using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    public GameObject bulletToInstatiate;
    public float shootingFrequency = 1.5f;

    public Transform playerTransformReference;

    public int upgradeLevel = 0;
    public int maxUpgradeLevel = 2;

    private float weaponTimer = 0;

    public virtual void Update()
    {
        Debug.Log("Weapon update");
        weaponTimer += Time.deltaTime;
        if (weaponTimer >= shootingFrequency)
        {
            fireWeapon((Vector2)playerTransformReference.position + new Vector2(0, 2));
            weaponTimer = 0;
        }
    }

    public abstract void fireWeapon(Vector2 spawnPosition);

    public void upgradeWeaponLevel()
    {
        upgradeLevel = Mathf.Clamp(upgradeLevel + 1, 0, maxUpgradeLevel);
        UpgradeTextManager.Instance.setUpgradeLevelToDisplay(this.upgradeLevel);
    }
}
