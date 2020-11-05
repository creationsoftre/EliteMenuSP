using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GTA;
using GTA.Native;


class CommonFunctions : Script
{
    public static Vehicle GetVehicle(bool lastVehicle = false)
    {
        if (lastVehicle)
        {
            return Game.Player.Character.LastVehicle;
        }
        else
        {
            if (Game.Player.Character.IsInVehicle())
            {
                return Game.Player.Character.CurrentVehicle;
            }
        }
        return null;
    }

    #region Get Localized Label Text
    /// <summary>
    /// Get the localized name from a text label (for classes that don't have BaseScript)
    /// </summary>
    /// <param name="label"></param>
    /// <returns></returns>
    public static string GetLabelText(string label) => Function.Call<string>(Hash._GET_LABEL_TEXT, label);
    #endregion

    #region Get Localized Label Mod Text
    /// <summary>
    /// Get the localized name from a Mod text label (for classes that don't have BaseScript)
    /// </summary>
    /// <param name="label"></param>
    /// <returns></returns>
    public static string GetModLabelText(Vehicle vehicle, int modType, int modValue) => Function.Call<string>(Hash.GET_MOD_TEXT_LABEL, vehicle, modType, modValue);
    #endregion




}
