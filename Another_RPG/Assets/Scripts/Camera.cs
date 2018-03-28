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
    public float epsD;
    public float epsU;// Расстояние по y при котором камера все еще не реагирует на смещение
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
        if (transform.position.y - target.position.y > 0 && Mathf.Abs(transform.position.y - target.position.y) > epsD)
        {
            localY = target.position.y + epsD;
            transform.position = new Vector3(target.transform.position.x, localY, transform.position.z);
        }
        else
        if (transform.position.y - target.position.y < 0 && Mathf.Abs(transform.position.y - target.position.y) > epsU)
        {
            localY = target.position.y - epsU;
            transform.position = new Vector3(target.transform.position.x, localY, transform.position.z);

        }

    



}






    private void FixedUpdate()
    {


    }
}
