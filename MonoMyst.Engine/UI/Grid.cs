using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.Engine.UI
{
    public class Grid : Widget
    {
        private ObservableCollection<ColumnDefinition> _columnDefinitions = new ObservableCollection<ColumnDefinition> ();
        private ObservableCollection<RowDefinition> _rowDefinitions = new ObservableCollection<RowDefinition> ();

        private ObservableCollection<Widget> _widgets = new ObservableCollection<Widget> ();

        public ObservableCollection<Widget> Widgets => _widgets;

        public ObservableCollection<ColumnDefinition> ColumnDefinitions => _columnDefinitions;
        public ObservableCollection<RowDefinition> RowDefinitions => _rowDefinitions;

        public bool DebugDraw = false;

        private Texture2D rect;

        private int TotalWidth
        {
            get
            {
                int width = 0;

                if (ColumnDefinitions.Count == 0)
                {
                    width = MonoMystGame.GraphicsDeviceManager.GraphicsDevice.Viewport.Bounds.Width;
                }

                return width;
            }
        }

        private int TotalHeight
        {
            get
            {
                int height = 0;

                if (RowDefinitions.Count == 0)
                {
                    height = MonoMystGame.GraphicsDeviceManager.GraphicsDevice.Viewport.Bounds.Height;
                }

                return height;
            }
        }

        public Grid ()
        {
            _widgets.CollectionChanged += WidgetsChanged;
            _columnDefinitions.CollectionChanged += ColumnsChanged;
            _rowDefinitions.CollectionChanged += RowsChanged;
        }

        public override void Initialize ()
        {
            base.Initialize ();

            rect = MonoMystGame.MMContent.Load<Texture2D> ("Rectangle");
        }

        private void WidgetsChanged (object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (Widget w in e.NewItems)
                {
                    w.Parent = this;
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (Widget w in e.NewItems)
                {
                    w.Parent = null;
                }
            }
        }

        private void ColumnsChanged (object sender, NotifyCollectionChangedEventArgs e)
        {
        }

        private void RowsChanged (object sender, NotifyCollectionChangedEventArgs e)
        {
        }

        public override void Draw (SpriteBatch spriteBatch)
        {
            base.Draw (spriteBatch);

            if (DebugDraw)
            {
                spriteBatch.Draw (rect, new Rectangle (0, 0, TotalWidth, 1), Color.Cyan);
                spriteBatch.Draw (rect, new Rectangle (TotalWidth - 1, 0, 1, TotalHeight), Color.Cyan);
                spriteBatch.Draw (rect, new Rectangle (0, TotalHeight - 1, TotalWidth, 1), Color.Cyan);
                spriteBatch.Draw (rect, new Rectangle (0, 0, 1, TotalHeight), Color.Cyan);
            }

            foreach (Widget w in _widgets)
                w.Draw (spriteBatch);
        }
    }
}
