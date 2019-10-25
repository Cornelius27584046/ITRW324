//The games assets were created by another entity and the video supplying this information can be found
//here: https://www.youtube.com/watch?v=2DsKCJsEzSA&list=PLX2vGYjWbI0TPcPOKW6GxwuY18eg7CjKZ&index=1
// The link in the video will lead the user to a download page where he/she can download these assets
// the developer just has to follow this link: https://oc.unity3d.com/index.php/s/E4UPMiU8hBc4Yqk?utm_source=evangelism&utm_medium=social&utm_campaign=evangelism_global_generalpromo_43536-isometricdemo&utm_content=eva&aid=1011l3LoF&pubref=evangelism-social-isometricdemo 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricPlayerMovementController : MonoBehaviour
{

    public float movementSpeed = 1f;
    IsometricCharacterRenderer isoRenderer;
    Rigidbody2D rbody;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
        CharacterAttributes.PlayerHealth.setHealth(0, 100);

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 currentPos = rbody.position;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        inputVector = Vector2.ClampMagnitude(inputVector, 1);
        Vector2 movement = inputVector * movementSpeed;
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        isoRenderer.SetDirection(movement);
        rbody.MovePosition(newPos);
    }
}
