using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            other.gameObject.GetComponent<CharacterStats>().addHP(-1, true);
        }
        else if(other.gameObject.tag == "Bomb") {
            other.gameObject.GetComponent<BombBehaviour>().ImmediateExplosion();
        }
    }
}
