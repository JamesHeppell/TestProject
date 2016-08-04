using UnityEngine;
using System.Collections;

public class MovingPlatformUpDown : MonoBehaviour {

	public float speed;
	public float endYPosition;

	private Vector3 startPosition;
	private Vector3 platformPosition;
	private bool movingUpwards = true;
	// Use this for initialization
	void Start () {
		startPosition = this.transform.position;
		platformPosition = startPosition;

		if (startPosition.y > endYPosition){
			movingUpwards = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		float newy = Time.deltaTime * speed;
		if(movingUpwards){ 
			platformPosition.y += newy;
			this.transform.position = new Vector3 (startPosition.x,platformPosition.y,startPosition.z);
			if (platformPosition.y>= Mathf.Max(endYPosition,startPosition.y)){
				movingUpwards=!movingUpwards;

			}
		}else{ 
			platformPosition.y -= newy;
			this.transform.position = new Vector3 (startPosition.x,platformPosition.y,startPosition.z);
			if (platformPosition.y<=Mathf.Min(startPosition.y,endYPosition)){
				movingUpwards=!movingUpwards;
			}
		}

	}
}
