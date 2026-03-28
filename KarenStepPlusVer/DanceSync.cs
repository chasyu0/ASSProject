using UnityEngine;

public class DanceSync : MonoBehaviour
{
    public AudioSource music;
    public Animator karenAnim;   

    [Header("조절 수치")]
    public float musicDelay = 0.5f;

    void Start()
    {
        if (music != null && karenAnim != null)
        {
            // 음악을 설정한 시간(musicDelay)만큼 뒤에 재생
            karenAnim.Play(0);

            music.PlayDelayed(musicDelay);
        }
    }
}