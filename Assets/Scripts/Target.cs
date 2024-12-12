using System;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    [SerializeField] GameObject brokenBottlePrefab;

    // Audio properties
    public AudioClip brokenBottleSound;
    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();

    }

    public void takeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Play broken bottle sound
        if (audioSource != null && brokenBottleSound != null)
        {
            audioSource.PlayOneShot(brokenBottleSound,0.4f);
        }

        // Instantiate the broken bottle prefab
        GameObject brokenBottle = Instantiate(brokenBottlePrefab, this.transform.position, Quaternion.identity);
        brokenBottle.GetComponent<BrokenBottle>().RandomVelocities();

        // Destroy the instantiated broken bottle after 2 seconds
        Destroy(brokenBottle, 2f);

        // Destroy the current object
        Destroy(gameObject, 0.1f);
    }

    void Update()
    {
    }
}
