using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private Animator jumpPadAnimation;
    [SerializeField] private float JumpPadbounce = 15f;
    [SerializeField] private PlayerAudioController audioController;

    private void OnCollisionEnter2D(Collision2D player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            jumpPadAnimation.SetTrigger("isTrigged");
            Debug.Log("Get jump");
            player.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * JumpPadbounce, ForceMode2D.Impulse);
            audioController.PlayJumppad();
        }
    }
    
}
