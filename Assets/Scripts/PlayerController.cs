
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
    
    private void OnEnable()
    {
        ShootAction.action.performed += OnShootActionPerformed;
        ShootAction.action.Enable();
        
        MoveAction.action.performed += OnMoveActionPerformed;
        MoveAction.action.canceled += OnMoveActionCanceled;
        MoveAction.action.Enable();
    }

    private void OnShootActionPerformed(InputAction.CallbackContext obj)
    {
        // Crée un missile à la position du firePoint (par ex. devant le joueur)
        var missile = Instantiate(missilePrefab, firePoint.position, Quaternion.identity);
        missile.tag = this.gameObject.tag; // Assigne le même tag que le joueur pour que le missile puisse toucher les ennemis
    }

    private void OnDisable()
    {
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
       direction = context.ReadValue<Vector2>();
    }
    // Update is called once per frame
    void Update()
    {
        // bloquer le joueur dans la scene
        Debug.Log("Mouse" + ShootAction.action.ReadValue<float>());
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

