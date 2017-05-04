using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatrixGridLayout : MonoBehaviour {
	public GameObject panel;
	public GameObject cellPrefab;

	private List<GameObject> cellList = new List<GameObject> ();
	private GridLayoutGroupMod grid;
	private Animator anim;
	private int dim;

	private bool allNums = false;

	// Use this for initialization
	void Start () {
		dim = panel.GetComponent<MatrixHandler> ().dimension;
		grid = GetComponent<GridLayoutGroupMod> ();
		anim = panel.GetComponent<Animator>();
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

		//create each cell, but why are they all rotated 45degrees?
		for (int i = 0; i < dim; i++) 
		{
			for (int j = 0; j < dim; j++) 
			{
				GameObject go = Instantiate (cellPrefab, transform);
				go.name = "a" + i + j;
				go.GetComponent<InputField> ().placeholder.GetComponent<Text> ().text = go.name;
				cellList.Add (go);
			}
		}	
	}
		
	// Update is called once per frame
	void Update () 
	{
		
	}

	/*public void OptimalP1()
	{
		panel.GetComponent<MatrixHandler> ().OptimalP1 (GetMatrix ());
		if (allNums)
			anim.SetTrigger ("NextScreen");
	}

	public void OptimalP2()
	{
		panel.GetComponent<MatrixHandler> ().OptimalP2 (GetMatrix ());
		if (allNums) 
			anim.SetTrigger ("NextScreen");
	}*/
	public void Optimal(bool isP1)
	{
		MatrixHandler mh = panel.GetComponent<MatrixHandler> ();
		if(isP1)
			mh.OptimalP1 (GetMatrix ());
		else
			mh.OptimalP2 (GetMatrix ());
		if (allNums)
			anim.SetTrigger ("NextScreen");
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
				int result;
				int.TryParse(tmp [cnt].text, out result);
				if (result != 0) 
				{
					allNums = true;
					cells [i, j] = result;
				}
				cnt++;
			}
		}
		return cells;
	}
}

