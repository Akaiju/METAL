using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    [Range(1, 10)]
    private int damage = 5;

    // Update is called once per frame
    void OnCollisionEnter(Collision gameObjectInformation)
    {
        if (gameObjectInformation.gameObject.tag == "Enemy")
        {
            var health = gameObjectInformation.gameObject.GetComponent<Health>();

            if (health != null)
                health.TakeDamage(damage);
            Debug.Log("Collision detected, damage dealt");
        }

        Debug.Log("Collision detected, no damage dealt");
    }
}
