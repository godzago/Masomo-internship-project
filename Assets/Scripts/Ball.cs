using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rgb { get; private set; }

    public float speed = 500f;

    public void Awake()
    {
        this.rgb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Invoke(nameof(SetRandomTrayjectory), 1f);
    }

    private void SetRandomTrayjectory()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;

        this.rgb.AddForce(force.normalized * this.speed);
    }
}
