using BepInEx;
using BrutalAPI;
using HarmonyLib;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BO4CoinsSpriteFix
{
    [BepInPlugin(MOD_GUID, MOD_NAME, MOD_VERSION)]
    [HarmonyPatch]
    public class Plugin : BaseUnityPlugin
    {
        public const string MOD_GUID = "SpecialAPI.4CoinsSpriteFix";
        public const string MOD_NAME = "4 Coins Sprite Fix";
        public const string MOD_VERSION = "1.0.0";

        public static Sprite new4CoinsSprite;

        public void Awake()
        {
            new4CoinsSprite = ResourceLoader.LoadSprite("4coins");

            var harmony = new Harmony(MOD_GUID);
            harmony.PatchAll();
        }

        [HarmonyPatch(typeof(SpritesDataBaseSO), nameof(SpritesDataBaseSO.GetCoinSprite))]
        [HarmonyPrefix]
        public static bool Replace4CoinsSprite_Postfix(ref Sprite __result, int amount)
        {
            if (amount != 4)
                return true;

            __result = new4CoinsSprite;
            return false;
        }
    }
}
