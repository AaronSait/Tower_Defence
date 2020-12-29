using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    Transform turretTransform;


    public float range = 50f;
    public GameObject bulletPrefab;
    float fireCD = 0.5f;
    float fireCDLeft = 0f;
    public int cost = 5;
    public float damage = 1;
    public float rad = 0f;

    // Use this for initialization
    void Start()
    {
        turretTransform = transform.Find("Turret");
    }

    // Update is called once per frame
    void Update()
    {
        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();

        Enemy nearestEnemy = null;
        float dist = Mathf.Infinity;

        foreach (Enemy e in enemies)
        {
            float d = Vector3.Distance(this.transform.position, e.transform.position);
            if (nearestEnemy == null || d < dist)
            {
                nearestEnemy = e;
                dist = d;
            }
        }

        if (nearestEnemy == null)
        {
            //Debug.Log("No Enemies?");
            return;
        }

        Vector3 dir = nearestEnemy.transform.position - this.transform.position;
        Quaternion lookRot = Quaternion.LookRotation(dir);
        turretTransform.rotation = Quaternion.Euler(0, lookRot.eulerAngles.y, 0);

        fireCDLeft -= Time.deltaTime;
        if (fireCDLeft <= 0 && dir.magnitude <= range)
        {
            fireCDLeft = fireCD;
            ShootAt(nearestEnemy);
        }

    }
    void ShootAt(Enemy e)
    {
        
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
        Bullet b = bulletGO.GetComponent<Bullet>();
        b.target = e.transform;
        b.damage = damage;
        b.rad = rad;
    }
}
