using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Backpack PlayerInventory = new Backpack();
    private void OnGUI()
    {
        GUI.Box(new Rect((Screen.width - 120),100 ,100, 130), "Backpack\n" + "Logs\n" + PlayerInventory.getItemCount().ToString());
    }
}

public class Backpack
{
    public int itemPlacer = -1;
    private int logcollect = 2000;
    public string[] itemsNameSlot = new string[10];
    public int[] itemsAmountSlot = new int[10];

    public void AddItem(string item, int amount)
    {

        logcollect++;
        itemPlacer += 1;
        for (int i = 0; i < itemsNameSlot.Length; i++)
        {
            if (itemsNameSlot[i].ToString() == item)
            {
                itemsAmountSlot[i] += 1;
            }
            else
            {
                if (itemPlacer < itemsNameSlot.Length)
                {
                    itemsNameSlot[itemPlacer] = item + " " + amount.ToString();
                    GUI.Box(new Rect((Screen.width - 120), 140, 100, 30), "/n" + item + ": " + amount.ToString());
                }
                else
                {
                    //do nothing, dont pick up item
                }
            }
        }
    }
    public int getItemCount()
    {
        return logcollect;
    }
    public int getNextItemSlot()
    {
        return itemPlacer;
    }
}
