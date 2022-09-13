using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveInput;
    [SerializeField] private float jump = 5f;
    [SerializeField] private float speed = 2;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private CollectibleColor playerColor;

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<float>();
        Debug.Log($"Float of moveInput is {moveInput}");
    }

    private void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            Debug.Log($"{value} is pressed");
            rb.AddForce(transform.up * jump, ForceMode2D.Impulse);
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
            Destroy(collectible.gameObject);
        }
    }

}