using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuLeveScoreDisplay : MonoBehaviour {

	public int gameLevel;
	
	private Text levelScore;
	// Use this for initialization
	void Start () {
		levelScore = GetComponent<Text>();
		SetScore();
	}
	
	// Update is called once per frame
	void Update () {
		SetScore();
	}

	private void SetScore(){
		if (PlayerPrefsManager.GetLevelScoreMax(gameLevel)==0){
			levelScore.text = "?";
		}else {
			levelScore.text = PlayerPrefsManager.GetLevelScore(gameLevel).ToString() + " / " + PlayerPrefsManager.GetLevelScoreMax(gameLevel).ToString();
		}
	}
}
