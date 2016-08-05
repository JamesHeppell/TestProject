using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class UpdateFinalScore : MonoBehaviour {

	private Text gameScore;

	private int numScenesBeforeLevel1 = 4;
	private int numScenesAfterLastLevel =1;
	private int numGameLevels;
	private int TotalScore=0;
	private int TotalStarsInAllLevels=0;
	// Use this for initialization
	void Start () {
		numGameLevels= SceneManager.sceneCountInBuildSettings - numScenesAfterLastLevel - numScenesBeforeLevel1;
		gameScore = GetComponent<Text>();

		for (int i=1; i <= numGameLevels; i++){
			TotalStarsInAllLevels += PlayerPrefsManager.GetLevelScoreMax(i);
			TotalScore += PlayerPrefsManager.GetLevelScore(i);
		}
		gameScore.text = TotalScore.ToString() + " / " + TotalStarsInAllLevels.ToString();
	}
	

}
