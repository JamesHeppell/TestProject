﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectLevelController : MonoBehaviour {

	private const int MaxNumberOfLevels = 10;
	public GameObject[] levelbutton;
	private bool[] levelUnlocked = new bool[MaxNumberOfLevels];

	private int numScenesBeforeLevel1 = 4;
	private int numScenesAfterLastLevel =1;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		for (int i=0; i <SceneManager.sceneCountInBuildSettings - numScenesBeforeLevel1 -numScenesAfterLastLevel; i++){
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

	public void LockLevels(){
		for (int i=1; i <SceneManager.sceneCountInBuildSettings - numScenesBeforeLevel1 -numScenesAfterLastLevel; i++){
			Debug.Log("level " + i +numScenesBeforeLevel1 );
			PlayerPrefsManager.LockLevel(i+numScenesBeforeLevel1);
		}
	}
}
