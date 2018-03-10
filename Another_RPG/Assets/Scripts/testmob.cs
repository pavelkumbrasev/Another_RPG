using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class testmob : MonoBehaviour
{
    public float seeDistance = 2f;
    public float attackDistance = 2f; 
    public float speed = 6;
    public Transform target;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, target.transform.position) < seeDistance)
        {
            if (Vector2.Distance(transform.position, target.transform.position) > attackDistance)
            {
                transform.right = target.transform.position - transform.position;
                transform.Translate(new Vector2(speed * Time.deltaTime, 0));
            }
        }   
    }
}
