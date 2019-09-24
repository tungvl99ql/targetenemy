using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public static gun instance;
    public GameObject sp;
    public GameObject bullet;
    public GameObject bulletPoint;
    public Vector3 posEnemy;
    public Vector2 direction;
    public float speed;
   
    void Update()
    {
        FindClosestEnemy();
        shoot();
    }
    void mouseposition()
    {
        Vector3 mousepos = Input.mousePosition;
        mousepos = Camera.main.ScreenToWorldPoint(mousepos);

        Vector2 direction = new Vector2(mousepos.x - transform.position.x, mousepos.y - transform.position.y);
        transform.right = direction;
    }
   public void FindClosestEnemy()
    {

        float distanceToClosestEnemy = 60;
        Enemy closestEnemy = null;
        Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();

        foreach (Enemy currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;

                //sp.transform.position = closestEnemy.transform.position;
                //posEnemy = closestEnemy.transform.position;
            }
        }

        //Debug.DrawLine(this.transform.position, closestEnemy.transform.position);
        //Debug.Log(closestEnemy.gameObject.transform.position);
        sp.transform.position = closestEnemy.transform.position;
        posEnemy = closestEnemy.transform.position;

        Vector2 direction = new Vector2(posEnemy.x - transform.position.x, posEnemy.y - transform.position.y);
        transform.right = direction;
        
    }
    void shoot()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, bulletPoint.transform.position, Quaternion.identity);
        }
    }
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
