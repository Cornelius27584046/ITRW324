using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveProgress : MonoBehaviour
{
    
    private void Awake()
    {
        SaveObject saveobject = new SaveObject
        {
            hadArmor = CharacterAttributes.PlayerArmor.getArmorOn(),
            hadHealth = CharacterAttributes.PlayerHealth.getMaxHealth(),
        };
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Save();
        }
    }
    //method to save player data as is in world.
    private void Save()
    {
        GameObject player = new GameObject();
        player = GameObject.Find("PlayerWitch");
        Vector3 playerposition = player.transform.position;
        SaveObject saveobject = new SaveObject
        {
            hadArmor = CharacterAttributes.PlayerArmor.getArmorOn(),
            hadHealth = CharacterAttributes.PlayerHealth.getHealth(),
            playerPos = playerposition,
        };

        string datatosave = JsonUtility.ToJson(saveobject);

        File.WriteAllText(Application.dataPath + "save.txt", datatosave);
        Debug.Log("Saved!");
    }

    private void Load()
    {

    }

    private class SaveObject
        {
        public int hadHealth = -1;
        public int hadArmor = -1;
        public Vector3 playerPos;

        }
}
