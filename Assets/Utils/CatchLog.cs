using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Debug.Log()をUI.Textに表示
/// </summary>
public class CatchLog : MonoBehaviour
{
    private Text uiText;

    [SerializeField, Tooltip("新しいログがUI範囲内に収まるようにテキストを調整する(Truncate限定)")]
    private bool viewInRect = true;
        
    private void Awake()
    {
        uiText = this.GetComponent<Text>();
        if (uiText == null)
            throw new System.NullReferenceException("No text component found.");
    }

    private void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    private void HandleLog(string logText, string stackTrace, LogType logType)
    {
        if (string.IsNullOrEmpty(logText))
            return;

        uiText.text += logText + System.Environment.NewLine;

        if (viewInRect && uiText.verticalOverflow == VerticalWrapMode.Truncate)
            AdjustText(uiText);
    }

    /// <summary>
    /// Textの範囲内に文字列を収める
    /// </summary>
    /// <param name="t"></param>
    private void AdjustText(Text t)
    {
        TextGenerator generator = t.cachedTextGenerator;
        var settings = t.GetGenerationSettings(t.rectTransform.rect.size);
        generator.Populate(t.text, settings);

        int countVisible = generator.characterCountVisible;
        if (countVisible == 0 || t.text.Length <= countVisible)
            return;

        int truncatedCount = t.text.Length - countVisible;
        var lines = t.text.Split('\n');
        foreach (string line in lines)
        {
            // 見切れている文字数が0になるまで、テキストの先頭行から消してゆく
            t.text = t.text.Remove(0, line.Length + 1);
            truncatedCount -= (line.Length + 1);
            if (truncatedCount <= 0)
                break;
        }
    }
}