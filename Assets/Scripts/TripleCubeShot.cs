using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleCubeShot : BaseWeapon
{
    public override void fireWeapon()
    {
        GameObject newBullet;
        newBullet = Instantiate(this.bulletToInstatiate, this.transform.parent);
        newBullet.GetComponent<Rigidbody>().AddForce(new Vector3(250, 0, 0));
        // newBullet
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
