using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject canvasRef;
    public static GameObject gameOverObj;
    // Start is called before the first frame update
    void Start()
    {
        gameOverObj = canvasRef.transform.Find("GameOverObjs").gameObject;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame() {
        SceneManager.LoadScene("GameMap");
        //Debug.Log("Started game!!!");
    }

    public void returnToMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
