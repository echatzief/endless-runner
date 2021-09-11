using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
  public static bool GameIsPaused = false;
	public GameObject PauseMenuUI;
	public GameObject Statistics;

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
		Statistics.SetActive(false);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}

	public void Resume(){
		PauseMenuUI.SetActive(false);
		Statistics.SetActive(true);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}

	public void Quit(){
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#endif
		Application.Quit();
	}

	public void Menu(){
		Time.timeScale = 1f;
		GameIsPaused = false;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}
}
