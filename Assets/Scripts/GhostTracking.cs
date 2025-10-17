using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GhostTracking : MonoBehaviour
{
    float speed = 1.5f;

    Vector2 direction;

    Vector2 velocity;

    Rigidbody2D rb;

    Vector2 playerPos;

    SpriteRenderer sprite;

    public static bool isFrozen = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        playerPos = GhostSpawner.playerPos;

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
        if (Mathf.Abs(rb.position.x - playerPos.x) < 0.25)
        {
            direction.x = 0;
        }
        if (Mathf.Abs(rb.position.y - playerPos.y) < 0.25)
        {
            direction.y = 0;
        }
        foreach (GameObject ghost in GhostSpawner.ghostList)
        {
            if (GhostSpawner.ghosts[ghost])
            {
                speed = 0;
            }
            if (!GhostSpawner.ghosts[ghost])
            {
                speed = 1.5f;
            }
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
        //GameOver scene
        if (collision.tag == "Player")
        {
            sprite.color = Color.red;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        sprite.color = Color.white;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        foreach (GameObject ghost in GhostSpawner.ghostList)
        {
            if (InBoxDisplay.boxCollider.bounds.Contains(ghost.transform.position))
            {
                GhostSpawner.ghosts[ghost] = true;
            }
        }
    }
}
