using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReticleMousePointer : MonoBehaviour
{
    public RectTransform MovingObject;
    public Vector3 offset;
    public RectTransform BasisObject;
    public Camera camera;

    // Update is called once per frame
    void Update()
    {
        MoveObject();
    }

    public void MoveObject()
    {
        Vector3 pos = Input.mousePosition + offset;
        pos.z = BasisObject.position.z;
        MovingObject.position = camera.ScreenToWorldPoint(pos);
    }
}
