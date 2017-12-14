using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class tracer : MonoBehaviour {

    public Ray r;
    public float wavespeed = 10F;
    public int bounces = 3;
    public int resolution = 4;
    public AudioListener listener;
    public AudioSource source;

    private float volume;
    private float x; 
    private float y; 
    private float z;
    private int res;
	// Use this for initialization
	void Start () {
		r = new Ray(transform.position, transform.forward);
		listener = (AudioListener)FindObjectOfType(typeof(AudioListener));
		source = GetComponent<AudioSource>();
		res = resolution;

	}
	
	// Update is called once per frame
	void Update () {

		volume = 0;

		//Direct sound waves
		//Vector3 dir = listener.transform.position - transform.position;
		//calcvolume(listener.transform.position, dir.magnitude);

		for(x = -1; x <= 1; x+= 2F/res){
			for(y = -1; y <= 1; y+= 2F/res ){
				for(z = -1; z <= 1; z+= 2F/res ){
					r.origin = transform.position;
					r.direction = new Vector3(x, y, z);

					pathtrace(r, bounces, 0);
				}
			}
		}
		source.volume = volume;
		Debug.Log(volume);

	}
	void pathtrace(Ray r, int depth, float len){
		RaycastHit hit;
        if (Physics.Raycast(r, out hit)) {
            Vector3 invec = hit.point - r.origin;
            Vector3 reflvec = Vector3.Reflect(invec, hit.normal);
            Ray refl = new Ray(hit.point, reflvec);
            len += invec.magnitude;
            calcvolume(hit.point, len);
            //Debug.DrawRay(r.origin, invec, Color.cyan);

            
            if (depth > 0)
            	pathtrace(refl, depth - 1, len);
        }
	}
	void calcvolume(Vector3 pos, float dist){
		
		Vector3 dir = listener.transform.position - pos;
		Ray path = new Ray(pos, dir);
		RaycastHit hit;
        if (Physics.Raycast(path, out hit, dir.magnitude)) {
        	if(hit.collider.gameObject.name.Equals("Player")){
        		volume += 1/((float)Math.Sqrt(res) * dist * dist);
        	}

        }
	}
}
