using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using NUnit.Framework;
using System.Runtime.InteropServices.WindowsRuntime;



    [SelectionBase]
public class Player : MonoBehaviour
{

    public static Player Instance { get; private set; }

    private float minMovingSpeed = 0.1f;
    private bool isRunning = false;

    [SerializeField] private float movingSpeed = 10f;
    Vector2 InputVector;

    private PlayerInputActions PlayerInputActions;


    private Rigidbody2D rb;


    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();

    }

    private void Start()
    {
        GameInput.Instance.OnPlayerAttack += GameInput_OnPlayerAttack;
    }


    private void GameInput_OnPlayerAttack(object sender, System.EventArgs e)
    {
        ActiveWeapon.Instance.GetActiveWeapon().Attack();
    }
    private void Update()
    {
        InputVector = GameInput.Instance.GetMovementVector();

    }


    private void FixedUpdate()
    {
        HandleMovement();


    }


    private void HandleMovement()
    {
        Vector2 InputVector = GameInput.Instance.GetMovementVector();
        rb.MovePosition(rb.position + InputVector * (movingSpeed * Time.fixedDeltaTime));
        if (Math.Abs(InputVector.x) > minMovingSpeed || Math.Abs(InputVector.y) > minMovingSpeed)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
    }

    public bool IsRunning()
    {
        return isRunning;
    }

    public Vector3 GetPlayerScreenPosition()
    {
        Vector3 playerScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        return playerScreenPosition;
    }
    }




