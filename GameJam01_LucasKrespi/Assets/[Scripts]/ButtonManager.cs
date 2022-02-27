using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public Canvas pauseMenucanvas;

    public Canvas CreditisCanvas;

    public Canvas InstructionsCanvas;

    public Canvas MainMenuCanvas;
    public void Resume()
    {
        Time.timeScale = 1.0f;

        if (pauseMenucanvas)
        {
            pauseMenucanvas.gameObject.SetActive(false);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void instructionsButton()
    {
        MainMenuCanvas.gameObject.SetActive(false);
        InstructionsCanvas.gameObject.SetActive(true);
    }

    public void CretidisButton()
    {
        MainMenuCanvas.gameObject.SetActive(false);
        CreditisCanvas.gameObject.SetActive(true);
    }

    public void BackButton()
    {
        MainMenuCanvas.gameObject.SetActive(true);
        CreditisCanvas.gameObject.SetActive(false);
        InstructionsCanvas.gameObject.SetActive(false);
    }

    public void StartButton()
    {
        SceneManager.LoadScene("Game");
    }
}
