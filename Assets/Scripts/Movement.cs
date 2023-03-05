using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Vector2 speed = new Vector2(10, 10);
    [SerializeField] bool hasJumped = false;
    [SerializeField] bool hasUnlockedDJB = false;
    [SerializeField] bool isInAir = false;
    Rigidbody2D rigidbodyjoe;
    void Start()
    {
        rigidbodyjoe = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Mover();
        Jump();
    }

    private void Jump()

    {
        if (hasJumped == false && Input.GetKeyDown(KeyCode.Space)&& isInAir== false)
        {
            float inputX = Input.GetAxis("Horizontal");
            float inputY = Input.GetAxis("Jump");
            rigidbodyjoe.velocity = new Vector2(speed.x * inputX, speed.y * inputY);


            
        }
        if (hasUnlockedDJB == true&& isInAir== true&& hasJumped == false)
        {

            JumpAgain();


        }
    }

    private void JumpAgain()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float inputX = Input.GetAxis("Horizontal");
            float inputY = Input.GetAxis("Jump");
            rigidbodyjoe.velocity = new Vector2(speed.x * inputX, speed.y * inputY);
            hasJumped = true;
        }
        
    }
    private void Mover()
    {
        float inputX = Input.GetAxis("Horizontal");
        rigidbodyjoe.velocity = new Vector2(speed.x * inputX, rigidbodyjoe.velocity.y);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hasJumped = false;
        isInAir = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isInAir = true;
    }
}
