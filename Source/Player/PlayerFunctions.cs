using System;
using System.Collections.Generic;
using GTA;
using GTA.Native;
using System.Globalization;

partial class PlayerFunctions : Script
{
    public static int WantedLevel { get { return Game.Player.WantedLevel; } set { Game.Player.WantedLevel = value; } }
    public static bool IsPlayerNeverWanted { get; set; }
    public static bool IsPlayerInvincible { get; set; }
    public static bool CanPlayerSuperJump { get; set; }
    public static bool CanPlayerExplosiveMelee { get; set; }
    public static bool CanPlayerFastRun { get; set; }
    public static bool CanPlayerFastSwim { get; set; }
    public static bool IsPlayerNoiseless { get; set; }
    public static bool HasPlayerUnlimitedStamina { get; set; }
    public static bool HasPlayerUnlimitedBreath { get; set; }
    public static float BreathValue = Function.Call<float>(Hash.GET_PLAYER_UNDERWATER_TIME_REMAINING, Game.Player);
    public static bool HasPlayerUnlimitedAbility { get; set; }
    public static bool IsAbilityMeterFull { get { return Function.Call<bool>(Hash.IS_SPECIAL_ABILITY_METER_FULL, Game.Player); } }
    private static bool currentMission = GTA.Native.Function.Call<bool>(GTA.Native.Hash.GET_MISSION_FLAG, Game.Player);


    public PlayerFunctions()
    {
        Tick += OnTick;
        Game.Player.Character.IsInvincible = false;
    }

    private void OnTick(object sender, EventArgs e)
    {
        if (IsPlayerNeverWanted)
        {
            WantedLevel = 0;
        }

        if (IsPlayerInvincible)
            Game.Player.Character.IsInvincible = true;

        if (CanPlayerSuperJump)
            Function.Call(Hash.SET_SUPER_JUMP_THIS_FRAME, Game.Player);

        if (CanPlayerExplosiveMelee)
            Function.Call(Hash.SET_EXPLOSIVE_MELEE_THIS_FRAME, Game.Player);

        if (IsPlayerNoiseless)
            Function.Call(Hash.SET_PLAYER_NOISE_MULTIPLIER, Game.Player, 0.0f);

        if (HasPlayerUnlimitedStamina)
            Function.Call(Hash.RESET_PLAYER_STAMINA, Game.Player);

        if (HasPlayerUnlimitedBreath)
        {
            if (Game.Player.Character.IsSwimmingUnderWater)
            {
                Function.Call(Hash.SET_PED_MAX_TIME_UNDERWATER, Game.Player.Character, BreathValue++);
            }
        }

        if (HasPlayerUnlimitedAbility)
        {
            if (!IsAbilityMeterFull)
            {
                Function.Call(Hash._RECHARGE_SPECIAL_ABILITY, Game.Player, true);
            }
        }

        if (Game.Player.IsDead || currentMission || Function.Call<bool>(Hash.IS_PLAYER_BEING_ARRESTED, Game.Player, false))
        {
         
            PlayerFunctions.resetPlayerModel();
            
        }
    }

    //-----------PLAYER MENU------------------
    internal static void fixPlayer()
    {
        Game.Player.Character.Health = Game.Player.Character.MaxHealth;
        Game.Player.Character.Armor = Function.Call<int>(Hash.GET_PLAYER_MAX_ARMOUR, Game.Player);
        Function.Call(Hash._RECHARGE_SPECIAL_ABILITY, Game.Player, true);
        Function.Call(Hash.RESET_PLAYER_STAMINA);

        MainMenu.DisplayMessage("Health, Armor, Stamina, and Special Abilities Has Been Restored");
    }

    internal static void neverWanted()
    {
        IsPlayerNeverWanted = !IsPlayerNeverWanted;

        MainMenu.DisplayMessage("Never Wanted", IsPlayerNeverWanted);
    }

    internal static void Invincibility()
    {
        IsPlayerInvincible = !IsPlayerInvincible;

        if (!IsPlayerInvincible)
            Game.Player.Character.IsInvincible = false;

        MainMenu.DisplayMessage("Invincibility", IsPlayerInvincible);
    }

    internal static void Invisibility()
    {
        Ped Player = Game.Player.Character;


        if (Player.Exists() && Player.IsAlive)
        {
      
            Player.IsVisible = !Player.IsVisible;

        }
        else
        {
            Player.IsVisible = !Player.IsVisible;
        }
    }

    internal static void SuperJump()
    {
        CanPlayerSuperJump = !CanPlayerSuperJump;

        MainMenu.DisplayMessage("Super Jump", CanPlayerSuperJump);
    }

    internal static void FastRun()
    {
        CanPlayerFastRun = !CanPlayerFastRun;

        if (CanPlayerFastRun)
            Function.Call(Hash._SET_MOVE_SPEED_MULTIPLIER, Game.Player, 1.49f);
        else
            Function.Call(Hash._SET_MOVE_SPEED_MULTIPLIER, Game.Player, 1.0f);

        MainMenu.DisplayMessage("Fast Run", CanPlayerFastRun);
    }

    internal static void FastSwim()
    {
        CanPlayerFastSwim = !CanPlayerFastSwim;

        if (CanPlayerFastSwim)
            Function.Call(Hash._SET_SWIM_SPEED_MULTIPLIER, Game.Player, 1.49f);
        else
            Function.Call(Hash._SET_SWIM_SPEED_MULTIPLIER, Game.Player, 1.0f);

        MainMenu.DisplayMessage("Fast Swim", CanPlayerFastSwim);
    }

