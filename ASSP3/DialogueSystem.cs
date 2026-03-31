using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [Header("UI 연결")]
    public Text contentText; // 대사가 나올 TMP 텍스트
    public GameObject dialogueBox;      // 하얀색 대화창 오브젝트 본체

    [Header("설정")]
    public float typingSpeed = 0.05f;   // 글자 속도
    public float waitTime = 136f;       // 시간 (2분 16초) 이후

    private List<string> sentences = new List<string>();
    private int index = 0;
    private bool isTyping = false;

    void Start()
    {
        // 대사 세팅
        sentences.Add("그래도 생각보다... 선임도 춤을 아주 못 추는 건 아니네?");
        sentences.Add("매일 여유 없이 출근하는 게 지옥 같긴 해도...\n다들 그렇게 산다고 하니까 참아야지, 뭐. 에휴.");
        sentences.Add("'화장실 가서 월루겸 코인좀 보고 와야지.\n선임님, 저 잠시 화장실좀! 캬캬캬캬'");

        // 처음시작 대화창 숨기기
        dialogueBox.SetActive(false);
        StartCoroutine(WaitAndStartDialogue());
    }

    IEnumerator WaitAndStartDialogue()
    {
        yield return new WaitForSeconds(waitTime);
        dialogueBox.SetActive(true);
        StartCoroutine(TypeSentence(sentences[index]));
    }

    // 대화창 클릭 시 실행!
    public void OnNextButtonClick()
    {
        if (isTyping) return; // 글자 나오는 중엔 클릭 무시

        index++;
        if (index < sentences.Count)
        {
            StartCoroutine(TypeSentence(sentences[index]));
        }
        else
        {
            dialogueBox.SetActive(false); // 대사 끝나면 창 닫기
            Debug.Log("카렌의 혼잣말 끝!");
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;
        contentText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            contentText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }
}