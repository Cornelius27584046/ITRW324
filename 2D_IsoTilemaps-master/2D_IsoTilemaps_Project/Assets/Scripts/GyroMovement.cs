using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroMovement : MonoBehaviour
{
    private bool isgyroenabled;
    private Gyroscope gyro;

    private GameObject camContainer;
    private Quaternion rot;

    // Start is called before the first frame update
    void Start()
    {
        camContainer = new GameObject("ContainerForCam");
        camContainer.transform.position = transform.position;
        transform.SetParent(camContainer.transform);

        isgyroenabled = EnableGyro();    
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;

            camContainer.transform.rotation = Quaternion.Euler(90f,90f,0f);
            rot = new Quaternion(0, 0, 0, 0);
            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isgyroenabled)
        {
            transform.localRotation = gyro.attitude * rot;
        }
    }
}
