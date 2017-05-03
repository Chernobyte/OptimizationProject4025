using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatrixGridLayout : MonoBehaviour {
	public GameObject panel;
	public GameObject cellPrefab;
	public Vector3 endMark = new Vector3 (0, 0, 0);
	public float speed = 1f;

	private Vector3 startMark;
	private List<GameObject> cellList = new List<GameObject> ();
	private GridLayoutGroupMod grid;
	private int dim;
	private float startTime;
	private float lerpLength;
	private float distCovered;
	private float lerpFrac = 0;
	private bool allNums = false;

	// Use this for initialization
	void Start () {
		startMark = Camera.main.transform.position;
		startTime = Time.time;
		lerpLength = Vector3.Distance (startMark, endMark);

		dim = panel.GetComponent<MatrixHandler> ().dimension;
		grid = GetComponent<GridLayoutGroupMod> ();
		grid.constraintCount = dim;

		//grid.spacing = new Vector2 (grid.cellSize.x, grid.cellSize.y);
		//sloppy quick fix (as if this isnt all sloppy...)
		//make more general later if you feel like it.
		if (dim == 2)
			grid.spacing = new Vector2 (50f, 40f);
		if (dim == 3) 
		{
			grid.spacing = new Vector2 (30f, 20f);
			grid.padding.left = 30;
			grid.padding.top = 30;
		}

		for (int i = 0; i < dim; i++) 
		{
			for (int j = 0; j < dim; j++) 
			{
				GameObject go = Instantiate (cellPrefab, transform);
				go.name = "a" + i + j;
				go.GetComponent<InputField> ().placeholder.GetComponent<Text> ().text = go.name;
				//go.transform.rotation.Set (0, 0, 0, 0);
				Debug.Log (go.name + " rotation: " + go.transform.rotation.ToString ());
				cellList.Add (go);
			}
		}	

		//cellList.Reverse ();
		//Debug.Log (cellList.ToString ());
		Debug.Log("why the hell are the cells rotated 45 degrees?");
		//cellList.ForEach (Debug.Log (GameObject.name + " rotation: " + GameObject.transform.rotation.ToString ()));
		foreach (GameObject o in cellList) 
		{
			Debug.Log (o.name + " rotation: " + o.transform.rotation.ToString ());
		}
	}
		
	// Update is called once per frame
	void Update () 
	{
		if (lerpFrac < 1) 
		{
			distCovered = (Time.time - startTime) * speed;
			lerpFrac = distCovered / lerpLength;
			Camera.main.transform.position = Vector3.Lerp (startMark, endMark, lerpFrac);
		}
	}

	public void OptimalP1()
	{
		panel.GetComponent<MatrixHandler> ().OptimalP1 (GetMatrix ());
		if (allNums) 
		{
			HandleAnim ();
		}
	}

	public void OptimalP2()
	{
		panel.GetComponent<MatrixHandler> ().OptimalP2 (GetMatrix ());
		if (allNums) 
		{
			HandleAnim ();
		}
	}

	int[,] GetMatrix()
	{
		InputField[] tmp = gameObject.GetComponentsInChildren<InputField> ();
		int[,] cells = new int[dim,dim];

		int cnt = 0;
		for (int i = 0; i < dim; i++) 
		{
			for (int j = 0; j < dim; j++) 
			{
				int result; //= 0;
				//cells [i,j] = int.TryParse(tmp [cnt].text, out int result);
				int.TryParse(tmp [cnt].text, out result);
				if (result != 0) 
				{
					allNums = true;
					cells [i, j] = result;
				}

				//notAllNums = bool.Parse (result.ToString ());
				cnt++;
			}
		}
			
		return cells;
	}

	void HandleAnim()
	{
		panel.GetComponent<Animator>().SetTrigger ("NextScreen");
	}
}

