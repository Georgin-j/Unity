using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch(other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("The object is friendly");
                break;
            case "Fuel":
                Debug.Log("The object is Fuel");
                break;
            case "Finish":
                Debug.Log("Congrats");
                break;
            default:
                ReloadLevel();
                break;
        }
    }
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
