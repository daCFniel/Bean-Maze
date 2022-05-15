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
    // Stand up speed
    [SerializeField]
    private float standUpSpeed = 1.0f;

    Vector3 m_EulerAngleVelocity;

    // Start is called before the first frame update
    //void Start()
    //{
    //    //Changing value of component
    //    //rb.useGravity = false;
    //    rb.AddForce(0, 200, 500);
    //}

    // Update is called once per frame
    void Start()
    {
        //Set the angular velocity of the Rigidbody (rotating around the Y axis, 100 deg/sec)
        m_EulerAngleVelocity = new Vector3(0, 100, 0);
    }

    void FixedUpdate()
    {
        // Add force every frame,
        // Time.deltaTime makes the change being adaptive to the actual amout of FPS
        // This means the object will have the same speed on different machines

        //rb.AddForce(0, 0, 2000 * Time.deltaTime);
        // Simple player key movement
        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);
        if(Input.GetKey(KeyCode.Space)) //stand up
        {
            transform.rotation = Quaternion.identity;
        }
        
        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaystForce * Time.deltaTime, 0, 0);
            
        }  
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaystForce * Time.deltaTime, 0, 0);
            rb.MoveRotation(rb.rotation * deltaRotation);
        } 
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -forwardForce * Time.deltaTime);
        }

         if (rb.position.y < -1f)
        {
            //FindObjectOfType<Score>().SetText("Game Over");
            //FindObjectOfType<GameController>().EndGame();
        }

        //Quaternion startRotation = transform.rotation;
        //if (transform.rotation.x != 0 || transform.rotation.y != 0 || transform.rotation.z != 0)
        //{
        //    rb.useGravity = false;
        //} else
        //{
        //    rb.useGravity = true;
        //}
        //Quaternion endRotation = new Quaternion(0f, 0f, 0f, transform.rotation.w);
        //transform.rotation = Quaternion.Lerp(startRotation, endRotation, Time.deltaTime * standUpSpeed);

        Quaternion upRot = Quaternion.FromToRotation(transform.up, Vector3.up);
        upRot *= transform.rotation;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, upRot, Time.deltaTime * standUpSpeed);

        //StandUp();
    }

    public void StandUp()
    {
        //Quaternion startRotation = transform.rotation;
        //Quaternion endRotation = new Quaternion(0.0F, transform.rotation.y, 0.0F, transform.rotation.w);
        //transform.rotation = Quaternion.Slerp(startRotation, endRotation, Time.deltaTime);
    }
}


