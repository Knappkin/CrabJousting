using UnityEngine;

public class Ready2 : MonoBehaviour
{
    public Sprite newSprite;   // Assign this in the Inspector

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            // Get the SpriteRenderer component on this GameObject
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            // Check if the SpriteRenderer and the new sprite are assigned
            if (spriteRenderer != null && newSprite != null)
            {
                // Change the sprite
                spriteRenderer.sprite = newSprite;
            }
            else
            {
                Debug.LogWarning("SpriteRenderer or newSprite not assigned on " + gameObject.name);
            }
        }
    }
}
