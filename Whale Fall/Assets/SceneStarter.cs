using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStarter : MonoBehaviour
{

    public string SceneName;
    
	void OnTriggerEnter2D(Collider2D collider2D) {
	    if (collider2D.tag == "Player")
	    {
	        SceneManager.LoadScene(SceneName);
	    }
	}
}
