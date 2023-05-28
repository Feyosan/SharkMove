/*using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Temporizador : MonoBehaviour
{
    public int initialCountdown;
    public int minutes;
    public int seconds;
    public TextMeshProUGUI countdownDisplay;
    public string loseSceneName;

    public SharkMovement SharkMov;
    private void Start()
    {
        SharkMov.canMove = false;
        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart()
    {
        while (initialCountdown > 0)
        {
            countdownDisplay.text = "Listo... " + initialCountdown;

            yield return new WaitForSeconds(1f);

            initialCountdown--;
        }

        countdownDisplay.text = "¡Empieza!";
        SharkMov.canMove = true;

        // Luego empieza el temporizador
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        while (minutes > 0 || seconds > 0)
        {
            countdownDisplay.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            yield return new WaitForSeconds(1f);

            if (seconds == 0)
            {
                minutes--;
                seconds = 59;
            }
            else
            {
                seconds--;
            }
        }

        // Cambia a la escena de "Perdiste" cuando el tiempo se agote
        //SceneManager.LoadScene(loseSceneName);
    }
}*/

using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Temporizador : MonoBehaviour
{
    public int initialCountdown;
    public int minutes;
    public int seconds;
    public TextMeshProUGUI countdownDisplay;
    public string loseSceneName;

    public SharkMovement SharkMov;

    private bool isTimerRunning = false;

    private void Start()
    {
        SharkMov.canMove = false;
        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart()
    {
        while (initialCountdown > 0)
        {
            countdownDisplay.text = "Listo... " + initialCountdown;

            yield return new WaitForSeconds(1f);

            initialCountdown--;
        }

        countdownDisplay.text = "¡Empieza!";
        SharkMov.canMove = true;

        // Luego empieza el temporizador
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        isTimerRunning = true;

        while (isTimerRunning)
        {
            countdownDisplay.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            yield return new WaitForSeconds(1f);

            if (seconds == 0)
            {
                if (minutes == 0)
                {
                    // El jugador pierde cuando el tiempo se agota
                    PlayerLose();
                    yield break;
                }
                else
                {
                    minutes--;
                    seconds = 59;
                }
            }
            else
            {
                seconds--;
            }
        }
    }

    void PlayerLose()
    {
        // Cambia a la escena de "Perdiste" cuando el tiempo se agote
        Time.timeScale = 0f;
        GameOverManager.gameOverManager.CallGameOver();
    }
}
