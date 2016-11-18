using UnityEngine;
using System.Collections;

public class Birdy : MonoBehaviour
{

    public float Health = 150f;
    // Use this for initialization
    void Start()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<Rigidbody2D>() == null) return;

        //if we are hit by a bird
        if (col.gameObject.tag == "Bird")
        {

            Destroy(gameObject);

        }
        else //we're hit by something else
        {
            //calculate the damage via the hit object velocity
            float damage = col.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude * 10;
            Health -= damage;




            if (Health <= 0) { GameState.Points += 100; Destroy(this.gameObject); }
        }
    }
}
