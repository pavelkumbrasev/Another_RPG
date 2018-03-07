using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Unit {
    [SerializeField]
    private float jumpforce = 10.0F;
    private bool isGrounded = true;
    protected override void DamageRecive()
    {
        
    }

    private void FixedUpdate()
    {
       // Debug.Log(Input.GetAxis("Horizontal"));
        if (Input.GetAxis("Horizontal") !=0)
        {
            if (Input.GetAxis("Horizontal") > 0)
                direction = 1;
            else direction = -1;
            Move();
        }
        //if (Input.GetButtonDown("Horizontal"))
    }

    protected override void Move()
    {
        Vector3 force = transform.right * direction * speed;
        rigidbody.AddForce(force,ForceMode2D.Impulse);
    }
}
