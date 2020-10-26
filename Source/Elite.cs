using NativeUI;

partial class MainMenu 
{
    public static UIMenu mainMenu;
    public MenuPool modMenuPool;

    private void EliteMainMenu()
    {
        
        modMenuPool = new MenuPool();
        mainMenu = new UIMenu("Elite Mod Menu", "Made ~b~By Creationsoftre v1.0 ");
        mainMenu.Title.Font = GTA.Font.ChaletComprimeCologne;
        mainMenu.Subtitle.Font = GTA.Font.Pricedown;
        modMenuPool.Add(mainMenu);

        //Player Menu
        ElitePlayerMenu();

        //Teleport 
        EliteTeleportMenu();

        // weaponsMenu
        EliteWeaponsMenu();
        WeaponSelectionMenu();

        //Weather Menu
        WeatherMenu();

        //Vehicle Menu
        EliteVehicleMenu();

    }
}
