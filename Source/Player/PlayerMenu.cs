﻿using System;
using System.Collections.Generic;
using GTA;
using NativeUI;

partial class MainMenu : Script
{
    public UIMenu playerMenu;
    public UIMenu spawnPedMenu;
    public UIMenu playerOptions;
    public UIMenu moneyOptions;

    public UIMenu animalMC;
    public UIMenu ambientFemales;
    public UIMenu ambientMales;
    public UIMenu cutsceneMC;
    public UIMenu gangFemaleMC;
    public UIMenu gangMaleMC;
    public UIMenu storyMC;
    public UIMenu multiplayerMC;
    public UIMenu scenarioFemaleMC;
    public UIMenu scenarioMaleMC;
    public UIMenu otherMC;


    private void ElitePlayerMenu()
    {
        playerMenu = modMenuPool.AddSubMenu(mainMenu, "Player");
        spawnPedMenu = modMenuPool.AddSubMenu(playerMenu, "Model Changer");
        moneyOptions = modMenuPool.AddSubMenu(playerMenu, "Money Options");
        playerOptions = modMenuPool.AddSubMenu(playerMenu, "Player Options");

        #region Player Model Menu(s)
        animalMC = modMenuPool.AddSubMenu(spawnPedMenu, "Animals Models");
        ambientFemales = modMenuPool.AddSubMenu(spawnPedMenu, "Ambient Females");
        ambientMales = modMenuPool.AddSubMenu(spawnPedMenu, "Ambient Males");
        cutsceneMC = modMenuPool.AddSubMenu(spawnPedMenu, "Cutscene Models");
        gangFemaleMC = modMenuPool.AddSubMenu(spawnPedMenu, "Gang Female");
        gangMaleMC = modMenuPool.AddSubMenu(spawnPedMenu, "Gang Male");
        storyMC = modMenuPool.AddSubMenu(spawnPedMenu, "Story Models");
        multiplayerMC = modMenuPool.AddSubMenu(spawnPedMenu, "Multiplayer Models");
        scenarioFemaleMC = modMenuPool.AddSubMenu(spawnPedMenu, "Scenario Females");
        scenarioMaleMC = modMenuPool.AddSubMenu(spawnPedMenu, "Scenario Males");
        otherMC = modMenuPool.AddSubMenu(spawnPedMenu, "Other Models");
        #endregion

        #region Character Models

        Dictionary<string, string> animalModels = new Dictionary<string, string>
        {
            {"boar","a_c_boar" },
            {"cat","a_c_cat_01" },
            {"chickenhawk","a_c_chickenhawk"},
            {"chimp","a_c_chimp" },
            {"chop","a_c_chop" },
            {"cormorant","a_c_cormorant" },
            {"cow","a_c_cow" },
            {"coyote","a_c_coyote" },
            {"crow","a_c_crow" },
            {"deer","a_c_deer" },
            {"dolphin","a_c_dolphin" },
            {"fish","a_c_fish" },
            {"hen","a_c_hen" },
            {"humpback","a_c_humpback" },
            {"husky","a_c_husky" },
            {"killerwhale","a_c_killerwhale" },
            {"mt lion","a_c_mtlion" },
            {"pig","a_c_pig" },
            {"pigeon","a_c_pigeon" },
            {"poodle","a_c_poodle" },
            {"pug","a_c_pug" },
            {"rabbit","a_c_rabbit_01" },
            {"rat","a_c_rat" },
            {"retriever" ,"a_c_retriever" },
            {"rhesus","a_c_rhesus" },
            {"rottweiler","a_c_rottweiler" },
            {"seagull","a_c_seagull" },
            {"sharkhammer","a_c_sharkhammer" },
            {"sharktiger","a_c_sharktiger" },
            {"shepherd","a_c_shepherd" },
            {"stingray","a_c_stingray" },
            {"westy","a_c_westy" },
        };

        Dictionary<UInt32, string> cutsceneModels = new Dictionary<uint, string>
        {
            { 0x95EF18E3, "cs_amandatownley" },
            { 0xE7565327, "cs_andreas" },
            { 0x26C3D079, "cs_ashley" },
            { 0x9760192E, "cs_bankman" },
            { 0x69591CF7, "cs_barry" },
            { 0xB46EC356, "cs_beverly" },
            { 0xEFE5AFE6, "cs_brad" },
            { 0x7228AF60, "cs_bradcadaver" },
            { 0x8CCE790F, "cs_carbuyer" },
            { 0xEA969C40, "cs_casey" },
            { 0x30DB9D7B, "cs_chengsr" },
            { 0xC1F380E6, "cs_chrisformage" },
            { 0xDBCB9834, "cs_clay" },
            { 0x0CE81655, "cs_dale" },
            { 0x8587248C, "cs_davenorton" },
            { 0xECD04FE9, "cs_debra" },
            { 0x6F802738, "cs_denise" },
            { 0x2F016D02, "cs_devin" },
            { 0x4772AF42, "cs_dom" },
            { 0x3C60A153, "cs_dreyfuss" },
            { 0xA3A35C2F, "cs_drfriedlander" },
            { 0x47035EC1, "cs_fabien" },
            { 0x585C0B52, "cs_fbisuit_01" },
            { 0x062547E7, "cs_floyd" },
            { 0x0F9513F1, "cs_guadalope" },
            { 0xC314F727, "cs_gurk" },
            { 0x5B44892C, "cs_hunter" },
            { 0x3034F9E2, "cs_janet" },
            { 0x4440A804, "cs_jewelass" },
            { 0x039677BD, "cs_jimmyboston" },
            { 0xB8CC92B4, "cs_jimmydisanto" },
            { 0xF09D5E29, "cs_joeminuteman" },
            { 0xFA8AB881, "cs_johnnyklebitz" },
            { 0x459762CA, "cs_josef" },
            { 0x450EEF9D, "cs_josh" },
            { 0x4BAF381C, "cs_karen_daniels" },
            { 0x45463A0D, "cs_lamardavis" },
            { 0x38951A1B, "cs_lazlow" },
            { 0xB594F5C3, "cs_lestercrest" },
            { 0x72551375, "cs_lifeinvad_01" },
            { 0x5816C61A, "cs_magenta" },
            { 0xFBB374CA, "cs_manuel" },
            { 0x574DE134, "cs_marnie" },
            { 0x43595670, "cs_martinmadrazo" },
            { 0x0998C7AD, "cs_maryann" },
            { 0x70AEB9C8, "cs_michelle" },
            { 0xB76A330F, "cs_milton" },
            { 0x45918E44, "cs_molly" },
            { 0x4BBA84D9, "cs_movpremf_01" },
            { 0x8D67EE7D, "cs_movpremmale" },
            { 0xC3CC9A75, "cs_mrk" },
            { 0x4F921E6E, "cs_mrs_thornhill" },
            { 0xCBFDA3CF, "cs_mrsphillips" },
            { 0x4EFEB1F0, "cs_natalia" },
            { 0x7896DA94, "cs_nervousron" },
            { 0xE1479C0B, "cs_nigel" },
            { 0x1EEC7BDC, "cs_old_man1a" },
            { 0x98F9E770, "cs_old_man2" },
            { 0x8B70B405, "cs_omega" },
            { 0xAD340F5A, "cs_orleans" },
            { 0x6B38B8F8, "cs_paper" },
            { 0xDF8B1301, "cs_patricia" },
            { 0x4D6DE57E, "cs_priest" },
            { 0x1E9314A2, "cs_prolsec_02" },
            { 0x46521A32, "cs_russiandrunk" },
            { 0xC0937202, "cs_siemonyetarian" },
            { 0xF6D1E04E, "cs_solomon" },
            { 0xA4E0A1FE, "cs_stevehains" },
            { 0x893D6805, "cs_stretch" },
            { 0x42FE5370, "cs_tanisha" },
            { 0x8864083D, "cs_taocheng" },
            { 0x53536529, "cs_taostranslator" },
            { 0x5C26040A, "cs_tenniscoach" },
            { 0x3A5201C5, "cs_terry" },
            { 0x69E8ABC3, "cs_tom" },
            { 0x8C0FD4E2, "cs_tomepsilon" },
            { 0x0609B130, "cs_tracydisanto" },
            { 0xD266D9D6, "cs_wade" },
            { 0xEAACAAF0, "cs_zimbor" },
            { 0x89768941, "csb_abigail" },
            { 0xD770C9B4, "csb_agent" },
            { 0x0703F106, "csb_anita" },
            { 0xA5C787B6, "csb_anton" },
            { 0xABEF0004, "csb_ballasog" },
            { 0x82BF7EA1, "csb_bride" },
            { 0x8CDCC057, "csb_burgerdrug" },
            { 0x04430687, "csb_car3guy1" },
            { 0x1383A508, "csb_car3guy2" },
            { 0xA347CA8A, "csb_chef" },
            { 0xAE5BE23A, "csb_chef2" },
            { 0xA8C22996, "csb_chin_goon" },
            { 0xCAE9E5D5, "csb_cletus" },
            { 0x9AB35F63, "csb_cop" },
            { 0xA44F6F8B, "csb_customer" },
            { 0xB58D2529, "csb_denise_friend" },
            { 0x1BCC157B, "csb_fos_rep" },
            { 0xA28E71D7, "csb_g" },
            { 0x7AAB19D2, "csb_groom" },
            { 0xE8594E22, "csb_grove_str_dlr" },
            { 0xEC9E8F1C, "csb_hao" },
            { 0x6F139B54, "csb_hugh" },
            { 0xE3420BDB, "csb_imran" },
            { 0x44BC7BB1, "csb_jackhowitzer" },
            { 0xC2005A40, "csb_janitor" },
            { 0xBCC475CB, "csb_maude" },
            { 0x989DFD9A, "csb_money" },
            { 0x6DBBFC8B, "csb_mp_agent14" },
            { 0x613E626C, "csb_mweather" },
            { 0xC0DB04CF, "csb_ortega" },
            { 0xF41F399B, "csb_oscar" },
            { 0x5B1FA0C3, "csb_paige" },
            { 0x617D89E2, "csb_popov" },
            { 0x2F4AFE35, "csb_porndudes" },
            { 0xF00B49DB, "csb_prologuedriver" },
            { 0x7FA2F024, "csb_prolsec" },
            { 0xC2800DBE, "csb_ramp_gang" },
            { 0x858C94B8, "csb_ramp_hic" },
            { 0x21F58BB4, "csb_ramp_hipster" },
            { 0x616C97B9, "csb_ramp_marine" },
            { 0xF64ED7D0, "csb_ramp_mex" },
            { 0x188099A9, "csb_rashcosvki" },
            { 0x2E420A24, "csb_reporter" },
            { 0xAA64168C, "csb_roccopelosi" },
            { 0x8BE12CEC, "csb_screen_writer" },
            { 0xAEEA76B5, "csb_stripper_01" },
            { 0x81441B71, "csb_stripper_02" },
            { 0x6343DD19, "csb_tonya" },
            { 0xDE2937F3, "csb_trafficwarden" },
            { 0xEF785A6A, "csb_undercover" },
            { 0x48FF4CA9, "csb_vagspeak" },
        };

        Dictionary<UInt32, string> multiplayerModels = new Dictionary<UInt32, string>
        {
            { 0x3293B9CE, "mp_f_boatstaff_01" },
            { 0x242C34A7, "mp_f_cardesign_01" },
            { 0xC3F6E385, "mp_f_chbar_01" },
            { 0x4B657AF8, "mp_f_cocaine_01" },
            { 0xB788F1F5, "mp_f_counterfeit_01" },
            { 0x73DEA88B, "mp_f_deadhooker" },
            { 0x432CA064, "mp_f_execpa_01" },
            { 0x5972CCF0, "mp_f_execpa_02" },
            { 0x781A3CF8, "mp_f_forgery_01" },
            { 0x9C9EFFD8, "mp_f_freemode_01" },
            { 0x19B6FF06, "mp_f_helistaff_01" },
            { 0xD2B27EC1, "mp_f_meth_01" },
            { 0xD128FF9D, "mp_f_misty_01" },
            { 0x2970A494, "mp_f_stripperlite" },
            { 0xB26573A3, "mp_f_weed_01" },
            { 0x6C9DD7C9, "mp_g_m_pros_01" },
            { 0x45F92D79, "mp_headtargets" },
            { 0xC85F0A88, "mp_m_boatstaff_01" },
            { 0xC0F371B7, "mp_m_claude_01" },
            { 0x56D38F95, "mp_m_cocaine_01" },
            { 0x9855C974, "mp_m_counterfeit_01" },
            { 0x45348DBB, "mp_m_exarmy_01" },
            { 0x3E8417BC, "mp_m_execpa_01" },
            { 0x33A464E5, "mp_m_famdd_01" },
            { 0x5CDEF405, "mp_m_fibsec_01" },
            { 0x613E709B, "mp_m_forgery_01" },
            { 0x705E61F2, "mp_m_freemode_01" },
            { 0xC4A617BD, "mp_m_g_vagfun_01" },
            { 0x38430167, "mp_m_marston_01" },
            { 0xEDB42F3F, "mp_m_meth_01" },
            { 0xEEDACFC9, "mp_m_niko_01" },
            { 0xDA2C984E, "mp_m_securoguard_01" },
            { 0x18CE57D0, "mp_m_shopkeep_01" },
            { 0xF7A74139, "mp_m_waremech_01" },
            { 0x36EA5B09, "mp_m_weapexp_01" },
            { 0x4186506E, "mp_m_weapwork_01" },
            { 0x917ED459, "mp_m_weed_01" },
            { 0xCDEF5408, "mp_s_m_armoured_01" },
            { 0x9B22DBAF, "player_one" },
            { 0x9B810FA2, "player_two" },
            { 0x0D7114C9, "player_zero" },
        };

        Dictionary<UInt32, string> ambientFemaleModels = new Dictionary<UInt32, string>
        {
            { 0x303638A7, "a_f_m_beach_01" },
            { 0xBE086EFD, "a_f_m_bevhills_01" },
            { 0xA039335F, "a_f_m_bevhills_02" },
            { 0x3BD99114, "a_f_m_bodybuild_01" },
            { 0x1FC37DBC, "a_f_m_business_02" },
            { 0x654AD86E, "a_f_m_downtown_01" },
            { 0x9D3DCB7A, "a_f_m_eastsa_01" },
            { 0x63C8D891, "a_f_m_eastsa_02" },
            { 0xFAB48BCB, "a_f_m_fatbla_01" },
            { 0xB5CF80E4, "a_f_m_fatcult_01" },
            { 0x38BAD33B, "a_f_m_fatwhite_01" },
            { 0x52C824DE, "a_f_m_ktown_01" },
            { 0x41018151, "a_f_m_ktown_02" },
            { 0x169BD1E1, "a_f_m_prolhost_01" },
            { 0xDE0E0969, "a_f_m_salton_01" },
            { 0xB097523B, "a_f_m_skidrow_01" },
            { 0x745855A1, "a_f_m_soucent_01" },
            { 0xF322D338, "a_f_m_soucent_02" },
            { 0xCDE955D2, "a_f_m_soucentmc_01" },
            { 0x505603B9, "a_f_m_tourist_01" },
            { 0x48F96F5B, "a_f_m_tramp_01" },
            { 0x8CA0C266, "a_f_m_trampbeac_01" },
            { 0x61C81C85, "a_f_o_genstreet_01" },
            { 0xBAD7BB80, "a_f_o_indian_01" },
            { 0x47CF5E96, "a_f_o_ktown_01" },
            { 0xCCFF7D8A, "a_f_o_salton_01" },
            { 0x3DFA1830, "a_f_o_soucent_01" },
            { 0xA56DE716, "a_f_o_soucent_02" },
            { 0xC79F6928, "a_f_y_beach_01" },
            { 0x445AC854, "a_f_y_bevhills_01" },
            { 0x5C2CF7F8, "a_f_y_bevhills_02" },
            { 0x20C8012F, "a_f_y_bevhills_03" },
            { 0x36DF2D5D, "a_f_y_bevhills_04" },
            { 0x2799EFD8, "a_f_y_business_01" },
            { 0x31430342, "a_f_y_business_02" },
            { 0xAE86FDB4, "a_f_y_business_03" },
            { 0xB7C61032, "a_f_y_business_04" },
            { 0xF5B0079D, "a_f_y_eastsa_01" },
            { 0x0438A4AE, "a_f_y_eastsa_02" },
            { 0x51C03FA4, "a_f_y_eastsa_03" },
            { 0x689C2A80, "a_f_y_epsilon_01" },
            { 0x50610C43, "a_f_y_femaleagent" },
            { 0x457C64FB, "a_f_y_fitness_01" },
            { 0x13C4818C, "a_f_y_fitness_02" },
            { 0x2F4AEC3E, "a_f_y_genhot_01" },
            { 0x7DD8FB58, "a_f_y_golfer_01" },
            { 0x30830813, "a_f_y_hiker_01" },
            { 0x1475B827, "a_f_y_hippie_01" },
            { 0x8247D331, "a_f_y_hipster_01" },
            { 0x97F5FE8D, "a_f_y_hipster_02" },
            { 0xA5BA9A16, "a_f_y_hipster_03" },
            { 0x199881DC, "a_f_y_hipster_04" },
            { 0x092D9CC1, "a_f_y_indian_01" },
            { 0xDB134533, "a_f_y_juggalo_01" },
            { 0xC7496729, "a_f_y_runner_01" },
            { 0x3F789426, "a_f_y_rurmeth_01" },
            { 0xDB5EC400, "a_f_y_scdressy_01" },
            { 0x695FE666, "a_f_y_skater_01" },
            { 0x2C641D7A, "a_f_y_soucent_01" },
            { 0x5A8EF9CF, "a_f_y_soucent_02" },
            { 0x87B25415, "a_f_y_soucent_03" },
            { 0x550C79C6, "a_f_y_tennis_01" },
            { 0x9CF26183, "a_f_y_topless_01" },
            { 0x563B8570, "a_f_y_tourist_01" },
            { 0x9123FB40, "a_f_y_tourist_02" },
            { 0x19F41F65, "a_f_y_vinewood_01" },
            { 0xDAB6A0EB, "a_f_y_vinewood_02" },
            { 0x379DDAB8, "a_f_y_vinewood_03" },
            { 0xFAE46146, "a_f_y_vinewood_04" },
            { 0xC41B062E, "a_f_y_yoga_01" },
        };

        Dictionary<UInt32, string> ambientMaleModels = new Dictionary<UInt32, string>
        {
            { 0x5442C66B, "a_m_m_acult_01" },
            { 0xD172497E, "a_m_m_afriamer_01" },
            { 0x403DB4FD, "a_m_m_beach_01" },
            { 0x787FA588, "a_m_m_beach_02" },
            { 0x54DBEE1F, "a_m_m_bevhills_01" },
            { 0x3FB5C3D3, "a_m_m_bevhills_02" },
            { 0x7E6A64B7, "a_m_m_business_01" },
            { 0xF9A6F53F, "a_m_m_eastsa_01" },
            { 0x07DD91AC, "a_m_m_eastsa_02" },
            { 0x94562DD7, "a_m_m_farmer_01" },
            { 0x61D201B3, "a_m_m_fatlatin_01" },
            { 0x06DD569F, "a_m_m_genfat_01" },
            { 0x13AEF042, "a_m_m_genfat_02" },
            { 0xA9EB0E42, "a_m_m_golfer_01" },
            { 0x6BD9B68C, "a_m_m_hasjew_01" },
            { 0x6C9B2849, "a_m_m_hillbilly_01" },
            { 0x7B0E452F, "a_m_m_hillbilly_02" },
            { 0xDDCAAA2C, "a_m_m_indian_01" },
            { 0xD15D7E71, "a_m_m_ktown_01" },
            { 0x2FDE6EB7, "a_m_m_malibu_01" },
            { 0xDD817EAD, "a_m_m_mexcntry_01" },
            { 0xB25D16B2, "a_m_m_mexlabor_01" },
            { 0x681BD012, "a_m_m_og_boss_01" },
            { 0xECCA8C15, "a_m_m_paparazzi_01" },
            { 0xA9D9B69E, "a_m_m_polynesian_01" },
            { 0x9712C38F, "a_m_m_prolhost_01" },
            { 0x3BAD4184, "a_m_m_rurmeth_01" },
            { 0x4F2E038A, "a_m_m_salton_01" },
            { 0x60F4A717, "a_m_m_salton_02" },
            { 0xB28C4A45, "a_m_m_salton_03" },
            { 0x964511B7, "a_m_m_salton_04" },
            { 0xD9D7588C, "a_m_m_skater_01" },
            { 0x01EEA6BD, "a_m_m_skidrow_01" },
            { 0x0B8D69E3, "a_m_m_socenlat_01" },
            { 0x6857C9B7, "a_m_m_soucent_01" },
            { 0x9F6D37E1, "a_m_m_soucent_02" },
            { 0x8BD990BA, "a_m_m_soucent_03" },
            { 0xC2FBFEFE, "a_m_m_soucent_04" },
            { 0xC2A87702, "a_m_m_stlat_02" },
            { 0x546A5344, "a_m_m_tennis_01" },
            { 0xC89F0184, "a_m_m_tourist_01" },
            { 0x1EC93FD0, "a_m_m_tramp_01" },
            { 0x53B57EB0, "a_m_m_trampbeac_01" },
            { 0xE0E69974, "a_m_m_tranvest_01" },
            { 0xF70EC5C4, "a_m_m_tranvest_02" },
            { 0x55446010, "a_m_o_acult_01" },
            { 0x4BA14CCA, "a_m_o_acult_02" },
            { 0x8427D398, "a_m_o_beach_01" },
            { 0xAD54E7A8, "a_m_o_genstreet_01" },
            { 0x1536D95A, "a_m_o_ktown_01" },
            { 0x20208E4D, "a_m_o_salton_01" },
            { 0x2AD8921B, "a_m_o_soucent_01" },
            { 0x4086BD77, "a_m_o_soucent_02" },
            { 0x0E32D8D0, "a_m_o_soucent_03" },
            { 0x174D4245, "a_m_o_tramp_01" },
            { 0xB564882B, "a_m_y_acult_01" },
            { 0x80E59F2E, "a_m_y_acult_02" },
            { 0xD1FEB884, "a_m_y_beach_01" },
            { 0x23C7DC11, "a_m_y_beach_02" },
            { 0xE7A963D9, "a_m_y_beach_03" },
            { 0x7E0961B8, "a_m_y_beachvesp_01" },
            { 0xCA56FA52, "a_m_y_beachvesp_02" },
            { 0x76284640, "a_m_y_bevhills_01" },
            { 0x668BA707, "a_m_y_bevhills_02" },
            { 0x379F9596, "a_m_y_breakdance_01" },
            { 0x9AD32FE9, "a_m_y_busicas_01" },
            { 0xC99F21C4, "a_m_y_business_01" },
            { 0xB3B3F5E6, "a_m_y_business_02" },
            { 0xA1435105, "a_m_y_business_03" },
            { 0xFDC653C7, "a_m_y_cyclist_01" },
            { 0xFF3E88AB, "a_m_y_dhill_01" },
            { 0x2DADF4AA, "a_m_y_downtown_01" },
            { 0xA4471173, "a_m_y_eastsa_01" },
            { 0x168775F6, "a_m_y_eastsa_02" },
            { 0x77D41A3E, "a_m_y_epsilon_01" },
            { 0xAA82FF9B, "a_m_y_epsilon_02" },
            { 0xD1CCE036, "a_m_y_gay_01" },
            { 0xA5720781, "a_m_y_gay_02" },
            { 0x9877EF71, "a_m_y_genstreet_01" },
            { 0x3521A8D2, "a_m_y_genstreet_02" },
            { 0xD71FE131, "a_m_y_golfer_01" },
            { 0xE16D8F01, "a_m_y_hasjew_01" },
            { 0x50F73C0C, "a_m_y_hiker_01" },
            { 0x7D03E617, "a_m_y_hippy_01" },
            { 0x2307A353, "a_m_y_hipster_01" },
            { 0x14D506EE, "a_m_y_hipster_02" },
            { 0x4E4179C6, "a_m_y_hipster_03" },
            { 0x2A22FBCE, "a_m_y_indian_01" },
            { 0x2DB7EEF3, "a_m_y_jetski_01" },
            { 0x91CA3E2C, "a_m_y_juggalo_01" },
            { 0x1AF6542C, "a_m_y_ktown_01" },
            { 0x297FF13F, "a_m_y_ktown_02" },
            { 0x132C1A8E, "a_m_y_latino_01" },
            { 0x696BE0A9, "a_m_y_methhead_01" },
            { 0x3053E555, "a_m_y_mexthug_01" },
            { 0x64FDEA7D, "a_m_y_motox_01" },
            { 0x77AC8FDA, "a_m_y_motox_02" },
            { 0x4B652906, "a_m_y_musclbeac_01" },
            { 0xC923247C, "a_m_y_musclbeac_02" },
            { 0x8384FC9F, "a_m_y_polynesian_01" },
            { 0xF561A4C6, "a_m_y_roadcyc_01" },
            { 0x25305EEE, "a_m_y_runner_01" },
            { 0x843D9D0F, "a_m_y_runner_02" },
            { 0xD7606C30, "a_m_y_salton_01" },
            { 0xC1C46677, "a_m_y_skater_01" },
            { 0xAFFAC2E4, "a_m_y_skater_02" },
            { 0xE716BDCB, "a_m_y_soucent_01" },
            { 0xACA3C8CA, "a_m_y_soucent_02" },
            { 0xC3F0F764, "a_m_y_soucent_03" },
            { 0x8A3703F1, "a_m_y_soucent_04" },
            { 0xCF92ADE9, "a_m_y_stbla_01" },
            { 0x98C7404F, "a_m_y_stbla_02" },
            { 0x8674D5FC, "a_m_y_stlat_01" },
            { 0x2418C430, "a_m_y_stwhi_01" },
            { 0x36C6E98C, "a_m_y_stwhi_02" },
            { 0xB7292F0C, "a_m_y_sunbathe_01" },
            { 0xEAC2C7EE, "a_m_y_surfer_01" },
            { 0xC19377E7, "a_m_y_vindouche_01" },
            { 0x4B64199D, "a_m_y_vinewood_01" },
            { 0x5D15BD00, "a_m_y_vinewood_02" },
            { 0x1FDF4294, "a_m_y_vinewood_03" },
            { 0x31C9E669, "a_m_y_vinewood_04" },
            { 0xAB0A7155, "a_m_y_yoga_01" },
        };

        Dictionary<UInt32, string> gangFemaleModels = new Dictionary<UInt32, string>
        {
            { 0x84A1B11A, "g_f_importexport_01" },
            { 0x158C439C, "g_f_y_ballas_01" },
            { 0x4E0CE5D3, "g_f_y_families_01" },
            { 0xFD5537DE, "g_f_y_lost_01" },
            { 0x5AA42C21, "g_f_y_vagos_01" }
        };

        Dictionary<UInt32, string> gangMaleModels = new Dictionary<UInt32, string>
        {
            { 0xBCA2CCEA, "g_m_importexport_01" },
            { 0xF1E823A2, "g_m_m_armboss_01" },
            { 0xFDA94268, "g_m_m_armgoon_01" },
            { 0xE7714013, "g_m_m_armlieut_01" },
            { 0xF6157D8F, "g_m_m_chemwork_01" },
            { 0xB9DD0300, "g_m_m_chiboss_01" },
            { 0x106D9A99, "g_m_m_chicold_01" },
            { 0x7E4F763F, "g_m_m_chigoon_01" },
            { 0xFF71F826, "g_m_m_chigoon_02" },
            { 0x352A026F, "g_m_m_korboss_01" },
            { 0x5761F4AD, "g_m_m_mexboss_01" },
            { 0x4914D813, "g_m_m_mexboss_02" },
            { 0xC54E878A, "g_m_y_armgoon_02" },
            { 0x68709618, "g_m_y_azteca_01" },
            { 0xF42EE883, "g_m_y_ballaeast_01" },
            { 0x231AF63F, "g_m_y_ballaorig_01" },
            { 0x23B88069, "g_m_y_ballasout_01" },
            { 0xE83B93B7, "g_m_y_famca_01" },
            { 0xDB729238, "g_m_y_famdnf_01" },
            { 0x84302B09, "g_m_y_famfor_01" },
            { 0x247502A9, "g_m_y_korean_01" },
            { 0x8FEDD989, "g_m_y_korean_02" },
            { 0x7CCBE17A, "g_m_y_korlieut_01" },
            { 0x4F46D607, "g_m_y_lost_01" },
            { 0x3D843282, "g_m_y_lost_02" },
            { 0x32B11CDC, "g_m_y_lost_03" },
            { 0xBDDD5546, "g_m_y_mexgang_01" },
            { 0x26EF3426, "g_m_y_mexgoon_01" },
            { 0x31A3498E, "g_m_y_mexgoon_02" },
            { 0x964D12DC, "g_m_y_mexgoon_03" },
            { 0x4F3FBA06, "g_m_y_pologoon_01" },
            { 0xA2E86156, "g_m_y_pologoon_02" },
            { 0x905CE0CA, "g_m_y_salvaboss_01" },
            { 0x278C8CB7, "g_m_y_salvagoon_01" },
            { 0x3273A285, "g_m_y_salvagoon_02" },
            { 0x03B8C510, "g_m_y_salvagoon_03" },
            { 0xFD1C49BB, "g_m_y_strpunk_01" },
            { 0x0DA1EAC6, "g_m_y_strpunk_02" },
        };

        Dictionary<UInt32, string> scenarioFemaleModels = new Dictionary<UInt32, string>
        {
            { 0x163B875B, "s_f_m_fembarber" },
            { 0xE093C5C6, "s_f_m_maid_01" },
            { 0xAE47E4B0, "s_f_m_shop_high" },
            { 0x312B5BC0, "s_f_m_sweatshop_01" },
            { 0x5D71A46F, "s_f_y_airhostess_01" },
            { 0x780C01BD, "s_f_y_bartender_01" },
            { 0x4A8E5536, "s_f_y_baywatch_01" },
            { 0x15F8700D, "s_f_y_cop_01" },
            { 0x69F46BF3, "s_f_y_factory_01" },
            { 0x028ABF95, "s_f_y_hooker_01" },
            { 0x14C3E407, "s_f_y_hooker_02" },
            { 0x031640AC, "s_f_y_hooker_03" },
            { 0xD55B2BF5, "s_f_y_migrant_01" },
            { 0x2300C816, "s_f_y_movprem_01" },
            { 0x9FC7F637, "s_f_y_ranger_01" },
            { 0xAB594AB6, "s_f_y_scrubs_01" },
            { 0x4161D042, "s_f_y_sheriff_01" },
            { 0xA96E2604, "s_f_y_shop_low" },
            { 0x3EECBA5D, "s_f_y_shop_mid" },
            { 0x52580019, "s_f_y_stripper_01" },
            { 0x6E0FB794, "s_f_y_stripper_02" },
            { 0x5C14EDFA, "s_f_y_stripperlite" },
            { 0x8502B6B2, "s_f_y_sweatshop_01" },
        };

        Dictionary<UInt32, string> scenarioMaleModels = new Dictionary<UInt32, string>
        {
            { 0x0DE9A30A, "s_m_m_ammucountry" },
            { 0x95C76ECD, "s_m_m_armoured_01" },
            { 0x63858A4A, "s_m_m_armoured_02" },
            { 0x040EABE3, "s_m_m_autoshop_01" },
            { 0xF06B849D, "s_m_m_autoshop_02" },
            { 0x9FD4292D, "s_m_m_bouncer_01" },
            { 0xC9E5F56B, "s_m_m_ccrew_01" },
            { 0x2EFEAFD5, "s_m_m_chemsec_01" },
            { 0x625D6958, "s_m_m_ciasec_01" },
            { 0x1A021B83, "s_m_m_cntrybar_01" },
            { 0x14D7B4E0, "s_m_m_dockwork_01" },
            { 0xD47303AC, "s_m_m_doctor_01" },
            { 0xEDBC7546, "s_m_m_fiboffice_01" },
            { 0x26F067AD, "s_m_m_fiboffice_02" },
            { 0x7B8B434B, "s_m_m_fibsec_01" },
            { 0xA956BD9E, "s_m_m_gaffer_01" },
            { 0x49EA5685, "s_m_m_gardener_01" },
            { 0x1880ED06, "s_m_m_gentransport" },
            { 0x418DFF92, "s_m_m_hairdress_01" },
            { 0xF161D212, "s_m_m_highsec_01" },
            { 0x2930C1AB, "s_m_m_highsec_02" },
            { 0xA96BD9EC, "s_m_m_janitor" },
            { 0x9E80D2CE, "s_m_m_lathandy_01" },
            { 0xDE0077FD, "s_m_m_lifeinvad_01" },
            { 0xDB9C0997, "s_m_m_linecook" },
            { 0x765AAAE4, "s_m_m_lsmetro_01" },
            { 0x7EA4FFA6, "s_m_m_mariachi_01" },
            { 0xF2DAA2ED, "s_m_m_marine_01" },
            { 0xF0259D83, "s_m_m_marine_02" },
            { 0xED0CE4C6, "s_m_m_migrant_01" },
            { 0x64611296, "s_m_m_movalien_01" },
            { 0xD85E6D28, "s_m_m_movprem_01" },
            { 0xE7B31432, "s_m_m_movspace_01" },
            { 0xB353629E, "s_m_m_paramedic_01" },
            { 0xE75B4B1C, "s_m_m_pilot_01" },
            { 0xF63DE8E1, "s_m_m_pilot_02" },
            { 0x62599034, "s_m_m_postal_01" },
            { 0x7367324F, "s_m_m_postal_02" },
            { 0x56C96FC6, "s_m_m_prisguard_01" },
            { 0x4117D39B, "s_m_m_scientist_01" },
            { 0xD768B228, "s_m_m_security_01" },
            { 0x1AE8BB58, "s_m_m_snowcop_01" },
            { 0x795AC7A8, "s_m_m_strperf_01" },
            { 0x1C0077FB, "s_m_m_strpreach_01" },
            { 0xCE9113A9, "s_m_m_strvend_01" },
            { 0x59511A6C, "s_m_m_trucker_01" },
            { 0x9FC37F22, "s_m_m_ups_01" },
            { 0xD0BDE116, "s_m_m_ups_02" },
            { 0xAD9EF1BB, "s_m_o_busker_01" },
            { 0x62018559, "s_m_y_airworker" },
            { 0x9E08633D, "s_m_y_ammucity_01" },
            { 0x62CC28E2, "s_m_y_armymech_01" },
            { 0xB2273D4E, "s_m_y_autopsy_01" },
            { 0xE5A11106, "s_m_y_barman_01" },
            { 0x0B4A6862, "s_m_y_baywatch_01" },
            { 0xB3F3EE34, "s_m_y_blackops_01" },
            { 0x7A05FA59, "s_m_y_blackops_02" },
            { 0x5076A73B, "s_m_y_blackops_03" },
            { 0xD8F9CD47, "s_m_y_busboy_01" },
            { 0x0F977CEB, "s_m_y_chef_01" },
            { 0x04498DDE, "s_m_y_clown_01" },
            { 0xD7DA9E99, "s_m_y_construct_01" },
            { 0xC5FEFADE, "s_m_y_construct_02" },
            { 0x5E3DA4A4, "s_m_y_cop_01" },
            { 0xE497BBEF, "s_m_y_dealer_01" },
            { 0x9B557274, "s_m_y_devinsec_01" },
            { 0x867639D1, "s_m_y_dockwork_01" },
            { 0x22911304, "s_m_y_doorman_01" },
            { 0x75D30A91, "s_m_y_dwservice_01" },
            { 0xF5908A06, "s_m_y_dwservice_02" },
            { 0x4163A158, "s_m_y_factory_01" },
            { 0xB6B1EDA8, "s_m_y_fireman_01" },
            { 0xEE75A00F, "s_m_y_garbage" },
            { 0x309E7DEA, "s_m_y_grip_01" },
            { 0x739B1EF5, "s_m_y_hwaycop_01" },
            { 0x65793043, "s_m_y_marine_01" },
            { 0x58D696FE, "s_m_y_marine_02" },
            { 0x72C0CAD2, "s_m_y_marine_03" },
            { 0x3CDCA742, "s_m_y_mime" },
            { 0x48114518, "s_m_y_pestcont_01" },
            { 0xAB300C07, "s_m_y_pilot_01" },
            { 0x5F2113A1, "s_m_y_prismuscl_01" },
            { 0xB1BB9B59, "s_m_y_prisoner_01" },
            { 0xEF7135AE, "s_m_y_ranger_01" },
            { 0xC05E1399, "s_m_y_robber_01" },
            { 0xB144F9B9, "s_m_y_sheriff_01" },
            { 0x6E122C06, "s_m_y_shop_mask" },
            { 0x927F2323, "s_m_y_strvend_01" },
            { 0x8D8F1B10, "s_m_y_swat_01" },
            { 0xCA0050E9, "s_m_y_uscg_01" },
            { 0x3B96F23E, "s_m_y_valet_01" },
            { 0xAD4C724C, "s_m_y_waiter_01" },
            { 0x550D8D9D, "s_m_y_winclean_01" },
            { 0x441405EC, "s_m_y_xmech_01" },
            { 0xBE20FA04, "s_m_y_xmech_02" },
            { 0x69147A0D, "s_m_y_xmech_02_mp" },
        };

        Dictionary<UInt32, string> storyModels = new Dictionary<UInt32, string>
        {
            { 0x3B474ADF, "hc_driver" },
            { 0x0B881AEE, "hc_gunman" },
            { 0x99BB00F8, "hc_hacker" },
            { 0x400AEC41, "ig_abigail" },
            { 0x246AF208, "ig_agent" },
            { 0x6D1E15F7, "ig_amandatownley" },
            { 0x47E4EEA0, "ig_andreas" },
            { 0x7EF440DB, "ig_ashley" },
            { 0xA70B4A92, "ig_ballasog" },
            { 0x909D9E7F, "ig_bankman" },
            { 0x2F8845A3, "ig_barry" },
            { 0xC4B715D2, "ig_benny" },
            { 0x5746CD96, "ig_bestmen" },
            { 0xBDA21E5C, "ig_beverly" },
            { 0xBDBB4922, "ig_brad" },
            { 0x6162EC47, "ig_bride" },
            { 0x84F9E937, "ig_car3guy1" },
            { 0x75C34ACA, "ig_car3guy2" },
            { 0xE0FA2554, "ig_casey" },
            { 0x49EADBF6, "ig_chef" },
            { 0x85889AC3, "ig_chef2" },
            { 0xAAE4EA7B, "ig_chengsr" },
            { 0x286E54A7, "ig_chrisformage" },
            { 0x6CCFE08A, "ig_clay" },
            { 0x9D0087A8, "ig_claypain" },
            { 0xE6631195, "ig_cletus" },
            { 0x467415E9, "ig_dale" },
            { 0x15CD4C33, "ig_davenorton" },
            { 0x820B33BD, "ig_denise" },
            { 0x7461A0B0, "ig_devin" },
            { 0x9C2DB088, "ig_dom" },
            { 0xDA890932, "ig_dreyfuss" },
            { 0xCBFC0DF5, "ig_drfriedlander" },
            { 0xD090C350, "ig_fabien" },
            { 0x3AE4A33B, "ig_fbisuit_01" },
            { 0xB1B196B2, "ig_floyd" },
            { 0x841BA933, "ig_g" },
            { 0xFECE8B85, "ig_groom" },
            { 0x65978363, "ig_hao" },
            { 0xCE1324DE, "ig_hunter" },
            { 0x0D6D9C49, "ig_janet" },
            { 0x7A32EE74, "ig_jay_norris" },
            { 0x0F5D26BB, "ig_jewelass" },
            { 0xEDA0082D, "ig_jimmyboston" },
            { 0x570462B9, "ig_jimmydisanto" },
            { 0xBE204C9B, "ig_joeminuteman" },
            { 0x87CA80AE, "ig_johnnyklebitz" },
            { 0xE11A9FB4, "ig_josef" },
            { 0x799E9EEE, "ig_josh" },
            { 0xEB51D959, "ig_karen_daniels" },
            { 0x5B3BD90D, "ig_kerrymcintosh" },
            { 0x65B93076, "ig_lamardavis" },
            { 0xDFE443E5, "ig_lazlow" },
            { 0x4DA6E849, "ig_lestercrest" },
            { 0x5389A93C, "ig_lifeinvad_01" },
            { 0x27BD51D4, "ig_lifeinvad_02" },
            { 0xFCDC910A, "ig_magenta" },
            { 0xF1BCA919, "ig_malc" },
            { 0xFD418E10, "ig_manuel" },
            { 0x188232D0, "ig_marnie" },
            { 0xA36F9806, "ig_maryann" },
            { 0x3BE8287E, "ig_maude" },
            { 0xBF9672F4, "ig_michelle" },
            { 0xCB3059B2, "ig_milton" },
            { 0xAF03DDE1, "ig_molly" },
            { 0x37FACDA6, "ig_money" },
            { 0xFBF98469, "ig_mp_agent14" },
            { 0xEDDCAB6D, "ig_mrk" },
            { 0x1E04A96B, "ig_mrs_thornhill" },
            { 0x3862EEA8, "ig_mrsphillips" },
            { 0xDE17DD3B, "ig_natalia" },
            { 0xBD006AF1, "ig_nervousron" },
            { 0xC8B7167D, "ig_nigel" },
            { 0x719D27F4, "ig_old_man1a" },
            { 0xEF154C47, "ig_old_man2" },
            { 0x60E6A7D8, "ig_omega" },
            { 0x2DC6D3E7, "ig_oneil" },
            { 0x61D4C771, "ig_orleans" },
            { 0x26A562B7, "ig_ortega" },
            { 0x154FCF3F, "ig_paige" },
            { 0x999B00C6, "ig_paper" },
            { 0xC56E118C, "ig_patricia" },
            { 0x267630FE, "ig_popov" },
            { 0x6437E77D, "ig_priest" },
            { 0x27B3AD75, "ig_prolsec_02" },
            { 0xE52E126C, "ig_ramp_gang" },
            { 0x45753032, "ig_ramp_hic" },
            { 0xDEEF9F6E, "ig_ramp_hipster" },
            { 0xE6AC74A4, "ig_ramp_mex" },
            { 0x380C4DE6, "ig_rashcosvki" },
            { 0xD5BA52FF, "ig_roccopelosi" },
            { 0x3D0A5EB1, "ig_russiandrunk" },
            { 0xFFE63677, "ig_screen_writer" },
            { 0x4C7B2F05, "ig_siemonyetarian" },
            { 0x86BDFE26, "ig_solomon" },
            { 0x382121C8, "ig_stevehains" },
            { 0x36984358, "ig_stretch" },
            { 0xE793C8E8, "ig_talina" },
            { 0x0D810489, "ig_tanisha" },
            { 0xDC5C5EA5, "ig_taocheng" },
            { 0x7C851464, "ig_taostranslator" },
            { 0xA23B5F57, "ig_tenniscoach" },
            { 0x67000B94, "ig_terry" },
            { 0xCD777AAA, "ig_tomepsilon" },
            { 0xCAC85344, "ig_tonya" },
            { 0xDE352A35, "ig_tracydisanto" },
            { 0x5719786D, "ig_trafficwarden" },
            { 0x5265F707, "ig_tylerdix" },
            { 0xF9FD068C, "ig_vagspeak" },
            { 0x92991B72, "ig_wade" },
            { 0x0B34D6F5, "ig_zimbor" },
        };

        Dictionary<UInt32, string> otherModels = new Dictionary<UInt32, string>
        {
            { 0x3F039CBA, "slod_human" },
            { 0x856CFB02, "slod_large_quadped" },
            { 0x2D7030F3, "slod_small_quadped" },
            { 0x2E140314, "u_f_m_corpse_01" },
            { 0xD7F37609, "u_f_m_drowned_01" },
            { 0x414FA27B, "u_f_m_miranda" },
            { 0xA20899E7, "u_f_m_promourn_01" },
            { 0x35578634, "u_f_o_moviestar" },
            { 0xC512DD23, "u_f_o_prolhost_01" },
            { 0xFA389D4F, "u_f_y_bikerchic" },
            { 0xB6AA85CE, "u_f_y_comjane" },
            { 0x9C70109D, "u_f_y_corpse_01" },
            { 0x0D9C72F8, "u_f_y_corpse_02" },
            { 0x969B6DFE, "u_f_y_hotposh_01" },
            { 0xF0D4BE2E, "u_f_y_jewelass_01" },
            { 0x5DCA2528, "u_f_y_mistress" },
            { 0x23E9A09E, "u_f_y_poppymich" },
            { 0xD2E3A284, "u_f_y_princess" },
            { 0x5B81D86C, "u_f_y_spyactress" },
            { 0xF0EC56E2, "u_m_m_aldinapoli" },
            { 0xC306D6F5, "u_m_m_bankman" },
            { 0x76474545, "u_m_m_bikehire_01" },
            { 0x621E6BFD, "u_m_m_doa_01" },
            { 0x2A797197, "u_m_m_edtoh" },
            { 0x342333D3, "u_m_m_fibarchitect" },
            { 0x2B6E1BB6, "u_m_m_filmdirector" },
            { 0x45BB1666, "u_m_m_glenstank_01" },
            { 0xC454BCBB, "u_m_m_griff_01" },
            { 0xCE2CB751, "u_m_m_jesus_01" },
            { 0xACCCBDB6, "u_m_m_jewelsec_01" },
            { 0xE6CC3CDC, "u_m_m_jewelthief" },
            { 0x1C95CB0B, "u_m_m_markfost" },
            { 0x81F74DE7, "u_m_m_partytarget" },
            { 0x709220C7, "u_m_m_prolsec_01" },
            { 0xCE96030B, "u_m_m_promourn_01" },
            { 0x60D5D6DA, "u_m_m_rivalpap" },
            { 0xAC0EA5D8, "u_m_m_spyactor" },
            { 0x6C19E962, "u_m_m_streetart_01" },
            { 0x90769A8F, "u_m_m_willyfist" },
            { 0x2BACC2DB, "u_m_o_filmnoir" },
            { 0x46E39E63, "u_m_o_finguru_01" },
            { 0x9A1E5E52, "u_m_o_taphillbilly" },
            { 0x6A8F1F9B, "u_m_o_tramp_01" },
            { 0xF0AC2626, "u_m_y_abner" },
            { 0xCF623A2C, "u_m_y_antonb" },
            { 0xDA116E7E, "u_m_y_babyd" },
            { 0x5244247D, "u_m_y_baygor" },
            { 0x8B7D3766, "u_m_y_burgerdrug_01" },
            { 0x24604B2B, "u_m_y_chip" },
            { 0x2D0EFCEB, "u_m_y_cyclist_01" },
            { 0x85B9C668, "u_m_y_fibmugger_01" },
            { 0xC6B49A2F, "u_m_y_guido_01" },
            { 0xB3229752, "u_m_y_gunvend_01" },
            { 0xF041880B, "u_m_y_hippie_01" },
            { 0x348065F5, "u_m_y_imporage" },
            { 0x7DC3908F, "u_m_y_justin" },
            { 0xC8BB1E52, "u_m_y_mani" },
            { 0x4705974A, "u_m_y_militarybum" },
            { 0x5048B328, "u_m_y_paparazzi" },
            { 0x36E70600, "u_m_y_party_01" },
            { 0xDC59940D, "u_m_y_pogo_01" },
            { 0x7B9B4BC0, "u_m_y_prisoner_01" },
            { 0x855E36A3, "u_m_y_proldriver_01" },
            { 0x3C438CD2, "u_m_y_rsranger_01" },
            { 0x6AF4185D, "u_m_y_sbike" },
            { 0x9194CE03, "u_m_y_staggrm_01" },
            { 0x94AE2B8C, "u_m_y_tattoo_01" },
            { 0xAC4B4506, "u_m_y_zombie_01" }
        };

        foreach (KeyValuePair<string, string> model in animalModels)
        {
            //Displays dictionary of locations in menu
            UIMenuItem animalModelNames = new UIMenuItem(model.Key);
            animalMC.AddItem(animalModelNames);

            animalModelNames.Activated += (sender, args) =>
            {
                if (Game.Player.IsAlive)
                {
                    Game.Player.ChangeModel(model.Value);
                };
            };
        }

        foreach (KeyValuePair<UInt32, string> model in cutsceneModels)
        {
            //Displays dictionary of locations in menu
            UIMenuItem cutsceneModelNames = new UIMenuItem(model.Value);
            cutsceneMC.AddItem(cutsceneModelNames);

            cutsceneModelNames.Activated += (sender, args) =>
            {
                PlayerFunctions.ChangePedModel(model);
            };
        }

        foreach (KeyValuePair<UInt32, string> model in multiplayerModels)
        {
            //Displays dictionary of locations in menu
            UIMenuItem multiplayereModelNames = new UIMenuItem(model.Value);
            multiplayerMC.AddItem(multiplayereModelNames);

            multiplayereModelNames.Activated += (sender, args) =>
            {
                PlayerFunctions.ChangePedModel(model);
            };
        }

        foreach (KeyValuePair<UInt32, string> model in ambientFemaleModels)
        {
            //Displays dictionary of locations in menu
            UIMenuItem ambientFModelNames = new UIMenuItem(model.Value);
            ambientFemales.AddItem(ambientFModelNames);

            ambientFModelNames.Activated += (sender, args) =>
            {
                PlayerFunctions.ChangePedModel(model);
            };
        }

        foreach (KeyValuePair<UInt32, string> model in ambientMaleModels)
        {
            //Displays dictionary of locations in menu
            UIMenuItem ambientMModelNames = new UIMenuItem(model.Value);
            ambientMales.AddItem(ambientMModelNames);

            ambientMModelNames.Activated += (sender, args) =>
            {
                PlayerFunctions.ChangePedModel(model);
            };
        }

        foreach (KeyValuePair<UInt32, string> model in gangMaleModels)
        {
            //Displays dictionary of locations in menu
            UIMenuItem gangMaleModelNames = new UIMenuItem(model.Value);
            gangMaleMC.AddItem(gangMaleModelNames);

            gangMaleModelNames.Activated += (sender, args) =>
            {
                PlayerFunctions.ChangePedModel(model);
            };
        }

        foreach (KeyValuePair<UInt32, string> model in gangFemaleModels)
        {
            //Displays dictionary of locations in menu
            UIMenuItem gangFemaleModelNames = new UIMenuItem(model.Value);
            gangFemaleMC.AddItem(gangFemaleModelNames);

            gangFemaleModelNames.Activated += (sender, args) =>
            {
                PlayerFunctions.ChangePedModel(model);
            };
        }

        foreach (KeyValuePair<UInt32, string> model in scenarioFemaleModels)
        {
            //Displays dictionary of locations in menu
            UIMenuItem scenFemaleModelNames = new UIMenuItem(model.Value);
            scenarioFemaleMC.AddItem(scenFemaleModelNames);

            scenFemaleModelNames.Activated += (sender, args) =>
            {
                PlayerFunctions.ChangePedModel(model);
            };
        }

        foreach (KeyValuePair<UInt32, string> model in scenarioMaleModels)
        {
            //Displays dictionary of locations in menu
            UIMenuItem scenMaleModelNames = new UIMenuItem(model.Value);
            scenarioMaleMC.AddItem(scenMaleModelNames);

            scenMaleModelNames.Activated += (sender, args) =>
            {
                PlayerFunctions.ChangePedModel(model);
            };
        }

        foreach (KeyValuePair<UInt32, string> model in storyModels)
        {
            //Displays dictionary of locations in menu
            UIMenuItem storyModelNames = new UIMenuItem(model.Value);
            storyMC.AddItem(storyModelNames);

            storyModelNames.Activated += (sender, args) =>
            {
                PlayerFunctions.ChangePedModel(model);
            };
        }

        foreach (KeyValuePair<UInt32, string> model in otherModels)
        {
            //Displays dictionary of locations in menu
            UIMenuItem otherModelNames = new UIMenuItem(model.Value);
            otherMC.AddItem(otherModelNames);

            otherModelNames.Activated += (sender, args) =>
            {

                PlayerFunctions.ChangePedModel(model);

            };
        }
        #endregion

        #region Player Options
        //Fix Player Checkbox
        UIMenuItem fixPlayer = new UIMenuItem("Fix Player");
        playerOptions.AddItem(fixPlayer);
        playerOptions.OnItemSelect += (sender, item, index) =>
        {
            if (item == fixPlayer)
            {
                PlayerFunctions.fixPlayer();
            }
        };

        //Never Wanted Checkbox
        UIMenuItem neverWanted = new UIMenuCheckboxItem("Never Wanted", false);
        playerOptions.AddItem(neverWanted);
        playerOptions.OnCheckboxChange += (sender, item, checked_) =>
        {
            if (item == neverWanted)
            {
                PlayerFunctions.neverWanted();
            }
        };

        //Invicibility Checkbox
        UIMenuItem Invincibility = new UIMenuCheckboxItem("Invincibility", false);
        playerOptions.AddItem(Invincibility);
        playerOptions.OnCheckboxChange += (sender, item, checked_) =>
        {
            if (item == Invincibility)
            {
                PlayerFunctions.Invincibility();
            }
        };

        //Invisibility Checkbox
        UIMenuItem invisibility  = new UIMenuCheckboxItem("Invisibility ", false);
        playerOptions.AddItem(invisibility);
        playerOptions.OnCheckboxChange += (sender, item, checked_) =>
        {
            if (item == invisibility)
            {
                PlayerFunctions.Invisibility();
            }
        };

        //Super Jump Checkbox
        UIMenuItem superJump = new UIMenuCheckboxItem("Super Jump", false);
        playerOptions.AddItem(superJump);
        playerOptions.OnCheckboxChange += (sender, item, checked_) =>
        {
            if (item == superJump)
            {
                PlayerFunctions.SuperJump();
            }
        };

        //Fast Run Checkbox
        UIMenuItem fastRun = new UIMenuCheckboxItem("Fast Run", false);
        playerOptions.AddItem(fastRun);
        playerOptions.OnCheckboxChange += (sender, item, checked_) =>
        {
            if (item == fastRun)
            {
                PlayerFunctions.FastRun();
            }
        };

        //Fast swim Checkbox
        UIMenuItem fastSwim = new UIMenuCheckboxItem("Fast Swim", false);
        playerOptions.AddItem(fastSwim);
        playerOptions.OnCheckboxChange += (sender, item, checked_) =>
        {
            if (item == fastSwim)
            {
                PlayerFunctions.FastSwim();
            }
        };

        //Silent Movement Checkbox
        UIMenuItem noNoise = new UIMenuCheckboxItem("Silent Movement", false);
        playerOptions.AddItem(noNoise);
        playerOptions.OnCheckboxChange += (sender, item, checked_) =>
        {
            if (item == noNoise)
            {
                PlayerFunctions.NoNoise();
            }
        };

        //Unlimited Stamina
        UIMenuItem unlimitedStamina = new UIMenuCheckboxItem("Unlimited Stamina", false);
        playerOptions.AddItem(unlimitedStamina);
        playerOptions.OnCheckboxChange += (sender, item, checked_) =>
        {
            if (item == unlimitedStamina)
            {
                PlayerFunctions.UnlimitedStamina();
            }
        };

        //Unlimited Breath
        UIMenuItem unlimitedBreath = new UIMenuCheckboxItem("Unlimited Breath", false);
        playerOptions.AddItem(unlimitedBreath);
        playerOptions.OnCheckboxChange += (sender, item, checked_) =>
        {
            if (item == unlimitedBreath)
            {
                PlayerFunctions.UnlimitedBreath();
            }
        };

        //Unlimited ability
        UIMenuItem unlimitedAbility = new UIMenuCheckboxItem("Unlimited Ability", false);
        playerOptions.AddItem(unlimitedAbility);
        playerOptions.OnCheckboxChange += (sender, item, checked_) =>
        {
            if (item == unlimitedAbility)
            {
                PlayerFunctions.UnlimitedAbility();
            }
        };
        #endregion

        #region Money Menu

        //Set Money
        UIMenuItem setMoney = new UIMenuItem("Enter an Amount");
        moneyOptions.AddItem(setMoney);
        moneyOptions.OnItemSelect += (sender, item, index) =>
        {
            if (item == setMoney)
            {
                PlayerFunctions.setMoney();
            }
        };

        //Add Money
        UIMenuItem addMoney = new UIMenuItem("Add $1,000,000");
        moneyOptions.AddItem(addMoney);
        moneyOptions.OnItemSelect += (sender, item, index) =>
        {
            if (item == addMoney)
            {
                PlayerFunctions.AddMoney();
            }
        };
        #endregion
    }
}
