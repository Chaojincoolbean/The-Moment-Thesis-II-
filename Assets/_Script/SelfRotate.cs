using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRotate : MonoBehaviour {

	public float LoadTime;
	public float n;
    public float i;

	// Use this for initialization
	void Start () {

		LoadTime = 0;
	}
	
	// Update is called once per frame
	void Update () {

		LoadTime = LoadTime + Time.deltaTime;

		transform.Rotate (Vector3.up * n * Time.deltaTime);

		n = n - LoadTime* i;

        if(transform.localEulerAngles.y > 260){
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 180, transform.localEulerAngles.z);
        }

		
	}
}
