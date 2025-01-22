using UnityEngine;

public class CanvasSwitcher : MonoBehaviour
{
    // TitleCanvas��GameCanvas�̎Q��
    [SerializeField] private GameObject titleCanvas;
    [SerializeField] private GameObject gameCanvas;

    // �{�^�����N���b�N���ꂽ�Ƃ��ɌĂяo�����֐�
    public void SwitchToGameCanvas()
    {
        // TitleCanvas���\���ɂ��AGameCanvas��\������
        titleCanvas.SetActive(false);
        gameCanvas.SetActive(true);
    }
}
