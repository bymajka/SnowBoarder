using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseDetector : MonoBehaviour
{
    [SerializeField] private float DelayToReload = 1f;
    [SerializeField] private ParticleSystem DeathEffect;
    private bool Lose = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground" && !Lose)
        {
            Lose = true;
            FindObjectOfType<PlayerController>().DisableControl();
            DeathEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", DelayToReload);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
