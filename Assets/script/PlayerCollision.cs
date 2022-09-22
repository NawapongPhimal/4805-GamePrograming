using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Player playerControll;
    private Collider2D playerCollider;
    private GameManager _gameManager;


    private void Start()
    {
        playerCollider = GetComponent<Collider2D>();
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerCollider.IsTouchingLayers(LayerMask.GetMask("Hazard")))
        {
            Debug.Log("outch");
            _gameManager.TakeDamage();
            
        }

    }
}
