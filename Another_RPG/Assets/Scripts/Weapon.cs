using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using System.Threading;

public class Weapon : MonoBehaviour {
    public float damage;
    public float radAttack;

    [SerializeField]
    public float hideTime = 0.2f;
    private bool activity = false;
    public void setActivity(bool value) { activity = value; }

    protected SpriteRenderer sprite;
    public SpriteRenderer getSprite() { return sprite; }

    protected virtual void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
    protected void OnEnable()
    {
        StartCoroutine(Hide());
    }
    private IEnumerator Hide()
    {
        yield return new WaitForSeconds(hideTime);
        gameObject.SetActive( false);
             

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

    
}
