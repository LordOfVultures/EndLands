using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {

	//public GameObject[] thePlatforms;
	public Transform generationPoint;
	public float distanceBetweenMin;
	public float distanceBetweenMax;
	public ObjectPooling[] objectPools;
	public Transform maxHeightPoint;
	public float maxHeightChange;

	private float distanceBetween;
	private float[] platformWidths;
	private int platformSelector;
	private float minHeight, maxHeight;
	private float heightChange;


	// Use this for initialization
	void Start () {
		platformWidths = new float[objectPools.Length];
		for (int i = 0; i < objectPools.Length; i++) {
			platformWidths [i] = objectPools [i].pooledObject.GetComponent<BoxCollider2D>().size.x;
		}
		minHeight = transform.position.y;
		maxHeight = maxHeightPoint.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);
		if (transform.position.x < generationPoint.position.x) {
			platformSelector = Random.Range(0, objectPools.Length);
			heightChange = transform.position.y + Random.Range(-maxHeightChange, maxHeightChange);
			if (heightChange > maxHeight) {
				heightChange = maxHeight;
			} else if(heightChange < minHeight) {
				heightChange = minHeight;
			}
			transform.position = new Vector3 (transform.position.x + (platformWidths[platformSelector]/2) + distanceBetween, heightChange, transform.position.z);
			//Instantiate (thePlatforms[platformSelector], transform.position, transform.rotation);
			GameObject newPlatform = objectPools[platformSelector].GetPooledObject();
			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive (true);
			transform.position = new Vector3 (transform.position.x + (platformWidths[platformSelector]/2), transform.position.y, transform.position.z);
		}
	}
}
