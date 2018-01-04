using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    bool isJumping;
    bool isAttacking;
    Rigidbody rbody;
    public Animator anim;

    Vector3 movement;
    int floorMask;
    float camRayLength = 100f;

    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Move(h,v);
        Jump();
        resetJump();
        Rotate();

        anim.SetBool("IsWalking", rbody.velocity.magnitude > 0.1f);

    }

    void Move(float h, float v)
    {
        // Set the movement vector based on the axis input.
        movement.Set(h, 0f, v);

        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        rbody.MovePosition(transform.position + movement);
    }

    void Jump()
    {
        if (!isJumping)
        {
            rbody.AddForce(transform.up * jumpForce * Input.GetAxis("Jump"), ForceMode.Impulse);
            isJumping = true;
        }
    }

    void resetJump()
    {
        if (rbody.velocity.y == 0)
            isJumping = false;
    }

    void Rotate()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            Vector3 playerToMouse = floorHit.point - transform.position;

            // Ensure the vector is entirely along the floor plane.
            playerToMouse.y = 0f;

            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            // Set the player's rotation to this new rotation.
            rbody.MoveRotation(newRotation);
        }
    }

    void mainAttack()
    {
        isAttacking = true;
    }

    void altAttack()
    {

    }

}
