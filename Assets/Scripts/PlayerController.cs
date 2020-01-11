using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : BaseDamageableCharacterController
{
    private static PlayerController _instance;

    public static PlayerController Instance { get { return _instance; } }
    public float speed;
    public BaseWeapon equippedWeapon;
    public BaseWeapon weaponToInstatiate;

    private Transform _transform;

    private Renderer _renderer;
    float playerWidth;

    public override void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        base.Awake();
        _transform = this.transform;
        _renderer = this.GetComponent<Renderer>();
    }

    public void equipWeapon(BaseWeapon weaponToEquip) {
        this.equippedWeapon = Instantiate(weaponToEquip);
        this.equippedWeapon.playerTransformReference = this.gameObject.transform;
    }

    void Start()
    {
        HealthBar.Instance.setHealthToValue(getLifePoints());
        playerWidth = _renderer.bounds.size.x;
        equipWeapon(weaponToInstatiate);
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
    }

    public override void changeLife(int changeAmount)
    {
        base.changeLife(changeAmount);
        HealthBar.Instance.setHealthToValue(getLifePoints());
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
