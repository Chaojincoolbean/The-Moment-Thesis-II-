using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartbeatDraw : MonoBehaviour {
	LineRenderer line;
	public float[] beatPts;
	public float heartStrength;
	Vector3 centerPos;
	public Vector3[] pts;
	float ang;
	public float lineSpd;
	public float lineDist;
	float[] circlePts;
	int degNum;
	// Use this for initialization
	void Start () {
		line = GetComponent<LineRenderer> ();
		circlePts = new float[360];
		for (int i = 0; i < 360/beatPts.Length; i++) {
			for (int j = 0; j < beatPts.Length; j++) {
				circlePts [(i * beatPts.Length) + j] = beatPts [j];
			}
		}
		degNum = beatPts.Length;
		centerPos = Vector3.zero;//Camera.main.transform.position;
		pts = new Vector3[degNum];
		heartStrength = .5f;
	}
	
	// Update is called once per frame
	void Update () {
		ang += lineSpd * Time.deltaTime;
		ang = ang % 360;
		pts [0] = ToVect(ang-1) * lineDist;
		pts [0].y = Mathf.Lerp (circlePts [Mod(Mathf.FloorToInt(ang), 360)], 
			circlePts[(Mathf.FloorToInt (ang) + 1) % 360], 
								ang - Mathf.Floor(ang)) * heartStrength;


		for (int i = 1; i < degNum - 1; i++) {
			pts[i] = ToVect (Mathf.Floor(ang) - i) * lineDist;
			pts[i].y = circlePts [Mod(Mathf.FloorToInt (ang - (i - 1)), 360)] * heartStrength;
		}
		pts [degNum - 1] = pts [degNum - 2];
		//pts [0] = centerPos + (ToVect (ang) * lineDist);
		//pts [1] = centerPos + (ToVect (ang - 20f) * lineDist);
		line.positionCount = degNum;
		line.SetPositions (pts);
	}

	Vector3 ToVect(float a) {
		return new Vector3 (Mathf.Cos (a * Mathf.Deg2Rad), 0, Mathf.Sin (a * Mathf.Deg2Rad));
	}

	float ToAng(Vector3 a) {
		return Mathf.Atan2 (a.x, -a.z) * Mathf.Rad2Deg;
	}

	int Mod(float a, float b){
		while (a < 0) {
			a += b;
		}
		while (a > b) {
			a -= b;
		}
		return (int)a;
	}
}
