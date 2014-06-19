using UnityEngine;
using System.Collections;

public class ViewSongScript : MonoBehaviour {


	public ButtonScript buttonScript;
	// Use this for initialization
	string [] listName;

	void OnEnable () {
		listName = buttonScript.title.arrayName;
		for(int i=0 ; i<listName.Length ; i++)
		{

		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
