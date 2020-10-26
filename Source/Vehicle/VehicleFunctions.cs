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
            Game.Player.Character.CurrentVehicle.Repair();
            Game.Player.Character.CurrentVehicle.Wash();
            Game.Player.Character.CurrentVehicle.EngineRunning = true;

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

            Game.Player.Character.CurrentVehicle.Wash();
            
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

        if (value)
        {
            Function.Call(Hash.SET_ENTITY_INVINCIBLE, vehicle, true);
            Function.Call(Hash.SET_ENTITY_PROOFS, vehicle, 1, 1, 1, 1, 1, 1, 1, 1);
            Function.Call(Hash.SET_VEHICLE_TYRES_CAN_BURST, vehicle, false);
            Function.Call(Hash.SET_VEHICLE_WHEELS_CAN_BREAK, vehicle, false);
            Function.Call(Hash.SET_VEHICLE_CAN_BE_VISIBLY_DAMAGED, vehicle, false);
            foreach (VehicleDoor door in Enum.GetValues(typeof(VehicleDoor)))
            {
                vehicle.SetDoorBreakable(door, false);
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
                vehicle.SetDoorBreakable(door, true);
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
        IsLockedDoorsEnabled = !IsLockedDoorsEnabled;

        if (!IsLockedDoorsEnabled)
        {
            Game.Player.Character.CanBeDraggedOutOfVehicle = true;
        }

        MainMenu.DisplayMessage("Locked Doors", IsLockedDoorsEnabled);
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
}