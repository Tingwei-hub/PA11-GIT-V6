using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    public int score;
    public Text scoreTXT;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        transform.position = transform.position + new Vector3(0 , verticalInput * speed * Time.deltaTime, 0);
        transform.position = new Vector3(0, Mathf.Clamp(transform.position.y, -3.9f, 3.9f), 0);
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("gameOver");
        }
        if(other.gameObject.tag == "Collider")
        {
            score += 1;
            scoreTXT.text = "Score : " + score;
           
        }
    }
}
