using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {

	private GameManager gameManager;

	void Start(){
		gameManager = FindObjectOfType<GameManager>();
	}

	void OnTriggerEnter(Collider collider){
		if (collider.tag == "Player"){
			Debug.Log("Start collected");
			gameManager.AddCollectedStar();
			Destroy(this.gameObject);
		}

	}
}
