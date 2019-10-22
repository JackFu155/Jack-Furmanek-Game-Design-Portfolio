using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    public Vector3 vehiclePosition;
    public Vector3 acceleration;
    public Vector3 direction;
    public Vector3 velocity;
    private bool friction = false;
    private float rotation;
    public Vector3 wind;
    public Vector3 wind2;
    public Vector3 wind3;
    public Vector3 gravity;

    public float mass;

    // Use this for initialization
    void Start ()
    {
        vehiclePosition = transform.position;
        rotation = transform.rotation.z;
    }
	
	// Update is called once per frame
	void Update ()
    {
        ApplyGravity(gravity);

        rotation += 3;

        velocity += acceleration * Time.deltaTime;
        vehiclePosition += velocity * Time.deltaTime;

        direction = velocity.normalized;

        acceleration = Vector3.zero;

        Bounce();

        transform.position = vehiclePosition;
    }

    /// <summary>
    /// Applies a gravity force to the asteroid
    /// </summary>
    /// <param name="force"></param>
    public void ApplyGravity(Vector3 force)
    {
        acceleration += force;
    }

    /// <summary>
    /// Allows the asteroids to bounce off the sides of the screen
    /// </summary>
    public void Bounce()
    {
        if (vehiclePosition.x >= 12)
        {
            velocity.x *= -1;
        }
        if (vehiclePosition.x <= -12)
        {
            velocity.x *= -1;
        }
        if (vehiclePosition.y >= 5)
        {
            velocity.y *= -1;
        }
        if (vehiclePosition.y <= -5)
        {
            velocity.y *= -1;
        }
    }
}
