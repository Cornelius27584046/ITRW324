//code below is from source https://www.youtube.com/watch?v=wpSm2O2LIRM
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMobileMovement : MonoBehaviour
{
    Rigidbody2D rb;
    float ChardirX;
    float ChardirY;
    float movespeed = 2f;
    IsometricCharacterRenderer isoRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
        CharacterAttributes.PlayerHealth.setHealth(0, 100);
    }
    
    void Update()
    {
        ChardirX = Input.acceleration.x * movespeed;
        ChardirY = Input.acceleration.y * movespeed;
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -23f, 23f), Mathf.Clamp(transform.position.y, -12, 13));
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(ChardirX, ChardirY);

        Vector2 currentPos = rb.position;
        Vector2 inputVector = new Vector2(ChardirX, ChardirY);
        inputVector = Vector2.ClampMagnitude(inputVector, 1);
        Vector2 movement = inputVector * movespeed;
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        isoRenderer.SetDirection(movement);
        rb.MovePosition(newPos);
    }
}
