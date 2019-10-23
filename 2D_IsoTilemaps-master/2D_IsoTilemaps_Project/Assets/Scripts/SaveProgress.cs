using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveProgress //: MonoBehaviour
{
    [SerializeField]private static GameObject player = new GameObject();

    private static void Awake()
    {
        SaveSystem.Init();
        player = GameObject.Find("PlayerWitch");
    }

    //update method to call save method once key pressed
    private static void Update()
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
    private static void Save()
    {
        Vector3 playerposition = player.transform.position;
        SaveObject saveobject = new SaveObject
        {
            hadArmor = CharacterAttributes.PlayerArmor.getArmorStat(),
            hadMaxA = CharacterAttributes.PlayerArmor.getArmorOn(),
            hadArmorType = CharacterAttributes.PlayerArmor.ArmorType,
            hadMaxH = CharacterAttributes.PlayerHealth.getMaxHealth(),
            hadHealth = CharacterAttributes.PlayerHealth.getHealth(),
            playerPos = playerposition,
        };

        string datatosave = JsonUtility.ToJson(saveobject);
        SaveSystem.Save(datatosave);
    }

    //method to load the players data from a previous session
    private static void Load()
    {
        string saveString = SaveSystem.Load();
        if (saveString != null)
        {
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);

            //below line sets the players position & Does not do a thing
            player.gameObject.transform.position.Set(saveObject.playerPos.x, saveObject.playerPos.y, saveObject.playerPos.z);
            //below sets the attributes & works!!!
            CharacterAttributes.PlayerArmor.getArmorOn();
            CharacterAttributes.PlayerHealth.setHealth(0, saveObject.hadHealth);
            CharacterAttributes.PlayerArmor.setArmorStat(saveObject.hadArmorType, 0, saveObject.hadArmor);

            Debug.Log("Loaded In Game!");
        }
        else
        {
            Debug.Log("Did not load!!!!!!!!!");
        }
    }

    //class to set which attributes must be saved.
    private class SaveObject
        {
        public int hadMaxH = -1;
        public int hadMaxA = -1;
        public int hadHealth = -1;
        public int hadArmor = -1;
        public string hadArmorType = "doal..."; //its load spelled backwards... there to know load failed.
        public Vector3 playerPos;
        }
}
