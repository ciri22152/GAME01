using UnityEngine;

public abstract class CardBase : MonoBehaviour
{
    public string cardName;   // カード名
    public string Seitou; //政党（自民、立憲、れいわ、NHK）

    // カードごとの効果を実装する抽象メソッド
    public abstract void ExecuteEffect();
}
