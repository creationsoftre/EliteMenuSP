using System;
using GTA;
using GTA.Native;
using NativeUI;


partial class MainMenu
{
    
    private void ElitevehicleModCategoryListMenu()
    {

        Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
        Function.Call(Hash.SET_VEHICLE_MOD_KIT, currentVehicle, 0);

        foreach (VehicleMod vehicleMod in Enum.GetValues(typeof(VehicleMod)))
        {
            int vehicleModCount = Function.Call<int>(Hash.GET_NUM_VEHICLE_MODS, currentVehicle, (int)vehicleMod);

            //if (vehicleModCount != 0)
            //{
                if (vehicleMod != VehicleMod.BackWheels && vehicleMod != VehicleMod.FrontWheels)
                {
                    UIMenuItem ModCategory = new UIMenuItem(vehicleMod.ToString());
                    //buttonModCategory.Activated += (sender, args) => ElitevehicleModCategoryListMenu(currentVehicle);
                    vehicleModMenu.AddItem(ModCategory);

                }
            //}
        }


        UIMenuItem Respray = new UIMenuItem("Respray");
        vehicleModMenu.AddItem(Respray);

        UIMenuItem Lights = new UIMenuItem("Lights");
        vehicleModMenu.AddItem(Lights);

        UIMenuItem Plates = new UIMenuItem("Plates");
        vehicleModMenu.AddItem(Plates);

        UIMenuItem Windows = new UIMenuItem("Windows");
        vehicleModMenu.AddItem(Windows);

        UIMenuItem Wheels = new UIMenuItem("Wheels");
        vehicleModMenu.AddItem(Wheels);

        vehicleModMenu.OnItemSelect += (sender, item, index) =>
        {
            //EliteVehicleModWheelsMenu(currentVehicle);
        };

        UIMenuItem Turbo = new UIMenuCheckboxItem("Turbo", false);
        vehicleModMenu.AddItem(Turbo);

    }
}

