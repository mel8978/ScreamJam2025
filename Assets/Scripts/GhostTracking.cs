using UnityEngine;

public class GhostTracking : MonoBehaviour
{
    int speed;

    Rigidbody2D rb;

    Vector2 playerPos;

    [SerializeField]
    GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPos = player.transform.position;
    }


    void Update()
    {
        
    }
}
