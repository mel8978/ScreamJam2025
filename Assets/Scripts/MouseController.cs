using UnityEngine;
using UnityEngine.InputSystem;

public class MouseController : MonoBehaviour
{
    Vector2 mousePosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Mouse.current.position.ReadValue();
        mousePosition = (Vector2)Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = mousePosition;
    }
}
