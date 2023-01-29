﻿using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine.XR;

namespace SubmersedVR
{
    // Main plguin/entry point of the mod
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class SubmersedVR : BaseUnityPlugin
    {
        public static ManualLogSource logger;
        public static SubmersedVR instance;

        private void Awake()
        {
            if (!XRSettings.enabled) {
                Logger.LogWarning($"Game was not started in VR. Don't load and apply {PluginInfo.PLUGIN_NAME} patches.");
                return;
            }
            Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);
            harmony.PatchAll();
            Logger.LogWarning($"Applying {PluginInfo.PLUGIN_NAME} patches applied");

            logger = Logger;
            instance = this;

            // TODO: Reinit SteamVR?
        }
    }
}