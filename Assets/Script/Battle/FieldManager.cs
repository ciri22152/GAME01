using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    private BattleManager battleManager; // �퓬��ʃ}�l�[�W��
    public Transform handsCanvas; // Hands�L�����o�X��Transform
    public Transform trashZone; // �g���b�V���]�[����Transform
    public Transform cardZone; // CardZone��Transform

    // ����������
    public void InitHands(BattleManager _battleManager)
    {
        battleManager = _battleManager;
        Debug.Log("FieldManager.cs : ����������");

        // �J�[�h�������_���ɔz�u
        PlaceRandomCards();
    }

    private void PlaceRandomCards()
    {
        List<Transform> cards = new List<Transform>();

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (child.name.StartsWith("Card"))
            {
                cards.Add(child);
            }
        }

        for (int i = 0; i < cards.Count; i++)
        {
            Transform temp = cards[i];
            int randomIndex = Random.Range(i, cards.Count);
            cards[i] = cards[randomIndex];
            cards[randomIndex] = temp;
        }

        for (int i = 0; i < 5 && i < cards.Count; i++)
        {
            cards[i].SetParent(handsCanvas, false);
        }
    }

    // CardZone�C���[�W���̃J�[�h��HP�����������郁�\�b�h
    public void ReduceHPInCardZone(int amount)
    {
        if (cardZone == null)
        {
            Debug.LogError("CardZone���ݒ肳��Ă��܂���I");
            return;
        }

        foreach (Transform card in cardZone)
        {
            Card cardComponent = card.GetComponent<Card>();
            if (cardComponent != null)
            {
                cardComponent.ReduceHP(amount);
            }
        }
    }
}
