using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesHLow : MonoBehaviour
{
    private int health = 30;
    private int armor = 0;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Sword")
        {
            setHealth(10);
            Debug.Log(health);
        }
    }
    private void setHealth(int damage)
    {
        health -= damage;
    }
}
