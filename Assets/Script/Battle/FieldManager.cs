using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �t�B�[���h�Ǘ��N���X
/// </summary>
public class FieldManager : MonoBehaviour
{
    // �I�u�W�F�N�g�E�R���|�[�l���g�Q��
    private BattleManager battleManager; // �퓬��ʃ}�l�[�W��
    public Transform handsCanvas; // Hands�L�����p�X��Transform

    // ����������
    public void InitHands(BattleManager _battleManager)
    {
        // �Q�Ǝ擾
        battleManager = _battleManager;

        Debug.Log("FieldManager.cs : ����������");

        // �J�[�h�������_���ɔz�u
        PlaceRandomCards();
    }

    // �J�[�h�������_���ɔz�u���郁�\�b�h
    private void PlaceRandomCards()
    {
        List<Transform> cards = new List<Transform>();

        // �q�I�u�W�F�N�g����J�[�h���擾
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (child.name.StartsWith("Card"))
            {
                cards.Add(child);
            }
        }

        // �J�[�h�������_���ɃV���b�t��
        for (int i = 0; i < cards.Count; i++)
        {
            Transform temp = cards[i];
            int randomIndex = Random.Range(i, cards.Count);
            cards[i] = cards[randomIndex];
            cards[randomIndex] = temp;
        }

        // �ŏ���5����Hands�L�����p�X�ɔz�u
        for (int i = 0; i < 5 && i < cards.Count; i++)
        {
            cards[i].SetParent(handsCanvas, false);
        }
    }

    // Update
    void Update()
    {

    }
}