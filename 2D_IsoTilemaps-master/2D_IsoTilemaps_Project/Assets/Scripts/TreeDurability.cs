﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDurability : MonoBehaviour
{
    private int hitcount = 0;
    private int TreeDur = 5;
    private float TreeRegenTime = 20;
    public int TreeStage = 1; //made public for later stage of implementation where a tree can have different stages with different sprites.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        hitcount++;
        if (hitcount == 5)
        {
            Destroy(collision.gameObject);
            collision.gameObject.name = "TreePalm" + i;
            Destroy(collision.gameObject);
            hitcount = 0;
        }
        //hit on tree script
        for (int i = 1; i <= 3; i++)
        {
            if (collision.gameObject.name == "PlayerWitch")
            {
                TreeCut();
                if (TreeDur > 0)
                {
                    setTimer();
                    TreeRegenTime -= Time.deltaTime;
                    Regrowth();
                }
                else
                {
                    TreeRegenTime = TreeRegenTime * 3;
                    TreeRegenTime -= Time.deltaTime;
                    Regrowth();
                }
            }
        }

    }
    private void TreeCut()
    {
        TreeDur--;
    }
    //method to help show when the tree starts regrowing.
    private void Regrowth()
    {
        TreeDur = 5;
    }
    //get & set for regen time of a tree
    private void setTimer()
    {
        TreeRegenTime = 20;
    }
    private float getTimer()
    {
        return TreeRegenTime;
    }
}
