using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float minSpeed = 50;
    public float maxSpeed = 80;

    private float speed;

    private Transform _transform;

    public float getSpeed() {
        return this.speed;
    }

    void Start() {
        Destroy(gameObject, 30);
    }

    // Start is called before the first frame update
    void Awake()
    {
        speed = UnityEngine.Random.Range(minSpeed, maxSpeed);
        _transform = this.transform;
    }

    private void Update() {
        _transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
