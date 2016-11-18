using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

    public static GameState instance = null;
    public static int Points;
    public GUIText ScoreText;



	// Use this for initialization
	void Start ()
    {
        Points = 0;
        updateScore();
	}
	
	// Update is called once per frame
	void Update ()
    {
        updateScore();
	}

    void updateScore()
    {
        ScoreText.text = "PENIS: " + Points;
    }

}

