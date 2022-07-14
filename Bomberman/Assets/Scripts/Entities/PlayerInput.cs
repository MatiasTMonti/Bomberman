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

    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //activeSpriteRenderer = spriteRendererDown;
    }

    private void Update()
    {
        if (Time.timeScale > 0)
        {
            if (Input.GetKey(inputUp))
            {
                animator.SetFloat("SpeedUp", (float)inputUp);
                //SetDirection(Vector2.up, spriteRendererUp);
            }
            else if (Input.GetKey(inputDown))
            {
                animator.SetFloat("SpeedDown", (float)inputDown);
                //SetDirection(Vector2.down, spriteRendererDown);
            }
            else if (Input.GetKey(inputRight))
            {
                animator.SetFloat("SpeedRight", (float)inputRight);
                //SetDirection(Vector2.right, spriteRendererRight);
            }
            else if (Input.GetKey(inputLeft))
            {
                animator.SetFloat("SpeedLeft", (float)inputLeft);
                //SetDirection(Vector2.left, spriteRendererLeft);
            }
            else
            {
                animator.SetFloat("SpeedUp", 0);
                animator.SetFloat("SpeedDown", 0);
                animator.SetFloat("SpeedRight", 0);
                animator.SetFloat("SpeedLeft", 0);
                //SetDirection(Vector2.zero, activeSpriteRenderer);
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 position = rb.position;
        Vector2 translation = direction * speed * Time.fixedDeltaTime;

        rb.MovePosition(position + translation);
    }
}
