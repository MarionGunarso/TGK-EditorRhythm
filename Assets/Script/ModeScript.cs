using UnityEngine;
using System.Collections;

public class ModeScript : MonoBehaviour {

	public bool editorMode;
	public TextMesh textMesh;
	public PlayModeScript playModeScript;
	public ButtonScript buttonScript;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		/*if(Input.GetKeyDown("r"))
		{
			
			if(editorMode == true)
			{
				Debug.Log("Change Play");
				//change to playMode
				editorMode=false;
				buttonScript.changeToPlay();
			}
			else if(editorMode == false)
			{
				Debug.Log("Change Editor");
				
				//change to editorMode
				editorMode=true;
				buttonScript.changeToEditor();
				playModeScript.isPlaying = false;
			}
			
			
		}*/
		
		if(editorMode==true)
		{
			textMesh.text="Editor";
		}
		else
		{
			textMesh.text="Play";
		}
	}
}
