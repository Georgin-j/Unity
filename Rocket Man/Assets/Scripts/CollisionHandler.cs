using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delayInLoading = 2f;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip death;

    AudioSource aus;
    Rigidbody rb;

    bool IsTransitioning = false;

    void Start()
    {
        aus = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision other)
    {
        if(IsTransitioning)
        {
            return;
        }
        switch(other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("The object is friendly");
                break;
            case "Fuel":
                Debug.Log("The object is Fuel");
                break;
            case "Finish":
                SuccessSequence();
                break;
            default:
                DeathSequence();
                break;
        }
    } 
    
    void DeathSequence()
    {
        IsTransitioning = true;
        aus.Stop();
        aus.PlayOneShot(death);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", delayInLoading);
    }

    void SuccessSequence()
    {
        IsTransitioning = true;
        aus.Stop();
        aus.PlayOneShot(success);
        GetComponent<Movement>().enabled = false;
        Invoke("NextLevel", delayInLoading);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
