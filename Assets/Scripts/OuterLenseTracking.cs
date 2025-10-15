using UnityEngine;
using UnityEngine.InputSystem;

public class OuterLenseTracking : MonoBehaviour
{

    [SerializeField]
    Vector2 ObjPos;

    [SerializeField]
    Vector2 mousePosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ObjPos = this.transform.position;

        mousePosition = Mouse.current.position.ReadValue();
        mousePosition = (Vector2)Camera.main.ScreenToWorldPoint(mousePosition);
        this.transform.position = mousePosition;
    }
}
