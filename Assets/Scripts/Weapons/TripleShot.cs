using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShot : BaseWeapon
{
    public float horizontalSpeed = 5;
    public float verticalSpeed = 250;
    public override void fireWeapon(Vector2 spawnPosition) {
        GameObject upperBullet;
        upperBullet = Instantiate(this.bulletToInstatiate, spawnPosition, Quaternion.identity);
        upperBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(-horizontalSpeed, verticalSpeed));

        GameObject middleBullet;
        middleBullet = Instantiate(this.bulletToInstatiate, spawnPosition, Quaternion.identity);
        middleBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, verticalSpeed));
        
        GameObject lowerBullet;
        lowerBullet = Instantiate(this.bulletToInstatiate, spawnPosition, Quaternion.identity);
        lowerBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(horizontalSpeed, verticalSpeed));
    }
}