using System;
using System.Collections.Generic;
using GTA;
using GTA.Native;
using GTA.Math;
using System.Globalization;

class WeaponFunctions : Script
{
    public static bool HasWeaponInfiniteAmmo { get; set; }
    public static bool HasWeaponFireBullets { get; set; }
    public static bool HasWeaponExplosiveBullets { get; set; }
    public static bool IsExplosiveMeleeEnabled { get; set; }
    public static bool IsOneHitKillEnabled { get; set; }
    public static bool IsGravityGunEnabled { get; set; }
    public static Entity GetAimedEntity { get; set; }

    List<WeaponHash> weaponHashList = new List<WeaponHash>()
    {
        WeaponHash.BZGas, WeaponHash.FireExtinguisher, WeaponHash.Firework,
        WeaponHash.Grenade, WeaponHash.GrenadeLauncher, WeaponHash.GrenadeLauncherSmoke,
        WeaponHash.HomingLauncher, WeaponHash.Molotov, WeaponHash.ProximityMine,
        WeaponHash.RPG, WeaponHash.SmokeGrenade, WeaponHash.StickyBomb
    };

    public WeaponFunctions()
    {
        Tick += OnTick;
        Game.Player.Character.Weapons.Current.InfiniteAmmoClip = false;
        Function.Call(Hash.SET_PLAYER_WEAPON_DAMAGE_MODIFIER, Game.Player, 1.0f);
        Function.Call(Hash.SET_PLAYER_MELEE_WEAPON_DAMAGE_MODIFIER, Game.Player, 1.0f);
    }
    private void OnTick(object sender, EventArgs e)
    {
        if (HasWeaponInfiniteAmmo)
        {
            Weapon playerWeapon = Game.Player.Character.Weapons.Current;

            playerWeapon.InfiniteAmmoClip = true;
            if (playerWeapon.AmmoInClip != playerWeapon.MaxAmmoInClip)
            {
                playerWeapon.AmmoInClip = playerWeapon.MaxAmmoInClip;
            }
        }

        if (HasWeaponFireBullets)
            Function.Call(Hash.SET_FIRE_AMMO_THIS_FRAME, Game.Player);

        if (HasWeaponExplosiveBullets)
            Function.Call(Hash.SET_EXPLOSIVE_AMMO_THIS_FRAME, Game.Player);

        if (IsExplosiveMeleeEnabled)
            Function.Call(Hash.SET_EXPLOSIVE_MELEE_THIS_FRAME, Game.Player);

        // Revisit Gravity Gun function - needs better logic.
        if (IsGravityGunEnabled)
        {
            WeaponHash currentWeapon = (WeaponHash)Game.Player.Character.Weapons.Current.Hash;
            Entity entity = Game.Player.GetTargetedEntity();

            if (Game.Player.Character.IsShooting && !weaponHashList.Contains(currentWeapon))
            {
                GetAimedEntity = entity;
                if (entity is Ped)
                {
                    Ped ped = (Ped)entity;
                    if (ped.IsInVehicle())
                    {
                        Function.Call(Hash.SET_VEHICLE_GRAVITY, ped.CurrentVehicle, 0);
                        ped.CurrentVehicle.ApplyForceRelative(new Vector3(0.0f, 0.0f, 1.5f));
                    }
                    else
                    {
                        Function.Call(Hash.SET_ENTITY_HAS_GRAVITY, ped, false);
                        ped.ApplyForceRelative(new Vector3(0.0f, 0.0f, 1.5f));
                    }
                }

                if (entity is Vehicle)
                {
                    Vehicle vehicle = (Vehicle)entity;
                    Function.Call(Hash.SET_VEHICLE_GRAVITY, vehicle, 0);
                    vehicle.ApplyForceRelative(new Vector3(0.0f, 0.0f, 1.5f));
                }
            }
        }
    }

