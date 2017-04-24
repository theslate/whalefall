using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleFallCleanUp : MonoBehaviour
{
    private Detonator _detonator;

	// Use this for initialization
	void Start ()
	{
	    _detonator = GetComponent<Detonator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Ground")
        {
            _detonator.Explode();
        }
    }
}
