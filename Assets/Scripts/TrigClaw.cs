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

    private float clawRadius;
    private Vector3 bodyVector;
    private Vector3 clawVector;

    public LayerMask terrainLayer;
    [SerializeField] private Color defaultColour;
    [SerializeField] private Color pinchColour;

    [SerializeField] private float motionBuffer;
    [SerializeField] private float spinSpeed;
    float clawAngle;

    private bool isPinchedGround;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clawRadius = 3;
        clawAngle = 0;

        rbClaw = GetComponent<Rigidbody2D>();

        joyconScript = joycon.GetComponent<jcdPlus>();

        isPinchedGround = false;
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
        clawVector = rbBody.position + new Vector2(Mathf.Cos(clawAngle), Mathf.Sin(clawAngle) * clawRadius);

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

    }
