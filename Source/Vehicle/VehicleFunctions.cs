using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GTA;
using GTA.Native;


class VehicleFunctions : Script
{

    public static bool IsVehicleIndestructible { get; set; }
    public static bool IsSeatBeltEnabled { get; set; }
    public const int PedFlagCanFlyThroughWindscreen = 32;
    public static bool CanFlyThroughWindscreen { get { return Function.Call<bool>(Hash.GET_PED_CONFIG_FLAG, Game.Player.Character, PedFlagCanFlyThroughWindscreen); } }
    public static bool IsLockedDoorsEnabled { get; set; }
    public static bool IsSpeedBoostEnabled { get; set; }
    public static bool IsNeverFallOffBikeEnabled { get; set; }
    public static bool CanVehiclesJump { get; set; }
    public static bool IsVehicleWeaponsEnabled { get; set; }
    public static int VehicleWeaponAssetIndex { get; set; }
    public static bool IsWarpInSpawnedVehicleEnabled { get; set; }
    public static bool IsVehicleAlwaysOnGroundEnabled { get; set; }
    public static bool IsEngineAlwaysEnabled { get; set; }
    public static bool LeftIndicatorLightOn { get;  set; }
    public static bool RightIndicatorLightOn { get; set; }
    public static bool IsInteriorLightOn { get; set; }
    public static bool IsSearchLightOn { get; set; }
    public static bool IsBombBayOpen { get; set; }

    public static Vehicle veh = CommonFunctions.GetVehicle();
    public static Ped Player = Game.Player.Character;



    public VehicleFunctions()
    {
        Tick += OnTick;

        // Onload.
        SetVehicleIndestructible(false);
        Function.Call(Hash.SET_PED_CONFIG_FLAG, Game.Player.Character, PedFlagCanFlyThroughWindscreen, true);
        Game.Player.Character.CanBeDraggedOutOfVehicle = true;
        Function.Call(Hash.SET_PED_CAN_BE_KNOCKED_OFF_VEHICLE, Game.Player.Character, 0);
    }

