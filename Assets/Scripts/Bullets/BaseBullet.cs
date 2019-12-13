using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBullet : MonoBehaviour
{
    void Start()
    {
        //Delete every bullet after 20 seconds by default
        Destroy(gameObject, 20);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Enemy")) {
            Debug.Log("bullet collision detected!");
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
