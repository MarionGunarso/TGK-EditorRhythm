using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TimingScript : MonoBehaviour {

	// Use this for initialization
	public ButtonScript buttonScript;
	
	private List<int> timeBlue;
	private List<int> timeGreen;
	private List<int> timeRed;
	private List<int> timeYellow;
	
	//[HideInInspector]
	public int [] blue;
	//[HideInInspector]
	public int [] green;
	//[HideInInspector]
	public int [] red;
	//[HideInInspector]
	public int [] yellow;
	
	//to indicate curr note
	public int currBlue;
	public int currGreen;
	public int currRed;
	public int currYellow;
	
	void Awake () {
		timeBlue = new List<int>();
		timeGreen = new List<int>();
		timeRed = new List<int>();
		timeYellow = new List<int>();
	}
	
	void OnEnable()
	{
		timeBlue = new List<int>();
		timeGreen = new List<int>();
		timeRed = new List<int>();
		timeYellow = new List<int>();
		Array.Clear(blue,0,blue.Length);
		Array.Clear(green,0,green.Length);
		Array.Clear(red,0,red.Length);
		Array.Clear(yellow,0,yellow.Length);
		
		if(buttonScript.song==null)
		{
			Debug.Log("NULL DATA");
		}
		else
		{
			Debug.Log("NOT NULL");
		}
		
		
		currBlue = -1;
		currGreen = -1;
		currRed = -1;
		currYellow = -1;
		GetTime();
	}
	
	void GetTime()
	{
		
		
		for(int i=0 ; i<buttonScript.song.a.Length ; i++)
		{
			if(buttonScript.song.a[i].button==1)
			{
				timeBlue.Add(buttonScript.song.a[i].sampleTimePrecise);
			}
			else if(buttonScript.song.a[i].button==2)
			{
				timeGreen.Add(buttonScript.song.a[i].sampleTimePrecise);
			}
			else if(buttonScript.song.a[i].button==3)
			{
				timeRed.Add(buttonScript.song.a[i].sampleTimePrecise);
			}
			else if(buttonScript.song.a[i].button==4)
			{
				timeYellow.Add(buttonScript.song.a[i].sampleTimePrecise);
			}
		}
		blue = timeBlue.ToArray();
		green = timeGreen.ToArray();
		red = timeRed.ToArray();
		yellow = timeYellow.ToArray();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
