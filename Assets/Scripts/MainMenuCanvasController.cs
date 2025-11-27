using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCanvasController : MonoBehaviour
{
    public void graj()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void wyjdü()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}