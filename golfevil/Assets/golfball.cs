using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class golfball : MonoBehaviour
{
    Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Launch(100f);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(0.0f, 0.0f, 5.0f);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(0.0f, 0.0f, -5.0f);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.rotation = Quaternion.identity;
        }
    }

    public void Reset()
    {
        transform.rotation = Quaternion.identity;
    }

    public void RotateBall(float angle)
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
    }

    // launch ball in direction based on angle and power
    public void Launch(float force)
    {
        body.AddForce(transform.up * force);
    }
}
