using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : BaseDamageableCharacterController
{
    public float speed;
    public BaseWeapon equippedWeapon;
    private float weaponTimer = 0;

    private Transform _transform;

    private Renderer _renderer;
    float playerWidth;

    public HealthBar healthBarReference;

    public override void Awake()
    {
        base.Awake();
        _transform = this.transform;
        _renderer = this.GetComponent<Renderer>();
    }

    void Start()
    {
        healthBarReference.setHealthToValue(getLifePoints());
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

        if (Input.GetKeyUp(KeyCode.U)) {
            this.equippedWeapon.upgradeWeaponLevel();
        }
    }

    public override void changeLife(int changeAmount)
    {
        base.changeLife(changeAmount);
        healthBarReference.setHealthToValue(getLifePoints());
    }

    public override void onDeath()
    {
        StaticGameInfo.setLastGameScore(ScoreManager.Instance.getScore());
        SceneManager.LoadScene(3);
    }

    public override int getMaxLife()
    {
        return 3;
    }
}
