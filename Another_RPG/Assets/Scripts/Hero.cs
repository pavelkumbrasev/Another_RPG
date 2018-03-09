using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Unit
{
    [SerializeField]
    private float jumpforce = 10.0F;
    private bool isGrounded = true;

    public GameObject Joystick;

    protected override void DamageRecive()
    {

    }

    private void FixedUpdate()
    {
        isGrounded = CheckGround();
        if (!isGrounded) return;
     
        if (Input.GetButton("Horizontal") || Joystick.GetComponent<joystick>().GetX() !=0)
        {
            if (Input.GetAxis("Horizontal") > 0 || Joystick.GetComponent<joystick>().GetX() > 0)
                direction = 1;
            else
                direction = -1;
            Move();
        }
        else if (isGrounded) Stop();

        
    }

    private void Update()
    {

        // Вот тут джойстик ведь выдает не о его нажатии, а о оси
        //Так что не Input.GetButtonDown("Jump"), а Input.GetButton("Jump") ему эквивалентно

        if ((Input.GetButton("Jump") ||  Joystick.GetComponent<joystick>().GetY() > 0) && isGrounded)
        {

            Jump();
        }
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
        Vector2 jumpDirection = new Vector2(1.0f*direction, 2.0f);
        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(new Vector2(0, jumpforce),ForceMode2D.Force);
    }

    private bool CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.2f);
        int k = 0;

        foreach(Collider2D elem in colliders)
        {
            if (elem.gameObject.tag == "Ground")
                k++;
        }


        return k > 0;
    }
}