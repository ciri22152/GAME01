using UnityEngine;

public class PolicyCard : CardBase
{
    public string policyEffect; // �J�[�h�̌��ʁi����������ʓ��e�j

    public override void ExecuteEffect()
    {
        Debug.Log($"{cardName}�i����j�����ʂ𔭓�: {policyEffect}");
        // ����J�[�h���L�̌��ʂ������ɒǉ�
    }
}
