using UnityEngine;

public class SlowSpin : MonoBehaviour
{
    [SerializeField] private float degreesPerSecond = 12f;

    void Update()
    {
        transform.Rotate(0f, degreesPerSecond * Time.deltaTime, 0f, Space.Self);
    }
}