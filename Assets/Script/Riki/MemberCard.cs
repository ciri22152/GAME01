using UnityEngine;

public class MemberCard : CombatCard
{
    public override void ExecuteEffect()
    {
        Debug.Log($"{cardName}（議員）が{attackName}で攻撃！ 攻撃力: {attackPower}");
        // 議員カード特有の効果をここに追加
    }
}
