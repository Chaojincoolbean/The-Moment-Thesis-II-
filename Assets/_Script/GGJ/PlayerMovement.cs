using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public GameObject Controller;
    public int Notmoving;
    public float Upspeed;
	public float y;
    public Vector3 LastPosition;
    public float Distance;
    public float Horizon;
    public float AllowedMoveDistance;


	// Use this for initialization
	void Start () {

        y = this.gameObject.transform.position.y;
        LastPosition = Controller.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        y = this.gameObject.transform.position.y;
     
        CheckControllerMovement(); 

        if(Notmoving >= 200){
            
            y = y + Upspeed;  
        }

        else y = y - Upspeed;

            if(y < Horizon){

                y = Horizon;
            }

        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, y, this.gameObject.transform.position.z);
	    
        LastPosition = Controller.transform.position;
    
    }

    void CheckControllerMovement(){

        Distance = Vector3.Distance(LastPosition, Controller.transform.position);
        //Debug.Log(Controller.transform.position);

        Debug.Log(Distance);

        if (Distance > AllowedMoveDistance)
        {
            Notmoving = 0;
        }
        else Notmoving++;

        //Debug.Log(Notmoving);
    }

}
