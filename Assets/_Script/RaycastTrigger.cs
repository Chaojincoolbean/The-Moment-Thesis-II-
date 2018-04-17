using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTrigger : MonoBehaviour {

    public Camera PlayerCamera;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Ray ray = new Ray (PlayerCamera.transform.position, PlayerCamera.transform.forward);

		RaycastHit rayHit = new RaycastHit();

		if (Physics.Raycast (ray, out rayHit, 10000f)) {
            Debug.Log("hit");
            if (rayHit.transform == this.transform){
                Debug.Log("hit");
				transform.localScale *= 1.1f;
			}
		}
		
	}
}
