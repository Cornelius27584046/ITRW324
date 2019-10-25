//The games assets were created by another entity and the video supplying this information can be found
//here: https://www.youtube.com/watch?v=2DsKCJsEzSA&list=PLX2vGYjWbI0TPcPOKW6GxwuY18eg7CjKZ&index=1
// The link in the video will lead the user to a download page where he/she can download these assets
// the developer just has to follow this link: https://oc.unity3d.com/index.php/s/E4UPMiU8hBc4Yqk?utm_source=evangelism&utm_medium=social&utm_campaign=evangelism_global_generalpromo_43536-isometricdemo&utm_content=eva&aid=1011l3LoF&pubref=evangelism-social-isometricdemo 
using UnityEngine;
using System.Collections;

public class BasicCameraFollow : MonoBehaviour 
{

	private Vector3 startingPosition;
	public Transform followTarget;
	private Vector3 targetPos;
	public float moveSpeed;
	
	void Start()
	{
		startingPosition = transform.position;
	}

	void Update () 
	{
		if(followTarget != null)
		{
			targetPos = new Vector3(followTarget.position.x, followTarget.position.y, transform.position.z);
			Vector3 velocity = (targetPos - transform.position) * moveSpeed;
			transform.position = Vector3.SmoothDamp (transform.position, targetPos, ref velocity, 1.0f, Time.deltaTime);
		}

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        // Disable screen dim on mobile platforms
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
}

