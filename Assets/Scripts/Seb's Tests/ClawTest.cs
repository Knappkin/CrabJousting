using UnityEngine;
using UnityEngine.UIElements;

public class ClawTest : MonoBehaviour
{

    public GameObject Joycon1;
    private JoyconDemo joyconScript;

    private float pointSpeed = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        joyconScript = Joycon1.GetComponent<JoyconDemo>();
    }

    // Update is called once per frame
    void Update()
    {

        Quaternion joyconOrientation = joyconScript.orientation;
       
    }
}
