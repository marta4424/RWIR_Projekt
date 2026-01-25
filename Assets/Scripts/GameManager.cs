using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Konfiguracja")]
    [Tooltip("Lista tagów, które liczymy jako œmieci do zebrania")]
    public List<string> trashTags = new List<string> { "BioTrash", "GlassTrash", "MetalTrash", "PlasticTrash" };

    [Header("Debug (tylko do podgl¹du)")]
    [SerializeField] private int totalTrashCount = 0;
    [SerializeField] private int collectedTrashCount = 0;
    private bool gameEnded = false;

    private IEnumerator Start()
    {
        Debug.Log("GameManager: Czekam na wygenerowanie œmieci...");
        yield return new WaitForSeconds(0.2f);
        countAllTrash();
    }
    
    private void OnEnable()
    {
        TrashEvents.OnScoreAdded += onTrashDisposed;
    }

    private void OnDisable()
    {
        TrashEvents.OnScoreAdded -= onTrashDisposed;
    }

    private void countAllTrash()
    {
        totalTrashCount = 0;

        foreach (string tag in trashTags)
        {
            GameObject[] found = GameObject.FindGameObjectsWithTag(tag);
            totalTrashCount += found.Length;
        }

        Debug.Log($"Gra rozpoczêta do zebrania {totalTrashCount} œmieci");
    }

    private void onTrashDisposed(int points)
    {
        if (gameEnded) return;

        collectedTrashCount++;

        if (collectedTrashCount >= totalTrashCount)
            EndGame();
    }

    private void EndGame()
    {
        gameEnded = true;
        Debug.Log("Poziom ukoñczony");
        SceneManager.LoadScene("Win_menu");
    }
}
