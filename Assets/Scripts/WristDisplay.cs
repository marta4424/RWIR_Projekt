using TMPro;
using UnityEngine;

public class WristDisplay : MonoBehaviour
{
    [Header("UI Reference")]
    public TextMeshProUGUI displayText;

    private int score = 0;

    private bool isHoldingBag = false;
    private int bagCount = 0;
    private int bagCapacity = 0;

    private void Start()
    {
        refreshDisplay();
    }

    private void OnEnable()
    {
        TrashEvents.OnScoreAdded += AddScore;
        TrashEvents.OnBagStateChanged += UpdateBagInfo;
    }

    private void OnDisable()
    {
        TrashEvents.OnScoreAdded -= AddScore;
        TrashEvents.OnBagStateChanged -= UpdateBagInfo;
    }

    private void AddScore(int points)
    {
        score += points;
        refreshDisplay();
    }

    private void UpdateBagInfo(bool isHeld, int count, int capacity)
    {
        isHoldingBag = isHeld;
        bagCount = count;
        bagCapacity = capacity;
        refreshDisplay();
    }

    private void refreshDisplay()
    {
        string finalText = $"Wynik: {score}";

        if (isHoldingBag)
        {
            finalText += $"\nWorek: {bagCount}/{bagCapacity}";
        }

        displayText.text = finalText;
    }
}
