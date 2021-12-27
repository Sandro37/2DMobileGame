using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CharacterFacing2D : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void UpdateFacing(Vector2 movementInput)
    {
        if (movementInput.x > 0)
        {
            spriteRenderer.flipX = false; 
        }
        else if (movementInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }

    }

    public bool IsFacingRight()
    {
        return spriteRenderer.flipX == false;
    } 
}
