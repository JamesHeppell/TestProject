using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevelAfter;

	void Start() {
		PlayerPrefsManager.UnlockLevel(4); //unlock first level (02a level1)
		if (autoLoadNextLevelAfter<=0){
			Debug.Log("Level auto load disabled, use a positive number in seconds");
		} else {
			Invoke ("LoadNextLevel",autoLoadNextLevelAfter);
		}
	}

	public void LoadLevel(string name) {
		Debug.Log ("Level load requested for: " +name);
		//Application.LoadLevel(name);
		SceneManager.LoadScene(name);
	}
	
	public void QuitRequest() {
		Debug.Log ("Quit requested");
		Application.Quit();
	}

	public void RestartLevel(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void LoadNextLevel(){
		//Application.LoadLevel(Application.loadedLevel +1);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


	}
	
}
