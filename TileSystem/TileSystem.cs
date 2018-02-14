using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using TiledSharp;

namespace MonoMyst.TileSystem
{
    public class TileSystem
    {
        private TmxMap map;
        private Texture2D tileset;

        private int tileWidth;
        private int tileHeight;
        private int tilesetTileWide;
        private int tilesetTileHigh;

        public TileSystem (TmxMap map, Texture2D tileset)
        {
            this.map = map;
            this.tileset = tileset;

            tileWidth = map.Tilesets [0].TileWidth;
            tileHeight = map.Tilesets [0].TileHeight;

            tilesetTileWide = tileset.Width / tileWidth;
            tilesetTileHigh = tileset.Height / tileHeight;
        }

        public void Draw (SpriteBatch spriteBatch)
        {
            for (int i = 0; i < map.Layers [0].Tiles.Count; i++)
            {
                int gid = map.Layers [0].Tiles [i].Gid;

                if (gid != 0)
                {
                    int tileFrame = gid - 1;
                    int column = tileFrame % tilesetTileWide;
                    int row = (int) Math.Floor ((double) tileFrame / (double) tilesetTileWide);
                
                    float x = (i % map.Width) * map.TileWidth;
                    float y = (float) Math.Floor (i / (double) map.Width) * map.TileHeight;

                    Rectangle tilesetRect = new Rectangle (tileWidth * column, tileHeight * row, tileWidth, tileHeight);

                    spriteBatch.Draw (tileset, new Rectangle ((int) x, (int) y, tileWidth, tileHeight), tilesetRect, Color.White);
                }
            }
        }
    }
}