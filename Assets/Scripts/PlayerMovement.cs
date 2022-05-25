using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jumpForce = 5f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Starts variables from project preferences to get input key values (w, a ,s d)
        float horizInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizInput * movementSpeed, rb.velocity.y, vertInput * movementSpeed);


        //Whilst holding onto a key which moves in the direction in x or z, the object can move in those directions mid air.
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Head"))
        {
            //Destroys the object entirley from the scene and won't run the script for the enemy script
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }

    bool IsGrounded()
    {
        //First parameter takes in the groundCheck object (feet) made in unity
        //Second parameter is size of sphere
        //Third parameter checks for what objects collides into
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }

}
