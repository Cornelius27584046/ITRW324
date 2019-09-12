using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbCharacter : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D myRigidbody;

    public bool isMoving;
    public float moveTime;
    private float moveCounter;
    public float waitTime;
    private float waitCounter;

    private int MoveDirection;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        waitCounter = waitTime;
        moveCounter = moveTime;

        ChooseDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
        {
            moveCounter -= Time.deltaTime;

            switch(MoveDirection)
            {
            case 0:
                myRigidbody.velocity = new Vector2(1, moveSpeed);
                break;
            case 1:
                myRigidbody.velocity = new Vector2(moveSpeed, 1);
                break;
            case 2:
                myRigidbody.velocity = new Vector2(1, -moveSpeed);
                break;
            case 3:
                myRigidbody.velocity = new Vector2(-moveSpeed, 1);
                break;
            }

            if(moveCounter < 0)
            {
                isMoving = false;
                waitCounter = waitTime;
            }
        }
        else
        {
            waitCounter -= Time.deltaTime;

            myRigidbody.velocity = Vector2.zero;

            if(waitCounter < 0)
            {
                ChooseDirection();
            }
        }
    }

    public void ChooseDirection()
    {
        MoveDirection = Random.Range(0, 4);
        isMoving = true;
        moveCounter = moveTime;
    }
}
