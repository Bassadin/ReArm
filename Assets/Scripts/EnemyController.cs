using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float minSpeed = 10;
    public float maxSpeed = 15;

    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = UnityEngine.Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
