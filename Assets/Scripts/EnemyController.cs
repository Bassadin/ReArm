using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : BaseDamageableCharacterController
{
    public float minSpeed = 50;
    public float maxSpeed = 80;

    private float speed;

    private Transform _transform;

    public float getSpeed()
    {
        return this.speed;
    }

    void Start()
    {
        Destroy(gameObject, 30);
    }

    public override void Awake()
    {
        base.Awake();
        speed = UnityEngine.Random.Range(minSpeed, maxSpeed);
        _transform = this.transform;
    }

    private void Update()
    {
        _transform.Translate(Vector2.down * speed * Time.deltaTime);

        //Drift to the side of the lane
        _transform.Translate(Vector2.right * _transform.position.x * 0.15f * Time.deltaTime);

        //Scale enemies bigger as they move downwards
        float addedScaleSize = -_transform.position.y * 0.045f;
        _transform.localScale = new Vector3(1 + addedScaleSize, 1 + addedScaleSize, 0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().dealOneDamage();
            Destroy(gameObject);
        }
    }

    public override void onDeath()
    {
        Destroy(this.gameObject);
        //Hardcoded score value for enemies for now
        //TODO Once the score somewhere else (maybe superclass)
        ScoreManager.Instance.addScore(50);
        PlayerController.Instance.equippedWeapon.chargeWeapon(20);
    }

    public override int getMaxLife()
    {
        return 4;
    }
}
