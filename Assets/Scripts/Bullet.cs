﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed = 50f;
    public Transform target;
    public float damage = 1f;
    public float rad = 0f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - this.transform.localPosition;

        float distThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distThisFrame)
        {
            //reached the node
            BulletHit();
        }
        else
        {
            //move towards node
            transform.Translate(dir.normalized * distThisFrame, Space.World);
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime * 5); 
        }
    }
    void BulletHit()
    {
        if (rad == 0f)
        {
            target.GetComponent<Enemy>().TakeDamage(damage);
        }
        else
        {
            Collider[] cols = Physics.OverlapSphere(transform.position, rad);
            foreach(Collider c in cols)
            {
                Enemy e = c.GetComponent<Enemy>();
                if (e!=null)
                {
                    e.GetComponent<Enemy>().TakeDamage(damage);
                }
            }
        }

        
        Destroy(gameObject);
    }
}
