using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource audioSource; // AudioSource���Q��
    public AudioClip buttonClickSound; // ���ʉ��t�@�C��

    public void PlaySound()
    {
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound); // ���ʉ����Đ�
        }
    }
}
