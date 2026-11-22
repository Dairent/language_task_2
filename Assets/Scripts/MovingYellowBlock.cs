using UnityEngine;

public class MovingYellowBlock : MonoBehaviour
{
    public float speed = 2f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (Random.Range(0, 2) == 0) speed = -speed;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + Vector2.right * speed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ball"))
            speed = -speed;
    }
}