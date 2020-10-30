using System;
using System.Collections.Generic;
using GTA;
using GTA.Native;
using System.Globalization;
using GTA.Math;

partial class TeleportFunctions : Script
{
    public TeleportFunctions()
    {
        Tick += OnTick;
    }

    private void OnTick(object sender, EventArgs e)
    {
        unlockAllInteriorDoors();
    }

    #region load IPL(s)
    internal static void LoadIPLs()
    {
        Function.Call(Hash._LOAD_MP_DLC_MAPS);
        Function.Call(Hash._ENABLE_MP_DLC_MAPS, 1);

        string[] locationIPLs = new string[]
        {
            //North Yankton
            "plg_01", "prologue01", "prologue01_lod","prologue01c", "prologue01c_lod", "prologue01d","prologue01d_lod", "prologue01e","prologue01e_lod",
            "prologue01f","prologue01f_lod","prologue01g","prologue01h","prologue01h_lod","prologue01i","prologue01i_lod","prologue01j","prologue01j_lod",
            "prologue01k","prologue01k_lod","prologue01z","prologue01z_lod","plg_02","prologue02","prologue02_lod","plg_03","prologue03","prologue03_lod",
            "prologue03b","prologue03b_lod","prologue03_grv_dug","prologue03_grv_dug_lod","prologue_grv_torch","plg_04","prologue04","prologue04_lod",
            "prologue04b","prologue04b_lod","prologue04_cover","des_protree_end","des_protree_start","des_protree_start_lod","plg_05","prologue05",
            "prologue05_lod","prologue05b","prologue05b_lod","plg_06","prologue06","prologue06_lod","prologue06b","prologue06b_lod","prologue06_int",
            "prologue06_int_lod","prologue06_pannel","prologue06_pannel_lod","prologue_m2_door","prologue_m2_door_lod","plg_occl_00","prologue_occl",
            "plg_rd","prologuerd","prologuerdb","prologuerd_lod",
            //Heist Yatch
            "hei_yacht_heist","hei_yacht_heist","hei_yacht_heist_Bar",
            "hei_yacht_heist_Bedrm","hei_yacht_heist_Bridge",
            "hei_yacht_heist_DistantLights","hei_yacht_heist_enginrm",
            "hei_yacht_heist_LODLights","hei_yacht_heist_Lounge",
            //Destroyed Hospital
            "RC12B_Destroyed","RC12B_HospitalInterior",
            //Morgue
            "Coroner_Int_on", "coronertrash",
            //O' Neil Farm
            "farm","farm_props","farmint",
            //Life Invader
            "facelobby",
            //Carrier 
            "hei_carrier","hei_carrier_DistantLights",
            "hei_Carrier_int1","hei_Carrier_int2",
            "hei_Carrier_int3","hei_Carrier_int3",
            "hei_Carrier_int3","hei_Carrier_int3",
            "hei_Carrier_int3",
            //Union Depository
            "FINBANK","DT1_03_shutter","DT1_03_Gr_Closed",
            //Jewelry Store
            "post_hiest_unload",
            //Bahama Mama's
            "hei_sm_16_interior_v_bahama_milo_", "sm_16_interior_v_bahama_milo_",
            //Chilliad, Hippy Camp, and Fort Zan UFO
            "ufo","ufo_eye","ufo_lod",
            //FIB Lobby
            "FIBlobby", 
            //Cluckin Bell Warehouse
            "CS1_02_cf_onmission1", "CS1_02_cf_onmission2",
            "CS1_02_cf_onmission3","CS1_02_cf_onmission4",
            "CS1_02_cf_offmission", 
            //Humane Labs
            "v_lab", 
            //Paleto & Sandy Shores Police Station
            "cs1_16_sheriff_cap",
            //Lester Factory
            "id2_14_during1", 
            //Rogers Recylce & Scrap Facility
            "v_recycle", 
            //Red Carpet
            "redCarpet", "redcarpet_lod",
            //Franklins New Home
            "v_franklinshouse", 
            //Madrazo's Ranch
            "apa_ch2_03c_interior_v_ranch_milo_", 
            //Stadium 
            "SP1_10_real_interior", 
            //Max Renda Sho
            "refit_unload", 
            //Premium Deluxe Motorsport
            "shutter_open", "csr_inMission", "shr_int", "v_carshowroom",
            //Foundry
            "lr_id1_17_interior_v_foundry_milo_"
        };

        
        foreach (string IPLRequest in locationIPLs)
        {
            Function.Call(Hash.REQUEST_IPL, IPLRequest);

        }

        
        string[] locationIPLRemove = new string[]
        {
            //Life Invader
            "facelobby_lod","facelobbyfake",
            //FIB Lobby
            "FIBlobbyfake",
            //North Yankton Grave
            "prologue03_grv_cov","prologue03_grv_cov_lod", "prologue03_grv_fun", 
            //Jewlry Sore
            "jewel2fake", "bh1_16_refurb", 
            //O'Niel Ranch
            "farmint_cap",
            //Cluckin Bell Warehouse
            "CS1_02_cf_offmission", 
            //Paleto & Sandy Shores Police Station
            "v_sheriff2", "sheriff_cap", "cs1_16_sheriff_cap",
            //Garment Factory
            "id2_14_pre_no_int", "id2_14_post_no_int", "id2_14_on_fire", "id2_14_during2",
            "id2_14_during_door", 
            //Undamaged Hospital 
            "rc12b_default", 
            //Humane Labs
            "chemgrill_grp1", 
            //Stadium
            "SP1_10_fake_interior", 
            //Max Renda
            "bh1_16_doors_shut",
            //Premium Deluxe Motorsport
            "shutter_closed", "fakeint"
        };

        foreach (string IPLRemove in locationIPLRemove)
        {
            Function.Call(Hash.REMOVE_IPL, IPLRemove);

        }

    }
    #endregion

