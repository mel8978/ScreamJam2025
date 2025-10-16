using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    [SerializeField]
    float spawnTimer;

    [SerializeField]
    float spawnTime;

    [SerializeField]
    GameObject ghost;

    [SerializeField]
    GameObject player;

    public static Vector3 playerPos;

    public static List<GameObject> ghosts = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnTimer = 0;
        ghosts.Add(Instantiate(ghost, new Vector3(0, 0, -20), Quaternion.identity));
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;

        if (spawnTimer < spawnTime)
        {
            spawnTimer += Time.deltaTime;
        }
        if (spawnTimer >= spawnTime)
        {
            
            ghosts.Add(Instantiate(ghost, new Vector3(0, 0, -20), Quaternion.identity));
            spawnTimer = 0;
        }
    }
}
