using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject BookParticle;
    public GameObject NekoBackdancer;
    public GameObject MainCharacter;

    public void ToggleParticles()
    {
        BookParticle.SetActive(!BookParticle.activeSelf);
    }

    public void ToggleNeko()
    {
        bool isNowActive = !NekoBackdancer.activeSelf;
        NekoBackdancer.SetActive(isNowActive);

        // 2. 고양이 On시 메인캐릭터와 싱크를 맞추다. 
        if (isNowActive && MainCharacter != null)
        {
            Animator mainAnim = MainCharacter.GetComponent<Animator>();
            // 현재 재생 중인 애니메이션 시간 정보(0~1 사이의 값을) 가져오다.
            float currentTime = mainAnim.GetCurrentAnimatorStateInfo(0).normalizedTime;

            // 고양이들을 Animator를 찾아서 같은 시간으로 강제 세팅한다. 
            Animator[] nekoAnims = NekoBackdancer.GetComponentsInChildren<Animator>();
            foreach (Animator anim in nekoAnims)
            {
                // 현재 상태 0번째 레이어 시간을 메인 캐릭터와 동일하게 일치시킴
                anim.Play(0, -1, currentTime);
            }
        }
    }
}
