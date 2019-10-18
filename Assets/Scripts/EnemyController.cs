using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float minSpeed = 50;
    public float maxSpeed = 80;

    private float speed;

    public float getSpeed() {
        return this.speed;
    }

    // Start is called before the first frame update
    void Awake()
    {
        speed = UnityEngine.Random.Range(minSpeed, maxSpeed);
    }
}
