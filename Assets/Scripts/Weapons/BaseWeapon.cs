using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    public GameObject bulletToInstatiate;
    public double shootingFrequency = 1.5f;

    public abstract void fireWeapon(Vector3 spawnPosition);
}
