using UnityEngine;

public class Rotater : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    void Update()
    {
        transform.Rotate(Vector3.forward * rotateSpeed);
    }
}
