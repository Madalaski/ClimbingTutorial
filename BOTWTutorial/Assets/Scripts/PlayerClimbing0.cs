using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimbing0 : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector2 input = SquareToCircle(new Vector2(h, v));

        if (rb)
        {
            rb.velocity = transform.TransformDirection(input) * speed;
        }
    }

    Vector2 SquareToCircle(Vector2 input)
    {
        return (input.sqrMagnitude >= 1f) ? input.normalized : input;
    }
}
