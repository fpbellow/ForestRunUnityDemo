using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectLeft : MonoBehaviour
{
    private float speed = 10f;
    private float leftLimit = -10.5f;
    
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.isGameActive)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        
        if (gameObject.CompareTag("Obstacle") && gameObject.transform.position.x < leftLimit)
        {
            Destroy(gameObject); 
        }
    }
}
