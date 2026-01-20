using TMPro;
using UnityEngine;

public class WristDisplay : MonoBehaviour
{
    [Header("UI Reference")]
    public TextMeshProUGUI scoreText;

    private int score = 0;

    private void Start()
    {
        updateScoreText();
    }

    private void OnEnable()
    {
        TrashEvents.OnScoreAdded += AddScore;
    }

    private void OnDisable()
    {
        TrashEvents.OnScoreAdded -= AddScore;
    }

    private void AddScore(int points)
    {
        score += points;
        updateScoreText();
    }

    private void updateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Wynik: {score}";
        }
    }
}
