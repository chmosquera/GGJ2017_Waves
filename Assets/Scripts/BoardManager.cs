using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;
using System.Collections.Generic;

public class BoardManager : MonoBehaviour {

	public class Count
	{
		public int minimum;
		public int maximum;

		public Count (int min, int max) {
			minimum = min;
			maximum = max;
		}
	}

	[SerializeField] public int rows;
	[SerializeField] public int cols;


	// Background Layout
	private int innerTileCount;
	public GameObject[] innerTiles;
	public GameObject[] wallTilesUP;
	public GameObject[] wallTilesRIGHT;
	public GameObject[] wallTilesDOWN;
	public GameObject[] wallTilesLEFT;
	public GameObject[] cornerTiles; // in order - UL, UR, BR, BL

	private Transform boardHolder; // child all board objects to this, use it to clean everything at end
	private List <Vector3> gridPositions = new List<Vector3>();


	// Use this for initialization
	void Start () {
		innerTileCount = (rows - 2) * (cols - 2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void InitializeList() {
		// makes sure list is empty
		gridPositions.Clear ();

		// fill gridpositions with vectors;
		for (int x = 1; x < cols; x++) {
			for (int y = 1; y < rows; y++) {
				gridPositions.Add( new Vector3(x,y,0.0f));
			}
		}
	}

	void BoardSetup () {
		// assign boardholder to this board's transform
		boardHolder = new GameObject ("Board").transform; // creates a game object called "Board"

		for (int x = 0; x <= cols; x++) {
			for (int y = 0; y <= rows; y++) {
				GameObject randTile;

				// Check if at a corner
				if (x == 0 && y == rows) 			// Upper-Left Corner
					randTile = cornerTiles [0];
				else if (x == cols && y == rows) 	// Upper-Right Corner
					randTile = cornerTiles [1];
				else if (x == cols && y == 0) 		// Bottom-Right Corner
					randTile = cornerTiles [2];
				else if (x == 0 && y == 0) 			// Bottom-Left Corner
					randTile = cornerTiles [3];
				
				// Check if along the wall. Important to check AFTER finding the corners
				else if (y == rows) 											// Up Wall
					randTile = wallTilesUP [Random.Range (0, wallTilesUP.Length)];
				else if (x == cols) 											// Right Wall
					randTile = wallTilesRIGHT [Random.Range (0, wallTilesRIGHT.Length)];
				else if (y == 0) 												// Down Wall
					randTile = wallTilesDOWN [Random.Range (0, wallTilesDOWN.Length)];
				else if (x == 0) 												// Left Wall
					randTile = wallTilesLEFT [Random.Range (0, wallTilesLEFT.Length)];
				// Not corner or wall? randTile should be an innerTile
				else
					randTile = innerTiles[Random.Range (0, innerTiles.Length)];

				// Place the randTile on the current location
				GameObject tile = Instantiate(randTile, new Vector3(x,y,0f), Quaternion.identity, boardHolder) as GameObject;

			}
		}
	}


	public void SetupScene() {

		BoardSetup ();
	}
}
