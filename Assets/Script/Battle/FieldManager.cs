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

    // ����������
    public void Init(BattleManager _battleManager)
    {
        // �Q�Ǝ擾
        battleManager = _battleManager;

        Debug.Log("FieldManager.cs : ����������");
    }

    // Update
    void Update()
    {

    }
}
