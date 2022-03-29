using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invincibility : MonoBehaviour
{
    Renderer meshRender;

    CharacterStats charStats;
    // Start is called before the first frame update
    void Start()
    {
        meshRender = GetComponent<Renderer>();
        charStats = transform.parent.GetComponent<CharacterStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator invincibleEffect() {
        meshRender.enabled = true;
        yield return new WaitForSeconds(charStats.invincibleTime);
        meshRender.enabled = false;
    }
}
