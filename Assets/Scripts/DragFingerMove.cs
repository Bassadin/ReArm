using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragFingerMove : MonoBehaviour
{
    private Vector2 touchPosition;
    private Rigidbody2D rigidbody2d;
    private Vector2 direction;
    public float moveSpeed = 10f;

    // Use this for initialization
    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.y < Screen.height / 3) //Only recognize touches in the lower third of the screen
            {
                touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                direction = (touchPosition - (Vector2)transform.position);
                rigidbody2d.velocity = new Vector2(direction.x, 0) * moveSpeed;

                if (touch.phase == TouchPhase.Ended)
                {
                    rigidbody2d.velocity = Vector2.zero;
                }
            }

        }
    }
}

