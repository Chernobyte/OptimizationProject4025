using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatrixHandler : MonoBehaviour {
	public int dimension;
	//public int[,] matrix;
	public GameObject dimensionInput;
	public GameObject payoffMatrix;
	public GameObject results;
	public Animator camera;
	private Animator menu;

	// Use this for initialization
	void Start () {
		//dimensionInput.SetActive (true);
		//payoffMatrix.SetActive (false);
		menu = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape) && !menu.GetCurrentAnimatorStateInfo (0).IsName ("idle"))
			camera.SetTrigger ("Animate");

		if (camera.IsInTransition (0) && camera.GetNextAnimatorStateInfo (0).IsName ("BackToMenu2")) 
		{
			menu.SetTrigger ("FirstScreen");
		}
	}

	public void OptimalP1(int[,] matrix)
	{
		Text[] txts = results.GetComponentsInChildren<Text> ();

		string lxy = Lxy (matrix) + "\n         = ";
		string tmp1 = "";
		string tmp2 = "";
		string tmp3 = "";
		string func = "f(x) = min{f1(x), f2(x)" + (dimension == 3 ? ", f3(x)" : "") + "} \n       =";

		for (int i = 0; i < dimension; i++) 
		{
			tmp1 = tmp1 + matrix[i,0] + "x" + i;
		}
		for (int i = 0; i < dimension; i++) 
		{
			tmp2 = tmp2 + (matrix[i,1] >= 0 ? "+" : "") + matrix[i,1] + "x" + i;
		}
		if (dimension == 3) 
		{
			for (int i = 0; i < dimension; i++) 
			{
				tmp3 = tmp3 + (matrix[i,2] >= 0 ? "+" : "") + matrix[i,2] + "x" + i;
			}
		}

		lxy = lxy + "(" + tmp1 + ")y1 + (" + tmp2 + ")y2" + (dimension == 3 ? " + (" + tmp3 + ")y3" : "");
		func = func + "min{" + tmp1 + ", " + tmp2 + (dimension == 3 ? ", " + tmp3 : "") + "}";
		string sysEq = tmp1 + " = " + tmp2 + (dimension == 3 ? " = " + tmp3 : "");

		tmp1 = "f1(x) = " + tmp1;
		tmp2 = "f2(x) = " + tmp2;
		if(dimension == 3)
			tmp3 = "f3(x) = " + tmp3;

		//title
		//lxy
		//tmp 1-3
		//func
		//sysEq
		// SOLUTION OF SYSTEM OF EQUATIONS
		txts [0].text += " P1:";
		txts [1].text = lxy;
		txts [2].text = tmp1;
		txts [3].text = tmp2;
		txts [4].text = dimension == 3 ? tmp3 : "";
		txts [5].text = func;
		txts [6].text = sysEq;
		txts [7].text = "x0 = \nx1 = " + (dimension == 3 ? "\nx2 = " : "");

		/*Debug.Log (lxy);
		Debug.Log (tmp1);
		Debug.Log (tmp2);
		if (dimension == 3) 
			Debug.Log (tmp3);*/
	}

	public void OptimalP2(int[,] matrix)
	{
		Text[] txts = results.GetComponentsInChildren<Text> ();

		string lxy = Lxy (matrix) + "\n         = ";
		string tmp1 = "";
		string tmp2 = "";
		string tmp3 = "";
		string func = "g(y) = max{g1(y), g2(y)" + (dimension == 3 ? ", g3(y)" : "") + "} \n       =";

		for (int i = 0; i < dimension; i++) 
		{
			tmp1 = tmp1 + matrix[0,i] + "y" + i;
		}
		for (int i = 0; i < dimension; i++) 
		{
			tmp2 = tmp2 + (matrix[1,i] >= 0 ? "+" : "") + matrix[1,i] + "y" + i;
		}
		if (dimension == 3) 
		{
			for (int i = 0; i < dimension; i++) 
			{
				tmp3 = tmp3 + (matrix[2,i] >= 0 ? "+" : "") + matrix[2,i] + "y" + i;
			}
		}

		lxy = lxy + "(" + tmp1 + ")x1 + (" + tmp2 + ")x2" + (dimension == 3 ? " + (" + tmp3 + ")x3" : "");
		func = func + "max{" + tmp1 + ", " + tmp2 + (dimension == 3 ? ", " + tmp3 : "") + "}";
		string sysEq = tmp1 + " = " + tmp2 + (dimension == 3 ? " = " + tmp3 : "");

		tmp1 = "g1(y) = " + tmp1;
		tmp2 = "g2(y) = " + tmp2;
		if(dimension == 3)
			tmp3 = "g3(y) = " + tmp3;

		//title
		//lxy
		//tmp 1-3
		//func
		//sysEq
		// SOLUTION OF SYSTEM OF EQUATIONS
		txts [0].text += " P2:";
		txts [1].text = lxy;
		txts [2].text = tmp1;
		txts [3].text = tmp2;
		txts [4].text = dimension == 3 ? tmp3 : "";
		txts [5].text = func;
		txts [6].text = sysEq;
		txts [7].text = "y0 = \ny1 = " + (dimension == 3 ? "\ny2 = " : "");

	}

	string Lxy(int[,] matrix)
	{
		string tmp = "L(x,y) = ";

		for (int i = 0; i < dimension; i++) 
		{
			for (int j = 0; j < dimension; j++) 
			{
				tmp = tmp + (matrix [i, j] >= 0 ? "+" : "" + matrix [i, j]) + "x" + i + "y" + j + " ";
			}
		}

		return tmp;
	}
}
