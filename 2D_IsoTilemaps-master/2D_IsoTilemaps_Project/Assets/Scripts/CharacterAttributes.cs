﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class is made to control characters health systems later on.
public class CharacterAttributes : MonoBehaviour
{
    public static int Score = 0;
    public static Health PlayerHealth = new Health();
    public static Armor PlayerArmor = new Armor();
    private void OnGUI()
    {
        GUI.Box(new Rect(100, 100, 100, 100),"(" + PlayerHealth.getHealth().ToString() + "/" + PlayerHealth.getMaxHealth().ToString() + ")");
    }
}

public class Health 
{
    private int currentHealth = 0;
    private int currentMax = 100;

    //methods to adjust the current health
    public int getHealth()
    {
        return currentHealth;
    }
    public void setHealth(int damage,int gained)
    {
        if (damage > 0)
        {
            currentHealth -= damage;
            if (currentHealth < 0)
            {
                currentHealth = 0;
            }
        }
        if (gained > 0)
        {
            currentHealth += gained;
            if (currentHealth > currentMax)
            {
                currentHealth = currentMax;
            }
        }
    }

    //methods to adjust the characters health stat
    public int getMaxHealth()
    {
        return currentMax;
    }
    public void setMaxHealth(bool validUpgrade)
    {
        if (validUpgrade == true)
        {
            currentMax = (currentMax + 20);
        }
    }
}
//this class is created to maintain the armor a character can wear and its stats
public class Armor
{
    private string[] ArmorType = { "Wood", "Stone", "Metal" }; //3 basic armor types
    private int[] ArmorValues = { 30, 50, 100 };//the 3 types stats
    private int ArmorCarried = 0;//the players armor stat he/she is wearing
    private bool ArmorOn = false;//the attribute to determine if the player is wearing armore or not.

    public int getArmorStat()
    {
        return ArmorCarried;
    }
    //method below helps maintain the armor stat that varies on the type of armor the player is wearing.
    public void setArmorStat(string type, int damage, int repaired)
    {
        if (ArmorOn == true)
        {
            if (type == ArmorType[0])
            {
                if (damage > 0)
                {
                    ArmorCarried -= damage;
                    if (ArmorCarried <= 0)
                    {
                        ArmorOn = false;
                    }
                }
                if (repaired > 0)
                {
                    ArmorCarried += repaired;
                    if (ArmorCarried > ArmorValues[0])
                    {
                        ArmorCarried = ArmorValues[0];
                    }
                }
            }
            else if (type == ArmorType[1])
            {
                if (damage > 0)
                {
                    ArmorCarried -= damage;
                    if (ArmorCarried <= 0)
                    {
                        ArmorOn = false;
                    }
                }
                if (repaired > 0)
                {
                    ArmorCarried += repaired;
                    if (ArmorCarried > ArmorValues[1])
                    {
                        ArmorCarried = ArmorValues[1];
                    }
                }
            }
            else if (type == ArmorType[2])
            {
                if (damage > 0)
                {
                    ArmorCarried -= damage;
                    if (ArmorCarried <= 0)
                    {
                        ArmorOn = false;
                    }
                }
                if (repaired > 0)
                {
                    ArmorCarried += repaired;
                    if (ArmorCarried > ArmorValues[2])
                    {
                        ArmorCarried = ArmorValues[2];
                    }
                }
            }
        }
        else if (ArmorOn == false)
        {
            //write so damage is assigned to health
        }               
    }
}
