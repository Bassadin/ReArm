using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //UI Image References
    public Image image1, image2, image3;

    //Images for life full and life empty
    public Sprite healthFullImage, healthEmptyImage;

    //All images
    private Image[] healthImages;

    //Global instance
    private static HealthBar _instance;

    public static HealthBar Instance { get { return _instance; } }

    private Text scoreText;

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        healthImages = new Image[3] { image1, image2, image3 };
    }

    private void Start()
    {
        this.setHealthToValue(3);
    }

    public void setHealthToValue(int healthValue)
    {
        if (healthValue < 0 || healthValue > 3)
        {
            throw new System.Exception("Health value must be between 0 and 3");
        }

        for (int i = 0; i < healthImages.Length; i++)
        {
            healthImages[i].sprite = i >= healthValue ? healthEmptyImage : healthFullImage;
        }
    }
}
