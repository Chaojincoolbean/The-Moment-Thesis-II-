using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAreaLocation : MonoBehaviour {

	public GameObject[] PlayAreas;

	// Use this for initialization
	void Start () {

		for (int i = 0; i < PlayAreas.Length; i++) {
			
			PlayAreas [i].transform.position = new Vector3 (0, 0 + 50* i, 0 - 50*i);
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
