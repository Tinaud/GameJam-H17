using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletKill : MonoBehaviour
{

    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(gameObject.tag) || !other.CompareTag("Wall"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
