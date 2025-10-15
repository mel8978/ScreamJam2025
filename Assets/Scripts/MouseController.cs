using UnityEngine;
using UnityEngine.InputSystem;

public class MouseController : MonoBehaviour
{
    Vector2 mousePosition;
    BoxCollider2D boxCollider;
    SpriteRenderer spriteRenderer;

    float clickTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.enabled = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        clickTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Mouse.current.position.ReadValue();
        mousePosition = (Vector2)Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = mousePosition;

        if (clickTimer > 0)
        {
            clickTimer -= Time.deltaTime;
        }
        if (clickTimer <= 0 && boxCollider.enabled)
        {
            boxCollider.enabled = false;
            spriteRenderer.color = Color.white;
        }
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && clickTimer <= 0)
        {
            clickTimer = 1;
            boxCollider.enabled = true;
            spriteRenderer.color = Color.green;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ghost")
        {
            Destroy(collision.gameObject);
            CanvasController.score++;
        }        
    }
}
