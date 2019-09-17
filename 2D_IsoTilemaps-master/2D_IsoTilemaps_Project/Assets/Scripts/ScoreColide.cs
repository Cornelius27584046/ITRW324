using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreColide : MonoBehaviour
{
    //method below assignes a score for the player on collisding with an orb.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        for (int i = 1; i <= 3; i++)
        {
            if (collision.gameObject.name == "orb" + i)
            {
                CharacterAttributes.PlayerHealth.setHealth(10, 0);
            }
        }
        if (collision.gameObject.name == "Shell1")
        {
            CharacterAttributes.PlayerHealth.setMaxHealth(true);
        }
    }
}
