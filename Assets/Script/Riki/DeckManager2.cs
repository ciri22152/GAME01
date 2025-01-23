using System.Collections.Generic;
using UnityEngine;

public class DeckManager2 : MonoBehaviour
{
    public Transform deck; // Deck�̐e�I�u�W�F�N�g�i�q��20���̃J�[�h���z�u����Ă���j
    public Transform handZone; // HandZone��Transform
    public float handZoneWidth = 750f; // HandZone�̉����i�S�̂̕����w��j
    private List<GameObject> deckCards = new List<GameObject>(); // �f�b�L�̃J�[�h���X�g

    void Start()
    {
        InitializeDeck();
        ShuffleDeck();
        DrawInitialHand(5);
    }

    // �f�b�L�̏�����: Deck�̎q�I�u�W�F�N�g�����X�g�Ɋi�[
    void InitializeDeck()
    {
        foreach (Transform card in deck)
        {
            deckCards.Add(card.gameObject);
        }
    }

    // �f�b�L���V���b�t��
    void ShuffleDeck()
    {
        for (int i = 0; i < deckCards.Count; i++)
        {
            GameObject temp = deckCards[i];
            int randomIndex = Random.Range(0, deckCards.Count);
            deckCards[i] = deckCards[randomIndex];
            deckCards[randomIndex] = temp;
        }
    }

    // ������D�������i�K��1���͑����܂��͋c���J�[�h���܂ށj
    void DrawInitialHand(int handSize)
    {
        List<GameObject> hand = new List<GameObject>();
        GameObject importantCard = null;

        // 1���͑����܂��͋c���J�[�h��T��
        foreach (GameObject card in deckCards)
        {
            CardBase cardBase = card.GetComponent<CardBase>();
            if (cardBase is PrimeMinisterCard || cardBase is MemberCard)
            {
                importantCard = card;
                break;
            }
        }

        if (importantCard != null)
        {
            hand.Add(importantCard);
            deckCards.Remove(importantCard);
        }

        // �c��̃J�[�h��ǉ�
        while (hand.Count < handSize)
        {
            if (deckCards.Count == 0)
            {
                Debug.LogError("�f�b�L�ɃJ�[�h������܂���I");
                break;
            }

            hand.Add(deckCards[0]);
            deckCards.RemoveAt(0);
        }

        // ��D��HandZone�ɔz�u
        ArrangeHandCards(hand);
    }

    // ��D�������т�HandZone�ɔz�u�i�d�Ȃ�Ȃ��悤�����j
    void ArrangeHandCards(List<GameObject> hand)
    {
        int cardCount = hand.Count;
        float cardSpacing = handZoneWidth / (cardCount + 1); // �J�[�h�Ԃ̊Ԋu���v�Z
        float startX = -handZoneWidth / 2 + cardSpacing; // �z�u�̊J�n�ʒu

        for (int i = 0; i < hand.Count; i++)
        {
            GameObject card = hand[i];
            card.transform.SetParent(handZone);
            card.transform.localPosition = new Vector3(startX + i * cardSpacing, 0, 0); // �����тɔz�u
            card.transform.localRotation = Quaternion.identity; // ��]�����Z�b�g
            // �� localScale���ێ�
        }

        Debug.Log("��D��HandZone�ɔz�u����܂����B");
    }
}
