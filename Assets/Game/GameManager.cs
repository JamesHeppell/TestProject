using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

	public Text levelScoreDisplay;
	public bool recording = true; // for recording replays

	private GameObject starParent;
	private RectTransform[] starRectTransforms;
	private int numberStars;
	private int starsCollected = 0;
	
	void Start () {
		starParent = GameObject.Find("Stars");
		starRectTransforms = starParent.GetComponentsInChildren<RectTransform>();
		numberStars = starRectTransforms.Length;
	} 
	
	public void AddCollectedStar(){
		starsCollected ++;
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
		levelScoreDisplay.text = starsCollected.ToString() + "/" + numberStars.ToString(); 
	}
}
