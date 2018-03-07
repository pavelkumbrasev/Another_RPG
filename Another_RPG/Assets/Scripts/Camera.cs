using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

	[SerializeField]
	private float speed=10.0F;
	[SerializeField]
	private Transform target;


	private void Awake(){
		if (!target)
			target = FindObjectOfType<Hero> ().transform;
	}
	private void FixedUpdate(){
		Vector3 position ;
        position = target.transform.position;
		position.z = -10.0F;
        position.y += 0.5f;
		transform.position = Vector3.Lerp (transform.position, position, speed * Time.deltaTime);

	}
}
