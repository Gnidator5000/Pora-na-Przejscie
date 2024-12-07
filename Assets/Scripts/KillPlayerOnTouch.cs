using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class KillPlayerOnTouch : MonoBehaviour
{
    //[SerializeField] private Text scoreText;
    //private int score;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;
            Destroy(collision.gameObject);
           // scoreText.text = "Score: " + score;
        }
    }
}
