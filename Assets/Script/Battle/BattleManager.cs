using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public FieldManager fieldManager; // �t�B�[���h�Ǘ��N���X�̎Q��

    void Start()
    {
        // �t�B�[���h�Ǘ��̏����� (�J�[�h�z�u�Ȃ�)
        if (fieldManager != null)
        {
            Debug.Log("BattleManager: �t�B�[���h�����������s���܂�");
            fieldManager.InitHands(); // InitHands ���\�b�h���Ăяo��
        }
        else
        {
            Debug.LogError("BattleManager: FieldManager �����蓖�Ă��Ă��܂���");
        }
    }
}
