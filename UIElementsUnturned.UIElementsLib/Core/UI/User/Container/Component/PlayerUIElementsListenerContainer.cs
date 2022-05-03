﻿using SDG.Unturned;
using UIElementsUnturned.UIElementsLib.Core.Player;
using UIElementsUnturned.UIElementsLib.Core.UI.Button;
using UIElementsUnturned.UIElementsLib.Core.UI.ChildObjectName.String;
using UIElementsUnturned.UIElementsLib.Core.UI.Holder;
using UIElementsUnturned.UIElementsLib.Core.UI.InputField;
using UnityEngine;

namespace UIElementsUnturned.UIElementsLib.Core.UI.User.Container.Component
{
    public sealed class PlayerUIElementsListenerContainer : MonoBehaviour, IUIElementsContainer
    {
        public UIHolder<IInputField> InputFieldsHolder { get; private set; }

        public UIHolder<IButton> ButtonsHolder { get; private set; }



        private void Awake()
        {
            InputFieldsHolder = new UIHolder<IInputField>();
            ButtonsHolder = new UIHolder<IButton>();
        }

        private void OnEnable()
        {
            EffectManager.onEffectTextCommitted += onInputFieldTextCommitted;
            EffectManager.onEffectButtonClicked += onButtonClicked;
        }

        private void OnDisable()
        {
            EffectManager.onEffectTextCommitted -= onInputFieldTextCommitted;
            EffectManager.onEffectButtonClicked -= onButtonClicked;
        }



        private void onInputFieldTextCommitted(SDG.Unturned.Player player, string inputField, string text)
        {
            if (InputFieldsHolder.TryFindItemByName(new ChildObjectNameString(inputField), out IInputField holder))
                holder.OnEnterInput(new UPlayer(player), text);
        }

        private void onButtonClicked(SDG.Unturned.Player player, string button)
        {
            if (ButtonsHolder.TryFindItemByName(new ChildObjectNameString(button), out IButton holder))
                holder.OnClick(new UPlayer(player));
        }
    }
}
