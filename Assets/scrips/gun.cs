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
    public SpriteRenderer spr;
    
    private void Awake()
    {
        MakeInstance();
    }
    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        FindClosestEnemy();
        shoot();
        FlipGunToDirectionEnemy();
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

        float distanceToClosestEnemy = 60f;
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

        if(closestEnemy != null)
        {
            Debug.DrawLine(this.transform.position, closestEnemy.transform.position);
            sp.transform.position = closestEnemy.transform.position;
            posEnemy = closestEnemy.transform.position;
            Vector2 direction = new Vector2(posEnemy.x - transform.position.x, posEnemy.y - transform.position.y);
            transform.right = direction;
        }if(closestEnemy == null)
        {
            direction = new Vector2(0,0);
            transform.right = direction;
            posEnemy = bulletPoint.transform.position;

        }
    }
    void shoot()
    {
        if(posEnemy != bulletPoint.transform.position)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(bullet, bulletPoint.transform.position, Quaternion.identity);
            }
        }
    }
    
    public void FlipGunToDirectionEnemy()
    {
        Vector3 v3 = posEnemy;
        Vector3 v4 = this.transform.position - v3;
        if (v4.y > 0)
        {
            Debug.Log("enemy ben duoi");
            
        }
        if(v4.y <0)
        {
            Debug.Log("enemy ben tren");
            //spr.flipX = true;
        }
        if(v4.x > 0)
        {
            spr.flipY = true;
        }
        if (v4.x < 0)
        {
            spr.flipY = false;
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
