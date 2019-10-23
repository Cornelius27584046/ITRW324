using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveSystem
{
    private static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";

    public static void Init()
    {

        if (!Directory.Exists(SAVE_FOLDER))
        {
            Directory.CreateDirectory(SAVE_FOLDER);
        }
    }

    public static void Save(string saveString)
    {
        File.WriteAllText(SAVE_FOLDER + "/save.txt", saveString);
        Debug.Log("Saved To File!");
    }

    public static string Load()
    {
        if (File.Exists(SAVE_FOLDER + "/save.txt"))
        {
            string savestring = File.ReadAllText(SAVE_FOLDER + "/save.txt");
            Debug.Log("Loaded From File!");
            return savestring;
        }
        else
        {
            return null;
        }
    }
}
