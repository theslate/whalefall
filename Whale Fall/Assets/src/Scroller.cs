using UnityEngine;

public class Scroller : MonoBehaviour
{
    public GameObject Camera;
    public bool IsClamped = true;
    public Vector3 Clamp = Vector3.zero;
    public float Offset = 1;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        var cameraPos = Camera.transform.position;

        var newPos = new Vector3(cameraPos.x * Offset, cameraPos.y * Offset, transform.position.z);
        if (IsClamped)
        {
            newPos = new Vector3(Mathf.Min(cameraPos.x * Offset, Clamp.x), Mathf.Min(cameraPos.y * Offset, Clamp.y), Mathf.Min(transform.position.z, Clamp.z));
        }

        this.transform.SetPositionAndRotation(newPos, Quaternion.identity);;
    }
}
