using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveProgress : MonoBehaviour
{
    public GameObject player = new GameObject();

    private void Start()
    {
        player = GameObject.Find("PlayerWitch");
        SaveObject saveobject = new SaveObject
        {
            hadArmor = CharacterAttributes.PlayerArmor.getArmorOn(),
            hadHealth = CharacterAttributes.PlayerHealth.getMaxHealth(),
            hadArmorType = CharacterAttributes.PlayerArmor.ArmorType,
        };
    }

    //update method to call save method once key pressed
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
    }

    //method to save player data as is in world.
    private void Save()
    {
        Vector3 playerposition = player.transform.position;
        SaveObject saveobject = new SaveObject
        {
            hadArmor = CharacterAttributes.PlayerArmor.getArmorOn(),
            hadArmorType = CharacterAttributes.PlayerArmor.ArmorType,
            hadHealth = CharacterAttributes.PlayerHealth.getHealth(),
            playerPos = playerposition,
        };

        string datatosave = JsonUtility.ToJson(saveobject);

        File.WriteAllText(Application.dataPath + "/save.txt", datatosave);
        Debug.Log("Saved!");
    }

    //method to load the players data from a previous session
    private void Load()
    {
        if (File.Exists(Application.dataPath + "/save.txt"))
        {
            string savestring = File.ReadAllText(Application.dataPath + "/save.txt");

            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(savestring);

            //below line sets the players position & Does not do a thing
            player.gameObject.transform.position.Set(saveObject.playerPos.x, saveObject.playerPos.y, saveObject.playerPos.z);
            //below sets the attributes & works!!!
            CharacterAttributes.PlayerHealth.setHealth(0, saveObject.hadHealth);
            CharacterAttributes.PlayerArmor.setArmorStat(saveObject.hadArmorType, 0, saveObject.hadArmor);
            Debug.Log("Loaded!");
        }
        else
        {
            Debug.Log("Did not load!!!!!!!!!");
        }
    }

    //class to set which attributes must be saved.
    private class SaveObject
        {
        public int hadHealth = -1;
        public int hadArmor = -1;
        public string hadArmorType = "doal..."; //its load spelled backwards... there to know load failed.
        public Vector3 playerPos;
        }
}
