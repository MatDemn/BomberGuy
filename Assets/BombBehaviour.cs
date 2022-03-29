using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BombBehaviour : MonoBehaviour
{
    public CharacterStats authorStats;
    public GameObject explosionPrefab;
    public float bomb_time;

    public int bomb_range;

    private bool isExploded;

    public LayerMask solidObstacle;


    public bool isMoving;

    public Vector3 movePosition;

    public float moveSpeed;

    private Collider bombCollider;
    // Start is called before the first frame update
    void Start()
    {
        isExploded = false;
        solidObstacle = LayerMask.GetMask("SolidObstacle");
        Invoke("Explosion", bomb_time);

        isMoving = false;
        movePosition = transform.position;
        moveSpeed = 5;
        bombCollider = GetComponent<Collider>();
    }

    void FixedUpdate()
    {
        if(isMoving) {
            transform.position += movePosition * Time.deltaTime * moveSpeed;
        }
    }

    public void initiateVars(CharacterStats authorStats) {
        this.authorStats = authorStats;
        bomb_time = authorStats.playerBombTime;
        bomb_range = authorStats.playerBombRange;
    }

    private void Explosion() 
    {
            if(bombCollider.isTrigger) {
                authorStats.canPlaceBomb = true;
            }
            authorStats.addBombs(1);
            isMoving = false;
            GameObject go = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), transform.position.y, Mathf.RoundToInt(transform.position.z));
            isExploded = true;
            StartCoroutine(CreateExplosions(Vector3.forward));
            StartCoroutine(CreateExplosions(Vector3.back));
            StartCoroutine(CreateExplosions(Vector3.left));
            StartCoroutine(CreateExplosions(Vector3.right));
            Destroy(gameObject, .3f);
    }

    IEnumerator CreateExplosions(Vector3 direction) 
    {
        for(int i=1; i<=bomb_range; i++) 
        {
            RaycastHit hit;

            Physics.Raycast(transform.position + new Vector3(0, .1f, 0), direction, out hit, i, solidObstacle);

            
            if(!hit.collider)
            {
                Instantiate(explosionPrefab, transform.position + (direction * i), explosionPrefab.transform.rotation);
            }
            else
            {
                GameObject hitted = hit.collider.transform.gameObject;
                if(hitted.tag == "Destructable") {
                    hitted.GetComponent<Destructable>().destroy(direction);
                }
                else if (hitted.tag == "Bomb") {
                    hitted.GetComponent<BombBehaviour>().ImmediateExplosion();
                }
                break;
            }

            yield return new WaitForSeconds(0.05f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            authorStats.canPlaceBomb = true;
            GetComponent<Collider>().isTrigger = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        isMoving = false;
        transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.z));
        movePosition = transform.position;
    }

    public void StartMoving(Vector3 movePos) {
        if(!isMoving && !bombCollider.isTrigger) {
            movePosition = movePos;
            isMoving = true;
        }
    }

    public void ImmediateExplosion() {
        isMoving = false;
        transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.z));
        movePosition = transform.position;

        if(!isExploded) 
        {
            CancelInvoke("Explosion");
            Explosion();
        }
    }

}
