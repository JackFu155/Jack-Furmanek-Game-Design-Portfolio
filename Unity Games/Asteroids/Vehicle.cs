using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour {

    public float accelRate;                     // Small, constant rate of acceleration
    public Vector3 vehiclePosition;             // Local vector for movement calculation
    public Vector3 direction;                   // Way the vehicle should move
    public Vector3 velocity;                    // Change in X and Y
    public Vector3 acceleration;                // Small accel vector that's added to velocity
    public float angleOfRotation;               // 0 
    public float maxSpeed;                      // 0.5 per frame, limits mag of velocity
    private int bulletSpeed = 10;
    public BoxCollider2D box;
    public GameObject bullet;
    public List<GameObject> bullets;
    public bool fire = true;

    // Use this for initialization
    void Start ()
    {
        vehiclePosition = new Vector3(0, 0, 0);     // Or you could say Vector3.zero
        direction = new Vector3(1, 0, 0);           // Facing right
        velocity = new Vector3(0, 0, 0);            // Starting still (no movement)
    }
	
	// Update is called once per frame
	void Update ()
    {
        RotateVehicle();

        Drive();

        SetTransform();

        Wrap();

        Fire();

        Limits();
    }

    /// <summary>
    /// Allows us to create the moveable vehicle
    /// </summary>
    public void SetTransform()
    {
        transform.rotation = Quaternion.Euler(0, 0, angleOfRotation);
        transform.position = vehiclePosition;
    }

    /// <summary>
    /// Allows us to acclerate the vehicle forward in any direction it is facing
    /// </summary>
    public void Drive()
    {
        // Accelerate
        // Small vector that's added to velocity every frame
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction = Vector3.Normalize(direction);
            acceleration = accelRate * direction;

            // We used to use this, but acceleration will now increase the vehicle's "speed"
            // Velocity will remain intact from one frame to the next
            //velocity = direction * speed;             // Unnecessary
            velocity += acceleration;

            acceleration = Vector3.zero;

            // Limit velocity so it doesn't become too large
            velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        }
        //Deals with what happens when the Up Arrow is released and the vehicle begins to decelerate
        else
        {
            //Allows for a bug that involves rotation to be taken care of using the values that if x or y is negative or zero, they both go to zero
            if (velocity.x <= 0)
            {
                acceleration = accelRate * direction;
                velocity -= acceleration / 10;
                velocity.x = 0;
                velocity.y = 0;
            }
            else if (velocity.y <= 0)
            {
                acceleration = accelRate * direction;
                velocity -= acceleration / 10;
                velocity.x = 0;
                velocity.y = 0;
            }
            //Otherwise, it decelerates like normal
            else
            {
                acceleration = accelRate * direction;
                velocity -= acceleration;
            }

        }
        // Add velocity to vehicle's position
        vehiclePosition += velocity;
    }

    /// <summary>
    /// Allows us to rotate the vehicle by pressing the left and right arrow keys
    /// </summary>
    public void RotateVehicle()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            angleOfRotation += 5;
            direction = Quaternion.Euler(0, 0, 5) * direction;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            angleOfRotation -= 5;
            direction = Quaternion.Euler(0, 0, -5) * direction;
        }
    }

    /// <summary>
    /// Fires bullets when the spacebar is pressed
    /// </summary>
    public void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space) && fire == true)
        {
            Vector3 bulletPos = direction.normalized;
            Vector3 difference = vehiclePosition + bulletPos;
            GameObject newBullet = Instantiate(bullet, difference, Quaternion.identity);
            //float rotZ = newBullet.rotation.z;
            newBullet.transform.rotation = Quaternion.Euler(0, 0, angleOfRotation - 90);
            //Debug.Log(newBullet.transform.rotation);
            if(bullets.Count <= 3)
            {
                bullets.Add(newBullet);
            }
        }

        for(int i = 0; i < bullets.Count; i++)
        {
            bullets[i].transform.position += direction;
        }
    }

    /// <summary>
    /// Allows for the generated bullets to be removed if they reach the outer limits
    /// In case any astroids appear outside the screen, the method allows for an extra 1f of space to destroy them
    /// </summary>
    public void Limits()
    {
        //If the bullets are there
        if(bullets.Count > 0)
        {
            //Loops through the created list of bullets and checks their position
            for (int i = 0; i < bullets.Count; i++)
            {
                GameObject bull = bullets[i];
                if(bullets[i].transform.position.x <= -13 || bullets[i].transform.position.x >= 13)
                {
                    //Debug.Log("hereX");
                    bullets.Remove(bullets[i]);
                    Destroy(bull);
                   
                }
                if (bullets[i].transform.position.y <= -6 || bullets[i].transform.position.y >= 6)
                {
                    //Debug.Log("hereY");
                    bullets.Remove(bullets[i]);
                    Destroy(bull);
                   
                }
                //Debug.Log("Hello");
            }
        }
        
    }

    public void Wrap()
    {
        //The screen resolution goes from roughly 30 across and 9 units down
        //If the vehicle goes beyond the middle values of these things, it appears on the other side of the respcetive position it is in
        if (vehiclePosition.x > 12)
        {
            vehiclePosition.x = -12;
        }
        if (vehiclePosition.x < -12)
        {
            vehiclePosition.x = 12;
        }
        if (vehiclePosition.y > 4.5)
        {
            vehiclePosition.y = -4.5f;
        }
        if (vehiclePosition.y < -4.5)
        {
            vehiclePosition.y = 4.5f;
        }
    }
}
