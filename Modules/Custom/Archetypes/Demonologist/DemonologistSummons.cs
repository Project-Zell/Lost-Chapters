using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Utils.Assets;
using Kingmaker.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.View;
using Kingmaker.Visual.Particles;
using LostChapters.Modules.Custom.Archetypes.Demonologist.SummonAbilities;
using UnityEngine;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist;

internal class DemonologistSummons
{
    internal static void Configure()
    {
        SummonDemonVisual.Configure();
        
        SummonDemon1Feature.Configure();
    }

    internal static void Configure(string unitName, string newPrefabID, string sourcePrefabID, string dismemberFxID)
    {
        AssetTool.RegisterDynamicPrefabLink(assetId: newPrefabID, source: sourcePrefabID, ModifyGameObject);

        void ModifyGameObject(GameObject unit)
        {
            unit.name = $"{Main.ModName} {unitName}";

            var disaperFx = "ab292bc1fd040844b8165bfb6a3648e5";
            AssetTool.RegisterDynamicPrefabLink(assetId: dismemberFxID, source: disaperFx, ModifyDismember);

            void ModifyDismember(GameObject gameObject)
            {
                gameObject.AddComponent<FxDestroyOnStop>();
                var dismember = gameObject.AddComponent<DismemberUnitFX>(fx =>
                {
                    fx.Delay = 0.98f;
                });

                dismember.Init(unit.GetComponentInChildren<UnitEntityView>());
            }
        }
    }

    internal void Configure3()
    {
        //1Drench
        //2Babau
        //3Brimorak
        //4Gallu
        //5Glabrezu
        //6Kalavakus
        //7Nabasu
        //8Painajai
        //9schir
        //10shadowdemon
        //11Lilitu
        //12quasit


        //Lvl1 - Dretch
        //Lvl2 - Quasit
        //Lvl3 - Schir
        //Lvl4 - Babau
        //Lvl5 - Nabasu
        //Lvl6 - Kalavakus
        //Lvl7 -
        //Lvl8 - Gallu
        //Lvl9 - Balor
        
        //Lvl20 - Glabrezu




    }

    internal class DretchSummon
    {

    }
}
