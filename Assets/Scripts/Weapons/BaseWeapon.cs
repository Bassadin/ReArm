using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    public GameObject bulletToInstatiate;
    public float shootingFrequency = 1.5f;

    public Transform playerTransformReference;

    public float currentChargeLevel = 0;
    public float maxChargeLevel = 100;

    protected bool isWeaponOvercharged = false;
    private float overchargeDepletionRate = 25;

    private float weaponFiringTimer = 0;

    public virtual void Update()
    {
        // if (Input.GetKeyUp(KeyCode.U))
        // {
        //     chargeWeapon(25);
        // }
        weaponFiringTimer += Time.deltaTime;
        if (weaponFiringTimer >= shootingFrequency)
        {
            fireWeapon((Vector2)playerTransformReference.position + new Vector2(0, 2));
            weaponFiringTimer = 0;
        }

        if (currentChargeLevel >= maxChargeLevel) {
            isWeaponOvercharged = true;
        }
        if (isWeaponOvercharged) {
            currentChargeLevel -= overchargeDepletionRate * Time.deltaTime;
            if (currentChargeLevel <= 0) {
                isWeaponOvercharged = false;
                currentChargeLevel = 0;
            }
            updateWeaponLevelInUI();
        }
    }

    public abstract void fireWeapon(Vector2 spawnPosition);

    public void chargeWeapon(float upgradeAmount)
    {
        currentChargeLevel = Mathf.Clamp(currentChargeLevel + upgradeAmount, 0, maxChargeLevel);
        updateWeaponLevelInUI();
    }

    public void updateWeaponLevelInUI()
    {
        UpgradeDisplayManager.Instance.setUpgradeLevelToDisplay(this.currentChargeLevel, this.maxChargeLevel);
    }

}