    private void OnTick(object sender, EventArgs e)
    {

        if (IsVehicleIndestructible)
        {
            SetVehicleIndestructible(true);
        }

        if (IsSeatBeltEnabled)
        {
            if (CanFlyThroughWindscreen)
            {
                Function.Call(Hash.SET_PED_CONFIG_FLAG, Game.Player.Character, PedFlagCanFlyThroughWindscreen, false);
            }
        }

        if (IsNeverFallOffBikeEnabled)
        {
            Function.Call(Hash.SET_PED_CAN_BE_KNOCKED_OFF_VEHICLE, Game.Player.Character, 1);
        }

        if (IsSpeedBoostEnabled)
        {
            if (Game.IsKeyPressed(Keys.NumPad9))
            {
                Game.Player.Character.CurrentVehicle.Speed += 0.5f;
            }
            if (Game.IsKeyPressed(Keys.NumPad3))
            {
                Game.Player.Character.CurrentVehicle.Speed = 0.0f;
            }
        }

        if (CanVehiclesJump)
        {
            if (Game.IsKeyPressed(Keys.B))
            {
                if (Game.Player.Character.CurrentVehicle.IsOnAllWheels)
                {
                    Game.Player.Character.CurrentVehicle.ApplyForceRelative(Game.Player.Character.CurrentVehicle.UpVector * 12.5f);
                }
            }
        }

        if (IsLockedDoorsEnabled)
        {
            Game.Player.Character.CanBeDraggedOutOfVehicle = false;
        }

        if (IsEngineAlwaysEnabled)
        {
            Game.Player.Character.CurrentVehicle.EngineRunning = true;
        }

        if (IsVehicleWeaponsEnabled)
        {
            /*if (Game.Player.Character.IsInVehicle() && Game.IsKeyPressed(Keys.Add))
            {
                Vehicle vehicle = Game.Player.Character.CurrentVehicle;

                // Request and load weapon asset.
                GTA.Model weaponAsset = Function.Call<int>(Hash.GET_HASH_KEY, GetVehicleWeaponAsset());
                if (!Function.Call<bool>(Hash.HAS_WEAPON_ASSET_LOADED, weaponAsset))
                {
                    Function.Call(Hash.REQUEST_WEAPON_ASSET, weaponAsset);
                    while (!Function.Call<bool>(Hash.HAS_WEAPON_ASSET_LOADED, weaponAsset))
                    {
                        Wait(0);
                    }
                }

                Vector3 vehicleDimensions = vehicle.Model.GetDimensions();

                // Left weapon.
                Vector3 leftWeaponFromCoords = vehicle.GetOffsetInWorldCoords(new Vector3(-(vehicleDimensions.X) + 1.25f, vehicleDimensions.Y + 1.25f, 0.3f));
                Vector3 leftWeaponToCoords = vehicle.GetOffsetInWorldCoords(new Vector3(-(vehicleDimensions.X) + 1.25f, vehicleDimensions.Y + 100.0f, 0.3f));

                // Right weapon.
                Vector3 rightWeaponFromCoords = vehicle.GetOffsetInWorldCoords(new Vector3(vehicleDimensions.X - 1.25f, vehicleDimensions.Y + 1.25f, 0.3f));
                Vector3 rightWeaponToCoords = vehicle.GetOffsetInWorldCoords(new Vector3(vehicleDimensions.X + 1.25f, vehicleDimensions.Y + 100.0f, 0.3f));

                World.ShootBullet(leftWeaponFromCoords, leftWeaponToCoords, Game.Player.Character, weaponAsset, 10000);
                World.ShootBullet(rightWeaponFromCoords, rightWeaponToCoords, Game.Player.Character, weaponAsset, 10000);
                weaponAsset.MarkAsNoLongerNeeded();
                Wait(150);
            }*/
        }

        if(LeftIndicatorLightOn)
        {
            veh.LeftIndicatorLightOn = false;
            
        }

        if(RightIndicatorLightOn)
        {
            veh.RightIndicatorLightOn = false;
            
        }

        if(IsInteriorLightOn)
        {
            veh.InteriorLightOn = false;
        }

        if(IsBombBayOpen)
        {
            IsBombBayOpen = true;
        }

    }

    internal static void SpawnVehicle(VehicleHash vehicle)
    {
        Vehicle spawnedVehicle = World.CreateVehicle(vehicle, Game.Player.Character.Position + (Game.Player.Character.ForwardVector * 6.5f), Game.Player.Character.Heading + 90.0f);
        
        if (spawnedVehicle.Exists())
        {
            spawnedVehicle.PlaceOnGround();
            spawnedVehicle.EngineRunning = true;

            if (IsWarpInSpawnedVehicleEnabled)
            {
                spawnedVehicle.Heading = Game.Player.Character.Heading;
                Game.Player.Character.Task.WarpIntoVehicle(spawnedVehicle, VehicleSeat.Driver);
            }
            
        }
        spawnedVehicle.MarkAsNoLongerNeeded();
    }

    internal static void ToggleWarpInSpawnedVehicle()
    {
        IsWarpInSpawnedVehicleEnabled = !IsWarpInSpawnedVehicleEnabled;

        MainMenu.DisplayMessage("Warp in Spawned Vehicle", IsWarpInSpawnedVehicleEnabled);
    }

    internal static void FixVehicle()
    {
        if (Game.Player.Character.IsInVehicle())
        {
            veh.Repair();
            veh.Wash();
            veh.EngineRunning = true;

            MainMenu.DisplayMessage("~g~Vehicle Fixed");
        } else
        {
            MainMenu.DisplayMessage("~r~ You Are Not In A Vehicle");
        }
    }

    internal static void WashVehicle()
    {
        if (Game.Player.Character.IsInVehicle())
        {

            veh.Wash();
            
            MainMenu.DisplayMessage("~g~Vehicle Washed");
        }
        else
        {
            MainMenu.DisplayMessage("~r~ You Are Not In A Vehicle");
        }
    }

    internal static void VehicleIndestructible()
    {
        IsVehicleIndestructible = !IsVehicleIndestructible;

        if (!IsVehicleIndestructible)
        {
            SetVehicleIndestructible(false);
        }  
    }

