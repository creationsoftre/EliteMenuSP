using System;
using System.Collections.Generic;
using System.Drawing;
using GTA;
using GTA.Native;
using NativeUI;
using NativeUI.PauseMenu;

partial class MainMenu : Script
{
    public UIMenu vehicleMenu;
    public UIMenu vehicleSpawnerMenu;
    public UIMenu vehicleModMenu;
    public UIMenu vehicleOptions;
    public UIMenu vehicleWindowOptions;
    public UIMenu vehicleDoorOptions;



    private void EliteVehicleMenu()
    {
        //Creates Vehicle Menu
        vehicleMenu = modMenuPool.AddSubMenu(mainMenu, "Vehicle");

        //Vehicle Mod Menu
        vehicleModMenu = modMenuPool.AddSubMenu(vehicleMenu, "Vehicle Mods");
        ElitevehicleModCategoryListMenu();


        //Vehical Spawner
        vehicleSpawnerMenu = modMenuPool.AddSubMenu(vehicleMenu, "Vehicle Spawner Menu");
        EliteVehicleSpawnerMenu();

        vehicleOptions = modMenuPool.AddSubMenu(vehicleMenu, "Vehicle Options");

        vehicleWindowOptions = modMenuPool.AddSubMenu(vehicleOptions, "Window Options");

        vehicleDoorOptions = modMenuPool.AddSubMenu(vehicleOptions, "Door Options");















        //Fix Vehicle Checkbox
        UIMenuItem fixVehicle = new UIMenuItem("Fix Vehicle");
        vehicleOptions.AddItem(fixVehicle);
        vehicleOptions.OnItemSelect += (sender, item, index) =>
        {
            if (item == fixVehicle)
            {
                VehicleFunctions.FixVehicle();
            }
        };

        //Wash Vehicle Checkbox
        UIMenuItem washVehicle = new UIMenuItem("Wash Vehicle");
        vehicleOptions.AddItem(washVehicle);
        vehicleOptions.OnItemSelect += (sender, item, index) =>
        {
            if (item == washVehicle)
            {
                VehicleFunctions.WashVehicle();
            }
        };

        //Flip Vehicle
        UIMenuItem flipVehicle = new UIMenuItem("Flip Vehicle");
        vehicleOptions.AddItem(flipVehicle);
        vehicleOptions.OnItemSelect += (sender, item, index) =>
        {
            if (item == flipVehicle)
            {
                VehicleFunctions.FlipVehicle();
            }
        };

        //Toggle Alarm
        UIMenuItem vehicleAlarm = new UIMenuItem("Vehicle Alarm");
        vehicleOptions.AddItem(vehicleAlarm);
        vehicleOptions.OnItemSelect += (sender, item, index) =>
        {
            if (item == vehicleAlarm)
            {
                VehicleFunctions.toggleVehicleAlarm();
            }
        };

        //Set Vehicle as Lock Doors 
        UIMenuItem toggleLockDoors = new UIMenuItem("Lock Doors");
        vehicleOptions.AddItem(toggleLockDoors);
        vehicleOptions.OnItemSelect += (sender, item, index) =>
        {
            if (item == toggleLockDoors)
            {
                VehicleFunctions.ToggleLockDoors();
            }
        };

        //Set Vehicle Child Lock
        UIMenuItem toggleChildLock = new UIMenuItem("Child Lock");
        vehicleOptions.AddItem(toggleChildLock);
        vehicleOptions.OnItemSelect += (sender, item, index) =>
        {
            if (item == toggleChildLock)
            {
                
                VehicleFunctions.ToggleChildLock();
            }
        };

        //Set Vehicle Peds Cannot Drag you out
        UIMenuItem toggleNoDrag = new UIMenuItem("Locked for Peds");
        vehicleOptions.AddItem(toggleNoDrag);
        vehicleOptions.OnItemSelect += (sender, item, index) =>
        {
            if (item == toggleNoDrag)
            {

                VehicleFunctions.ToggleNoGettingPulled();
            }
        };

        #region Window Options
        //Roll All Windows Up
        UIMenuItem toggleRollUpWindows = new UIMenuItem("Roll Up All Windows");
        vehicleWindowOptions.AddItem(toggleRollUpWindows);

        //Roll Down All windows
        UIMenuItem toggleRollDownWindows = new UIMenuItem("Roll Down All Windows");
        vehicleWindowOptions.AddItem(toggleRollDownWindows);
        vehicleWindowOptions.OnItemSelect += (sender, item, index) =>
        {
            if (item == toggleRollDownWindows)
            {

                VehicleFunctions.RollAllWindowDown();
            }
        };

        //Window Options
        Dictionary<int, string> windowIndex = new Dictionary<int, string>()
        {
            {0, "Front Driver Window" },
            {1, "Front Passenger Window" },
            {2, "Rear Driver Window" },
            {3, "Rear Passenger Window"},
        };

        foreach (KeyValuePair<int,string> window in windowIndex)
        {
            UIMenu windowPos = modMenuPool.AddSubMenu(vehicleWindowOptions, window.Value);
            UIMenuItem rollDownWindow = new UIMenuItem("Roll Down Window");
            windowPos.AddItem(rollDownWindow);
            UIMenuItem rollUpWindow = new UIMenuItem("Roll Up Window");
            windowPos.AddItem(rollUpWindow);
            UIMenuItem fixWindow = new UIMenuItem("Fix Window");
            windowPos.AddItem(fixWindow);

            windowPos.OnItemSelect += (sender, item, index) =>
            {
                if (item == rollDownWindow)
                {
                    VehicleFunctions.RollWindowDown(window);
                }

                if(item == rollUpWindow)
                {
                    VehicleFunctions.RollWindowUp(window);
                }

                if (item == fixWindow)
                {
                    VehicleFunctions.FixWindow(window);
                }
            };

            vehicleWindowOptions.OnItemSelect += (sender, item, index) =>
            {
                if(item == toggleRollUpWindows)
                {
                    for(int i = 0; i <= 4; i++)
                    {
                        VehicleFunctions.RollWindowUp(window);
                    }
                }
            };
        }

        #endregion

        #region Vehicle Doors
        Dictionary<int, string> doorIndex = new Dictionary<int, string>()
        {
            {0, "Front Driver Door" },
            {1, "Front Passenger Door" },
            {2, "Rear Driver Door" },
            {3, "Rear Passenger Door"},
            {4, "Hood"},
            {5, "Trunk"},
            {6, "Extra1"},
            {7, "Extra2"},
        };

        UIMenuItem openAllDoors = new UIMenuItem("Open All Doors", "Open all vehicle doors.");
        vehicleDoorOptions.AddItem(openAllDoors);

        UIMenuItem closeAllDoors = new UIMenuItem("Close All Doors", "Close all vehicle doors.");
        vehicleDoorOptions.AddItem(closeAllDoors);

        foreach (KeyValuePair<int, string> door in doorIndex)
        {
            UIMenu doorPos = modMenuPool.AddSubMenu(vehicleDoorOptions, door.Value, "Open/Close Specified Door");
            UIMenuItem openDoor = new UIMenuItem("Open Door", "Open Specified Door");
            doorPos.AddItem(openDoor);
            UIMenuItem closeDoor = new UIMenuItem("Close Door", "Close Specified Door");
            doorPos.AddItem(closeDoor);
            

            doorPos.OnItemSelect += (sender, item, index) =>
            {

                if (item == openDoor)
                {
                    VehicleFunctions.VehOpenDoor(door);
                }

                if (item == closeDoor)
                {
                    VehicleFunctions.VehCloseDoor(door);
                }
            };

            vehicleDoorOptions.OnItemSelect += (sender, item, index) =>
            {
                if (item == closeAllDoors)
                {
                    VehicleFunctions.CloseAllDoors();
                }

                if (item == openAllDoors)
                {
                    for (int i = 0; i <= 8; i++)
                    {
                        Function.Call(Hash.SET_VEHICLE_DOOR_OPEN, veh.Handle, door.Key, false, false);
                    }
                }

            };
        }

        UIMenuItem bombBayDoors = new UIMenuItem("Bomb Bay", "Open/close the bomb bay. Only available on some planes.");
        vehicleDoorOptions.AddItem(bombBayDoors);
        vehicleDoorOptions.OnItemSelect += (sender, item, index) =>
        {
            if (item == bombBayDoors && veh.HasBombBay)
            {
                VehicleFunctions.GetBombBayDoorStatus(veh);
;
            }
        };

        #endregion

        #region Vehicle Lights
            List<dynamic> lightTypes = new List<dynamic>()
        {
            "Hazard Lights",
            "Left Indicator",
            "Right Indicator",
            "Interior Lights",
            "Taxi Light", 
            "Helicopter Spotlight",
        };

        
        //Light Type Dynamic List
        UIMenuListItem vehLightType = new UIMenuListItem("Vehicle Lights", lightTypes, 0, "Turn vehicle lights on/off.");
        vehicleOptions.OnItemSelect += (sender, item, index) =>
        {
            if (item == vehLightType)
            {
                if (Game.Player.Character.IsInVehicle() && veh.Exists())
                {
                    Vehicle veh = CommonFunctions.GetVehicle();
                    int state = (int)VehicleFunctions.GetVehicleIndicatorLights(veh);
                    int listIndex = vehLightType.Index;
                    
                    if (listIndex == 0)
                    {
                        if (state != 3) // either all lights are off, or one of the two (left/right) is off.
                        {
                            VehicleFunctions.LeftIndicatorLightOn_set(true); // left on
                            VehicleFunctions.RightIndicatorLightOn_set(true); // right on
                            
                        }
                        else  // both are on.
                        {
                            VehicleFunctions.LeftIndicatorLightOn_set(false); // left off
                            VehicleFunctions.RightIndicatorLightOn_set(false); // right off
                            
                        }
                    }
                    else if (listIndex == 1)
                    {
                        if (state != 1) // Left indicator is (only) off
                        {
                            VehicleFunctions.LeftIndicatorLightOn_set(true); // left on
                            VehicleFunctions.RightIndicatorLightOn_set(false); // right on
                            
                        }
                        else
                        {
                            VehicleFunctions.LeftIndicatorLightOn_set(false); // left off
                            VehicleFunctions.RightIndicatorLightOn_set(false); // right off
                            
                        }
                    }
                    else if (listIndex == 2)
                    {
                        if (state != 2) // Left indicator is (only) off
                        {
                            VehicleFunctions.LeftIndicatorLightOn_set(false); // left on
                            VehicleFunctions.RightIndicatorLightOn_set(true); // right on
                            
                        }
                        else
                        {
                            VehicleFunctions.LeftIndicatorLightOn_set(false); // left off
                            VehicleFunctions.RightIndicatorLightOn_set(false); // right off
                            
                        }
                    }
                    else if (listIndex == 3) //Interior Light
                    {
                        VehicleFunctions.SetInteriorLights(veh);
                    }
                    else if (listIndex == 4) //Native Does not work
                    {
                        bool isTaxiLightOn = Function.Call<bool>(Hash.IS_TAXI_LIGHT_ON, veh);
                        bool playerInTaxi = Function.Call<bool>(Hash.IS_PED_IN_ANY_TAXI, Game.Player.Character);

                        if (playerInTaxi)
                        {
                            if (!isTaxiLightOn)
                            {
                                Function.Call(Hash.SET_TAXI_LIGHTS, veh, 1);
                                DisplayMessage("Taxi ON" + " " + isTaxiLightOn);
                            }
                            else
                            {
                                Function.Call(Hash.SET_TAXI_LIGHTS, veh, 0);
                                DisplayMessage("Taxi Off" + " " + !isTaxiLightOn);
                            }
                        }
                    }
                    else if (listIndex == 5) // helicopter spotlight
                    {
                        bool isSearchLightOn = Function.Call<bool>(Hash.IS_VEHICLE_SEARCHLIGHT_ON, veh);
                        bool isPlayerInHeli = Game.Player.Character.IsInHeli;

                        if (!isSearchLightOn && isPlayerInHeli == true)
                        {
                            Function.Call(Hash.SET_VEHICLE_SEARCHLIGHT, veh, !isSearchLightOn, true);
                            DisplayMessage("Helicopter On");
                        }
                        else
                        {
                            Function.Call(Hash.SET_VEHICLE_SEARCHLIGHT, veh, !isSearchLightOn, false);
                            DisplayMessage("Helicopter Off");
                        }

                    }
                }
            }
        };
        #endregion

        #region Set Dirt Level
        List<dynamic> listOfDirtLevels  = new List<dynamic>{"No Dirt", 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

        Vehicle currentPedVehicle = Function.Call<Vehicle>(Hash.GET_VEHICLE_PED_IS_IN, Game.Player.Character, false);

        int getDirtLevel = Function.Call<int>(Hash.GET_VEHICLE_DIRT_LEVEL, currentPedVehicle);
        
        UIMenuListItem dirtLevelyList = new UIMenuListItem("Dirt Level", listOfDirtLevels, getDirtLevel, "Select how much dirt should be visible on your vehicle, press ~r~enter~s~ " +"to apply the selected level.");
        vehicleOptions.AddItem(dirtLevelyList);

        vehicleOptions.OnListChange += (sender, listItem, index) =>
        {
            if (listItem == dirtLevelyList)
            {
                float listIndex = dirtLevelyList.Index;
                Function.Call(Hash.SET_VEHICLE_DIRT_LEVEL, currentPedVehicle, listIndex);
            }
        };
        #endregion

        //Warp in Vehicle
        UIMenuItem warpInSpawnedCar = new UIMenuCheckboxItem("Warp In Spawned Car", false);
        vehicleOptions.AddItem(warpInSpawnedCar);
        vehicleOptions.OnCheckboxChange += (sender, item, checked_) =>
        {
            if (item == warpInSpawnedCar)
            {
                VehicleFunctions.ToggleWarpInSpawnedVehicle();
            }
        };

        //Set Vehicle as Indestructible Checkbox
        UIMenuItem Indestructible = new UIMenuCheckboxItem("Indestructible", false);
        vehicleOptions.AddItem(Indestructible);
        vehicleOptions.OnCheckboxChange += (sender, item, checked_) =>
        {
            if (item == Indestructible)
            {
                VehicleFunctions.VehicleIndestructible();
            }
        };

        // toggle seatbelt Checkbox
        UIMenuItem toggleSeatBelt = new UIMenuCheckboxItem("Enable Seatbelt", false);
        vehicleOptions.AddItem(toggleSeatBelt);
        vehicleOptions.OnCheckboxChange += (sender, item, checked_) =>
        {
            if (item == toggleSeatBelt)
            {
                VehicleFunctions.ToggleSeatBelt();
            }
        };

        //Never fall off motorcycle Checkbox
        UIMenuItem toggleNeverFallOffBike = new UIMenuCheckboxItem("Never Fall-Off Bike", false);
        vehicleOptions.AddItem(toggleNeverFallOffBike);
        vehicleOptions.OnCheckboxChange += (sender, item, checked_) =>
        {
            if (item == toggleNeverFallOffBike)
            {
                VehicleFunctions.ToggleNeverFallOffBike();
            }
        };

        //Toggle Speed Boost Checkbox
        UIMenuItem toggleSpeedBoost = new UIMenuCheckboxItem("Speed Boost", false);
        vehicleOptions.AddItem(toggleSpeedBoost);
        vehicleOptions.OnCheckboxChange += (sender, item, checked_) =>
        {
            if (item == toggleSpeedBoost)
            {
                VehicleFunctions.ToggleSpeedBoost();
            }
        };

        //Toggle Vehicle Jump Checkbox
        UIMenuItem toggleVehicleJump = new UIMenuCheckboxItem("Super Jump", false);
        vehicleOptions.AddItem(toggleVehicleJump);
        vehicleOptions.OnCheckboxChange += (sender, item, checked_) =>
        {
            if (item == toggleVehicleJump)
            {
                VehicleFunctions.ToggleVehicleJump();
            }
        };

        //Toggle Vehicle Invisible
        UIMenuItem toggleVehicleInvisible = new UIMenuCheckboxItem("Invisible", false);
        vehicleOptions.AddItem(toggleVehicleInvisible);
        vehicleOptions.OnCheckboxChange += (sender, item, checked_) =>
        {
            if (item == toggleVehicleInvisible)
            {
                VehicleFunctions.ToggleVehicleInvisible();
            }
        };

        //Toggle Engine Always On
        UIMenuItem engineOn = new UIMenuCheckboxItem("Leave Engine Running", false);
        vehicleOptions.AddItem(engineOn);
        vehicleOptions.OnCheckboxChange += (sender, item, checked_) =>
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

                
                if (convertDisplayModelToName != null && vehicleClass == vehicleType.Value )
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
