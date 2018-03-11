using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public float damage;
    public float radAttack;
    private void OnTriggerEnter2D(Collider2D col)
    {
        Unit unit = col.GetComponent<Unit>();
        if (unit && unit is Enemy)
            unit.DamageRecive(damage);
    }
}
