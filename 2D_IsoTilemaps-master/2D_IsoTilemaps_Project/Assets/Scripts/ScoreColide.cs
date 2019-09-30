using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreColide : MonoBehaviour
{
    //method below assignes a score for the player on collisding with an orb.
    private void OnCollisionEnter2D(Collision2D collision)
    {
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
        for (int i = 1; i <= 4; i++)
        {
            if (collision.gameObject.name == "Shell" + i)
            {
                CharacterAttributes.PlayerHealth.setMaxHealth(true);
                Destroy(collision.gameObject);
            }
        }
        for (int i = 1; i <= 4; i++)
        {
            if (collision.gameObject.name == "Star" + i)
            {
                CharacterAttributes.PlayerHealth.setHealth(0,15);
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.name == "MetalArmor")
        {
            CharacterAttributes.PlayerArmor.setArmorOn("Metal");
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "ArmorRepair1")
        {
            if (CharacterAttributes.PlayerArmor.ArmorOn == true)
            {
                CharacterAttributes.PlayerArmor.setArmorStat(CharacterAttributes.PlayerArmor.ArmorType, 0, (int)(CharacterAttributes.PlayerArmor.getArmorOn() * 0.20));
            }
        }
        if (collision.gameObject.name == "ArmorRepair2")
        {
            if (CharacterAttributes.PlayerArmor.ArmorOn == true)
            {
                CharacterAttributes.PlayerArmor.setArmorStat(CharacterAttributes.PlayerArmor.ArmorType, 0, (int)(CharacterAttributes.PlayerArmor.getArmorOn() * 0.50));
            }
        }
    }
}
