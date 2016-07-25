using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public GameObject levelCompleteDisplay;
	public Text finalScore;
	public Text levelScoreDisplay;
	public bool recording = true; // for recording replays

	private LevelManager levelManager;
	private GameObject starParent;
	private RectTransform[] starRectTransforms;
	private int numberStarsInLevel;
	private int starsCollectedInLevel = 0;
	
	void Start () {
		levelManager = FindObjectOfType<LevelManager>();
		levelCompleteDisplay.SetActive(false);
		starParent = GameObject.Find("Stars");
		starRectTransforms = starParent.GetComponentsInChildren<RectTransform>();
		numberStarsInLevel = starRectTransforms.Length;
	} 
	
	public void AddCollectedStar(){
		starsCollectedInLevel ++;
	}

	public void BallinFinishArea(){
		if (starsCollectedInLevel >= 0){
			//display level complete sign
			//play win music
			//unlock next level
			//load level menu

			levelCompleteDisplay.SetActive(true);
			PlayerPrefsManager.UnlockLevel(SceneManager.GetActiveScene().buildIndex + 1);
			levelManager.Invoke("LoadNextLevel",2f);

		} 
	}


	void Update () {

	UpdateLevelScoreDisplay();
//		//For recording replays
//		if (CrossPlatformInputManager.GetButton("Fire1")){
//			recording = false;
//		}else {
//			recording = true;
//		}
	}

	private void UpdateLevelScoreDisplay(){
		levelScoreDisplay.text = starsCollectedInLevel.ToString() + "/" + numberStarsInLevel.ToString(); 
		finalScore.text = starsCollectedInLevel.ToString() + "/" + numberStarsInLevel.ToString(); 
	}
}
