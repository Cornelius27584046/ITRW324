using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    //array of weapon types
    private string[] WeaponArr = { "Fists", "Rock", "Stick", "Axe", "Hammer", "Sword", "Battle-Axe", "WarHammer", "Spear" };
    //array of weapon handle
    private string[] WeaponTypeArr = { "Melee", "Throwable", "Twohanded" };
    //array of weapon damage
    private int[] WeaponDamageArr = { 10, 20, 30 };
    
    //variables to be used in calls
    //private string Weapon = "NONE";
    private string wType = "NONE";
    private int wDamage = -1;

    //method to receive variable inputs
    public void getWeaponStat()
    {
        string Weapon = WeaponArr[0];
        string wType = WeaponTypeArr[0];
        int wDamage = WeaponDamageArr[0];
    }

    //method to set the attributes of the weapons
    public void setWeaponStat(string Weapontype)
    {
        string w = Weapontype;
        if (w == WeaponArr[0])
        {
            wType = WeaponTypeArr[0];
            wDamage = WeaponDamageArr[0];
        }
        else if (w == WeaponArr[1])
        {
            wType = WeaponTypeArr[1];
            wDamage = WeaponDamageArr[0];
        }
        else if (w == WeaponArr[2])
        {
            wType = WeaponTypeArr[0];
            wDamage = WeaponDamageArr[0];
        }
        else if (w == WeaponArr[3])
        {
            wType = WeaponTypeArr[1];
            wDamage = WeaponDamageArr[1];
        }
        else if (w == WeaponArr[4])
        {
            wType = WeaponTypeArr[0];
            wDamage = WeaponDamageArr[1];
        }
        else if (w == WeaponArr[5])
        {
            wType = WeaponTypeArr[0];
            wDamage = WeaponDamageArr[1];
        }
        else if (w == WeaponArr[6])
        {
            wType = WeaponTypeArr[2];
            wDamage = WeaponDamageArr[2];
        }
        else if (w == WeaponArr[7])
        {
            wType = WeaponTypeArr[2];
            wDamage = WeaponDamageArr[2];
        }
        else if (w == WeaponArr[8])
        {
            wType = WeaponTypeArr[1];
            wDamage = WeaponDamageArr[2];
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
