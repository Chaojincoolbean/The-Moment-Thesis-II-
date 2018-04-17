using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlyManager : MonoBehaviour
{

    public GameObject Player;
    public GameObject Ride;
    public float FlySpeed;
    public float StartTime;
    


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Time.timeSinceLevelLoad > StartTime)
        {
            Fly();
        }



    }


    void Fly()
    {
    
        Player.transform.position = new Vector3(Player.transform.position.x + FlySpeed, Player.transform.position.y, Player.transform.position.z);
        Ride.transform.position = Player.transform.position;


    }
}
