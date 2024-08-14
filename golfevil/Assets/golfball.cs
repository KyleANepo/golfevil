using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class golfball : MonoBehaviour
{
    Rigidbody2D body;
    public GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetBall ()
    {
        transform.rotation = Quaternion.identity;
        body.velocity = Vector2.zero;
        body.angularVelocity = 0;
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

    bool arrowToggle = false;

    public void ShowArrow()
    {
        arrow.SetActive(true);
        arrowToggle = true;
    }

    public void HideArrow()
    {
        arrow.SetActive(false);
        arrowToggle = false;
    }

    public void ToggleArrow()
    {
        if (arrowToggle)
        {
            arrow.SetActive(false);
            arrowToggle = false;
        }
        else
        {
            arrow.SetActive(true);
            arrowToggle = true;
        }
    }
}
