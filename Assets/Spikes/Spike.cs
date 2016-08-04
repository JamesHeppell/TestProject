using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Spike : MonoBehaviour {

	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager>();
	}


	void OnTriggerEnter(Collider collider){
		Debug.Log(collider + " hit the spike");
		if (collider.tag == "Player"){
			Destroy (collider);
			levelManager.RestartLevel();
		}
	}
}
