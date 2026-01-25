using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void RestartGame()
    {
        Debug.Log("Wciœniêto przycisk restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
