using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiShooter : MonoBehaviour
{
    public GameObject missilePrefab;       // Missile à instancier
    public Transform firePoint;            // Point de tir
    public float fireRate = 2f;            // Temps entre deux tirs
    void OnEnable()
    {
        StartCoroutine(FireRoutine());
    }
    IEnumerator FireRoutine()
    { 
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(fireRate * 0.8f, fireRate * 1.2f)); 
            FireMissile();
        }
    }
    void FireMissile()
    {
        if (missilePrefab != null && firePoint != null)
        {
         var missile =  Instantiate(missilePrefab, firePoint.position, firePoint.rotation);
         missile.tag = this.gameObject.tag;
        }
    }
   
}
