using UnityEngine;

public class CrabClaw : MonoBehaviour
{

    public GameObject body;
    public GameObject joycon;
    private jcdPlus joyconScript;
    public GameObject crab;

    public GameObject rotationObject;

    public LayerMask terrainLayer;
    public Rigidbody2D rb;

    [SerializeField] private float crabRotateSpeed;
   [SerializeField] private Color defaultColour;
    [SerializeField] private Color pinchColour;

    [SerializeField] private float spinSpeed;
    [SerializeField] private float maxArmRange;

    Vector2 defaultPos;

    Vector2 rotationPoint;

    private bool isPinched;
    private bool pinchingTerrain;
    private bool pinchingEnemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isPinched = false;
        joyconScript = joycon.GetComponent<jcdPlus>();
        defaultPos = new Vector2(0,-0.7f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPinched)
        {
            WaveArm(gameObject);
        }
      
        if (isPinched && Input.GetKeyUp(KeyCode.LeftArrow))
        {
            isPinched=false;
            GetComponent<SpriteRenderer>().color = defaultColour;

            pinchingTerrain = false;

            body.transform.SetParent(crab.transform);

            rotationObject.transform.SetParent(body.transform);

            //rotationObject.transform.position = body.transform.position;
        }

        Debug.DrawLine(transform.position, body.transform.position, Color.white);

        if (Input.GetKeyDown(KeyCode.R))
        {
            crab.transform.position = defaultPos;
        }

        if (!isPinched && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PinchClaw();
        }

        //if (isPinched && pinchingTerrain)
        //{
        //    WaveArm(body);
        //}
    }

    private void FixedUpdate()
    {
        if (isPinched && pinchingTerrain)
        {

            // WaveArm(body);



            Debug.Log("WILL ROTATE CRAB AT THIS POINT");
            float zRot = joyconScript.orientation.z * Mathf.Rad2Deg;
            zRot = Mathf.Clamp(zRot, -35, 35);

            rb.AddTorque(zRot * crabRotateSpeed);
        }
    }

    private void WaveArm(GameObject rotationCore)
    {
       

        float zRot = joyconScript.orientation.z * Mathf.Rad2Deg;
        zRot = Mathf.Clamp(zRot, -35, 35);

       // Debug.Log(zRot);
        if (zRot < 180 && zRot > 15)
        {
            rotationCore.transform.parent.Rotate(0, 0, Time.deltaTime * (zRot - 15) * spinSpeed);
        }

        if (zRot < -15 && zRot > -180)
        {
            rotationCore.transform.parent.Rotate(0, 0, Time.deltaTime * (zRot + 15) * spinSpeed);
        }
    }



    private void PinchClaw()
    {


        if (Physics2D.Raycast(transform.position, transform.up, 1f, terrainLayer))
        {
            Debug.Log("YAHOO");

            isPinched = true;

            //rotationPoint = transform.position;

            GetComponent<SpriteRenderer>().color = pinchColour;

            rotationObject.transform.SetParent(null);

            pinchingTerrain = true;

            body.transform.SetParent(rotationObject.transform);


        }




        // if()
    }

    private void LetGoClaw()
    {
        
    }
}
