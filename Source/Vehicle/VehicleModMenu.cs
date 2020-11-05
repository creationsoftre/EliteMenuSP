using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using EliteMenu.Data;
using GTA;
using GTA.Native;
using GTA.NaturalMotion;
using NativeUI;


partial class MainMenu
{
    public Ped Player = Game.Player.Character;
    Vehicle veh = CommonFunctions.GetVehicle();

    private void ElitevehicleModCategoryListMenu()
    {
        #region

        UIMenu vehMods = modMenuPool.AddSubMenu(vehicleModMenu, "Mods");

        vehMods.OnMenuOpen += (sender) =>
        {

            if (veh.Exists() && veh != null && !veh.IsDead)
            {
                Function.Call(Hash.SET_VEHICLE_MOD_KIT, veh, 0);


                foreach (VehicleMod modType in Enum.GetValues(typeof(VehicleMod)))
                {
                    List<dynamic> modList = new List<dynamic>();

                    int vehModCount = Function.Call<int>(Hash.GET_NUM_VEHICLE_MODS, veh, (int)modType);

                    // Get the current item index ({current}/{max upgrades})
                    var currentItem = $"[1/{ vehModCount + 1}]";

                    var modName = $"Stock {modType} {currentItem}";
                    modList.Add(modName);

                    if (vehModCount > 0)
                    {
                        if(modType != VehicleMod.BackWheels && modType != VehicleMod.FrontWheels)
                        {

                            for (int x = 0; x < vehModCount; x++)
                            {
                                string modLabel = Function.Call<string>(Hash.GET_MOD_TEXT_LABEL, veh, (int)modType, x);
                                string convertModLabelText = CommonFunctions.GetLabelText(modLabel);

                                currentItem = $"[{2 + x}/{ vehModCount + 1}]";
                                modName = Function.Call<string>(Hash.GET_MOD_TEXT_LABEL, veh, (int)modType, x) != "" ? $"{convertModLabelText} {currentItem}" : $"{modType} #{x} {currentItem}";
                                modList.Add(modName);
                            }

                            int currIndex = Function.Call<int>(Hash.GET_VEHICLE_MOD, veh.Handle, (int)modType) + 1;
                            UIMenuListItem modTypeListItem = new UIMenuListItem(modType.ToString(), modList, currIndex);
                            vehMods.AddItem(modTypeListItem);

                            vehMods.OnListChange += (senderMenu, item, index) =>
                            {
                                if(index < senderMenu.Size - 9)
                                {
                                    if(item == modTypeListItem)
                                    {
                                        int listIndex = modTypeListItem.Index;
                                        bool customWheels = Function.Call<bool>(Hash.GET_VEHICLE_MOD_VARIATION, veh, 23);
                                        Function.Call(Hash.SET_VEHICLE_MOD, veh, (int)modType, listIndex, customWheels);
                                    }
                                                                     
                                    
                                }
                            };

                        }
                    }
                }

            }
          
        };
        #endregion

        #region Livery
        UIMenu vehLiveryMods = modMenuPool.AddSubMenu(vehicleModMenu, "Livery");

        vehLiveryMods.OnMenuOpen += (sender) =>
        {
            if (veh.Exists() && veh != null && !veh.IsDead)
            {
                if (veh.Driver == Player)
                {
                    vehLiveryMods.Clear();
                    Function.Call(Hash.SET_VEHICLE_MOD_KIT, veh, 0);
                    int liveryCount = Function.Call<int>(Hash.GET_NUM_VEHICLE_MODS, veh, 48);

                    DisplayMessage(liveryCount.ToString());

                    if (liveryCount > 0)
                    {
                        var liveryList = new List<dynamic>();

                        for (int i = 0; i < liveryCount; i++)
                        {
                            string label = CommonFunctions.GetModLabelText(veh, 48, i);
                            string convertToDisplayName = CommonFunctions.GetLabelText(label);
                            DisplayMessage(convertToDisplayName);

                            if (label != "NULL")
                            {
                                liveryList.Add(convertToDisplayName);
                            }

                        }

                        UIMenuListItem liveryListItem = new UIMenuListItem("Set Livery", liveryList, 0, "Choose a livery for this vehicle.");
                        vehLiveryMods.AddItem(liveryListItem);
                        liveryListItem.Activated += (senderMenu, args) =>
                        {
                            int listIndex = liveryListItem.Index;
                            Function.Call(Hash.SET_VEHICLE_MOD, veh, 48, listIndex, false);
                            

                        };

                        vehLiveryMods.RefreshIndex();
                    }
                }
                else
                {
                    DisplayMessage("You have to be the driver of a vehicle to access this menu.");
                }
            }
            else
            {
                DisplayMessage("You have to be the driver of a vehicle to access this menu.");
            }
        };
        #endregion

        #region Toggle Mods
        UIMenuItem Turbo = new UIMenuCheckboxItem("Turbo", false);
        vehicleModMenu.AddItem(Turbo);
        vehicleModMenu.OnCheckboxChange += (sender, item, checked_) =>
        {

            if (item == Turbo)
            {
                if (checked_)
                {
                    if (veh.Exists() && veh != null)
                    {
                        veh.ToggleMod(VehicleToggleMod.Turbo, true);
                        MainMenu.DisplayMessage("Turbo Enabled");
                    }

                }
                else
                {
                    if (veh.Exists() && veh != null)
                    {
                        veh.ToggleMod(VehicleToggleMod.Turbo, false);
                        MainMenu.DisplayMessage("Turbo Disabled");
                    }

                }

            }

        };

        UIMenuItem xeonHeadLights = new UIMenuCheckboxItem("Xeon Head Lights", false);
        vehicleModMenu.AddItem(xeonHeadLights);
        vehicleModMenu.OnCheckboxChange += (sender, item, checked_) =>
        {
            if (item == xeonHeadLights)
            {
                if (checked_)
                {
                    if (veh.Exists() && veh != null)
                    {
                        veh.ToggleMod(VehicleToggleMod.XenonHeadlights, true);
                        MainMenu.DisplayMessage("Xenon Headlights Enabled");
                    }

                }
                else
                {
                    if (veh.Exists() && veh != null)
                    {
                        veh.ToggleMod(VehicleToggleMod.XenonHeadlights, false);
                        MainMenu.DisplayMessage("Xenon Headlights Disabled");
                    }
                }

            }
        };

        UIMenuItem tireSmoke = new UIMenuCheckboxItem("Tire Smoke", false);
        vehicleModMenu.AddItem(tireSmoke);
        vehicleModMenu.OnCheckboxChange += (sender, item, checked_) =>
        {

            if (item == tireSmoke)
            {
                if (checked_)
                {
                    if (veh.Exists() && veh != null)
                    {
                        veh.ToggleMod(VehicleToggleMod.TireSmoke, true);
                        MainMenu.DisplayMessage("Tire Smoke Enabled");
                    }

                }
                else
                {
                    if (veh.Exists() && veh != null)
                    {
                        veh.ToggleMod(VehicleToggleMod.TireSmoke, false);
                        MainMenu.DisplayMessage("Tire Smoke Disabled");
                    }
                }

            }
        };
        #endregion

        #region Respray
        //Vehicle Color Menu
        UIMenu vehicleColorMenu;
        vehicleColorMenu = modMenuPool.AddSubMenu(vehicleModMenu, "Vehicle Color");
        //Primary Menu
        UIMenu primaryColorsMenu;
        primaryColorsMenu = modMenuPool.AddSubMenu(vehicleColorMenu, "Primary Color");

        //Secondary Menu
        UIMenu secondaryColorsMenu;
        secondaryColorsMenu = modMenuPool.AddSubMenu(vehicleColorMenu, "secondary Color");

        // color lists
        List<dynamic> Classic = new List<dynamic>();
        List<dynamic> Matte = new List<dynamic>();
        List<dynamic> Metals = new List<dynamic>();
        List<dynamic> Util = new List<dynamic>();
        List<dynamic> Worn = new List<dynamic>();
        List<dynamic> WheelColors = new List<dynamic>() { "Default Alloy" };

        {
            int i = 0;
            foreach (var vehColor in VehicleData.ClassicColors)
            {
                string vehColorName = Function.Call<string>(Hash._GET_LABEL_TEXT, vehColor.label);
                Classic.Add(vehColorName);
                i++;
            }

            i = 0;
            foreach (var vehColor in VehicleData.MatteColors)
            {
                string vehColorName = Function.Call<string>(Hash._GET_LABEL_TEXT, vehColor.label);
                Matte.Add(vehColorName);
                i++;
            }

            i = 0;
            foreach (var vehColor in VehicleData.MetalColors)
            {
                string vehColorName = Function.Call<string>(Hash._GET_LABEL_TEXT, vehColor.label);
                Metals.Add(vehColorName);
                i++;
            }

            i = 0;
            foreach (var vehColor in VehicleData.UtilColors)
            {
                string vehColorName = Function.Call<string>(Hash._GET_LABEL_TEXT, vehColor.label);
                Util.Add(vehColorName);
                i++;
            }

            i = 0;
            foreach (var vehColor in VehicleData.WornColors)
            {
                string vehColorName = Function.Call<string>(Hash._GET_LABEL_TEXT, vehColor.label);
                Worn.Add(vehColorName);
                i++;
            }


            WheelColors.AddRange(Classic);
        }



        UIMenuListItem wheelColorList = new UIMenuListItem("Wheel Color", WheelColors, 0);
        UIMenuSliderItem vehicleEnveffScale = new UIMenuSliderItem("Vehicle Enveff Scale");

        UIMenuItem chrome = new UIMenuItem("Chrome");
        vehicleColorMenu.AddItem(chrome);


        vehicleColorMenu.OnItemSelect += (sender, item, index) =>
        {
            Vehicle veh = Game.Player.LastVehicle;
            Ped Player = Game.Player.Character;
            if (veh != null && veh.Exists() && !veh.IsDead && veh.Driver == Player)
            {
                if (item == chrome)
                {
                    Function.Call(Hash.SET_VEHICLE_COLOURS, veh.Handle, 120, 120); // chrome is index 120
                }
            }
            else
            {
                DisplayMessage("You need to be the driver of a driveable vehicle to change this.");
            }
        };

        vehicleColorMenu.OnSliderChange += (sender, listItem, itemIndex) =>
        {
            Vehicle veh = Game.Player.LastVehicle;
            Ped Player = Game.Player.Character;

            if (veh != null && veh.Driver == Player && !veh.IsDead)
            {
                if (listItem == vehicleEnveffScale)
                {
                    //SetVehicleEnveffScale(veh.Handle, itemIndex / 20f);
                }
            }
            else
            {
                DisplayMessage("You need to be the driver of a driveable vehicle to change this slider.");
            }
        };

        //Create Color Menus
        for (int i = 0; i < 2; i++)
        {
            UIMenuListItem pearlescentList = new UIMenuListItem("Pearlescent", Classic, 0);
            UIMenuListItem metalicColorList = new UIMenuListItem("Metallic", Classic, 0);
            UIMenuListItem classicList = new UIMenuListItem("Classic", Classic, 0);
            UIMenuListItem matteList = new UIMenuListItem("Matte", Matte, 0);
            UIMenuListItem metalList = new UIMenuListItem("Metal", Metals, 0);
            UIMenuListItem utilList = new UIMenuListItem("Util", Util, 0);
            UIMenuListItem wornList = new UIMenuListItem("Worn", Worn, 0);



            if (i == 0)
            {

                primaryColorsMenu.AddItem(classicList);
                primaryColorsMenu.AddItem(matteList);
                primaryColorsMenu.AddItem(metalList);
                primaryColorsMenu.AddItem(utilList);
                primaryColorsMenu.AddItem(wornList);

                primaryColorsMenu.OnListChange += HandleListIndexChanges;
            }
            else
            {
                secondaryColorsMenu.AddItem(pearlescentList);
                secondaryColorsMenu.AddItem(classicList);
                secondaryColorsMenu.AddItem(metalicColorList);
                secondaryColorsMenu.AddItem(matteList);
                secondaryColorsMenu.AddItem(metalList);
                secondaryColorsMenu.AddItem(utilList);
                secondaryColorsMenu.AddItem(wornList);

                secondaryColorsMenu.OnListChange += HandleListIndexChanges;
            }

        }

        vehicleColorMenu.OnListChange += HandleListIndexChanges;

        void HandleListIndexChanges(UIMenu sender, UIMenuListItem listItem, int newIndex)
        {
            Vehicle veh = Game.Player.LastVehicle;
            Ped Player = Game.Player.Character;
            if (veh != null && veh.Exists() && !veh.IsDead && veh.Driver == Player)
            {
                int primaryColor = 0;
                int secondaryColor = 0;
                int pearlColor = 0;
                int wheelColor = 0;
                int dashColor = 0;
                int intColor = 0;

                unsafe
                {
                    Function.Call(Hash.GET_VEHICLE_COLOURS, veh.Handle, &primaryColor, &secondaryColor);
                    Function.Call(Hash.GET_VEHICLE_EXTRA_COLOURS, veh.Handle, &pearlColor, &wheelColor);
                }


                if (sender == primaryColorsMenu)
                {

                    /*if (listItem.Parent.Title.Equals("Metallic"))
                        pearlColor = VehicleData.ClassicColors[newIndex].id;
                    else
                        pearlColor = 0;*/

                    switch (listItem.Parent.CurrentSelection)
                    {
                        case 0:
                            primaryColor = VehicleData.ClassicColors[newIndex].id;
                            break;
                        case 1:
                            primaryColor = VehicleData.MatteColors[newIndex].id;
                            break;
                        case 2:
                            primaryColor = VehicleData.MetalColors[newIndex].id;
                            break;
                        case 3:
                            primaryColor = VehicleData.UtilColors[newIndex].id;
                            break;
                        case 4:
                            primaryColor = VehicleData.WornColors[newIndex].id;
                            break;
                        default:
                            break;
                    }

                    Function.Call(Hash.SET_VEHICLE_COLOURS, veh.Handle, primaryColor, secondaryColor);
                }
                else if (sender == secondaryColorsMenu)
                {
                    switch (listItem.Parent.CurrentSelection)
                    {
                        case 0:
                            pearlColor = VehicleData.ClassicColors[newIndex].id;
                            DisplayMessage("Color " + newIndex + " " + primaryColor + listItem.Index);
                            break;
                        case 1:
                        case 2:
                            primaryColor = VehicleData.ClassicColors[newIndex].id;
                            break;

                        case 3:
                            secondaryColor = VehicleData.MatteColors[newIndex].id;
                            break;
                        case 4:
                            secondaryColor = VehicleData.MetalColors[newIndex].id;
                            break;
                        case 5:
                            secondaryColor = VehicleData.UtilColors[newIndex].id;
                            break;
                        case 6:
                            secondaryColor = VehicleData.WornColors[newIndex].id;
                            break;
                    }

                    Function.Call(Hash.SET_VEHICLE_COLOURS, veh.Handle, primaryColor, secondaryColor);
                }
                else if (sender == vehicleColorMenu)
                {
                    if (listItem == wheelColorList)
                    {
                        if (newIndex == 0)
                        {
                            wheelColor = 156; //defaul alloy color
                        }
                        else
                        {
                            wheelColor = VehicleData.ClassicColors[newIndex - 1].id;
                        }
                    }
                }

                Function.Call(Hash.SET_VEHICLE_EXTRA_COLOURS, veh.Handle, pearlColor, wheelColor);
            }
        }
        #endregion

        #region License Plate Styles

        var licensePlates = new List<dynamic>
        { CommonFunctions.GetLabelText("CMOD_PLA_0"),
          CommonFunctions.GetLabelText("CMOD_PLA_1"),
          CommonFunctions.GetLabelText("CMOD_PLA_2"),
          CommonFunctions.GetLabelText("CMOD_PLA_3"),
          CommonFunctions.GetLabelText("CMOD_PLA_4"),
          "North Yankton"
        };
        UIMenuListItem setLicensePlateType = new UIMenuListItem("License Plate Type", licensePlates, 0, "Choose a license plate type and press ~r~enter ~s~to apply " +
            "it to your vehicle.");
        vehicleModMenu.AddItem(setLicensePlateType);
        vehicleModMenu.OnListChange += (sender, item, index) =>
        {
            if (item == setLicensePlateType)
            {
                // Set the license plate style.
                switch (index)
                {
                    case 0:
                        VehicleFunctions.SetPlateStyle(index);
                        break;
                    case 1:
                        VehicleFunctions.SetPlateStyle(index);
                        break;
                    case 2:
                        VehicleFunctions.SetPlateStyle(index);
                        break;
                    case 3:
                        VehicleFunctions.SetPlateStyle(index);
                        break;
                    case 4:
                        VehicleFunctions.SetPlateStyle(index);
                        break;
                    case 5:
                        VehicleFunctions.SetPlateStyle(index);
                        break;
                    default:
                        break;
                }
            }
        };

        #endregion

    }


