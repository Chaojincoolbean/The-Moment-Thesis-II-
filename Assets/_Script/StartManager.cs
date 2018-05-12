using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour {

	public float LoadTime;
	public GameObject Canvas;
	public GameObject HeartBeatGroup;
    public GameObject HeartBeat1;
    public GameObject HeartBeat2;
    public GameObject HeartBeat3;
	public GameObject Mask;
    public GameObject Dying;
    public GameObject Moment;
    public GameObject Star;
    public Camera PlayerCamera;
    public Material Daytime;
    private int LengthOfLineRender;
    public LineRenderer lineRender1;
    public LineRenderer lineRender2;
    public LineRenderer lineRender3;
    private bool changeYposition1 = true;
    private bool changeYposition2 = true;
    private bool changeYposition3 = true;
    private bool changeYposition4 = true;
    private bool changeYposition5 = true;
    private bool changeYposition6 = true;

    // Use this for initialization
    void Start () {

        LoadTime = 0f;
        lineRender1 = HeartBeat1.GetComponent<LineRenderer>();
        lineRender2 = HeartBeat2.GetComponent<LineRenderer>();
        lineRender3 = HeartBeat3.GetComponent<LineRenderer>();
        LengthOfLineRender = 28;

    }
	
	// Update is called once per frame
	void Update () {

        LoadTime = LoadTime + Time.deltaTime;

		if (LoadTime > 15f) {
			HeartBeatGroup.SetActive (true);
			Mask.SetActive (true);
		}

        if (LoadTime > 55f)
        {
            Canvas.SetActive(false);

            if(changeYposition1 == true){
                
                ChangeY(lineRender1, 0.8f);
                ChangeY(lineRender2, 0.8f);
                ChangeY(lineRender3, 0.8f);
                changeYposition1 = false;
            }
        }

        if (LoadTime > 66f)
        {

            if (changeYposition2 == true){
                
                ChangeY(lineRender1, 0.6f);
                ChangeY(lineRender2, 0.6f);
                ChangeY(lineRender3, 0.6f);
                changeYposition2 = false;
            }
        }

        if (LoadTime > 77f)
        {

            if (changeYposition3 == true)
            {

                ChangeY(lineRender1, 0.4f);
                ChangeY(lineRender2, 0.4f);
                ChangeY(lineRender3, 0.4f);
                changeYposition3 = false;
            }
        }

        if (LoadTime > 85f)
        {

            if (changeYposition4 == true)
            {

                ChangeY(lineRender1, 0.2f);
                ChangeY(lineRender2, 0.2f);
                ChangeY(lineRender3, 0.2f);
                changeYposition4 = false;
            }
        }

        if (LoadTime > 95f)
        {

            if (changeYposition5 == true)
            {

                ChangeY(lineRender1, 0.1f);
                ChangeY(lineRender2, 0.1f);
                ChangeY(lineRender3, 0.1f);
                changeYposition5 = false;
            }
        }


        if (LoadTime > 99f) {

            Mask.SetActive(false);

            if (changeYposition6 == true){
                
                ChangeY(lineRender1, 0f);
                ChangeY(lineRender2, 0f);
                ChangeY(lineRender3, 0f);
                changeYposition6 = false;
            }

        }


		if (LoadTime > 115f) {

            LoadTime = 0f;
            Moment.SetActive(true);
            Star.SetActive(true);
            Dying.SetActive(false);
            PlayerCamera.GetComponent<Camera>().clearFlags = CameraClearFlags.Skybox;
            RenderSettings.skybox = Daytime;

        }

    }

    void ChangeY(LineRenderer m, float n){

        Vector3[] positions = new Vector3[LengthOfLineRender];

        for (int i = 0; i < LengthOfLineRender; i++ ){
            positions[i] = m.GetPosition(i);
            positions[i] = new Vector3(positions[i].x, positions[i].y * n, positions[i].z);
        }

        m.SetPositions(positions);
    }
}