    internal static void SpawnVehicle(VehicleHash[] allVehiclesHashes)
    {
        throw new NotImplementedException();
    }

    private static void SetVehicleIndestructible(bool value)
    {
        Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
        Vehicle prevVehicle = Game.Player.LastVehicle;
        Vehicle vehicle;

        if (Game.Player.Character.IsInVehicle())
            vehicle = currentVehicle;
        else
            vehicle = prevVehicle;
        if(vehicle.Driver == Player && Player.IsInVehicle() && vehicle.Exists())
        {
            if (value)
            {
                Function.Call(Hash.SET_ENTITY_INVINCIBLE, vehicle, true);
                Function.Call(Hash.SET_ENTITY_PROOFS, vehicle, 1, 1, 1, 1, 1, 1, 1, 1);
                Function.Call(Hash.SET_VEHICLE_TYRES_CAN_BURST, vehicle, false);
                Function.Call(Hash.SET_VEHICLE_WHEELS_CAN_BREAK, vehicle, false);
                Function.Call(Hash.SET_VEHICLE_CAN_BE_VISIBLY_DAMAGED, vehicle, false);
                foreach (VehicleDoor door in Enum.GetValues(typeof(VehicleDoor)))
                {
                    veh.SetDoorBreakable(door, false);
                }
            }
            else
            {
                Function.Call(Hash.SET_ENTITY_INVINCIBLE, vehicle, false);
                Function.Call(Hash.SET_ENTITY_PROOFS, vehicle, 0, 0, 0, 0, 0, 0, 0, 0);
                Function.Call(Hash.SET_VEHICLE_TYRES_CAN_BURST, vehicle, true);
                Function.Call(Hash.SET_VEHICLE_WHEELS_CAN_BREAK, vehicle, true);
                Function.Call(Hash.SET_VEHICLE_CAN_BE_VISIBLY_DAMAGED, vehicle, true);
                foreach (VehicleDoor door in Enum.GetValues(typeof(VehicleDoor)))
                {
                    veh.SetDoorBreakable(door, true);
                }
            }
        }
    }

    internal static void ToggleSeatBelt()
    {
        IsSeatBeltEnabled = !IsSeatBeltEnabled;

        if (!IsSeatBeltEnabled)
        {
            Function.Call(Hash.SET_PED_CONFIG_FLAG, Game.Player.Character, PedFlagCanFlyThroughWindscreen, true);
        } 

        MainMenu.DisplayMessage("Seat Belt", IsSeatBeltEnabled);
    }

    internal static void ToggleLockDoors()
    {

         int vehDoorLockStatus = Function.Call<int>(Hash.GET_VEHICLE_DOOR_LOCK_STATUS, veh);

         if (veh.Exists() && vehDoorLockStatus == 1)
         {

            Function.Call(Hash.SET_VEHICLE_DOORS_LOCKED, veh, 2);
            MainMenu.DisplayMessage("Vehicle is Locked");

         } else if (veh.Exists() && vehDoorLockStatus == 2)
         {
            Function.Call(Hash.SET_VEHICLE_DOORS_LOCKED, veh, 1);
            MainMenu.DisplayMessage("Vehicle is Unocked");
        }
    }

    internal static void ToggleChildLock()
    {
        
        Ped Player = Game.Player.Character;
        int vehChildLockStatus = Function.Call<int>(Hash.GET_VEHICLE_DOOR_LOCK_STATUS, veh);

        if (veh.Exists() && vehChildLockStatus == 1 && Player.IsInVehicle())
        {

            Function.Call(Hash.SET_VEHICLE_DOORS_LOCKED, veh, 4);
            MainMenu.DisplayMessage("Child Lock Enabled");

        }
        else if (veh.Exists() && vehChildLockStatus == 4 && Player.IsInVehicle())
        {
            Function.Call(Hash.SET_VEHICLE_DOORS_LOCKED, veh, 1);
            MainMenu.DisplayMessage("Child Lock disabled");
        }
    }

    internal static void ToggleNoGettingPulled()
    {
        IsLockedDoorsEnabled = !IsLockedDoorsEnabled;

        if (!IsLockedDoorsEnabled)
        {
            
            Game.Player.Character.CanBeDraggedOutOfVehicle = true;

        }

       
    }

