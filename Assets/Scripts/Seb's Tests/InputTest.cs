using UnityEngine;

public class InputTest : MonoBehaviour
{
    private P1Controls inputController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        inputController = new P1Controls();
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnPinch()
    {
        Debug.Log("PINCHED");
    }
}
