using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {

    public int hitPoints = 3;
    public Sprite damagedSprite;
    public float damageImpactSpeed;

    private int currentHitpoints;
    private float damageImpactspeed2;
    private SpriteRenderer spriteRenderer;
    private Collider2D objCollider2D;
    private Rigidbody2D objRigibody2D;
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHitpoints = hitPoints;
        damageImpactspeed2 = damageImpactSpeed * damageImpactSpeed;
        objCollider2D = GetComponent<Collider2D>();
        objRigibody2D = GetComponent<Rigidbody2D>();

	}
	
    void OnCollisionEnter2d (Collision2D collision)
    {
        if(collision.relativeVelocity.sqrMagnitude < damageImpactspeed2)
        {
            return;
        }
       // spriteRenderer.sprite = damagedSprite;
        currentHitpoints--;

        if(currentHitpoints <=0)
        {
            Death();
        }
    }

    void Death()
    {
        spriteRenderer.enabled = false;
        objCollider2D.enabled = false;
        objRigibody2D.isKinematic = true;
    }
	// Update is called once per frame
	void Update () {
	
	}
}
