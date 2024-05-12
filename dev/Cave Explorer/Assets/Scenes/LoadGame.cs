using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    private static LoadGame instance;
    public string email;
    public string password;
    public int level;
    public static string backendURL = "http://127.0.0.1:8080";

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
        // WWWForm form = new();
        // form.AddField("email", email);
        // form.AddField("password", password);
        User user = new()
        {
            email = email,
            password = password
        };

        string json = JsonUtility.ToJson(user);


        // UnityWebRequest request = UnityWebRequest.Post(backendURL, form);
        UnityWebRequest request = UnityWebRequest.PostWwwForm(backendURL + "/user/login", json);
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        request.uploadHandler = new UploadHandlerRaw(jsonToSend);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

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
        public string password;
        public int level;
    }
}
