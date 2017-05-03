using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputTextHandler : MonoBehaviour {
	public GameObject panel;
	public Text n;
	private Animator anim;
	//private Button bttn;

	// Use this for initialization
	void Start () {
		anim = panel.GetComponent<Animator> ();
		//bttn = GetComponent<Button> ();
		//bttn.onClick.AddListener (HandleClick); 
	}

	public void HandleClick()
	{
		//string txt = bttn.GetComponentInChildren<Text> ().text.ToString();]
		Debug.Log("n : "+n.text);
		if (n.text.Equals (""))
			return;
		//make more general later. complications with dynamic grid.
		if(int.Parse(n.text) > 1 && int.Parse(n.text) < 4)
		{
			//pass text n to next screen
			panel.GetComponent<MatrixHandler>().dimension = int.Parse(n.text);
			//animated camera to zoom
			//Camera.main.transform.position
			anim.SetTrigger ("NextScreen");
		}
	}
}
