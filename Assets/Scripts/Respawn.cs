using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject paddle;

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
            Instantiate(paddle, transform.position, transform.rotation);
    }
}
