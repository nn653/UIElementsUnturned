## Example how use lib by fast & simple

[Full Example Project](https://github.com/sunnamed434/UIElementsUnturned/tree/main/UIElementsUnturned.SimpleUIElementsLibPluginExample)

```cs
/// <summary>
/// Example of fast and simple way how to use UIElementsLib
/// </summary>
public sealed class SimpleUIElementsLibPluginExample : RocketPlugin
{
    public static SimpleUIElementsLibPluginExample Instance { get; private set; }



    protected override void Load()
    {
        Instance = this;

        // Way how to use it fast and simple
        PlayerUIElementsListenerContainer container = TryAddComponent<PlayerUIElementsListenerContainer>();

        // Or instead of TryAddComponent use gameobject.AddComponent
        // PlayerUIElementsListenerContainer container = gameObject.AddComponent<PlayerUIElementsListenerContainer>();

        // Adding button in Buttons Holder
        container.ButtonsHolder.AddNew(new CloseUIButton());

        // Adding input field in Input Fields Holder
        container.InputFieldsHolder.AddNew(new SearchInputField());

        // Simple way how to add button without creating any classes in the project
        container.ButtonsHolder.AddNew(new ActionButton(childObjectName: "MyButton", onClickCallback: (uPlayer) =>
        {

        }));

        container.ButtonsHolder.AddNew(new ActionButton(childObjectName: "MyUI", onClickCallback: onMyUIButtonClicked));

        // Simple way how to add input field without creating any classes in the project
        container.InputFieldsHolder.AddNew(new ActionInputField(childObjectName: "MyUIObject", onEnterInputCallback: (uPlayer, text) =>
        {

        }));

        container.InputFieldsHolder.AddNew(new ActionInputField(childObjectName: "MyUITest", onEnterInputCallback: onEnterInputInMyUIObjectInputField));
    }



    // MyUI
    private void onMyUIButtonClicked(UPlayer player)
    {
        // How to get UnturnedPlayer
        UnturnedPlayer unturnedPlayer = player.Player;
    }

    // MyUIObject
    private void onEnterInputInMyUIObjectInputField(UPlayer player, string text)
    {
        // How to get UnturnedPlayer
        UnturnedPlayer unturnedPlayer = player.Player;

        Rocket.Core.Logging.Logger.Log("The text: " + text);
    }
}
```

```cs
/// <summary>
/// Example usage of Button.
/// </summary>
public sealed class CloseUIButton : IButton
{
    /// <summary>
    /// Equal this property same name of your GameObject as you have in Unity, in simple words your GameObject name.
    /// </summary>
    public string ChildObjectName => "CloseButton";



    /// <summary>
    /// Best practice to use it explicitly, but you can use it by default.
    /// </summary>
    /// <param name="executor"></param>
    void IButton.OnClick(UPlayer executor)
    {
        // Example of using player.
        // executor.Player - this is UnturnedPlayer
    }
}
```

```cs
/// <summary>
/// One more example, better check CloseUIButton.
/// </summary>
public sealed class SearchInputField : IInputField
{
    public string ChildObjectName => "SearchInputField";



    void IInputField.OnEnterInput(UPlayer executor, string text)
    {
        // executor is unturnedplayer who called it
        // text - the text which player enter in input field

        Rocket.Core.Logging.Logger.Log("Executor Name: " + executor.Player.CharacterName);
        Rocket.Core.Logging.Logger.Log("Wrote in inputfield next text: " + text);
    }
}
```

### Default
[Another example](https://github.com/sunnamed434/UIElementsUnturned/blob/main/Plugin%20Examples/DEFAULT_EXAMPLE.md)