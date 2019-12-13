using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShot : BaseWeapon
{
    public float verticalSpeed = 250;
    public override void fireWeapon(Vector2 spawnPosition) {
        GameObject middleBullet;
        middleBullet = Instantiate(this.bulletToInstatiate, spawnPosition, Quaternion.identity);
        middleBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, verticalSpeed));
    }
}
