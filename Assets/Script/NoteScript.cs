using UnityEngine;
using System.Collections;

public class NoteScript : MonoBehaviour {

	// Use this for initialization
	public string key;

	public Animator anim;
	
	
	//determine timing of perfect and cool
	public int perfectTimeSample;
	public int coolTopTimeSample;
	
	//score to add
	public int tambahScore;
	
	public bool hasTapped;
	public bool canPooled;
	public bool canPooled2;
	public bool canTapped;
	
	public bool aP;
	public bool sP;
	public bool dP;
	public bool fP;
	
	private ObjectPoolScript objectPoolScript;
	public Vector3 defaultPos;
	
	AudioSource audioSource;
	TimingScript timingScript;
	ScoreScript scoreScript;
	ModeScript modeScript;
	
	void Awake()
	{
		//store spawning Pos
		defaultPos=this.transform.position;
		audioSource = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioSource>();
		timingScript = GameObject.FindGameObjectWithTag("timing").GetComponent<TimingScript>();
		scoreScript = GameObject.FindGameObjectWithTag("score").GetComponent<ScoreScript>();
		modeScript = GameObject.FindGameObjectWithTag("mode").GetComponent<ModeScript>();
	}
	
	void Start () {
		
		canPooled2 = true;
		canPooled = true;
		hasTapped = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		//if change mode, let buttonscript handle the pooling
		if(Input.GetKeyDown("r"))
		{
			canPooled2 = false;
		}


		//if note already in the position and hasn't tapped before
		if(canTapped==true)
		{
			if(hasTapped==false)
			{
				//if(aP==true)
				if(Input.GetKeyDown(key))
				{


					hasTapped = true;
					if(key=="a")
					{
						Debug.Log("currBlue = "+timingScript.currBlue);
						Debug.Log("timeSample = "+audioSource.audio.timeSamples);
						Debug.Log("timing = "+timingScript.blue[timingScript.currBlue]);
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
					else if(key=="s")
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
					else if(key=="d")
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
					else if(key=="f")
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
				}
			}
		}
		
		
	}
	
	void OnEnable()
	{
		//reset flaq
		canPooled2 = true;
		canPooled = true;
		canTapped = false;
		hasTapped = false;
	}
	public void Pool()
	{
		
		//before pooling, if note's still untapped
		if(hasTapped==false)
		{
			//reduceScore/stopCombo/gameOver
			
		}
		//if(canPooled2==true)
		//{
		ObjectPoolScript.instance.PoolObject(this.gameObject);
		Debug.Log("Pool");
		//}
		
		
		
		//back to top
		this.transform.position = defaultPos;
		
		
		
		
		//reset position
		
	}
	
	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		
		
		if(modeScript.editorMode==false)
		{
			if(otherCollider.gameObject.layer==9)
			{
				Debug.Log("TriggerEnter");
				//note can be tapped
				canTapped=true;
				
				if(key=="a")
				{
					timingScript.currBlue+=1;
				}
				else if(key=="s")
				{
					timingScript.currGreen+=1;
				}
				else if(key=="d")
				{
					timingScript.currRed+=1;
				}
				else if(key=="f")
				{
					timingScript.currYellow+=1;
				}
			}
		}
		
	}
	void OnTriggerStay2D(Collider2D otherCollider)
	{
		if(modeScript.editorMode==false)
		{
			if(otherCollider.gameObject.layer == 9)
			{
				
				
				//if position note and button is exact
				if(this.transform.position.x == otherCollider.gameObject.transform.position.x && this.transform.position.y == otherCollider.gameObject.transform.position.y )
				{
					
					//pool note only once
					if(canPooled==true)
					{
						Invoke("Pool",1.5f);
						canPooled = false;
					}
					
				}
				
				
				
			}
		}
		
	}
}
