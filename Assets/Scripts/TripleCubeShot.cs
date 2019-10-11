using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleCubeShot : BaseWeapon
{
    public float horizontalSpeed = 350;
    public float verticalSpeed = 75;
    public override void fireWeapon(Transform spawnPosition)
    {
        GameObject upperBullet;
        upperBullet = Instantiate(this.bulletToInstatiate, spawnPosition);
        upperBullet.GetComponent<Rigidbody>().AddForce(new Vector3(horizontalSpeed, -verticalSpeed, 0));

        GameObject middleBullet;
        middleBullet = Instantiate(this.bulletToInstatiate, spawnPosition);
        middleBullet.GetComponent<Rigidbody>().AddForce(new Vector3(horizontalSpeed, 0, 0));
        
        GameObject lowerBullet;
        lowerBullet = Instantiate(this.bulletToInstatiate, spawnPosition);
        lowerBullet.GetComponent<Rigidbody>().AddForce(new Vector3(horizontalSpeed, verticalSpeed, 0));
    }
}
