using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
  public static bool GameIsPaused = false;
	public GameObject PauseMenuUI;

	// Update is called once per frame
	void Update() {
		if(Input.GetKeyDown(KeyCode.Escape)){
			if(GameIsPaused){
				Resume();	
			} else {
				Pause();
			}
		}
	}

	public void Pause(){
		PauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}

	public void Resume(){
		PauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}

	public void Quit(){
		UnityEditor.EditorApplication.isPlaying = false;
		Application.Quit();
	}

	public void Menu(){
		Time.timeScale = 1f;
		GameIsPaused = false;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}
}
