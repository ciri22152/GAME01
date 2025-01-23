using UnityEngine;

public abstract class CombatCard : CardBase
{
    public int hp;              // ヒットポイント
    public int attackCost;      // 攻撃に必要なコスト
    public int attackPower;     // 攻撃力
    public string attackName;   // 攻撃の名前

    public void TakeDamage(int damage)
    {
        hp -= damage;
        Debug.Log($"{cardName}が{damage}ダメージを受けた！ 残りHP: {hp}");
        if (hp <= 0)
        {
            Debug.Log($"{cardName}が倒されました！");
        }
    }
}
