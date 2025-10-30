using UnityEngine;

public class CrabClaw : MonoBehaviour
{

    public GameObject body;
    public GameObject joycon;
    private jcdPlus joyconScript;
    public GameObject crab;

    [SerializeField] private float spinSpeed;
    [SerializeField] private float maxArmRange;

    Vector2 defaultPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        joyconScript = joycon.GetComponent<jcdPlus>();
        defaultPos = new Vector2(0,-0.7f);
    }

    // Update is called once per frame
    void Update()
    {

        Move();

        Debug.DrawLine(transform.position, body.transform.position, Color.white);

        if (Input.GetKeyDown(KeyCode.R))
        {
            crab.transform.position = defaultPos;
        }  
    }

    private void Move()
    {
       

        float zRot = joyconScript.orientation.z * Mathf.Rad2Deg;
        zRot = Mathf.Clamp(zRot, -35, 35);

        Debug.Log(zRot);
        if (zRot < 180 && zRot > 15)
        {
            transform.parent.Rotate(0, 0, Time.deltaTime * (zRot - 15) * spinSpeed);
        }

        if (zRot < -15 && zRot > -180)
        {
            transform.parent.Rotate(0, 0, Time.deltaTime * (zRot + 15) * spinSpeed);
        }
    }
    
}
