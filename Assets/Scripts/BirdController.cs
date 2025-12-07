using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float flapForce = 5f;
    private Rigidbody2D rb;
    private bool isAlive = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isAlive) return;

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = Vector2.zero; // reset current downward speed
            rb.AddForce(Vector2.up * flapForce, ForceMode2D.Impulse);
        }

        // Optional: tilt the bird based on vertical speed
        float angle = Mathf.Clamp(rb.linearVelocity.y * 5f, -90f, 45f);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void Die()
    {
        isAlive = false;
        GameManager.Instance.GameOver();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }
}
