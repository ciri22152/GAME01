using UnityEngine;

public abstract class CardBase : MonoBehaviour
{
    public string cardName;   // �J�[�h��
    public string Seitou; //���}�i�����A�����A�ꂢ��ANHK�j

    // �J�[�h���Ƃ̌��ʂ��������钊�ۃ��\�b�h
    public abstract void ExecuteEffect();
}
