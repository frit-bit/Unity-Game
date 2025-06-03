using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NPCAI_2 : MonoBehaviour
{
    public static NPCAI_2 instance;
    public Transform[] waypoints; // Array of waypoints
    private int currentWaypointIndex = 0;
    private NavMeshAgent agent;
    public GameObject player;
    public Animator animator;
    public Slider slider;
    public int EnemyHealth = 100;
    public Rigidbody[] ragdoll_rigidbodies;
    public Collider[] ragdollColliders;
    public CapsuleCollider MutantCapsuleCollider;
    public CapsuleCollider MutantClawCollider;
    public GameObject MutantHealthCanvas;
    private void Awake()
    {
        instance = this;
        ragdoll_rigidbodies = GetComponentsInChildren<Rigidbody>();
        ragdollColliders = GetComponentsInChildren<Collider>();
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (waypoints.Length > 0)
        {
            animator.SetBool("Walking", true);
            agent.SetDestination(waypoints[currentWaypointIndex].position);
        }
        slider.value = EnemyHealth;
        disableRagdoll();
        MutantCapsuleCollider.enabled = true;
        MutantClawCollider.enabled = false;
    }

    void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
        {
            NextWaypoint();
        }
        Vector3 distance = player.transform.position - transform.position;


        if (distance.magnitude < 5)
        {
            animator.applyRootMotion = true;
            animator.SetBool("Swipe", true);
            animator.SetBool("Walking", false);
            agent.SetDestination(player.transform.position);
        }
        else
        {
            animator.applyRootMotion = false;
            animator.SetBool("Swipe", false);
            animator.SetBool("Walking", true);
        }
    }

    public void ToggleAttack()
    {
        MutantClawCollider.enabled = !MutantClawCollider.enabled;
    }

    public void enemyHit(int decreaseHealth)
    {
        slider.value = EnemyHealth - decreaseHealth;
        EnemyHealth = (int)slider.value;
        if (EnemyHealth <= 0)
        {
            EnableRagdoll();
            MutantClawCollider.enabled = false;
        }
    }

    void NextWaypoint()
    {
        if (waypoints.Length == 0) return;

        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        agent.SetDestination(waypoints[currentWaypointIndex].position);
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
        MutantHealthCanvas.SetActive(false);
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
}
