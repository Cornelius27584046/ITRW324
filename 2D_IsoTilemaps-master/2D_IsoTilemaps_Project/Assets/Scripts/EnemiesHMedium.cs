using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesHMedium : MonoBehaviour
{
    private int health = 70;
    private int armor = 15;
    private int rollOverDamage = 0;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Sword")
        {
            setArmor(10);
        }
    }
    private void setHealth(int damage)
    {
        health -= damage;
        IsDead();
    }
    private void setArmor(int damage)
    {
        if (damage < armor)
        {
            armor -= damage;
        }
        else
        {
            damage -= armor;
            armor = 0;
            rollOverDamage = damage;
            setHealth(rollOverDamage);

        }
    }
    private void IsDead()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
