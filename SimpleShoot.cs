using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleShoot : MonoBehaviour
{

    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;
    public Transform barrelLocation;
    public Transform casingExitLocation;


    public float shotPower = 2000f;

    public int CurrentAmmo;
    public int ReserveAmmo;
    public float ReloadTime = 2;
    public int FullAmmo = 8;

    public bool IsReloading;
    public bool InBattery;
    public Text CurrentAmmoText;
    public Text ReserveAmmoText;

    public AudioClip ReloadSound;
    private AudioSource source;
    void Start()
    {
        
        if (barrelLocation == null)
            barrelLocation = transform;
        CurrentAmmo = 8;
        ReserveAmmo = 40;
        InBattery = true;
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        CurrentAmmoText.text = CurrentAmmo.ToString();
        ReserveAmmoText.text = ReserveAmmo.ToString();

        if (Input.GetButtonDown("Fire1") && !IsReloading && CurrentAmmo > 0 && InBattery)
        {
           
            GetComponent<Animator>().SetTrigger("Fire");
            CurrentAmmo -= 1;
            
            InBattery = false;
            
        }
        if (Input.GetKeyDown(KeyCode.R) && !IsReloading)
        {
            IsReloading = true;
            source.PlayOneShot(ReloadSound);

        }

        if (IsReloading)
        {
            InBattery = false;
            ReloadTime -= Time.deltaTime;
            if (ReloadTime <= 0)
            {
                IsReloading = false;
                Reload();
                ReloadTime = 2;
                InBattery = true;
                
            }
        }
    }

    public void Reload()
    {
        var Shot = FullAmmo - CurrentAmmo;

        if (ReserveAmmo < Shot)
        {
            CurrentAmmo = ReserveAmmo;
            ReserveAmmo = 0;
        }
        else
        {
            CurrentAmmo += Shot;
            ReserveAmmo -= Shot;
        }
    }

    public void Shootable()
    {
        if (!IsReloading)
        {
            InBattery = true;
        }
        if (CurrentAmmo == 0)
        {
            InBattery = false;
        }
    }


    void Shoot()
    {
        // GameObject bullet;
        // bullet = Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation);
        // bullet.GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);

        GameObject tempFlash;
        Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
        tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

        // Destroy(tempFlash, 0.5f);
        //  Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation).GetComponent<Rigidbody>().AddForce(casingExitLocation.right * 100f);

    }

    void CasingRelease()
    {
        GameObject casing;
        casing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        casing.GetComponent<Rigidbody>().AddExplosionForce(550f, (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        casing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(10f, 1000f)), ForceMode.Impulse);
    }
}
        
