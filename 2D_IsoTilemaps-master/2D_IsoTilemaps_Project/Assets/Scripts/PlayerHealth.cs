using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerMaxHealth;
    public int playerCurrentHealth;

    public float waitToReload;
    public bool reloading;
    private GameObject thePlayer;

    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
    }

    void Update()
    {
        if(playerCurrentHealth <= 0)
        {
            gameObject.SetActive(false);
            reloading = true;
            //thePlayer = other.gameObject;
        }

    /*if(reloading)
        {
            waitToReload -= Time.deltaTime;
            if(waitToReload < 0)
            {
                Application.LoadLevel(Application.loadedLevel);
                //thePlayer.SetActive(true);
            }
        }*/
    }

    public void HurtPlayer(int damageDealt)
    {
        playerCurrentHealth -= damageDealt;
    }

    public void SetMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;
    }
}
