using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
using System;

[RequireComponent(typeof(AudioSource))]
public class sines : MonoBehaviour
{
    AudioSource audioSource;
    //precomputed intervals just in case
    /*private float[] pitchmap = {0.0F,
    							0.05945F,
    							0.12246F,
    							0.18921F,
    							0.259932F,
    							0.334841F,
    							0.414205F,
    							0.498318F,
    							0.587409F,
    							0.681795F,
    							0.781795F,
    							0.88775F,
    							1.0F};*/

    //A440							
    private int key = 69;
    private int offset = 0;

    //private Dictionary<String,int> keymap = new Dictionary<String, int>();
    private int[] min = {0,2,3,5,7,8,10,12};
    private int[] maj = {0,2,4,5,7,9, 11,12};
   	enum Keys {MAJOR, MINOR};
   	private Keys keykind = Keys.MAJOR;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = pitch(key);
        audioSource.loop = true;
    }

    float pitch(int pos){
    	var exp = (pos - 33F) * (1F/ 12F);
    	return (float)(55 * Math.Pow(2, exp));
    }
    float pitchmap(int interval){
    	return 1 + ((pitch(key+offset+interval) - pitch(key)) / pitch(key));
    }
    int scale(int pos){
    	if (keykind == Keys.MINOR) return min[pos];
    	if (keykind == Keys.MAJOR) return maj[pos];
    	return 0;

    }
    void Update()
    {
        if (Input.GetKeyDown("-")){
        	offset--;
        }
       	if (Input.GetKeyDown("=")){
        	offset++;
        }
        if (Input.GetKeyDown("q")){
        	
        }

        if (Input.GetKeyDown("1")) 
        {
        	audioSource.pitch = pitchmap(scale(0));
        	audioSource.Play();

        }
        if (Input.GetKeyDown("2")) 
        {
        	audioSource.pitch = pitchmap(scale(1));
        	audioSource.Play();

        }
        if (Input.GetKeyDown("3")) 
        {
        	audioSource.pitch = pitchmap(scale(2));
        	audioSource.Play();

        }
         if (Input.GetKeyDown("4")) 
        {
        	audioSource.pitch = pitchmap(scale(3));
        	audioSource.Play();

        }
        if (Input.GetKeyDown("7")) 
        {
        	audioSource.pitch = pitchmap(scale(4));
        	audioSource.Play();

        }
        if (Input.GetKeyDown("8")) 
        {
        	audioSource.pitch = pitchmap(scale(5));
        	audioSource.Play();

        }
        if (Input.GetKeyDown("9")) 
        {
        	audioSource.pitch = pitchmap(scale(6));
        	audioSource.Play();

        }
        if (Input.GetKeyDown("0")) 
        {
        	audioSource.pitch = pitchmap(scale(7));
        	audioSource.Play();

        }
        if (audioSource.isPlaying && (Input.GetKeyUp("1") 
        							|| Input.GetKeyUp("2")
        							|| Input.GetKeyUp("3")
        							|| Input.GetKeyUp("4")
        							|| Input.GetKeyUp("7")
        							|| Input.GetKeyUp("8")
        							|| Input.GetKeyUp("9")
        							|| Input.GetKeyUp("0"))){
        	audioSource.Stop();
        }
    }
}