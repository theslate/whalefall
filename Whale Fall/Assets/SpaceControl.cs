using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpaceControl : MonoBehaviour
{
    public Vector3 ClampMins;
    public Vector3 ClampMaxes;
    public float Speed = 10;
    public float BulletSpeed = 50;
    public GameObject BulletPrefab;
    
    private Vector3 _up = Vector3.up;

    private Dictionary<GameObject, Vector3> _bullets = new Dictionary<GameObject, Vector3>();
    private Camera _camera;

    // Use this for initialization
    void Start ()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update ()
	{
	    {
	        var horizontal = Input.GetAxisRaw("Horizontal");
	        var vertical = Input.GetAxisRaw("Vertical");
	        var vel = Vector3.Normalize(new Vector3(horizontal, vertical)) * Speed * Time.deltaTime;
	        if (vel.magnitude > float.Epsilon)
	        {
	            transform.rotation = Quaternion.FromToRotation(Vector3.up, vel.normalized);
	            _up = vel.normalized;
	            transform.position =
	                new Vector3(
	                    Mathf.Clamp(transform.position.x + vel.x, ClampMins.x, ClampMaxes.x),
	                    Mathf.Clamp(transform.position.y + vel.y, ClampMins.y, ClampMaxes.y));
	        }
	    }
        
	    if (Input.GetButtonDown("jump"))
	    {
	        _bullets.Add(Instantiate(BulletPrefab, transform.position, Quaternion.identity), _up);
	    }

	    foreach (var bullet in _bullets.ToArray())
	    {
	        if (bullet.Key == null)
	        {
	            _bullets.Remove(bullet.Key);
	        }
	        else
	        {
	            var viewPoint = _camera.WorldToViewportPoint(bullet.Key.transform.position);
	            if (viewPoint.x > 1 || viewPoint.x < 0 || viewPoint.y < 0 || viewPoint.y > 1)
	            {
	                _bullets.Remove(bullet.Key);
                    Destroy(bullet.Key);
	            }

                bullet.Key.transform.rotation = Quaternion.FromToRotation(Vector3.up, bullet.Value);
	            bullet.Key.transform.Translate(Vector3.up * BulletSpeed);
            }
        }
    }
}