using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTA;
using GTA.Native;
using GTA.Math;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;
using NativeUI;
using NativeUI.PauseMenu;
using GTA.NaturalMotion;
using System.Data.SqlTypes;

partial class MainMenu : Script
{
    public UIMenu playerMenu;
    public UIMenu moneyMenu;
    public UIMenu teleportMenu;


    bool godModeOn = false;
    bool neverWantedOn = false;

    private void ElitePlayerMenu()
    {
        playerMenu = modMenuPool.AddSubMenu(mainMenu, "Player");

        moneyMenu = modMenuPool.AddSubMenu(playerMenu, "Money");

        teleportMenu = modMenuPool.AddSubMenu(playerMenu, "Teleport");

        //int playerMoney = Game.Player.Money;

        //Money Mod Menu
        UIMenuItem add10k = new UIMenuItem("Add: ~g~10k");
        UIMenuItem add50k = new UIMenuItem("Add: ~g~50k");
        UIMenuItem add100k = new UIMenuItem("Add: ~g~100k");
        UIMenuItem add500k = new UIMenuItem("Add: ~g~500k");
        UIMenuItem add1million = new UIMenuItem("Add: ~g~1.000.000");
        UIMenuItem add5million = new UIMenuItem("Add: ~g~5.000.000");
        UIMenuItem add20million = new UIMenuItem("Add: ~g~20.000.000");
        UIMenuItem add100million = new UIMenuItem("Add: ~g~100.000.000");
        UIMenuItem add1billion = new UIMenuItem("Add: ~g~1.000.000.000");

        moneyMenu.AddItem(add10k);
        moneyMenu.AddItem(add50k);
        moneyMenu.AddItem(add100k);
        moneyMenu.AddItem(add500k);
        moneyMenu.AddItem(add1million);
        moneyMenu.AddItem(add5million);
        moneyMenu.AddItem(add20million);
        moneyMenu.AddItem(add100million);
        moneyMenu.AddItem(add1billion);

        moneyMenu.OnItemSelect += (sender, item, index) =>
        {
            if(Game.Player.Money < 2000000000)
            {
                // Add $10k
                if (item == add10k)
                {
                    DisplayMessage("$10,000 has been successfully wired to your account");
                    Game.Player.Money += 10000;
                }

                //Add $50k
                if (item == add50k)
                {
                    DisplayMessage("$50,000 has been successfully wired to your account");
                    Game.Player.Money += 50000;
                }

                //Add $100k
                if (item == add100k)
                {
                    DisplayMessage("$100,000 has been successfully wired to your account");
                    Game.Player.Money += 100000;
                }

                //Add $1mill
                if (item == add1million)
                {
                    DisplayMessage("$1,000,000 has been successfully wired to your account");
                    Game.Player.Money += 1000000;
                }

                //Add $5mill
                if (item == add5million)
                {
                    DisplayMessage("$5,000,000 has been successfully wired to your account");
                    Game.Player.Money += 5000000;
                }

                //Add $20mill
                if (item == add20million)
                {
                    DisplayMessage("$20,000,000 has been successfully wired to your account");
                    Game.Player.Money += 20000000;
                }

                //Add $100mill
                if (item == add100million)
                {
                    DisplayMessage("$100,000,000 has been successfully wired to your account");
                    Game.Player.Money += 100000000;
                }

                if (item == add1billion)
                {
                    DisplayMessage("$1,000,000,000 has been successfully wired to your account");
                    Game.Player.Money += 1000000000;
                }
            }
            else
            {
                DisplayMessage("You Have Wired The Max Amount of Money You Can Obtain");
            }
        };

        //Teleport Menu
        UIMenuItem teleportwaypoint = new UIMenuItem("Waypoint");
        UIMenuItem teleportchilliad = new UIMenuItem("Chilliad");
        UIMenuItem teleportpbank = new UIMenuItem("Pacific Standard Bank");
        UIMenuItem teleportpub1 = new UIMenuItem("Tequilala");
        UIMenuItem teleportpub2 = new UIMenuItem("Bahama Mamas");
        UIMenuItem teleportbell = new UIMenuItem("Cluckin Bell");
        UIMenuItem teleportfib = new UIMenuItem("FIB Lobby");
        UIMenuItem teleportfloyd = new UIMenuItem("Floyd's House");
        UIMenuItem teleportlifeinvader = new UIMenuItem("Life Invader");
        UIMenuItem teleportlester = new UIMenuItem("Lester's House");
        UIMenuItem teleportoneil = new UIMenuItem("O'Neil's Ranch");
        UIMenuItem teleportsolomon = new UIMenuItem("Solomon's Office");
        UIMenuItem teleportyatch = new UIMenuItem("Yatch");

        teleportMenu.AddItem(teleportwaypoint);
        teleportMenu.AddItem(teleportchilliad);
        teleportMenu.AddItem(teleportpbank);
        teleportMenu.AddItem(teleportpub1);
        teleportMenu.AddItem(teleportpub2);
        teleportMenu.AddItem(teleportbell);
        teleportMenu.AddItem(teleportfib);
        teleportMenu.AddItem(teleportfloyd);
        teleportMenu.AddItem(teleportlifeinvader);
        teleportMenu.AddItem(teleportlester);
        teleportMenu.AddItem(teleportoneil);
        teleportMenu.AddItem(teleportsolomon);
        teleportMenu.AddItem(teleportyatch);

        teleportMenu.OnItemSelect += (sender, item, index) =>
        {
            if (item == teleportwaypoint)
            {
                Player player = Game.Player;
             
                var markerPosition = World.GetWaypointPosition();
                var groundHeight = World.GetGroundHeight(markerPosition);

                if (!player.Character.IsInVehicle())
                {
                    player.Character.Position = markerPosition + (Vector3.WorldDown * 200.5f);
                }
                else
                {
                    Vehicle v = player.Character.CurrentVehicle;
                    v.Position = markerPosition + (Vector3.WorldDown * 200.5f);
                }


            }

            if (item == teleportchilliad)
            {
                Player player = Game.Player;
                if (!player.Character.IsInVehicle())
                {
                    player.Character.Position = new Vector3(451.2820f, 5572.9897f, 796.6793f);
                }
                else
                {
                    Vehicle v = player.Character.CurrentVehicle;
                    v.Position = new Vector3(451.2820f, 5572.9897f, 796.6793f);
                }


            }


            if (item == teleportpbank)
            {
                //Pacific Standard Bank Vault X: 255.851 Y: 217.030 Z: 101.683
                Player player = Game.Player;
                if (!player.Character.IsInVehicle())
                {
                    player.Character.Position = new Vector3(255.851f, 217.030f, 101.683f);
                }
                else
                {
                    Vehicle v = player.Character.CurrentVehicle;
                    v.Position = new Vector3(255.851f, 217.030f, 101.683f);
                }
            }

            if (item == teleportpub1)
            {
                //IAA Office X: 117.220 Y: -620.938 Z: 206.047
                Player player = Game.Player;
                if (!player.Character.IsInVehicle())
                {
                    //player.Character.Position = new Vector3(117.220f,-620.938f,06.047f);
                    player.Character.Position = new Vector3(-556.5089111328125f, 286.318115234375f, 81.1763f);
                    Function.Call(Hash.DISABLE_INTERIOR, Function.Call<int>(Hash.GET_INTERIOR_AT_COORDS, -556.5089111328125, 286.318115234375, 81.1763), false);
                    Function.Call(Hash.CAP_INTERIOR, Function.Call<int>(Hash.GET_INTERIOR_AT_COORDS, -556.5089111328125, 286.318115234375, 81.1763), false);
                    Function.Call(Hash.REQUEST_IPL, "v_rockclub");
                    Function.Call(Hash._DOOR_CONTROL, 993120320, -565.1712f, 276.6259f, 83.28626f, false, 0.0f, 0.0f, 0.0f);// front door
                    Function.Call(Hash._DOOR_CONTROL, 993120320, -561.2866f, 293.5044f, 87.77851f, false, 0.0f, 0.0f, 0.0f);// back door

                }
                else
                {
                    Vehicle v = player.Character.CurrentVehicle;
                    v.Position = new Vector3(255.851f, 217.030f, 101.683f);
                }
            }

            if (item == teleportpub2)
            {
                Player player = Game.Player;
                if (!player.Character.IsInVehicle())
                {
                    player.Character.Position = new Vector3(-1388.0013427734375f, -618.419677734375f, 30.819599151611328f);
                    Function.Call(Hash.DISABLE_INTERIOR, Function.Call<int>(Hash.GET_INTERIOR_AT_COORDS, -1388.0013427734375, -618.419677734375, 30.819599151611328), false);
                    Function.Call(Hash.REQUEST_IPL, "v_bahama");
                }
                else
                {
                    Vehicle v = player.Character.CurrentVehicle;
                    v.Position = new Vector3(-1388.0013427734375f, -618.419677734375f, 30.819599151611328f);

                }
            }

            if (item == teleportbell)
            {
                Player player = Game.Player;
                if (!player.Character.IsInVehicle())
                {
                    player.Character.Position = new Vector3(-72.68752f, 6253.72656f, 31.08991f);
                    Function.Call(Hash.REQUEST_IPL, "CS1_02_cf_onmission1");
                    Function.Call(Hash.REQUEST_IPL, "CS1_02_cf_onmission2");
                    Function.Call(Hash.REQUEST_IPL, "CS1_02_cf_onmission3");
                    Function.Call(Hash.REQUEST_IPL, "CS1_02_cf_onmission4");
                    Function.Call(Hash.REMOVE_IPL, "CS1_02_cf_offmission");
                }
                else
                {
                    Vehicle v = player.Character.CurrentVehicle;
                    v.Position = new Vector3(-72.68752f, 6253.72656f, 31.08991f);

                }
            }

            if (item == teleportfib)
            {
                Player player = Game.Player;
                if (!player.Character.IsInVehicle())
                {
                    player.Character.Position = new Vector3(110.4f, -744.2f, 45.7f);
                    Function.Call(Hash.REQUEST_IPL, "FIBlobby");
                    Function.Call(Hash.REMOVE_IPL, "FIBlobbyfake");
                    Function.Call(Hash._DOOR_CONTROL, -1517873911, 106.3793f, -742.6982f, 46.51962f, false, 0.0f, 0.0f, 0.0f);
                    Function.Call(Hash._DOOR_CONTROL, -90456267, 105.7607f, -746.646f, 46.18266f, false, 0.0f, 0.0f, 0.0f);
                }
                else
                {
                    Vehicle v = player.Character.CurrentVehicle;
                    v.Position = new Vector3(110.4f, -744.2f, 45.7f);

                }
            }

            if (item == teleportfloyd)
            {
                {
                    Player player = Game.Player;
                    if (!player.Character.IsInVehicle())
                    {
                        player.Character.Position = new Vector3(-1149.709f, -1521.088f, 10.78267f);
                        Function.Call(Hash.REMOVE_IPL, "vb_30_crimetape");
                        Function.Call(Hash._DOOR_CONTROL, -607040053, -1149.709f, -1521.088f, 10.78267f, false, 0.0f, 0.0f, 0.0f);
                    }
                    else
                    {
                        Vehicle v = player.Character.CurrentVehicle;
                        v.Position = new Vector3(-1149.709f, -1521.088f, 10.78267f);

                    }
                }
            }

            if (item == teleportlifeinvader)
            {
                {
                    Player player = Game.Player;
                    if (!player.Character.IsInVehicle())
                    {
                        player.Character.Position = new Vector3(-1047.9f, -233.0f, 39.0f);
                        Function.Call(Hash.REQUEST_IPL, "facelobby");  // lifeinvader
                        Function.Call(Hash.REMOVE_IPL, "facelobbyfake");
                        Function.Call(Hash._DOOR_CONTROL, -340230128, -1042.518, -240.6915, 38.11796, true, 0.0f, 0.0f, -1.0f);
                    }
                    else
                    {
                        Vehicle v = player.Character.CurrentVehicle;
                        v.Position = new Vector3(-1047.9f, -233.0f, 39.0f);

                    }
                }
            }

            if (item == teleportlester)
            {
                {
                    Player player = Game.Player;
                    if (!player.Character.IsInVehicle())
                    {
                        player.Character.Position = new Vector3(1274.933837890625f, -1714.7255859375f, 53.77149963378906f);
                        Function.Call(Hash.DISABLE_INTERIOR, Function.Call<int>(Hash.GET_INTERIOR_AT_COORDS, 1274.933837890625, -1714.7255859375, 53.77149963378906), false);
                        Function.Call(Hash.REQUEST_IPL, "v_lesters");
                        Function.Call(Hash._DOOR_CONTROL, 1145337974, 1273.816f, -1720.697f, 54.92143f, false, 0.0f, 0.0f, 0.0f);
                    }
                    else
                    {
                        Vehicle v = player.Character.CurrentVehicle;
                        v.Position = new Vector3(1274.933837890625f, -1714.7255859375f, 53.77149963378906f);

                    }
                }
            }

            if (item == teleportoneil)
            {
                {
                    Player player = Game.Player;
                    if (!player.Character.IsInVehicle())
                    {
                        player.Character.Position = new Vector3(2441.2f, 4968.5f, 51.7f);
                        Function.Call(Hash.REMOVE_IPL, "farm_burnt");
                        Function.Call(Hash.REMOVE_IPL, "farm_burnt_lod");
                        Function.Call(Hash.REMOVE_IPL, "farm_burnt_props");
                        Function.Call(Hash.REMOVE_IPL, "farmint_cap");
                        Function.Call(Hash.REMOVE_IPL, "farmint_cap_lod");
                        Function.Call(Hash.REQUEST_IPL, "farm");
                        Function.Call(Hash.REQUEST_IPL, "farmint");
                        Function.Call(Hash.REQUEST_IPL, "farm_lod");
                        Function.Call(Hash.REQUEST_IPL, "farm_props");

                    }
                    else
                    {
                        Vehicle v = player.Character.CurrentVehicle;
                        v.Position = new Vector3(2441.2f, 4968.5f, 51.7f);

                    }
                }
            }


            if (item == teleportsolomon)
            {
                {
                    Player player = Game.Player;
                    if (!player.Character.IsInVehicle())
                    {
                        player.Character.Position = new Vector3(-1005.663208f, -478.3460998535156f, 49.0265f);
                        Function.Call(Hash.DISABLE_INTERIOR, Function.Call<int>(Hash.GET_INTERIOR_AT_COORDS, -1005.663208f, -478.3460998535156f, 49.0265f), false);
                        Function.Call(Hash.REQUEST_IPL, "v_58_sol_office");
                    }
                    else
                    {
                        Vehicle v = player.Character.CurrentVehicle;
                        v.Position = new Vector3(-1005.663208f, -478.3460998535156f, 49.0265f);

                    }
                }
            }

            if (item == teleportyatch)
            {
                Player player = Game.Player;
                if (!player.Character.IsInVehicle())
                {
                    player.Character.Position = new Vector3(-2045.8f, -1031.2f, 11.9f);
                    Function.Call(Hash.REQUEST_IPL, "hei_yacht_heist");
                    Function.Call(Hash.REQUEST_IPL, "hei_yacht_heist_Bar");
                    Function.Call(Hash.REQUEST_IPL, "hei_yacht_heist_Bedrm");
                    Function.Call(Hash.REQUEST_IPL, "hei_yacht_heist_Bridge");
                    Function.Call(Hash.REQUEST_IPL, "hei_yacht_heist_DistantLights");
                    Function.Call(Hash.REQUEST_IPL, "hei_yacht_heist_enginrm");
                    Function.Call(Hash.REQUEST_IPL, "hei_yacht_heist_LODLights");
                    Function.Call(Hash.REQUEST_IPL, "hei_yacht_heist_Lounge");
                }
                else
                {
                    Vehicle v = player.Character.CurrentVehicle;
                    v.Position = new Vector3(-2045.8f, -1031.2f, 11.9f);

                }
            }



        };

        //Change Player Model
        UIMenu mainModel = modMenuPool.AddSubMenu(playerMenu, "Change Model");
        UIMenuItem randomOutfit = new UIMenuItem("~b~Randomize Outfit");

        UIMenu playerModel = modMenuPool.AddSubMenu(mainModel, "Player Models");
        UIMenuItem alienItem = new UIMenuItem("Alien");
        UIMenuItem copItem = new UIMenuItem("Cop");
        UIMenuItem rangerItem = new UIMenuItem("Ranger");
        UIMenuItem clayItem = new UIMenuItem("ClayPain");
        UIMenuItem clownItem = new UIMenuItem("Clown");
        UIMenuItem jesusItem = new UIMenuItem("Jesus");
        UIMenuItem formageItem = new UIMenuItem("Cris Formage");
        UIMenuItem ballasItem = new UIMenuItem("Ballas");
        UIMenuItem marineItem = new UIMenuItem("Marine");
        UIMenuItem fbiItem = new UIMenuItem("FBI Man");
        UIMenuItem superItem = new UIMenuItem("Superman");
        UIMenuItem cjItem = new UIMenuItem("Fake CJ");
        UIMenuItem zombieItem = new UIMenuItem("Zombie");
        UIMenuItem lamarItem = new UIMenuItem("Lamar");
        UIMenuItem amandaItem = new UIMenuItem("Amanda");
        UIMenuItem traceyItem = new UIMenuItem("Tracey");
        UIMenuItem musclemainItem = new UIMenuItem("Muscle Man");
        UIMenuItem bigfootItem = new UIMenuItem("Bigfoot");

        UIMenu animalModel = modMenuPool.AddSubMenu(mainModel, "Animal Models");
        UIMenuItem catItem = new UIMenuItem("Cat");
        UIMenuItem hawkItem = new UIMenuItem("Hawk");
        UIMenuItem chopItem = new UIMenuItem("Chop");
        UIMenuItem chimpItem = new UIMenuItem("Chimp");
        UIMenuItem cowItem = new UIMenuItem("Cow");
        UIMenuItem coyoteItem = new UIMenuItem("Coyote");
        UIMenuItem crowItem = new UIMenuItem("Crow");
        UIMenuItem cormoItem = new UIMenuItem("Cormorant");
        UIMenuItem boarItem = new UIMenuItem("Board");

        playerModel.AddItem(randomOutfit);

        //Player Models
        playerModel.AddItem(alienItem);
        playerModel.AddItem(copItem);
        playerModel.AddItem(rangerItem);
        playerModel.AddItem(clayItem);
        playerModel.AddItem(clownItem);
        playerModel.AddItem(jesusItem);
        playerModel.AddItem(formageItem);
        playerModel.AddItem(ballasItem);
        playerModel.AddItem(marineItem);
        playerModel.AddItem(fbiItem);
        playerModel.AddItem(superItem);
        playerModel.AddItem(cjItem);
        playerModel.AddItem(zombieItem);
        playerModel.AddItem(lamarItem);
        playerModel.AddItem(amandaItem);
        playerModel.AddItem(traceyItem);
        playerModel.AddItem(musclemainItem);
        playerModel.AddItem(bigfootItem);

        //Animal Models
        animalModel.AddItem(catItem);
        animalModel.AddItem(hawkItem);
        animalModel.AddItem(chopItem);
        animalModel.AddItem(chimpItem);
        animalModel.AddItem(cowItem);
        animalModel.AddItem(coyoteItem);
        animalModel.AddItem(crowItem);
        animalModel.AddItem(cormoItem);
        animalModel.AddItem(boarItem);

        mainModel.OnItemSelect += (sender, item, index) =>
        {

            if (item == randomOutfit)
            {
                Game.Player.Character.RandomizeOutfit();
            }

        };

        playerModel.OnItemSelect += (sender, item, index) =>
        {
            if(Game.Player.IsAlive)
            {
                if (item == alienItem)
                {
                    Ped gamePed = Game.Player.Character;
                    Game.Player.ChangeModel(PedHash.MovAlien01);
                }

                if (item == copItem)
                {
                    Ped gamePed = Game.Player.Character;
                    Game.Player.ChangeModel(PedHash.Cop01SMY);
                }


                if (item == rangerItem)
                {
                    Ped gamePed = Game.Player.Character;
                    Game.Player.ChangeModel(PedHash.Ranger01SMY);
                }

                if (item == clayItem)
                {
                    Ped gamePed = Game.Player.Character;
                    Game.Player.ChangeModel(PedHash.Claypain);
                }

                if (item == clownItem)
                {
                    Ped gamePed = Game.Player.Character;
                    Game.Player.ChangeModel(PedHash.Clown01SMY);
                }

                if (item == jesusItem)
                {
                    Ped gamePed = Game.Player.Character;
                    Game.Player.ChangeModel(PedHash.Jesus01);
                }

                if (item == formageItem)
                {
                    Ped gamePed = Game.Player.Character;
                    Game.Player.ChangeModel(PedHash.CrisFormage);
                }

                if (item == ballasItem)
                {
                    Ped gamePed = Game.Player.Character;
                    Game.Player.ChangeModel(PedHash.BallaOrig01GMY);
                }

                if (item == marineItem)
                {
                    Ped gamePed = Game.Player.Character;
                    Game.Player.ChangeModel(PedHash.Marine03SMY);
                }

                if (item == fbiItem)
                {
                    Ped gamePed = Game.Player.Character;
                    Game.Player.ChangeModel(PedHash.FibSec01SMM);
                }

                if (item == superItem)
                {
                    Ped gamePed = Game.Player.Character;
                    Game.Player.ChangeModel(PedHash.Imporage);
                }

                if (item == cjItem)
                {
                    Ped gamePed = Game.Player.Character;
                    Game.Player.ChangeModel(PedHash.StrPunk02GMY);
                }

                if (item == zombieItem)
                {
                    Ped gamePed = Game.Player.Character;
                    Game.Player.ChangeModel(PedHash.Zombie01);
                }

                if (item == lamarItem)
                {
                    Model model = PedHash.LamarDavis;

                    if (!model.IsLoaded && !model.Request(1000))
                    {
                        DisplayMessage("Model Could not be loaded");
                        return;
                    }

                    Game.Player.ChangeModel(model);

                    Function.Call(Hash.SET_PED_DEFAULT_COMPONENT_VARIATION, Game.Player.Character);

                }


                if (item == amandaItem)
                {
                    Model model = PedHash.AmandaTownley;

                    if (!model.IsLoaded && !model.Request(1000))
                    {
                        DisplayMessage("Model Could not be loaded");
                        return;
                    }

                    Game.Player.ChangeModel(model);

                    Function.Call(Hash.SET_PED_DEFAULT_COMPONENT_VARIATION, Game.Player.Character);
                }


                if (item == traceyItem)
                {
                    Model model = PedHash.TracyDisanto;

                    if (!model.IsLoaded && !model.Request(1000))
                    {
                        DisplayMessage("Model Could not be loaded");
                        return;
                    }

                    Game.Player.ChangeModel(model);

                    Function.Call(Hash.SET_PED_DEFAULT_COMPONENT_VARIATION, Game.Player.Character);
                }


                if (item == musclemainItem)
                {
                    Model model = PedHash.Babyd;

                    if (!model.IsLoaded && !model.Request(1000))
                    {
                        DisplayMessage("Model Could not be loaded");
                        return;
                    }

                    Game.Player.ChangeModel(model);

                    Function.Call(Hash.SET_PED_DEFAULT_COMPONENT_VARIATION, Game.Player.Character);
                }

                if (item == bigfootItem)
                {
                    Model model = PedHash.Orleans;

                    if (!model.IsLoaded && !model.Request(1000))
                    {
                        DisplayMessage("Model Could not be loaded");
                        return;
                    }

                    Game.Player.ChangeModel(model);

                    Function.Call(Hash.SET_PED_DEFAULT_COMPONENT_VARIATION, Game.Player.Character);
                }
            }
            else 
            {
                if (Game.Player.IsDead || Function.Call<bool>(Hash.IS_PLAYER_BEING_ARRESTED, Game.Player.Handle, true))
                {
                
                        var defaultModel = new Model(PedHash.Michael);
                        defaultModel.Request(500);
                        if (defaultModel.IsInCdImage && defaultModel.IsValid)
                        {
                            while (!defaultModel.IsLoaded)
                            {
                                Script.Wait(100);
                                Function.Call(Hash.SET_PLAYER_MODEL, Game.Player, defaultModel.Hash);
                                Function.Call(Hash.SET_PED_DEFAULT_COMPONENT_VARIATION, Game.Player.Character.Handle);
                            }
                        }


                    
                }
            }
        };

        //Animal Models
        animalModel.OnItemSelect += (sender, item, index) =>
        {
            if (item == catItem)
            {
                Ped gamePed = Game.Player.Character;
                Game.Player.ChangeModel(PedHash.Cat);
            }

            if (item == hawkItem)
            {
                Model model = PedHash.ChickenHawk;

                if (!model.IsLoaded && !model.Request(1000))
                {
                    DisplayMessage("Model Could not be loaded");
                    return;
                }

                Game.Player.ChangeModel(model);

                Function.Call(Hash.SET_PED_DEFAULT_COMPONENT_VARIATION, Game.Player.Character);
            }

            if (item == chopItem)
            {
                Ped gamePed = Game.Player.Character;
                Game.Player.ChangeModel(PedHash.Chop);
            }

            if (item == chimpItem)
            {
                Ped gamePed = Game.Player.Character;
                Game.Player.ChangeModel(PedHash.Chimp);
            }

            if (item == cowItem)
            {
                Ped gamePed = Game.Player.Character;
                Game.Player.ChangeModel(PedHash.Cow);
            }

            if (item == coyoteItem)
            {
                Ped gamePed = Game.Player.Character;
                Game.Player.ChangeModel(PedHash.Coyote);
            }

            if (item == crowItem)
            {
                Ped gamePed = Game.Player.Character;
                Game.Player.ChangeModel(PedHash.Crow);
            }

            if (item == cormoItem)
            {
                Ped gamePed = Game.Player.Character;
                Game.Player.ChangeModel(PedHash.Cormorant);
            }

            if (item == boarItem)
            {
                Ped gamePed = Game.Player.Character;
                Game.Player.ChangeModel(PedHash.Boar);
            }
        };


    //Player God Mode Check box
    UIMenuItem godMode = new UIMenuCheckboxItem("God Mode", false);

        playerMenu.AddItem(godMode);

        playerMenu.OnCheckboxChange += (sender, item, checked_) =>
        {
            if (item == godMode)
            {
                godModeOn = !godModeOn;

                if (godModeOn)
                {
                    Game.Player.IsInvincible = true;
                    Game.Player.Character.IsInvincible = true;

                }
                else
                {
                    Game.Player.IsInvincible = false;
                    Game.Player.Character.IsInvincible = false;

                }
            }
        };

        //Never Wanted Checkbox
        UIMenuItem neverWanted = new UIMenuCheckboxItem("Never Wanted", false);

        playerMenu.AddItem(neverWanted);

        playerMenu.OnCheckboxChange += (sender, item, checked_) =>
        {
            if (item == neverWanted)
            {
                neverWantedOn = !neverWantedOn;

                if (neverWantedOn)
                {
                    neverWantedOn = true;
                }
                else
                {
                    neverWantedOn = false;
                }
            }
        };

        //Remove Wanted Level
        UIMenuItem removeWantedLevel = new UIMenuItem("Remove Wanted Level");
        playerMenu.AddItem(removeWantedLevel);

        playerMenu.OnItemSelect += (sender, item, index) =>
        {
            if (item == removeWantedLevel)
            {
                if (Game.Player.WantedLevel == 0)
                {
                    DisplayMessage("You are not wanted");
                }
                else
                {
                    Game.Player.WantedLevel = 0;
                }
            }
        };

        //Max Wanted Level
        UIMenuItem maxWantedLevel = new UIMenuItem("Max Wanted Level");
        playerMenu.AddItem(maxWantedLevel);

        playerMenu.OnItemSelect += (sender, item, index) =>
        {
            if (item == maxWantedLevel)
            {
                if (Game.Player.WantedLevel == 5)
                {
                    DisplayMessage("You are already most wanted!");
                }
                else
                {
                    Game.Player.WantedLevel = 5;
                }
            }
        };

        //Kill Player
        UIMenuItem commitSuicide = new UIMenuItem("Commit Suicide");
        playerMenu.AddItem(commitSuicide);

        playerMenu.OnItemSelect += (sender, item, index) =>
        {
            if (item == commitSuicide)
            {
                Game.Player.Character.Health = -1;
            }
        };
    }
}
