using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{

    public float speed;
    private int score;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        health = 5;
    }

    // Update is called once per frame
    void Update()

    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.position += (move * speed * Time.deltaTime);
        if (health == 0)
        {
            Debug.Log("Game Over!");
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

    // Increment the score value when the player touches an object tagged pickup
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickup")
        {
            score++;
            Debug.Log("Score: " + score);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Trap")
        {
            health--;
            Debug.Log("Health: " + health);
        }
        if (other.gameObject.tag == "Goal")
        {
            Debug.Log("You win!");
        }
    }
}
