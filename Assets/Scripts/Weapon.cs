using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float damage = 10f;
    public float range = 100f;
    public Camera cam;
    public GameObject MuzzleFlash;
    public Transform MuzzlePosition;
    public GameObject ImpactEffect;
   

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

     void Shoot()
    {
        GameObject Flash = Instantiate(MuzzleFlash,MuzzlePosition);
        Destroy(Flash,0.1f);
        RaycastHit hit;

       if ( Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);
           Target target = hit.transform.GetComponent<Target>();
           if (target != null)
            {
                target.takeDamage(damage);
            }

           

            GameObject ImpactGO = Instantiate(ImpactEffect,hit.point,Quaternion.LookRotation(hit.normal));
            Destroy(ImpactGO, 2f);


        }
    }
}
