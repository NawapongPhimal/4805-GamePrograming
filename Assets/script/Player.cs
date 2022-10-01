using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    #region SerializeFieldInput
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float moveInput;

    [SerializeField] private float jump = 10f;
    [SerializeField] private float speed = 5;

    [SerializeField] private BoxCollider2D PlayerCollision2D;
    [SerializeField] private LayerMask TileGroundlayer;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private CollectibleColor playerColor;
    [SerializeField] private PlayerAnimatorControll animatorController;
    [SerializeField] private PlayerAudioController audioController;

    [SerializeField] private float Coyotetime = 0.15f;
    private float CoyotetimeCounter;
    [SerializeField] private GameManager _gameManager;



    #endregion

    #region UpdateFunction
    private void Update()
    {
        animatorController.SetParameter(rb.velocity, isGrounded());


        if (isGrounded())
        {
            CoyotetimeCounter = Coyotetime;
        }
        else
        {
            CoyotetimeCounter -= Time.deltaTime;
        }
    }
    

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        
    }
    #endregion

    #region Player action
    private void OnMove(InputValue value)
    {
        moveInput = value.Get<float>();
        FlipPlayer();
    }

    
    private void OnJump(InputValue value)
    {
        if (value.isPressed && CoyotetimeCounter > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(transform.up * jump, ForceMode2D.Impulse);
            CoyotetimeCounter = 0f;
            audioController.PlayJumpSound();
        }
    }

    private void OnQuit(InputValue value)
    {
        if (value.isPressed)
        {
            _gameManager = FindObjectOfType<GameManager>();
            _gameManager.LoadMainMenu();
        }
    }

    #endregion

    #region Trigged
    private void OnCollisionEnter2D(Collision2D player)
    {
        if (player.gameObject.CompareTag("ground")){
            Debug.Log("Is Grounded");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Collectible collectible))
        {
            CollectibleColor playerColor = collectible.color;

            switch (playerColor)
            {
                case CollectibleColor.Yellow:
                    spriteRenderer.color = Color.yellow;
                    break;
                case CollectibleColor.Green:
                    spriteRenderer.color = Color.green;
                    break;
                case CollectibleColor.Blue:
                    spriteRenderer.color = Color.blue;
                    break;
            }
        }
    }

    private bool isGrounded()
    {
        float Height = 0.015f;
        Bounds boxBound = PlayerCollision2D.bounds;
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxBound.center, boxBound.size, 0f, 
                                    Vector2.down, Height, TileGroundlayer);

        Color raycastColor;
        if (raycastHit2D.collider != null)
        {
            raycastColor = Color.green;
        }
        else
        {
            raycastColor = Color.blue;
        }
        Debug.DrawRay(boxBound.center + new Vector3(boxBound.extents.x, 0), Vector2.down * (boxBound.extents.y + Height), raycastColor);
        return raycastHit2D.collider != null;

    }
    #endregion

    private void FlipPlayer()
    {
        if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}