using UnityEngine;
using System.Collections;  //including some .NET for dynamic arrays called List in C#
using System.Collections.Generic;
public class GameManager : MonoBehaviour
{
	// weight parameters are set in editor and used by all flockers 
	// if they are initialized here, the editor will override settings	 
	// weights used to arbitrate btweeen concurrent steering forces 
	//public float seekWt;
	//public float minSeekWt;




	//public float alignmentWt;

	//public float cohesionWt;
	//public float inBoundsWt;



	// these distances modify the respective steering behaviors
	public float avoidDist;
	public float separationDist;
	
	
	// set in editor to promote reusability.
	//public int numberOfSeekers;
	//public int numberOfObstacles;
	//public Object seekerPrefab;
	//public Object obstaclePrefab;
	
	//values used by all flockers that are recalculated on update
	//private Vector3 direction;
	//private Vector3 centroid;
	
	//accessors
	private static GameManager instance;
	public static GameManager Instance { get { return instance; } }
	
	/*public Vector3 FlockDirection {
		get { return direction; }
	}*/
	
	//public Vector3 Centroid { get { return centroid; } }
	//public GameObject centroidContainer;
	
	
	// list of flockers with accessor
	//private List<GameObject> seekers = new List<GameObject>();
	//public List<GameObject> Seekers {get{return seekers;}}
	
	// array of obstacles with accessor
	private  GameObject[] obstacles;
	public GameObject[] Obstacles {get{return obstacles;}}
	
	// this is a 2-dimensional array for distances between flockers
	// it is recalculated each frame on update
	//private float[,] distances;
	
	//construct our 2d array based on the value set in
	public void Start ()
	{
		instance = this;
		//construct our 2d array based on the value set in the editor
		/*distances = new float[numberOfSeekers, numberOfSeekers];
		//reference to Vehicle script component for each flocker
		Seeker seeker; // reference to flocker scripts
		
		obstacles = GameObject.FindGameObjectsWithTag ("Obstacle");
		
		for (int i = 0; i < numberOfSeekers; i++) {
			//Instantiate a flocker prefab, catch the reference, cast it to a GameObject
			//and add it to our list all in one line.
			Vector3 pos = new Vector3(Random.Range(-40, 40), 1.3f, Random.Range( -40, 40));
			
			seekers.Add ((GameObject)Instantiate (seekerPrefab, pos, Quaternion.identity));
			//grab a component reference
			seeker = seekers [i].GetComponent<Seeker> ();
			//set values in the Vehicle script
			seeker.Index = i;
		}
		
		for (int i = 0; i < numberOfObstacles; i++) {
			Vector3 pos = new Vector3(Random.Range(-40, 40), 1.3f, Random.Range( -40, 40));
			GameObject.Instantiate (obstaclePrefab, pos, Quaternion.identity);
		}
		centroidContainer.transform.position = new Vector3 (320, 30, 100);*/
		
	}
	public void Update( )
	{
		//calcCentroid( );//find average position of each flocker 
		//calcFlockDirection( );//find average "forward" for each flocker
		
		//position & orient the centoid container for the SmoothFollow camera script
		//centroidContainer.transform.position = centroid;
		//centroidContainer.transform.forward = direction;
		
		// This function which populates the 2-dimensional distance array, lets us 
		// calculate distance between each pair of flockers exactly once per frame
		//calcDistances( );
	}
	
	
	/*void calcDistances( )
	{
		float dist;


		for(int i = 0 ; i < numberOfSeekers; i++)
		{
			for( int j = i+1; j < numberOfSeekers; j++)
			{
				dist = Vector3.Distance(seekers[i].transform.position, seekers[j].transform.position);
				distances[i, j] = dist;
				distances[j, i] = dist;
			}
		}
	}
	
	public float getDistance(int i, int j)
	{
		return distances[i, j];
	}
	
	
	
	private void calcCentroid ()
	{
		//*******************************************************
		// calculate the current centroid of the flock
		// use transform.position - you need to write this!
		//*******************************************************
		
		centroid = new Vector3 (0, 0, 0);  //fix this!
		
		foreach (GameObject seeker in seekers) {
			centroid += seeker.transform.position;
		}
		
		centroid /= seekers.Count;
	}
	
	private void calcFlockDirection ()
	{
		//*******************************************************
		// calculate the average heading of the flock
		// use transform.forward - you need to write this!
		//*******************************************************
		
		direction = new Vector3 (0, 0, 1); //fix this!
		
		foreach (GameObject seeker in seekers) {
			direction += seeker.transform.forward;
		}
	}*/
}