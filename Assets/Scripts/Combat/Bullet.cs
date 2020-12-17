using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField]
    [Range(1, 10)]
    private int damage = 5;

    // Update is called once per frame
    //void OnCollision()
    //{
    //    if (OnCollision)
    //    {
    //        var health = hitInfo.collider.GetComponent<Health>();

    //        if (health != null)
    //            health.TakeDamage(damage);
    //    }
    //}
}
