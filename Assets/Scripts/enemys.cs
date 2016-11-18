using UnityEngine;
using System.Collections;

public class enemys : MonoBehaviour {
    int counter;
    void Update()
    {
        if(counter == 4)
        {
            Application.LoadLevel("1");
        }
    }
    // Use this for initialization
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Damage")
        {
            GameState.Points += 100;
            counter++;
            Destroy(gameObject);
        }
    }
  
}
