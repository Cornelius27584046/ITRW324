using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayStyle : MonoBehaviour
{
    private float movementSpeed = 1f;
    private Rigidbody2D rb;
    private IsometricCharacterRenderer isoRenderer;
    public PlayStyle()
    {
        Debug.Log("Determining device");
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            void Awake()
            {
                rb = GetComponent<Rigidbody2D>();
                isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
                CharacterAttributes.PlayerHealth.setHealth(0, 100);
            }
         // Update is called once per frame
            void FixedUpdate()
            {
                Vector2 currentPos = rb.position;
                float horizontalInput = Input.GetAxis("Horizontal");
                float verticalInput = Input.GetAxis("Vertical");
                Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
                inputVector = Vector2.ClampMagnitude(inputVector, 1);
                Vector2 movement = inputVector * movementSpeed;
                Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
                isoRenderer.SetDirection(movement);
                rb.MovePosition(newPos);
            }
        }
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            float ChardirX;
            float ChardirY;

            void Start()
            {
                rb = GetComponent<Rigidbody2D>();
                isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
                CharacterAttributes.PlayerHealth.setHealth(0, 100);
            }

            void Update()
            {
                ChardirX = Input.acceleration.x * movementSpeed;
                ChardirY = Input.acceleration.y * movementSpeed;
                transform.position = new Vector2(Mathf.Clamp(transform.position.x, -23f, 23f), Mathf.Clamp(transform.position.y, -12, 13));
            }
            void FixedUpdate()
            {
                rb.velocity = new Vector2(ChardirX, ChardirY);
                Vector2 currentPos = rb.position;
                Vector2 inputVector = new Vector2(ChardirX, ChardirY);
                inputVector = Vector2.ClampMagnitude(inputVector, 1);
                Vector2 movement = inputVector * movementSpeed;
                Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
                isoRenderer.SetDirection(movement);
                rb.MovePosition(newPos);
            }
        }
    }
}
