using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	[Tooltip("Insert player object here")]
	public GameObject player;
	private Vector3 distPlayerToCamera;

	// Use this for initialization
	void Start () {
		distPlayerToCamera =  transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position + distPlayerToCamera;
	}
}
