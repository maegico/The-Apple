using UnityEngine;
using System.Collections;

public class MonstarBehavior : VehicleR {

	public float wanderWt = 20.0f;
	public float contDist = 550.0f;
	public float radMonstar = 35.0f;
	public float contWt = 40.0f;
	public float avoidWt = 40.0f;
	public float avoidDist = 20.0f;
	public float attackRad = 50.0f;
	public float attackWt = 30.0f;
	
	private GameObject[] obstacles;
	public GameObject objectContainment;
	public GameObject leader;


	// Use this for initialization
	override public void Start () {
		base.Start ();

		obstacles = GameObject.FindGameObjectsWithTag ("Obstacle");
	}
	
	// Update is called once per frame
	protected override void CalcSteeringForce ()
	{
		Vector3 force = Vector3.zero;
		Vector3 vecToLeader = transform.position - leader.transform.position;

		if (vecToLeader.magnitude < attackRad) {
			force += attackWt * Seek (leader.transform.position);
		}
		else {

			force += wanderWt * Seek (Wander ());
			force += contWt * Containment (objectContainment.transform.position, contDist + radMonstar);
		}

		for (int i=0; i<obstacles.Length; i++) {	
			force += avoidWt * AvoidObstacle (obstacles [i], avoidDist);
		}
		
		force = Vector3.ClampMagnitude (force, maxForce);
		ApplyForce(force);
	}
}