    internal static void ToggleNeverFallOffBike()
    {
        IsNeverFallOffBikeEnabled = !IsNeverFallOffBikeEnabled;

        if (!IsNeverFallOffBikeEnabled)
        {
            Function.Call(Hash.SET_PED_CAN_BE_KNOCKED_OFF_VEHICLE, Game.Player.Character, 0);
        }
            
        MainMenu.DisplayMessage("Never Fall-Off Bike", IsNeverFallOffBikeEnabled);
    }

    internal static void ToggleSpeedBoost()
    {
        IsSpeedBoostEnabled = !IsSpeedBoostEnabled;

        MainMenu.DisplayMessage("Speed Boost", IsSpeedBoostEnabled);
    }

    internal static void ToggleVehicleJump()
    {
        CanVehiclesJump = !CanVehiclesJump;

        MainMenu.DisplayMessage("Vehicle Jump", CanVehiclesJump);
    }

    internal static void ToggleVehicleWeapons()
    {
        IsVehicleWeaponsEnabled = !IsVehicleWeaponsEnabled;

        MainMenu.DisplayMessage("Vehicle Weapons", IsVehicleWeaponsEnabled);
    }

    internal static void ToggleEngineAlwaysOn()
    {
        IsEngineAlwaysEnabled = !IsEngineAlwaysEnabled;
        
        MainMenu.DisplayMessage("Leave Engine Running", IsVehicleWeaponsEnabled);
    }

    internal static void FlipVehicle()
    {
        Ped Player = Game.Player.Character;

        if(Player.IsInVehicle() && veh.IsUpsideDown)
        {
            veh.PlaceOnGround();
            MainMenu.DisplayMessage("Vehicle Succesfully Flipped");
        }
    }

    internal static void toggleVehicleAlarm()
    {
        Ped Player = Game.Player.Character;
        bool isVehAlarmActive = Function.Call<bool>(Hash.IS_VEHICLE_ALARM_ACTIVATED, veh);

        
        
        if (veh.Exists() && isVehAlarmActive == false && !Player.IsInVehicle())
        {
            Function.Call(Hash.SET_VEHICLE_ALARM, veh, true);
            Function.Call(Hash.START_VEHICLE_ALARM, veh);
            MainMenu.DisplayMessage("Vehicle Alarm Active");
        }
        else if (veh.Exists() && isVehAlarmActive == true )
        {
            Function.Call(Hash.SET_VEHICLE_ALARM, veh, false);
            Function.Call(Hash.START_VEHICLE_ALARM, veh);
            MainMenu.DisplayMessage("Vehicle Alarm Deactivated");
        }
            
    }

    internal static void RollAllWindowDown()
    {
        if (veh.Exists())
        {
            Function.Call(Hash.ROLL_DOWN_WINDOWS, veh);
        }
    }

    internal static void RollWindowDown(KeyValuePair<int,string> window)
    {
        if (veh.Exists())
        {
            Function.Call(Hash.ROLL_DOWN_WINDOW, veh, window.Key);
        }
    }

    internal static void RollWindowUp(KeyValuePair<int, string> window)
    {
        if (veh.Exists())
        {
            Function.Call(Hash.ROLL_UP_WINDOW, veh, window.Key);
        }
    }

    internal static void FixWindow(KeyValuePair<int, string> window)
    {
        if (veh.Exists())
        {
            Function.Call(Hash.FIX_VEHICLE_WINDOW, veh, window.Key);
            MainMenu.DisplayMessage("Window Has Been Fixed");
        }
    }

    internal static void VehOpenDoor(KeyValuePair<int, string> door)
    {
        
        bool isDoorFullyOpen = Function.Call<bool>(Hash.IS_VEHICLE_DOOR_FULLY_OPEN, veh, door.Key);
        
        if (veh.Exists() && !isDoorFullyOpen || Game.Player.Character.IsInVehicle())
        {
            Function.Call(Hash.SET_VEHICLE_DOOR_OPEN, veh.Handle, door.Key, false, false);
            MainMenu.DisplayMessage("Door Has Been Opened");

        }
    }

