using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private float RestartingDelay = 1f;
    [SerializeField] private ParticleSystem FinishEffect;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FinishEffect.Play();
            Invoke("ReloadScene", RestartingDelay);
            GetComponent<AudioSource>().Play();
        }
    }
    
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
