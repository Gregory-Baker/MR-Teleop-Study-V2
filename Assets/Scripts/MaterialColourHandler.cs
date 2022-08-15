using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialColourHandler : MonoBehaviour
{

    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();    
    }

    public void SetMaterialColour(Color color)
    {
        if(rend != null && color != null) rend.material.color = color;
    }
}

