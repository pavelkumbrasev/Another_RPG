using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit {
    [SerializeField]
    protected float seeDistance = 2.0f;
    [SerializeField]
    protected float attackDistance = 2.0f;
    [SerializeField]
    protected float resistance = 1.0f;
    [SerializeField]
    protected float healthPoint = 10.0f;
    protected Hero target;

   
    protected override void Awake()
    {
        base.Awake();
        target = FindObjectOfType<Hero>();
    }
    public override void DamageRecive(float damage)
    {
        healthPoint -= damage * resistance;
        Debug.Log(healthPoint);
        if (healthPoint <= 0) Die();
    }
    
}
