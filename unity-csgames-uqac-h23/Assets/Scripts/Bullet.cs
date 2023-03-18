using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    private bool isBouncy = false;
    private bool isFirstHit = true;

    public Transform getBullet()
    {
        return bullet.transform;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(isBouncy && isFirstHit && collision.gameObject.name != "Capsule" && collision.gameObject.name != "PlayerCapsule") {
            isFirstHit = false;
             FindObjectOfType<Feedback>().setHitText("You hit " + collision.gameObject.name);
        }
        else if(collision.gameObject.name != "Capsule" && collision.gameObject.name != "PlayerCapsule" ) { 
            FindObjectOfType<Feedback>().setHitText("You hit " + collision.gameObject.name);
            Destroy(bullet);
        }
    }

    public void setBouncy(bool bouncy) {
        isBouncy = bouncy;
    }
}
