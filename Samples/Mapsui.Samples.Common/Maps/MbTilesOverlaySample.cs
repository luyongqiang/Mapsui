﻿using System.IO;
using BruTile.MbTiles;
using BruTile.Predefined;
using Mapsui.Layers;
using Mapsui.Samples.Tests.Maps;
using Mapsui.UI;
using SQLite;

namespace Mapsui.Samples.Common.Maps
{
    public class MbTilesOverlaySample : IDemoSample
    {
        public string Name => "3.2 MbTiles Overlay";

        public void Setup(IMapControl mapControl)
        {
            mapControl.Map = CreateMap();
        }

        public static Map CreateMap()
        {
            var map = new Map();
            map.Layers.Add(new TileLayer(KnownTileSources.Create(KnownTileSource.BingAerial)) { Name = "Bing Aerial" });
            map.Layers.Add(CreateMbTilesLayer(Path.Combine(MbTilesSample.MbTilesLocation, "torrejon-de-ardoz.mbtiles")));
            return map;
        }
        public static TileLayer CreateMbTilesLayer(string path)
        {
            var mbTilesTileSource = new MbTilesTileSource(new SQLiteConnectionString(path, true));
            var mbTilesLayer = new TileLayer(mbTilesTileSource);
            return mbTilesLayer;
        }
    }
}