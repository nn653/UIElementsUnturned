﻿using UIElementsUnturned.UIElementsLib.Core.UI.Buttons;
﻿using OpenMod.API.Eventing;
using OpenMod.Unturned.Players.UI.Events;
using System.Threading.Tasks;
using UIElementsUnturned.UIElementsLib.Core.Player;
using UIElementsUnturned.UIElementsLib.Core.UI.Buttons;
using UIElementsUnturned.UIElementsLib.Core.UI.Containers;
using UIElementsUnturned.UIElementsLib.Core.UI.Holders;
using UIElementsUnturned.UIElementsLib.Core.UI.InputFields;

namespace UIElementsUnturned.UIElementsLib.OpenMod.UI.EventsListeners
{
    public sealed class UIEventListenerContainer : IUIElementsContainer
    {
        public UIEventListenerContainer()
        {
            InputFieldsHolder = new UIHolder<IInputField>();
            ButtonsHolder = new UIHolder<IButton>();
        }

        public UIHolder<IInputField> InputFieldsHolder { get; }
        public UIHolder<IButton> ButtonsHolder { get; }
    }
}
