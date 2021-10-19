using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] Text _pauseText;
    private bool _isPaused = false;
    private void OnPause()
    {
        if (_isPaused)
        {
            UnpauseGame();
            HidePauseOverlay();
            _isPaused = false;
        }
        else
        {
            PauseGame();
            ShowPauseOverlay();
            _isPaused = true;
        }
    }

    private void HidePauseOverlay()
    {
        _pauseText.gameObject.SetActive(false);
    }
    private void ShowPauseOverlay()
    {
        _pauseText.gameObject.SetActive(true);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void UnpauseGame()
    {
        Time.timeScale = 1;
    }
}
