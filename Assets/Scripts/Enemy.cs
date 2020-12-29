using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject pathGO;

    Transform targetPathNode;
    int pathNodeIndex = 0;

    public float speed = 5f;
    public int moneyVal = 5;
    public float HP = 1f;

    // Use this for initialization
	void Start ()
    {
        pathGO = GameObject.Find("Path");

	}

    void GetNextNode()
    {
        targetPathNode = pathGO.transform.GetChild(pathNodeIndex);
        pathNodeIndex++;

    }
	
	// Update is called once per frame
	void Update ()
    {
		if(targetPathNode == null)
        {
            GetNextNode();
            if (targetPathNode ==  null)
            {
                //Run out of path
                ReachedEnd();
            }
        }
        Vector3 dir = targetPathNode.position - this.transform.localPosition;

        float distThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distThisFrame)
        {
            //reached the node
            targetPathNode = null;
        }
        else
        {
            //move towards node
            transform.Translate(dir.normalized * distThisFrame, Space.World);
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation , Time.deltaTime *5);
        }
	}
    void ReachedEnd()
    {
        GameObject.FindObjectOfType<ScoreManager>().LoseLife();
        Destroy(gameObject);
        
    }

    public void TakeDamage(float damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameObject.FindObjectOfType<ScoreManager>().gainMoney(moneyVal);
        Destroy(gameObject);
    }
}
