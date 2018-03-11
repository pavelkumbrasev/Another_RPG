using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using System.Threading;

public class Weapon : MonoBehaviour {
    public float damage;
    public float radAttack;

    [SerializeField]
    public int hideTime = 50;
    private bool activity = false;
    public void setActivity(bool value) { activity = value; }

    protected SpriteRenderer sprite;
    public SpriteRenderer getSprite() { return sprite; }

    protected virtual void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        gameObject.SetActive(activity);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Unit unit = col.GetComponent<Unit>();
        if (unit && unit is Enemy)
            unit.DamageRecive(damage);
    }

    public void TimerOff()
    {
        Thread.Sleep(hideTime);
        activity = false;
    }
    
}
