using System;
using BepInEx;
using BepInEx.Unity.Mono;
using HarmonyLib;
using UnityEngine;


namespace Snowman_
{
    [BepInPlugin(pluginGuid, pluginName, pluginversion)]
    public class Mod : BaseUnityPlugin
    {
        public const string pluginGuid = "kestrel.iamyourbeast.snowmanpercent";
        public const string pluginName = "Snowman%";
        public const string pluginversion = "1.1.0";

        public void Awake() {

            Logger.LogInfo("Hiiiiiiiiiiii :3");
            Harmony harmony = new Harmony(pluginGuid);
            harmony.PatchAll();
        }
    }

    [HarmonyPatch(typeof(Snowman), "Kill")]
    public class PatchSnowman
    {
        [HarmonyPostfix]
        public static void Postfix() {
            float time = GameManager.instance.levelController.GetCombatTimer().GetTime();
            GameManager.instance.player.GetHUD().GetNotificationPopUp().TriggerPopUp($"Snowman%: {time:0.00}", HUDNotificationPopUp.ThreatLevel.High);
        }
    }
    

}
