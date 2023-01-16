using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxVida : MonoBehaviour
{
    public float multiplier = 2f;
    public float speed = 5f;
    
    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.CompareTag("Ball"))
        {
            Pickup(other);
        }
    }

    void Pickup(Collider2D other)
    {
        speed *= multiplier;
    }

    
    
}
