using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLerp : MonoBehaviour {
	public Vector3 endMark = new Vector3 (-26.1f, 44.1f, -91.4f);
	public float speed = 50f;

	private Vector3 startMark;
	private float startTime, lerpLength, distCovered, lerpFrac;

	// Use this for initialization
	void Start () 
	{
		lerpFrac = 0f;
		startMark = Camera.main.transform.position;
		startTime = Time.time;
		lerpLength = Vector3.Distance (startMark, endMark);
	}

	void OnEnable()
	{
		lerpFrac = 0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (lerpFrac < 1) 
		{
			Debug.Log ("Lerp Fraction : " + lerpFrac);
			distCovered = (Time.time - startTime) * speed;
			lerpFrac = distCovered / lerpLength;
			Camera.main.transform.position = Vector3.Lerp (startMark, endMark, lerpFrac);
		}
	}
}
