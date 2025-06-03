using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerFiring : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform firePoint;
    public Slider slider;
    public int PlayerHealth = 100;
    public static PlayerFiring instance;
    public Rigidbody[] ragdoll_rigidbodies;
    public Collider[] ragdollColliders;
    public Animator animator;
    public GameObject PlayerHealthCanvas;
    public CapsuleCollider playerCapsuleCollider;

    void Awake()
    {
        instance = this;
        ragdoll_rigidbodies = GetComponentsInChildren<Rigidbody>();
        ragdollColliders = GetComponentsInChildren<Collider>();
        disableRagdoll();
        playerCapsuleCollider.enabled = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullets = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }

    public void playerHit(int decreaseHealth)
    {
        slider.value = PlayerHealth - decreaseHealth;
        PlayerHealth = (int)slider.value;
        if (PlayerHealth <= 0)
        {
            EnableRagdoll();
            Invoke("GameOver", 1);
        }
    }
    void EnableRagdoll()
    {
        animator.enabled = false;
        foreach (var RB in ragdoll_rigidbodies)
        {
            RB.isKinematic = false;
        }
        foreach (var Colliders in ragdollColliders)
        {
            Colliders.enabled = true;
        }
        this.enabled = false;
        PlayerHealthCanvas.SetActive(false);
    }
    void disableRagdoll()
    {
        animator.enabled = true;
        foreach (var RB in ragdoll_rigidbodies)
        {
            RB.isKinematic = true;
        }
        foreach (var Colliders in ragdollColliders)
        {
            Colliders.enabled = false;
        }
    }
    private void GameOver()
    {
        SceneManager.LoadScene(3);
    }
}