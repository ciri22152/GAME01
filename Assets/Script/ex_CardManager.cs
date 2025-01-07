using UnityEngine;

public class CardManager : MonoBehaviour
{
    public GameObject cardPrefab;       // �J�[�h�̃v���n�u
    public Transform cardParent;        // �J�[�h��z�u����e�I�u�W�F�N�g

    public CardData[] cardDataArray;    // �g�p����CardData�i�z��j

    void Start()
    {
        CreateCards();
    }

    void CreateCards()
    {
        foreach (CardData cardData in cardDataArray)
        {
            // �J�[�h�v���n�u���C���X�^���X��
            GameObject newCard = Instantiate(cardPrefab, cardParent);

            // CardDisplay�X�N���v�g���擾
            CardDisplay cardDisplay = newCard.GetComponent<CardDisplay>();

            // CardData�������ݒ�
            cardDisplay.SetCardData(cardData);
        }
    }
}
