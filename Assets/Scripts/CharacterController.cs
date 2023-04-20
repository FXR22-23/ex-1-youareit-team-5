using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float worldSize = 100;
    public GameManager gameManager;
    private Animator _animator;
    private Rigidbody _rb;
    public GameObject other;
    public float hitRadius;



    private static readonly int Near = Animator.StringToHash("Near");

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check if the character is outside the bounds
        // Get the position of the player or AI
        Vector3 position = transform.position;

        // Check if the player or AI has gone beyond the X boundaries
        if (position.x < -worldSize / 2f)
        {
            position.x = worldSize / 2f;
        }
        else if (position.x > worldSize / 2f)
        {
            position.x = -worldSize / 2f;
        }

        // Check if the player or AI has gone beyond the Y boundaries
        if (position.y < -worldSize / 2f)
        {
            position.y = worldSize / 2f;
        }
        else if (position.y > worldSize / 2f)
        {
            position.y = -worldSize / 2f;
        }

        // Check if the player or AI has gone beyond the Z boundaries
        if (position.z < -worldSize / 2f)
        {
            position.z = worldSize / 2f;
        }
        else if (position.z > worldSize / 2f)
        {
            position.z = -worldSize / 2f;
        }

        // Update the position of the player or AI
        transform.position = position;


        // Check distance for hit
        if (CompareTag("Player") && gameManager.isPlayerIt)
        {
            if (Vector3.Distance(other.transform.position, transform.position) < hitRadius)
            {
                _animator.SetTrigger(Near);
            }
        }
        else if (CompareTag("AI") && !gameManager.isPlayerIt)
        {
            if (Vector3.Distance(other.transform.position, transform.position) < hitRadius)
            {
                _animator.SetTrigger(Near);
            }
        }
    }
}
