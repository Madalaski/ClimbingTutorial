using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimbing1 : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector2 input = SquareToCircle(new Vector2(h, v));

        RaycastHit hit;
        if (Physics.Raycast(transform.position, // Position
                            transform.forward, // Direction
                            out hit)) // Hit Data
        {
            transform.forward = -hit.normal;
            rb.position = Vector3.Lerp(rb.position,
                                        hit.point + hit.normal * 0.51f,
                                        10f * Time.fixedDeltaTime);
        }

        rb.velocity = transform.TransformDirection(input) * speed;
    }

    Vector2 SquareToCircle(Vector2 input)
    {

        return (input.sqrMagnitude >= 1f) ? input.normalized : input;
    }
}
