using UnityEngine;

public class Detonator : MonoBehaviour {

    public GameObject ExplosionSource;
    public AudioClip ExplosionClip;

    public void Explode()
    {
        var explosion = Instantiate(ExplosionSource, transform.parent);
        explosion.transform.position = transform.position;
        AudioSource.PlayClipAtPoint(ExplosionClip, transform.position);
        Destroy(gameObject, .1f);
        Destroy(explosion.gameObject, 5);
    }
}
