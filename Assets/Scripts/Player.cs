using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rig;
    private bool isJumping;

    public float speed;
    public float jump;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        //float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        if (h > 0)
        {
            rig.velocity = new Vector2(speed, rig.velocity.y);
            
        }

        if (h < 0)
        {
            rig.velocity = new Vector2(-speed, rig.velocity.y);
        }

    }

    void Jump()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!isJumping)
            {
                rig.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
            }
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            isJumping = false;
        }
    }
}
