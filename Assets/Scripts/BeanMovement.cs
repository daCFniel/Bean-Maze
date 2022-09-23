using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BeanMovement : MonoBehaviour
{
    private Rigidbody rb;

    public float rotationSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(Vector3.forward);
        if (Input.GetKey(KeyCode.S))
            rb.AddForce(Vector3.back);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(Vector3.right);
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(Vector3.left);
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementDirection), Time.deltaTime * rotationSpeed);
    }
}
