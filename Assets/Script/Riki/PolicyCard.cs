using UnityEngine;

public class PolicyCard : CardBase
{
    public string policyEffect; // カードの効果（説明文や効果内容）

    public override void ExecuteEffect()
    {
        Debug.Log($"{cardName}（政策）が効果を発動: {policyEffect}");
        // 政策カード特有の効果をここに追加
    }
}
