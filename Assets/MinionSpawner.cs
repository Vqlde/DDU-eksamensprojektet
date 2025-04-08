using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawner : MonoBehaviour
{
    public GameObject minionPrefab; // Assign your minion prefab
    public int minionCount = 2;
    public Vector3[] spawnPositions; // Array for positions
    public Quaternion[] spawnRotations; // Array for rotations

    void Start()
    {
        for (int i = 0; i < minionCount; i++)
        {
            Vector3 spawnPos = spawnPositions[i];
            Quaternion spawnRot = spawnRotations[i];

            GameObject minion = Instantiate(minionPrefab, spawnPos, spawnRot);
            Debug.Log("Spawned minion at: " + spawnPos + " with rotation: " + spawnRot.eulerAngles);
        }
    }
}