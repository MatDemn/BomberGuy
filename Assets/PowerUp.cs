using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpType {
    Bomb,
    Heart,
    Speed,
    Kick,
    Fire
}

public class PowerUp : MonoBehaviour
{
    public PowerUpType powerupType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            if (powerupType == PowerUpType.Bomb) {
                other.gameObject.GetComponent<CharacterStats>().addBombs(1);
            }
            else if (powerupType == PowerUpType.Heart){
                other.gameObject.GetComponent<CharacterStats>().addHP(1);
            }
            else if (powerupType == PowerUpType.Speed){
                other.gameObject.GetComponent<CharacterStats>().addMoveSpeed(1);
            }
            else if (powerupType == PowerUpType.Kick){
                other.gameObject.GetComponent<CharacterStats>().addKick();
            }
            else if (powerupType == PowerUpType.Fire){
                other.gameObject.GetComponent<CharacterStats>().addRange(1);
            }
            else {
                Debug.Log("This should not happen! Wrong enum of powerup");
                return;
            }
            gameObject.GetComponent<Collider>().enabled = false;
            gameObject.GetComponentInChildren<ParticleSystem>().Stop();
            Destroy(gameObject);
        }
    }
}
