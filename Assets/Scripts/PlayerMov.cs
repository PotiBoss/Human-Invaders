using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public Joystick joystick;
    public float playerMoveSpeed;
    private Rigidbody2D myRigidBody;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        
    }

    void FixedUpdate()
    {
        if (joystick.joystickVector.y != 0)
        {
            myRigidBody.velocity = new Vector2(joystick.joystickVector.x * playerMoveSpeed, joystick.joystickVector.y * playerMoveSpeed);
        }

        else
        {
            myRigidBody.velocity = Vector2.zero;
        }
    }
}
