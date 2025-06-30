using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiController : MonoBehaviour
{
    public GameObject missileEnnemiPrefab;
    public Transform firePointEnnemi;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(missileEnnemiPrefab, firePointEnnemi.position, firePointEnnemi.rotation);
    }
}
