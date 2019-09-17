using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreColide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "orb1" )
        {
            KeepScore.Score += 100;
        }
        else if (collision.gameObject.name == "orb2")
        {
            KeepScore.Score += 50;
        }
        else if (collision.gameObject.name == "orb3")
        {
            KeepScore.Score += 25;
        }
    }
}
