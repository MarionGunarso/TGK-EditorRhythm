using UnityEngine;
using System.Collections;

public class ButtonPlayScript : MonoBehaviour {

	// Use this for initialization
	public int perfectTimeSample;
	public int coolTopTimeSample;
	//public int coolBotTimeSample;

	public string key;

	public int button;

	public int tambahScore;
	public ModeScript modeScript;
	public ButtonScript buttonScript;
	public TimingScript timingScript;
	public AudioSource audioSource;

	public ScoreScript scoreScript;
	//terima list Data note


	void Start () {
		//scoreScript = GameObject.FindGameObjectWithTag("score").GetComponent<ScoreScript>();
	}


	/*void OnMouseDown()
	{
		if(modeScript.editorMode==true)
		{
			if(key=="a")
			{
				buttonScript.aF=true;
			}
			else if(key=="s")
			{
				buttonScript.sF=true;
			}
			else if(key=="d")
			{
				buttonScript.dF=true;
			}
			else if(key=="f")
			{
				buttonScript.fF=true;
			}
		}
		else if(modeScript.editorMode==false)
		{

		}

	}

	void OnMouseUp()
	{
		if(key=="a")
		{
			
		}
		else if(key=="s")
		{
			
		}
		else if(key=="d")
		{
			
		}
		else if(key=="f")
		{
			
		}
	}
*/
	// Update is called once per frame
	void Update () {

		/*if(Input.GetKeyDown(key))
		{
			if(key=="a")
			{

			}
			else if(key=="s")
			{

			}
			else if(key=="d")
			{

			}
			else if(key=="f")
			{

			}
		}*/
		
	}

	/*void OnTriggerEnter2D(Collider2D otherCollider)
	{
		Debug.Log("TriggerEnter");

		if(modeScript.editorMode==false)
		{
			if(otherCollider.gameObject.layer==8)
			{
				if(otherCollider.gameObject.GetComponent<NoteScript>().key=="a")
				{
					timingScript.currBlue+=1;
				}
				else if(otherCollider.gameObject.GetComponent<NoteScript>().key=="s")
				{
					timingScript.currGreen+=1;
				}
				else if(otherCollider.gameObject.GetComponent<NoteScript>().key=="d")
				{
					timingScript.currRed+=1;
				}
				else if(otherCollider.gameObject.GetComponent<NoteScript>().key=="f")
				{
					timingScript.currYellow+=1;
				}
			}
		}

	}
*/


	/*void OnTriggerStay2D(Collider2D otherCollider)
	{
		if(modeScript.editorMode==false)
		{
			//Debug.Log("Editor");
			if(otherCollider.gameObject.layer==8)
			{
				//Debug.Log("Layer");
				//can only be tapped once
				if(otherCollider.gameObject.GetComponent<NoteScript>().hasTapped==false)
				{
					Debug.Log("Has Tapped");
					if(Input.GetKeyDown(KeyCode.A))
					{
						Debug.Log("KeyDown");
						//check the timing and determine the score based on that

						

						Debug.Log(audioSource.audio.timeSamples - timingScript.blue[timingScript.currBlue]);
						if(audioSource.audio.timeSamples - timingScript.blue[timingScript.currBlue]<=perfectTimeSample && audioSource.audio.timeSamples - timingScript.blue[timingScript.currBlue]>=-perfectTimeSample )
						{
							Debug.Log("Perfect");
							scoreScript.AddScore(tambahScore+2);
						}
						else if( (audioSource.audio.timeSamples - timingScript.blue[timingScript.currBlue]<=coolTopTimeSample && audioSource.audio.timeSamples - timingScript.blue[timingScript.currBlue]>perfectTimeSample) ||  (audioSource.audio.timeSamples - timingScript.blue[timingScript.currBlue]<-perfectTimeSample && audioSource.audio.timeSamples - timingScript.blue[timingScript.currBlue]>=-coolTopTimeSample) )
						{
							Debug.Log("Cool");
							scoreScript.AddScore(tambahScore);
						}
						
					}
					else if(Input.GetKeyDown(KeyCode.S))
					{

						Debug.Log(audioSource.audio.timeSamples - timingScript.green[timingScript.currGreen]);
						if(audioSource.audio.timeSamples - timingScript.green[timingScript.currGreen]<=perfectTimeSample && audioSource.audio.timeSamples - timingScript.green[timingScript.currGreen]>=-perfectTimeSample)
						{
							Debug.Log("Perfect");
							scoreScript.AddScore(tambahScore+2);
						}
						else if( (audioSource.audio.timeSamples - timingScript.green[timingScript.currGreen]<=coolTopTimeSample && audioSource.audio.timeSamples - timingScript.green[timingScript.currGreen]>perfectTimeSample) ||  (audioSource.audio.timeSamples - timingScript.green[timingScript.currGreen]<-perfectTimeSample && audioSource.audio.timeSamples - timingScript.green[timingScript.currGreen]>=-coolTopTimeSample) )
						{
							Debug.Log("Cool");
							scoreScript.AddScore(tambahScore);
						}

					}
					else if(Input.GetKeyDown(KeyCode.D))
					{

						Debug.Log(audioSource.audio.timeSamples - timingScript.red[timingScript.currRed]);
						if(audioSource.audio.timeSamples - timingScript.red[timingScript.currRed]<=perfectTimeSample && audioSource.audio.timeSamples - timingScript.red[timingScript.currRed]>=-perfectTimeSample )
						{
							Debug.Log("Perfect");
							scoreScript.AddScore(tambahScore+2);
						}
						else if( (audioSource.audio.timeSamples - timingScript.red[timingScript.currRed]<=coolTopTimeSample && audioSource.audio.timeSamples - timingScript.red[timingScript.currRed]>perfectTimeSample) ||  (audioSource.audio.timeSamples - timingScript.red[timingScript.currRed]<-perfectTimeSample && audioSource.audio.timeSamples - timingScript.red[timingScript.currRed]>=-coolTopTimeSample) )
						{
							Debug.Log("Cool");
							scoreScript.AddScore(tambahScore);
						}

					}
					else if(Input.GetKeyDown(KeyCode.F))
					{

						Debug.Log(audioSource.audio.timeSamples - timingScript.yellow[timingScript.currYellow]);
						if(audioSource.audio.timeSamples - timingScript.yellow[timingScript.currYellow]<=perfectTimeSample && audioSource.audio.timeSamples - timingScript.yellow[timingScript.currYellow]>=-perfectTimeSample )
						{
							Debug.Log("Perfect");
							scoreScript.AddScore(tambahScore+2);
						}
						else if( (audioSource.audio.timeSamples - timingScript.yellow[timingScript.currYellow]<=coolTopTimeSample && audioSource.audio.timeSamples - timingScript.yellow[timingScript.currYellow]>perfectTimeSample) ||  (audioSource.audio.timeSamples - timingScript.yellow[timingScript.currYellow]<-perfectTimeSample && audioSource.audio.timeSamples - timingScript.yellow[timingScript.currYellow]>=-coolTopTimeSample) )
						{
							Debug.Log("Cool");
							scoreScript.AddScore(tambahScore);
						}

					}
						
					otherCollider.gameObject.GetComponent<NoteScript>().hasTapped=true;
					
				}




			}
		}

	}*/
}
