using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayShooter : MonoBehaviour {
    private Camera _camera;
    public GameObject BulletImpact;
     
    public int damage = 1;
    public SimpleShoot gun;

    public int Score;
    public Text ScoreText;

    public AudioClip ShootSound;
    public AudioClip ShellSound;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    // Use this for initialization
    void Start()
    {
        _camera = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Score = 0;
        source = GetComponent<AudioSource>();

    }
    private void OnGUI()
    {
        int size = 20;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "+");

    }
    // Update is called once per frame
    void Update()
    {
        ScoreText.text = Score.ToString();
        if (Input.GetMouseButtonDown(0) && gun.InBattery)
        {
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(ShootSound, vol);
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.
           pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                StartCoroutine(HitIndicator(hit.point));
                if (hit.rigidbody != null)
                    print(hit.collider.gameObject.name);
                EnemyController Enemy = hit.collider.GetComponent<EnemyController>();
                {
                    Enemy.Hurt(damage);
                    Score += 25;
                    
                }
                
            }
        }
    }


    private IEnumerator HitIndicator(Vector3 pos)
    {
        GameObject BulletHit = Instantiate(BulletImpact);        
        BulletHit.transform.position = pos;
        yield return new WaitForSeconds(.5f);
        source.PlayOneShot(ShellSound);

        yield return new WaitForSeconds(10);

        Destroy(BulletHit);
    }
}