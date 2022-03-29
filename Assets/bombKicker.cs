using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombKicker : MonoBehaviour
{
    public CharacterStats charStats;

    private bool isMoving;
    // Start is called before the first frame update
    void Start()
    {
        charStats = GetComponent<CharacterStats>();
    }
    private void OnControllerColliderHit(ControllerColliderHit other) {
        // If this collision is the actual bomb
        if(other.transform.gameObject.tag == "Bomb") {
            // And if player can kick bombs freely
            if(charStats.canKick) {
                // Then bomb should rush in the opposite direction that the player collided with it
                // So same axis, but negative direction
                // If player is facing 
                if(transform.rotation.eulerAngles.y == 0){
                    other.gameObject.GetComponent<BombBehaviour>().StartMoving(Vector3.left);
                }
                // If player is facing
                else if(transform.rotation.eulerAngles.y == 90) {
                    other.gameObject.GetComponent<BombBehaviour>().StartMoving(Vector3.forward);
                }
                // If player is facing 
                else if (transform.rotation.eulerAngles.y == 180){
                    other.gameObject.GetComponent<BombBehaviour>().StartMoving(Vector3.right);
                }
                // If player is facing 
                else {
                    other.gameObject.GetComponent<BombBehaviour>().StartMoving(Vector3.back);
                }
            }
        }
    }
}
