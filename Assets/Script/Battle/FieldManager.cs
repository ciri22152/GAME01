using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    private BattleManager battleManager;
    public Transform handsCanvas;
    public Transform trashZone;
    public List<Transform> cardZones; // CardZone, CardZone1, CardZone2, CardZone3 �̃��X�g

    private int currentZoneIndex = 0;

    public void InitHands(BattleManager _battleManager)
    {
        battleManager = _battleManager;
        Debug.Log("FieldManager.cs : ����������");

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

    // �g�p�\�Ȏ��̃]�[����Ԃ�
    public Transform GetNextAvailableZone()
    {
        // �]�[�������ׂĎg�p����Ă��邩�`�F�b�N
        for (int i = currentZoneIndex; i < cardZones.Count; i++)
        {
            Transform zone = cardZones[i];
            // �]�[�����̃J�[�h�����m�F
            if (zone.childCount == 0)  // �]�[���ɃJ�[�h���Ȃ��ꍇ
            {
                currentZoneIndex = i + 1;  // ���̃]�[���ɐi��
                Debug.Log($"���̋󂫃]�[��: {zone.name}");
                return zone;
            }
        }

        Debug.Log("���ׂẴ]�[�����g�p����Ă��܂��I");
        return null; // �󂢂Ă���]�[�����Ȃ��ꍇ
    }
}