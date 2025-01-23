using UnityEngine;

public class PlaceZone : MonoBehaviour
{
    public enum ZoneType { Field, Seat }

    public ZoneType zoneType; // �ꂩ�c�Ȃ��𔻒�
    public int maxCardsInZone = 1; // ��̏ꍇ��1���A�c�Ȃ̏ꍇ��3���܂�

    private int currentCardCount = 0; // ���ݔz�u����Ă���J�[�h�̐�

    // �J�[�h�������ɔz�u���ꂽ�Ƃ��̏���
    public bool CanPlaceCard()
    {
        return currentCardCount < maxCardsInZone;
    }

    // �J�[�h�����̃]�[���ɔz�u
    public void PlaceCard(GameObject card)
    {
        if (CanPlaceCard())
        {
            currentCardCount++;
            // �ʒu�𒲐��i�J�[�h���u�����ʒu�j
            RectTransform cardRect = card.GetComponent<RectTransform>();
            cardRect.position = transform.position; // �]�[���̒��S�ɔz�u

            // �ꂩ�c�Ȃ��ɂ���ăJ�[�h�T�C�Y��ύX
            if (zoneType == ZoneType.Field)
            {
                cardRect.localScale = new Vector3(1.5f, 1.5f, 1); // ��ɒu�����ƃJ�[�h���傫���Ȃ�
            }
            else if (zoneType == ZoneType.Seat)
            {
                cardRect.localScale = new Vector3(1f, 1f, 1); // �c�Ȃɒu�����ƌ��̑傫��
            }
        }
    }

    // �J�[�h����菜���ꂽ�Ƃ��̏���
    public void RemoveCard()
    {
        if (currentCardCount > 0)
        {
            currentCardCount--;
        }
    }
}
