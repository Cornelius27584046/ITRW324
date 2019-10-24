using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayStyle : MonoBehaviour
{
    private float movementSpeed = 3f;
    private Rigidbody2D rb;
    private IsometricCharacterRenderer isoRenderer;
    private Vector2 inputVector;
    private float ChardirX;
    private float ChardirY;
    private float horizontalInput;
    private float verticalInput;

    void Awake()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        ChardirX = Input.acceleration.x * movementSpeed;
        ChardirY = Input.acceleration.y * movementSpeed;
        rb = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
        CharacterAttributes.PlayerHealth.setHealth(0, 100);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
        CharacterAttributes.PlayerHealth.setHealth(0, 100);
    }
    void FixedUpdate()
    {
        Vector2 currentPos = rb.position;
        determineDevice(); //calldevice method
        inputVector = Vector2.ClampMagnitude(inputVector, 1);
        Vector2 movement = inputVector * movementSpeed;
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        isoRenderer.SetDirection(movement);
        rb.MovePosition(newPos);
    }
    public void determineDevice()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            inputVector = new Vector2(horizontalInput, verticalInput);
            rb.velocity = new Vector2(ChardirX, ChardirY);
        }
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            ChardirX = Input.acceleration.x * movementSpeed;
            ChardirY = Input.acceleration.y * movementSpeed;
            inputVector = new Vector2(ChardirX, ChardirY);
            rb.velocity = new Vector2(ChardirX, ChardirY);
            transform.position = new Vector2(Mathf.Clamp(transform.position.x, -23f, 31f), Mathf.Clamp(transform.position.y, -12, 20));
        }
    }
}
