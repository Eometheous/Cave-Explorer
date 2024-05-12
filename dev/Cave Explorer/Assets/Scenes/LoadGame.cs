using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Compilation;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    private static LoadGame instance;
    public string email;
    public string password;
    public int level;

    // [SerializeField] TextMeshProUGUI usernameText;
    // [SerializeField] TextMeshProUGUI passwordText;

    public static string backendURL = "https://cave-explorer-git-adding-proper-log-7845d5-eometheous-projects.vercel.app/api/login";

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
            Debug.Log(request.downloadHandler.text);

            string jsonResponse = request.downloadHandler.text;
            LoginResponse response = JsonUtility.FromJson<LoginResponse>(jsonResponse);

            if (response.success) 
            {
                Debug.Log("Login succesfull");
                Debug.Log("Email: " + response.user.email);
                Debug.Log("Level: " + response.user.level);
                level = response.user.level;
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

    [System.Serializable]
    private class LoginResponse
    {
        public bool success;
        public string message;
        public User user;
    }

    [System.Serializable]
    private class User
    {
        public string email;
        public int level;
    }
}
