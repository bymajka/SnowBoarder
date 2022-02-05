using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] private float TorqueMoment = 1f;
    [SerializeField] private float boostSpeed= 30f;
    [SerializeField] private float normalSpeed;
    private SurfaceEffector2D surfaceEffector2D;
    private bool CanMove = true;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    private void Update()
    {
        if (CanMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
    }

    public void DisableControl()
    {
        CanMove = false;
    }
    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb2d.AddTorque(TorqueMoment);
        } 
        else if (Input.GetKey(KeyCode.D))
        {
            rb2d.AddTorque(-TorqueMoment);
        }
    }
    
    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.W))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = normalSpeed;
        }
    }
    
    
}
