using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;

    [SerializeField] float timeToDestory = 0.1f;

    [SerializeField] Color32 noPackageColor = new Color32(255, 255, 255, 255);
    [SerializeField] Color32 hasPackageColor = new Color32 (130, 45, 154, 255);


    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Package" && hasPackage == false)
        {
            Debug.Log("Package Picked Up");

            hasPackage = true;

            spriteRenderer.color = hasPackageColor;

            Destroy(collision.gameObject, timeToDestory);

        }

        if (collision.tag == "Customer" && hasPackage == true)
        {
            Debug.Log("Delivered Package");

            spriteRenderer.color = noPackageColor;

            hasPackage = false;
        }

    }


}

