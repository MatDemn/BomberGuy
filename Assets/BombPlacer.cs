using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPlacer : MonoBehaviour
{
    public GameObject bombPrefab;
    public Animator anim;
    public CharacterStats charStats;

    // Start is called before the first frame update
    void Start()
    {
        charStats = transform.parent.GetComponent<CharacterStats>();
        anim = transform.parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(charStats.playerNumber==1 && Input.GetAxis("P1_Fire") != 0)
        {
            placeBomb();
        }
        else if (charStats.playerNumber==2 && Input.GetAxis("P2_Fire") != 0) {
            placeBomb();
        }
    }

    public void placeBomb() {
        if(charStats.playerBombCount != 0 && charStats.canPlaceBomb)
            {
                anim.SetTrigger("placeTrigger");
                charStats.canPlaceBomb = false;
                GameObject go = 
                    Instantiate(
                        bombPrefab, 
                        new Vector3(
                            Mathf.RoundToInt(transform.position.x), 
                            0, 
                            Mathf.RoundToInt(transform.position.z)
                        ), 
                        bombPrefab.transform.rotation
                    );
                go.GetComponent<BombBehaviour>().initiateVars(charStats);
                charStats.addBombs(-1);
            }
    }

    public void ChangeBombs(int changeAmount)
    {
        if(charStats.playerBombCount + changeAmount < 1) return;
        charStats.addBombs(changeAmount);
    }

    public void ChangeRange(int changeAmount)
    {
        if(charStats.playerBombRange + changeAmount < 1) return;
        charStats.addRange(changeAmount);
    }

    public void ChangeHP(int changeAmount)
    {
        if(charStats.playerHp + changeAmount < 1) return;
        charStats.addHP(changeAmount);
    }
}
