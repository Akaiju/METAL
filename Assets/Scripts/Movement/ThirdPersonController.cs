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
    private readonly int movementInputAnimParam = Animator.StringToHash("movementInput");
    private Animator animator;
    Vector3 worldPosition;
    
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        animator = GetComponentInChildren<Animator>();

    }
    private void FixedUpdate()
    {
        collider.material = input.magnitude > 0 ? movingPhysicsMaterial : stoppingPhysicsMaterial;

        if (rigidbody.velocity.magnitude < maxSpeed)
        {
            rigidbody.AddForce(transform.forward * input.y * accelerationForce, ForceMode.Acceleration);
            rigidbody.AddForce(transform.right * input.x * accelerationForce, ForceMode.Acceleration);
            animator.SetFloat(movementInputAnimParam, input.magnitude);
        }
    }

    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }
}
