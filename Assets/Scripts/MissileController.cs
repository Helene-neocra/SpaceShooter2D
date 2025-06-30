using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    public float speed = 10f; // Vitesse du missile
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Le missile avance vers le haut à chaque frame
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        
        // Vérifie si le missile est en dehors de l'écran
        if (transform.position.y > 10f) 
        {
            Destroy(gameObject); // Détruit le missile s'il est hors de l'écran
        }
        if (transform.position.y < -10f) 
        {
            Destroy(gameObject); // Détruit le missile s'il est hors de l'écran
        }

    }
}
