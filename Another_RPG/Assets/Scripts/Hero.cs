using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Hero : Unit
{

    [SerializeField]
    private float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    [SerializeField]
    private float epsilon = 0;
    [SerializeField]
    private float jumpforce = 10.0F;
    private bool isGrounded = true;

    [SerializeField]
    private Weapon HeroWeapon;

    Vector3 delta = new Vector3(0.6f, 0.5f);

    public GameObject Joystick;

    public override void DamageRecive(float damage)
    {

    }

    private void FixedUpdate()
    {
        isGrounded = CheckGround();


        if (!isGrounded && rigidbody.velocity.y <= epsilon && rigidbody.velocity.y <= 0) return;
        
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



        if (Input.GetButton("Fire1"))
        {
            HeroWeapon.gameObject.SetActive(true);
            HeroWeapon.setActivity(true);

            delta.x = 0.6f * direction;
            HeroWeapon.transform.position = gameObject.transform.position + delta;
            HeroWeapon.getSprite().flipX = direction < 0.0f;

            Thread hideThread = new Thread(new ThreadStart(HeroWeapon.TimerOff));
            hideThread.Start();
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

    public bool CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, groundRadius, whatIsGround);
        return isGrounded = colliders.Length > 0;
    }
}