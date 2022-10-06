using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{   
    [SerializeField] private Player playerControll;
    private Collider2D playerCollider;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private PlayerAudioController audioController;


    private void Start()
    {
        playerCollider = GetComponent<Collider2D>();
        //_gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _gameManager = FindObjectOfType<GameManager>();
        if (playerCollider.IsTouchingLayers(LayerMask.GetMask("Hazard")))
        {
            Debug.Log("outch");
            audioController.PlayDeathSound();
            _gameManager.ProcessPlayerDeath();
            
        }

    }
}
