using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDurability : MonoBehaviour
{
    public int Durability = 5;

    //figure out a way to chop trees

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "PlayerWitch")
        {
            if (Durability > 0)
            {
                --Durability;
            }
            else
            {
                IsDestroyed();
            }
        }
        Debug.Log(Durability);
    }
    private void IsDestroyed()
    {
        Destroy(this.gameObject);
    }
}
