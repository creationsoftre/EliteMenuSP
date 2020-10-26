using System.Collections.Generic;
using GTA;
using GTA.Native;
using GTA.Math;
using NativeUI;


partial class MainMenu : Script
{
    public UIMenu weatherMenu;
    public UIMenu cloudMenu;

    private void WeatherMenu()
    {
        #region Weather Types
        weatherMenu = modMenuPool.AddSubMenu(mainMenu, "Weather");

        Dictionary<string, string> weatherOptions = new Dictionary<string, string>()
        {
            {"Extra Sunny", "EXTRASUNNY"},
            {"Clear", "CLEAR"},
            {"Smog", "SMOG"},
            {"Clouds", "CLOUDS"},
            {"Foggy", "FOGGY"},
            {"Overcast", "OVERCAST"},
            {"Rain", "RAIN"},
            {"Thunder", "THUNDER"},
            {"Clearing","CLEARING"},
            {"Neutral", "NEUTRAL"},
            {"Snow", "SNOW"},
            {"Blizzard", "BLIZZARD"},
            {"Light Snow", "SNOWLIGHT"},
            {"Christmas", "XMAS"},
            {"Halloween", "HALLOWEEN"},


        };
        foreach (KeyValuePair<string, string> weatherType in weatherOptions)
        {
            //Displays dictionary of locations in menu
            UIMenuItem WeatherItems = new UIMenuItem(weatherType.Key);

            WeatherItems.Activated += (sender, args) =>
            SetWeather(weatherType);
            weatherMenu.AddItem(WeatherItems);
        }
        #endregion

        #region cloud Types
        cloudMenu = modMenuPool.AddSubMenu(weatherMenu, "Cloud Options");

        Dictionary<string, string> listOfClouds = new Dictionary<string, string>()
        {
            {"Stratus", "altostratus"},
            {"Cirrus", "Cirrus"},
            {"cirrocumulus", "cirrocumulus"},
            {"Clear", "Clear 01"},
            {"Cloudy", "Cloudy 01"},
            {"Contrails", "Contrails"},
            {"Horizon", "Horizon"},
            {"horizon Band Type 1", "horizonband1"},
            {"horizon Band Type 2", "horizonband2"},
            {"horizon Band Type 3", "horizonband3"},
            {"Horsey", "horsey"},
            {"Nimbus", "Nimbus"},
            {"Rain", "RAIN"},
            {"Snowy", "Snowy 01"},
            {"Stromy Type 1", "Stormy 01"},
            {"stratoscumulus", "stratoscumulus"},
            {"Stripey", "Stripey"},
            {"Shower", "shower"},
            {"Wispy", "Wispy"},
        };

        foreach (KeyValuePair<string, string> cloudType in listOfClouds)
        {
            //Displays dictionary of locations in menu
            UIMenuItem WeatherItems = new UIMenuItem(cloudType.Key);

            WeatherItems.Activated += (sender, args) =>
            setCloudType(cloudType);
            cloudMenu.AddItem(WeatherItems);
        }
        #endregion

        #region Snow On Ground
        UIMenuItem setSnowOnGround = new UIMenuCheckboxItem("Snow On Ground", false);
        weatherMenu.AddItem(setSnowOnGround);
        weatherMenu.OnCheckboxChange += (sender, item, checked_) =>
        {
            if (item == setSnowOnGround)
            {
                if(checked_)
                {
                    MemoryAccess.SetSnowRendered(true);
                }
                else
                {
                    MemoryAccess.SetSnowRendered(false);
                }
            }
           
        };
        #endregion

        #region Black Out
        UIMenuItem setBlackOut = new UIMenuCheckboxItem("Black Out", false);
        weatherMenu.AddItem(setBlackOut);
        weatherMenu.OnCheckboxChange += (sender, item, checked_) =>
        {
            if (item == setBlackOut)
            {
                if (checked_)
                {
                    Function.Call(Hash._SET_BLACKOUT, true);
                }
                else
                {
                    Function.Call(Hash._SET_BLACKOUT, false);
                }
            }

        };
        #endregion

        #region Wind Speeds
        List<dynamic> listOfWindSpeeds = new List<dynamic>()
        {
            0f,0.1f,0.2f,0.3f,0.4f,0.5f,0.6f,0.7f,0.8f,0.9f,1f,
            1.1f,1.2f,1.3f,1.4f,1.5f,1.6f,1.7f,1.8f,1.9f,2f,
            2.1f,2.2f,2.3f,2.4f,2.5f,2.6f,2.7f,2.8f,2.9f,3f,
            3.1f,3.2f,3.3f,3.4f,3.5f,3.6f,3.7f,3.8f,3.9f,
            4f,4.1f,4.2f,4.3f,4.4f,4.5f,4.6f,4.7f,4.8f,4.9f,
            5f,5.1f,5.2f,5.3f,5.4f,5.5f,5.6f,5.7f,5.8f,5.9f,
            6f,6.1f,6.2f,6.3f,6.4f,6.5f,6.6f,6.7f,6.8f,6.9f,
            7f,7.1f,7.2f,7.3f,7.4f,7.5f,7.6f,7.7f,7.8f,7.9f,
            8f,8.1f,8.2f,8.3f,8.4f,8.5f,8.6f,8.7f,8.8f,8.9f,9f,
            9.1f,9.2f,9.3f,9.4f,9.5f,9.6f,9.7f,9.8f,9.9f,
            10f,10.1f,10.2f,10.3f,10.4f,10.5f,10.6f,10.7f,
            10.8f,10.9f,11f,11.1f,11.2f,11.3f,11.4f,11.5f,
            11.6f,11.7f,11.8f,11.9f,12f,
        };

        UIMenuListItem windList = new UIMenuListItem("Wind Speed", listOfWindSpeeds, 0);
        weatherMenu.AddItem(windList);

        weatherMenu.OnListChange += (sender, listItem, index) =>
        {
            if (listItem == windList)
            {
                int listIndex = windList.Index;
                float currentWindSpeed = listOfWindSpeeds[index];
                Function.Call(Hash.SET_WIND_SPEED, currentWindSpeed);
            }
        };
        #endregion

        #region Rain Level
        List<dynamic> listOfRainLevels = new List<dynamic>()
        {
            -1f,-0.9f,-0.8f,-0.7f,-0.6f,-0.5f,-0.4f,-0.3f,-0.2f,-0.1f,
            0f,0.1f,0.2f,0.3f,0.4f,0.5f,0.6f,0.7f,0.8f,0.9f,1f,
        };

        UIMenuListItem rainList = new UIMenuListItem("Rain Level", listOfRainLevels, 0);
        weatherMenu.AddItem(rainList);

        weatherMenu.OnListChange += (sender, listItem, index) =>
        {
            if (listItem == rainList)
            {
      
                int listIndex = rainList.Index;
                float currentRainLevel = listOfRainLevels[index];
                Function.Call(Hash._SET_RAIN_FX_INTENSITY, currentRainLevel);
                
            }
        };
        #endregion

        #region gravity level
        List<dynamic> listOfGravityLevels = new List<dynamic>()
        {
            0,1,2,3
        };

        UIMenuListItem gravityList = new UIMenuListItem("Gravity Level", listOfGravityLevels, 0);
        weatherMenu.AddItem(gravityList);

        weatherMenu.OnListChange += (sender, listItem, index) =>
        {
            if (listItem == gravityList)
            {
                int listIndex = gravityList.Index;
                int currentGravityLevel = listOfGravityLevels[index];
                Function.Call(Hash.SET_GRAVITY_LEVEL, currentGravityLevel);
            }
        };
        #endregion

        #region Water Intensity
        List<dynamic> listOfWaveIntens = new List<dynamic>();

        float getWaveIntensity = 0f;
        unsafe
        {
            Function.Call(Hash._0x2B2A2CC86778B619, &getWaveIntensity);
        }
        for (float i = 0.0f; i <= 200.00; i+= 1.0f)
        {
            listOfWaveIntens.Add(i);
        }

        UIMenuListItem WaveIntensityList = new UIMenuListItem("Wave Intensity", listOfWaveIntens, 0);
        weatherMenu.AddItem(WaveIntensityList);

        weatherMenu.OnListChange += (sender, listItem, index) =>
        {
            if (listItem == WaveIntensityList)
            {
                float listIndex = WaveIntensityList.Index;
                float setWaterIntensity = listOfWaveIntens[index];
                toggleWaterIntensity(setWaterIntensity);
            }
        };
        #endregion
    }

    private void SetWeather(KeyValuePair<string, string> weatherType)
    {
        Function.Call(Hash.SET_WEATHER_TYPE_NOW, weatherType.Value);
    }

    private void setCloudType(KeyValuePair<string, string> cloudType)
    {
        Function.Call(Hash._SET_CLOUD_HAT_TRANSITION, cloudType.Value, 0.0f);
    }

    private void toggleWaterIntensity(float setWaterIntensity)
    {
        Function.Call(Hash._0xB96B00E976BE977F, setWaterIntensity);
        
    }
}