    #region GetColorFromIndex function (underglow)

    private readonly List<int[]> _VehicleNeonLightColors = new List<int[]>()
        {
            { new int[3] { 255, 255, 255 } },   // White
            { new int[3] { 2, 21, 255 } },      // Blue
            { new int[3] { 3, 83, 255 } },      // Electric blue
            { new int[3] { 0, 255, 140 } },     // Mint Green
            { new int[3] { 94, 255, 1 } },      // Lime Green
            { new int[3] { 255, 255, 0 } },     // Yellow
            { new int[3] { 255, 150, 5 } },     // Golden Shower
            { new int[3] { 255, 62, 0 } },      // Orange
            { new int[3] { 255, 0, 0 } },       // Red
            { new int[3] { 255, 50, 100 } },    // Pony Pink
            { new int[3] { 255, 5, 190 } },     // Hot Pink
            { new int[3] { 35, 1, 255 } },      // Purple
            { new int[3] { 15, 3, 255 } },      // Blacklight
        };

    private System.Drawing.Color GetColorFromIndex(int index)
    {
        if (index >= 0 && index < 13)
        {
            return System.Drawing.Color.FromArgb(_VehicleNeonLightColors[index][0], _VehicleNeonLightColors[index][1], _VehicleNeonLightColors[index][2]);
        }
        return System.Drawing.Color.FromArgb(255, 255, 255);
    }

