using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SailManager : MonoBehaviour {

	public GameObject Boat;
	public GameObject Water;
	public GameObject Player;
	public GameObject PlayerCamera;
	public GameObject SailScene;
	public GameObject Lobby;
	public float SailStartTime;
	public float SailSpeed;
	public float DrowingSpeed;
    public GameObject BackgroundMusic;
    public float Loadtime;
	public float Drown;
	public Material LobbySkybox;


	// Use this for initialization
	void Start () {

        Player.transform.position = new Vector3(0f, 0f, 0f);
        Loadtime = 0f;
		
	}
	
	// Update is called once per frame
	void Update () {

        Loadtime = Loadtime + Time.deltaTime;

        if (Loadtime > SailStartTime) {

			Boat.SetActive (true);
            Sail();
  
        }

		if(PlayerCamera.transform.position.y < Water.transform.position.y)
        {

            Loadtime = 0f;
            Lobby.SetActive(true);
			SailScene.SetActive (false);
            Player.transform.position = new Vector3(0f, 0f, 0f);
            PlayerCamera.GetComponent<Camera>().clearFlags = CameraClearFlags.Skybox;
			//PlayerCamera.GetComponent<Camera>().backgroundColor = SailColor;
			RenderSettings.skybox = LobbySkybox;
        }

		if (Boat.transform.position.y < Water.transform.position.y - 0.5f) {
			Boat.SetActive (false);
		}

    }

	public void Sail(){

		Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y - DrowingSpeed, Player.transform.position.z + SailSpeed);
		Boat.transform.position = new Vector3(Boat.transform.position.x, Boat.transform.position.y - DrowingSpeed, Boat.transform.position.z + SailSpeed);
        

	}
}
