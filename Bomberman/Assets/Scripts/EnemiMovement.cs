using UnityEngine;

public class EnemiMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;

    private int rnd = 0;

    [SerializeField] private LayerMask layer;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        rnd = Random.Range(0, 4);

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            switch (rnd)
            {
                case 0:
                    if (!Physics2D.OverlapCircle(Vector2.up, .2f, layer))
                    {
                        movePoint.Translate(Vector2.up);
                    }
                    break;
                case 1:
                    if (!Physics2D.OverlapCircle(Vector2.down, .2f, layer))
                    {
                        movePoint.Translate(Vector2.down);
                    }
                    break;
                case 2:
                    if (!Physics2D.OverlapCircle(Vector2.right, .2f, layer))
                    {
                        movePoint.Translate(Vector2.right);
                    }
                    break;
                case 3:
                    if (!Physics2D.OverlapCircle(Vector2.left, .2f, layer))
                    {
                        movePoint.Translate(Vector2.left);
                    }
                    break;
                default:
                    break;
            }
        }
    }

    //private void MovePlayer()
    //{
    //    transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

    //    if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
    //    {
    //        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
    //        {
    //            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, layer))
    //            {
    //                movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
    //            }
    //        }

    //        if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
    //        {
    //            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, layer))
    //            {
    //                movePoint.position += new Vector3(Input.GetAxisRaw("Vertical"), 0f, 0f);
    //            }
    //        }
    //    }
    //}
}