    #region unlock interior doors
    internal static void unlockAllInteriorDoors()
    {
        //Custom struct?

        //FIB Lobby
        Function.Call(Hash._DOOR_CONTROL, -1517873911, 106.3793f, -742.6982f, 46.51962f, false, 0.0f, 0.0f, 0.0f);
        Function.Call(Hash._DOOR_CONTROL, -90456267, 105.7607f, -746.646f, 46.18266f, false, 0.0f, 0.0f, 0.0f);
        //Floyd's House'
        Function.Call(Hash._DOOR_CONTROL, -607040053, -1149.709f, -1521.088f, 10.78267f, false, 0.0f, 0.0f, 0.0f);
        //Epsilon
        Function.Call(Hash._DOOR_CONTROL, -1230442770, 241.3621f, 361.0471f, 105.8883f, false, 0.0f, 0.0f, 0.0f);
        //Janitor
        Function.Call(Hash._DOOR_CONTROL, 486670049, -107.5373f, -9.018099f, 70.67085f, false, 0.0f, 0.0f, 0.0f);
        //Humane Lab
        Function.Call(Hash._DOOR_CONTROL, -1081024910, 3620.843f, 3751.527f, 27.69009f, false, 0.0f, 0.0f, -1.0f);
        Function.Call(Hash._DOOR_CONTROL, -1081024910, 3627.713f, 3746.716f, 27.69009f, false, 0.0f, 0.0f, -1.0f);
        //Life Invader
        Function.Call(Hash._DOOR_CONTROL, 3954737168, -1042.518f, -240.6915f, 38.11796f, false, 0.0f, 0.0f, 0.0f); //Emergency Exit(Side)
        Function.Call(Hash._DOOR_CONTROL, 3249951925, -1080.974f, -259.0203f, 38.1867f, false, 0.0f, 0.0f, 0.0f); //Lobby Entrance Left door
        Function.Call(Hash._DOOR_CONTROL, 2615085319, -1083.62f, -260.4166f, 38.1867f, false, 0.0f, 0.0f, 0.0f); //Lobby Entrance Right door
        Function.Call(Hash._DOOR_CONTROL, 1104171198, -1045.12f, -232.0f, 39.43f, false, 0.0f, 0.0f, 0.0f); //Employee Entrance Left door
        Function.Call(Hash._DOOR_CONTROL, 2869895994, -1046.516f, -229.3581f, 39.43794f, false, 0.0f, 0.0f, 0.0f); //Employee Entrance Right door
        Function.Call(Hash._DOOR_CONTROL, 3799246327, -1055.958f, -236.4251f, 44.171f, false, 0.0f, 0.0f, 0.0f); //Free Thinking Room
        Function.Call(Hash._DOOR_CONTROL, 2473190209, -1048.285f, -236.8171f, 44.171f, false, 0.0f, 0.0f, 0.0f); //Conference Room Left
        Function.Call(Hash._DOOR_CONTROL, 2473190209, -1047.084f, -239.1246f, 44.171f, false, 0.0f, 0.0f, 0.0f); //Conference Room Right
        //Physc
        Function.Call(Hash._DOOR_CONTROL, 2243315674, -1901.312f, -572.4862f, 19.24694f, false, 0.0f, 0.0f, 0.0f);
        //Bank Gate 
        Function.Call(Hash._DOOR_CONTROL, 4072696575, 256.3116f, 220.6579f, 106.4296f, false, 0.0f, 0.0f, 0.0f);
        Function.Call(Hash._DOOR_CONTROL, 746855201, 262.1981, 222.5188f, 106.4296f, false, 0.0f, 0.0f, 0.0f);
        Function.Call(Hash._DOOR_CONTROL, 1956494919, 266.3624f, 217.5697f, 110.4328f, false, 0.0f, 0.0f, 0.0f);
        //Lester House
        Function.Call(Hash._DOOR_CONTROL, 1145337974, 1273.816f, -1720.697f, 54.92143f, false, 0.0f, 0.0f, 0.0f);
        //Lesters Factory
        Function.Call(Hash._DOOR_CONTROL, 826072862, 717.0f, -975.0f, 25.0f, false, 0.0f, 0.0f, 0.0f);
        Function.Call(Hash._DOOR_CONTROL, 763780711, 719.0f, -975.0f, 25.0f, false, 0.0f, 0.0f, 0.0f);
        //Ranch
        Function.Call(Hash._DOOR_CONTROL, 1504256620, 1395.92f, 1142.904f, 114.7902f, true, 0.0f, 0.0f, 0.0f);
        Function.Call(Hash._DOOR_CONTROL, 262671971, 1395.92f, 1140.705f, 114.7902f, true, 0.0f, 0.0f, 0.0f);
        //Rogers Salaveg & Scrap
        Function.Call(Hash._DOOR_CONTROL, 1099436502, -608.7289f, -1610.315f, 27.15894f, false, 0.0f, 0.0f, -1.0f);
        Function.Call(Hash._DOOR_CONTROL, -1627599682, -611.32f, -1610.089f, 27.15894f, false, 0.0f, 0.0f, 1.0f);
        Function.Call(Hash._DOOR_CONTROL, 1099436502, -592.9376f, -1631.577f, 27.15931f, false, 0.0f, 0.0f, -1.0f);
        Function.Call(Hash._DOOR_CONTROL, -1627599682, -592.7109f, -1628.986f, 27.15931f, false, 0.0f, 0.0f, 1.0f);
        //Sheriff Office paleto
        Function.Call(Hash._DOOR_CONTROL, -1501157055, -444.4985f, 6017.06f, 31.86633f, false, 0.0f, 0.0f, 0.0f);
        Function.Call(Hash._DOOR_CONTROL, -1501157055, -442.66f, 6015.222f, 31.86633f, false, 0.0f, 0.0f, 0.0f);
        //Sheriff Office sandy shores
        Function.Call(Hash._DOOR_CONTROL, -1765048490, 1855.685f, 3683.93f, 34.59282f, false, 0.0f, 0.0f, 0.0f);
        //Slaughter House
        Function.Call(Hash._DOOR_CONTROL, -1468417022, 962.9084f, -2105.813f, 32.52716f, true, 0.0f, 0.0f, 1.0f);
        Function.Call(Hash._DOOR_CONTROL, 1755793225, 962.0066f, -2183.816f, 31.06194f, true, 0.0f, 0.0f, 1.0f);
        //Trevor's Trailer
        Function.Call(Hash._DOOR_CONTROL, 132154435, 1972.769f, 3815.366f, 33.66326f, false, 0.0f, 0.0f, 0.0f);
        //TEQUL-LA_LA:
        Function.Call(Hash._DOOR_CONTROL, 993120320, -565.1712f, 276.6259f, 83.28626f, false, 0.0f, 0.0f, 0.0f);// front door
        Function.Call(Hash._DOOR_CONTROL, 993120320, -561.2866f, 293.5044f, 87.77851f, false, 0.0f, 0.0f, 0.0f);// back door
        //Torture
        Function.Call(Hash._DOOR_CONTROL, 464151082, 134.3954f, -2204.097f, 7.514325f, false, 0.0f, 0.0f, 0.0f);
        //Foundry
        Function.Call(Hash._DOOR_CONTROL, 2866345169, 1083.547f, -1975.435f, 31.62222f, false, 0.0f, 0.0f, 0.0f);
        Function.Call(Hash._DOOR_CONTROL, 2866345169, 1085.307f, -2018.561f, 41.62894f, false, 0.0f, 0.0f, 0.0f);
    }
    #endregion

