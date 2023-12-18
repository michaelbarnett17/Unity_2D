using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem dustEffect;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            dustEffect.Play();
        }
    }


    void OnCollisionExit2D(Collision2D collision)
    {
            dustEffect.Stop();
    }
}
