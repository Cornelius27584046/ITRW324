using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreColide : MonoBehaviour
{
    //method below assignes a score for the player on collisding with an orb.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "orb1" )
        {
            CharacterAttributes.PlayerHealth.setHealth(10, 0);
        }
        else if (collision.gameObject.name == "orb2")
        {
            CharacterAttributes.PlayerHealth.setHealth(10, 0);
        }
        else if (collision.gameObject.name == "orb3")
        {
            CharacterAttributes.PlayerHealth.setHealth(10, 0);
        }
    }
}
