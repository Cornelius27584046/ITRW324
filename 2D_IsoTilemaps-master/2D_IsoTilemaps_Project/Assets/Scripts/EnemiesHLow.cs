using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesHLow : MonoBehaviour
{
    private int health = 50;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Sword")
        {
            setHealth(CharacterAttributes.PlayerWeapon.getWDamage());
        }
    }
    private void setHealth(int damage)
    {
        health -= damage;
        IsDead();
    }
    private void IsDead()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
