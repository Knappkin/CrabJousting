using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class TrigClaw : MonoBehaviour
{
    public GameObject joycon;
    private jcdPlus joyconScript;
    public GameObject body;
    public GameObject crab;

    private Rigidbody2D rbClaw;
    public Rigidbody2D rbBody;

    [SerializeField] private float clawRadius;
    private Vector3 bodyVector;
    private Vector3 clawVector;

    public LayerMask terrainLayer;
    public LayerMask crabLayer;

    [SerializeField] private Color defaultColour;
    [SerializeField] private Color pinchColour;

    [SerializeField] private float motionBuffer;
    [SerializeField] private float spinSpeed;

    [SerializeField] private float startClawAngle;

    float clawAngle;
    float bodyAngle;

    private bool isPinchedGround;

    public GameObject enemyBody;
    public TrigClaw enemyScript;

    public KeyCode pinchKey;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(transform.parent.name);
        clawAngle = startClawAngle;
        bodyAngle = 0;

        rbClaw = GetComponent<Rigidbody2D>();
        rbBody = body.GetComponent<Rigidbody2D>();

        joyconScript = joycon.GetComponent<jcdPlus>();

        isPinchedGround = false;

        //rbClaw.MovePosition(clawAngle * radius);

    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(pinchKey) && !isPinchedGround)
        {
            PinchClaw();
        }

        if (Input.GetKeyUp(pinchKey) && isPinchedGround)
        {
            LetGoTerrain();

        }
    }
    void FixedUpdate()
    {

       if (!isPinchedGround)
        {
            WaveArm();
        }

       if (isPinchedGround)
        {
            MoveBody();
        }

    }

    private void WaveArm()
    {
        float zRot = joyconScript.orientation.z;
        zRot = Mathf.Clamp(zRot, -35, 35);

        if (Mathf.Abs(zRot) > motionBuffer)
        {
            clawAngle += zRot * spinSpeed;
        }

        float clawAngleRad = clawAngle * Mathf.Deg2Rad;
        Vector2 clawDirection = new Vector2(Mathf.Cos(clawAngle), Mathf.Sin(clawAngle)).normalized;
        clawVector = rbBody.position + clawDirection * clawRadius;

        rbClaw.MovePosition(clawVector);
    }

    private void PinchClaw()
    {


        if (Physics2D.Raycast(transform.position, transform.up, 1f, terrainLayer))
        {

            isPinchedGround = true;

            //rotationPoint = transform.position;

            GetComponent<SpriteRenderer>().color = pinchColour;

           


           

        }

        if (Physics2D.Raycast(transform.position, transform.up, 1f, crabLayer))
        {
            Debug.Log("ADASDA:LSDA:LD");
        }
    }

    private void LetGoTerrain()
    {
        isPinchedGround = false;
        GetComponent<SpriteRenderer>().color = defaultColour;
    }

    private void MoveBody()
    {
        float zRot = joyconScript.orientation.z;
        zRot = Mathf.Clamp(zRot, -35, 35);

        if (Mathf.Abs(zRot) > motionBuffer)
        {
            bodyAngle += zRot * spinSpeed;
        }

        float bodyAngleRad = bodyAngle * Mathf.Deg2Rad;
        Vector2 bodyDirection = new Vector2(Mathf.Cos(bodyAngle), Mathf.Sin(bodyAngle)).normalized;
        bodyVector = rbClaw.position + bodyDirection * clawRadius;

        

        Vector2 bodyDirectionVector = (rbClaw.position - rbBody.position).normalized;


        bodyAngleRad = Mathf.Atan2(bodyDirectionVector.y, bodyDirectionVector.x);
       

        if (!Physics2D.Raycast(bodyVector, rbBody.transform.up, 1, terrainLayer))
        {
            rbBody.MovePosition(bodyVector);
        }
       



    }

    }
