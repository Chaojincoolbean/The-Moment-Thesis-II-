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
    public MeshRenderer skybox;
    public GameObject Light;
    public bool GameEnd1 = false;
    public bool GameEnd2 = false;
    public float Alpha;
    public GameObject Credits;

    void Start () {

        AS = this.gameObject.GetComponent<AudioSource>();
        //BA = BackgroundAudio.GetComponent<AudioSource>();

	}

    void Update()
    {

        GameTime = GameTime + Time.deltaTime;

        HeadsetDistance = Vector3.Distance(PlayerCamera.transform.position, HeadsetLastFrame);

        if (Vector3.Distance(PlayerCamera.transform.position, HeadsetLastFrame) < 0.001f)

        {
            LookForward();
        }
        else
        {
            if(Player.transform.position.y < AccelerationPoint2)
            {
                DesaturateCamera();
            }
        }

        HeadsetLastFrame = PlayerCamera.transform.position;

        if (Player.transform.position.y > AccelerationPoint2)
        {
            GameEnd1 = true;
        }
    
        if (Light.transform.rotation.x < - 0.1f)
        {
            GameEnd2 = true;
        }

        if (GameEnd1 == true & GameEnd2 == true)
        {
           
            Player.transform.position = new Vector3(Player.transform.position.x, //set player in the right position
                                        FloatEndPositionY,
                                        Player.transform.position.z);
            
            Alpha = Alpha - 0.001f;
            SetSkyAmount(Alpha);

        }

        if (Alpha <= 0)
        {
            Moment.SetActive(false);
            Credits.SetActive(true); 
            Credits.transform.position = new Vector3(Player.transform.position.x,
                                                     Player.transform.position.y + 100f,
                                                     Player.transform.position.z);
        }
    }



    void LookForward(){

        Vector3 camLookDir = PlayerCamera.transform.forward;

        Vector3 LookDir = new Vector3(0, 1, 0);

        if (GameTime > StartTime)
        {
            if (Vector3.Dot(camLookDir, LookDir) > 0.90f)
            {
                FloatUp();
            }
        }
        
    }

    void FloatUp() 
    {

        SaturateCamera();


            if (Player.transform.position.y > AccelerationPoint)
            {
               FloatSpeed += Acceleration;
            }

        Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + FloatSpeed, Player.transform.position.z);
    }

    void SetSkyAmount(float amount){
        
        skybox.sharedMaterial.SetFloat("_Cutoff", amount);

        //DebugView.GetComponent<TextMesh>().text = amount.ToString();
    }


    void DesaturateCamera(){
        
        DesaturateValue = PlayerCamera.GetComponent<FxPro>().DesaturateDarksStrength;

        if (DesaturateValue < 2f)
        {
            DesaturateValue = DesaturateValue + DesaturateSpeed;
            PlayerCamera.GetComponent<FxPro>().DesaturateDarksStrength = DesaturateValue;
            PlayerCamera.GetComponent<FxPro>().Init();
        }

        AudioListener.volume = Mathf.Lerp(AudioListener.volume,0.1f,0.01f);

    }

    void SaturateCamera(){

        //PlayerCamera.gameObject.GetComponent<AudioListener>().enabled = true;

        DesaturateValue = PlayerCamera.GetComponent<FxPro>().DesaturateDarksStrength;

        if (DesaturateValue > 0.0001f)
        {
            DesaturateValue = DesaturateValue - DesaturateSpeed;
            PlayerCamera.GetComponent<FxPro>().DesaturateDarksStrength = DesaturateValue;
            PlayerCamera.GetComponent<FxPro>().Init();
        }

        AudioListener.volume = Mathf.Lerp(AudioListener.volume, 1f, 0.01f);
    }

}
