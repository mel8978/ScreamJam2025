using TMPro;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    float globalTimer;
    public static int score;

    [SerializeField]
    TextMeshProUGUI timerText;

    [SerializeField]
    TextMeshProUGUI scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        globalTimer = 0;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        globalTimer += Time.deltaTime;

        timerText.text = $"Time: {globalTimer:F}s";
        scoreText.text = $"Score: {score}";
    }
}
