using UnityEngine;
using System.Collections;

public class ReplaySystem : MonoBehaviour {

	private GameManager gameManager;
	private const int bufferFrames = 100;
	private MyKeyFrame[] keyFrames = new MyKeyFrame [bufferFrames];


	private Rigidbody rigidBody;
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
		gameManager = GameObject.FindObjectOfType<GameManager>();
	}

	// Update is called once per frame
	void Update () {
		//Record ();
		if (gameManager.recording){
			Record ();
		}else {
			PlayBack();
		}
	}

	void PlayBack(){ //TODO solve problem when replay is less than bufferframes.
		rigidBody.isKinematic = true;
		int frame = Time.frameCount % bufferFrames;
		Debug.Log ("Reading frame " + frame);
		transform.position = keyFrames[frame].position;
		transform.rotation = keyFrames[frame].rotation;

	}

	void Record (){
		rigidBody.isKinematic = false;
		int frame = Time.frameCount % bufferFrames;
		float time = Time.time;
		Debug.Log ("Writing frame " + frame);
		keyFrames [frame] = new MyKeyFrame (time, transform.position, transform.rotation);
	}
}

/// <summary>
/// A struct for storing time, position and rotation
/// </summary>)
public struct MyKeyFrame {
	public float frameTime;
	public Vector3 position;
	public Quaternion rotation;

	public MyKeyFrame (float aTime, Vector3 aPos, Quaternion aRot ){
		frameTime = aTime;
		position = aPos;
		rotation = aRot;
	}
}
