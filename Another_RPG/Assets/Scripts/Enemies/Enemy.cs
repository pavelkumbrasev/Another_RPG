using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit {
    [SerializeField]
    protected float seeDistance = 2.0f;
    [SerializeField]
    protected float attackDistance = 2.0f;
    protected Hero target;

   
    protected override void Awake()
    {
        base.Awake();
        target = FindObjectOfType<Hero>();
    }
   
}
