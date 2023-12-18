using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] ParticleSystem finishEffect;

    float loadDelay = 1f;
    bool hasFinished = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && hasFinished == false)
        {
            finishEffect.Play();

            GetComponent<AudioSource>().Play();

            Invoke(nameof(ReloadScene), loadDelay);

            hasFinished = true;
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
