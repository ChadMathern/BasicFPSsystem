using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    //our player script
    public PlayerCharacter thePlayer;
    //will serve as the restart point
    private Vector3 playerStartpoint;
    public GameObject[] Enemies;
    
    // Use this for initialization
    void Start()
    {
        playerStartpoint = thePlayer.transform.position;
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {

    }
    //new method that can be called from our PlayerController script
    public void RestartGame()
    {//starts our Coroutine below (IEnumerator restartGameCo()
        StartCoroutine("RestartGameCo");
    }


    public IEnumerator RestartGameCo()
    {

        //thePlayer.gameObject.SetActive(false);
        SceneManager.LoadScene("Scene1");
        yield return new WaitForSeconds(1f);
        thePlayer.transform.position = playerStartpoint;
        //thePlayer.gameObject.SetActive(true);
        thePlayer._health = 5;




    }
}