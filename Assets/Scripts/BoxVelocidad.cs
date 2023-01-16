using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxVelocidad : MonoBehaviour
{  
    public float multiplier = 2f;
    
    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.CompareTag("Ball"))
        {
            Pickup(other);
        }
    }

    void Pickup(Collider2D Ball)
    {
        Ball.transform.localScale *= multiplier;
    }

}
