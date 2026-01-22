using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCanvasController : MonoBehaviour
{
    public void graj()
    {
        SceneManager.LoadScene("Main_Scene");
    }

    public void wrocDoMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void wyjdü()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}