using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=UnityEngine.Random;



public class OnGoalEventArg : EventArgs
{
    public NumeroJugador jugador;

    public OnGoalEventArg(NumeroJugador jugador)
    {
        this.jugador = jugador;
    }
    
}

public class BallController : MonoBehaviour
{
    
    
    public float initialSpeed = 10f;
    private float mSpeedX;
    private float mSpeedY;
    private AudioSource mAudioSource;


    private Rigidbody2D mRb;


    // Evento
    public event EventHandler OnGoal;
    public AudioClip audioGoal;
    public AudioClip audioPaddle;
    public AudioClip audioWall;
    
    private void Start()
    {
        mRb = GetComponent<Rigidbody2D>();
        mAudioSource = GetComponent<AudioSource>();
        mSpeedX = Random.Range(0, 5) == 0 ? 5 : -5;
        mSpeedY = Random.Range(0, 5) == 0 ? 5 : -5;

        
        
        
    }

    
    private void Update()
    {
        // x = x + z
        // x += z
        //transform.position += Vector3.right * -speed * Time.deltaTime; 
        mRb.velocity = new Vector2(mSpeedX, mSpeedY);
        
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.CompareTag("Pvel"))
        {
            mSpeedX *= -2; 
        }
        
        if (collider.gameObject.CompareTag("Paddles"))
        {
            mAudioSource.clip = audioPaddle;
            mAudioSource.Play();
            mSpeedX *= -1;  

            mSpeedY = UnityEngine.Random.Range(-initialSpeed, initialSpeed);
        }else
        {
            mAudioSource.clip = audioWall;
            mAudioSource.Play();
            mSpeedY *= -1;
        }        

    }
    
    public float multiplier = 2f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pvel"))
        {
            mSpeedX = Random.Range(0, 5) == 0 ? 5 : -5 * multiplier;
            mSpeedY = Random.Range(0, 5) == 0 ? 5 : -5 * multiplier;
        }
        
        /*OnGoalEventArg data;
        if (mSpeedX < 0 )
        {
            data = new OnGoalEventArg( NumeroJugador.DOS);
        }else
        {
            data = new OnGoalEventArg(NumeroJugador.UNO);
        }*/
        mAudioSource.clip = audioGoal;
        mAudioSource.Play();
        
        OnGoalEventArg data = new OnGoalEventArg(
            mSpeedX < 0 ? NumeroJugador.DOS : NumeroJugador.UNO
        );
        
        // Sucede el evento OnGoal
        OnGoal?.Invoke(this, data);
    }

    public void ReInit()
    {
        transform.position = new Vector3(0f, 0f, 0f);
        mSpeedX = 0f;
        mSpeedY = 0f;
    }

    public void ReStart()
    {
        mSpeedX = -initialSpeed;
        mSpeedX = Random.Range(0, 5) == 0 ? 5 : -5;
        mSpeedY = Random.Range(0, 5) == 0 ? 5 : -5;
    }

    
}
