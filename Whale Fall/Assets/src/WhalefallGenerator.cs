using UnityEngine;

public class WhalefallGenerator : MonoBehaviour
{
    public float Frequency = .1f;
    public GameObject Source;
    public GameObject ExplosionSource;
    public AudioClip ExplosionClip;

    private int _count = 0;
    private float _changeDirTime = 0;
    private Vector3 _dir = -Vector3.right * .5f;
    private float _totalTime;

    // Use this for initialization
	void Start ()
	{
	    _totalTime = 0f;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
	    _totalTime += Time.deltaTime;
	    if (_totalTime > _count/Frequency)
	    {
	        var instance = Instantiate(Source, gameObject.transform.position, Quaternion.identity);
	        instance.transform.Translate(1 - 1 * _count % 3, 0, 0);

            _count++;
	    }
	}

    void Update()
    {
        if (_changeDirTime < Time.time)
        {
            _changeDirTime = Time.time + 4;
            _dir = -_dir;
        }

        transform.position = transform.position + _dir * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.name == "zombie")
        {
            Explode();
            collider2D.attachedRigidbody.AddForce(Vector2.up * 1000);
        }
    }

    private void Explode()
    {
        var explosion = Instantiate(ExplosionSource, transform.parent);
        explosion.transform.position = transform.position;
        AudioSource.PlayClipAtPoint(ExplosionClip, transform.position);
        Destroy(gameObject, .1f);
    }
}
