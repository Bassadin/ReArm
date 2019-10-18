using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public BaseWeapon equippedWeapon;
    private Rigidbody rigidbody3d;

    void Start()
    {
        rigidbody3d = GetComponent<Rigidbody> ();
    }

    void FixedUpdate() {
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (0, moveVertical, 0);
        rigidbody3d.AddForce(movement * speed);

        if(Input.GetKeyDown(KeyCode.Space)) {
            this.equippedWeapon.fireWeapon(this.gameObject.transform.position + new Vector3(1, 0, 0));
        }
    }
}
