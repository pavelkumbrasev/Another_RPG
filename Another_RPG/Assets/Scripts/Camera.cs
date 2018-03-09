using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

	[SerializeField]
	private float speed=10.0F;
	[SerializeField]
	private Transform target;
    private Vector3 position;

    private void Awake(){
		if (!target)
			target = FindObjectOfType<Hero> ().transform;
	}
    private void Start()
    {
        position.x = target.transform.position.x;
        position.z = -10.0F;
        position.y = target.transform.position.y+0.5f;
    }
	private void FixedUpdate(){
        position.x = target.transform.position.x;
        transform.position = Vector3.Lerp (transform.position, position, speed * Time.deltaTime);

	}
}
