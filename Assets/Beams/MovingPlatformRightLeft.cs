using UnityEngine;
using System.Collections;

public class MovingPlatformRightLeft : MonoBehaviour {

	public float speed;
	public float endZPosition;

	private Vector3 startPosition;
	private Vector3 platformPosition;
	private bool movingRight = true;
	// Use this for initialization
	void Start () {
		startPosition = this.transform.position;
		platformPosition = startPosition;

		if (startPosition.z > endZPosition){
			movingRight = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		float newz = Time.deltaTime * speed;
		if(movingRight){ 
			platformPosition.z += newz;
			this.transform.position = new Vector3 (startPosition.x,startPosition.y,platformPosition.z);
			if (platformPosition.z>= Mathf.Max(endZPosition,startPosition.z)){
				movingRight=!movingRight;

			}
		}else{ 
			platformPosition.z -= newz;
			this.transform.position = new Vector3 (startPosition.x,startPosition.y,platformPosition.z);
			if (platformPosition.z<=Mathf.Min(startPosition.z,endZPosition)){
				movingRight=!movingRight;
			}
		}

	}
}

