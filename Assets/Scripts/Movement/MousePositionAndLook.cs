using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class MousePositionAndLook : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void Update()
    {
        //Mouse Position in the world. It's important to give it some distance from the camera. 
        //If the screen point is calculated right from the exact position of the camera, then it will
        //just return the exact same position as the camera, which is no good.
        //Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);

        //Angle between mouse and this object
        //float angle = AngleBetweenPoints(transform.position, mouseWorldPosition);

        //Ta daa
        //transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        Vector3 mousePos = Input.mousePosition;
        Debug.Log($"mousePosition: {mousePos}");

        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.nearClipPlane));
        Debug.Log($"point: {worldPoint}");

        //mousePos.z = Camera.main.nearClipPlane;
        //worldPosition = Camera.main.ScreenToViewportPoint(mousePos);
    }

    float AngleBetweenPoints(Vector2 a, Vector2 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    
}
