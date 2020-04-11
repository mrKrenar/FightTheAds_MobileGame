using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class gamePauserScript : MonoBehaviour {

	public Canvas pauseMenu;
	public Canvas pauseButtonCanvas;
	public Button pauseButton;
	public Button resumeButton;
	public Button stopButton;

	// Use this for initialization
	void Start () 
	{
		pauseMenu = pauseMenu.GetComponent<Canvas> ();
		pauseButtonCanvas = pauseButtonCanvas.GetComponent<Canvas> ();
		pauseButton = pauseButton.GetComponent<Button> ();
		resumeButton = resumeButton.GetComponent<Button> ();
		stopButton = stopButton.GetComponent<Button> ();
		pauseButtonCanvas.enabled = true;
		pauseMenu.enabled = false;
//		pauseButton.enabled = true;
	
	}
	
	public void PausePress()

	{
		pauseMenu.enabled = true;
		pauseButtonCanvas.enabled = false;
		pauseButton.enabled = false;
		resumeButton.enabled = true;
		stopButton.enabled = true;
		Time.timeScale = 0.0f;
	}

	public void ResumePress()
	{
		pauseMenu.enabled = false;
		pauseButtonCanvas.enabled = true;
		pauseButton.enabled = true;
		resumeButton.enabled = false;
		stopButton.enabled = false;
		Time.timeScale = 1.0f;
	}

	public void StopPress()

	{
		SceneManager.LoadScene (0);
	}
}
