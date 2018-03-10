using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRunMonster : MovableEnemy {

    protected override void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, target.transform.position) < seeDistance)
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
