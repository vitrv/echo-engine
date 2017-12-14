using UnityEngine;
 
[AddComponentMenu("controller for player movements")]
public class player : MonoBehaviour
{
	public float walkSpeed = 10F;
 
	void Start()
    {

    }
    void Update()
    {
	    //moverment and jumps
        if (Input.GetKey("w")) 
        {
        	var lookdir = transform.forward;
        	transform.localPosition += walkSpeed * lookdir;
        }
         if (Input.GetKey("s")) 
        {
        	var lookdir = transform.forward;
        	transform.localPosition -= walkSpeed * lookdir;
        }
         if (Input.GetKey("a")) 
        {
        	var rightdir = transform.right;
        	transform.localPosition -= walkSpeed * rightdir;
        }
         if (Input.GetKey("d")) 
        {
        	var rightdir = transform.right;
        	transform.localPosition += walkSpeed * rightdir;
        }
        /* if (Input.GetKeyDown("space")) 
        {
        	rb.velocity = new Vector3(0, 5, 0);
        }*/

    }

}