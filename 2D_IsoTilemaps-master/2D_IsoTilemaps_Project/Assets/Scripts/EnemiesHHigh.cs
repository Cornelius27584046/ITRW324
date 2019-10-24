﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesHHigh : MonoBehaviour
{
    private int health = 150;
    private int armor = 70;
    private int rollOverDamage = 0;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Sword")
        {
            setArmor(CharacterAttributes.PlayerWeapon.getWDamage());
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
