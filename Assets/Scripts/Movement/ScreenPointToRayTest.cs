using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenPointToRayTest : MonoBehaviour
{
    //Attach this script to your Camera
    //This draws a line in the Scene view going through a point 200 pixels from the lower-left corner of the screen
    //To see this, enter Play Mode and switch to the Scene tab. Zoom into your Camera's position.

    Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Ray ray = cam.ScreenPointToRay(pos);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
    }
}
