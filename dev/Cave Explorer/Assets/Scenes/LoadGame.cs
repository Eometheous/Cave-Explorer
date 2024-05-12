using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    private static LoadGame instance;
    public string email;
    public string password;

    // [SerializeField] TextMeshProUGUI usernameText;
    // [SerializeField] TextMeshProUGUI passwordText;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GrabUsernameText(string email)
    {
        this.email = email;   
    }
    public void GrabPasswordText(string password)
    {
        this.password = password;
    }

    public void OnSubmitButton() 
    {
        // username = usernameText.text;
        // password = passwordText.text;
    }

    public void StartGame() 
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMainMenu() 
    {
        SceneManager.LoadScene(0);
    }

    public void LoadLogin() 
    {
        SceneManager.LoadScene(8);
    }
}
