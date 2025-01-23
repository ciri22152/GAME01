using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject selectedCard;  // �I�΂ꂽ�J�[�h

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // ��D����J�[�h��I�ԏ���
    public void SelectCard(GameObject card)
    {
        if (selectedCard != null)
        {
            // ���ɑI�΂ꂽ�J�[�h������ΑI�������Ȃǂ̏���
        }

        selectedCard = card;  // �V�����J�[�h��I��
        Debug.Log("�I�΂ꂽ�J�[�h: " + selectedCard.name);
    }
}
