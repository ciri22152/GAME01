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

    // �J�[�h�I�u�W�F�N�g���X�g
    [SerializeField] private Transform cardParent; // �J�[�h�I�u�W�F�N�g�̐e (20���̃J�[�h�̐e)
    [SerializeField] private Transform handsCanvas; // Hands�L�����o�X

    private List<Transform> cardList = new List<Transform>();

    // ����������
    public void Init(BattleManager _battleManager)
    {
        // �Q�Ǝ擾
        battleManager = _battleManager;

        // �q�I�u�W�F�N�g�̃J�[�h�����X�g�ɒǉ�
        foreach (Transform card in cardParent)
        {
            cardList.Add(card);
        }

        Debug.Log("FieldManager.cs : ����������");

        // �J�[�h�������_���ɔz�u
        PlaceRandomCards();
    }

    /// <summary>
    /// �����_����5���̃J�[�h��Hands�L�����o�X�ɔz�u
    /// </summary>
    private void PlaceRandomCards()
    {
        if (cardList.Count < 5)
        {
            Debug.LogError("�J�[�h�̐����s�����Ă��܂��I");
            return;
        }

        // �g�p�ς݂̃C���f�b�N�X��ǐՂ��邽�߂̃��X�g
        List<int> usedIndices = new List<int>();
        int cardCount = 5;

        for (int i = 0; i < cardCount; i++)
        {
            int randomIndex;

            // ���g�p�̃C���f�b�N�X��I��
            do
            {
                randomIndex = Random.Range(0, cardList.Count);
            } while (usedIndices.Contains(randomIndex));

            usedIndices.Add(randomIndex);

            // �J�[�h��Hands�L�����o�X�Ɉړ�
            Transform selectedCard = cardList[randomIndex];
            selectedCard.SetParent(handsCanvas);
            selectedCard.localPosition = Vector3.zero; // �����ʒu�����Z�b�g
            Debug.Log($"�J�[�h {selectedCard.name} ��Hands�ɔz�u���܂����B");
        }
    }
    /// <summary>
    /// Hands�L�����o�X�̏�����
    /// </summary>
    public void InitHands()
    {
        // �����_���ɃJ�[�h��Hands�L�����o�X�ɔz�u
        PlaceRandomCards();
        Debug.Log("FieldManager.cs : Hands�̏���������");
    }

    // Update
    void Update()
    {

    }
}
