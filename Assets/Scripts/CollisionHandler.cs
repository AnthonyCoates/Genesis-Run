using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollisionHandler : MonoBehaviour
{
    public AudioClip nomSFX;
    public AudioClip blechSFX;

    private AudioSource audioSource;
    public float volumeFX = 1f;

    public TextMeshProUGUI scoreTXT;
    public TextMeshProUGUI livesTXT;

    private ScoreKeeper sk;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        sk = GameObject.FindGameObjectWithTag("ScoreKeeper").GetComponent<ScoreKeeper>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Broccoli")
        {
            sk.AdjustLives(-1);
            livesTXT.text = "Tastebuds: " + sk.GetLives();

            audioSource.PlayOneShot(blechSFX, volumeFX);
        }
        else if (collision.gameObject.tag == "Steak")
        {
            sk.AdjustScore(75);
            scoreTXT.text = "Protein: " + sk.GetScore() + "g";

            audioSource.PlayOneShot(nomSFX, volumeFX);
        }

        Destroy(collision.gameObject);
    }
}
