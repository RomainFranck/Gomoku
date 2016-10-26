using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayOverColor : MonoBehaviour {

	// Use this for initialization
	RectTransform coll;


	float W;
	float H;

	void Start () {

		//col = GetComponent<Image> ();
		coll = GetComponent<RectTransform> ();

		W = GetComponent<RectTransform> ().rect.width;
		H = GetComponent<RectTransform> ().rect.height;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Over()
	{
		for (float i = 0; i < 50; i++) 
		{
			//Vector2 temp = new Vector2(coll.rect.size.x, coll.rect.size.y);
			//temp.x += 1f;
			coll.rect.Set(transform.position.x, transform.position.y, i, coll.rect.height);

			//coll.rect.size.x += 1f;
		}
		
		//for (float j = 50; j > 0; j--)
		//	coll.rect.size.x -= 1f;
	}

	public void NotOver()
	{
		//coll.rect.height = H;
		//coll.rect.width = W;
	}
}
