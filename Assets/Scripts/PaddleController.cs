using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ControlType
{
    Keyboard, Mouse
}

public class PaddleController : MonoBehaviour
{
    
    public float speed = 1f;
    public ControlType controlType;
    Vector2 startPosition;
    
    private void Start() 
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        float inputMovement = controlType == ControlType.Keyboard
            ? Input.GetAxis("Vertical")
            : Input.GetAxis("Mouse Y");
        
        Vector3 newPosition = new Vector3(
            transform.position.x,
            Mathf.Clamp(
                transform.position.y + (inputMovement * speed * Time.deltaTime),
                -4.9f,
                4.9f
            ),
            transform.position.z
        );
        
        transform.position = newPosition; 


        
    }

    public void ResetPaddle()
    {
        transform.position = startPosition;
        
    }
           
}

