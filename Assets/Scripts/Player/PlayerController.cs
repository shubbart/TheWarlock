using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    float speedModifier = 1;
    public float jumpForce;
    bool isJumping;
    bool isAttacking;
    Rigidbody rbody;
    public Animator anim;

    Vector3 movement;
    Vector3 direction;
    Quaternion newRotation;
    Vector3 playerToMouse;
    int floorMask;
    float camRayLength = 100f;

    public bool isCasting;
    public bool longCasting;

    public GameObject activeSlot;

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
        if(!longCasting)
            Move(h,v);
        if(longCasting)
            anim.SetBool("isRunning", false);
        GetFacing();
        //Jump();
        Rotate();
    }

    void Move(float h, float v)
    {
        // Set the movement vector based on the axis input.
        movement.Set(h, 0f, v);
        //direction.Set(h, 0f, v);
        if(h != 0 || v != 0)
            anim.SetBool("isRunning", true);
        else
            anim.SetBool("isRunning", false);

        // Normalize the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * speedModifier * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        rbody.MovePosition(transform.position + movement);
    }

    void GetFacing()
    {
        float angle = Vector3.Angle(movement, transform.forward);
        Vector3 cross = Vector3.Cross(movement, transform.forward);

        if (cross.y < 0)
            angle = -angle;

        if (angle > 90 || angle < -90)
            speedModifier = .5f;
        else
            speedModifier = 1;

        anim.SetFloat("Direction", angle);
    }

    //void Jump()
    //{
    //    RaycastHit floorHit;
    //    if (Physics.Raycast(transform.position, -transform.up, out floorHit, 1f, floorMask))
    //    {
    //        rbody.AddForce(transform.up * jumpForce * Input.GetAxis("Jump"), ForceMode.Impulse);
            
    //    }
    //    if (rbody.velocity.y > 0)
    //        anim.SetBool("isJumping", true);
    //    else
    //        anim.SetBool("isJumping", false);

    //    Debug.Log(rbody.velocity.y);
    //}



    void Rotate()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            playerToMouse = floorHit.point - transform.position;

            // Ensure the vector is entirely along the floor plane.
            playerToMouse.y = 0f;

            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            newRotation = Quaternion.LookRotation(playerToMouse);

            // Set the player's rotation to this new rotation.
            rbody.MoveRotation(newRotation);
        }
    }
}
