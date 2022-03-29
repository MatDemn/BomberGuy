using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    public int playerNumber;
    public int playerHp;

    public int playerMoveSpeed;

    public int playerInvincibleTime;

    public int playerKickForce;

    public bool canKick;

    public bool canMove;

    public bool canPlaceBomb;

    public int playerBombCount;

    public int playerBombRange;

    public int playerBombTime;

    public Canvas uiRef;
    public hudDisplay hudHPText;

    public bool isInvincible;

    public float invincibleTime;

    public GameObject invincibleObj;
    // Start is called before the first frame update
    void Start()
    {
        hudHPText = uiRef.GetComponent<hudDisplay>();
        hudHPText.setHP(playerNumber, playerHp);
        hudHPText.setBombs(playerNumber, playerBombCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setHP(int val) {
        if(!isInvincible) {
            playerHp = val;
            hudHPText.setHP(playerNumber, playerHp);
        }
    }

    public void addHP(int val, bool invinc = false) {
        if(!isInvincible) {

            if(playerHp + val < 1) {
                Time.timeScale = 0f;
                
                GameManager.gameOverObj.SetActive(true);
            }

            playerHp += val;
            hudHPText.setHP(playerNumber, playerHp);

            if(invinc) {
                StartCoroutine(invincibleBehaviour());
                StartCoroutine(invincibleObj.GetComponent<invincibility>().invincibleEffect());
            }
        }
    }

    public void setBombs(int val) {
        playerBombCount = val;
        hudHPText.setBombs(playerNumber, playerBombCount);
    }

    public void addBombs(int val) {
        playerBombCount += val;
        hudHPText.setBombs(playerNumber, playerBombCount);
    }

    public void setRange(int val) {
        playerBombRange = val;
        //hudHPText.setRange(playerNumber, playerBombRange);
    }

    public void addRange(int val) {
        playerBombRange += val;
        //hudHPText.setRange(playerNumber, playerBombRange);
    }

    public void setMoveSpeed(int val) {
        playerMoveSpeed = val;
        //hudHPText.setRange(playerNumber, playerBombRange);
    }

    public void addMoveSpeed(int val) {
        playerMoveSpeed += val;
        //hudHPText.setRange(playerNumber, playerBombRange);
    }

    public void addKick() {
        canKick = true;
        //hudHPText.setRange(playerNumber, playerBombRange);
    }

    public void switchKick() {
        canKick ^= true;
        //hudHPText.setRange(playerNumber, playerBombRange);
    }

    IEnumerator invincibleBehaviour() {
        isInvincible = true;
        yield return new WaitForSeconds(invincibleTime);
        isInvincible = false;
    }
    
}