    #region Teleport to location
    internal static void TeleportToLocation(KeyValuePair<string, Vector3> location)
    {
        MainMenu.GetEntity.Position = location.Value;
        MainMenu.DisplayMessage(string.Format("Teleport to {0} succeeded", location.Key));
    }
    #endregion

    #region Teleport to Waypoint
    internal static void TeleportToMarker()
    {
        Entity e = MainMenu.GetEntity;
        Vector3 waypointPos = World.GetWaypointPosition();

        float[] groundHeight = new float[]
        {
            100.0f, 150.0f, 50.0f, 0.0f, 200.0f, 250.0f, 300.0f, 350.0f, 400.0f,
            450.0f, 500.0f, 550.0f, 600.0f, 650.0f, 700.0f, 750.0f, 800.0f
        };
        unsafe
        {
            if (waypointPos != Vector3.Zero)
            {
                foreach (float height in groundHeight)
                {
                    float zCoord = 0;
                    Wait(100);
                    if (Function.Call<bool>(Hash.GET_GROUND_Z_FOR_3D_COORD, e.Position.X, e.Position.Y, height, &zCoord))
                    {
                        e.Position = new Vector3(waypointPos.X, waypointPos.Y, zCoord + 3);
                        MainMenu.DisplayMessage("~g~Successfully Teleported To Waypoint");
                    }
                }
            }
            else
            {
                MainMenu.DisplayMessage("~r~A Waypoint Has Not Been Placed");
            }
        }
    }
    #endregion
}
