using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [Header("===---Move Properties---===")]
    [SerializeField] private Vector3 InputVector;
    [SerializeField] private UltimateJoystick joystick;

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
        float h = joystick.GetHorizontalAxis();
        float v = joystick.GetVerticalAxis();

        InputVector.x = (Input.GetAxis("Horizontal") == 0) ? h : Input.GetAxis("Horizontal");
        InputVector.z = (Input.GetAxis("Vertical") == 0) ? v : Input.GetAxis("Vertical");

        if (InputVector.magnitude > 0)
        {
            Movement();
            Rotate();
        }
        else
        {
            Idle();
        }
    }

    private void Idle()
    {
        _rb.velocity = Vector3.zero;
        transform.rotation = transform.rotation;
        ChangeAnimation("idle");
        Attack();
    }

    private void Movement()
    {
        _rb.velocity = InputVector * characterMoveSpeed;
        ChangeAnimation("run");
    }

    private void Rotate()
    {
        Quaternion toRotate = Quaternion.LookRotation(InputVector, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, characterMoveSpeed);
    }
}
