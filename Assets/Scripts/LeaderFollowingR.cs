using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LeaderFollowingR : VehicleR {

	//Followers
	public float arriveWt = 20.0f;
	public float arriveDist = 20.0f;
	public float fleeFrontWt = 20.0f;
	public float separationWt = 30.0f;
	public float separationDist = 15.0f;
	public float disFromL = 15.0f;
	public float avoidWt = 40.0f;
	public float avoidDist = 20.0f;
	public float runDist = 50.0f;
	public float evadeWt = 30.0f;

	public GameObject leader;
	public GameObject monstar;

	private GameObject[] obstacles;
	private GameObject[] followers;



	override public void Start ()
	{
	// Use this for initialization
		base.Start ();
		//get component references
		obstacles = GameObject.FindGameObjectsWithTag ("Obstacle");
		followers = GameObject.FindGameObjectsWithTag ("Follower");
		
	}
	
	protected override void CalcSteeringForce ()
	{
		Vector3 force = Vector3.zero;
		Vector3 vecToMonstar = transform.position - monstar.transform.position;
		if (vecToMonstar.magnitude < runDist) {
			force += evadeWt * Flee (monstar.transform.position);
		}
		else {
			force += arriveWt * ArriveBehind ();
			force += fleeFrontWt * FleeFront ();
			force += separationWt * Separation (followers, separationDist);
		}
		
		for (int i=0; i<obstacles.Length; i++) {	
			force += avoidWt * AvoidObstacle (obstacles [i], avoidDist);
		}
		
		force = Vector3.ClampMagnitude (force, maxForce);
		ApplyForce(force);
	}
	
	protected Vector3 ArriveBehind()
	{
		Vector3 posBehd = leader.transform.position - (disFromL * transform.forward);
		return Arrive (posBehd, arriveDist);
	}
	
	protected Vector3 FleeFront()
	{
		Vector3 posFront = leader.transform.position + (disFromL * transform.forward);
		return Flee (posFront);
	}
}