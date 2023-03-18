using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBullet : MonoBehaviour
{
   [SerializeField] private GameObject bouncyBullet;
    private bool isFirstHit = true;

    public Transform getBullet()
    {
        return bouncyBullet.transform;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(isFirstHit && collision.gameObject.name != "Capsule" && collision.gameObject.name != "PlayerCapsule") {
            isFirstHit = false;
             FindObjectOfType<Feedback>().setHitText("You hit " + collision.gameObject.name);
        }
    }
}
