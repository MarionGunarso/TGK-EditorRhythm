using UnityEngine;
using System.Collections;

public class MoveSample : MonoBehaviour
{	
	public float time;
	private GameObject target;
	void Awake()
	{

	}
	void Start(){


		//iTween.MoveTo(gameObject, target.transform.position,5);
		//iTween.MoveBy(gameObject, iTween.Hash("x", 2, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", 0,"time", 0.5));
	}

	void OnEnable()
	{
		if(gameObject.tag=="blueNote")
		{
			
			target = GameObject.FindGameObjectWithTag("blueButton");
			Debug.Log("blue");
		}
		else if(gameObject.tag=="greenNote")
		{
			target = GameObject.FindGameObjectWithTag("greenButton");
			Debug.Log("green");
		}
		else if(gameObject.tag=="redNote")
		{
			target = GameObject.FindGameObjectWithTag("redButton");
			Debug.Log("red");
		}
		else if(gameObject.tag=="yellowNote")
		{
			target = GameObject.FindGameObjectWithTag("yellowButton");
			Debug.Log("yellow");
		}
		if(target==null)
			Debug.Log("null");
		else
		{
			iTween.MoveTo(gameObject,iTween.Hash("position", new Vector3(target.transform.position.x,target.transform.position.y,this.transform.position.z), "easetype", "linear" ,"time",time));
		}




	}
}

