using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public Transform target1;
    public Transform leftBound;
    public Transform rightBound;
    bool weapon1;
    bool weapon2;
    private float arrowX;
    public float speed = 15.0f;

	void Start()
    {
        weapon1 = true;
    }
	void Update () {
 if(Input.GetKeyDown("1") )
        {
            weapon1 = true;
            weapon2 = false;
            
          
        }
        if (Input.GetKeyDown("2"))
        {
            weapon2 = true;
            weapon1 = false;
            
            
        }
        if (weapon1 == true)
        {
            arrowX = Input.GetAxis("Horizontal");
            Transform cam = GetComponent<Transform>();
            if (arrowX == 0)
            {
                Vector3 newPos = transform.position;
                newPos.x = target.transform.position.x;
                newPos.x = Mathf.Clamp(newPos.x, leftBound.transform.position.x, rightBound.transform.position.x);
                transform.position = newPos;
            }
            if (arrowX != 0)
            {
                cam.position = cam.position + (Vector3.right * speed * Time.deltaTime);
                float camX = cam.position.x;
                camX = Mathf.Clamp(camX, leftBound.transform.position.x, rightBound.transform.position.x);
                cam.position = new Vector3(camX, cam.position.y, cam.position.z);
            }
        }
        if (weapon2 == true)
        {
            arrowX = Input.GetAxis("Horizontal");
            Transform cam = GetComponent<Transform>();
            if (arrowX == 0)
            {
                Vector3 newPos = transform.position;
                newPos.x = target1.transform.position.x;
                newPos.x = Mathf.Clamp(newPos.x, leftBound.transform.position.x, rightBound.transform.position.x);
                transform.position = newPos;
            }
            if (arrowX != 0)
            {
                cam.position = cam.position + (Vector3.right * speed * Time.deltaTime);
                float camX = cam.position.x;
                camX = Mathf.Clamp(camX, leftBound.transform.position.x, rightBound.transform.position.x);
                cam.position = new Vector3(camX, cam.position.y, cam.position.z);
            }
        }
      
	}
}
