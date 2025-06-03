using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFiring : MonoBehaviour {
    public float bulletSpeed;
    public GameObject projectileHitEffect;
    private float duration;
    public AudioSource audioSource;
    public AudioClip projectileExplode;
    void Start() {
        duration = projectileHitEffect.GetComponent<ParticleSystem>().main.duration;
        Rigidbody bulletRB = GetComponent<Rigidbody>();
        bulletRB.velocity = transform.forward*bulletSpeed*Time.deltaTime;
        Destroy(gameObject, duration);
    }
    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Enemy"){
            NPCAI_2.instance.enemyHit(10);
        }
        ContactPoint contact = collision.contacts[0];
        
        GameObject exp = Instantiate(projectileHitEffect, contact.point, Quaternion.LookRotation(contact.normal));
        audioSource.PlayOneShot(projectileExplode);
        Destroy(exp, duration);
    }
}
