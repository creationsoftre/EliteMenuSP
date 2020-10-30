using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using GTA;
using GTA.Math;
using NativeUI;

partial class MainMenu : Script
{
    public UIMenu teleportOptions;
    public UIMenu tpShops;
    public UIMenu tpSafehouses;
    public UIMenu tpLandmarks;
    public UIMenu tpInteriors;
    public UIMenu tpUnderwater;
    public UIMenu tpHigh;


    private void EliteTeleportMenu()
    {
        

        #region Setting up Teleport Menu
        teleportOptions = modMenuPool.AddSubMenu(mainMenu, "Teleport");
        
        //Teleport to Waypoint
        UIMenuItem teleportToWaypoint = new UIMenuItem("Teleport to Waypoint");
        teleportOptions.AddItem(teleportToWaypoint);
        teleportOptions.OnItemSelect += (sender, item, index) =>
        {
            if (item == teleportToWaypoint)
            {
                TeleportFunctions.TeleportToMarker();
            }
        };

        tpShops = modMenuPool.AddSubMenu(teleportOptions, "Shops");
        tpSafehouses = modMenuPool.AddSubMenu(teleportOptions, "Safehouses");
        tpLandmarks = modMenuPool.AddSubMenu(teleportOptions, "Landmarks");
        tpInteriors = modMenuPool.AddSubMenu(teleportOptions, "Interiors");
        tpUnderwater = modMenuPool.AddSubMenu(teleportOptions, "Underwater");
        tpHigh = modMenuPool.AddSubMenu(teleportOptions, "High Locations");
        #endregion

        /* Teleport By Category */
        #region Shops
        Dictionary<string, Vector3> teleportShops = new Dictionary<string, Vector3>()
        {
            {"Downtown Vinewood LS Customs", new Vector3(-365.4f, -131.8f, 37.8f)},
        };
        foreach (KeyValuePair<string, Vector3> location in teleportShops)
        {
            //Displays dictionary of locations in menu
            UIMenuItem tphopsLocation = new UIMenuItem(location.Key);

            //on select
            tphopsLocation.Activated += (sender, args) =>
            TeleportFunctions.TeleportToLocation(location);
            tpShops.AddItem(tphopsLocation);

        }
        #endregion

        #region Safehouses
        Dictionary<string, Vector3> teleportSafehouses = new Dictionary<string, Vector3>()
        {
            {"Michael's House", new Vector3(-852.4f, 160.0f, 65.6f)},
            {"Franklin's House", new Vector3(7.9f, 548.1f, 175.5f)},
            {"Franklin's Aunt House", new Vector3(-14.8f, -1454.5f, 30.5f)},
            {"Trevor's Trailer", new Vector3(1985.7f, 3812.2f, 32.2f)}

        };
        foreach (KeyValuePair<string, Vector3> location in teleportSafehouses)
        {
            //Displays dictionary of locations in menu
            UIMenuItem tpSafehouseLocation = new UIMenuItem(location.Key);

            //on select
            tpSafehouseLocation.Activated += (sender, args) =>
            TeleportFunctions.TeleportToLocation(location);
            tpSafehouses.AddItem(tpSafehouseLocation);

        }
        #endregion

        #region Landmarks
        Dictionary<string, Vector3> teleportLandmarks = new Dictionary<string, Vector3>()
        {
            {"North Yankton", new Vector3(3217.6f, -4834.8f, 111.8f)},
            {"Airport Entrance", new Vector3(-1034.6f, -2733.6f, 13.8f)},
            {"Airport Field", new Vector3(-1336.0f, -3044.0f, 13.9f)},
            {"Elysian Island", new Vector3(338.2f, -2715.9f, 38.5f)},
            {"Jetsam", new Vector3(760.4f, -2943.2f, 5.8f)},
            {"Strip Club", new Vector3(127.4f, -1307.7f, 29.2f)},
            {"Elburro Heights", new Vector3(1384.0f, -2057.1f, 52.0f)},
            {"Ferris Wheel", new Vector3(-1670.7f, -1125.0f, 13.0f)},
            {"Chumash Historic Family Pier", new Vector3(-3192.6f, 1100.0f, 20.2f)},
            {"Windfarm", new Vector3(2354.0f, 1830.3f, 101.1f)},
            {"Military Base", new Vector3(-2047.4f, 3132.1f, 32.8f)},
            {"McKenzie Airfield", new Vector3(2121.7f, 4796.3f, 41.1f)},
            {"Desert Airfield", new Vector3(1747.0f, 3273.7f, 41.1f)},
            {"Chilliad", new Vector3(425.4f, 5614.3f, 766.5f)},
            {"Heist Yatch", new Vector3(-2043.974f, -1031.582f, 11.981f)},
            {"Vinewood Bowl Stage", new Vector3(686.2f, 577.9f, 130.4f)},
            {"Galileo Observatory Roof", new Vector3(-438.8f, 1076.0f, 352.4f)},
            {"Kortz Center", new Vector3(-2243.8f, 264.0f, 174.6f)},
            {"Paleto Bay Pier", new Vector3(-275.5f, 6635.8f, 7.4f)},
            {"God's Thumb", new Vector3(-1006.4f, 6272.3f, 1.5f)},
            {"Altruist Cult Camp", new Vector3(-1170.8f, 4926.6f, 224.2f)},
            {"Raton Canyon Bridge", new Vector3(-517.8f, 4425.2f, 89.7f)},
            {"Marlowe Vineyards", new Vector3(-1868.9f, 2095.6f, 139.1f)},
            {"Hippy Camp", new Vector3(2476.7f, 3789.6f, 41.2f)},
            {"Devin Weston's House", new Vector3(-2639.8f, 1866.8f, 160.1f)},
            {"Abandon Mine", new Vector3(-595.3f, 2086.0f, 131.4f)},
            {"Weed Farm", new Vector3(2208.7f, 5578.2f, 53.7f)},
            {"Stab City", new Vector3(126.9f, 3714.4f, 46.8f)},
            {"Davis Quartz(Quarry)", new Vector3(2954.1f, 2783.4f, 41.0f)},
            {"Cargo Ship(SS Bulker)", new Vector3(899.6f, -2882.1f, 19.0f)},
            {"Los Santos Naval Port", new Vector3(486.4f, -3339.6f, 6.0f)},
            {"Del Perro Pier", new Vector3(-1850.1f, -1231.7f, 13.0f)},
            {"Play Boy Mansion", new Vector3(-1475.2f, 167.0f, 55.8f)},
            {"Jolene Cranley-Evans' Ghost", new Vector3(3059.6f, 5564.2f, 197.0f)},
            {"NOOSE Headquarters", new Vector3(2535.2f, -383.7f, 92.9f)},
            {"Giant Snowman", new Vector3(971.2f, -1620.9f, 30.1f)},
            {"Underpass Skatepark", new Vector3(718.3f, -1218.7f, 26.0f)},
            {"University of San Andreas", new Vector3(-1696.8f, 142.7f, 64.3f)},
            {"Land Act Dam", new Vector3(1660.3f, -12.0f, 170.0f)},
            {"Sisyphus Theater Stage", new Vector3(205.3f, 1167.3f, 227.0f)},
            {"North Point", new Vector3(24.7f, 7644.1f, 19.0f)},
            {"Mount Gordo", new Vector3(2877.6f, 5911.0f, 369.6f)},
            {"Epsilon Building ", new Vector3(-695.0f, 82.9f, 55.8f)},
            {"The Richman Hotel", new Vector3(-1330.9f, 340.8f, 64.0f)},
            {"Vinewood Sign", new Vector3(711.3f, 1198.1f, 348.5f)},
            {"Vinewood Cemetery", new Vector3(-1659.9f, -128.3f, 59.9f)},
            {"Mirror Park", new Vector3(711.3f, 1198.1f, 348.5f)},
            {"Aircraft Carrier(USS Luxington)", new Vector3(3084.7f, -4770.7f, 15.2f)},
            {"Red Carpet", new Vector3(300.5927f, 199.7589f, 104.3776f)}
        };
        foreach (KeyValuePair<string, Vector3> location in teleportLandmarks)
        {

            //Displays dictionary of locations in menu
            UIMenuItem tpLandmarksLocation = new UIMenuItem(location.Key);

            //on select
            tpLandmarksLocation.Activated += (sender, args) =>
            TeleportFunctions.TeleportToLocation(location);
            tpLandmarks.AddItem(tpLandmarksLocation);

        }
        #endregion

        #region Interior
        Dictionary<string, Vector3> interiorLocations = new Dictionary<string, Vector3>()
        {
            {"Strip Club Dj Booth", new Vector3(126.1f, -1278.5f, 29.2f)},
            {"Blaine County Savings Bank", new Vector3(-109.2f, 6464.0f, 31.6f)},
            {"Mission Row Police Station", new Vector3(436.4f,-982.1f, 30.699f)},
            {"Humane Labs and Research Entrance", new Vector3(3607.195f, 3711.857f, 30.0f)},
            {"North Yankton Bank", new Vector3(5309.5f,-5212.3f, 83.5f)},
            {"Ammu-Nation Office", new Vector3(12.9f, -1110.1f, 29.7f)},
            {"Ammu-Nation Gun Range", new Vector3(22.1f, -1072.8f, 29.7f)},
            {"Trevor's Meth Lab", new Vector3(1391.7f, 3608.7f, 38.9f)},
            {"Pacific Standard Bank", new Vector3(235.0f, 216.4f, 106.2f)},
            {"Pacific Standard Bank Vault", new Vector3(255.8f, 217.0f, 101.6f)},
            {"Lester's House", new Vector3(1273.8f, -1719.3f, 54.7f)},
            {"Floyd's Apartment", new Vector3(-1150.7f, -1520.7f, 10.6f)},
            {"FIB Top Floor", new Vector3(135.7f, -749.2f, 258.1f)},
            {"FIB Floor 47", new Vector3(134.5f, -766.4f, 234.1f)},
            {"FIB Floor 49", new Vector3(134.6f, -765.8f, 242.1f)},
            {"FIB Building Burnt", new Vector3(159.553f, -738.851f, 246.152f)},
            {"FIB Building Lobby", new Vector3(110.4f, -744.2f, 45.7f)},
            {"IAA Office", new Vector3(117.2f, -620.9f, 206.0f)},
            {"Fort Zancudo ATC Entrance", new Vector3(-2344.3f, 3267.4f, 32.8f)},
            {"Fort Zancudo ATC Top Floor", new Vector3(-2358.1f, 3249.7f, 101.4f)},
            {"Damaged Hospital", new Vector3(302.651f, -586.293f, 43.3129f)},
            {"Raven Slaughterhouse", new Vector3(967.357f, -2184.71f, 30.0613f)},
            {"Los Santos County Coroner Office", new Vector3(243.3f, -1376.0f, 39.534f)},
            {"Torture Room", new Vector3(147.1f, -2201.8f, 4.6f)},
            {"O'neil Ranch", new Vector3(2441.2f, 4968.5f, 51.7f)},
            {"Trevor's Trailer", new Vector3(1976.0f, 3821.0f, 34.0f)},
            {"Solomon's Office", new Vector3(-1006.0f, -476.5f, 50.0f)},
            {"LifeInvader", new Vector3(-1047.9f,-233.0f, 39.0f)},
            {"Omega's Garage", new Vector3(2331.3f, 2574.0f, 46.6f)},
            {"Psychiatrist's Office", new Vector3(-1908.0f, -573.4f, 19.0f)},
            {"The Jewel Store", new Vector3(-623.8f,-233.2f, 38.0f)},
            {"Union Depository Vault", new Vector3(2.69f, -667.01f, 16.13f)},
            {"Bahama Mamas", new Vector3(-1388.0f, -618.4f, 30.8f)},
            {"Garment Factory", new Vector3(717.397f, -965.572f, 30.3955f)},
            {"Paleto Bay Sheriff", new Vector3(-446.135f, 6012.91f, 31.7164f)},
            {"Sandy Shores Sheriff", new Vector3(1853.18f, 3686.63f, 34.2671f)},
            {"Clucking Bell Farms Warehouse", new Vector3(-70.0624f, 6263.53f, 31.0909f)},
            {"Rogers Salvage & Scrap", new Vector3(-605.5f, -1623.2f, 33.8f)},
            {"La Fuente Blanca (Madrazo Cartel Ranch)", new Vector3(1398.673f, 1139.677f, 114.6105f)},
            {"Tequi-la-la", new Vector3(-557.58f, 286.77f, 81.56f)},
            {"Max Renda Shop", new Vector3(-583.1606f, -282.3967f, 35.394f)},
            {"Janitor's Apartment", new Vector3(-110.721f, -8.22095f, 70.5197f)},
            {"Stadium", new Vector3(-248.4916f, -2010.509f, 34.5743f)},
            {"Motel Room", new Vector3(152.2600f, -1004.4700f, -99.0000f)},
            {"Split Sides Comedy Club", new Vector3(377.0883f, -991.8690f, -98.6035f)},
            {"East Los Santos Foundry", new Vector3(1080.5678f, -1974.9805f, 31.4715f)},
            {"Premium Deluxe Motorsport", new Vector3(-57.6615f, -1097.595f, 26.4224f)},
            {"Epsilon Storage Room", new Vector3(243.3000f, 365.7000f, 105.7383f)},


        };
        foreach (KeyValuePair<string, Vector3> location in interiorLocations)
        {


            //Displays dictionary of locations in menu
            UIMenuItem tpInteriorLocations = new UIMenuItem(location.Key);

            //on select
            tpInteriorLocations.Activated += (sender, args) =>
            TeleportFunctions.TeleportToLocation(location);
            tpInteriors.AddItem(tpInteriorLocations);

        }
        #endregion

        #region Underwater
        Dictionary<string, Vector3> underwaterLocations = new Dictionary<string, Vector3>()
        {
            {"Humane Labs and Research Tunnel", new Vector3(3525.4f, 3705.3f, 20.9f)},
            {"Sunken Body", new Vector3(-3161.0f, 3001.9f, -37.9f)},
            {"Underwater WW2 Tank", new Vector3(4201.6f, 3643.8f, -39.0f)},
            {"Dead Sea Monster", new Vector3(-3373.7f, 504.7f, -24.6f)},
            {"Underwater UFO", new Vector3(762.426f, 7380.3f, -111.3f)},
            {"Underwater Hatch", new Vector3(4273.9f, 2975.7f, -170.7f)},
            {"Sunken Plane", new Vector3(-942.3f, 6608.7f, -20.9f)},
            {"Sunken Cargo Ship", new Vector3(3199.7f, -379.018f, -22.5f)}

        };
        foreach (KeyValuePair<string, Vector3> location in underwaterLocations)
        {
            //Displays dictionary of locations in menu
            UIMenuItem tpUnderwaterLocations = new UIMenuItem(location.Key);

            //on select
            tpUnderwaterLocations.Activated += (sender, args) =>
            TeleportFunctions.TeleportToLocation(location);
            tpUnderwater.AddItem(tpUnderwaterLocations);

        }
        #endregion

        #region High Locations
        Dictionary<string, Vector3> highLocations = new Dictionary<string, Vector3>()
        {
            {"Airplane Graveyard", new Vector3(2395.0f, 3049.6f, 60.0f)},
            {"Fort Zankudo UFO", new Vector3(-2051.9f, 3237.0f, 1456.9f)},
            {"IAA Roof", new Vector3(134.0f, -637.8f, 262.8f)},
            {"FIB Roof", new Vector3(150.1f, -754.5f, 262.8f)},
            {"Maze Bank Roof", new Vector3(-75.0f, -818.2f, 326.1f)},
            {"Rebel Radio", new Vector3(736.1f, 2583.1f, 79.6f)},
            {"Sandy Shores Building Site Crane", new Vector3(1051.209f, 2280.452f, 89.727f)},
            {"Satellite Dish Antenna", new Vector3(2034.988f, 2953.105f, 74.602f)},
            {"Stab City", new Vector3(126.975f, 3714.419f, 46.827f)},
            {"Very High Up", new Vector3(-129.964f, 8130.873f, 6705.307f)},
            {"Windmill Top", new Vector3(2026.677f, 1842.684f, 133.313f)},
            {"Palmer-Taylor Power Station Chimney", new Vector3 (2732.931f, 1577.540f, 83.671f)},

        };
        foreach (KeyValuePair<string, Vector3> location in highLocations)
        {
            //Displays dictionary of locations in menu
            UIMenuItem tpHighLocations = new UIMenuItem(location.Key);

            //on select
            tpHighLocations.Activated += (sender, args) =>
            TeleportFunctions.TeleportToLocation(location);
            tpHigh.AddItem(tpHighLocations);

        }
        #endregion
    }
}