using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Rigidbody2D rb;

    private Vector2 direction = Vector2.down;

    public float speed = 5f;

    [SerializeField] private KeyCode inputUp = KeyCode.W;
    [SerializeField] private KeyCode inputDown = KeyCode.S;
    [SerializeField] private KeyCode inputRight = KeyCode.D;
    [SerializeField] private KeyCode inputLeft = KeyCode.A;

    [SerializeField] public AnimatedSpriteRenderer spriteRendererUp;
    [SerializeField] public AnimatedSpriteRenderer spriteRendererDown;
    [SerializeField] public AnimatedSpriteRenderer spriteRendererRight;
    [SerializeField] public AnimatedSpriteRenderer spriteRendererLeft;
    [SerializeField] public AnimatedSpriteRenderer spriteRendererDeath;

    private AnimatedSpriteRenderer activeSpriteRenderer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        activeSpriteRenderer = spriteRendererDown;
    }

    private void Update()
    {
        if (Time.timeScale > 0)
        {
            if (Input.GetKey(inputUp))
            {
                SetDirection(Vector2.up, spriteRendererUp);
            }
            else if (Input.GetKey(inputDown))
            {
                SetDirection(Vector2.down, spriteRendererDown);
            }
            else if (Input.GetKey(inputRight))
            {
                SetDirection(Vector2.right, spriteRendererRight);
            }
            else if (Input.GetKey(inputLeft))
            {
                SetDirection(Vector2.left, spriteRendererLeft);
            }
            else
            {
                SetDirection(Vector2.zero, activeSpriteRenderer);
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 position = rb.position;
        Vector2 translation = direction * speed * Time.fixedDeltaTime;

        rb.MovePosition(position + translation);
    }

    private void SetDirection(Vector2 newDirection, AnimatedSpriteRenderer spriteRenderer)
    {
        direction = newDirection;

        spriteRendererUp.enabled = spriteRenderer == spriteRendererUp;
        spriteRendererDown.enabled = spriteRenderer == spriteRendererDown;
        spriteRendererRight.enabled = spriteRenderer == spriteRendererRight;
        spriteRendererLeft.enabled = spriteRenderer == spriteRendererLeft;

        activeSpriteRenderer = spriteRenderer;
        activeSpriteRenderer.idle = direction == Vector2.zero;
    }

    public void AnimationsDeath()
    {
        enabled = false;
        GetComponent<BombController>().enabled = false;

        spriteRendererUp.enabled = false;
        spriteRendererDown.enabled = false;
        spriteRendererRight.enabled = false;
        spriteRendererLeft.enabled = false;
        spriteRendererDeath.enabled = true;
    }
}
