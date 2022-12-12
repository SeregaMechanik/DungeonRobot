using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
	public GameObject thePlatform;
	public Transform generationPoint;

	public float distanceBetween;
	public float distanceBetweenMin;
	public float distanceBetweenMax;

	public ObjectPooler[] Obstacles;

	private int ObstacleSelector;

    // Start is called before the first frame update
    void Start()
    {

	}

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < generationPoint.position.x)
		{
			Instantiate(thePlatform, new Vector3(transform.position.x + 20,
				transform.position.y + 4.55f, transform.position.z), Quaternion.identity);

			distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

			ObstacleSelector = Random.Range(0, Obstacles.Length);

			transform.position = new Vector3(transform.position.x + distanceBetween,
				transform.position.y, transform.position.z);

			GameObject newObstacle = Obstacles[ObstacleSelector].GetPooledObject();

			newObstacle.transform.position = new Vector3(transform.position.x,
				transform.position.y + 5.8f, transform.position.z);
			newObstacle.transform.rotation = transform.rotation;
			newObstacle.SetActive(true);

			transform.position = new Vector3(transform.position.x,
				transform.position.y, transform.position.z);
		}
    }
}
