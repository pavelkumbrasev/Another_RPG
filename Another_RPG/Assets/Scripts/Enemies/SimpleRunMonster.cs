using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRunMonster : MovableEnemy {
    [SerializeField]
    private LayerMask whatIsGround;
    private bool flag=false;
    protected override void FixedUpdate()
    {
        if (flag && Vector2.Distance(transform.position, target.transform.position) < seeDistance )
        {
            rigidbody.velocity = new Vector2(direction * -1 * speed, rigidbody.velocity.y);
        }
        else flag = false;
        if (Physics2D.OverlapCircleAll(transform.position + new Vector3(direction, 1.0f), 0.2f, whatIsGround).Length > 0)
            flag = true;
        if (Vector2.Distance(transform.position, target.transform.position) < seeDistance && !flag)
            base.FixedUpdate();
     
            
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
