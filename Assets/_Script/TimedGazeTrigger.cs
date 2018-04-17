using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.Events;

public class TimedGazeTrigger : MonoBehaviour {

	[SerializeField] float timeLookedAt = 0f; //time in seconds, we've spent looking at this thing.
	public Camera PlayerCamera;
	public GameObject TitleEnglish;
    public GameObject Name; 
    public Color TitleColor;
    private AudioSource As;
	public GameObject Lobby;
	public GameObject Dying;
    public float y;

	// Use this for initialization
	void Start () {
        
        As = this.gameObject.GetComponent<AudioSource>();
        timeLookedAt = 0f;
        y = this.gameObject.transform.position.y;

    }
	
	// Update is called once per frame
	void Update () {

		Vector3 camLookDir = PlayerCamera.transform.forward;

		Vector3 VectorFromCamToTarget = transform.position - PlayerCamera.transform.position;

		float angle = Vector3.Angle (camLookDir, VectorFromCamToTarget);

		if (angle < 15f * transform.localScale.x) {
			
			timeLookedAt =  timeLookedAt + Time.deltaTime;   //after 1 second, this variable will be 1f
            TitleColor.a = 1 - timeLookedAt/20;
            As.volume = As.volume - timeLookedAt / 8000;
            y = y + timeLookedAt/100;
            this.gameObject.transform.position = new Vector3(transform.position.x, y, transform.position.z);
            Debug.Log(y);

            
            if(TitleColor.a < 0)
            {
                TitleColor.a = 0;
            }

            this.gameObject.GetComponent<SpriteRenderer>().color = TitleColor;
            TitleEnglish.gameObject.GetComponent<SpriteRenderer>().color = TitleColor;
            Name.gameObject.GetComponent<SpriteRenderer>().color = TitleColor;

            if (TitleColor.a == 0) {
                //OnGazeComplete.Invoke ();	//fire any events accosiating this event
                //Loadtime = 0f;
                timeLookedAt = 0f;
                Dying.SetActive(true);
				Lobby.SetActive (false);
                PlayerCamera.GetComponent<Camera>().clearFlags = CameraClearFlags.SolidColor;
			}
		}
	}
}
