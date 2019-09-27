using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class bullet : MonoBehaviour
{
    public float speed;
    Rigidbody2D bulletbody;
    Vector3 targetpoint;

    private void Start()
    {
        bulletbody = GetComponent<Rigidbody2D>();
       targetpoint= singleton.sg._gun.posEnemy;
    }
    void Update()
    {
        MoveTo(targetpoint, () =>
        {
            Destroy(this.gameObject);
        });

    }
    protected void MoveTo(Vector3 EndPoint, Action onComplete = null)
    {
        float speedPersecond = 15f;
        Vector3 currenPosition = this.gameObject.transform.position;
        float distance = Vector3.Distance(currenPosition, targetpoint);
        float duration = distance / speedPersecond;

        LeanTween.moveLocal(this.gameObject, EndPoint, duration).setEase(LeanTweenType.linear).setOnComplete(onComplete);

        //rotate bullet
        Vector2 direction = new Vector2(targetpoint.x - transform.position.x, targetpoint.y - transform.position.y);
        transform.right = direction;
    }

    //private void OnCollisionEnter2D(Collision2D target)
    //{
    //    if (target.gameObject.tag == "enemy")
    //    {
    //        Destroy(this.gameObject);
    //        Debug.Log("va cham enemy");
    //    }
    //}

}
