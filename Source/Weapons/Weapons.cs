﻿using System;
using System.Collections.Generic;
using GTA;
using GTA.Native;
using NativeUI;

partial class MainMenu : Script
{
    public UIMenu weaponsMenu;
    public UIMenu weaponOptions;
    public UIMenu weaponSelectionMenu;
    public UIMenu weaponName;
    public UIMenu weaponAttachmentMenu;



    private void EliteWeaponsMenu()
    {
        weaponsMenu = modMenuPool.AddSubMenu(mainMenu, "Weapons");

        UIMenuItem giveAllWeapons = new UIMenuItem("Give All Weapons");
        giveAllWeapons.Activated += (sender, args) => WeaponFunctions.GiveAllWeapons();
        weaponsMenu.AddItem(giveAllWeapons);

        weaponSelectionMenu = modMenuPool.AddSubMenu(weaponsMenu, "Individual Weapons & Attachments");

        weaponOptions = modMenuPool.AddSubMenu(weaponsMenu, "Weapon Options");

        var removeAllWeapons = new UIMenuItem("Remove All Weapons");
        weaponOptions.AddItem(removeAllWeapons);
        weaponOptions.OnItemSelect += (sender, item, index) =>
        {
            if (item == removeAllWeapons)
            {
                WeaponFunctions.RemoveAllWeapons();
            }
        };
        var maxAmmo = new UIMenuItem("Give Max Ammo");
        weaponOptions.AddItem(maxAmmo);
        weaponOptions.OnItemSelect += (sender, item, index) =>
        {
            if (item == maxAmmo)
            {
                WeaponFunctions.GiveMaxAmmo();
            }
        };

        UIMenuItem infiniteAmmo = new UIMenuCheckboxItem("Infinite Ammo", false);
        weaponOptions.AddItem(infiniteAmmo);
        weaponOptions.OnCheckboxChange += (sender, item, checked_) =>
        {
            if(item == infiniteAmmo)
            {
                WeaponFunctions.InfiniteAmmo();
            }
            
        };

        UIMenuItem explosiveBullets = new UIMenuCheckboxItem("Explosive Bullets", false);
        weaponOptions.AddItem(explosiveBullets);
        weaponOptions.OnCheckboxChange += (sender, item, checked_) =>
        {
            if(item == explosiveBullets)
            {
                WeaponFunctions.ExplosiveBullets();
            }
        };


        UIMenuItem explosiveMelee = new UIMenuCheckboxItem("Explosive Melee", false);
        weaponOptions.AddItem(explosiveMelee);
        weaponOptions.OnCheckboxChange += (sender, item, checked_) =>
        {
            if (item == explosiveMelee)
            {
                WeaponFunctions.ExplosiveMelee();
            }
        };


        UIMenuItem oneHitKill = new UIMenuCheckboxItem("One-Hit Kill", false);
        weaponOptions.AddItem(oneHitKill);
        weaponOptions.OnCheckboxChange += (sender, item, checked_) =>
        {
            if(item == oneHitKill)
            {
                WeaponFunctions.OneHitKill();
            } 
        };


        UIMenuItem gravityGun = new UIMenuCheckboxItem("Gravity Gun", false);
        weaponOptions.AddItem(gravityGun);
        weaponOptions.OnCheckboxChange += (sender, item, checked_) =>
        {
            if(item == gravityGun)
            {
                WeaponFunctions.GravityGun();
            }
        };
    }


    #region Individual weapons & attachments

