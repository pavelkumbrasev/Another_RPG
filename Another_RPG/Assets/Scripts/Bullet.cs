using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f;
    private Vector3 direction;
    public Vector3 Direction { set { direction = value; } }
    private Unit owner;
    public Unit Owner { set { owner = value; } }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    private void Start()
    {
        Destroy(gameObject, 1.5f);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();
        if(unit && (unit != owner))
        {
            Destroy(gameObject);
        }
    }
}
