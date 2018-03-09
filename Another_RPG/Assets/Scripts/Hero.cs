using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Unit
{

    [SerializeField]
    private float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    [SerializeField]
    public float epsilon = 0; 
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


        if (!CheckGround() && rigidbody.velocity.y <= epsilon && rigidbody.velocity.y <= 0) return;
        
        if (Input.GetButton("Horizontal") || Joystick.GetComponent<joystick>().GetX() != 0)
        {
            if (Input.GetAxis("Horizontal") > 0 || Joystick.GetComponent<joystick>().GetX() > 0)
                direction = 1;
            else
                direction = -1;
            Move();
        }




        if ((Input.GetButton("Jump") || Joystick.GetComponent<joystick>().GetY() > 0) && isGrounded)
        {
            Jump();
        }




    }

    private void Update()
    {

    }

    protected override void Move()
    {
        rigidbody.velocity = new Vector2(direction * speed, rigidbody.velocity.y);
        sprite.flipX = direction < 0.0F; 
    }


    private void Jump()
    {
        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
        
    }

    private bool CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, groundRadius, whatIsGround);
        return isGrounded = colliders.Length > 0;
    }
}