using System;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    float spawnTimer;

    float waveTimer;

    [SerializeField]
    float spawnTime;

    [SerializeField]
    GameObject ghost;

    [SerializeField]
    GameObject player;

    public static Vector3 playerPos;

    public static Dictionary<GameObject, bool> ghosts = new Dictionary<GameObject, bool>();

    public static List<GameObject> ghostList = new List<GameObject>();

    int count;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnTimer = 0;
        ghostList.Add(Instantiate(ghost, new Vector3(0, 0, -20), Quaternion.identity));
        count = 0;
        ghosts.Add(ghostList[count], false);
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;

        waveTimer += Time.deltaTime;

        if (waveTimer >= 15)
        {
            spawnTime--;
            waveTimer = 0; 
        }

        if (spawnTimer < spawnTime)
        {
            spawnTimer += Time.deltaTime;
        }
        if (spawnTimer >= spawnTime)
        {
            Vector3 spawnPos = new Vector3(UnityEngine.Random.Range(-9, 9), UnityEngine.Random.Range(-4, 5), -20);
            ghostList.Add(Instantiate(ghost, spawnPos, Quaternion.identity));
            count++;
            ghosts.Add(ghostList[count], false);
            spawnTimer = 0;
        }
    }
}
