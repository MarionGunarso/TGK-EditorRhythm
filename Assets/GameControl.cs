using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {

	public static GameControl control;

	public float health;
	public float experience;
	// Use this for initialization
	void Awake () {
		if(control == null)
		{
			DontDestroyOnLoad(gameObject);
			control = this;
		}
		else if(control != this)
		{
			Destroy(gameObject);
		}
	
	}

	void OnGUI()
	{
		GUI.Label(new Rect(10,10,100,30), "Health: "+ health);
		GUI.Label(new Rect(10,40,100,30), "Experience: "+ experience);
	}

	public void Save()
	{
		//create file
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

		PlayerData data = new PlayerData();
		data.health = health;
		data.expereince = experience;

		bf.Serialize(file, data);
		file.Close();
	}

	public void Load()
	{
		if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open (Application.persistentDataPath+ "/playerInfo.dat",FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize(file);
			file.Close();

			health= data.health;
			experience= data.expereince;
		}
	}

	[Serializable]
	class PlayerData
	{
		public float health;
		public float expereince;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
