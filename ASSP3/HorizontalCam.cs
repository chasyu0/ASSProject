using UnityEngine;

public class HorizontalCam : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 5f;

    private Vector3 offset;        // 시작할 때의 간격을 자동으로 계산해서 저장할 변수
    private float fixedY;          // 1.5로 고정될 높이
    private Quaternion fixedRot;   // (22, 90, 0)으로 고정될 각도

    void Start()
    {
        if (target != null)
        {
            fixedY = transform.position.y;
            fixedRot = transform.rotation;

            offset = transform.position - target.position;
        }
    }

    void LateUpdate()
    {
        if (target == null) return;

        // X, Z는 따라가고 Y는 고정
        Vector3 targetPosition = target.position + offset;
        targetPosition.y = fixedY;

        // 부드러운 추적 (Lerp)
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

        transform.rotation = fixedRot;
    }
}

