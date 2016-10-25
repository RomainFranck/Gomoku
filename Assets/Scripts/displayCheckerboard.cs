using UnityEngine;
using System.Collections;

public class displayCheckerboard : MonoBehaviour {


	public class Checkerboard
	{
		public GameObject Grid;
		public GameObject Intersection;

		float posX;
		float posY;

		float sizeX;
		float sizeY;

		// Use this for initialization
		void Start () {

			sizeX = Grid.GetComponent<SpriteRenderer> ().bounds.size.x;
			sizeY = Grid.GetComponent<SpriteRenderer> ().bounds.size.y;

			Debug.Log ("sizeX : " + sizeX);
			Debug.Log ("sizeY : " + sizeY);

			posX = 1;

			for (int i = 0; i < 18; i++) 
			{
				posY = 1;
				for (int a = 0; a < 18; a++) 
				{
					Instantiate (Intersection, new Vector3 (posX + (sizeX / 2), posY + (sizeY / 2), -5), Quaternion.identity);
					posY += sizeY; 
				}
				posX += sizeX;
			}
		}
	}


	// Update is called once per frame
	void Update () {
	}
}
