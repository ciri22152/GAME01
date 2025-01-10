using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerDownHandler
{
    private bool isPlayed = false; // �J�[�h�����łɃv���C���ꂽ���ǂ���
    private FieldManager fieldManager;

    public int HP { get; private set; } = 100; // ����HP

    private void Start()
    {
        fieldManager = FindObjectOfType<FieldManager>();
    }

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

        if (fieldManager != null)
        {
            Transform targetZone = fieldManager.GetNextAvailableZone();
            if (targetZone != null)
            {
                transform.SetParent(targetZone, false);
                transform.localPosition = Vector3.zero; // �]�[���̒��S�ɔz�u
                isPlayed = true; // �J�[�h���v���C�ς݂ɐݒ�
                Debug.Log($"{gameObject.name} �� {targetZone.name} �ɔz�u����܂����I");
            }
            else
            {
                Debug.Log("�󂫃]�[��������܂���I");
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