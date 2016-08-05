using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectLevelController : MonoBehaviour {

	private const int MaxNumberOfLevels = 10;
	public GameObject[] levelbutton;

	private bool[] levelUnlocked = new bool[MaxNumberOfLevels];
	private int numScenesBeforeLevel1 = 4;
	private int numScenesAfterLastLevel =1;
	private int numGameLevels;

	// Use this for initialization
	void Start () {
		numGameLevels= SceneManager.sceneCountInBuildSettings - numScenesAfterLastLevel - numScenesBeforeLevel1;

	}
	
	// Update is called once per frame
	void Update () {
		LockAndUnlockAvailableLevels();

	}

	private void LockAndUnlockAvailableLevels(){
		for (int i=0; i <numGameLevels; i++){
			levelUnlocked[i] = PlayerPrefsManager.IsLevelUnocked(i + numScenesBeforeLevel1);
			if (!levelUnlocked[i]){
				Image currentButtonImage = levelbutton[i].GetComponent<Image>();
				Color currentAlpha = Color.white;
				currentAlpha.a = 30f;
				currentButtonImage.color = currentAlpha;
				Button currentButton = levelbutton[i].GetComponent<Button>();
				currentButton.interactable = false;
			} else{
				Image currentButtonImage = levelbutton[i].GetComponent<Image>();
				Color currentAlpha = Color.white;
				currentAlpha.a = 1;
				currentButtonImage.color = currentAlpha;
				Button currentButton = levelbutton[i].GetComponent<Button>();
				currentButton.interactable = true;
			}
		}
	}


	public void ResetScoreAndLockLevels(){
		ResetScores();
		LockLevels();
	}

	private void ResetScores(){
		for (int i=1; i <= numGameLevels; i++){
			PlayerPrefsManager.SetLevelScoreMax(i,0);
			PlayerPrefsManager.SetLevelScore(i,0);
		}
	}

	private void LockLevels(){
		for (int i=1; i <numGameLevels; i++){
			Debug.Log("level " + i +numScenesBeforeLevel1 );
			PlayerPrefsManager.LockLevel(i+numScenesBeforeLevel1);
		}
	}


}
