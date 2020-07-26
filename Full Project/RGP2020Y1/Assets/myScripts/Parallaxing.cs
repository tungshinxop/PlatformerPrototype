using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour
{
    public float parrallaxingSpeed;
    Transform cam;
    Vector3 previousCamPos;

    private void Awake()
    {
        cam = Camera.main.transform;
    }

    void Start()
    {
        previousCamPos = cam.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Use minus so that we have an effect the terrain move backward
        float camMoveDist = previousCamPos.x - cam.position.x;

        //Modify the terrain move speed by the different background speeds
        float moveInX = camMoveDist * parrallaxingSpeed;

        //Target position 
        Vector3 newPos = new Vector3(moveInX, transform.position.y, transform.position.z);

        //Lerp the terrain to the new position
        transform.position = Vector3.Lerp(transform.position, newPos, 1);
    }
}
