using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void ShowCredits()
    {
        SceneManager.LoadScene(2);
    }
}
