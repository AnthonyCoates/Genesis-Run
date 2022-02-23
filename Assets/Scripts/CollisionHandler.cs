using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public AudioClip nomSFX;
    public AudioClip blechSFX;

    private AudioSource audioSource;
    public float volumeFX = 1f;

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
            audioSource.PlayOneShot(blechSFX, volumeFX);
        }
        else if (collision.gameObject.tag == "Steak")
        {
            audioSource.PlayOneShot(nomSFX, volumeFX);
        }

        Destroy(collision.gameObject);
    }
}
