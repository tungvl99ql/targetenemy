using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMove : MonoBehaviour {

	float dirX, dirY, movespeed = 5f;
    // Update is called once per frame
    public SpriteRenderer spr;
    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }
    void Update ()
    {
        Move();
        flipPlayertoDirectioEenemy();

    }
    public void Move()
    {
        dirX = Input.GetAxis("Horizontal") * movespeed * Time.deltaTime;
        dirY = Input.GetAxis("Vertical") * movespeed * Time.deltaTime;

        transform.position = new Vector2(transform.position.x + dirX, transform.position.y + dirY);
    }
    public void flipPlayertoDirectioEenemy()
    {
        Vector3 v3 =  singleton.sg._gun.posEnemy;
        Vector3 v4 =  this.transform.position - v3;
        
        if(v4.x >0)
        {
            //Debug.Log("enemy ben trai");
            spr.flipX = true;
        }
        else
        {
            //Debug.Log("enemy ben phai");
            spr.flipX = false;
        }
    }

}
