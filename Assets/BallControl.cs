﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private Vector2 trajectoryOrigin;
    public float xInitialForce;
    public float yInitialForce;
    
    void ResetBall()
    {
        transform.position = Vector2.zero;
        rigidBody2D.velocity = Vector2.zero;
        trajectoryOrigin = transform.position;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;
    }

    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }

    void PushBall()
    {
        float randomDirection = Random.Range(0, 2);
        if(randomDirection < 1.0f)
        {
            rigidBody2D.AddForce(new Vector2(-xInitialForce, yInitialForce));
        }
        else
        {
            rigidBody2D.AddForce(new Vector2(xInitialForce, yInitialForce));
        }
    }

    void RestartGame()
    {
        ResetBall();
        Invoke("PushBall", 2);
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        RestartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
