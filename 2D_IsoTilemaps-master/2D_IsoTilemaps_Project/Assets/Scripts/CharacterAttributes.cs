using System.Collections;
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
        GUI.Box(new Rect(30, 20, 100, 70), "HP\n(" + PlayerHealth.getHealth().ToString() + "/" + PlayerHealth.getMaxHealth().ToString() + ")\nArmor\n(" + PlayerArmor.getArmorStat().ToString() + " / " + PlayerArmor.getArmorOn().ToString()+ ")");
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
    private string[] ArmorType = { "None","Wood", "Stone", "Metal" }; //3 basic armor types and an indicator of no armor worn
    private int[] ArmorValues = { 0, 30, 50, 100 };//the 3 types stats
    private int ArmorCarried = 0;//the players armor stat he/she is wearing
    private int ArmorMax = 0;
    public bool ArmorOn = false;//the attribute to determine if the player is wearing armore or not.

    //methods below are used to determine what type of armor the character is wearing.
    //this method gets the armor types maximum
    public int getArmorOn()
    {
        return ArmorMax;
    }
    //this method sets the armor type maximum
    public void setArmorOn(string equipedArmor)
    {
        for (int k = 0; k < 4; k++)
        {
            if (equipedArmor == ArmorType[k])
            {
                ArmorMax = ArmorValues[k];
            }
        }
    }

    //method below helps maintain the armor stat that varies on the type of armor the player is wearing.
    //this method gets the players armor stat
    public int getArmorStat()
    {
        return ArmorCarried;
    }
   //this methods sets the players armor stat.
    public void setArmorStat(string type, int damage, int repaired)
    {
        if (ArmorOn == true)
        {
            if (type == ArmorType[1])
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
            else if (type == ArmorType[3])
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
                    if (ArmorCarried > ArmorValues[3])
                    {
                        ArmorCarried = ArmorValues[3];
                    }
                }
            }
        }
        else if (ArmorOn == false)
        {
            ArmorCarried = -1;//this line needs to interact with the players health instead then.
        }               
    }
}
