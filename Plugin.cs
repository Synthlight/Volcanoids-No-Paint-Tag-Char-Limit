using System.Reflection;
using Base_Mod;
using HarmonyLib;
using JetBrains.Annotations;
using TMPro;

namespace No_Paint_Tag_Char_Limit {
    [UsedImplicitly]
    public class Plugin : BaseGameMod {
        protected override bool UseHarmony => true;
    }

    [HarmonyPatch]
    [UsedImplicitly]
    public static class RemovePaintTagLimitPatch {
        [HarmonyTargetMethod]
        [UsedImplicitly]
        public static MethodBase TargetMethod() {
            return typeof(PaintCameraController).GetMethod("Awake", BindingFlags.NonPublic | BindingFlags.Instance);
        }

        [UsedImplicitly]
        [HarmonyPostfix]
        public static void Postfix(ref TMP_InputField ___m_tag) {
            ___m_tag.characterLimit = int.MaxValue;
        }
    }
}