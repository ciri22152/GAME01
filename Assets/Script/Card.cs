using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerDownHandler
{
    private FieldManager fieldManager;
    private CardZone cardZone;

    public int HP { get; private set; } = 100; // ����HP

    private void Start()
    {
        fieldManager = FindObjectOfType<FieldManager>();
        cardZone = GetComponentInParent<CardZone>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (HP <= 0)
        {
            Debug.Log("�J�[�h��HP��0�̂��߃v���C�ł��܂���I");
            return;
        }

        if (cardZone != null && cardZone.zoneType == CardZone.ZoneType.Hand)
        {
            // ��D����v���C�{�[�h�Ɉړ�
            CardZone playBoardZone = fieldManager.GetPlayBoardZone();
            if (playBoardZone != null)
            {
                playBoardZone.MoveCardFromHandToPlayBoard(this);
            }
            else
            {
                Debug.Log("�v���C�{�[�h�]�[����������܂���I");
            }
        }
    }

    public void ReduceHP(int amount)
    {
        HP -= amount;
        Debug.Log($"{gameObject.name} ��HP�� {HP} �ɂȂ�܂����B");

        if (HP <= 0)
        {
            HP = 0; // ������0�ɌŒ�
            MoveToTrash(); // �g���b�V���]�[���Ɉړ�
        }
    }

    private void MoveToTrash()
    {
        Transform trashZone = fieldManager?.trashZone;
        if (trashZone != null)
        {
            transform.SetParent(trashZone, false);
            transform.localPosition = Vector3.zero;
            Debug.Log($"{gameObject.name} ���g���b�V���]�[���Ɉړ����܂����I");
        }
        else
        {
            Debug.LogError("�g���b�V���]�[�����ݒ肳��Ă��܂���I");
        }
    }
}