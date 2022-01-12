using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;

    private Animator robotAnim;
    private Joystick joyStick;
    private Rigidbody robotBody;


    void Start()
    {
        robotAnim = GetComponent<Animator>();
        robotBody = GetComponent<Rigidbody>();
        joyStick = FindObjectOfType<Joystick>(); // look for the joystick component.

        robotAnim.SetBool("Open_Anim", true);
    }


    void Update()
    {
        // Capture the joystick values and move forward
        if(joyStick.Direction.magnitude > 0)
        {
            // Add a movement force
            robotBody.AddForce(transform.forward * moveSpeed);

            robotAnim.SetBool("Walk_Anim", true);
        }
        else
        {
            robotAnim.SetBool("Walk_Anim", false);
        }

        // Rotate the robot

        Vector3 targetDirection = new Vector3(joyStick.Direction.x, 0, joyStick.Direction.y);

        Vector3 direction = Vector3.RotateTowards(transform.forward, targetDirection, turnSpeed * Time.deltaTime, 0);

        transform.rotation = Quaternion.LookRotation(direction);
    }
}
