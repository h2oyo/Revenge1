using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
    public float stretchLimit = 3f;
    public LineRenderer frontSling;
    public LineRenderer backSling;

    private SpringJoint2D springJoint;
    private Transform slingShot;
    private bool click;
    private Ray mouseRay;
    private Ray frontSlingToP;
    private float stretchLimit2;
    private Rigidbody2D proRig;
    private Vector2 oldVelocity;
    private float proRad;

    public GameObject BirdToThrow;
    void Awake()
    {
        springJoint = GetComponent<SpringJoint2D>();
        slingShot = springJoint.connectedBody.transform;
        mouseRay = new Ray(slingShot.position, Vector3.zero);
        frontSlingToP = new Ray(frontSling.transform.position, Vector3.zero);
        stretchLimit2 = stretchLimit * stretchLimit;
        proRig = GetComponent<Rigidbody2D>();
        CircleCollider2D circle = GetComponent<Collider2D>() as CircleCollider2D;
        //proRad = circle.radius;
    }
	void Start () {
        DrawSling();
	}
	
	void Update () {
        if(click)
        Drag();
        if(springJoint != null)
        {
           if(!proRig.isKinematic && oldVelocity.sqrMagnitude > proRig.velocity.sqrMagnitude)
            {
                BirdToThrow.GetComponent<Bird>().OnThrow();
                Destroy(springJoint);
                proRig.velocity = oldVelocity;
         
            }
            DrawSlingUpdate();
            if (!click)
            {
                oldVelocity = proRig.velocity;
            }
        }
	}

    void DrawSling ()
    {
        frontSling.SetPosition(0, frontSling.transform.position);
        backSling.SetPosition(0, backSling.transform.position);
        frontSling.sortingOrder = 3;
        backSling.sortingOrder = 1;
    }
    void DrawSlingUpdate()
    {
        Vector2 slingToProjectile = transform.position - frontSling.transform.position;
        frontSlingToP.direction = slingToProjectile;
        Vector3 point = frontSlingToP.GetPoint(slingToProjectile.magnitude + proRad);
        frontSling.SetPosition(1, point);
        backSling.SetPosition(1, point);

    }
    void OnMouseDown()
    {
        springJoint.enabled = false;
        click = true;

    }
    void OnMouseUp()
    {
        springJoint.enabled = true;
        proRig.isKinematic = false;
        click = false;
    }
    void Drag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 slingToMouse = mousePos - slingShot.position;
        if(slingToMouse.sqrMagnitude > stretchLimit2)
        {
            mouseRay.direction = slingToMouse;
            mousePos = mouseRay.GetPoint(stretchLimit);
        }
        mousePos.z = 0;
        transform.position = mousePos;
    }
}
