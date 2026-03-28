using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    public Transform targetBone; 
    public float smoothSpeed = 0.125f; // 수치가 낮을수록 더 부드럽게 따라감 (0.05 ~ 0.2 추천)
    public float fixedY = 1.2f; // 카메라의 고정 높이 (직접 조절)

    void Start()
    {
        fixedY = transform.position.y;
    }
      
    void LateUpdate()
    {
        if (targetBone != null)
        {
            // X, Z는 힙을 따라가고, Y는 직접 높이로 고정!
            Vector3 desiredPosition = new Vector3(targetBone.position.x, fixedY, targetBone.position.z);
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        }
    }
}