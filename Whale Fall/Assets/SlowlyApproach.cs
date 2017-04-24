using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlowlyApproach : MonoBehaviour
{
    public GameObject[] HitActions;
    public int HitPoints = 1;
    private Detonator _detonator;

	// Use this for initialization
	void Start ()
	{
	    _detonator = GetComponent<Detonator>();
	}

    void OnTriggerEnter2D(Collider2D collider2d)
    {
        if (collider2d.tag == "Player")
        {
            _detonator.Explode();
            Destroy(collider2d.gameObject);
            SceneManager.LoadScene("Lost", LoadSceneMode.Additive);
        }

        if (collider2d.tag == "CanDestroy")
        {
            HitPoints--;
            Destroy(collider2d.gameObject);
            if (HitPoints <= 0)
            {
                _detonator.Explode();
                Destroy(collider2d.gameObject);
                Destroy(gameObject);
                if (tag == "FinalBoss")
                {
                    SceneManager.LoadScene("Win", LoadSceneMode.Additive);
                }
            }
            else
            {
                Instantiate(HitActions[HitPoints], collider2d.transform.position, Quaternion.identity, transform);
            }
        }
    }
}
