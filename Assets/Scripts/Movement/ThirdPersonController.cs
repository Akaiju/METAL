using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    [SerializeField]
    private float accelerationForce = 10;

    [SerializeField]
    private float maxSpeed = 2;

    [SerializeField]
    [Tooltip("How fast the player turns. 0 = no turning, 1 = instant turning")]
    [Range(0, 1)]
    private float turnSpeed = 0.1f;

    [SerializeField]
    private PhysicMaterial stoppingPhysicsMaterial, movingPhysicsMaterial;

    [SerializeField]
    private Plane plane;

    private new Rigidbody rigidbody;
    private Vector2 input;
    private new Collider collider;
    Vector3 worldPosition;
    

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();

    }
    private void FixedUpdate()
    {
        collider.material = input.magnitude > 0 ? movingPhysicsMaterial : stoppingPhysicsMaterial;

        if (rigidbody.velocity.magnitude < maxSpeed)
        {
            rigidbody.AddForce(transform.forward * input.y * accelerationForce, ForceMode.Acceleration);
            rigidbody.AddForce(transform.right * input.x * accelerationForce, ForceMode.Acceleration);
        }
    }

    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        //here's where the cursor should cast a ray that the player character turns to orient to
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (plane.Raycast(ray, out distance))
        {

            worldPosition = ray.GetPoint(distance);
            gameObject.transform.rotation = Quaternion.LookRotation(worldPosition - gameObject.transform.position);
        }
    }
}