    private void WeaponSelectionMenu()
    {
        Dictionary<string, string> weaponComponentItems = new Dictionary<string, string>()
        {
            #region Global
            {"COMPONENT_AT_PI_FLSH","Flashlight"},
            {"COMPONENT_AT_PI_SUPP", "Suppressor"},
            {"COMPONENT_AT_AR_SUPP_02", "Suppressor"},
            {"COMPONENT_AT_PI_COMP_03","Compensator"},
            {"COMPONENT_AT_PI_FLSH_03", "Flashlight"},
            {"COMPONENT_AT_PI_RAIL_02", "Mounted Scope"},
            {"COMPONENT_AT_SCOPE_MACRO", "Scope"},
            {"COMPONENT_AT_SCOPE_MACRO_02", "Scope"},
            {"COMPONENT_AT_SIGHTS_SMG", "Holographic Sight"},
            {"COMPONENT_AT_AR_FLSH", "Flashlight"},
            {"COMPONENT_AT_AR_AFGRIP", "Grip"},
            {"COMPONENT_AT_SCOPE_SMALL", "Scope"},
            {"COMPONENT_AT_SIGHTS","Holographic Sight"},
            {"COMPONENT_AT_SCOPE_MEDIUM", "Scope"},
            {"COMPONENT_AT_MUZZLE_01","FlatMuzzleBrake"},
            {"COMPONENT_AT_MUZZLE_02","TacticalMuzzleBrake"},
            {"COMPONENT_AT_MUZZLE_03","Fat-EndMuzzleBrake"},
            {"COMPONENT_AT_MUZZLE_04","PrecisionMuzzleBrake"},
            {"COMPONENT_AT_MUZZLE_05","HeavyDutyMuzzleBrake"},
            {"COMPONENT_AT_MUZZLE_06","SlantedMuzzleBrake"},
            {"COMPONENT_AT_MUZZLE_07","Split-EndMuzzleBrake"},
            {"COMPONENT_AT_MUZZLE_09","Bell-End Muzzle Brake"},
            {"COMPONENT_AT_MUZZLE_08", "Squared Muzzle Brake"},
            {"COMPONENT_AT_SCOPE_MACRO_MK2","Small Scope"},
            {"COMPONENT_AT_SCOPE_MEDIUM_MK2","Large Scope"},
            {"COMPONENT_AT_SCOPE_LARGE", "Scope" },
            {"COMPONENT_AT_SCOPE_MAX", "Advanced Scope" },
            {"COMPONENT_AT_SCOPE_LARGE_MK2","Zoom Scope"},
            {"COMPONENT_AT_SR_SUPP_03", "Suppressor"},
            #endregion

            #region Knuckle Duster
            {"COMPONENT_KNUCKLE_VARMOD_BASE","Base Model"},
            {"COMPONENT_KNUCKLE_VARMOD_PIMP", "The Pimp"},
            {"COMPONENT_KNUCKLE_VARMOD_BALLAS", "The Ballas"},
            {"COMPONENT_KNUCKLE_VARMOD_DOLLAR", "The Hustler"},
            {"COMPONENT_KNUCKLE_VARMOD_DIAMOND", "The Rock"},
            {"COMPONENT_KNUCKLE_VARMOD_HATE", "The Hater"},
            {"COMPONENT_KNUCKLE_VARMOD_LOVE", "The Lover"},
            {"COMPONENT_KNUCKLE_VARMOD_PLAYER", "The Player"},
            {"COMPONENT_KNUCKLE_VARMOD_KING", "The King"},
            {"COMPONENT_KNUCKLE_VARMOD_VAGOS", "The Vagos"},
            #endregion

            #region Switchblade
            {"COMPONENT_SWITCHBLADE_VARMOD_BASE", "Default Handle"},
            {"COMPONENT_SWITCHBLADE_VARMOD_VAR1	","VIP Variant"},
            {"COMPONENT_SWITCHBLADE_VARMOD_VAR2","Bodyguard Variant"},
            #endregion

            #region Pistols
            {"COMPONENT_PISTOL_CLIP_01", "Default Clip"},
            {"COMPONENT_PISTOL_CLIP_02","Extended Clip"},
            {"COMPONENT_PISTOL_VARMOD_LUXE","Yusuf Amir Luxury Finish"},
            #endregion

            #region Combat Pistol
            {"COMPONENT_COMBATPISTOL_CLIP_01", "Default Clip"},
            {"COMPONENT_COMBATPISTOL_CLIP_02","Extended Clip"},
            {"COMPONENT_COMBATPISTOL_VARMOD_LOWRIDER","Yusuf Amir Luxury Finish"},
            #endregion

            #region AP Pistol
            {"COMPONENT_APPISTOL_CLIP_01", "Default Clip"},
            {"COMPONENT_APPISTOL_CLIP_02","Extended Clip"},
            {"COMPONENT_APPISTOL_VARMOD_LUXE","Gilded Gun Metal Finish"},
            #endregion


            #region Pistol .50
            {"COMPONENT_PISTOL50_CLIP_01", "Default Clip"},
            {"COMPONENT_PISTOL50_CLIP_02","Extended Clip"},
            {"COMPONENT_PISTOL50_VARMOD_LUXE","Platinum Pearl Deluxe Finish"},
            
            #endregion

            #region Heavy Revolver
            {"COMPONENT_REVOLVER_CLIP_01", "Default Clip"},
            {"COMPONENT_REVOLVER_VARMOD_BOSS","VIP Variant"},
            {"COMPONENT_REVOLVER_VARMOD_GOON","Bodyguard Variant"},
            
            #endregion

            #region SNS Pistol
            {"COMPONENT_SNSPISTOL_CLIP_01", "Default Clip"},
            {"COMPONENT_SNSPISTOL_CLIP_02","Extended Clip"},
            {"COMPONENT_SNSPISTOL_VARMOD_LOWRIDER","Etched Wood Grip Finish"},
            #endregion
            

            #region Heavy Revolver MKII
            {"COMPONENT_REVOLVER_MK2_CLIP_01","Default Clip"},
            {"COMPONENT_REVOLVER_MK2_CLIP_TRACER","Tracer Rounds"},
            {"COMPONENT_REVOLVER_MK2_CLIP_INCENDIARY","Incendiary Rounds"},
            {"COMPONENT_REVOLVER_MK2_CLIP_HOLLOWPOINT","Hollow Point Rounds"},
            {"COMPONENT_REVOLVER_MK2_CLIP_FMJ","Full Metal Jacket Rounds"},
            {"COMPONENT_REVOLVER_MK2_CAMO","Digital Camo"},
            {"COMPONENT_REVOLVER_MK2_CAMO_02","Brushstroke Camo"},
            {"COMPONENT_REVOLVER_MK2_CAMO_03","Woodland Camo"},
            {"COMPONENT_REVOLVER_MK2_CAMO_04","Skull"},
            {"COMPONENT_REVOLVER_MK2_CAMO_05","Sessanta Nove"},
            {"COMPONENT_REVOLVER_MK2_CAMO_06","Perseus"},
            {"COMPONENT_REVOLVER_MK2_CAMO_07","Leopard"},
            {"COMPONENT_REVOLVER_MK2_CAMO_08","Zebra"},
            {"COMPONENT_REVOLVER_MK2_CAMO_09","Geometric"},
            {"COMPONENT_REVOLVER_MK2_CAMO_10","Boom!"},
            {"COMPONENT_REVOLVER_MK2_CAMO_IND_01","Patriotic"},
            #endregion

            #region SNS Pistol MKII
            {"COMPONENT_SNSPISTOL_MK2_CLIP_01","Default Rounds"},
            {"COMPONENT_SNSPISTOL_MK2_CLIP_02","Extended Rounds"},
            {"COMPONENT_SNSPISTOL_MK2_CLIP_TRACER","Tracer Rounds"},
            {"COMPONENT_SNSPISTOL_MK2_CLIP_INCENDIARY","Incendiary Rounds"},
            {"COMPONENT_SNSPISTOL_MK2_CLIP_HOLLOWPOINT","Hollow Point Rounds"},
            {"COMPONENT_SNSPISTOL_MK2_CLIP_FMJ","Full Metal Jacket Rounds"},
            {"COMPONENT_SNSPISTOL_MK2_CAMO","Digital Camo"},
            {"COMPONENT_SNSPISTOL_MK2_CAMO_02","Brushstroke Camo"},
            {"COMPONENT_SNSPISTOL_MK2_CAMO_03","Woodland Camo"},
            {"COMPONENT_SNSPISTOL_MK2_CAMO_04","Skull"},
            {"COMPONENT_SNSPISTOL_MK2_CAMO_05","Sessanta Nove"},
            {"COMPONENT_SNSPISTOL_MK2_CAMO_06","Perseus"},
            {"COMPONENT_SNSPISTOL_MK2_CAMO_07","Leopard"},
            {"COMPONENT_SNSPISTOL_MK2_CAMO_08","Zebra"},
            {"COMPONENT_SNSPISTOL_MK2_CAMO_09","Geometric"},
            {"COMPONENT_SNSPISTOL_MK2_CAMO_10","Boom!"},
            {"COMPONENT_SNSPISTOL_MK2_CAMO_IND_01","Boom!"},
            {"COMPONENT_SNSPISTOL_MK2_CAMO_SLIDE","Digital Camo"},
            {"COMPONENT_SNSPISTOL_MK2_CAMO_02_SLIDE","Brushstroke Camo"},
            {"COMPONENT_SNSPISTOL_MK2_CAMO_03_SLIDE","Woodland Camo"},
            {"COMPONENT_SNSPISTOL_MK2_CAMO_04_SLIDE","Skull"},
            {"COMPONENT_SNSPISTOL_MK2_CAMO_05_SLIDE","Sessanta Nove"},
            {"COMPONENT_SNSPISTOL_MK2_CAMO_06_SLIDE","Perseus"},
            {"COMPONENT_SNSPISTOL_MK2_CAMO_07_SLIDE","Leopard"},
            {"COMPONENT_SNSPISTOL_MK2_CAMO_08_SLIDE","Zebra"},
            {"COMPONENT_SNSPISTOL_MK2_CAMO_09_SLIDE","Geometric"},
            {"COMPONENT_SNSPISTOL_MK2_CAMO_10_SLIDE","Boom!"},
            {"COMPONENT_SNSPISTOL_MK2_CAMO_IND_01_SLIDE","Patriotic"},
            #endregion

            #region Pistol MKII
            {"COMPONENT_PISTOL_MK2_CLIP_01","Default Clip"},
            {"COMPONENT_PISTOL_MK2_CLIP_02","Extended Clip"},
            {"COMPONENT_PISTOL_MK2_CLIP_TRACER","Tracer Rounds"},
            {"COMPONENT_PISTOL_MK2_CLIP_INCENDIARY","Incendiary Rounds"},
            {"COMPONENT_PISTOL_MK2_CLIP_HOLLOWPOINT","Hollow Point Rounds"},
            {"COMPONENT_PISTOL_MK2_CLIP_FMJ","Full Metal Jacket Rounds"},
            {"COMPONENT_PISTOL_MK2_CAMO","Digital Camo"},
            {"COMPONENT_PISTOL_MK2_CAMO_02", "Brushstroke Camo"},
            {"COMPONENT_PISTOL_MK2_CAMO_03", "Woodland Camo"},
            {"COMPONENT_PISTOL_MK2_CAMO_04", "Skull		"},
            {"COMPONENT_PISTOL_MK2_CAMO_05", "Sessanta Nove"},
            {"COMPONENT_PISTOL_MK2_CAMO_06", "Perseus"},
            {"COMPONENT_PISTOL_MK2_CAMO_07", "Leopard"},
            {"COMPONENT_PISTOL_MK2_CAMO_08", "Zebra"},
            {"COMPONENT_PISTOL_MK2_CAMO_09", "Geometric"},
            {"COMPONENT_PISTOL_MK2_CAMO_10", "Boom!"},
            {"COMPONENT_PISTOL_MK2_CAMO_IND_01","Patriotic"},
            {"COMPONENT_PISTOL_MK2_CAMO_SLIDE", "Digital Camo"},
            {"COMPONENT_PISTOL_MK2_CAMO_02_SLIDE","Digital Camo"},
            {"COMPONENT_PISTOL_MK2_CAMO_03_SLIDE","Digital Camo"},
            {"COMPONENT_PISTOL_MK2_CAMO_04_SLIDE","Digital Camo"},
            {"COMPONENT_PISTOL_MK2_CAMO_05_SLIDE","Digital Camo"},
            {"COMPONENT_PISTOL_MK2_CAMO_06_SLIDE","Digital Camo"},
            {"COMPONENT_PISTOL_MK2_CAMO_07_SLIDE","Digital Camo"},
            {"COMPONENT_PISTOL_MK2_CAMO_08_SLIDE","Digital Camo"},
            {"COMPONENT_PISTOL_MK2_CAMO_09_SLIDE","Digital Camo"},
            {"COMPONENT_PISTOL_MK2_CAMO_10_SLIDE","Digital Camo"},
            {"COMPONENT_PISTOL_MK2_CAMO_IND_01_SLIDE","Patriotic"},
            #endregion

            #region Vintage Pistol
            {"COMPONENT_VINTAGEPISTOL_CLIP_01","Default Clip"},
            {"COMPONENT_VINTAGEPISTOL_CLIP_02","Extended Clip"},
            #endregion

            #region Up-n-Atomizer
            {"COMPONENT_RAYPISTOL_VARMOD_XMAS18","Festive tint"},
            #endregion

            #region Ceramic Pistol
            {"COMPONENT_CERAMICPISTOL_CLIP_01","Default Clip"},
            {"COMPONENT_CERAMICPISTOL_CLIP_02","Extended Clip"},
            {"COMPONENT_CERAMICPISTOL_SUPP","Suppressor"},
            #endregion

            #region Micro SMG
            {"COMPONENT_MICROSMG_CLIP_01","Default Clip"},
            {"COMPONENT_MICROSMG_CLIP_02","Extended Clip"},
            {"COMPONENT_MICROSMG_VARMOD_LUXE","Yusuf Amir Luxury Finish"},
            #endregion

            #region SMG/Mini SMG
            {"COMPONENT_SMG_CLIP_01","Default Clip"},
            {"COMPONENT_SMG_CLIP_02","Extended Clip"},
            {"COMPONENT_SMG_CLIP_03","Drum Magazine"},
            {"COMPONENT_SMG_VARMOD_LUXE","Yusuf Amir Luxury Finish"},
            #endregion

            #region Assualt SMG
            {"COMPONENT_ASSAULTSMG_CLIP_01","Default Clip"},
            {"COMPONENT_ASSAULTSMG_CLIP_02","Extended Clip"},
            {"COMPONENT_ASSAULTSMG_VARMOD_LOWRIDER","Yusuf Amir Luxury Finish"},
            #endregion


            #region SMG MKII
            {"COMPONENT_SMG_MK2_CLIP_01","Default Clip"},
            {"COMPONENT_SMG_MK2_CLIP_02","Extended Clip"},
            {"COMPONENT_SMG_MK2_CLIP_TRACER","Tracer Rounds"},
            {"COMPONENT_SMG_MK2_CLIP_INCENDIARY", "Incendiary Rounds"},
            {"COMPONENT_SMG_MK2_CLIP_HOLLOWPOINT","Hollow Point Rounds"},
            {"COMPONENT_SMG_MK2_CLIP_FMJ","Full Metal Jacket Rounds"},
            {"COMPONENT_AT_SCOPE_SMALL_SMG_MK2","Medium Scope"},
            {"COMPONENT_AT_SB_BARREL_01","Default Barrel"},
            {"COMPONENT_AT_SB_BARREL_02","Heavy Barrel"},
            {"COMPONENT_SMG_MK2_CAMO","Digital Camo"},
            {"COMPONENT_SMG_MK2_CAMO_02","Brushstroke Camo"},
            {"COMPONENT_SMG_MK2_CAMO_03","Woodland Camo"},
            {"COMPONENT_SMG_MK2_CAMO_04","Skull"},
            {"COMPONENT_SMG_MK2_CAMO_05","Sessanta Nove"},
            {"COMPONENT_SMG_MK2_CAMO_06","Perseus"},
            {"COMPONENT_SMG_MK2_CAMO_07","Leopard"},
            {"COMPONENT_SMG_MK2_CAMO_08","Zebra"},
            {"COMPONENT_SMG_MK2_CAMO_09","Geometric"},
            {"COMPONENT_SMG_MK2_CAMO_10","Boom!"},
            {"COMPONENT_SMG_MK2_CAMO_IND_01","Patriotic"},
            #endregion

           #region Assualt SMG
            {"COMPONENT_MACHINEPISTOL_CLIP_01","Default Clip"},
            {"COMPONENT_MACHINEPISTOL_CLIP_02","Extended Clip"},
            {"COMPONENT_MACHINEPISTOL_CLIP_03","Drum Magazine"},
            #endregion

            #region Combat PDW
            {"COMPONENT_COMBATPDW_CLIP_01","Default Clip"},
            {"COMPONENT_COMBATPDW_CLIP_02","Extended Clip"},
            {"COMPONENT_COMBATPDW_CLIP_03","Drum Magazine"},
            #endregion

            #region Pump Shotgun
            {"COMPONENT_PUMPSHOTGUN_VARMOD_LOWRIDER","Yusuf Amir Luxury Finish"},
            #endregion

            #region Sawed-Off Shotgun
            {"COMPONENT_SAWNOFFSHOTGUN_VARMOD_LUXE","Gilded Gun Metal Finish"},
            #endregion

            #region Assault Shotgun
            {"COMPONENT_ASSAULTSHOTGUN_CLIP_01","Default Clip"},
            {"COMPONENT_ASSAULTSHOTGUN_CLIP_02","Extended Clip"},
            #endregion

            #region Pump Shotgun MLII
            {"COMPONENT_PUMPSHOTGUN_MK2_CLIP_01","Default Shells"},
            {"COMPONENT_PUMPSHOTGUN_MK2_CLIP_INCENDIARY","Dragon's Breath Shells"},
            {"COMPONENT_PUMPSHOTGUN_MK2_CLIP_ARMORPIERCING","Steel Buckshot Shells"},
            {"COMPONENT_PUMPSHOTGUN_MK2_CLIP_HOLLOWPOINT", "Flechette Shells"},
            {"COMPONENT_PUMPSHOTGUN_MK2_CLIP_EXPLOSIVE","Explosive Slugs"},
            {"COMPONENT_AT_SCOPE_SMALL_MK2","Medium Scope"},
            {"COMPONENT_PUMPSHOTGUN_MK2_CAMO","Digital Camo"},
            {"COMPONENT_PUMPSHOTGUN_MK2_CAMO_02","Brushstroke Camo"},
            {"COMPONENT_PUMPSHOTGUN_MK2_CAMO_03","Woodland Camo"},
            {"COMPONENT_PUMPSHOTGUN_MK2_CAMO_04","Skull"},
            {"COMPONENT_PUMPSHOTGUN_MK2_CAMO_05","Sessanta Nove"},
            {"COMPONENT_PUMPSHOTGUN_MK2_CAMO_06","Perseus"},
            {"COMPONENT_PUMPSHOTGUN_MK2_CAMO_07","Leopard"},
            {"COMPONENT_PUMPSHOTGUN_MK2_CAMO_08","Zebra"},
            {"COMPONENT_PUMPSHOTGUN_MK2_CAMO_09","Geometric"},
            {"COMPONENT_PUMPSHOTGUN_MK2_CAMO_10","Boom!"},
            {"COMPONENT_PUMPSHOTGUN_MK2_CAMO_IND_01","Patriotic"},
            #endregion

            #region Heavy Shotgun
            {"COMPONENT_HEAVYSHOTGUN_CLIP_01","Default Clip"},
            {"COMPONENT_HEAVYSHOTGUN_CLIP_02","Extended Clip"},
            {"COMPONENT_HEAVYSHOTGUN_CLIP_03","Drum Magazine"},
            #endregion

            #region Assault Rifle
            {"COMPONENT_ASSAULTRIFLE_CLIP_01","Default Clip"},
            {"COMPONENT_ASSAULTRIFLE_CLIP_02","Extended Clip"},
            {"COMPONENT_ASSAULTRIFLE_CLIP_03","Drum Magazine"},
            {"COMPONENT_ASSAULTRIFLE_VARMOD_LUXE","Yusuf Amir Luxury Finish"},
            #endregion

            #region Carbine Rifle
            {"COMPONENT_CARBINERIFLE_CLIP_01","Default Clip"},
            {"COMPONENT_CARBINERIFLE_CLIP_02","Extended Clip"},
            {"COMPONENT_CARBINERIFLE_CLIP_03","Box Magazine"},
            {"COMPONENT_CARBINERIFLE_VARMOD_LUXE","Yusuf Amir Luxury Finish"},
            #endregion

            #region Advanced Rifle
            {"COMPONENT_ADVANCEDRIFLE_CLIP_01","Default Clip"},
            {"COMPONENT_ADVANCEDRIFLE_CLIP_02","Extended Clip"},
            {"COMPONENT_ADVANCEDRIFLE_VARMOD_LUXE","Gilded Gun Metal Finish"},
            #endregion

            #region Special Carbine
            {"COMPONENT_SPECIALCARBINE_CLIP_01","Default Clip"},
            {"COMPONENT_SPECIALCARBINE_CLIP_02","Extended Clip"},
            {"COMPONENT_SPECIALCARBINE_CLIP_03","Drum Magazine"},
            {"COMPONENT_SPECIALCARBINE_VARMOD_LOWRIDER","Etched Gun Metal Finish"},
            #endregion

            #region Bullpup Rifle
            {"COMPONENT_BULLPUPRIFLE_CLIP_01","Default Clip"},
            {"COMPONENT_BULLPUPRIFLE_CLIP_02","Extended Clip"},
            {"COMPONENT_BULLPUPRIFLE_VARMOD_LOW","Gilded Gun Metal Finish"},
            #endregion

            #region Bullpup Rifle Mk II
            {"COMPONENT_BULLPUPRIFLE_MK2_CLIP_01","DefaultClip"},
            {"COMPONENT_BULLPUPRIFLE_MK2_CLIP_02","ExtendedClip"},
            {"COMPONENT_BULLPUPRIFLE_MK2_CLIP_TRACER","TracerRounds"},
            {"COMPONENT_BULLPUPRIFLE_MK2_CLIP_INCENDIARY","IncendiaryRounds"},
            {"COMPONENT_BULLPUPRIFLE_MK2_CLIP_ARMORPIERCING","ArmorPiercingRounds"},
            {"COMPONENT_BULLPUPRIFLE_MK2_CLIP_FMJ","FullMetalJacketRounds"},
            {"COMPONENT_AT_BP_BARREL_01","DefaultBarrel"},
            {"COMPONENT_AT_BP_BARREL_02","HeavyBarrel"},
            {"COMPONENT_BULLPUPRIFLE_MK2_CAMO","DigitalCamo"},
            {"COMPONENT_BULLPUPRIFLE_MK2_CAMO_02","BrushstrokeCamo"},
            {"COMPONENT_BULLPUPRIFLE_MK2_CAMO_03","WoodlandCamo"},
            {"COMPONENT_BULLPUPRIFLE_MK2_CAMO_04","Skull"},
            {"COMPONENT_BULLPUPRIFLE_MK2_CAMO_05","SessantaNove"},
            {"COMPONENT_BULLPUPRIFLE_MK2_CAMO_06","Perseus"},
            {"COMPONENT_BULLPUPRIFLE_MK2_CAMO_07","Leopard"},
            {"COMPONENT_BULLPUPRIFLE_MK2_CAMO_08","Zebra"},
            {"COMPONENT_BULLPUPRIFLE_MK2_CAMO_09","Geometric"},
            {"COMPONENT_BULLPUPRIFLE_MK2_CAMO_10","Boom!"},
            {"COMPONENT_BULLPUPRIFLE_MK2_CAMO_IND_01","Patriotic"},
            #endregion

            #region Special Carbine Mk II
            {"COMPONENT_SPECIALCARBINE_MK2_CLIP_01","Default Clip"},
            {"COMPONENT_SPECIALCARBINE_MK2_CLIP_02","Extended Clip"},
            {"COMPONENT_SPECIALCARBINE_MK2_CLIP_TRACER","Tracer Rounds"},
            {"COMPONENT_SPECIALCARBINE_MK2_CLIP_INCENDIARY","Incendiary Rounds"},
            {"COMPONENT_SPECIALCARBINE_MK2_CLIP_ARMORPIERCING", "Armor Piercing Rounds"},
            {"COMPONENT_SPECIALCARBINE_MK2_CLIP_FMJ","Full Metal Jacket Rounds"},
            {"COMPONENT_AT_SC_BARREL_01","Default Barrel"},
            {"COMPONENT_AT_SC_BARREL_02","Heavy Barrel"},
            {"COMPONENT_SPECIALCARBINE_MK2_CAMO","Digital Camo"},
            {"COMPONENT_SPECIALCARBINE_MK2_CAMO_02","Brushstroke Camo"},
            {"COMPONENT_SPECIALCARBINE_MK2_CAMO_03","Woodland Camo"},
            {"COMPONENT_SPECIALCARBINE_MK2_CAMO_04","Skull"},
            {"COMPONENT_SPECIALCARBINE_MK2_CAMO_05","Sessanta Nove"},
            {"COMPONENT_SPECIALCARBINE_MK2_CAMO_06","Perseus"},
            {"COMPONENT_SPECIALCARBINE_MK2_CAMO_07","Leopard"},
            {"COMPONENT_SPECIALCARBINE_MK2_CAMO_08","Zebra"},
            {"COMPONENT_SPECIALCARBINE_MK2_CAMO_09","Geometric"},
            {"COMPONENT_SPECIALCARBINE_MK2_CAMO_10","Boom!"},
            {"COMPONENT_SPECIALCARBINE_MK2_CAMO_IND_01","Patriotic"},
            #endregion

            #region Assault Rifle Mk II
            {"COMPONENT_ASSAULTRIFLE_MK2_CLIP_01","Default Clip"},
            {"COMPONENT_ASSAULTRIFLE_MK2_CLIP_02","Extended Clip"},
            {"COMPONENT_ASSAULTRIFLE_MK2_CLIP_TRACER","Tracer Rounds"},
            {"COMPONENT_ASSAULTRIFLE_MK2_CLIP_INCENDIARY","Incendiary Rounds"},
            {"COMPONENT_ASSAULTRIFLE_MK2_CLIP_ARMORPIERCING","Armor Piercing Rounds"},
            {"COMPONENT_ASSAULTRIFLE_MK2_CLIP_FMJ","Full Metal Jacket Rounds"},
            {"COMPONENT_AT_AR_BARREL_01","Default Barrel"},
            {"COMPONENT_AT_AR_BARREL_02","Heavy Barrel"},
            {"COMPONENT_ASSAULTRIFLE_MK2_CAMO","Digital Camo"},
            {"COMPONENT_ASSAULTRIFLE_MK2_CAMO_02","Brushstroke Camo"},
            {"COMPONENT_ASSAULTRIFLE_MK2_CAMO_03","Woodland Camo"},
            {"COMPONENT_ASSAULTRIFLE_MK2_CAMO_04","Skull"},
            {"COMPONENT_ASSAULTRIFLE_MK2_CAMO_05","Sessanta Nove"},
            {"COMPONENT_ASSAULTRIFLE_MK2_CAMO_06","Perseus"},
            {"COMPONENT_ASSAULTRIFLE_MK2_CAMO_07","Leopard"},
            {"COMPONENT_ASSAULTRIFLE_MK2_CAMO_08","Zebra"},
            {"COMPONENT_ASSAULTRIFLE_MK2_CAMO_09","Geometric"},
            {"COMPONENT_ASSAULTRIFLE_MK2_CAMO_10","Boom!"},
            {"COMPONENT_ASSAULTRIFLE_MK2_CAMO_IND_01","Patriotic"},
            #endregion

            #region Carbine Rifle Mk II
            {"COMPONENT_CARBINERIFLE_MK2_CLIP_01","Default Clip"},
            {"COMPONENT_CARBINERIFLE_MK2_CLIP_02","Extended Clip"},
            {"COMPONENT_CARBINERIFLE_MK2_CLIP_TRACER","Tracer Rounds"},
            {"COMPONENT_CARBINERIFLE_MK2_CLIP_INCENDIARY","Incendiary Rounds"},
            {"COMPONENT_CARBINERIFLE_MK2_CLIP_ARMORPIERCING","Armor Piercing Rounds"},
            {"COMPONENT_CARBINERIFLE_MK2_CLIP_FMJ","Full Metal Jacket Rounds"},
            {"COMPONENT_AT_CR_BARREL_01","Default Barrel"},
            {"COMPONENT_AT_CR_BARREL_02","Heavy Barrel"},
            {"COMPONENT_CARBINERIFLE_MK2_CAMO","Digital Camo"},
            {"COMPONENT_CARBINERIFLE_MK2_CAMO_02","Brushstroke Camo"},
            {"COMPONENT_CARBINERIFLE_MK2_CAMO_03","Woodland Camo"},
            {"COMPONENT_CARBINERIFLE_MK2_CAMO_04","Skull"},
            {"COMPONENT_CARBINERIFLE_MK2_CAMO_05","Sessanta Nove"},
            {"COMPONENT_CARBINERIFLE_MK2_CAMO_06","Perseus"},
            {"COMPONENT_CARBINERIFLE_MK2_CAMO_07","Leopard"},
            {"COMPONENT_CARBINERIFLE_MK2_CAMO_08","Zebra"},
            {"COMPONENT_CARBINERIFLE_MK2_CAMO_09","Geometric"},
            {"COMPONENT_CARBINERIFLE_MK2_CAMO_10","Boom!"},
            {"COMPONENT_CARBINERIFLE_MK2_CAMO_IND_01","Patriotic"},
            #endregion

            #region Compact Rifle 
            {"COMPONENT_COMPACTRIFLE_CLIP_01","Default Clip"},
            {"COMPONENT_COMPACTRIFLE_CLIP_02","Extended Clip"},
            {"COMPONENT_COMPACTRIFLE_CLIP_03","Drum Magazine"},
            #endregion

            #region MG
            {"COMPONENT_MG_CLIP_01","Default Clip"},
            {"COMPONENT_MG_CLIP_02","Extended Clip"},
            {"COMPONENT_MG_VARMOD_LOWRIDER","Etched Gun Metal Finish"},
            
            #endregion

            #region Combat MG
            {"COMPONENT_COMBATMG_CLIP_01","Default Clip"},
            {"COMPONENT_COMBATMG_CLIP_02","Extended Clip"},
            {"COMPONENT_COMBATMG_VARMOD_LOWRIDER","Yusuf Amir Luxury Finish"},
            #endregion

            #region Combat MG Mk II
            {"COMPONENT_COMBATMG_MK2_CLIP_01","Default Clip"},
            {"COMPONENT_COMBATMG_MK2_CLIP_02","Extended Clip"},
            {"COMPONENT_COMBATMG_MK2_CLIP_TRACER","Tracer Rounds"},
            {"COMPONENT_COMBATMG_MK2_CLIP_INCENDIARY","Incendiary Rounds"},
            {"COMPONENT_COMBATMG_MK2_CLIP_ARMORPIERCING","Armor Piercing Rounds"},
            {"COMPONENT_COMBATMG_MK2_CLIP_FMJ","Full Metal Jacket Rounds"},
            {"COMPONENT_AT_MG_BARREL_01","Default Barrel"},
            {"COMPONENT_AT_MG_BARREL_02","Heavy Barrel"},
            {"COMPONENT_COMBATMG_MK2_CAMO","Digital Camo"},
            {"COMPONENT_COMBATMG_MK2_CAMO_02","Brushstroke Camo"},
            {"COMPONENT_COMBATMG_MK2_CAMO_03","Woodland Camo"},
            {"COMPONENT_COMBATMG_MK2_CAMO_04","Skull"},
            {"COMPONENT_COMBATMG_MK2_CAMO_05","Sessanta Nove"},
            {"COMPONENT_COMBATMG_MK2_CAMO_06","Perseus"},
            {"COMPONENT_COMBATMG_MK2_CAMO_07","Leopard"},
            {"COMPONENT_COMBATMG_MK2_CAMO_08","Zebra"},
            {"COMPONENT_COMBATMG_MK2_CAMO_09","Geometric"},
            {"COMPONENT_COMBATMG_MK2_CAMO_10","Boom!"},
            {"COMPONENT_COMBATMG_MK2_CAMO_IND_01","Patriotic"},
            #endregion

            #region Gusenberg Sweeper
            {"COMPONENT_GUSENBERG_CLIP_01","Default Clip"},
            {"COMPONENT_GUSENBERG_CLIP_02","Extended Clip"},
            #endregion

            #region Sniper Rifle
            {"COMPONENT_SNIPERRIFLE_CLIP_01","Default Clip"},
            {"COMPONENT_SNIPERRIFLE_VARMOD_LUXE","Etched Wood Grip Finish"},
            #endregion

            #region Heavy Sniper
            {"COMPONENT_HEAVYSNIPER_CLIP_01","Default Clip"},
            #endregion

            #region Marksman Rifle Mk II
            {"COMPONENT_MARKSMANRIFLE_MK2_CLIP_01","DefaultClip"},
            {"COMPONENT_MARKSMANRIFLE_MK2_CLIP_02","ExtendedClip"},
            {"COMPONENT_MARKSMANRIFLE_MK2_CLIP_TRACER","TracerRounds"},
            {"COMPONENT_MARKSMANRIFLE_MK2_CLIP_INCENDIARY","IncendiaryRounds"},
            {"COMPONENT_MARKSMANRIFLE_MK2_CLIP_ARMORPIERCING","ArmorPiercingRounds"},
            {"COMPONENT_MARKSMANRIFLE_MK2_CLIP_FMJ","FullMetalJacketRounds"},
            {"COMPONENT_AT_MRFL_BARREL_01","DefaultBarrel"},
            {"COMPONENT_AT_MRFL_BARREL_02","HeavyBarrel"},
            {"COMPONENT_MARKSMANRIFLE_MK2_CAMO","DigitalCamo"},
            {"COMPONENT_MARKSMANRIFLE_MK2_CAMO_02","BrushstrokeCamo"},
            {"COMPONENT_MARKSMANRIFLE_MK2_CAMO_03","WoodlandCamo"},
            {"COMPONENT_MARKSMANRIFLE_MK2_CAMO_04","Skull"},
            {"COMPONENT_MARKSMANRIFLE_MK2_CAMO_05","SessantaNove"},
            {"COMPONENT_MARKSMANRIFLE_MK2_CAMO_06","Perseus"},
            {"COMPONENT_MARKSMANRIFLE_MK2_CAMO_07","Leopard"},
            {"COMPONENT_MARKSMANRIFLE_MK2_CAMO_08","Zebra"},
            {"COMPONENT_MARKSMANRIFLE_MK2_CAMO_09","Geometric"},
            {"COMPONENT_MARKSMANRIFLE_MK2_CAMO_10","Boom!"},
            {"COMPONENT_MARKSMANRIFLE_MK2_CAMO_IND_01","Boom!"},
            #endregion

            #region Heavy Sniper Mk II
            {"COMPONENT_HEAVYSNIPER_MK2_CLIP_01","Default Clip"},
            {"COMPONENT_HEAVYSNIPER_MK2_CLIP_02","Extended Clip"},
            {"COMPONENT_HEAVYSNIPER_MK2_CLIP_INCENDIARY","Incendiary Rounds"},
            {"COMPONENT_HEAVYSNIPER_MK2_CLIP_ARMORPIERCING","Armor Piercing Rounds"},
            {"COMPONENT_HEAVYSNIPER_MK2_CLIP_FMJ","Full Metal Jacket Rounds"},
            {"COMPONENT_HEAVYSNIPER_MK2_CLIP_EXPLOSIVE", "Explosive Rounds"},
            {"COMPONENT_AT_SCOPE_NV", "Night Vision Scope"},
            {"COMPONENT_AT_SCOPE_THERMAL","Thermal Scope"},
            {"COMPONENT_AT_SR_BARREL_01","Default Barrel"},
            {"COMPONENT_AT_SR_BARREL_02","Heavy Barrel"},
            {"COMPONENT_HEAVYSNIPER_MK2_CAMO","Digital Camo"},
            {"COMPONENT_HEAVYSNIPER_MK2_CAMO_02","Brushstroke Camo"},
            {"COMPONENT_HEAVYSNIPER_MK2_CAMO_03","Woodland Camo"},
            {"COMPONENT_HEAVYSNIPER_MK2_CAMO_04","Skull"},
            {"COMPONENT_HEAVYSNIPER_MK2_CAMO_05","Sessanta Nove"},
            {"COMPONENT_HEAVYSNIPER_MK2_CAMO_06","Perseus"},
            {"COMPONENT_HEAVYSNIPER_MK2_CAMO_07","Leopard"},
            {"COMPONENT_HEAVYSNIPER_MK2_CAMO_08","Zebra"},
            {"COMPONENT_HEAVYSNIPER_MK2_CAMO_09","Geometric"},
            {"COMPONENT_HEAVYSNIPER_MK2_CAMO_10","Boom!"},
            {"COMPONENT_HEAVYSNIPER_MK2_CAMO_IND_01", "Patriotic"},
            #endregion

            #region Marksman Rifle
            {"COMPONENT_MARKSMANRIFLE_CLIP_01","Default Clip"},
            {"COMPONENT_MARKSMANRIFLE_CLIP_02","Extended Clip"},
            {"COMPONENT_MARKSMANRIFLE_VARMOD_LUXE","Yusuf Amir Luxury Finish"},
            #endregion

            #region Grenade Launcher
            {"COMPONENT_GRENADELAUNCHER_CLIP_01","Default Clip"},
            #endregion*/
        };

        Dictionary<string, int> weaponTintIndexDict = new Dictionary<string, int>()
    {
        {"Normal", 0}, {"Green", 1}, {"Gold", 2}, {"Pink", 3}, {"Army", 4}, {"LSPD", 5},
        {"Orange", 6}, {"Platinum", 7}
    };


        //Exclude 'Unarmed from Menu' -- future proofed 
        List<WeaponHash> weaponsToExclude = new List<WeaponHash>()
        {
            WeaponHash.Unarmed
        };
        //Exclude weapons that cannot have components
        List<WeaponHash> weaponsNoComponentList = new List<WeaponHash>()
        {
            WeaponHash.Bat, WeaponHash.BZGas, WeaponHash.Crowbar,
            WeaponHash.Dagger, WeaponHash.FireExtinguisher, WeaponHash.Firework,
            WeaponHash.GolfClub, WeaponHash.Grenade, WeaponHash.Hammer,
            WeaponHash.Hatchet, WeaponHash.HomingLauncher, WeaponHash.Knife,
            WeaponHash.Minigun, WeaponHash.Molotov, WeaponHash.Musket,
            WeaponHash.Nightstick, WeaponHash.PetrolCan, WeaponHash.ProximityMine,
            WeaponHash.Railgun, WeaponHash.RPG, WeaponHash.SawnOffShotgun,
            WeaponHash.SmokeGrenade, WeaponHash.Snowball, WeaponHash.StickyBomb,
            WeaponHash.StunGun, WeaponHash.Unarmed, 
        };
        //Exclude weapons from Fill & empty Ammo Option
        List<WeaponHash> weaponsNoAmmo = new List<WeaponHash>()
        {
            WeaponHash.Bat, WeaponHash.Crowbar,
            WeaponHash.Dagger, WeaponHash.FireExtinguisher, 
            WeaponHash.Firework,WeaponHash.GolfClub, WeaponHash.Hammer, 
            WeaponHash.Hatchet,  WeaponHash.Knife, WeaponHash.Ball,
            WeaponHash.Nightstick, WeaponHash.PetrolCan, WeaponHash.BattleAxe,
            WeaponHash.StunGun, WeaponHash.Unarmed, WeaponHash.KnuckleDuster,
            WeaponHash.Bottle, WeaponHash.Machete, WeaponHash.PoolCue, 
            WeaponHash.Flashlight, WeaponHash.SwitchBlade, WeaponHash.Wrench,
            WeaponHash.UpNAtomizer, WeaponHash.StunGun
        };
        //Exclude weapons from Tint option
        List<WeaponHash> weaponsNoTint = new List<WeaponHash>()
        {
            WeaponHash.Bat, WeaponHash.Crowbar,
            WeaponHash.Dagger, WeaponHash.FireExtinguisher,
            WeaponHash.Firework,WeaponHash.GolfClub, WeaponHash.Hammer,
            WeaponHash.Hatchet,  WeaponHash.Knife, WeaponHash.Ball,
            WeaponHash.Nightstick, WeaponHash.PetrolCan, WeaponHash.BattleAxe,
            WeaponHash.StunGun, WeaponHash.Unarmed, 
            WeaponHash.Bottle, WeaponHash.Machete, WeaponHash.PoolCue,
            WeaponHash.Flashlight, WeaponHash.SwitchBlade, WeaponHash.Wrench,
            WeaponHash.Grenade, WeaponHash.BZGas, WeaponHash.Molotov, WeaponHash.StickyBomb,
            WeaponHash.ProximityMine, WeaponHash.Snowball, WeaponHash.PipeBomb, WeaponHash.Ball,
            WeaponHash.SmokeGrenade, WeaponHash.Flare, WeaponHash.KnuckleDuster
        };

        Dictionary<string, UInt32> weaponCategoriesDict = new Dictionary<string, UInt32>()
        {
            {"Melee", 2685387236}, {"Handguns", 416676503}, {"Submachine Guns", 3337201093}, {"Shotguns", 860033945}, {"Assault Rifles", 970310034},
            {"Light Machine Guns", 1159398588}, {"Sniper Rifles",3082541095}, {"Heavy Weapons", 2725924767}, {"Throwables", 1548507267},
            {"Miscellaneous", 4257178988}
        };



        foreach (KeyValuePair<string, UInt32> weaponType in weaponCategoriesDict)
        {
            UIMenu weaponCategories = modMenuPool.AddSubMenu(weaponSelectionMenu, weaponType.Key);
            
            WeaponHash[] allWeaponHashes = (WeaponHash[])Enum.GetValues(typeof(WeaponHash));

            foreach (WeaponHash weapon in allWeaponHashes)
            {
                if(!weaponsToExclude.Contains(weapon))
                {
                    uint weaponGroup = Function.Call<uint>((Hash)0xC3287EE3050FB74C, (uint)weapon);
                    bool hasPedGotWeapon = Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON, Game.Player.Character, (int)weapon, false);

                    if (weaponGroup == weaponType.Value)
                    {
                        var convertWeaponName = weapon.ToString();
                        weaponName = modMenuPool.AddSubMenu(weaponCategories, convertWeaponName);

                        UIMenuItem equipWeapon = new UIMenuItem("Equip");
                        equipWeapon.Activated += (sender, args) =>
                        {
                            WeaponFunctions.EquipWeapon(weapon);
                        };
                        weaponName.AddItem(equipWeapon);

                        UIMenuItem dropWeapon = new UIMenuItem("Drop Weapon");
                        dropWeapon.Activated += (sender, args) =>
                        {
                            WeaponFunctions.dropWeapon(weapon);
                        };
                        weaponName.AddItem(dropWeapon);

                        if (!weaponsNoAmmo.Contains(weapon))
                        {
                            UIMenuItem fillAmmo = new UIMenuItem("Fill Ammo");
                            fillAmmo.Activated += (sender, args) =>
                            {
                                WeaponFunctions.FillAmmo(weapon);
                            };
                            weaponName.AddItem(fillAmmo);

                            UIMenuItem emptyAmmo = new UIMenuItem("Empty Ammo");
                            emptyAmmo.Activated += (sender, args) =>
                            {
                                WeaponFunctions.EmptyAmmo(weapon);
                            };
                            weaponName.AddItem(emptyAmmo);
                        }
                    }


                    if (!weaponsNoComponentList.Contains(weapon) && weaponGroup == weaponType.Value)
                    {
                        weaponAttachmentMenu = modMenuPool.AddSubMenu(weaponName, "Weapon Attachments");

                        foreach (KeyValuePair<string, string> weaponComponent in weaponComponentItems)
                        {
                            int weaponComponentHash = Function.Call<int>(Hash.GET_HASH_KEY, weaponComponent.Key);
                            bool canWeaponHaveComponent = Function.Call<bool>(Hash._CAN_WEAPON_HAVE_COMPONENT, (int)weapon, weaponComponentHash);

                            if (canWeaponHaveComponent)
                            {
                                UIMenuItem weaponComponentName = new UIMenuItem(weaponComponent.Value);
                                weaponComponentName.Activated += (sender, args) => WeaponFunctions.ChangeWeaponComponent(weapon, weaponComponent);
                                weaponAttachmentMenu.AddItem(weaponComponentName);

                            }
                        }

                        UIMenu weaponTint;
                        weaponTint = modMenuPool.AddSubMenu(weaponName, "Weapon Tint");

                        foreach (KeyValuePair<string, int> tintIndex in weaponTintIndexDict)
                        {
                            if (!weaponsNoTint.Contains(weapon))
                            {
                                UIMenuItem tintType = new UIMenuItem(tintIndex.Key);
                                tintType.Activated += (sender, args) => WeaponFunctions.ChangeWeaponTint(weapon, tintIndex.Value);
                                weaponTint.AddItem(tintType);
                            }
                        }
                    }
                }
            }
        }

    }

    #endregion
}