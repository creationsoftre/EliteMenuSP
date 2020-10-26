using System;
using System.Collections.Generic;
using GTA;
using GTA.Native;
using NativeUI;

partial class MainMenu : Script
{
    public UIMenu vehicleMenu;
    public UIMenu vehicleSpawnerMenu;
    public UIMenu vehicleModMenu;


    private void EliteVehicleMenu()
    {
        //Creates Vehicle Menu
        vehicleMenu = modMenuPool.AddSubMenu(mainMenu, "Vehicle");

        //Vehicle Mod Menu
        vehicleModMenu = modMenuPool.AddSubMenu(vehicleMenu, "Vehicle Mod Menu");
        ElitevehicleModCategoryListMenu();

        //Vehical Spawner
        vehicleSpawnerMenu = modMenuPool.AddSubMenu(vehicleMenu, "Vehicle Spawner Menu");
        EliteVehicleSpawnerMenu();

        //Vehicle Weapons 
        UIMenuItem vehicleWeapons = new UIMenuItem("Select Vehicle Weapons");
        vehicleMenu.AddItem(vehicleWeapons);
        vehicleMenu.OnItemSelect += (sender, item, index) =>
        {
            if (item == vehicleWeapons)
            {
                VehicleFunctions.ToggleVehicleWeapons();
            }
        };

        //Vehicle Weapons 
        UIMenuItem warpInSpawnedCar = new UIMenuCheckboxItem("Warp In Spawned Car", false);
        vehicleMenu.AddItem(warpInSpawnedCar);
        vehicleMenu.OnCheckboxChange += (sender, item, checked_) =>
        {
            if (item == warpInSpawnedCar)
            {
                VehicleFunctions.ToggleWarpInSpawnedVehicle();
            }
        };

        //Fix Vehicle Checkbox
        UIMenuItem fixVehicle = new UIMenuItem("Fix Vehicle");
        vehicleMenu.AddItem(fixVehicle);
        vehicleMenu.OnItemSelect += (sender, item, index) =>
        {
            if (item == fixVehicle)
            {
                VehicleFunctions.FixVehicle();
            }
        };

        //Wash Vehicle Checkbox
        UIMenuItem washVehicle = new UIMenuItem("Wash Vehicle");
        vehicleMenu.AddItem(washVehicle);
        vehicleMenu.OnItemSelect += (sender, item, index) =>
        {
            if (item == washVehicle)
            {
                VehicleFunctions.WashVehicle();
            }
        };

        //Set Vehicle as Indestructible Checkbox
        UIMenuItem Indestructible = new UIMenuCheckboxItem("Indestructible", false);
        vehicleMenu.AddItem(Indestructible);
        vehicleMenu.OnCheckboxChange += (sender, item, checked_) =>
        {
            if (item == Indestructible)
            {
                VehicleFunctions.VehicleIndestructible();
            }
        };

        // toggle seatbelt Checkbox
        UIMenuItem toggleSeatBelt = new UIMenuCheckboxItem("Enable Seatbelt", false);
        vehicleMenu.AddItem(toggleSeatBelt);
        vehicleMenu.OnCheckboxChange += (sender, item, checked_) =>
        {
            if (item == toggleSeatBelt)
            {
                VehicleFunctions.ToggleSeatBelt();
            }
        };

        //Set Vehicle as Lock Doors Checkbox
        UIMenuItem toggleLockDoors = new UIMenuCheckboxItem("Lock Doors", false);
        vehicleMenu.AddItem(toggleLockDoors);
        vehicleMenu.OnCheckboxChange += (sender, item, checked_) =>
        {
            if (item == toggleLockDoors)
            {
                VehicleFunctions.ToggleLockDoors();
            }
        };

        //Never fall off motorcycle Checkbox
        UIMenuItem toggleNeverFallOffBike = new UIMenuCheckboxItem("Never Fall-Off Bike", false);
        vehicleMenu.AddItem(toggleNeverFallOffBike);
        vehicleMenu.OnCheckboxChange += (sender, item, checked_) =>
        {
            if (item == toggleNeverFallOffBike)
            {
                VehicleFunctions.ToggleNeverFallOffBike();
            }
        };

        //Toggle Speed Boost Checkbox
        UIMenuItem toggleSpeedBoost = new UIMenuCheckboxItem("Speed Boost", false);
        vehicleMenu.AddItem(toggleSpeedBoost);
        vehicleMenu.OnCheckboxChange += (sender, item, checked_) =>
        {
            if (item == toggleSpeedBoost)
            {
                VehicleFunctions.ToggleSpeedBoost();
            }
        };

        //Toggle Vehicle Jump Checkbox
        UIMenuItem toggleVehicleJump = new UIMenuCheckboxItem("Super Jump", false);
        vehicleMenu.AddItem(toggleVehicleJump);
        vehicleMenu.OnCheckboxChange += (sender, item, checked_) =>
        {
            if (item == toggleVehicleJump)
            {
                VehicleFunctions.ToggleVehicleJump();
            }
        };

        //Toggle Engine Always On
        UIMenuItem engineOn = new UIMenuCheckboxItem("Leave Engine Running", false);
        vehicleMenu.AddItem(engineOn);
        vehicleMenu.OnCheckboxChange += (sender, item, checked_) =>
        {
            if (item == engineOn)
            {
                VehicleFunctions.ToggleEngineAlwaysOn();
            }
        };

    }

