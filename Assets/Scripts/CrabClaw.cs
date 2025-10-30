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

   [SerializeField] private Color defaultColour;
    [SerializeField] private Color pinchColour;

    [SerializeField] private float spinSpeed;
    [SerializeField] private float maxArmRange;

    public KeyCode pinchKey;

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
      
        if (isPinched && Input.GetKeyUp(pinchKey))
        {
            isPinched=false;
            GetComponent<SpriteRenderer>().color = defaultColour;

            body.transform.SetParent(null);

            rotationObject.transform.SetParent(body.transform);
        }

        Debug.DrawLine(transform.position, body.transform.position, Color.white);

        if (Input.GetKeyDown(KeyCode.R))
        {
            crab.transform.position = defaultPos;
        }

        if (!isPinched && Input.GetKeyDown(pinchKey))
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
            Debug.Log("WILL ROTATE CRAB AT THIS POINT");
            float zRot = joyconScript.orientation.z * Mathf.Rad2Deg;
            zRot = Mathf.Clamp(zRot, -35, 35);

            rb.AddTorque((zRot - 15) * spinSpeed);
        }
    }

    private void WaveArm(GameObject rotationCore)
    {
       

        float zRot = joyconScript.orientation.z * Mathf.Rad2Deg;
        zRot = Mathf.Clamp(zRot, -35, 35);

       Debug.Log(zRot);
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
        

        if (Physics2D.Raycast(transform.position,transform.up,1f,terrainLayer))
        {
            Debug.Log("YAHOO");

            isPinched = true;

            //rotationPoint = transform.position;

             GetComponent<SpriteRenderer>().color = pinchColour;

            rotationObject.transform.SetParent(null);

            body.transform.SetParent(rotationObject.transform);


            body.GetComponent<Rigidbody2D>();
           
        }
         
         
        

       // if()
    }
}
