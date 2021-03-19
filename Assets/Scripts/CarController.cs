using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 10f;
    public float torqueForce = 10f;

    private Rigidbody2D _rigidbody2D;

    private void Awake() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        _rigidbody2D.velocity = ForwardVelocity();
        float horizontalnput = Input.GetAxis("Horizontal");
        float verticalnput = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift)) {
            _rigidbody2D.AddForce(transform.right * speed);
        }

        _rigidbody2D.AddTorque(verticalnput * torqueForce);
    }

    Vector2 ForwardVelocity() {
        Vector2 lhs = _rigidbody2D.velocity;
        //Vector2 rhs = new Vector2(transform.position.x, transform.position.y);
        Vector2 rhs = transform.right;
        return transform.right * Vector2.Dot(lhs, rhs);
    }
}
