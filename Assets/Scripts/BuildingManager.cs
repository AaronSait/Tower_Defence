using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour {
    public GameObject selectedTower;
    // Use this for initialization
    public void SelsctTowerType(GameObject towerPrefab)
    {
        selectedTower = towerPrefab;
    }

}
