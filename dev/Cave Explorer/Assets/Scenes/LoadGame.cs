using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    public string email;
    public string password;
    public int level;
    public static string backendURL = "http://127.0.0.1:8080/user/login";

    public User user;
    public LoginResponse response;

    // void Awake()
    // {
    //     if (instance == null)
    //     {
    //         instance = this;
    //         DontDestroyOnLoad(gameObject);
    //     }
    //     else
    //     {
    //         Destroy(gameObject);
    //     }
    // }

    public void GrabUsernameText(string email)
    {
        this.email = email;   
    }
    public void GrabPasswordText(string password)
    {
        this.password = password;
    }

    public void StartGame() 
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("level"));
    }

    public void LoadMainMenu() 
    {
        SceneManager.LoadScene(0);
    }

    public void LoadLogin() 
    {
        SceneManager.LoadScene(8);
    }

        public void OnSubmitButton() 
    {
        Login(email, password);
    }

    public void Login(string email, string password)
    {
        StartCoroutine(LoginRequest(email, password));
    }

    private IEnumerator LoginRequest(string email, string password)
    {
        WWWForm form = new();
        form.AddField("email", email);
        form.AddField("password", password);

        UnityWebRequest request = UnityWebRequest.Post(backendURL, form);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            // Debug.Log("Success!");
            // Debug.Log(request.downloadHandler.text);

            string jsonResponse = request.downloadHandler.text;
            Debug.Log(jsonResponse);

            response = JsonUtility.FromJson<LoginResponse>(jsonResponse);

            if (response.success) 
            {
                level = response.user.level;
                PlayerPrefs.SetString("email", response.user.email);
                PlayerPrefs.SetInt("level", response.user.level);
                SceneManager.LoadScene(level);
            }
            else
            {
                Debug.LogError("Login failed: " + response.message);
            }
        }
        else
        {
            Debug.LogError("Login failed: " + request.error);
        }
    }

    [Serializable]
    public class LoginResponse
    {
        public bool success;
        public string message;
        public User user;
    }

    [Serializable]
    public class User
    {
        public string email;
        public int level;
    }
}
