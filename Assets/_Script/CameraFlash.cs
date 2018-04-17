using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFlash : MonoBehaviour {

	public float flashTimeLength;
	public bool doCameraFlash = true;
    public int FlashTimes;

	private Image flashImage;
	private float startTime;
	private bool flashing = false;

	// Use this for initialization
	void Start () {

		flashImage = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {

		if(doCameraFlash && !flashing)
		{
			Flash();
            FlashTimes = FlashTimes + 1;
            //Debug.Log(FlashTimes);

		}

        if(FlashTimes >5)
        {
            flashTimeLength = 6.0f;
        }

        if(FlashTimes > 7)
        {
            this.gameObject.SetActive(false);
        }
//		else
//		{
//			doCameraFlash = false;
//		}
	}

	public void Flash()
	{
		// initial color
		Color col = flashImage.color;

		// start time to fade over time
		startTime = Time.time;

		// so we can flash again
		doCameraFlash = false;

		// start it as alpha = 1.0 (opaque)
		col.a = 1.0f;

		// flash image start color
		flashImage.color = col;

		// flag we are flashing so user can't do 2 of them
		flashing = true;

		StartCoroutine(FlashCoroutine());

	}

	IEnumerator FlashCoroutine()
	{
		bool done = false;

		while(!done)
		{
			float perc;
			Color col = flashImage.color;

			perc = Time.time - startTime;
			perc = perc / flashTimeLength;

			if(perc > 1.0f)
			{
				perc = 1.0f;
				done = true;
				doCameraFlash = true;
			}

			col.a = Mathf.Lerp(1.0f, 0.0f, perc);
			flashImage.color = col;
			flashing = true;

			yield return null;
		}

		flashing = false;

		yield break;
	}
}
