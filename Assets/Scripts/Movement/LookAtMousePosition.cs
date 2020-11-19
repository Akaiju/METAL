using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMousePosition : MonoBehaviour
{
    [SerializeField]
    [TooltipAttribute("speed is the rate at which the object will rotate")]
    private float rotateSpeed;

    public Vector3 targetPoint;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    void FixedUpdate()
    {
        Vector3 mousePos = Input.mousePosition;
        Debug.Log($"mousePosition: {mousePos}");

        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.nearClipPlane));
        Debug.Log($"point: {worldPoint}");

        // Generate a plane that intersects the transform's position with an upwards normal. 
        // This is plane the player is standing on.
        Plane playerPlane = new Plane(Vector3.up, transform.position);

        // Generate a ray from the cursor position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Determine the point where the cursor ray intersects the plane.
        // This will be the point that the object must look towards to be looking at the mouse.
        // Raycasting to a Plane object only gives us a distance, so we'll have to take the distance,
        //   then find the point along that ray that meets that distance.  This will be the point
        //   to look at.
        float hitDistance = 0.0f;
        // If the ray is parallel to the plane, Raycast will return false.
        if (playerPlane.Raycast(ray, out hitDistance))
        {
            // Get the point along the ray that hits the calculated distance.
            targetPoint = ray.GetPoint(hitDistance);

            // Determine the target rotation.  This is the rotation if the transform looks at the target point.
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

            // Smoothly rotate towards the target point.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }
    }
    //Unused but leaving here as future reference
    //float AngleBetweenPoints(Vector2 a, Vector2 b)
    //{
    //    return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    //}
}
