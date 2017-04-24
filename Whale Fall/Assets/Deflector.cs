using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deflector : MonoBehaviour
{
    public AudioClip BouncyClip;

    private Detonator _detonator;

    // Use this for initialization
	void Start () {

	    _detonator = GetComponent<Detonator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collider2d)
    {
        if (collider2d.tag == "CanDestroy")
        {
            Destroy(collider2d.gameObject);
            AudioSource.PlayClipAtPoint(BouncyClip, transform.position);
        }

        if (collider2d.tag == "Player")
        {
            _detonator.Explode();
            Destroy(collider2d.gameObject);
            SceneManager.LoadScene("Lost", LoadSceneMode.Additive);
        }
    }
}
