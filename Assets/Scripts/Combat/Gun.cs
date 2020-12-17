using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    [Range (0.5f, 1.5f)]
    private float fireRate = 1;

    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private LookAtMousePosition lookAtMousePosition;

    [SerializeField]
    private AudioSource gunfireSource;

    [SerializeField]
    public GameObject Bullet_Emitter;

    [SerializeField]
    public GameObject Bullet;

    [SerializeField]
    public float Bullet_Forward_Force;

    private float timer;

    // checks to see if lmb is clicked to fire the weapon and play audiosource attached
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            if (Input.GetButton("Fire1"))
            {
                GameObject Temporary_Bullet_Handler;
                Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;

                Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);

                Rigidbody Temporary_RigidBody;
                Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

                Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);
                
                Destroy(Temporary_Bullet_Handler, 1.0f);

                timer = 0f;
                FireGun();
            }
        }
    }

    //casts a ray that will collide with objects and detract health if they have any
    private void FireGun()
    {
        gunfireSource.Play();
    }
}
