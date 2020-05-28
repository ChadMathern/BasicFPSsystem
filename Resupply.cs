using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resupply : MonoBehaviour {
    public Animator anim;
    public GameObject Player;
    public SimpleShoot ss;
    public AudioClip Pickup;
    private AudioSource source;
    //public Collider MyCollider;
    // Use this for initialization
    void Start () {
        anim = GetComponent <Animator>();
        source = GetComponent<AudioSource>();

    }
	
	//Update is called once per frame
	void OnTriggerEnter(Collider Other) {
    
        {
            anim.SetBool("Activate", true);
            ss.ReserveAmmo = 40;
            source.PlayOneShot(Pickup);
        }
        
	}

    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("Activate", false);
    }
}
