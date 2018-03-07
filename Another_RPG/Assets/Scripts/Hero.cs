using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Unit
{
    [SerializeField]
    private float jumpforce = 10.0F;
    private bool isGrounded = true;
    protected override void DamageRecive()
    {

    }

    private void FixedUpdate()
    { 
        if (Input.GetButton("Horizontal"))
        {
            if (Input.GetAxis("Horizontal") > 0)
                direction = 1;
            else direction = -1;
            Move();
        }
       
    }

    protected override void Move()
    {
       rigidbody.velocity = transform.right * direction*speed;
        sprite.flipX = direction < 0.0F;
    }
}