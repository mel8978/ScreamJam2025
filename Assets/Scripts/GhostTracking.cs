using UnityEngine;

public class GhostTracking : MonoBehaviour
{
    float speed = 2f;

    Vector2 direction;

    Vector2 velocity;

    Rigidbody2D rb;

    Vector2 playerPos;

    [SerializeField]
    GameObject player;

    SpriteRenderer sprite;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        playerPos = player.transform.position;

        if (playerPos.x < rb.position.x)
        {
            direction.x = -2;
        }
        else if (playerPos.x > rb.position.x)
        {
            direction.x = 2;
        }
        if (playerPos.y < rb.position.y)
        {
            direction.y = -1.3f;
        }
        else if (playerPos.y > rb.position.y)
        {
            direction.y = 1.3f;
        }
        else if (playerPos.y == rb.position.y)
        {
            direction.y = 0;
        }
    }

    private void FixedUpdate()
    {
        if (direction.magnitude > 0)
        {
            velocity = direction * speed * Time.fixedDeltaTime;
            Vector2 newPos = (Vector2)transform.position + velocity;
            rb.MovePosition(newPos);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //collision.gameObject.SetActive(false);
        sprite.color = Color.red;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        sprite.color = Color.white;
    }
}