    internal static void VehCloseDoor(KeyValuePair<int, string> door)
    {
        
        bool isDoorFullyOpen = Function.Call<bool>(Hash.IS_VEHICLE_DOOR_FULLY_OPEN, veh, door.Key);

        if (veh.Exists() && !isDoorFullyOpen)
        {
            Function.Call(Hash.SET_VEHICLE_DOOR_SHUT, veh.Handle, door.Key, false, false);
            MainMenu.DisplayMessage("Door Has Been Closed");
        }
    }

    internal static void CloseAllDoors()
    {

        if (veh.Exists())
        {
            Function.Call(Hash.SET_VEHICLE_DOORS_SHUT, veh.Handle, false, false);
            MainMenu.DisplayMessage("All Doors Have Been Shut");
        }
    }


    internal static void ToggleVehicleInvisible()
    {
        Ped Player = Game.Player.Character;
        

        bool isPlayerVisible = true;

        if (Player.IsInVehicle() && Player.IsVisible)
        {
            veh.IsVisible = !veh.IsVisible;
            Player.IsVisible = isPlayerVisible;      
       
        }
        else 
        {
            veh.IsVisible = !veh.IsVisible; //car invisible
            Player.IsVisible = isPlayerVisible;
        }
    }

    internal static void SetPlateStyle(int plateNumber)
    {
        Function.Call(Hash.SET_VEHICLE_NUMBER_PLATE_TEXT_INDEX, veh, plateNumber);
    }

    #region Vehicle Weapons
    public static Dictionary<string, string> VehicleWeaponAssetsDict = new Dictionary<string, string>()
    {
        {"Rockets", "WEAPON_AIRSTRIKE_ROCKET"}, {"Bullets", "VEHICLE_WEAPON_PLAYER_BULLET"}
    };
    /*public static string GetVehicleWeaponAsset()
    {
        WeaponHash[] weaponAsset = (WeaponHash[])Enum.GetValues(typeof(WeaponHash));
        foreach (KeyValuePair<string, string> weapon in VehicleWeaponAssetsDict)
        {
            if (weapon.Key == weaponAsset)
            {
                weaponAsset = weapon.Value;
                break;
            }
        }

        return weaponAsset;
    }*/
    #endregion


    public static int? GetVehicleIndicatorLights(Vehicle vehicle)
    {
        LeftIndicatorLightOn = !LeftIndicatorLightOn;
        RightIndicatorLightOn = !RightIndicatorLightOn;

        if (LeftIndicatorLightOn == false && RightIndicatorLightOn == false)
        {
            return 0; // none
        }
        else if (LeftIndicatorLightOn == true && RightIndicatorLightOn == false)
        {
            return 1; //left 
        }
        else if (LeftIndicatorLightOn == false && RightIndicatorLightOn == true)
        {
            return 2; // Right
        }
        else if (LeftIndicatorLightOn == true && RightIndicatorLightOn == true)
        {
            
            return 3; // Both
        }
        else
        {
            return null;
        }
    }

    public static void LeftIndicatorLightOn_set(bool value)
    {
        Vehicle veh = CommonFunctions.GetVehicle();
        Function.Call(Hash.SET_VEHICLE_INDICATOR_LIGHTS, veh.Handle, 1, value); // left on
    }

    public static void RightIndicatorLightOn_set(bool value)
    {
        Vehicle veh = CommonFunctions.GetVehicle();
        Function.Call(Hash.SET_VEHICLE_INDICATOR_LIGHTS, veh.Handle, 0, value); // Right on
    }

    public static void SetInteriorLights(Vehicle vehicle)
    {
        IsInteriorLightOn = !IsInteriorLightOn;
        Function.Call(Hash.SET_VEHICLE_INTERIORLIGHT, vehicle, !IsInteriorLightOn);
    }

    public static void GetBombBayDoorStatus(Vehicle vehicle)
    {
        IsBombBayOpen = !IsBombBayOpen;

        if (!IsBombBayOpen)
        {
            veh.OpenBombBay();

        } else 
        {
            veh.CloseBombBay();
            
        }
    }

}