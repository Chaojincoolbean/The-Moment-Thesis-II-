using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsBehavior : MonoBehaviour {

    public GameObject Player;
    public GameObject Clouds1;
    public GameObject Clouds2;
    public GameObject Clouds3;
    public GameObject Clouds4;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        if (Player.transform.position.y > Clouds1.transform.position.y)
        {
            Clouds1.SetActive(false);

            if (Player.transform.position.y > Clouds1.transform.position.y + 20f){

                Clouds1.SetActive(true);
            }
        }

        if (Player.transform.position.y > Clouds2.transform.position.y)
        {

            Clouds2.SetActive(false);

            if (Player.transform.position.y > Clouds2.transform.position.y + 20f)
            {

                Clouds2.SetActive(true);
            }
        }

        if (Player.transform.position.y > Clouds3.transform.position.y)
        {

            Clouds3.SetActive(false);

            if (Player.transform.position.y > Clouds3.transform.position.y + 20f)
            {

                Clouds3.SetActive(true);
            }
        }

        if (Player.transform.position.y > Clouds4.transform.position.y)
        {

            Clouds4.SetActive(false);

            if (Player.transform.position.y > Clouds4.transform.position.y + 20f)
            {

                Clouds4.SetActive(true);
            }
        }





		
	}
}
