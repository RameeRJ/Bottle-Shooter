using System;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    [SerializeField] GameObject brokenBottlePrefab;

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
        GameObject brokenBottle = Instantiate(brokenBottlePrefab, this.transform.position, Quaternion.identity);
        brokenBottle.GetComponent<BrokenBottle>().RandomVelocities();
        Destroy(brokenBottle,2f);
        Destroy(gameObject,0.1f);

    }

    void Update()
    {
        
    }
}
