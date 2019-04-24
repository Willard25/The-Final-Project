using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    public float speed;
    public int multi;
    public bool level = false;

    private Rigidbody rb;

    void Start()
    {
        if (level == false)
        {
            multi = 1;
            rb = GetComponent<Rigidbody>();
            rb.velocity = transform.forward * speed * multi;
        }else if (level == true)
        {
            multi = 2;
            rb = GetComponent<Rigidbody>();
            rb.velocity = transform.forward * speed * multi;
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            level = true;
            Start();
            
        }
    }
}