using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Speed on player
    public float speed = 5;

    // How high they jump
    public float jumpPower = 4;

    // Unity object for accessing the attached component Rigid Body
    Rigidbody rb;

    // Collider object for accessing the attached component Capsule Collider
    CapsuleCollider col;

    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get the input value from the controllers
        float Horizontal = Input.GetAxis("Horizontal") * speed;
        float Vertical = Input.GetAxis("Vertical") * speed;
        Horizontal *= Time.deltaTime;
        Vertical *= Time.deltaTime;

        //Translate our character via our inputs.
        transform.Translate(Horizontal, 0, Vertical);

        // Jump the player if they are on the ground
        if (isGrounded() && Input.GetButtonDown("Jump"))
        {
            //Add upward force to the rigid body when we press jump.
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }

        // Unlock the cursor mode
        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;
    }


    private bool isGrounded()
    {
        //Test that we are grounded by drawingan invisible line (raycast)
        //If this hits a solid object e.g.floor then we are grounded.
        return Physics.Raycast(transform.position, Vector3.down, col.bounds.extents.y + 0.1f);
    }
}