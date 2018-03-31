using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RangeMob : Enemy {
    private Bullet bullet;
    private DateTime lastShotTime;

    protected override void Awake()
    {
        base.Awake();
        bullet = Resources.Load<Bullet>("Bullet");
        lastShotTime = DateTime.Now;
    }

    private void FixedUpdate()
    {
        direction = Mathf.Sign(target.transform.position.x - transform.position.x);

        if (Math.Abs(DateTime.Now.Second - lastShotTime.Second) >= 3)
        {
            Shoot();
            lastShotTime = DateTime.Now;
        }
    }

    private void Shoot()
    {
        Vector3 position = transform.position;

        Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;
        newBullet.Direction = new Vector3(direction, 0);
        newBullet.Owner = this;
    }
}
