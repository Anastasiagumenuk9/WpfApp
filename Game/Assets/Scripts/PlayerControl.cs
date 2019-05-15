using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {
    public Text text;
    GameObject panel;
    int score = 0;

    private void Start()
    {
        panel = GameObject.FindGameObjectWithTag("1");
        panel.SetActive(false);
        text = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
    }

    void Update ()
    {
		if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > -8.5f)
        {
            transform.position = new Vector3(transform.position.x - 8.5f, transform.position.y, transform.position.z);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < 8.5f)
        {
            transform.position = new Vector3(transform.position.x + 8.5f, transform.position.y, transform.position.z);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            score++;
            text.text = "Score : " + score.ToString();
        }
        else
        {
            Destroy(GameObject.Find("Road").gameObject);
            Destroy(GameObject.Find("Game").gameObject);

            Destroy(GameObject.FindGameObjectWithTag("Player").gameObject);
            panel.SetActive(true);
        }
        Destroy(collision.gameObject);
    }
}
