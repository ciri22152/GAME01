using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerDownHandler
{
    private bool isPlayed = false; // �J�[�h�����łɃv���C���ꂽ���ǂ���
    public Transform cardZone; // �z�u���CardZone
    public Transform trashZone; // �g���b�V���]�[����Transform

    public int HP { get; private set; } = 100; // ����HP

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isPlayed)
        {
            Debug.Log("���̃J�[�h�͂��łɃv���C����Ă��܂��I");
            return;
        }

        if (HP <= 0)
        {
            Debug.Log("�J�[�h��HP��0�̂��߃v���C�ł��܂���I");
            return;
        }

        if (cardZone != null)
        {
            // �J�[�h��CardZone�Ɉړ�
            transform.SetParent(cardZone, false);
            transform.localPosition = Vector3.zero; // CardZone�̒��S�ɔz�u
            isPlayed = true; // �J�[�h���v���C�ς݂ɐݒ�
            Debug.Log($"{gameObject.name} �� CardZone �ɔz�u����܂����I");
        }
    }

    // HP�����������郁�\�b�h
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

    // �J�[�h���g���b�V���]�[���Ɉړ����郁�\�b�h
    private void MoveToTrash()
    {
        if (trashZone != null)
        {
            transform.SetParent(trashZone, false);
            transform.localPosition = Vector3.zero; // �g���b�V���]�[���̒��S�ɔz�u
            Debug.Log($"{gameObject.name} ���g���b�V���]�[���Ɉړ����܂����I");
        }
        else
        {
            Debug.LogError("�g���b�V���]�[�����ݒ肳��Ă��܂���I");
        }
    }
}

