using System.Collections.Generic;
using UnityEngine;

public class CardZone : MonoBehaviour
{
    // �]�[����ޒ�`
    public enum ZoneType
    {
        Hand,         // ��D
        PlayBoard,    // �v���C�{�[�h
        Trash         // �g���b�V��(�S�~��)
    }

    // ���̃]�[���̎��
    public ZoneType zoneType;

    // �g���b�V���]�[���̎Q��
    public CardZone trashZone;

    // ��D�]�[���̎Q��
    public CardZone handZone;

    void Update()
    {
        // ��D��v���C�{�[�h�̃J�[�h�̏�Ԃ��`�F�b�N
        if (zoneType == ZoneType.PlayBoard)
        {
            CheckAndMoveToTrash();
        }
    }

    // HP��0�ȉ��̃J�[�h���g���b�V���]�[���Ɉړ�
    public void CheckAndMoveToTrash()
    {
        List<Transform> toTrash = new List<Transform>();

        // �]�[�����̃J�[�h���`�F�b�N
        foreach (Transform cardTransform in transform)
        {
            Card card = cardTransform.GetComponent<Card>();
            if (card != null && card.HP <= 0) // HP��0�ȉ��̃J�[�h���m�F
            {
                toTrash.Add(cardTransform);
            }
        }

        // �g���b�V���]�[���Ɉړ�
        foreach (Transform cardTransform in toTrash)
        {
            cardTransform.SetParent(trashZone.transform, false);
            cardTransform.localPosition = Vector3.zero; // �g���b�V���̒��S�ɔz�u
            Debug.Log($"{cardTransform.name} �� {zoneType} ���� Trash �Ɉړ����܂����I");
        }

        // �J�[�h�]�[������̏ꍇ�A��D����J�[�h���ړ�
        if (transform.childCount == 0)
        {
            Debug.Log("�v���C�{�[�h����ł��B��D����J�[�h���N���b�N���Ĕz�u���Ă��������B");
        }
    }

    // ��D����J�[�h���N���b�N���ăv���C�{�[�h�ɔz�u
    public void MoveCardFromHandToPlayBoard(Card card)
    {
        card.transform.SetParent(transform, false);
        card.transform.localPosition = Vector3.zero; // �]�[���̒��S�ɔz�u
        Debug.Log($"{card.name} ����D����v���C�{�[�h�Ɉړ����܂����I");
    }
}