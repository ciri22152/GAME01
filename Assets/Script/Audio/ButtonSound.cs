using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource audioSource; // AudioSourceを参照
    public AudioClip buttonClickSound; // 効果音ファイル

    public void PlaySound()
    {
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound); // 効果音を再生
        }
    }
}
