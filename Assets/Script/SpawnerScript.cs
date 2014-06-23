using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SpawnerScript : MonoBehaviour {

	// Use this for initialization
	public GameObject getList;
	public ButtonScript buttonScript;
	public NoteScript noteScript;
	public PlayModeScript playModeScript;
	//script to get time travel
	public MoveSample moveSample;

	public Vector3 defaultBlue;
	public Vector3 defaultGreen;
	public Vector3 defaultRed;
	public Vector3 defaultYellow;

	//determine if last note already spawned
	public bool finished;
	
	//to get all object in pool
	private Transform pool;
	
	//to get each note in pool
	private List<Transform> listNote = new List<Transform>();
	private Transform[] arrayNote;
	
	
	private AudioSource audio;
	
	private float travelTime;
	
	//indicate curr data in list
	int indexCurrDataList=0;
	
	void Awake()
	{
		audio = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioSource>();
		pool = GameObject.FindGameObjectWithTag("objectPool").transform;
		
		//add to list of note in pool
		foreach(Transform child in pool)
		{
			//Debug.Log(child.name);
			listNote.Add(child);
			
		}
		//change to array
		arrayNote = listNote.ToArray();
	}
	void Start () {
		
		
		//get the dataNote in buttonScript
		buttonScript = getList.GetComponent<ButtonScript>();
		
		
		
		
		
		travelTime = moveSample.time;
		
		//calculate timeSpawn
		//timeSpawn = buttonScript.buttonPressedArray[indexCurrDataList].time-travelTime;
		
	}
	
	void OnEnable()
	{
		finished=false;
		Debug.Log("Spawn Active");
		if(buttonScript.song!=null)
		{
			
			/*for(int i=0 ; i<buttonScript.song.a.Length ; i++)
			{
				Debug.Log("BUTTON = "+buttonScript.song.a[i].button);
				//Debug.Log(buttonScript.buttonPressedArray[i].sample);
				Debug.Log("TIME REAL = "+buttonScript.song.a[i].timeReal);
				Debug.Log ("TIME PRECISE = "+buttonScript.song.a[i].timePrecise);
				Debug.Log("TIME SAMPLE PRECISE = "+buttonScript.song.a[i].sampleTimePrecise);
				Debug.Log("TIME SPAWN = "+buttonScript.song.a[i].timeSpawn);
				Debug.Log("TIME SAMPLE SPAWN = "+buttonScript.song.a[i].sample);
			}*/
		}
		StartCoroutine(SpawnCoroutine());
		
	}
	
	void OnDisable()
	{

		playModeScript.isPlaying = false;
		playModeScript.canStop = true;
		/*//pool All Object that's active
		if(listNote!=null)
		{
			//Debug.Log ("NOTNULL");
			foreach(Transform note in listNote)
			{
				if(note!=null)
				{
					//Debug.Log("note");
					if(note.gameObject.activeSelf==true)
					{
						Debug.Log("if");
						note.GetComponent<NoteScript>().Pool();
						//ObjectPoolScript.instance.PoolObject(note.gameObject);
						Debug.Log("POOL ALL OBJECT");
						//note.transform.position = noteScript.defaultPos;
						//reset curr data indicator
						indexCurrDataList=0;

					}
				}
				
			}
		}
		//StopCoroutine(SpawnCoroutine());*/
		
	}
	
	
	
	IEnumerator SpawnCoroutine()
	{
		//kalau ada data notenya
		if(buttonScript.buttonPressedArray!=null)
		{
			
			
			/*	//kalau note yg disimpen cuma 1
			if(buttonScript.buttonPressedArray.Length==1)
			{
				//tunggu sampai timingny sama
				while(audio.timeSamples<buttonScript.buttonPressedArray[0].sample)
				{
					yield return new WaitForSeconds(0);
				}
				//kalau blue note
				if(buttonScript.buttonPressedArray[0].button==1)
				{
					Debug.Log("masuk");
					ObjectPoolScript.instance.GetObjectForType("Blue Note",true);
					
				}
				//kalau green note
				else if(buttonScript.buttonPressedArray[0].button==2)
				{
					Debug.Log("masuk");
					ObjectPoolScript.instance.GetObjectForType("Green Note",true);
					

				}
				//kalau red note
				else if(buttonScript.buttonPressedArray[0].button==3)
				{
					Debug.Log("masuk");
					ObjectPoolScript.instance.GetObjectForType("Red Note",true);

				}
				//kalau yellow note
				else if(buttonScript.buttonPressedArray[0].button==4)
				{
					Debug.Log("masuk");
					ObjectPoolScript.instance.GetObjectForType("Yellow Note",true);

				}
			}
*/
			//kalau note yg disimpen ada
			if(buttonScript.song.a.Length>=1)
			{
				//looping semua datany
				for(int i=0 ; i<buttonScript.song.a.Length ; i++)
				{
					//kalau play biasa
					if(playModeScript.finishing==false)
					{
						Debug.Log("PLAY BIASA");
						//tunggu sampai timingny pas
						while(audio.timeSamples<buttonScript.song.a[i].sample)
						{
							yield return new WaitForSeconds(0);
						}
					}
					//kalau di stop, maka dislesein sampe akhir
					else
					{
						Debug.Log("STOP");
					}
					if(buttonScript.song.a[i].button==1)
					{
						Debug.Log("masukBiru");
						ObjectPoolScript.instance.GetObjectForType("Blue Note",true).transform.position = defaultBlue ;
						
					}
					else if(buttonScript.song.a[i].button==2)
					{
						Debug.Log("masukHijau");
						ObjectPoolScript.instance.GetObjectForType("Green Note",true).transform.position = defaultGreen;
						
						
					}
					else if(buttonScript.song.a[i].button==3)
					{
						Debug.Log("masukMerah");
						ObjectPoolScript.instance.GetObjectForType("Red Note",true).transform.position = defaultRed;
						
					}
					else if(buttonScript.song.a[i].button==4)
					{
						Debug.Log("masukKuning");
						ObjectPoolScript.instance.GetObjectForType("Yellow Note",true).transform.position = defaultYellow;
						
					}
					/*if(i==buttonScript.song.a.Length-1)
					{
						finished=true;
					}*/
				}
			}
			
		}
	}
	void Spawn()
	{
		
		//if the curr time in audio is the same as time that note is tapped in the list minus travel time
		//do
		//{
		//Debug.Log(buttonScript.buttonPressedArray[indexCurrDataList].time+" "+indexCurrDataList);
		
		//Debug.Log("timeSpawn = "+timeSpawn);
		if(audio.time == buttonScript.song.a[indexCurrDataList].timeSpawn )
		{
			
			if(buttonScript.song.a[indexCurrDataList].button==1)
			{
				Debug.Log("masuk");
				ObjectPoolScript.instance.GetObjectForType("Blue Note",true);
				
				if(indexCurrDataList<buttonScript.song.a.Length-1)
				{
					indexCurrDataList++;
				}
				
				
				
			}
			else if(buttonScript.song.a[indexCurrDataList].button==2)
			{
				Debug.Log("masuk");
				ObjectPoolScript.instance.GetObjectForType("Green Note",true);
				
				if(indexCurrDataList<buttonScript.song.a.Length-1)
				{
					indexCurrDataList++;
				}
				
			}
			else if(buttonScript.song.a[indexCurrDataList].button==3)
			{
				Debug.Log("masuk");
				ObjectPoolScript.instance.GetObjectForType("Red Note",true);
				
				if(indexCurrDataList<buttonScript.song.a.Length-1)
				{
					indexCurrDataList++;
				}
				
			}
			else if(buttonScript.song.a[indexCurrDataList].button==4)
			{
				Debug.Log("masuk");
				ObjectPoolScript.instance.GetObjectForType("Yellow Note",true);
				
				if(indexCurrDataList<buttonScript.song.a.Length-1)
				{
					indexCurrDataList++;
				}
				
			}
			
			
			
		}
		//}while(indexCurrDataList < buttonScript.buttonPressedArray.Length-1);
		
		
		
	}
	// Update is called once per frame
	void FixedUpdate () {
		//Debug.Log(audio.timeSamples);
		//Spawn();
	}
}
