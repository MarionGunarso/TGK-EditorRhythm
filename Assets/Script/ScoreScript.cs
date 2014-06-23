using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	// Use this for initialization
	public TextMesh textMesh;
	
	public int score;
	
	private bool show;
	
	void Start () {
		
	}
	
	void OnEnable()
	{
		ResetScore();
		show = true;
	}
	
	void OnDisable()
	{
		show = false;
	}
	public void AddScore(int a)
	{
		score+=a;
		
	}
	
	public void ShowScore()
	{
		textMesh.text=score.ToString();
	}
	
	public void ResetScore()
	{
		score = 0;
	}
	// Update is called once per frame
	void Update () {
		if(show==true)
		{
			ShowScore();
		}
		
	}
}
