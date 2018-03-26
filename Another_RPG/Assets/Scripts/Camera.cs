using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

	[SerializeField]
	private float speed=10.0F;
	[SerializeField]
	private Transform target;
    private Vector3 position;
    private float localY;
    public float eps; // Расстояние по y при котором камера все еще не реагирует на смещение
    public float soft = 0.9f; // Коэфицент лпавности смещения камеры

    private void Awake(){
		if (!target)
			target = FindObjectOfType<Hero> ().transform;
	}
    private void Start()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        localY = transform.position.y;
    }


    private void Update()
    {

        transform.position = new Vector3(target.transform.position.x, localY, transform.position.z);




        if (target.GetComponent<Hero>().CheckGround())
        {
            localY = target.position.y + 0.15f + (localY - target.position.y) * 0.9f;
        }
        else
          if (Mathf.Abs(localY - target.position.y) > eps)
        {
            localY = target.position.y + 0.15f + eps;
            transform.position = new Vector3(target.transform.position.x, localY, transform.position.z);
        }



    



}






    private void FixedUpdate()
    {


    }
}
