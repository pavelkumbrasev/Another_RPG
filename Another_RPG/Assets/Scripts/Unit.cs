using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
    [SerializeField]
	protected int health_point=1;
	[SerializeField]
	protected float speed=1.0f;
    protected SpriteRenderer sprite;
    protected float direction=1.0f;
    protected Animator animator;
    new protected Rigidbody2D rigidbody;
    protected virtual void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }
    protected virtual void Move(){
	}
	protected virtual void DamageRecive(){
		gameObject.SetActive (false);
	}

}
