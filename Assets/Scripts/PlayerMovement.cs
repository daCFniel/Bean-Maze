using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    // Getting reference of component
    [SerializeField]
    private Rigidbody rb;

    // Move forces
    [SerializeField]
    private int forwardForce = 2000;
    [SerializeField]
    private int sidewaystForce = 2000;

    // Start is called before the first frame update
    //void Start()
    //{
    //    //Changing value of component
    //    //rb.useGravity = false;
    //    rb.AddForce(0, 200, 500);
    //}

    // Update is called once per frame
    void FixedUpdate()
    {
        // Add force every frame,
        // Time.deltaTime makes the change being adaptive to the actual amout of FPS
        // This means the object will have the same speed on different machines

        //rb.AddForce(0, 0, 2000 * Time.deltaTime);
        // Simple player key movement
        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaystForce * Time.deltaTime, 0, 0);
        }  
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaystForce * Time.deltaTime, 0, 0);
        } 
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -forwardForce * Time.deltaTime);
        }
    }
}
