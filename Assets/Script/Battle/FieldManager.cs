using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    public Transform handsArea; // Hands�G���A��Transform
    public GameObject cardPrefab; // �J�[�h�̃v���n�u
    public Transform playBoardArea; // PlayBoard�G���A��Transform
    public Transform trashArea; // CardZone_Trash�G���A��Transform

    private Card draggingCard; // �h���b�O���̃J�[�h
    private bool isDragging = false; // �h���b�O�t���O

    /// <summary>
    /// Hands�G���A�ɃJ�[�h��z�u����
    /// </summary>
    public void InitHands()
    {
        const int cardCount = 5; // �z�u����J�[�h�̖���
        const float spacing = 150f; // �J�[�h�Ԃ̃X�y�[�X
        const float startX = -300f; // �ŏ��̃J�[�h��X���W
        const float cardWidth = 100f; // �J�[�h�̕�
        const float cardHeight = 150f; // �J�[�h�̍���

        for (int i = 0; i < cardCount; i++)
        {
            // �J�[�h����
            GameObject cardObject = Instantiate(cardPrefab, handsArea);

            // RectTransform ���擾���ăT�C�Y��ݒ�
            RectTransform cardRect = cardObject.GetComponent<RectTransform>();
            cardRect.sizeDelta = new Vector2(cardWidth, cardHeight); // �J�[�h�̃T�C�Y��ݒ�
            cardRect.localScale = Vector3.one; // �X�P�[�������Z�b�g

            // �z�u�ʒu���v�Z���Đݒ�
            float xPosition = startX + i * spacing;
            cardRect.anchoredPosition = new Vector2(xPosition, 0);

            // �J�[�h�̃h���b�O�C�x���g��ݒ�
            Card card = cardObject.GetComponent<Card>();
            card.Init(this); // Init���\�b�h�Ńh���b�O������Ǘ�
            Debug.Log($"�J�[�h{i + 1}��Hands�G���A�ɔz�u���܂���");
        }
    }

    /// <summary>
    /// �h���b�O���J�n����
    /// </summary>
    public void StartDragging(Card card)
    {
        draggingCard = card;
        isDragging = true;
        card.transform.SetAsLastSibling(); // �őO�ʂɕ\��
    }

    /// <summary>
    /// �h���b�O���ɃJ�[�h���ړ�����
    /// </summary>
    public void UpdateDragging(Vector2 mousePosition)
    {
        if (isDragging && draggingCard != null)
        {
            // �J�[�h�̈ʒu���}�E�X�ʒu�ɍ��킹��
            draggingCard.rectTransform.position = mousePosition;
        }
    }

    /// <summary>
    /// �h���b�O���I�����A�J�[�h��K�؂ȃ]�[���ɔz�u����
    /// </summary>
    public void EndDragging()
    {
        if (draggingCard == null)
            return;

        // �}�E�X�̈ʒu���擾
        Vector3 mousePosition = Input.mousePosition;

        // PlayBoard�G���A�܂���CardZone_Trash�G���A�ɃJ�[�h��z�u
        if (RectTransformUtility.RectangleContainsScreenPoint(playBoardArea.GetComponent<RectTransform>(), mousePosition))
        {
            // PlayBoard�G���A�ɔz�u
            draggingCard.rectTransform.SetParent(playBoardArea);
            draggingCard.rectTransform.anchoredPosition = Vector2.zero; // PlayBoard��̎w��ʒu�ɐݒ�
            Debug.Log("�J�[�h��PlayBoard�G���A�ɔz�u���܂���");
        }
        else if (RectTransformUtility.RectangleContainsScreenPoint(trashArea.GetComponent<RectTransform>(), mousePosition))
        {
            // Trash�G���A�ɔz�u
            draggingCard.rectTransform.SetParent(trashArea);
            draggingCard.rectTransform.anchoredPosition = Vector2.zero; // Trash�G���A��̎w��ʒu�ɐݒ�
            Debug.Log("�J�[�h��CardZone_Trash�G���A�ɔz�u���܂���");
        }
        else
        {
            // �z�u�悪�Ȃ���Ό��̈ʒu�ɖ߂�
            draggingCard.rectTransform.SetParent(handsArea);
            draggingCard.rectTransform.anchoredPosition = draggingCard.initialPosition;
            Debug.Log("�J�[�h�����̈ʒu�ɖ߂���܂���");
        }

        // �h���b�O��Ԃ��I��
        isDragging = false;
        draggingCard = null;
    }
}


