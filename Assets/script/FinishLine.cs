using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    private GameManager _gameManager;
    [SerializeField] private PlayerAudioController audioController;
    [SerializeField] private ParticleSystem finishEffect;
    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        finishEffect.Play();
        audioController.PlayFinishline();
        _gameManager.TriggernextScene();
    }
}
