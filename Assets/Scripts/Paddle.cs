using UnityEngine;

public class Paddle : MonoBehaviour
{
    public Rigidbody2D rgb {  get; private set; }

    public Vector2 diraction { get; private set; }

    public float speed = 30f;

    public float maxBoundsAngle = 70f;

    public void Awake()
    {
        this.rgb = GetComponent<Rigidbody2D>();
    }

    public void ResetPaddle()
    {
        this.transform.position = new Vector2(0f, this.transform.position.y);
        this.rgb.velocity = Vector2.zero;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.diraction = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.diraction = Vector2.right;
        }
        else
        {
            this.diraction = Vector2.zero;
        }
    }


    private void FixedUpdate()
    {
        if (this.diraction != Vector2.zero)
        {
            this.rgb.AddForce(this.diraction * this.speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            Vector3 paddlePosition = this.transform.position;
            Vector2 contactPoint = collision.GetContact(0).point;

            float offset = paddlePosition.x = contactPoint.x;
            float widhth = collision.otherCollider.bounds.size.x / 2;

            float currnetAngle = Vector2.SignedAngle(Vector2.up, ball.rgb.velocity);
            float bounceAngle = (offset / widhth) * this.maxBoundsAngle;

            float newAngle = Mathf.Clamp(currnetAngle + bounceAngle, -this.maxBoundsAngle, this.maxBoundsAngle);

            Quaternion rotation = Quaternion.AngleAxis(newAngle , Vector3.forward);
            ball.rgb.velocity = rotation * Vector2.up * ball.rgb.velocity.magnitude;
        }
    }
}
