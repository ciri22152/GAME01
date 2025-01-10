using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siziritu : MonoBehaviour
{
    public Transform cardZoneTrash; // CardZone_Trash��Transform
    public GameObject highImage;    // High�C���[�W
    public GameObject midImage;     // Mid�C���[�W
    public GameObject lowImage;     // Low�C���[�W

    // Start is called before the first frame update
    void Start()
    {
        // �ŏ��̏�ԂŃ`�F�b�N���Đݒ�
        UpdateCardZoneDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        // ���t���[���J�[�h�̐��Ɋ�Â��ĕ\�����X�V
        UpdateCardZoneDisplay();
    }

    // CardZone_Trash�̃J�[�h���ɉ����ĕ\�����X�V���郁�\�b�h
    private void UpdateCardZoneDisplay()
    {
        if (cardZoneTrash == null)
        {
            Debug.LogError("CardZone_Trash���ݒ肳��Ă��܂���I");
            return;
        }

        // CardZone_Trash���̃J�[�h�̐����擾
        int cardCount = cardZoneTrash.childCount;

        // 0���̏ꍇ (High�C���[�W��\��)
        if (cardCount == 0)
        {
            SetImageVisibility(highImage, true);
            SetImageVisibility(midImage, false);
            SetImageVisibility(lowImage, false);
        }
        // 1���̏ꍇ
        else if (cardCount == 1)
        {
            SetImageVisibility(highImage, false);
            SetImageVisibility(midImage, true);
            SetImageVisibility(lowImage, false);
        }
        // 2���̏ꍇ
        else if (cardCount == 2)
        {
            SetImageVisibility(highImage, false);
            SetImageVisibility(midImage, false);
            SetImageVisibility(lowImage, true);
        }
        // ���̑��̏ꍇ�͂��ׂĔ�\��
        else
        {
            SetImageVisibility(highImage, false);
            SetImageVisibility(midImage, false);
            SetImageVisibility(lowImage, false);
        }
    }

    // �摜�̕\���E��\����؂�ւ���w���p�[���\�b�h
    private void SetImageVisibility(GameObject imageObject, bool isVisible)
    {
        if (imageObject != null)
        {
            imageObject.SetActive(isVisible);
        }
    }
}

