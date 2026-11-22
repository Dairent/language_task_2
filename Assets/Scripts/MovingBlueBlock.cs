using UnityEngine;

public class MovingBlueBlock : MonoBehaviour
{
    public Vector3 pos1;
    public Vector3 pos2;
    public Vector3 autoOffset = new Vector3(3f, 0f, 0f);
    public bool useManualPositions = false;
    public float speed = 0.5f;

    void Start()
    {
        if (!useManualPositions)
        {
            pos1 = transform.position;
            pos2 = transform.position + autoOffset;
        }
    }

    void Update()
    {
        float t = Mathf.PingPong(Time.time * speed, 1f);
        transform.position = Vector3.Lerp(pos1, pos2, t);
    }
}