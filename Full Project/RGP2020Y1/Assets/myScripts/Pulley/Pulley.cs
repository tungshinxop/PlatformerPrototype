using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulley : MonoBehaviour
{
    public GameObject platform_01, platform_02;
    public float pulleySpeed, resetPulleySpeed;
 

    public float yUp, yDown;

    private Vector3 start_01, start_02;
    private Vector3 end_01_up, end_01_down, end_02_up, end_02_down;

    public bool isOnPlatform;

    private void Start()
    {
        //Store the start pos of the pulley platforms
        start_01 = platform_01.transform.position;
        start_02 = platform_02.transform.position;

        //Max height
        end_01_up = new Vector3(platform_01.transform.position.x, platform_01.transform.position.y + yUp, platform_01.transform.position.z);

        end_02_up = new Vector3(platform_02.transform.position.x, platform_02.transform.position.y + yUp, platform_02.transform.position.z);


        //Min height
        end_01_down = new Vector3(platform_01.transform.position.x, platform_01.transform.position.y + yDown, platform_01.transform.position.z);

        end_02_down = new Vector3(platform_02.transform.position.x, platform_02.transform.position.y + yDown, platform_02.transform.position.z);

    }

    private void Update()
    {
        if (!isOnPlatform)
        {
            PlatformReset_01();
            PlatformReset_02();
        }
    }

    public void Platform_01_Up()
    {
        platform_01.transform.position = Vector3.MoveTowards(platform_01.transform.position, end_01_up, pulleySpeed);
    }

    public void Platform_01_Down()
    {
        platform_01.transform.position = Vector3.MoveTowards(platform_01.transform.position, end_01_down, pulleySpeed);
    }

    public void Platform_02_Up()
    {
        platform_02.transform.position = Vector3.MoveTowards(platform_02.transform.position, end_02_up, pulleySpeed);
    }

    public void Platform_02_Down()
    {
        platform_02.transform.position = Vector3.MoveTowards(platform_02.transform.position, end_02_down, pulleySpeed);
    }

    public void PlatformReset_01()
    {
        platform_01.transform.position = Vector3.MoveTowards(platform_01.transform.position, start_01, resetPulleySpeed);
    }

    public void PlatformReset_02()
    {
        platform_02.transform.position = Vector3.MoveTowards(platform_02.transform.position, start_02, resetPulleySpeed);
    }
}
