using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableEnemy : Enemy {

	protected virtual void FixedUpdate()
    {
        Move();
    }
}
