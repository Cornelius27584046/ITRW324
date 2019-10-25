//The games assets were created by another entity and the video supplying this information can be found
//here: https://www.youtube.com/watch?v=2DsKCJsEzSA&list=PLX2vGYjWbI0TPcPOKW6GxwuY18eg7CjKZ&index=1
// The link in the video will lead the user to a download page where he/she can download these assets
// the developer just has to follow this link: https://oc.unity3d.com/index.php/s/E4UPMiU8hBc4Yqk?utm_source=evangelism&utm_medium=social&utm_campaign=evangelism_global_generalpromo_43536-isometricdemo&utm_content=eva&aid=1011l3LoF&pubref=evangelism-social-isometricdemo 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HideTilemapColliderOnPlay : MonoBehaviour
{

    private TilemapRenderer tilemapRenderer;

    void Start()
    {
        tilemapRenderer = GetComponent<TilemapRenderer>();
        tilemapRenderer.enabled = false;
    }
}
