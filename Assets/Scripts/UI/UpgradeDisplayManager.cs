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

    public void setUpgradeLevelToDisplay(int setUpgradeLevel, int maxUpgradeLevel)
    {
        Debug.Assert(setUpgradeLevel >= 0);
        staffMask.rectTransform.SetSizeWithCurrentAnchors(
            RectTransform.Axis.Vertical,
            (float)maxHeight * (Mathf.Clamp(setUpgradeLevel, 0f, maxUpgradeLevel) / (float)maxUpgradeLevel));
        Debug.Log("Set staff upgrade bar height to " + maxHeight * (Mathf.Clamp(setUpgradeLevel, 0, maxUpgradeLevel) / maxUpgradeLevel));
    }
}
