using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public Joystick joystick;
    public float playerMoveSpeed;
    private Rigidbody2D myRigidBody;


    float xMin;
    float xMax;
    float yMin;
    float yMax;


    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        SetUpMoveBoundaries();   
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

        Move();
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0.045f, 0, 0)).x;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(0.955f, 0, 0)).x;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0.025f, 0)).y;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 0.955f, 0)).y;
    }

    private void Move()
    {
        var newXPos = Mathf.Clamp(transform.position.x, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y, yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);
    }

}