    private int GetIndexFromColor()
    {
        Vehicle veh = Game.Player.LastVehicle; ;

        if (veh == null || !veh.Exists())
        {
            return 0;
        }

        int r = 255, g = 255, b = 255;


        //Function.Call<int>(Hash._GET_VEHICLE_NEON_LIGHTS_COLOUR, veh.Handle, &r, &g, &b);



        if (r == 255 && g == 0 && b == 255) // default return value when the vehicle has no neon kit selected.
        {
            return 0;
        }

        if (_VehicleNeonLightColors.Any(a => { return a[0] == r && a[1] == g && a[2] == b; }))
        {
            return _VehicleNeonLightColors.FindIndex(a => { return a[0] == r && a[1] == g && a[2] == b; });
        }

        return 0;
    }
    #endregion

    #region Update Vehicle Mods Menu
    /// <summary>
    /// Refreshes the mods page. The selectedIndex allows you to go straight to a specific index after refreshing the menu.
    /// This is used because when the wheel type is changed, the menu is refreshed to update the available wheels list.
    /// </summary>
    /// <param name="selectedIndex">Pass this if you want to go straight to a specific mod/index.</param>
    public void UpdateMods(int selectedIndex = 0)
    {
        // If there are items, remove all of them.
        if (vehicleModMenu.Size > 0)
        {
            if (selectedIndex != 0)
            {
                vehicleModMenu.MenuItems.Clear();
            }
            else
            {
                
            }

        }
    }
    #endregion
}