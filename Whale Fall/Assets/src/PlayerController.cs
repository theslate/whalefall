using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 1;
    public float JumpSpeed = 10;
    public float Tolerance = .5f;
    public float CameraOffset = .5f;
    public GroundTrigger GroundTrigger;
    public Camera Camera;
    public AudioClip JumpClip;
    public AudioClip LandClip;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private Animation _animation;
    private bool _jumping = false;

    // Use this for initialization
    void Start ()
	{
	    _rigidbody2D = GetComponent<Rigidbody2D>();
	    _animator = GetComponent<Animator>();
	    _animation = GetComponent<Animation>();
        GroundTrigger.GroundEvent += GroundTriggerOnGroundEvent;
    }

    private void GroundTriggerOnGroundEvent(object sender, EventArgs eventArgs)
    {
        _jumping = false;
        _animator.SetBool("jumping", false);
    }

    void Update()
    {
        Camera.transform.position = new Vector3(Camera.transform.position.x, gameObject.transform.position.y + CameraOffset, Camera.transform.position.z);
    }

    // Update is called once per frame
	void FixedUpdate ()
	{
	    Move(Time.fixedDeltaTime, Input.GetAxis("Horizontal"));
        _animator.SetFloat("x_velocity", _rigidbody2D.velocity.x);
	    if (Input.GetButton("jump"))
	    {
	        Jump(Time.fixedDeltaTime);
        }

	    if (transform.position.y > 6)
	    {
	        _rigidbody2D.AddForce(Vector2.up*2, ForceMode2D.Force);
	    }
	}

    private void Move(float fixedDeltaTime, float axis)
    {
        var speed = _jumping ? Speed / 2 : Speed;
        _rigidbody2D.AddForce(fixedDeltaTime * axis * speed * Vector3.right, ForceMode2D.Impulse);
    }

    private void Jump(float fixedDeltaTime)
    {
        _animator.SetBool("jumping", true);
        if (!_jumping)
        {
            AudioSource.PlayClipAtPoint(JumpClip, transform.position);
            _jumping = true;
            _rigidbody2D.AddForce(fixedDeltaTime * JumpSpeed * Vector3.up, ForceMode2D.Impulse);
        }
    }
}
