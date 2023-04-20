using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject player;
    public PlayerController playerController;
    public float chaseSpeed = 20f;
    private Animator _animator;
    private bool triggered;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        playerController = player.GetComponent<PlayerController>();
        _animator = GetComponent<Animator>();
        triggered = false;
    }

    void Update()
    {
        Vector3 direction;
        // Calculate movement direction and speed
        if (!gameManager.isPlayerIt)
        {
            direction = player.transform.position-transform.position;
        }
        else
        {
            direction = playerController.direction;
        }
        direction.y = 0f;
        direction.Normalize();
        if (direction == Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation, Quaternion.LookRotation(
                    player.transform.position-transform.position), Time.deltaTime * 40f);
            _animator.SetBool("Walk", false);
            return;
        }
        transform.position += direction * (chaseSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(
            transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 40f);
        _animator.SetBool("Walk",true);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!triggered)
            {
                triggered = true;
                print("RESET");
                gameManager.Reset();
            }
            else
            {
                triggered = false;
            }

        }
    }
}
