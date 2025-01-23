using UnityEngine;

public class PrimeMinisterCard : CombatCard
{
    public override void ExecuteEffect()
    {
        Debug.Log($"{cardName}（総理）が{attackName}で攻撃！ 攻撃力: {attackPower}");
        // 総理カード特有の効果をここに追加
    }
}
