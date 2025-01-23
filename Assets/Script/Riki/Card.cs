using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerClickHandler
{
    public string name; // �J�[�h�̖��O

    // �R���X�g���N�^
    public Card(string cardName)
    {
        name = cardName;
    }

    // �J�[�h���N���b�N���ꂽ�Ƃ��̏���
    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.Instance.SelectCard(this.gameObject); // �Q�[���}�l�[�W���[�ɃJ�[�h�I���̒ʒm�𑗂�
    }
}
