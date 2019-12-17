using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public BaseWeapon equippedWeapon;
    private float weaponTimer = 0;

    private Transform _transform;

    private Renderer _renderer;
    private int lifePoints;
    float playerWidth;

    public HealthBar healthBarReference;

    void Awake()
    {
        _transform = this.transform;
        _renderer = this.GetComponent<Renderer>();
    }

    void Start() {
        lifePoints = 3;
        healthBarReference.setHealthToValue(lifePoints);
        playerWidth = _renderer.bounds.size.x;
    }

    void Update()
    {
        weaponTimer += Time.deltaTime;
        if (weaponTimer >= equippedWeapon.shootingFrequency)
        {
            this.equippedWeapon.fireWeapon((Vector2)this.gameObject.transform.position + new Vector2(0, 2));
            weaponTimer = 0;
        }
    }

    void FixedUpdate()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");

        if (_transform.position.x < Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x && horizontalAxis < 0)
        {
            horizontalAxis = 0;
        }

        if (_transform.position.x > Camera.main.ScreenToWorldPoint(new Vector2(Screen.width - playerWidth, 0)).x && horizontalAxis > 0)
        {
            horizontalAxis = 0;
        }

        _transform.Translate(new Vector3(horizontalAxis * speed, 0, 0));

        if (Input.touchCount > 0)
        {

        }
    }

    public void changeLife(int changeAmount) {
        lifePoints = Mathf.Clamp(getLifePoints() + changeAmount, 0, 3);
        healthBarReference.setHealthToValue(getLifePoints());

        Debug.Log("Player life has been set to: " + getLifePoints());

        if (lifePoints == 0) {
            //Throw the user back into the main menu for now
            SceneManager.LoadScene(0);
        }
    }

    public int getLifePoints() {
        return lifePoints;
    }
}
