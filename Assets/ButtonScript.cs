using UnityEngine;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ButtonScript : MonoBehaviour {

	public static ButtonScript control;

	public s spawner;
	public ModeScript modeScript;
	public GameObject [] activableObjects;

	public GameObject playMode;


	//script to get time travel
	public MoveSample moveSample;

	[Serializable]
	public class Rhythm
	{
		[SerializeField]
		public int button;
		[SerializeField]
		public float timeSpawn; //time tapped minus travel time
		[SerializeField]
		public float timeReal; //time tapped
		[SerializeField]
		public float timePrecise;//precise beat time
		[SerializeField]
		public int sampleTimePrecise;//convert timePrecise into timeSample
		[SerializeField]
		public int sample; //convert timeSpawn into timeSample
	}

	public List<Rhythm> buttonPressedList = new List<Rhythm>();
	public Rhythm[] buttonPressedArray;

	//bpm of the song
	public float bpm;

	//one beat in every interval
	private float timePerBeat;

	//timePerBeat divide by 16
	private float preciseTimePerBeat;

	private AudioSource audioSource;
	private AudioClip audioClip;

	private float travelTime;

	//class to store dataSong to save into file
	[Serializable]
	public class SongData
	{
		public string songName;
		public Rhythm[] a;
	}

	//song that will be played
	public SongData song;

	//class to store list of song
	[Serializable]
	public class NameData
	{

		public string [] arrayName;
	}

	public List<string> listName = new List<string>();
	public string [] arrName;

	public NameData title;


	public bool aF;
	public bool sF;
	public bool dF;
	public bool fF;

	// Use this for initialization
	void Awake () {
		Debug.Log(Application.persistentDataPath);
		timePerBeat = 60/bpm;
		preciseTimePerBeat = timePerBeat/16;

		control = this;
		//initialize the song that will be played
		song = new SongData();
		title = new NameData();


		//get all list of song stored
		LoadListSong();

		//get travel time
		travelTime = moveSample.time;

		if(modeScript.editorMode==true)
		{
			//disactive object in playmode
			foreach(GameObject activableObject in activableObjects)
			{
				activableObject.SetActive(false);
			}
		}
		else if(modeScript.editorMode==false)
		{
			//activate object in playmode
			playMode.SetActive(true);
		}


		//modeScript.editorMode=true;
		audioSource = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioSource>();

	}

	public void Save(string name)
	{
		Debug.Log("Save File");
		//if file already exist, replace it
		if(File.Exists(Application.persistentDataPath+"/"+name+".dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath +"/"+name+".dat",FileMode.Open);



			SongData data = new SongData();
			data.songName = name;
			data.a = buttonPressedList.ToArray();

			//save to file
			bf.Serialize(file, data);
			file.Close();
			Debug.Log("File Saved");

		}
		else
		{
			//create file
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Create(Application.persistentDataPath +"/"+name+".dat");

			SongData data = new SongData();
			data.songName = name;
			data.a = buttonPressedList.ToArray();
			bf.Serialize(file, data);
			file.Close();

			//check if file list song is exist then open and add name to it, if not create new nameData, add name and then create file
			if(File.Exists(Application.persistentDataPath+"/listSongs.dat"))
			{
				FileStream file1 = File.Open(Application.persistentDataPath +"/listSongs.dat",FileMode.Open);
				NameData nameData = new NameData();
				//nameData = (NameData)bf.Deserialize(file1);
				//nameData.name.Add(name);
				//listName.AddRange(nameData.arrayName);
				//listName = title.arrayName;
				for(int i=0 ; i<title.arrayName.Length ; i++)
				{
					listName.Add(title.arrayName[i]);
				}
				listName.Add(name);

				nameData.arrayName = listName.ToArray();
				for(int i = 0 ; i<nameData.arrayName.Length ; i++)
				{
					Debug.Log("In "+nameData.arrayName[i]);
				}		

				bf.Serialize(file1,nameData);
				file1.Close();
				Debug.Log("Song added");
			}
			else
			{
				FileStream file1 = File.Create(Application.persistentDataPath +"/listSongs.dat");
				NameData nameData = new NameData();
				//listName = title.arrayName;
				//for(int i=0 ; i<title.arrayName.Length ; i++)
				//{
					//listName.Add(title.arrayName[i]);
				//}
				//title = new NameData();
				//title.arrayName[0]=name;
				listName.Add (name);
				title.arrayName = listName.ToArray();
				nameData.arrayName = listName.ToArray();
				
				bf.Serialize(file1,nameData);
				file1.Close();
				Debug.Log("Song created n added");
			}
			Debug.Log("File Saved");
		}
	}

	public void LoadListSong()
	{
		//Debug.Log(File.Exists(Application.persistentDataPath));
		//Debug.Log(Application.persistentDataPath);
		//check if file list song is exist then open and add name to it, if not create new nameData, add name and then create file
		if(File.Exists(Application.persistentDataPath+"/listSongs.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file1 = File.Open(Application.persistentDataPath +"/listSongs.dat",FileMode.Open);
			if(file1 != null)
			{
				Debug.Log("NOT NULL");
				//if(title.arrayName!=null)
				//{
					//Array.Clear(title.arrayName,0,title.arrayName.Length);
				//}


				title = (NameData)bf.Deserialize(file1);
				Debug.Log("Out "+title.arrayName.Length);
				for(int i=0 ; i<title.arrayName.Length; i++)
				{
					Debug.Log("Out "+title.arrayName[i]);
				}
			}


			file1.Close();
			Debug.Log("List Song loaded");
		}
		else
		{
			/*BinaryFormatter bf = new BinaryFormatter();
			FileStream file1 = File.Create(Application.persistentDataPath +"/listSongs.dat");
			NameData nameData = new NameData();
			//listName = title.arrayName;
			for(int i=0 ; i<title.arrayName.Length ; i++)
			{
				listName.Add(title.arrayName[i]);
			}
			listName.Add (name);
			nameData.arrayName = listName.ToArray();
			
			bf.Serialize(file1,nameData);
			file1.Close();
			Debug.Log("Song created n added");*/
		}
	}

	//load song Data from file
	public void Load(string name)
	{
		Debug.Log("Load File");
		//Save(audioSource.clip.name);
		//LoadListSong();
		//activate playModeScript
		//playMode.SetActive(true);

		if(File.Exists(Application.persistentDataPath+"/"+name+".dat"))
		{
			//disactive object in playmode
			/*foreach(GameObject activableObject in activableObjects)
			{
				activableObject.SetActive(false);
			}*/

			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open (Application.persistentDataPath+"/"+name+".dat",FileMode.Open);
			song = new SongData();
			song = (SongData)bf.Deserialize(file);
			file.Close();

			//load song resources and assign it to audiosource component
			audioSource.Stop();
			audioClip = Resources.Load(name) as AudioClip;
			audioSource.clip = audioClip;
			audioSource.Play();
			Debug.Log("Song Loaded");

			//activate object in playMode
			foreach(GameObject activableObject in activableObjects)
			{
				activableObject.SetActive(true);
			}


		}
		playMode.GetComponent<PlayModeScript>().isPlaying=true;
	}

	void a()
	{
		foreach(GameObject activableObject in activableObjects)
		{
			//Debug.Log("activate: "+a);
			activableObject.SetActive(false);
		}
		playMode.GetComponent<PlayModeScript>().isPlaying=false;
		//playMode.SetActive(true);
	}

	public void Activate(bool a)
	{
		//Save(audioSource.clip.name);
		//LoadListSong();
		//activate object in playMode
		//Invoke ("a",2);

		foreach(GameObject activableObject in activableObjects)
		{
			//Debug.Log("activate: "+a);
			activableObject.SetActive(false);
		}
		playMode.GetComponent<PlayModeScript>().isPlaying=false;
		//playMode.SetActive(true);

	}

	//function that happen after changing mode
	public void changeToPlay()
	{
		//save the recorded into file
		Save(audioSource.clip.name);
		LoadListSong();
		//activate playModeScript
		playMode.SetActive(true);

		
		//listTitle = ButtonScript.control.title.name.ToArray();


		//buttonPressedArray = buttonPressedList.ToArray();
		//audioSource.Stop();
		//audioSource.Play();
		
		

	}

	public void changeToEditor()
	{
		//disactive object in playmode
		foreach(GameObject activableObject in activableObjects)
		{
			activableObject.SetActive(false);
		}
		//playMode disActive
		playMode.SetActive(false);

		//playsound, and clear list data rhythm
		buttonPressedList.Clear();
		Array.Clear(buttonPressedArray,0,buttonPressedArray.Length);
		
		audioSource.Stop();
		audioSource.Play();

	}
	// Update is called once per frame
	void Update () {

		//if it's in editor mode
		if(modeScript.editorMode==true)
		{

		
			if(Input.GetKeyDown("a"))
			//if(aF==true)
			{
				Debug.Log("a");
				
				Rhythm temp = new Rhythm();
				temp.button = 1;
				temp.timeReal = audioSource.time;

				//if the beat doesn't precise, make it precise
				if(temp.timeReal % preciseTimePerBeat!=0)
				{
					float b = temp.timeReal%preciseTimePerBeat;
					temp.timePrecise = temp.timeReal-b;
				}
				else
				{
					temp.timePrecise = temp.timeReal;
				}
				float a =temp.timePrecise*audioSource.clip.frequency;
				temp.sampleTimePrecise = (int)a;
				//calculate timeSpawn by minusing with travelTime
				temp.timeSpawn = temp.timePrecise-travelTime;

				//convert into sample
				a = temp.timeSpawn*audioSource.clip.frequency;
				temp.sample = (int)a;


				buttonPressedList.Add(temp);
				aF=false;
				
			}
			if(Input.GetKeyDown("s"))
			//if(sF==true)
			{
				Debug.Log("s");
				Rhythm temp = new Rhythm();
				temp.button = 2;
				//get the time in second
				temp.timeReal = audioSource.time;
				if(temp.timeReal % preciseTimePerBeat!=0)
				{
					float b = temp.timeReal%preciseTimePerBeat;
					temp.timePrecise = temp.timeReal-b;
				}
				else
				{
					temp.timePrecise = temp.timeReal;
				}
				float a =temp.timePrecise*audioSource.clip.frequency;
				temp.sampleTimePrecise = (int)a;
				temp.timeSpawn = temp.timePrecise-travelTime;
				//conver into sample
				a = temp.timeSpawn*audioSource.clip.frequency;
				temp.sample = (int)a;

				
				buttonPressedList.Add(temp);
				sF=false;
			}
			//if(dF==true)
			if(Input.GetKeyDown("d"))
			{
				Debug.Log("d");
				Rhythm temp = new Rhythm();
				temp.button = 3;
				temp.timeReal = audioSource.time;
				if(temp.timeReal % preciseTimePerBeat!=0)
				{
					float b = temp.timeReal%preciseTimePerBeat;
					temp.timePrecise = temp.timeReal-b;
				}
				else
				{
					temp.timePrecise = temp.timeReal;
				}
				float a =temp.timePrecise*audioSource.clip.frequency;
				temp.sampleTimePrecise = (int)a;
				temp.timeSpawn = temp.timePrecise-travelTime;
				a = temp.timeSpawn*audioSource.clip.frequency;
				temp.sample = (int)a;

				
				
				buttonPressedList.Add(temp);
				dF=false;
			}
			//if(fF==true)
			if(Input.GetKeyDown("f"))
			{
				Debug.Log("f");
				Rhythm temp = new Rhythm();
				temp.button = 4;
				temp.timeReal = audioSource.time;
				if(temp.timeReal % preciseTimePerBeat!=0)
				{
					float b = temp.timeReal%preciseTimePerBeat;
					temp.timePrecise = temp.timeReal-b;
				}
				else
				{
					temp.timePrecise = temp.timeReal;
				}
				float a =temp.timePrecise*audioSource.clip.frequency;
				temp.sampleTimePrecise = (int)a;
				temp.timeSpawn = temp.timePrecise-travelTime;
				a = temp.timeSpawn*audioSource.clip.frequency;
				temp.sample = (int)a;

				
				
				buttonPressedList.Add(temp);
				fF=false;
			}
			
			




		}

		//playMode
		else if(modeScript.editorMode==false)
		{

		}



	
	}
}
