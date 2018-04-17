using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	public GameObject CameraRig;
	public GameObject LeftController;
	public GameObject RightController;
	public Vector3 LLT; //LLT = LastLeftContollerPosition
	public Vector3  LRT; //LRT = LastRightContollerPosition
	public Vector3  CLT; //CLT = CurrentLeftControllerPosition
	public Vector3  CRT; //CRT = CurrentRightControllerPosition
	public float StandandY = 1.4f; //Where the player's arm is on Y position when they raise
	public float FlyYDistance;

	// Use this for initialization
	void Start () {

		LLT = LRT = CLT = CRT = Vector3.zero;
		
	}
	
	// Update is called once per frame
	void Update () {

			
		CLT = LeftController.transform.position;
		CRT = RightController.transform.position;

		if ((CLT.y < StandandY) & (LLT.y > StandandY)
		    & (CRT.y < StandandY) & (LRT.y > StandandY)) {
			Debug.Log ("fly");
			CameraRig.gameObject.transform.position = new Vector3 (CameraRig.gameObject.transform.position.x, 
				CameraRig.gameObject.transform.position.y + FlyYDistance, 
				CameraRig.gameObject.transform.position.z);

			LLT = CLT;
			LRT = CRT;

			Debug.Log ("LLT:" + LLT.y);
			Debug.Log ("LRT:" +  LRT.y);
		}

		Debug.Log ("CLT:" + CLT.y);
		Debug.Log ("CRT:" + CRT.y);

	}


}

