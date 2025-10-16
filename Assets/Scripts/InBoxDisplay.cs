using UnityEngine;

public class InBoxDisplay : MonoBehaviour
{

    [SerializeField]
    bool isActive;

    public static BoxCollider2D boxCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            collision.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y, 0);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isActive)
        {
            collision.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y, -20);
        }
    }

}
