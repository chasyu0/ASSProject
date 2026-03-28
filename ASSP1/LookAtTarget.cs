using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    public Transform target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void LateUpdate()
    {
        if (target != null)
        {
            transform.LookAt(target);
        }
    }
}
