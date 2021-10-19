using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int _brickCount = 0;
    private int _playerHealth = 3;
    void Start()
    {
        HandleSingleton();
    }

    private void HandleSingleton()
    {
        int levelManagerCount = FindObjectsOfType<LevelManager>().Length;
        if (levelManagerCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
        _playerHealth = 3;
    }
    public void LoadNextLevel()
    {
        int nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextLevelIndex == SceneManager.sceneCountInBuildSettings)
        {
            LoadMainMenu();
            return;
        }
        LoadLevel(nextLevelIndex);
    }
    public void LoadMainMenu()
    {
        Destroy(FindObjectOfType<LevelManager>().gameObject);
        LoadLevel(0);
    }
    public void IncreaseBrickCount()
    {
        _brickCount++;
    }
    public void DecreaseBrickCount()
    {
        _brickCount--;
        if (_brickCount < 1)
        {
            OnLevelCompleted();
        }
    }
    public void OnLevelCompleted()
    {
        LoadNextLevel();
    }
    public void DecreasePlayerHealth()
    {
        _playerHealth--;
        if (_playerHealth < 1)
        {
            HandleGameOver();
        }
    }

    private void HandleGameOver()
    {
        LoadMainMenu();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
