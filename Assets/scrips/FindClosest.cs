using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindClosest : MonoBehaviour {

    public static FindClosest instance;
    public GameObject sp;
    public Vector3 posEnemy;
    void Update ()
    {
		FindClosestEnemy ();
	}

	void FindClosestEnemy()
	{
        
		float distanceToClosestEnemy = Mathf.Infinity;
		Enemy closestEnemy = null;
		Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();

		foreach (Enemy currentEnemy in allEnemies) {
			float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
			if (distanceToEnemy < distanceToClosestEnemy) {
				distanceToClosestEnemy = distanceToEnemy;
				closestEnemy = currentEnemy;
			}
		}
       
		Debug.DrawLine (this.transform.position, closestEnemy.transform.position);
        //Debug.Log(closestEnemy.gameObject.transform.position);
        sp.transform.position = closestEnemy.transform.position;
        posEnemy = closestEnemy.transform.position;
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

}
