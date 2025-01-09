using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerDownHandler
{
    private bool isPlayed = false; // �J�[�h�����łɃv���C���ꂽ���ǂ���
    public Transform cardZone; // �J�[�h��z�u����CardZone

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isPlayed)
        {
            Debug.Log("���̃J�[�h�͂��łɃv���C����Ă��܂��I");
            return; // ��x�����v���C�ł���悤�ɐ���
        }

        if (cardZone == null)
        {
            Debug.LogError("CardZone���ݒ肳��Ă��܂���I");
            return;
        }

        // �J�[�h��CardZone�Ɉړ�
        transform.SetParent(cardZone, false);
        transform.localPosition = Vector3.zero; // CardZone�̒��S�ɔz�u
        isPlayed = true; // �J�[�h���v���C�ς݂ɐݒ�

        Debug.Log($"{gameObject.name} �� CardZone �ɔz�u����܂����I");
    }
}
