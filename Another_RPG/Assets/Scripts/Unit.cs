using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
	protected int health_point=1;
	[SerializeField]
	protected float speed=1.0f;
	protected virtual void Move(){
	}
	protected virtual void DamageRecive(){
		gameObject.SetActive (false);
	}

}
