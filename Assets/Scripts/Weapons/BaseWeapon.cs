using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    public GameObject bulletToInstatiate;
    public double shootingFrequency = 1.5f;

    public int upgradeLevel = 0;
    public int maxUpgradeLevel = 2;

    public abstract void fireWeapon(Vector2 spawnPosition);

    public void upgradeWeaponLevel() {
        upgradeLevel = Mathf.Clamp(upgradeLevel + 1, 0, maxUpgradeLevel);
        UpgradeTextManager.Instance.setUpgradeLevelToDisplay(this.upgradeLevel);
    }
}
