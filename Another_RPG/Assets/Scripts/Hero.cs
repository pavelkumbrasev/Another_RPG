using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Unit
{




    /* Затестим прыжок с новой ground */




    //находится ли персонаж на земле или в прыжке?
    [SerializeField]
    private bool isGrounded = false;
    //ссылка на компонент Transform объекта
    //для определения соприкосновения с землей
    public Transform groundCheck;
    //радиус определения соприкосновения с землей
    [SerializeField]
    private float groundRadius = 0.2f;
    //ссылка на слой, представляющий землю
    public LayerMask whatIsGround;







    [SerializeField]
    private float jumpforce = 10.0F;
    [SerializeField]
   // private bool isGrounded = true;


    private Vector2 nowVelocityVector;

    public GameObject Joystick;

    protected override void DamageRecive()
    {

    }

    private void FixedUpdate()
    {
        isGrounded = CheckGround();

        //if (!isGrounded) return;
     
        if (Input.GetButton("Horizontal") || Joystick.GetComponent<joystick>().GetX() !=0)
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


        //  else if (isGrounded) Stop();


    }

    private void Update()
    {

        // Вот тут джойстик ведь выдает не о его нажатии, а о оси
        //Так что не Input.GetButtonDown("Jump"), а Input.GetButton("Jump") ему эквивалентно










    }

    protected override void Move()
    {
        // rigidbody.velocity = transform.right * direction * speed * 2;
        // Никто не должен нарушать движения вверх. И вообще чужие вектора просто так

        rigidbody.velocity = new Vector2(direction * speed, rigidbody.velocity.y);


        sprite.flipX = direction < 0.0F; // ???!!!!!!!!!!!!!
    }

    private void Stop()
    {
        rigidbody.velocity = new Vector2(0.0f, 0.0f);
    }

    private void Jump()
    {
       // Vector2 jumpDirection = new Vector2(1.0f*direction, 2.0f);// ??? 0_о
       // rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(new Vector2(0, jumpforce),ForceMode2D.Impulse);
    }

    private bool CheckGround()
    {
       return isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
    }
}