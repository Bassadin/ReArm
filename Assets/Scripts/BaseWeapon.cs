using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    public GameObject bulletToInstatiate;

    public abstract void fireWeapon();
}
