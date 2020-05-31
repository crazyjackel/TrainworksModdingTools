﻿using System;
using System.Collections.Generic;
using System.Text;
using HarmonyLib;
using MonsterTrainModdingAPI.Managers;

namespace MonsterTrainModdingAPI.Patches
{
    [HarmonyPatch(typeof(CardPoolHelper), "GetCardsForClass")]
    [HarmonyPatch(new Type[] { typeof(CardPool), typeof(ClassData), typeof(CollectableRarity), typeof(CardPoolHelper.RarityCondition), typeof(bool) })]
    class AddCustomCardToPoolPatch
    {
        static void Postfix(ref List<CardData> __result, ref CardPool cardPool, ClassData classData, CollectableRarity paramRarity, CardPoolHelper.RarityCondition rarityCondition, bool testRarityCondition)
        {
            List<CardData> customCardsToAddToPool = CustomCardManager.GetCardsForPoolSatisfyingConstraints(cardPool.GetInstanceID(), classData, paramRarity, rarityCondition, testRarityCondition);
            __result.AddRange(customCardsToAddToPool);
        }
    }
}
