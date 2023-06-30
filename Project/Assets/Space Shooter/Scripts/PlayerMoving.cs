using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// This script defines the borders of ‘Player’s’ movement. Depending on the chosen handling type, it moves the ‘Player’ together with the pointer.
/// </summary>

[System.Serializable]
public class Borders
{
    [Tooltip("offset from viewport borders for player's movement")]
    public float minXOffset = 1.5f, maxXOffset = 1.5f, minYOffset = 1.5f, maxYOffset = 1.5f;
    [HideInInspector] public float minX, maxX, minY, maxY;
}

public class PlayerMoving : MonoBehaviour {

    [Tooltip("offset from viewport borders for player's movement")]
    public Borders borders;
    Camera mainCamera;

    private int playerSpeed = 10;
    private Vector2 moveInput;
    private Rigidbody2D rb;

    public static PlayerMoving instance; //unique instance of the script for easy access to the script

    private void Start()
    {
        mainCamera = Camera.main;
        ResizeBorders();                //setting 'Player's' moving borders deending on Viewport's size
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 newPosition = rb.position + moveInput * playerSpeed * Time.fixedDeltaTime;
        newPosition.x = Mathf.Clamp(newPosition.x, borders.minX, borders.maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, borders.minY, borders.maxY);
        rb.MovePosition(newPosition);
    }


        void OnMove(InputValue value)
    {
        moveInput =  value.Get<Vector2>();
    }

    //setting 'Player's' movement borders according to Viewport size and defined offset
    void ResizeBorders() 
    {
        borders.minX = mainCamera.ViewportToWorldPoint(Vector2.zero).x + borders.minXOffset;
        borders.minY = mainCamera.ViewportToWorldPoint(Vector2.zero).y + borders.minYOffset;
        borders.maxX = mainCamera.ViewportToWorldPoint(Vector2.right).x - borders.maxXOffset;
        borders.maxY = mainCamera.ViewportToWorldPoint(Vector2.up).y - borders.maxYOffset;
    }
}
