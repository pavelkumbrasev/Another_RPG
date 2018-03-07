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
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
        else if (Input.GetButton("Horizontal"))
        {
            if (Input.GetAxis("Horizontal") > 0)
                direction = 1;
            else
                direction = -1;
            Move();
        }
        //else Stop();

        
    }

    protected override void Move()
    {
        rigidbody.velocity = transform.right * direction * speed * 2;
        sprite.flipX = direction < 0.0F;
    }

    private void Stop()
    {
        rigidbody.velocity = new Vector2(0.0f, 0.0f);
    }

    private void Jump()
    {
        Vector2 jumpDirection = new Vector2(0.0f, 2.0f);
        rigidbody.AddForce(jumpDirection * jumpforce, ForceMode2D.Impulse);

        //rigidbody.AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
    }

    private bool IsGrounded()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.2f);
        int k = 0;

        foreach(Collider2D elem in colliders)
        {
            if (elem.gameObject.tag == "Ground")
                k++;
        }

        Debug.Log(k);

        return k > 0;
    }
}