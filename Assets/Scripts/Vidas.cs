using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vidas : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            hit += 1;
            checkhit();
        }        
        
    }

    
    public int hit = 0;
    void checkhit()
    {
        if(hit == 10)
            {
                Destroy(gameObject);
            }
    }


    
}
