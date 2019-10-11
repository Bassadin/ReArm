using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleCubeShot : BaseWeapon
{
    public float horizontalSpeed = 300;
    public float verticalSpeed = 75;
    public override void fireWeapon()
    {
        GameObject upperBullet;
        upperBullet = Instantiate(this.bulletToInstatiate, this.transform.parent);
        upperBullet.GetComponent<Rigidbody>().AddForce(new Vector3(horizontalSpeed, -verticalSpeed, 0));

        GameObject middleBullet;
        middleBullet = Instantiate(this.bulletToInstatiate, this.transform.parent);
        middleBullet.GetComponent<Rigidbody>().AddForce(new Vector3(horizontalSpeed, 0, 0));
        
        GameObject lowerBullet;
        lowerBullet = Instantiate(this.bulletToInstatiate, this.transform.parent);
        lowerBullet.GetComponent<Rigidbody>().AddForce(new Vector3(horizontalSpeed, verticalSpeed, 0));
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
