using UnityEngine;
using System.Collections;

public class FinishArea : MonoBehaviour {

	private GameManager gameManager;
	// Use this for initialization
	void Start () {
		gameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider){
		if (collider.tag == "Player"){
			gameManager.BallinFinishArea();
		}
	}
}
