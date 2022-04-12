﻿using Rocket.Core.Plugins;
using Rocket.Unturned.Player;
using UIElementsLib.Core.UI.InputField;
using UIElementsUnturned.SimpleUIElementsLibPluginExample.UI.Buttons;
using UIElementsUnturned.SimpleUIElementsLibPluginExample.UI.InputFields;
using UIElementsUnturned.UIElementsLib.Core.Player;
using UIElementsUnturned.UIElementsLib.Core.UI.Button;
using UIElementsUnturned.UIElementsLib.Core.UI.User.Container.Component;

namespace UIElementsUnturned.SimpleUIElementsLibPluginExample
{
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
}