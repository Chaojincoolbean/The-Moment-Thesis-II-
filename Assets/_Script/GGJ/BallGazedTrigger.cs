using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGazedTrigger : MonoBehaviour {

    public float timeLookedAt;
    public Camera PlayerCamera;
    public float y;

	// Use this for initialization
	void Start () {

        timeLookedAt = 0f;
		
	}
	
	// Update is called once per frame
	void Update () {

        y = this.gameObject.transform.position.y;

        Vector3 camLookDir = PlayerCamera.transform.forward;

        Vector3 VectorFromCamToTarget = transform.position - PlayerCamera.transform.position;

        float angle = Vector3.Angle(camLookDir, VectorFromCamToTarget);

        //Debug.Log(angle);

        if (angle < 15f * transform.localScale.x)
        {

            //timeLookedAt = timeLookedAt + Time.deltaTime;   //after 1 second, this variable will be 1f

            //if (timeLookedAt > 2f)
            //{

                y = y + 0.01f;

                this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, y, this.gameObject.transform.position.z);
            //}
        }

        //else timeLookedAt = 0f;
		
	}
}
