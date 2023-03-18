using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet bullet;
    [SerializeField] private BouncyBullet bouncyBullet;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private float speed = 10f;
    [SerializeField] private Transform cameraTransform;
    int ammunition = 10;
    bool isFirstWeapon = true;
    [SerializeField] GameObject firstWeapon;
    [SerializeField] GameObject secondWeapon;

    // Update is called once per frame
    void Update()
    {
  
        if (Input.GetMouseButtonDown(0)) 
        {
            Shoot();
        }

        if(Input.GetKeyDown(KeyCode.R) && ammunition == 0) 
        {
            Reload();
        }

         if(Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            secondWeapon.SetActive(false);
            firstWeapon.SetActive(true);
            isFirstWeapon = true;
        }
         if(Input.GetKeyDown(KeyCode.Alpha2)) 
        {
            firstWeapon.SetActive(false);
            secondWeapon.SetActive(true);
            isFirstWeapon = false;
        }
    }

    private void Shoot() {
        if(ammunition != 0) {
            ammunition--;
            if(ammunition == 0) {
                FindObjectOfType<Feedback>().setAmmoText(ammunition.ToString() + " - Press R to reload");
            }
            else {
                FindObjectOfType<Feedback>().setAmmoText(ammunition.ToString());
            }
            if(isFirstWeapon) {
                GameObject bulletObject = Instantiate(bullet.getBullet().gameObject, bulletSpawn.position, Quaternion.identity);
                bulletObject.GetComponent<Rigidbody>().AddForce(cameraTransform.forward * speed);
            }
            else {
                GameObject bulletObject = Instantiate(bouncyBullet.getBullet().gameObject, bulletSpawn.position, Quaternion.identity);
                bulletObject.GetComponent<Rigidbody>().AddForce(cameraTransform.forward * speed/2);
            }

            
        }
        
    }

    private void Reload() {
        FindObjectOfType<Feedback>().setReloadText("Reloading...");
        Invoke("resetAmmo", 1.5f);
    }

    private void resetAmmo() {
        ammunition = 10;
    }


}
