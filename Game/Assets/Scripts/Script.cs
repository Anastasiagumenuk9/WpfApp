using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script : MonoBehaviour {

    public GameObject game;

    private void Start()
    {
        Instantiate(game).name = "Game";
    }

    public void StartGame()
    {
        GameObject.FindGameObjectWithTag("Score").GetComponent<Text>().text = "Score : 0";
        Instantiate(game).name = "Game";
    }
}
