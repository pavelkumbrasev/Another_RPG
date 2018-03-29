using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using System.Threading;

public class Weapon : MonoBehaviour {
    public float damage;
    public float radAttack;
    private bool stay = false;
    [SerializeField]
    public float hideTime = 0.02f;
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

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Unit[] unit = collider.GetComponents<Unit>();
        for (int i=0;i<unit.Length;i++)
            if (unit[i] && unit[i] is Enemy)
                unit[i].DamageRecive(damage);

    }

   
}
