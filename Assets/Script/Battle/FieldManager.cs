using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI�C�x���g�p

public class FieldManager : MonoBehaviour
{
    private BattleManager battleManager;
    public Transform handsCanvas;
    public Transform trashZone;
    public CardZone playBoardZone; // �v���C�{�[�h�]�[���̎Q��

    public Button deckButton; // �f�b�L�C���[�W�ɑΉ�����{�^��
    private List<Transform> remainingCards = new List<Transform>(); // �f�b�L�Ɏc���Ă���J�[�h�̃��X�g

    public void InitHands(BattleManager _battleManager)
    {
        battleManager = _battleManager;
        Debug.Log("FieldManager.cs : ����������");

        InitializeDeck();
        PlaceRandomCards();

        // �f�b�L�C���[�W�̃{�^���ɃN���b�N�C�x���g��o�^
        deckButton.onClick.AddListener(DrawCardFromDeck);
    }

    private void InitializeDeck()
    {
        // �f�b�L�ɃJ�[�h��o�^
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (child.name.StartsWith("Card"))
            {
                remainingCards.Add(child);
            }
        }

        // �J�[�h�������_���ɃV���b�t��
        for (int i = 0; i < remainingCards.Count; i++)
        {
            Transform temp = remainingCards[i];
            int randomIndex = Random.Range(i, remainingCards.Count);
            remainingCards[i] = remainingCards[randomIndex];
            remainingCards[randomIndex] = temp;
        }
    }

    private void PlaceRandomCards()
    {
        // ������D��5���z�u
        for (int i = 0; i < 5 && remainingCards.Count > 0; i++)
        {
            // �擪�̃J�[�h�� Hands �Ɉړ�
            Transform card = remainingCards[0];
            card.SetParent(handsCanvas, false);

            // �f�b�L����폜
            remainingCards.RemoveAt(0);
        }
    }


    private void DrawCardFromDeck()
    {
        if (remainingCards.Count > 0)
        {
            // �c��̃J�[�h���烉���_����1���擾
            int randomIndex = Random.Range(0, remainingCards.Count);
            Transform selectedCard = remainingCards[randomIndex];

            // Hands�Ɉړ�
            selectedCard.SetParent(handsCanvas, false);

            // �f�b�L����폜
            remainingCards.RemoveAt(randomIndex);

            Debug.Log($"Card {selectedCard.name} has been drawn and moved to Hands.");
        }
        else
        {
            Debug.Log("No cards left in the deck.");
        }
    }

    // �v���C�{�[�h�]�[����Ԃ�
    public CardZone GetPlayBoardZone()
    {
        return playBoardZone;
    }
}
