using UnityEngine;

public class MemberCard : CombatCard
{
    public override void ExecuteEffect()
    {
        Debug.Log($"{cardName}�i�c���j��{attackName}�ōU���I �U����: {attackPower}");
        // �c���J�[�h���L�̌��ʂ������ɒǉ�
    }
}
