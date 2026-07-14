using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class deis : MonoBehaviour
{
    public float speed = 2f;
    public float range = 3f;

    private Vector3 startPos;
    private Rigidbody rb;

    void Start()
    {
        startPos = transform.position;

        rb = GetComponent<Rigidbody>();

        rb.isKinematic = true;

        // ŠŠ‚ç‚©‚É‚·‚é
        rb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    void FixedUpdate()
    {
        float z = Mathf.Sin(Time.time * speed) * range;

        Vector3 targetPos = startPos + new Vector3(0, 0, z);

        rb.MovePosition(targetPos);
    }
}