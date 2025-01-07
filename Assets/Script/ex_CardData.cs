using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "CardGame/CardData")]
public class CardData : ScriptableObject
{
    public string characterName;        // キャラクター名
    public string cardAbility;          // カードの能力
    public int power;                   // 攻撃力
    public int tax;                     // 必要コスト
    public Sprite characterImage;       // キャラクター画像
    public Sprite backgroundImage;      // キャラクター背景画像
    public Sprite iconImage;            // カードの種類アイコン
    public Sprite cardFrameImage;       // カードのフレーム画像
}