    internal static void NoNoise()
    {
        IsPlayerNoiseless = !IsPlayerNoiseless;

        MainMenu.DisplayMessage("No Noise", IsPlayerNoiseless);
    }

    internal static void UnlimitedStamina()
    {
        HasPlayerUnlimitedStamina = !HasPlayerUnlimitedStamina;

        MainMenu.DisplayMessage("Unlimited Stamina", HasPlayerUnlimitedStamina);
    }

    internal static void UnlimitedBreath()
    {
        HasPlayerUnlimitedBreath = !HasPlayerUnlimitedBreath;

        if (HasPlayerUnlimitedBreath)
        {
            unsafe
            {
                float originalBreathValue = BreathValue;
                Function.Call(Hash.SET_PED_MAX_TIME_UNDERWATER, Game.Player.Character, &originalBreathValue);
            }
        }

        MainMenu.DisplayMessage("Unlimited Breath", HasPlayerUnlimitedBreath);
    }

    internal static void UnlimitedAbility()
    {
        HasPlayerUnlimitedAbility = !HasPlayerUnlimitedAbility;

        MainMenu.DisplayMessage("Unlimited Special Ability", HasPlayerUnlimitedAbility);
    }

    #region Set Money
    internal static void setMoney()
    {
        string userCashInput = Game.GetUserInput(12);
        int result;
        bool success = int.TryParse(userCashInput, out result);

        if (success)
        {
            Game.Player.Money = result;
            MainMenu.DisplayMessage(string.Format(CultureInfo.GetCultureInfo(1033), "{0:C} Has Been Transfered to Your Account", result));
        }
        else if (userCashInput != string.Empty)
        {
            MainMenu.DisplayMessage("Please enter a valid amount");
            return;
        }
    }

    internal static void AddMoney()
    {
        Game.Player.Money += 1000000;
        MainMenu.DisplayMessage(string.Format(CultureInfo.GetCultureInfo(1033), "{0:C} Has Been Transfered to Your Account", 1000000));
    }
    #endregion

    #region Change Model 
    internal static void ChangePedModel(KeyValuePair<UInt32, string> model)
    {
        var characterModel = new Model (model.Value);
        characterModel.Request(500);
        if (characterModel.IsInCdImage && characterModel.IsValid)
        {
            while (!characterModel.IsLoaded) 
            Script.Wait(100);

            Game.Player.ChangeModel(characterModel);
            Function.Call(Hash.SET_PED_DEFAULT_COMPONENT_VARIATION, Game.Player.Character.Handle);
        };

        characterModel.MarkAsNoLongerNeeded();
    }

    internal static  void resetPlayerModel()
    {
        bool playerWasDead = false;
        bool playerWasArrested = false;
        PedHash savedPlayerModelHash = PedHash.Franklin;
        Ped player = Game.Player.Character;

        if ((PedHash)player.Model != savedPlayerModelHash)
        {
            Vehicle currentVehicle = null;
            if (player.IsInVehicle())
            {
                currentVehicle = player.CurrentVehicle;
            }

            if (player.IsDead || Function.Call<bool>(Hash.IS_PLAYER_BEING_ARRESTED, Game.Player, false))
            {
                #region Create remplacement ped
                Wait(10000);
                Ped replacementPed = Function.Call<Ped>(Hash.CLONE_PED, Game.Player.Character, Function.Call<int>(Hash.GET_ENTITY_HEADING, Function.Call<int>(Hash.PLAYER_PED_ID)), false, true);


                if (player.IsDead)
                {
                    playerWasDead = true;
                    replacementPed.Kill();
                    
                }
                else
                {
                    playerWasArrested = true;
                    replacementPed.Task.HandsUp(10000);
                }

                replacementPed.MarkAsNoLongerNeeded();
                #endregion
            }

            #region Change player model with saved PedHash
            var characterModel = new Model(savedPlayerModelHash);
            characterModel.Request(1000);

            if (characterModel.IsInCdImage && characterModel.IsValid)
            {
                while (!characterModel.IsLoaded) Script.Wait(100);

                Function.Call(Hash.SET_PLAYER_MODEL, Game.Player, characterModel.Hash);
                Function.Call(Hash.SET_PED_DEFAULT_COMPONENT_VARIATION, Game.Player.Character.Handle);
            }

            characterModel.MarkAsNoLongerNeeded();
            #endregion

            player = Game.Player.Character;
            if (currentVehicle != null)
            {
                player.SetIntoVehicle(currentVehicle, VehicleSeat.Driver);
            }

            if ((playerWasDead || playerWasArrested) && currentMission)
            {
                #region Hide real player and wait for game recovery
                player.IsVisible = false;
                player.IsInvincible = true;
                player.Task.StandStill(-1);

                //As long as we load the game, we keep the GTA script waiting
                while (!Function.Call<bool>(Hash.IS_PLAYER_PLAYING, Game.Player))
                {
                    Script.Wait(100);
                }

                player.IsVisible = true;
                player.IsInvincible = false;
                #endregion

                while (!Function.Call<bool>(Hash.IS_PLAYER_CONTROL_ON, Game.Player))
                {
                    Script.Wait(100);
                }
            }
        }
    }
    #endregion

}
