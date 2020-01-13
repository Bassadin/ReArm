using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeDisplayManager : MonoBehaviour
{
    private static UpgradeDisplayManager _instance;

    public static UpgradeDisplayManager Instance { get { return _instance; } }

    public Mask staffMask;
    public Image staffBackgroundImage;

    private double maxHeight;

    private void Awake()
    {
        maxHeight = staffBackgroundImage.rectTransform.sizeDelta.y;

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void setUpgradeLevelToDisplay(float setChargeLevel, float maxChargeLevel)
    {
        Debug.Log(setChargeLevel + "/" + maxChargeLevel);
        staffMask.rectTransform.SetSizeWithCurrentAnchors(
            RectTransform.Axis.Vertical,
            (float)maxHeight * (Mathf.Clamp(setChargeLevel, 0, maxChargeLevel) / maxChargeLevel));
        Debug.Log("Set upgrade bar height to: " + (float)maxHeight * (Mathf.Clamp(setChargeLevel, 0, maxChargeLevel) / maxChargeLevel));
    }
}
