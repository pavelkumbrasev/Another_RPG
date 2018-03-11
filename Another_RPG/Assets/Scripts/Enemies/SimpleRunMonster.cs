using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRunMonster : MovableEnemy {
    [SerializeField]
    private LayerMask whatIsGround;
    [SerializeField]
    private float walkDiameter = 5.0F;
    private bool flag=false;
    protected override void FixedUpdate()
    {
        if(Physics2D.OverlapCircleAll(transform.position + new Vector3(direction, 1.0f), 0.2f, whatIsGround).Length > 0)
        flag = true;
        if (Vector2.Distance(transform.position, target.transform.position) < seeDistance && !flag)
        {
            base.FixedUpdate();
        }
        if (flag)
        {
            rigidbody.velocity = new Vector2(0, 0);
           // Debug.Log(Mathf.Abs(transform.position.y - target.transform.position.y));
            if ((target.transform.position.x - transform.position.x) < 0.5f && Mathf.Abs(transform.position.y - target.transform.position.y) < 1)
            {
                direction = Mathf.Sign(target.transform.position.x - transform.position.x);
                rigidbody.AddForce(new Vector2(-direction, 0), ForceMode2D.Impulse);
                flag = false;
            }
        }
        else flag = false;
    }
    protected override void Move()
    {
        direction = Mathf.Sign(target.transform.position.x - transform.position.x);

        if (Vector2.Distance(transform.position, target.transform.position) > attackDistance)
        {
            rigidbody.velocity = new Vector2(direction * speed, rigidbody.velocity.y);
            sprite.flipX = direction > 0.0F;
        }
    }
}
