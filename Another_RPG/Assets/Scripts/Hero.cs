using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Unit {
    [SerializeField]
    private float jumpforce = 10.0F;
    private bool isGrounded = true;
    protected override void DamageRecive()
    {
        
    }

}
