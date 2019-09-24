using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class bullet : MonoBehaviour
{
    public float speedmove = 1;
    private void Start()
    {
        
    }
    void Update()
    {
        Debug.Log(gun.instance.posEnemy);
        //bulletmove();
    }
    void bulletmove()
    {
        //Vector3 v3 = this.transform.position;
        //Vector3 vA = this.transform.position;
        //v3.x -= speedmove * Time.deltaTime;
        //this.transform.position = v3;
        //Vector3.Lerp(vA,_gun.posEnemy,2);
    }
}
