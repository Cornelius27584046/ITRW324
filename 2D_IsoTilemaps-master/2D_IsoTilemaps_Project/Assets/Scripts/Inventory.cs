using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Backpack PlayerInventory = new Backpack();
    private void OnGUI()
    {//only three items willbe collectable, might solve problem
        GUI.Box(new Rect((Screen.width - 120),100 ,100, 70), "Backpack" + "\nLogs : " + PlayerInventory.getTypeAmm("Logs").ToString() + "\nStone : " + PlayerInventory.getTypeAmm("Stone").ToString() + "\nGrass : " + PlayerInventory.getTypeAmm("Grass").ToString());
    }
}

public class Backpack
{
    public string[] itemsNameSlot = { "Logs","Stone","Grass"};
    public int[] itemsAmountSlot = new int[3];

    public void AddItem(string type)
    {
        for (int i = 0; i < itemsNameSlot.Length; i++)
        {
            if (type == itemsNameSlot[i])
            {
                itemsAmountSlot[i] += 1;
            }
        }
    }
    public int getTypeAmm(string type)
    {
        int x = -1;
        for (int i = 0; i < itemsNameSlot.Length; i++)
        {
            if (type == itemsNameSlot[i])
            {
                x = itemsAmountSlot[i];
            }
        }
        return x;
    }
}
