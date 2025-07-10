using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputActionReference MoveAction; // Action pour le mouvement du joueur
    public InputActionReference ShootAction; // Action pour tirer des missiles
    private Vector2 direction = Vector2.zero; // Direction du mouvement du joueur
    public float speed = 5f; // Speed of the player
    
    public GameObject missilePrefab;
    public Transform firePoint;
    
    

    private void OnShootActionPerformed(InputAction.CallbackContext obj)
    { 
        GameObject shoot = ShootPool.instance.getPoolObject ();

        //on s'assure que l'instance est pas nulle
        if (shoot != null) {
            shoot.transform.position = firePoint.position;
            shoot.transform.rotation = firePoint.rotation;
            shoot.SetActive (true);
            shoot.tag = gameObject.tag; // Assigne le même tag que le joueur pour que le missile puisse toucher les ennemis

        } else {
            Debug.Log ("plus de pool dispo ! ");
        }
       
    }
    private void OnEnable()
    {
        // Abonnez-vous aux événements de l'action de mouvement
        MoveAction.action.performed += OnMoveActionPerformed;
        MoveAction.action.canceled += OnMoveActionCanceled;
        MoveAction.action.Enable();
        
        ShootAction.action.performed += OnShootActionPerformed;
        ShootAction.action.Enable();
    }
    private void OnDisable()
    {
        // Désabonnez-vous des événements de l'action de mouvement
        MoveAction.action.performed -= OnMoveActionPerformed;
        MoveAction.action.canceled -= OnMoveActionCanceled;
        MoveAction.action.Disable();
        
        ShootAction.action.performed -= OnShootActionPerformed;
        ShootAction.action.Disable();
    }
    private void OnMoveActionCanceled(InputAction.CallbackContext context)
    {
        direction = Vector2.zero; // Réinitialise la direction lorsque l'action est annulée
    }
    private void OnMoveActionPerformed(InputAction.CallbackContext context)
    {
        // Met à jour la direction du joueur en fonction de l'entrée
        // context.ReadValue<Vector2>() retourne un Vector2 représentant la direction
       direction = context.ReadValue<Vector2>();
    }
    // Update is called once per frame
    void Update()
    {
        // bloquer le joueur dans la scene
        transform.Translate(direction * speed * Time.deltaTime);
        clampPlayerMovement();
    }
    void clampPlayerMovement()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        float paddingX = 0.05f; // 5% des bords gauche et droit
        pos.x = Mathf.Clamp(pos.x, paddingX, 1f - paddingX);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
    }

