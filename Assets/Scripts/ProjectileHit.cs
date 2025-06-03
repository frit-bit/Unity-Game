using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHit : MonoBehaviour {
    public AudioSource audioSource;
    public AudioClip projectileExplode;

    void OnCollisionEnter(Collision collision) {
        audioSource.PlayOneShot(projectileExplode);
    }
}
