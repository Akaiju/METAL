using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    [Range (0.5f, 1.5f)]
    private float fireRate = 1;

    [SerializeField]
    [Range(1, 10)]
    private int damage = 1;

    private float timer;

    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private ParticleSystem muzzleFlash;

    // checks to see if lmb is clicked to fire the weapon and play audiosource attached
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            if (Input.GetButton("Fire1"))
            {
                timer = 0f;
                FireGun();
                muzzleFlash.Play();
            }
        }
    }

    //casts a ray that will collide with objects and detract health if they have any
    private void FireGun()
    {
        Debug.DrawRay(firePoint.position, firePoint.forward * 100, Color.red, 2f);

        Ray ray = new Ray(firePoint.position, firePoint.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 100))
        {
            var health = hitInfo.collider.GetComponent<Health>();
            if (health != null)
                health.TakeDamage(damage);
        }
    }
}
