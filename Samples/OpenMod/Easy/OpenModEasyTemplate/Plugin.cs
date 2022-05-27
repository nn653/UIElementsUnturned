﻿using Cysharp.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OpenMod.API.Plugins;
using OpenMod.API.Users;
using OpenMod.Core.Users;
using OpenMod.Unturned.Plugins;
using OpenMod.Unturned.Users;
using System;
using System.Threading.Tasks;
using UIElementsUnturned.Samples.OpenMod.Easy.OpenModEasySample.UI.Buttons;
using UIElementsUnturned.Samples.OpenMod.Easy.OpenModEasySample.UI.InputFields;
using UIElementsUnturned.UIElementsLib.Core.Player;
using UIElementsUnturned.UIElementsLib.Core.UI.Callbackables.Buttons;
using UIElementsUnturned.UIElementsLib.Core.UI.Callbackables.InputFields;
using UIElementsUnturned.UIElementsLib.Core.UI.Data;
using UIElementsUnturned.UIElementsLib.Core.UI.User.Containers;
using UIElementsUnturned.UIElementsLib.OpenMod.UI.EventsListeners;

[assembly: PluginMetadata("UIElementsLib.OpenModEasyTemplate",
    Author = "https://github.com/sunnamed434/UIElementsUnturned",
    Description = "Plugin template that shows how to use UIElementsLib.",
    Website = "github")]
namespace UIElementsUnturned.Samples.OpenMod.Easy.OpenModEasySample
{
    /// <summary>
    /// Easy way how to use UIElementLib with OpenMod.
    /// </summary>
    public class Plugin : OpenModUnturnedPlugin
    {
        private readonly IUserManager userManager;



        public Plugin(IServiceProvider serviceProvider, IUserManager userManager) : base(serviceProvider)
        {
            this.userManager = userManager;
        }



        protected override async UniTask OnLoadAsync()
        {
            IUIElementsContainer container = new UIEventListenerContainer();

            // Adding button in holder
            container.ButtonsHolder.Add(new CloseUIButton(this.userManager, Logger));

            // Adding input field in Holder
            container.InputFieldsHolder.Add(new SearchInputField(this.userManager, Logger));

            // Simple way how to add button without creating new classes in the project
            container.ButtonsHolder.Add(new ActionableButton(childObjectName: "MyButton", callback: (data, uPlayer) =>
            {

            }));

            container.ButtonsHolder.Add(new ActionableButton(childObjectName: "MyUI", callback: onMyUIButtonClicked));

            // Adding input field without creating new classes in the project
            container.InputFieldsHolder.Add(new ActionableInputField(childObjectName: "MyUIObject", callback: (data, uPlayer, text) =>
            {

            }));

            container.InputFieldsHolder.Add(new ActionableInputField(childObjectName: "MyUITest", callback: onEnterInputInMyUIObjectInputField));

            await Task.CompletedTask;
        }



        // MyUI
        private async void onMyUIButtonClicked(object caller, UPlayer player)
        {
            // How to get User
            IUser user = await userManager.FindUserAsync(
                KnownActorTypes.Player,
                player.Player.channel.owner.playerID.steamID.ToString(),
                UserSearchMode.FindById);

            // How to get UnturnedUser
            UnturnedUser unturnedUser = (UnturnedUser)user;

            Logger.Log(LogLevel.Debug, "Caller DisplayName: " + user.DisplayName);
        }

        // MyUIObject
        private async void onEnterInputInMyUIObjectInputField(object caller, UPlayer player, string text)
        {
            // How to get User
            IUser user = await userManager.FindUserAsync(
                KnownActorTypes.Player,
                player.Player.channel.owner.playerID.steamID.ToString(),
                UserSearchMode.FindById);

            IUIObjectDataContainer dataContainer = (IUIObjectDataContainer)caller;
            string uiName = dataContainer.ChildObjectName;

            Logger.Log(LogLevel.Debug, "The text: " + text);
        }
    }
}
