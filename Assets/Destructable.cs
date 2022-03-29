using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public GameObject fracturedPrefab;

    public float explosiveValue;

    public float fadeStep = 0.5f;

    public GameObject[] upgradesPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   

    }

    public void destroy(Vector3 direction) {
        GameObject go = Instantiate(fracturedPrefab, transform.position, transform.rotation);
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        Rigidbody[] rbs = go.GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody rb in rbs) {
            rb.AddExplosionForce(explosiveValue, transform.position, 1f);
        }
        int choice = Random.Range(0, upgradesPrefab.Length + 5);
        if(choice < upgradesPrefab.Length)
        {
            GameObject upgrade = Instantiate(upgradesPrefab[choice], transform.position + Vector3.up/2, Quaternion.identity);
        }
        StartCoroutine(fadeOutPieces(rbs, go));
    }

    IEnumerator fadeOutPieces(Rigidbody[] rbs, GameObject fractures) {
        yield return new WaitForSeconds(3);
        // Now I can start fading them
        float passedTime = -fadeStep;
        foreach(Rigidbody rb in rbs) {
            rb.isKinematic = true;
        }
        yield return null;
        float step = Time.deltaTime * fadeStep;
        while(passedTime < fadeStep) {
            passedTime += Time.deltaTime;
            foreach(Rigidbody rb in rbs) {
                rb.gameObject.transform.Translate(Vector3.down * step, Space.World);
            }
            yield return null;
        }
        Destroy(fractures);
        Destroy(gameObject);
    }
}
