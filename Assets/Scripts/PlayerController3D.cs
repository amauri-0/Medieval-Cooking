using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController3D : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody rb;
    Animator animator;
    public float walkSpeed = 5f;
    public float runSpeed = 8f;
    public float turnSpeed = 10f;

    private bool _isMoving = false;
    public bool IsMoving
    {
        get => _isMoving;
        private set
        {
            _isMoving = value;
            if (animator) animator.SetBool("isMoving", value);
        }
    }

    private bool _isRunning = false;
    public bool IsRunning
    {
        get => _isRunning;
        private set
        {
            _isRunning = value;
            if (animator) animator.SetBool("isRunning", value);
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Vector3 move = GetMoveDirection();
        float speed = CurrentMoveSpeed;

        Vector3 targetVel = new Vector3(move.x * speed, rb.velocity.y, move.z * speed);
        rb.velocity = targetVel;

        if (animator)
        {
            animator.SetFloat("yVelocity", rb.velocity.y);
            animator.SetFloat("speed", new Vector2(rb.velocity.x, rb.velocity.z).magnitude);
        }

        HandleRotation(move);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        IsMoving = moveInput != Vector2.zero;
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.started && _isMoving)
            IsRunning = true;
        else if (context.canceled)
            IsRunning = false;
    }

    private Vector3 GetMoveDirection()
    {
        Vector3 move = Vector3.zero;
        if (Camera.main != null)
        {
            Vector3 camForward = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up).normalized;
            Vector3 camRight = Vector3.ProjectOnPlane(Camera.main.transform.right, Vector3.up).normalized;
            move = camRight * moveInput.x + camForward * moveInput.y;
        }
        else
        {
            move = new Vector3(moveInput.x, 0f, moveInput.y);
        }

        move.y = 0f;
        if (move.magnitude > 1f) move.Normalize();
        return move;
    }

    private void HandleRotation(Vector3 move)
    {
        if (move.sqrMagnitude > 0.001f)
        {
            Quaternion targetRot = Quaternion.LookRotation(move, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, turnSpeed * Time.deltaTime);
        }
    }

    public float CurrentMoveSpeed
    {
        get
        {
            if (IsMoving)
            {
                return IsRunning ? runSpeed : walkSpeed;
            }
            return 0f;
        }
    }
}
