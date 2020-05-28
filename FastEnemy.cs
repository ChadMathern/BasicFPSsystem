using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FastEnemy : MonoBehaviour
{
    
    public Vector3 Player;
    int MoveSpeed = 6;
    int MinDist = 1;

    public int damage = 1;
    public GameObject BadMan;
    public Rigidbody rb;
    public float jumpforce;

    public AudioClip HurtSound;
    private AudioSource source;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();

    }

    void Update()
    {
        Player = GameObject.FindWithTag("Player").transform.position;
        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player) >= MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        }


    }

    void OnTriggerEnter(Collider other)
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();

        if (player != null)
        {
            player.Hurt(damage);
            source.PlayOneShot(HurtSound);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {

            rb.velocity = new Vector3(rb.velocity.x, jumpforce);
        }
    }
}