    internal static void GiveAllWeapons()
    {
        foreach (WeaponHash weaponHash in Enum.GetValues(typeof(WeaponHash)))
        {
            bool hasPedGotWeapon = Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON, Game.Player.Character, (int)weaponHash, false);

            if (!hasPedGotWeapon)
            {
                Game.Player.Character.Weapons.Give(weaponHash, 9999, true, true);
            }
            else
            {
                Function.Call(Hash.SET_PED_AMMO, Game.Player.Character, (int)weaponHash, 9999);
            }
        }

        MainMenu.DisplayMessage("All Weapons Received");
    }

    internal static void RemoveAllWeapons()
    {
        foreach (WeaponHash weaponHash in Enum.GetValues(typeof(WeaponHash)))
        {
            bool hasPedGotWeapon = Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON, Game.Player.Character, (int)weaponHash, false);
            //needs validation for some guns
            if (!hasPedGotWeapon)
            {
                MainMenu.DisplayMessage("There are no weapons to remove");
            }
            else if(hasPedGotWeapon)
            {
                Function.Call(Hash.REMOVE_ALL_PED_WEAPONS, Game.Player.Character, true);
                MainMenu.DisplayMessage("All Weapons Have Been Removed");
            }
        }
    }

    internal static void GiveMaxAmmo()
    {
        foreach (WeaponHash weaponHash in Enum.GetValues(typeof(WeaponHash)))
        {
            bool hasPedGotWeapon = Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON, Game.Player.Character, (int)weaponHash, false);

            if (hasPedGotWeapon)
            {
                Function.Call(Hash.SET_PED_AMMO, Game.Player.Character, (int)weaponHash, 9999);
                MainMenu.DisplayMessage("Max Ammo Received");
            }
            else
            {
                MainMenu.DisplayMessage("Obtain Weapons to Recive Max Ammo");
            }
        }
    }

    internal static void InfiniteAmmo()
    {
        HasWeaponInfiniteAmmo = !HasWeaponInfiniteAmmo;

        if (!HasWeaponInfiniteAmmo)
            Game.Player.Character.Weapons.Current.InfiniteAmmoClip = false;

        MainMenu.DisplayMessage("Infinite Ammunition", HasWeaponInfiniteAmmo);
    }

    internal static void FireBullets()
    {
        HasWeaponFireBullets = !HasWeaponFireBullets;

        MainMenu.DisplayMessage("Fire Bullets", HasWeaponFireBullets);
    }

    internal static void ExplosiveBullets()
    {
        HasWeaponExplosiveBullets = !HasWeaponExplosiveBullets;

        MainMenu.DisplayMessage("Explosive Bullets", HasWeaponExplosiveBullets);
    }

    internal static void ExplosiveMelee()
    {
        IsExplosiveMeleeEnabled = !IsExplosiveMeleeEnabled;

        MainMenu.DisplayMessage("Explosive Melee", IsExplosiveMeleeEnabled);
    }

    internal static void OneHitKill()
    {
        IsOneHitKillEnabled = !IsOneHitKillEnabled;

        if (IsOneHitKillEnabled)
        {
            Function.Call(Hash.SET_PLAYER_WEAPON_DAMAGE_MODIFIER, Game.Player, 1000.0f);
            Function.Call(Hash.SET_PLAYER_MELEE_WEAPON_DAMAGE_MODIFIER, Game.Player, 1000.0f);
        }
        else
        {
            Function.Call(Hash.SET_PLAYER_WEAPON_DAMAGE_MODIFIER, Game.Player, 1.0f);
            Function.Call(Hash.SET_PLAYER_MELEE_WEAPON_DAMAGE_MODIFIER, Game.Player, 1.0f);
        }

        MainMenu.DisplayMessage("One-Hit Kill", IsOneHitKillEnabled);
    }

    internal static void GravityGun()
    {
        IsGravityGunEnabled = !IsGravityGunEnabled;

        MainMenu.DisplayMessage("Gravity Gun", IsGravityGunEnabled);
    }

    #region
    internal static void ChangeWeaponComponent(WeaponHash weapon, KeyValuePair<string, string> weaponComponent)
    {
        int weaponComponentHash = Function.Call<int>(Hash.GET_HASH_KEY, weaponComponent.Key);
        bool hasWeaponGotComponent = Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, Game.Player.Character, (int)weapon, weaponComponentHash);

        if (!hasWeaponGotComponent)
        {
            Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, Game.Player.Character, (int)weapon, weaponComponentHash);
            MainMenu.DisplayMessage(string.Format(CultureInfo.GetCultureInfo(1033), "Attachment {0:C} has been equiped", weaponComponent));
        }
        else
        {
            Function.Call(Hash.REMOVE_WEAPON_COMPONENT_FROM_PED, Game.Player.Character, (int)weapon, weaponComponentHash);
            MainMenu.DisplayMessage(string.Format(CultureInfo.GetCultureInfo(1033), "Attachment {0:C} has been removed", weaponComponent));
        }
    }
    internal static void ChangeWeaponTint(WeaponHash weapon, int tintIndex)
    {
        Function.Call(Hash.SET_PED_WEAPON_TINT_INDEX, Game.Player.Character, (int)weapon, tintIndex);
    }

    internal static void EquipWeapon(WeaponHash weapon)
    {
        bool hasPedGotWeapon = Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON, Game.Player.Character, (int)weapon, false);

        if (!hasPedGotWeapon)
        {
            Game.Player.Character.Weapons.Give(weapon, 9999, true, true);
            MainMenu.DisplayMessage("Weapon Equiped");
        }
        else
        {
            MainMenu.DisplayMessage("You Already Have This Weapon");
        }
    }

    internal static void FillAmmo(WeaponHash weapon)
    {
        bool hasPedGotWeapon = Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON, Game.Player.Character, (int)weapon, false);
        Ped Player = Game.Player.Character;

        if (!hasPedGotWeapon)
        {
            MainMenu.DisplayMessage("You do not have this Weapon Equiped");
        }
        else
        {
            
            //Get Ammo Type from current weapon in menu
            UInt32 ammoType = Function.Call<UInt32>(Hash._GET_PED_AMMO_TYPE, Player, (int)weapon);
            //Set ped ammo to 9999 by type 'FMJ or etc'
            Function.Call(Hash.SET_PED_AMMO_BY_TYPE, Player, ammoType, 9999);
            

            
            
        }
    }

    internal static void EmptyAmmo(WeaponHash weapon)
    {
        bool hasPedGotWeapon = Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON, Game.Player.Character, (int)weapon, false);

        if (!hasPedGotWeapon)
        {
            MainMenu.DisplayMessage("You do not have this Weapon Equiped");
        }
        else
        {
           
        }
    }

    internal static void dropWeapon(WeaponHash weapon)
    {
        bool hasPedGotWeapon = Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON, Game.Player.Character, (int)weapon, false);
        int ammoInClip = Function.Call<int>(Hash.GET_AMMO_IN_CLIP, Game.Player, (int)weapon);

        if (!hasPedGotWeapon)
        {
            MainMenu.DisplayMessage("You do not have this Weapon Equiped or this weapon is not in your hand");
        }
        else 
        {
            Function.Call(Hash.SET_PED_DROPS_INVENTORY_WEAPON, Game.Player.Character, (int)weapon, 0.4f, 2.7f, -0.1f, ammoInClip);
            MainMenu.DisplayMessage("Weapon Has Been Dropped");
            
        }
    }

    internal static void upgradeAllWeapons()
    {
        foreach (WeaponHash weaponHash in Enum.GetValues(typeof(WeaponHash)))
        {
            bool hasPedGotWeapon = Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON, Game.Player.Character, (int)weaponHash, false);

            if (!hasPedGotWeapon)
            {
                
            }
            else
            {
                Function.Call(Hash.SET_PED_AMMO, Game.Player.Character, (int)weaponHash, 9999);
            }
        }

        MainMenu.DisplayMessage("All Weapons Received");
    }
    #endregion
}