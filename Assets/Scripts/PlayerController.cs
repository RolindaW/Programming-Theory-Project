using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float MOVE_SPEED = 5.0f;

    [SerializeField] private GameObject projectile;
    private float projectileSpawnForwardOffsetValue = 1.0f;
    
    private GameManager gameManager;
    private Camera mainCamera;
    private CharacterController characterController;

    private Vector3 lookAtPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        characterController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.IsGameActive)
        {
            // Move the player
            Vector3 movementIncrement = MOVE_SPEED * Time.deltaTime * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            characterController.Move(movementIncrement);

            // Rotate the player
            lookAtPosition = GetLookAtPosition();
            gameObject.transform.LookAt(lookAtPosition);
            
            // Shoot projectile
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }
    }

    private Vector3 GetLookAtPosition()
    {
        Vector3 worldPosition;
        if (GetMouseWorldPosition(mainCamera, out worldPosition))
        {
            // Constraint player pitch
            return new Vector3(worldPosition.x, gameObject.transform.position.y, worldPosition.z);
        }
        else
        {
            return gameObject.transform.position;
        }
    }

    private bool GetMouseWorldPosition(Camera camera, out Vector3 worldPosition)
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitData;
        if(Physics.Raycast(ray, out hitData, 1000))
        {
            worldPosition = hitData.point;
            return true;
        }
        else
        {
            worldPosition = Vector3.zero;
            return false;
        }
    }

    private void Shoot()
    {
        Vector3 projectileSpawnForwardOffset = projectileSpawnForwardOffsetValue * (lookAtPosition - gameObject.transform.position).normalized;
        Instantiate(projectile, gameObject.transform.position + projectileSpawnForwardOffset, gameObject.transform.rotation);
    }
}
