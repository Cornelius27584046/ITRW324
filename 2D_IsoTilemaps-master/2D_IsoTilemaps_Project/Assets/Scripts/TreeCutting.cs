using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCutting : MonoBehaviour
{
    Inventory PlayerInventory = new Inventory();
    private void OnCollisionEnter2D(Collision2D collision)
    {
        for (int i = 1; i <= 3; i++)
        {
            if (collision.gameObject.name == "TreePalm" + i)
            {
                PlayerInventory.AddItem("Logs", 1);
            }
        }
    }
}

