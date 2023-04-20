using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour {
    public float walkSpeed = 20f;
    public float runSpeed = 40f;
    public Vector3 direction;
    
    private float currentSpeed;
    private Animator _animator;

    private static readonly int Walk = Animator.StringToHash("Walk");
    private static readonly int Run = Animator.StringToHash("Run");

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update () {
        // Get input from the arrow keys
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
 
        // Calculate movement direction and speed
        direction = new Vector3(horizontal, 0f, vertical);
        direction.Normalize();
 
        if (Input.GetKey(KeyCode.LeftShift)) {
            currentSpeed = runSpeed;
            _animator.SetBool(Run,true);
        } else {
            currentSpeed = walkSpeed;
            _animator.SetBool(Run,false);
        }
 
        // Move the player
        transform.position += direction * (currentSpeed * Time.deltaTime);
        if (Vector3.zero != direction)
        {
            _animator.SetBool(Walk,true);
            transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (direction), Time.deltaTime * 40f);
        }
        else
        {
            _animator.SetBool(Walk,false);
        }
    }
}