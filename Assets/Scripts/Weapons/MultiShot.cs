using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShot : BaseWeapon
{
    public float maxHorizontalSpeed = 5;
    public float verticalSpeed = 250;

    private float arc = 0.25f * Mathf.PI;
    public override void fireWeapon(Vector2 spawnPosition)
    {
        GameObject middleBullet;
        middleBullet = Instantiate(this.bulletToInstatiate, spawnPosition, Quaternion.identity);
        middleBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, verticalSpeed));

        for (int i = 1; i <= upgradeLevel; i++)
        {

            GameObject newBulletL;
            newBulletL = Instantiate(this.bulletToInstatiate, spawnPosition, Quaternion.identity);
            newBulletL.GetComponent<Rigidbody2D>().AddForce(new Vector2(-i * (maxHorizontalSpeed / upgradeLevel), verticalSpeed));

            GameObject newBulletR;
            newBulletR = Instantiate(this.bulletToInstatiate, spawnPosition, Quaternion.identity);
            newBulletR.GetComponent<Rigidbody2D>().AddForce(new Vector2(i * (maxHorizontalSpeed / upgradeLevel), verticalSpeed));

        }
    }
}