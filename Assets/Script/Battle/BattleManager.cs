using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private FieldManager fieldManager;
    [SerializeField] private Button testButton;
    [SerializeField] private CardZone cardZone; // CardZone��ǉ�

    private void Start()
    {
        if (fieldManager != null)
        {
            fieldManager.InitHands(this);
        }
        else
        {
            Debug.LogError("FieldManager���ݒ肳��Ă��܂���I");
        }

        if (testButton != null)
        {
            testButton.onClick.AddListener(OnTestButtonClick);
        }
        else
        {
            Debug.LogError("Test�{�^�����ݒ肳��Ă��܂���I");
        }
    }

    private void OnTestButtonClick()
    {
        Debug.Log("Test�{�^����������܂����I");
        ReduceCardHP();
    }

    private void ReduceCardHP()
    {
        // CardZone�ɂ���J�[�h��HP��-100���鏈����ǉ�
        foreach (Transform cardTransform in cardZone.transform)
        {
            Card card = cardTransform.GetComponent<Card>();
            if (card != null)
            {
                card.ReduceHP(100); // HP�����������郁�\�b�h���Ăяo��
                Debug.Log("�J�[�h��HP��-100����܂����B���݂�HP: " + card.HP);
            }
        }

        // CardZone�̃`�F�b�N���s��
        cardZone.CheckAndMoveToTrash();
    }
}