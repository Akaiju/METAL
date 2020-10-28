using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePositionAndLook : MonoBehaviour
{
    Vector3 worldPosition;

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        worldPosition = Camera.main.ScreenToViewportPoint(mousePos);
    }
}
