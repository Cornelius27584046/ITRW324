using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreColide : MonoBehaviour
{
    //method below assignes a score for the player on collisding with objects.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //orb damage reduction beneath
        for (int i = 1; i <= 3; i++)
        {
            if (collision.gameObject.name == "orb" + i)
            {
                if (CharacterAttributes.PlayerArmor.ArmorOn == true)
                {
                    if (CharacterAttributes.PlayerArmor.getArmorStat() <= 10)
                    {
                        CharacterAttributes.PlayerHealth.setHealth((10 - CharacterAttributes.PlayerArmor.getArmorStat()), 0);
                        CharacterAttributes.PlayerArmor.setArmorStat(CharacterAttributes.PlayerArmor.ArmorType, CharacterAttributes.PlayerArmor.getArmorStat(), 0);
                    }
                    else
                    {
                        CharacterAttributes.PlayerArmor.setArmorStat(CharacterAttributes.PlayerArmor.ArmorType, 10, 0);
                    }
                }
                else
                {
                    CharacterAttributes.PlayerHealth.setHealth(10, 0);
                }
            }
        }
        //shell collection and ahealth modification beneath
        for (int i = 1; i <= 4; i++)
        {
            if (collision.gameObject.name == "Shell" + i)
            {
                CharacterAttributes.PlayerHealth.setMaxHealth(true);
                Destroy(collision.gameObject);
            }
        }
        //star on health regain beneath 
        for (int i = 1; i <= 4; i++)
        {
            if (collision.gameObject.name == "Star" + i)
            {
                CharacterAttributes.PlayerHealth.setHealth(0,15);
                Destroy(collision.gameObject);
            }
        }
        //log collection beneath & treecutting
        for (int i = 1; i <= 3; i++)
        {
            if (collision.gameObject.name == "TreePalmC" + i)
            {
                Inventory.PlayerInventory.AddItem("Logs");
                //================================tree cutting section===================================
            }
        }
        //armor collection beneath
        if (collision.gameObject.name == "MetalArmor")
        {
            CharacterAttributes.PlayerArmor.setArmorOn("Metal");
            Destroy(collision.gameObject);
        }
        //armor repair pieces beneath stage 1
        if (collision.gameObject.name == "ArmorRepair1")
        {
            if (CharacterAttributes.PlayerArmor.ArmorOn == true)
            {
                CharacterAttributes.PlayerArmor.setArmorStat(CharacterAttributes.PlayerArmor.ArmorType, 0, (int)(CharacterAttributes.PlayerArmor.getArmorOn() * 0.20));
            }
        }
        //armor repair pieces beneath stage 2
        if (collision.gameObject.name == "ArmorRepair2")
        {
            if (CharacterAttributes.PlayerArmor.ArmorOn == true)
            {
                CharacterAttributes.PlayerArmor.setArmorStat(CharacterAttributes.PlayerArmor.ArmorType, 0, (int)(CharacterAttributes.PlayerArmor.getArmorOn() * 0.50));
            }
        }
        
}
}
