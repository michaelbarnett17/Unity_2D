using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;

    float loadDelay = 1f;

    bool hasCrashed = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground" && hasCrashed == false)
        {
            FindObjectOfType<PlayerController>().DisableControls();

            crashEffect.Play();

            GetComponent<AudioSource>().PlayOneShot(crashSFX);

            Invoke(nameof(ReloadScene), loadDelay);

            hasCrashed = true;
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
