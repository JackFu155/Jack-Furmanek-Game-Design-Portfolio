using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

    public GameObject[] objects = new GameObject[3];
    public GameObject ship;
    private SpriteRenderer shipSprite;
    public List<GameObject> bullets = new List<GameObject>();
    private List<GameObject> numObjectsSmall;
    private List<GameObject> numObjectsMedium;
    private List<GameObject> numObjectsLarge;
    private int level = 0;
    private int score = 0;
    private int health = 3;
    private bool ended = false;
    private bool ishit = false;
    private float count = 0;

	// Use this for initialization
	void Start ()
    {
        ship = GameObject.FindGameObjectWithTag("ship");
        shipSprite = ship.GetComponent<SpriteRenderer>();
        numObjectsSmall = new List<GameObject>();
        numObjectsMedium = new List<GameObject>();
        numObjectsLarge = new List<GameObject>();
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(health > 0)
        {
            bullets = ship.GetComponent<Vehicle>().bullets;

            //If there are no more objects in any list, it goes to the next level
            if (numObjectsSmall.Count == 0 && numObjectsMedium.Count == 0 && numObjectsLarge.Count == 0)
            {
                level += 1;
                if (level <= 5)
                {

                    for (int i = 0; i < level; i++)
                    {
                        //Generates random x and y positions for each object
                        float x1 = Generator(-10.5f, 10.5f);
                        float y1 = Generator(-4, 4);
                        numObjectsSmall.Add(Instantiate(objects[0], new Vector3(x1, y1, 0), Quaternion.identity));
                    }

                }
                else if (level > 5 && level <= 10)
                {

                    for (int i = 0; i < level; i++)
                    {
                        //Generates random x and y positions for each object
                        float x1 = Generator(-10.5f, 10.5f);
                        float y1 = Generator(-4, 4);
                        numObjectsSmall.Add(Instantiate(objects[0], new Vector3(x1, y1, 0), Quaternion.identity));
                    }
                    for (int i = 0; i < level - 5; i++)
                    {
                        //Generates random x and y positions for each object
                        float x1 = Generator(-10.5f, 10.5f);
                        float y1 = Generator(-4, 4);
                        numObjectsMedium.Add(Instantiate(objects[1], new Vector3(x1, y1, 0), Quaternion.identity));
                    }
                }
                else if (level > 10)
                {

                    for (int i = 0; i < level; i++)
                    {
                        //Generates random x and y positions for each object
                        float x1 = Generator(-10.5f, 10.5f);
                        float y1 = Generator(-4, 4);
                        numObjectsSmall.Add(Instantiate(objects[0], new Vector3(x1, y1, 0), Quaternion.identity));
                    }
                    for (int i = 0; i < level - 5; i++)
                    {
                        //Generates random x and y positions for each object
                        float x1 = Generator(-10.5f, 10.5f);
                        float y1 = Generator(-4, 4);
                        numObjectsMedium.Add(Instantiate(objects[1], new Vector3(x1, y1, 0), Quaternion.identity));
                    }
                    for (int i = 0; i < level - 10; i++)
                    {
                        //Generates random x and y positions for each object
                        float x1 = Generator(-10.5f, 10.5f);
                        float y1 = Generator(-4, 4);
                        numObjectsLarge.Add(Instantiate(objects[2], new Vector3(x1, y1, 0), Quaternion.identity));
                    }
                }
            }
            //If there are objects in the level, the collsion methods are called
            else
            {
                //Ship Collisions with small asteroids
                if (numObjectsSmall.Count > 0)
                {
                    for (int i = 0; i < numObjectsSmall.Count; i++)
                    {
                        ShipCollision(ship, numObjectsSmall[i]);
                        if (health <= 0)
                        {
                            ended = true;
                        }
                    }
                    //Asteroids' collison with bullets
                    for (int i = 0; i < numObjectsSmall.Count; i++)
                    {
                        for (int j = 0; j < bullets.Count; j++)
                        {
                            DestroySmall(numObjectsSmall[i], bullets[j], i, j);
                        }
                    }
                }
                //Ship Collisions with medium asteroids
                if (numObjectsMedium.Count > 0)
                {
                    for (int i = 0; i < numObjectsMedium.Count; i++)
                    {
                        ShipCollision(ship, numObjectsMedium[i]);
                        if (health <= 0)
                        {
                            ended = true;
                        }
                    }
                    //Asteroids' collison with bullets
                    for (int i = 0; i < numObjectsMedium.Count; i++)
                    {
                        for (int j = 0; j < bullets.Count; j++)
                        {
                            DestroyMedium(numObjectsMedium[i], bullets[j], i, j);
                        }
                    }
                }
                //Ship Collisions with large asteroids
                if (numObjectsLarge.Count > 0)
                {
                    for (int i = 0; i < numObjectsLarge.Count; i++)
                    {
                        ShipCollision(ship, numObjectsLarge[i]);
                        if (health <= 0)
                        {
                            ended = true;
                        }
                    }
                    //Asteroids' collison with bullets
                    for (int i = 0; i < numObjectsLarge.Count; i++)
                    {
                        for (int j = 0; j < bullets.Count; j++)
                        {
                            DestroyLarge(numObjectsLarge[i], bullets[j], i, j);
                        }
                    }
                }
            }
        }
        //Checks for an endgame and then resets if health becomes <= 0
        else if(health <= 0)
        {
            health = 3;
            level = 0;
            score = 0;
            foreach(GameObject ast in numObjectsSmall)
            {
                Destroy(ast);
            }
            foreach (GameObject ast in numObjectsMedium)
            {
                Destroy(ast);
            }
            foreach (GameObject ast in numObjectsLarge)
            {
                Destroy(ast);
            }
            numObjectsSmall.Clear();
            numObjectsMedium.Clear();
            numObjectsLarge.Clear();
        }
        
    }

    /// <summary>
    /// Checks for collison between the ship and an asteroid
    /// </summary>
    /// <param name="ship"></param>
    /// <param name="asteroid"></param>
    public void ShipCollision(GameObject ship, GameObject asteroid)
    {
        if(ishit == false)
        {
            count = 0;
        }
        else
        {
            count += Time.deltaTime;
            //Debug.Log(count);
            if(count >= 3.0f)
            {
                ishit = false;
            }
        }

        //for levels 1 - 5, small asteroids are generated
        if (level <= 5)
        {
            if (numObjectsSmall.Count > 0)
            {
                for (int i = 0; i < numObjectsSmall.Count; i++)
                {
                    float dist = Vector3.Distance(ship.transform.position, asteroid.transform.position);
                    if (dist < 0.7f && ishit == false)
                    {
                        health -= 1;
                        ishit = true;
                    }
                }
            }
        }
        //Once it becomes level 6 to 10, medium asteroids are generated
        else if (level > 5 && level <= 10)
        {
            if (numObjectsSmall.Count > 0)
            {
                for (int i = 0; i < numObjectsSmall.Count; i++)
                {
                    float dist = Vector3.Distance(ship.transform.position, asteroid.transform.position);
                    if (dist < 0.7f && ishit == false)
                    {
                        health -= 1;
                        ishit = true;
                    }
                }
            }
            if (numObjectsMedium.Count > 0)
            {
                for (int i = 0; i < numObjectsMedium.Count; i++)
                {
                    float dist = Vector3.Distance(ship.transform.position, asteroid.transform.position);
                    if (dist < 1f && ishit == false)
                    {
                        health -= 1;
                        ishit = true;
                    }
                }
            }
        }

        //Once it becomes level 11 and above, large asteroids are generated
        else if (level > 10)
        {
            if (numObjectsSmall.Count > 0)
            {
                for (int i = 0; i < numObjectsSmall.Count; i++)
                {
                    float dist = Vector3.Distance(ship.transform.position, numObjectsSmall[i].transform.position);
                    if (dist < 0.7f && ishit == false)
                    {
                        health -= 1;
                        ishit = true;
                    }
                }
            }
            if (numObjectsMedium.Count > 0)
            {
                for (int i = 0; i < numObjectsMedium.Count; i++)
                {
                    float dist = Vector3.Distance(ship.transform.position, numObjectsMedium[i].transform.position);
                    if (dist < 1f && ishit == false)
                    {
                        health -= 1;
                        ishit = true;
                    }
                }
            }
            if (numObjectsLarge.Count > 0)
            {
                for (int i = 0; i < numObjectsLarge.Count; i++)
                {
                    float dist = Vector3.Distance(ship.transform.position, numObjectsSmall[i].transform.position);
                    if (dist < 2f && ishit == false)
                    {
                        health -= 1;
                        ishit = true;
                    }
                }
            }
        }
    }

    /// <summary>
    /// Allows us to get rid of small asteroids if collision conditions are met
    /// </summary>
    /// <param name="object1"></param>
    /// <param name="object2"></param>
    /// <param name="i"></param>
    /// <param name="j"></param>
    public void DestroySmall(GameObject object1, GameObject object2, int i, int j)
    {   
        float dist = Vector3.Distance(object1.transform.position, object2.transform.position);
        if (dist < 1f)
        {
            GameObject asteroid = object1;
            GameObject bull = object2;
            numObjectsSmall.Remove(numObjectsSmall[i]);
            Destroy(asteroid);
            bullets.Remove(bullets[j]);
            Destroy(bull);
            score += 20;
        }
    }

    /// <summary>
    /// Allows us to get rid of medium asteroids if collision conditions are met
    /// </summary>
    /// <param name="object1"></param>
    /// <param name="object2"></param>
    /// <param name="i"></param>
    /// <param name="j"></param>
    public void DestroyMedium(GameObject object1, GameObject object2, int i, int j)
    {
        float dist = Vector3.Distance(object1.transform.position, object2.transform.position);
        if (dist < 1f)
        {
            GameObject asteroid = object1;
            GameObject bull = object2;
            //creates 4 new small asteroids to replace it
            numObjectsSmall.Add(Instantiate(objects[0], new Vector3(asteroid.transform.position.x + 1, asteroid.transform.position.y, 0), Quaternion.identity));
            numObjectsSmall.Add(Instantiate(objects[0], new Vector3(asteroid.transform.position.x - 1, asteroid.transform.position.y, 0), Quaternion.identity));
            numObjectsSmall.Add(Instantiate(objects[0], new Vector3(asteroid.transform.position.x, asteroid.transform.position.y + 1, 0), Quaternion.identity));
            numObjectsSmall.Add(Instantiate(objects[0], new Vector3(asteroid.transform.position.x, asteroid.transform.position.y - 1, 0), Quaternion.identity));
            numObjectsMedium.Remove(numObjectsMedium[i]);
            Destroy(asteroid);
            bullets.Remove(bullets[j]);
            Destroy(bull);
            score += 50;
        }
    }

    /// <summary>
    /// Allows us to get rid of large asteroids if collision conditions are met
    /// </summary>
    /// <param name="object1"></param>
    /// <param name="object2"></param>
    /// <param name="i"></param>
    /// <param name="j"></param>
    public void DestroyLarge(GameObject object1, GameObject object2, int i, int j)
    {
        float dist = Vector3.Distance(object1.transform.position, object2.transform.position);
        if (dist < 1f)
        {
            GameObject asteroid = object1;
            GameObject bull = object2;
            //creates 4 new medium asteroids to replace it
            numObjectsMedium.Add(Instantiate(objects[1], new Vector3(asteroid.transform.position.x + 1, asteroid.transform.position.y, 0), Quaternion.identity));
            numObjectsMedium.Add(Instantiate(objects[1], new Vector3(asteroid.transform.position.x - 1, asteroid.transform.position.y, 0), Quaternion.identity));
            numObjectsMedium.Add(Instantiate(objects[1], new Vector3(asteroid.transform.position.y, asteroid.transform.position.y + 1, 0), Quaternion.identity));
            numObjectsMedium.Add(Instantiate(objects[1], new Vector3(asteroid.transform.position.y, asteroid.transform.position.y - 1, 0), Quaternion.identity));
            numObjectsLarge.Remove(numObjectsLarge[i]);
            Destroy(asteroid);
            bullets.Remove(bullets[j]);
            Destroy(bull);
            score += 100;
        }
    }
    
    /// <summary>
    /// Generates a random
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    float Generator(float min, float max)
    {
        Random rand = new Random();
        float maxed = Random.Range(min, max + 1);
        return maxed;
    }

    /// <summary>
    /// Displays stats to the player
    /// </summary>
    private void OnGUI()
    {
        GUI.color = Color.white;

        GUI.skin.box.fontSize = 20;

        GUI.skin.box.wordWrap = true;

        GUI.Box(new Rect(1000, 10, 200, 200), "Level: " + level + "\nSmall Asteroids: " + numObjectsSmall.Count + "\nMedium Asteroids: " + numObjectsMedium.Count + "\nLarge Asteroids: " + numObjectsLarge.Count + "\nHealth: " + health + "\nBullets: " + bullets.Count + "\nScore: " + score);
    }
}
