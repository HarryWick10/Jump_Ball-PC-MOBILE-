using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPc : MonoBehaviour
{

    [SerializeField] private  Rigidbody rb;
    [SerializeField] private Vector3 direction=Vector3.up;
    [SerializeField] private float jumpSpeed=500;
    [SerializeField] private float Stop;
    public bool ground = false;
    public bool hold = false;
    void Start()
    {
        
        
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0)&&!hold&&ground)
        {
            Stop = 1;
        }

        if (Input.GetMouseButtonUp(0))
        {
            hold = true;
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
            rb.AddForce(direction * jumpSpeed*Stop);
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