    private void EliteVehicleSpawnerMenu()
    {
        UIMenu spawnByClassMenu = modMenuPool.AddSubMenu(vehicleSpawnerMenu, "Spawn Vehicle By Class");

        List<dynamic> vehicleMenuItems = new List<dynamic>();


        Dictionary<string, int> vehicleCategoriesDict = new Dictionary<string, int>()
        {
            {"Compacts", 0}, {"Sedans", 1}, {"SUVs", 2}, {"Coupes", 3}, {"Muscle", 4},
            {"Sports Classic", 5}, {"Sports", 6}, {"Super", 7}, {"Motorcycle", 8},
            {"Off-Road", 9}, {"Industrial", 10}, {"Utility", 11}, {"Vans/Pickups", 12},
            {"Bicycles", 13}, {"Boats", 14}, {"Helicopters", 15}, {"Airplanes", 16},
            {"Service", 17}, {"Emergency", 18}, {"Military", 19}, {"Commercial", 20},
            {"Trains/Containers", 21}
        };

        

        foreach (KeyValuePair<string, int> vehicleType in vehicleCategoriesDict)
        {
            //create new menu & display menu for each vehicle type 
            UIMenu vehicleCategories = modMenuPool.AddSubMenu(spawnByClassMenu, vehicleType.Key);

            VehicleHash[] allVehiclesHashes = (VehicleHash[])Enum.GetValues(typeof(VehicleHash));


            // Add vehicles to each category
            foreach (VehicleHash vehicle in allVehiclesHashes)
            {
                int vehicleClass = Function.Call<int>((Hash)0xDEDF1C8BD47C2200, (int)vehicle);
                string getDisplayModel = Function.Call<string>(Hash.GET_DISPLAY_NAME_FROM_VEHICLE_MODEL, (int)vehicle);
                string convertDisplayModelToName = Function.Call<string>(Hash._GET_LABEL_TEXT, getDisplayModel);

                
                if (vehicleClass == vehicleType.Value && convertDisplayModelToName != null)
                {
                    //list for all vehicles
                    UIMenuItem listOfVehicles = new UIMenuItem(convertDisplayModelToName);

                    // On click of spawn vehicle button, do...
                    listOfVehicles.Activated += (sender, args) => VehicleFunctions.SpawnVehicle(vehicle);
                    vehicleCategories.AddItem(listOfVehicles);

                }

            }

        }

    }
}
