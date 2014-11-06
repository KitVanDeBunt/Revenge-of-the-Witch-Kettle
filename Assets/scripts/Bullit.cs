using UnityEngine;
using System.Collections;

public class Bullit : MonoBehaviour {
	GameObject[] enemys;
	int enemyCount;
	float nearestDistence = 999999999999;
	GameObject nearestEnemy;
	// Use this for initialization
	void Start () {
		enemys = GameObject.FindGameObjectsWithTag("enemy");
		enemyCount = GameObject.FindGameObjectsWithTag("enemy").Length;
		Debug.Log(enemyCount);
		
		for(int enemy = 0; enemy < enemyCount; enemy++)
		{
			float curDistance = Vector3.Distance(enemys[enemy].transform.position,transform.position);
			if(curDistance<nearestDistence){
				nearestDistence = curDistance;
				nearestEnemy = enemys[enemy];
			}
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.LookAt(nearestEnemy.transform.position);
		rigidbody.AddRelativeForce(0, 0, 3000);
	}
	
	void OnCollisionEnter(Collision collision) {
		if(collision.collider.name=="Enemy"){
	        Destroy(gameObject);
		}
    }
}
