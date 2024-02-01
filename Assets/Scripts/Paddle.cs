using UnityEngine;

public class Paddle : MonoBehaviour
{
    public Rigidbody2D rgb {  get; private set; }

    public Vector2 diraction { get; private set; }

    public float speed = 30f;

    public void Awake()
    {
        this.rgb = GetComponent<Rigidbody2D>();
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
}
