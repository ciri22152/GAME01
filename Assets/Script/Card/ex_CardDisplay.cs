using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public TextMeshProUGUI nameText;     // キャラクター名
    public TextMeshProUGUI abilityText;  // カードの能力
    public TextMeshProUGUI powerText;    // 攻撃力
    public TextMeshProUGUI taxText;      // 必要コスト
    public Image characterImage;         // キャラクター画像
    public Image backgroundImage;        // 背景画像
    public Image iconImage;              // アイコン画像
    public Image cardFrameImage;         // カードのフレーム画像

    // カードデータを設定するメソッド
    public void SetCardData(CardData cardData)
    {
        nameText.text = cardData.characterName;   // キャラクター名
        abilityText.text = cardData.cardAbility;  // カードの能力
        powerText.text = cardData.power.ToString();  // 攻撃力
        taxText.text = cardData.tax.ToString();      // 必要コスト

        characterImage.sprite = cardData.characterImage;  // キャラクター画像
        backgroundImage.sprite = cardData.backgroundImage;  // 背景画像
        iconImage.sprite = cardData.iconImage;           // アイコン画像
        cardFrameImage.sprite = cardData.cardFrameImage;  // カードのフレーム画像
    }
}
