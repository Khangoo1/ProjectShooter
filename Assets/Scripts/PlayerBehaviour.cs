﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    private Inputs inputs;
    private Vector2 direction;

    private void OnEnable()
    {
        inputs = new Inputs();
        inputs.Enable();
        inputs.Player.Move.performed += OnMovePerformed;
        inputs.Player.Move.canceled += OnMoveCanceled;
    }


    private void OnMovePerformed(InputAction.CallbackContext obj)
    {
       direction = obj.ReadValue<Vector2>();
    }

     private void OnMoveCanceled (InputAction.CallbackContext obj)
    {
       direction = Vector2.zero;
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var myRigidBody = GetComponent<Rigidbody2D>();
        if (myRigidBody.velocity.sqrMagnitude < maxSpeed)
            myRigidBody.AddForce(direction * speed);
    }

}
