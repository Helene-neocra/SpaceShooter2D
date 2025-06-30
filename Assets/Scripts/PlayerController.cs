using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputActionReference MoveAction; // Action pour le mouvement du joueur
    public InputActionReference ShootAction; // Action pour tirer des missiles
    private Vector2 direction = Vector2.zero; // Direction du mouvement du joueur
    public float speed = 5f; // Speed of the player
    
    // Limites gauche et droite
    public float minX = -8f;
    public float maxX = 8f;
    
    public GameObject missilePrefab;
    public Transform firePoint;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
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
        Instantiate(missilePrefab, firePoint.position, Quaternion.identity);
        Debug.Log("Shoot action performed");
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
        transform.Translate(direction * speed * Time.deltaTime);

        
        // bloquer le joueur dans la scene
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
        
        // if (Input.GetMouseButtonDown(0))
        // {
        //     // Crée un missile à la position du firePoint (par ex. devant le joueur)
        //     Instantiate(missilePrefab, firePoint.position, Quaternion.identity);
        // }  
        // if (Mouse.current.leftButton.wasPressedThisFrame)
        // {
        //     Debug.Log("Clic détecté");
        // }

    }

   
    }

