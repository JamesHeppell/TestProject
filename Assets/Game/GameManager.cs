using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

	public bool recording = true; // for recording replays

	
	void Start () {
		PlayerPrefsManager.UnlockLevel(4); //unlock first level (02a level1)

	}
	

	void Update () {

//		//For recording replays
//		if (CrossPlatformInputManager.GetButton("Fire1")){
//			recording = false;
//		}else {
//			recording = true;
//		}
	}
}
