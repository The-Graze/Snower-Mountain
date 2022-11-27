using BepInEx;
using System;
using System.IO;
using System.Reflection;
using UnityEngine;
using Utilla;
namespace Snower_Mountain
{
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        bool inRoom;
        GameObject snowbundle;
        void Start()
        {
            Utilla.Events.GameInitialized += OnGameInitialized;
        }
        void OnGameInitialized(object sender, EventArgs e)
        {
            Stream str = Assembly.GetExecutingAssembly().GetManifestResourceStream("Snower-Mountain.Assets.snowbundle");
            AssetBundle bundle = AssetBundle.LoadFromStream(str);
            GameObject powder = bundle.LoadAsset<GameObject>("snowbundle");
            snowbundle = Instantiate(powder);
            GameObject.Find("Level/mountain/Geometry/mountainside").GetComponent<MeshRenderer>().material = GameObject.Find("snowbundle(Clone)/3D snow").GetComponent<Renderer>().material;
            GameObject.Find("snowbundle(Clone)").transform.SetParent(GameObject.Find("Level/mountain").transform, true);
        }

    }
}
