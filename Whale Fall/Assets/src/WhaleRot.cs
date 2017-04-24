using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleRot : MonoBehaviour {
    private Animator _animator;

    // Use this for initialization
	void Start ()
	{
	    _animator = GetComponent<Animator>();
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "SeaFloor")
        {
            _animator.SetBool("rotten", true);
        }
    }
}
