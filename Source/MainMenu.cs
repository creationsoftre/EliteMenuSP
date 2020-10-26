using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using GTA;
using GTA.Native;
using GTA.Math;
using NativeUI;
using System.Collections;

partial class MainMenu : Script
{
    public static Entity GetEntity
    {
        get
        {
            Ped playerPed = Game.Player.Character;
            Entity entity = playerPed;
            if (playerPed.IsInVehicle())
                entity = playerPed.CurrentVehicle;

            return entity;
        }
    }

    public MainMenu()
    {
        EliteMainMenu();

        Tick += onTick;
        KeyDown += onKeyDown;
    }

    void onTick(object sender, EventArgs e)
    {
        if (modMenuPool != null)
        {
            modMenuPool.ProcessMenus();
        }
    }

    void onKeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F10 && !modMenuPool.IsAnyMenuOpen())
        {
            mainMenu.Visible = !mainMenu.Visible;
        }

        //Display Cordinates when J is selected 

        if (e.KeyCode == Keys.J)
        {
            UI.Notify("POS " + Game.Player.Character.Position);
        }
    }



    //Functions
    public static void DisplayMessage(string msg, bool state)
    {
        string stateMsg;
        if (state)
            stateMsg = " ~g~Activated";
        else
            stateMsg = " ~r~Deactivated";

        UI.Notify(msg + ":" + stateMsg);
    }

    public static void DisplayMessage(string msg)
    {
        UI.Notify(msg);
    }

}
