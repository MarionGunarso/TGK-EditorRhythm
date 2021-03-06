﻿using UnityEngine;
using System.Collections;
using System;

public class PlayModeScript : MonoBehaviour {

	// Use this for initialization
	public ButtonScript buttonScript;
	public ModeScript modeScript;
	public AudioSource audioSource;
	public SpawnerScript spawnerScript;
	
	public bool isPlaying;
	public bool finishing;

	//stop button only once

	public bool canStop;

	private string [] listTitle;
	
	void Awake () {
		canStop = true;
		finishing = false;
		isPlaying = false;
		
	}
	
	//after enable, get the list of songtitle 
	void OnEnable()
	{
		isPlaying = false;
		finishing = false;

		audioSource.Stop();
		//buttonScript.LoadListSong();
		Debug.Log("Enable PlayMode");
		
		//Array.Clear(listTitle,0,listTitle.Length);
		listTitle = buttonScript.title.arrayName;
		
		if(listTitle == null)
		{
			Debug.Log("listTItle null");
		}
		else
		{
			Debug.Log("success to get listTitle");
			for(int i = 0 ; i<listTitle.Length ; i++)
			{
				Debug.Log(listTitle[i]);
			}
		}
		
		
		
		
	}
	
	int a = 140;
	void OnGUI()
	{
		if(modeScript.editorMode==false)
		{
			a = 60;
			if(isPlaying==true)
			{

				if(GUI.Button ( new Rect(10,60,100,30), "Stop"))
				{
					if(canStop==true)
					{
						audioSource.Stop();
						//if(spawnerScript.finished==true)
						//{
						buttonScript.Activate(false);
						//}
						canStop = false;
					}

					
				}
				
			}
			else if(isPlaying==false)
			{
				for(int i=0 ; i<listTitle.Length ; i++)
				{
					
					if(GUI.Button (new Rect(10,a,100,30),listTitle[i]))
					{
						//load the note data and play sound
						buttonScript.Load(listTitle[i]);
						
					}
					a+=40;
				}
			}
			
		}
		
		
	}
	// Update is called once per frame
	void Update () {
		//Debug.Log(isPlaying);
	}
}
