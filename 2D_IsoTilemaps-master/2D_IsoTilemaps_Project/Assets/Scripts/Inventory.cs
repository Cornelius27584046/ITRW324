using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private int itemPlacer = -1;
    public string[] itemsNameSlot = new string[10];
    public int[] itemsAmountSlot = new int[10];
    private void OnGUI()
    {
        GUI.Box(new Rect(30, 100, 100, 100),"Backpack");
        //armor can either be destroyed on 0, meaning its left 0 and no repairs can be made, or code can be reverted to ensure the armor is always on, even on 0 and can be restored from that point.
    }
    public void AddItem(string item, int amount)
    {
        for (int i = 0; i < itemsNameSlot.Length; i++)
        {
            if (itemsNameSlot[i].ToString() == item)
            {
                itemsAmountSlot[i] += 1;
            }
        }
        for (int i = 0; i < itemsNameSlot.Length; i++)
        {
            if (item != itemsNameSlot[i].ToString())
            {

                itemsNameSlot[itemPlacer] = item + " " + amount.ToString();
                GUI.Box(new Rect(30, 100, 100, 100), "/n" + item + ": " + amount.ToString());
            }
        }
    }
    public int getNextItemSlot()
    {
        return itemPlacer;
    }
}
