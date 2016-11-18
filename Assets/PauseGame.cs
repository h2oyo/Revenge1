using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {
    public Transform canvas;
	
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(canvas.gameObject.activeInHierarchy == false) { canvas.gameObject.SetActive(true); }
            else { canvas.gameObject.SetActive(false); }
        }

      


	}

   public void nextLevel()
    {
        print("nextLevel");
    }

    public void MainMenu()
    {
        print("MainMEnu");
    }

}
