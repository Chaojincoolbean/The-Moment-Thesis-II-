using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloatMovement : MonoBehaviour {

	public GameObject Player;
    public GameObject PlayerCamera;
    public GameObject Target;
	public float FloatSpeed;
    public float Acceleration;
    public float MaxSpeed;
    public float AccelerationPoint;
    public float AccelerationPoint2;
    public float AccelerationPoint3;
    public float FloatEndPositionY;
    public AudioSource AS;
    public AudioSource BA;
    public GameObject Moment;
    public GameObject Lobby;
    private float GameTime;
    public float StartTime;
    public GameObject DebugView;
    public bool NotMoving = true;
    public Vector3 HeadsetLastFrame = new Vector3(0,0,0);
    public float HeadsetDistance;
    public float DesaturateSpeed;
    public float DesaturateValue;
    public GameObject Wind;
    public GameObject Sound;

    void Start () {

        AS = this.gameObject.GetComponent<AudioSource>();
        //BA = BackgroundAudio.GetComponent<AudioSource>();

	}
	
	void Update () {

        GameTime = GameTime + Time.deltaTime;

        HeadsetDistance = Vector3.Distance(PlayerCamera.transform.position, HeadsetLastFrame);

        DebugView.gameObject.GetComponent<TextMesh>().text = HeadsetDistance.ToString();

        if(Vector3.Distance(PlayerCamera.transform.position,HeadsetLastFrame)< 0.0001f)
            
        {
            LookForward();
        }
        else {
            
            DesaturateCamera();
        }

        HeadsetLastFrame = PlayerCamera.transform.position;

    }

    void LookForward(){

        Vector3 camLookDir = PlayerCamera.transform.forward;

        Vector3 LookDir = new Vector3(0, 1, 0);

        if (GameTime > StartTime)
        {
            if (Vector3.Dot(camLookDir, LookDir) > 0.99)
            {
                FloatUp();
                Debug.Log("called");
            }
        }
        
    }

    void FloatUp()
    {

        SaturateCamera();

        if(Player.transform.position.y > AccelerationPoint)
        {
            FloatSpeed += Acceleration;
        }

        Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + FloatSpeed, Player.transform.position.z);

         if (Player.transform.position.y > FloatEndPositionY)
         {
            Lobby.SetActive(true);
            Moment.SetActive(false);
        }
    }

    void DesaturateCamera(){
        
        DesaturateValue = PlayerCamera.GetComponent<FxPro>().DesaturateDarksStrength;

        if (DesaturateValue < 2f)
        {
            DesaturateValue = DesaturateValue + DesaturateSpeed;
            PlayerCamera.GetComponent<FxPro>().DesaturateDarksStrength = DesaturateValue;
            PlayerCamera.GetComponent<FxPro>().Init();
        }

        this.gameObject.GetComponent<AudioListener>().enabled = false;
    }

    void SaturateCamera(){

        DesaturateValue = PlayerCamera.GetComponent<FxPro>().DesaturateDarksStrength;

        if (DesaturateValue > 0.0001f)
        {
            DesaturateValue = DesaturateValue - DesaturateSpeed;
            PlayerCamera.GetComponent<FxPro>().DesaturateDarksStrength = DesaturateValue;
            PlayerCamera.GetComponent<FxPro>().Init();
        }

        this.gameObject.GetComponent<AudioListener>().enabled = true;
    }
}
