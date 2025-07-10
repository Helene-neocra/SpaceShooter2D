using UnityEngine;
public class MissileController : MonoBehaviour
{
    public float speed = 10f; // Vitesse du missile
    public int damage = 1;
    public string targetTag = "Ennemis"; // Qui ce missile est censé toucher
    void Update()
    {
        // Le missile avance vers le haut à chaque frame
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        // Vérifie si le missile est en dehors de l'écran
        if (transform.position.y > 10f) 
        {
            gameObject.SetActive(false);// Détruit le missile s'il est hors de l'écran
        }
        if (transform.position.y < -10f) 
        {
            gameObject.SetActive(false);// Détruit le missile s'il est hors de l'écran
        }
    } 
    void OnTriggerEnter2D(Collider2D other)
    {
        // Vérifie si le missile touche un objet avec un tag différent de celui du joueur
        if (!other.CompareTag(this.gameObject.tag))
        {
            Health health = other.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
            gameObject.SetActive(false);// Détruit le missile s'il touche un ennemi ou le joueur
        }
    }
}
