using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary boundary;

    private Rigidbody rb;

    private void Start()
    {
        james = 0;
        rb = GetComponent<Rigidbody>();
        WeaponSource.clip = WeaponClip;
    }

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public int james;

    private float nextFire;

    public AudioClip WeaponClip;

    public AudioSource WeaponSource;

    void Update ()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + (fireRate - james);
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            WeaponSource.Play();
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3
        (
             Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
             0.0f,
             Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }

    public void rapidfire()
    {
        james = 1;
    }
}