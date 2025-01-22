using UnityEngine;

public class CanvasSwitcher : MonoBehaviour
{
    // TitleCanvasとGameCanvasの参照
    [SerializeField] private GameObject titleCanvas;
    [SerializeField] private GameObject gameCanvas;

    // ボタンがクリックされたときに呼び出される関数
    public void SwitchToGameCanvas()
    {
        // TitleCanvasを非表示にし、GameCanvasを表示する
        titleCanvas.SetActive(false);
        gameCanvas.SetActive(true);
    }
}
