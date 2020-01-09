using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBullet : MonoBehaviour
{
    public int damageAmount = 1;
    private Transform _transform;

    private Vector3 baseScale;

    void Start()
    {
        //Delete every bullet after 20 seconds by default
        Destroy(gameObject, 20);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyController>().changeLife(-damageAmount);
            //Destroy self
            Destroy(gameObject);
        }
    }

    void Awake()
    {
        _transform = this.transform;
        baseScale = _transform.localScale;
    }

    void Update()
    {
        //Scale enemies bigger as they move downwards
        float addedScaleSize = _transform.position.y * -0.01f;
        _transform.localScale = new Vector3(baseScale.x + addedScaleSize, baseScale.y + addedScaleSize, 0);
    }
}
