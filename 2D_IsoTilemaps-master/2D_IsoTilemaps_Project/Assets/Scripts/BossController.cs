using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private Animator myAnim;
    private Transform target;

    public float speed;
    public float minRange;
    public float maxRange;
    public Transform homePos;

    void Start()
    {
        myAnim = GetComponent<Animator>();
        target = FindObjectOfType<IsometricCharacterRenderer>().transform;
    }
    
    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
        {
            FollowPlayer();
        }

        else if (Vector3.Distance(target.position, transform.position) >= maxRange)
        {
            GoHome();
            myAnim.SetBool("isClose", false);
        }

        if (Vector3.Distance(target.position, transform.position) <= (maxRange - 3) && Vector3.Distance(target.position, transform.position) >= minRange)
        {
            AttackPlayer();
        }

        if (Vector3.Distance(target.position, transform.position) >= (maxRange - 3) && Vector3.Distance(target.position, transform.position) >= minRange)
        {
            myAnim.SetBool("isClose", false);
        }
    }

    public void FollowPlayer()
    {
        myAnim.SetBool("isMoving", true);
        myAnim.SetFloat("moveX", (target.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void AttackPlayer()
    {
        myAnim.SetBool("isClose", true);
    }

    public void GoHome()
    {
        transform.position = Vector3.MoveTowards(transform.position, homePos.position, speed * Time.deltaTime);
    }
}
