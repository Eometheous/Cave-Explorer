using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour
{
    static int level;

private static string backendURL = "ec2-3-14-70-33.us-east-2.compute.amazonaws.com:8080/user/increment-level";


    // Start is called before the first frame update
    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.CompareTag("Player")) {
            level++;
            PlayerPrefs.SetInt("level", level);
            StartCoroutine(IncrementLevelRequest(PlayerPrefs.GetString("email")));
            SceneManager.LoadScene(level);
        }
    }

    private IEnumerator IncrementLevelRequest(string email)
    {
        WWWForm form = new();
        form.AddField("email", email);

        UnityWebRequest request = UnityWebRequest.Post(backendURL, form);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {

            string jsonResponse = request.downloadHandler.text;
            Debug.Log(jsonResponse);

            IncrementResponse response = JsonUtility.FromJson<IncrementResponse>(jsonResponse);

            if (response.success) 
            {
                Debug.Log("Increment successfull");
            }
            else
            {
                Debug.LogError("Increment failed: " + response.message);
            }
        }
        else
        {
            Debug.LogError("Increment failed: " + request.error);
        }
    }

    [Serializable]
    private class IncrementResponse
   {
        public bool success;
        public string message;
    }
}
