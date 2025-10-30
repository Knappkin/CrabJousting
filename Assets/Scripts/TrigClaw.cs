using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class TrigClaw : MonoBehaviour
{
    public GameObject joycon;
    private jcdPlus joyconScript;
    public GameObject body;

    private Rigidbody2D rbClaw;
    public Rigidbody2D rbBody;

    [SerializeField] private float clawRadius;
    private Vector3 bodyVector;
    private Vector3 clawVector;

    public LayerMask terrainLayer;
    [SerializeField] private Color defaultColour;
    [SerializeField] private Color pinchColour;

    [SerializeField] private float motionBuffer;
    [SerializeField] private float spinSpeed;
    float clawAngle;
    float bodyAngle;

    private bool isPinchedGround;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        clawAngle = 0;
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
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !isPinchedGround)
        {
            PinchClaw();
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) && isPinchedGround)
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
            Debug.Log("YAHOO");

            isPinchedGround = true;

            //rotationPoint = transform.position;

            GetComponent<SpriteRenderer>().color = pinchColour;

            //  rotationObject.transform.SetParent(null);

            //body.transform.SetParent(rotationObject.transform);


            body.GetComponent<Rigidbody2D>();

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
        //Vector2 bodyPosition = bodyDirectionVector * clawRadius;

        bodyAngleRad = Mathf.Atan2(bodyDirectionVector.y, bodyDirectionVector.x);
        // bodyAngle = bodyAngleRad * Mathf.Rad2Deg;

        //float zRot = joyconScript.orientation.z;
        //zRot = Mathf.Clamp(zRot, -35, 35);

        if (!Physics2D.Raycast(rbBody.position, rbBody.transform.up, 1, terrainLayer))
        {
            rbBody.MovePosition(bodyVector);
        }
        //if (Mathf.Abs(zRot) > motionBuffer)
        //{
        //    bodyAngle += zRot * spinSpeed;
        //}

        //bodyAngleRad = bodyAngle * Mathf.Deg2Rad;

        //Vector2 bodyDirection = new Vector2(Mathf.Cos(bodyAngleRad), Mathf.Sin(bodyAngleRad)).normalized;
        //bodyVector = rbClaw.position + bodyDirection * clawRadius;

        //rbBody.MovePosition(bodyVector);



    }

    }
