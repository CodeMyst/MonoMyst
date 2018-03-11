using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoMyst.Engine.UI.Widgets
{
    public class MenuBarButtonWidget : Widget
    {
        public string Title { get; protected set; }
        protected MenuBarButtonType ButtonType;

        public event Action OnClicked;

        public MenuBarButtonWidget (string title, MenuBarButtonType buttonType)
        {
            Title = title;
            ButtonType = buttonType;
        }
    }
}
