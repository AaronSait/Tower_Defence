﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpot : MonoBehaviour
{
    private void OnMouseUp()
    {
        Debug.Log("Clicked");
        BuildingManager bm = GameObject.FindObjectOfType<BuildingManager>();
        if (bm.selectedTower != null)
        {
            ScoreManager sm = GameObject.FindObjectOfType<ScoreManager>();
            if (sm.money < bm.selectedTower.GetComponent<Tower>().cost)
            {
                Debug.Log("Not enugh Money");
                return;
            }
            sm.gainMoney(-bm.selectedTower.GetComponent<Tower>().cost);
            Instantiate(bm.selectedTower, transform.parent.position, transform.parent.rotation);
            Destroy(transform.parent.gameObject);
        }
    }
}
