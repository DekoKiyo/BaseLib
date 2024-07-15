using Rage;

namespace BaseLib;

/// <summary>
/// ログの深刻度を示す
/// </summary>
public enum LogType
{
    /// <summary>
    /// 情報
    /// </summary>
    Info,
    /// <summary>
    /// 警告
    /// </summary>
    Warn,
    /// <summary>
    /// エラー
    /// </summary>
    Error,
}

/// <summary>
/// 各プラグインごとに一つづつ生成するロガークラス
/// </summary>
public class Logger
{
    private readonly string pluginName;

    /// <summary>
    /// ログの頭にプラグインの名前が付随するロガーのインスタンスを生成
    /// </summary>
    /// <param name="pluginName">プラグイン名</param>
    public Logger(string pluginName)
    {
        this.pluginName = pluginName;
        Info($"Logger was initialized by {pluginName}", pluginName: Main.LIB_NAME);
    }

    /// <summary>
    /// 情報ログの送信
    /// </summary>
    /// <param name="text">テキスト</param>
    public void Info(string text) => Log(text, LogType.Info);
    /// <summary>
    /// 警告ログの送信
    /// </summary>
    /// <param name="text">テキスト</param>
    public void Warn(string text) => Log(text, LogType.Warn);
    /// <summary>
    /// エラーログの送信
    /// </summary>
    /// <param name="text">テキスト</param>
    public void Error(string text) => Log(text, LogType.Error);
    /// <summary>
    /// 情報ログの送信 (強化版)
    /// </summary>
    /// <param name="text">テキスト</param>
    /// <param name="tag">タグ</param>
    /// <param name="pluginName">プラグイン名</param>
    public void Info(string text, string tag = "", string pluginName = "") => Log(text, LogType.Info, tag, pluginName);
    /// <summary>
    /// 警告ログの送信 (強化版)
    /// </summary>
    /// <param name="text">テキスト</param>
    /// <param name="tag">タグ</param>
    /// <param name="pluginName">プラグイン名</param>
    public void Warn(string text, string tag = "", string pluginName = "") => Log(text, LogType.Warn, tag, pluginName);
    /// <summary>
    /// エラーログの送信 (強化版)
    /// </summary>
    /// <param name="text">テキスト</param>
    /// <param name="tag">タグ</param>
    /// <param name="pluginName">プラグイン名</param>
    public void Error(string text, string tag = "", string pluginName = "") => Log(text, LogType.Error, tag, pluginName);

    private void Log(string text, LogType type = LogType.Info, string tag = "", string pluginName = "")
    {
        if (!string.IsNullOrEmpty(tag))
        {
            Game.Console.Print($"{(string.IsNullOrEmpty(pluginName) ? this.pluginName : pluginName)}: [{type} - {tag}] {text}");
        }
        else
        {
            Game.Console.Print($"{(string.IsNullOrEmpty(pluginName) ? this.pluginName : pluginName)}: [{type}] {text}");
        }
    }
}