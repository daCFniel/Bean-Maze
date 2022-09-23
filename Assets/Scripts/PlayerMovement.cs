using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    // Getting reference of component
    [SerializeField]
    private Rigidbody rb;

    // Move forces
    [SerializeField]
    private int forwardForce = 2000;
    [SerializeField]
    private int sidewaysForce = 2000;

    public float getUpSpeed = 30f;

    public float upAngle;

    private bool standingUp;

    private float speedLimit = 0.1f;

    void FixedUpdate()
    {
        // Add force every frame,
        // Time.deltaTime makes the change being adaptive to the actual amout of FPS
        // This means the object will have the same speed on different machines

        //var hoizontalAxis = Input.GetAxis("Horizontal");
        //var verticalAxis = Input.GetAxis("Vertical");
        //rb.AddForce(sidewaysForce * Time.deltaTime * hoizontalAxis, 0, 0);
        //rb.AddForce(0, 0, forwardForce * Time.deltaTime * verticalAxis);

        upAngle = Vector3.Angle(gameObject.transform.up, Vector3.up);

        //if (upAngle >= angleLimit && velocity <= 0.1) //stand up
        //{
        //    if (standingUp == false)
        //    {
        //        standingUp = true;
        //    }
        //} 
        //if (standingUp)
        //{
        //    StandUp();
        //    if (upAngle <= 10f)
        //    {
        //        standingUp = false;
        //        rb.useGravity = true;
        //        rb.rotation = Quaternion.identity;
        //        rb.velocity = Vector3.zero;
        //        rb.Sleep();
        //    }
        //}

        if (Input.GetKey("d"))
        {
            //if (CheckIfFallen())
            //{
            //    if (!standingUp)
            //    {
            //        standingUp = true;
            //    }
            //    StandUp();

            //} else if (!standingUp)
            //{
                rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0);
            //}
        }  
        if (Input.GetKey("a"))
        {
            //if (CheckIfFallen())
            //{
            //    if (!standingUp)
            //    {
            //        standingUp = true;
            //    }
            //    StandUp();

            //}
            //else if (!standingUp)
            //{
                rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0);
            //}
        } 
        if (Input.GetKey("w"))
        {
            //if (CheckIfFallen())
            //{
            //    if (!standingUp)
            //    {
            //        standingUp = true;
            //    }
            //    StandUp();

            //}
            //else if (!standingUp)
            //{
                rb.AddForce(0, 0, forwardForce * Time.deltaTime);
            //}
        }
        if (Input.GetKey("s"))
        {
            //if (CheckIfFallen())
            //{
            //    if (!standingUp)
            //    {
            //        standingUp = true;
            //    }
            //    StandUp();

            //}
            //else if (!standingUp)
            //{
                rb.AddForce(0, 0, -forwardForce * Time.deltaTime);
            //}
        }

        if(Input.GetKey("space"))
        {
            rb.useGravity = false;
        }
    }

    private void StandUp()
    {
        Vector3 p = rb.position;
        rb.useGravity = false;
        rb.rotation = Quaternion.Lerp(rb.rotation, Quaternion.identity, getUpSpeed * Time.deltaTime);
        rb.position = p;
        if (upAngle <= 10f)
        {
            rb.rotation = Quaternion.identity;
            rb.velocity = Vector3.zero;
            //rb.Sleep();
            rb.useGravity = true;
            standingUp = false;
        }

    }

    private bool CheckIfFallen()
    {
        return (rb.velocity.magnitude <= speedLimit && upAngle != 0) || standingUp;
    }
}


