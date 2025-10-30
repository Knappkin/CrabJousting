using UnityEngine;
using UnityEngine.UI; // Required for Image component

public class Ready1 : MonoBehaviour
{
    public Sprite newSprite;   // Assign this in the Inspector
    public bool isReady;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isReady = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            // Get the SpriteRenderer component on this GameObject
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            // Check if the SpriteRenderer and the new sprite are assigned
            if (spriteRenderer != null && newSprite != null)
            {
                // Change the sprite
                spriteRenderer.sprite = newSprite;
                isReady = true;
            }
            else
            {
                Debug.LogWarning("SpriteRenderer or newSprite not assigned on " + gameObject.name);
            }
        }
    }
}
