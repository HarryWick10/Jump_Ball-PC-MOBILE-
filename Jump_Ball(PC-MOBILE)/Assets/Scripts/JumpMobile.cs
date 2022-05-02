using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMobile : MonoBehaviour
{
    //only works on mobile devices//
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Vector3 direction = Vector3.up;
    [SerializeField] private float jumpSpeed = 500;
    [SerializeField] private float Stop;
    public bool ground = false;
    public bool hold = false;
    Touch touch;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if (Input.touchCount>0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase==TouchPhase.Began&&!hold&&ground)
            {
                Stop = 1;
            }
            if (touch.phase==TouchPhase.Ended)
            {
                hold = true;
            }
        }
        if (!ground)
        {
            Stop = 0;
        }



    }

    private void FixedUpdate()
    {
        if (hold)
        {
            rb.AddForce(direction * jumpSpeed * Stop);
            hold = false;
            ground = false;




        }

    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("ground"))
        {
            ground = true;


        }




    }










}
