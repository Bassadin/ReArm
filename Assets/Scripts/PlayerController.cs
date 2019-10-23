using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public BaseWeapon equippedWeapon;
    private Rigidbody rigidbody3d;
    private float weaponTimer = 0;

    void Start()
    {
        rigidbody3d = GetComponent<Rigidbody>();
    }

    void Update() {
        Debug.Log(equippedWeapon.shootingFrequency);
        weaponTimer += Time.deltaTime;
        if (weaponTimer >= equippedWeapon.shootingFrequency) {
            this.equippedWeapon.fireWeapon(this.gameObject.transform.position + new Vector3(0, 2, 0));
            weaponTimer = 0;
        }
    }

    void FixedUpdate() {
        Vector3 movement = new Vector3 (Input.GetAxis("Horizontal"), 0, 0);
        rigidbody3d.AddForce(movement * speed);
    }
}
