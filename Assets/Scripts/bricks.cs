using UnityEngine;
using System.Collections;

public class bricks : MonoBehaviour
{


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<Rigidbody2D>() == null) return;

        float damage = col.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude * 7;

        if (damage >= 10)

            Health -= damage;

        if (Health <= 0) { GameState.Points += 10; Destroy(this.gameObject); }
    }

    public float Health;

}
