using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject player;

    public float verticalOffset;
    public float horizontalOffset;

    private void LateUpdate()
    {
        Vector3 temp = transform.position;

        temp.x = player.transform.position.x;
        temp.y = player.transform.position.y;

        temp.y += verticalOffset; 

        transform.position = temp;
    }
}
