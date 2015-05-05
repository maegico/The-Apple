using UnityEngine;
using System.Collections;

public class AppleRespawn : MonoBehaviour {

	public GameObject leader;
	public GameObject respawnCenter;
	public Vector3 vecToLeader;
	Random rand;
	public float collideDist = 55.0f;
	public float respawnRad = 550.0f;
	// Use this for initialization
	void Start () {
		rand = new Random ();
	}
	
	// Update is called once per frame
	void Update () {
		vecToLeader = transform.position - leader.transform.position;

		if (vecToLeader.magnitude < collideDist) {
			float respawnX = Random.Range(respawnCenter.transform.position.x-respawnRad, respawnCenter.transform.position.x + respawnRad);
			float respawnZ = Random.Range(respawnCenter.transform.position.z-respawnRad, respawnCenter.transform.position.z + respawnRad);
			transform.position = new Vector3(respawnX, 42.13217f, respawnZ);
		}
	}
}
