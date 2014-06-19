using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {
	
	// Use this for initialization
	public GameObject button;
	public float time = 10;

	public Vector2 speed = new Vector2(1,0);
	public Vector2 direction = new Vector2 (1,10);
	private Vector2 movement;

	public float xDestroyMin;
	public float xDestroyMax;

	private float defaultSpeed;
	void Awake () {
		defaultSpeed = speed.x;
		//Debug.Log(defaultSpeed);
	}
	
	// Update is called once per frame

	//movement berdasarkan speed dan direction
	void Update () {

	

		movement = new Vector3 (speed.x * direction.x, speed.y * direction.y,0);


		
	}

	public void DefaultSpeed()
	{
		speed.x = defaultSpeed;
	}
	void FixedUpdate()
	{
		if(this.transform.position == button.transform.position)
		{
			Debug.Log(time);
		}
		time-=Time.deltaTime;
		transform.Translate(movement);
	}
}
