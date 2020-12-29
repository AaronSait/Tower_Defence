using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    float spawnCD = 0.5f;
    float spawnCDRemaning = 5f;
    [System.Serializable]
    public class WaveComponent
        {
        public GameObject enemyPrefab;
        public int num;
        [System.NonSerialized]
        public int spawned = 0;
        }
    public WaveComponent[] waveComps;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        spawnCDRemaning -= Time.deltaTime;
        if (spawnCDRemaning <= 0)
        {
            spawnCDRemaning = spawnCD;
            bool didSpawn = false;
            foreach (WaveComponent wc in waveComps)
            {
                if (wc.spawned < wc.num)
                {
                    Instantiate(wc.enemyPrefab, transform.position, transform.rotation);
                    wc.spawned++;
                    didSpawn = true;
                    break;
                }
            }
            if (didSpawn == false)
            {
                if (transform.parent.childCount > 1)
                {
                    transform.parent.GetChild(1).gameObject.SetActive(true);
                }
                Destroy(gameObject);
            }
        }

    }
}
