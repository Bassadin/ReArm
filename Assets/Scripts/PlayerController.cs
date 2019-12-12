using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public BaseWeapon equippedWeapon;
    private Rigidbody2D rigidbody2d;
    private float weaponTimer = 0;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Debug.Log(equippedWeapon.shootingFrequency);
        weaponTimer += Time.deltaTime;
        if (weaponTimer >= equippedWeapon.shootingFrequency)
        {
            this.equippedWeapon.fireWeapon((Vector2)this.gameObject.transform.position + new Vector2(0, 2));
            weaponTimer = 0;
        }
    }

    void FixedUpdate()
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), 0);
        rigidbody2d.AddForce(movement * speed);
    }
}
