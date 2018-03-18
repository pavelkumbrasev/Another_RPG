using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_anim_control : MonoBehaviour {


    private Animator anim;
    private Rigidbody2D rb;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    void FixedUpdate()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));


    }
}
