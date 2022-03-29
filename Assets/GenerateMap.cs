using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    GameObject[] frame;
    public int size_x;
    public int crates;

    public bool doGenerate;

    public bool crateGenerate;

    public GameObject cratePrefab;
    public GameObject cratePrefabFract;

    public GameObject bandPrefab;

    public GameObject player1;

    public GameObject player2;

    public GameObject[] rocksArray;

    // Start is called before the first frame update
    void Start()
    {
        if(!doGenerate)
            return;

        player1.transform.position = new Vector3(-(size_x/2-1),-.5f,(size_x/2-1));
        player2.transform.position = new Vector3((size_x/2-1),-.5f,-(size_x/2-1));

        Vector3 bandScaleBig = new Vector3(size_x+1, 1, 1);
        Vector3 bandScaleSmall = new Vector3(size_x-0.5f, 1, 1);
        frame = new GameObject[4];
        LayerMask solidLayer = LayerMask.NameToLayer("SolidObstacle");

        for(int i=0; i<frame.Length; i++)
        {
            frame[i] = Instantiate(bandPrefab);
            frame[i].transform.Rotate(0,i*90,0);
            frame[i].layer = solidLayer;
            frame[i].transform.SetParent(gameObject.transform);
            frame[i].tag = "SolidObstacle";
            frame[i].name = $"Band_${i}";
            if(i%2 == 0)
                frame[i].transform.localScale = bandScaleBig;
            else
                frame[i].transform.localScale = bandScaleSmall;
        }

        frame[0].transform.position = new Vector3(0, 0, size_x/2);
        frame[1].transform.position = new Vector3(size_x/2, 0, 0);
        frame[2].transform.position = new Vector3(0, 0, -size_x/2);
        frame[3].transform.position = new Vector3(-size_x/2, 0, 0);
    
        /*

        for(int z = -size_x/2+2; z<size_x/2; z+=2)
        {
            for(int x = -size_x/2+2; x<size_x/2; x+=2) {
                GameObject go = Instantiate(
                    rocksArray[Random.Range(0, rocksArray.Length-1)], 
                    new Vector3(x, -.5f, z), 
                    Quaternion.Euler(0, Random.Range(0, 360), 0));
                go.transform.SetParent(gameObject.transform);
                go.name = $"Pillar_{z}_{x}";
            }
        }

        if(!crateGenerate)
            return;

        // Generate some crates to destroy with explosions...

        // First 2 and last 2 rows have to be different (players are there)
        for(int x = -size_x/2+3; x<size_x/2-2; x+=1) {
            if(Random.Range(0,9) < 7) {
                Instantiate(cratePrefab, new Vector3(x,-0.5f,-size_x/2+1), Quaternion.Euler(0, 90*Random.Range(0, 3), 0)).transform.SetParent(gameObject.transform);
            }
        }
        for(int x = -size_x/2+3; x<size_x/2-2; x+=2) {
            if(Random.Range(0,9) < 7) {
                Instantiate(cratePrefab, new Vector3(x,-0.5f,-size_x/2+2), Quaternion.Euler(0, 90*Random.Range(0, 3), 0)).transform.SetParent(gameObject.transform);
            }
        }
        
        for(int z = -size_x/2+3; z<size_x/2-2; z+=1) {
            for(int x = -size_x/2+1; x<size_x/2; x+=1) {
                if(z % 2 == 0 && x % 2 == 0) {
                    continue;
                }
                if(Random.Range(0,9) < 7) {
                    Instantiate(cratePrefab, new Vector3(x,-0.5f,z), Quaternion.Euler(0, 90*Random.Range(0, 3), 0)).transform.SetParent(gameObject.transform);
                }
            }
        }

        for(int x = -size_x/2+3; x<size_x/2-2; x+=2) {
            if(Random.Range(0,9) < 7) {
                Instantiate(cratePrefab, new Vector3(x,-0.5f,size_x/2-2), Quaternion.Euler(0, 90*Random.Range(0, 3), 0)).transform.SetParent(gameObject.transform);
            }
        }

        for(int x = -size_x/2+3; x<size_x/2-2; x+=1) {
            if(Random.Range(0,9) < 7) {
                Instantiate(cratePrefab, new Vector3(x,-0.5f,size_x/2-1), Quaternion.Euler(0, 90*Random.Range(0, 3), 0)).transform.SetParent(gameObject.transform);
            }
        }
        
        */
        
        // First 2 and last 2 rows have to be different (players are there)
        
        for(int y = -size_x/2+1; y <= -size_x/2+2; y++) {
            for(int x = -size_x/2+3; x<size_x/2-2; x+=1) {
                if(Random.Range(0,9) < 7) {
                    Instantiate(cratePrefab, new Vector3(x,-0.5f,y), Quaternion.Euler(0, 90*Random.Range(0, 3), 0)).transform.SetParent(gameObject.transform);
                }
            }
        }
        
        for(int z = -size_x/2+3; z<size_x/2-2; z+=1) {
            for(int x = -size_x/2+1; x<size_x/2; x+=1) {
                if(z % 2 == 0 && x % 2 == 0) {
                    continue;
                }
                int randomPref = Random.Range(0,9);
                if(randomPref < 7) {
                    Instantiate(cratePrefab, new Vector3(x,-0.5f,z), Quaternion.Euler(0, 90*Random.Range(0, 3), 0)).transform.SetParent(gameObject.transform);
                }
                else if(randomPref < 9) {
                    GameObject go = Instantiate(
                        rocksArray[Random.Range(0, rocksArray.Length-1)], 
                        new Vector3(x,-0.5f,z), 
                        Quaternion.Euler(0, Random.Range(0, 360), 0));
                    go.transform.SetParent(gameObject.transform);
                    go.name = $"Rock_{z}_{x}";
                }
            }
        }

        for(int y = size_x/2-2; y <= size_x/2-1; y++) {
            for(int x = -size_x/2+3; x<size_x/2-2; x+=1) {
                if(Random.Range(0,9) < 7) {
                    Instantiate(cratePrefab, new Vector3(x,-0.5f,y), Quaternion.Euler(0, 90*Random.Range(0, 3), 0)).transform.SetParent(gameObject.transform);
                }
            }
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
