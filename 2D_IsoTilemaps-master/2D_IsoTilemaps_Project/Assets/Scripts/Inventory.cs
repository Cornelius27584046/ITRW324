using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private void OnGUI()
    {
        GUI.Box(new Rect(30, 100, 100, 100),"Backpack");
        //armor can either be destroyed on 0, meaning its left 0 and no repairs can be made, or code can be reverted to ensure the armor is always on, even on 0 and can be restored from that point.
    }
}
