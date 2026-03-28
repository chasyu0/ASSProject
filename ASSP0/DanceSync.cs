using UnityEngine;

public class DanceSync : MonoBehaviour
{
    public AudioSource music;
    public float musicDelay = 0.1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(music != null)
        {
            music.PlayDelayed(musicDelay);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
