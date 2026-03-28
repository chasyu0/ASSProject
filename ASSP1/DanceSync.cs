using UnityEngine;

public class DanceSync : MonoBehaviour
{
    public Animator karenAnim;

    [Header("시작 타이밍 조절 (0.0 ~ 1.0)")]
    [Tooltip("0.05면 전체 애니메이션의 5% 지점부터 시작합니다.")]
    public float startOffset = 0.05f;

    void Start()
    {
        if (karenAnim != null)
        {
            // 속도는 정속도(1.0)로 고정!
            karenAnim.speed = 1.0f;

            // Play(상태이름, 레이어, 시작시간)
            // 시작시간을 startOffset으로 설정해서 앞부분을 살짝 스킵합니다.
            karenAnim.Play(0, -1, startOffset);
        }
    }
}