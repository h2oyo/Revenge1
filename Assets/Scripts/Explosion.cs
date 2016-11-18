using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

    public GameObject explosion;
	void OnCollisionEnter2D (Collision2D col) {
    
            Instantiate(explosion, transform.position, Quaternion.identity);
        StartCoroutine(DestroyAfter(1));
        gameObject.SetActive(false);
       


    }
    IEnumerator DestroyAfter(float seconds)
    {

        yield return new WaitForSeconds(seconds);
        Destroy(explosion);

    }
}
