using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreColide : MonoBehaviour
{
    //Object[] trees = new Object[9];
    //method below assignes a score for the player on collisding with objects.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //spider damage collision
        if (collision.gameObject.name == "spider")
            {
                if (CharacterAttributes.PlayerArmor.ArmorOn == true)
                {
                    if (CharacterAttributes.PlayerArmor.getArmorStat() <= 15)
                    {
                        CharacterAttributes.PlayerHealth.setHealth((15 - CharacterAttributes.PlayerArmor.getArmorStat()), 0);
                        CharacterAttributes.PlayerArmor.setArmorStat(CharacterAttributes.PlayerArmor.ArmorType, CharacterAttributes.PlayerArmor.getArmorStat(), 0);
                    }
                    else
                    {
                        CharacterAttributes.PlayerArmor.setArmorStat(CharacterAttributes.PlayerArmor.ArmorType, 15, 0);
                    }
                }
                else
                {
                    CharacterAttributes.PlayerHealth.setHealth(15, 0);
                }
            }
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
            if (collision.gameObject.name == "Hart" + i)
            {
                CharacterAttributes.PlayerHealth.setHealth(0,15);
                Destroy(collision.gameObject);
            }
        }
        //Tree "cutting" collection
        for (int i = 1; i <= 9; i++)
        {
            if (collision.gameObject.name == "TreePalmC" + i)
            {
                //TreeDurability.Tree.StartTree(); //this is not working correct
                Inventory.PlayerInventory.AddItem("Logs");
            }
        }
        //Stone "mining" collection
        for (int i = 1; i <= 6; i++)
        {
            if (collision.gameObject.name == "stone" + i)
            {
                Inventory.PlayerInventory.AddItem("Stone");
            }
        }
        //log collection
        for (int i = 1; i <= 8; i++)
        {
            if (collision.gameObject.name == "log" + i)
            {
                Inventory.PlayerInventory.AddItem("Logs");
                Destroy(collision.gameObject);
            }
        }
        //grass collection
        for (int i = 1; i <= 30; i++)
        {
            if (collision.gameObject.name == "grass" + i)
            {
                Inventory.PlayerInventory.AddItem("Grass");
                Destroy(collision.gameObject);
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
