using UnityEngine;
using System.Collections;
using System.Collections.Generic; //including some .NET for dynamic arrays called List in C#
public class Seeker : VehicleR
{
	//Leaders
	public float arriveWt = 20.0f;
	public float arriveDist = 20.0f;
	public float avoidWt = 40.0f;
	public float avoidDist = 20.0f;
	public float runDist = 50.0f;
	public float evadeWt = 30.0f;
	public float collideDist = 55.0f;

	public GameObject target;
	public GameObject monstar;
	private  GameObject[] obstacles;
	
	// a unique identification number assigned by the flock manager
	// for the purpose of using the distances array
	private int index = -1;
	public int Index {
		get { return index; }
		set { index = value; }
	}
	
	override public void Start ()
	{
		base.Start ();
		//get component references
		//target = GameObject.FindGameObjectWithTag ("Target");
		obstacles = GameObject.FindGameObjectsWithTag ("Obstacle");
	}

	// We clearly need lignment, Cohesion and Separation
	// for our Flockers, but you will nee to handle obstacle
	// avoidance and implement a strategy for keeping your
	// flock on stage - avoid the lemming effect
	protected override void CalcSteeringForce ()
	{
		Vector3 force = Vector3.zero;
		Vector3 vecToMonstar = transform.position - monstar.transform.position;

		if (vecToMonstar.magnitude < collideDist) {
			transform.position = new Vector3(2676.374f, 35.0f, 462.1876f);
		}

		if (vecToMonstar.magnitude < runDist) {
			force += evadeWt * Flee (monstar.transform.position);
		}
		else {
			force += arriveWt * Arrive (target.transform.position, arriveDist);
		}
		//force += gameManager.alignmentWt * Alignment ();
		//force += gameManager.cohesionWt * Cohesion ();
		//force += gameManager.separationWt * Separation (gameManager.Seekers, gameManager.separationDist);
		//force += gameManager.inBoundsWt * Containment(Vector3.zero,45);
		
		// handle obstacle avoidance and containment here
		for (int i=0; i<obstacles.Length; i++) {	
			force += avoidWt * AvoidObstacle (obstacles [i], avoidDist);
		}
		
		//limit force to maxForce and apply
		force = Vector3.ClampMagnitude (force, maxForce);
		ApplyForce(force);
	}
	
	/*private Vector3 ArriveApple(GameObject apple)
	{
		return Arrive (apple.transform.position, gameManager.arriveDist);
	}*/

	//This function depends on the flockManager updating the direction
	//of the flock every frame. It makes use of the AlignTo function
	//that has been added to the Vehicle class.
	/*private Vector3 Alignment ()
	{
		return AlignTo (gameManager.FlockDirection);
	}
	
	
	// This function depends on the flockManager updating the centroid
	// of the flock every frame.
	private Vector3 Cohesion ()
	{
		return Seek (gameManager.Centroid);
	}*/
	
	/*private Vector3 Containment(Vector3 centerTer, float rad)
	{
		if(Vector3.Distance(transform.position, centerTer) > rad)
		{
			return Seek (centerTer);
		}
		return Vector3.zero;
	}*/
}