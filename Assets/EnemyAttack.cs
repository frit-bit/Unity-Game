using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerFiring.instance.playerHit(25);
        }
    }
}
