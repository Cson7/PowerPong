using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn1 : MonoBehaviour
{
    public GameObject paddle;

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
            Instantiate(paddle, transform.position, transform.rotation);
    }
}
