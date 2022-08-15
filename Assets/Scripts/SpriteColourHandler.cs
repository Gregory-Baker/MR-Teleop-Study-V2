using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpriteColourHandler : MonoBehaviour
{
    SpriteRenderer spriteRenderer = null;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetSpriteColor(Color color)
    {
        if (spriteRenderer!= null && color != null)
        {
            spriteRenderer.color = color;
        }
        
    }



}
