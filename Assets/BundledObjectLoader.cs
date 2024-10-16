﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BundledObjectLoader : MonoBehaviour
{   public string assetName = "Robotic";
    public string bundleName = "testbundle";
    // Start is called before the first frame update
    void Start()
    {
        AssetBundle localAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, bundleName));
        if (localAssetBundle == null) 
        { 
            Debug.LogError("Failed to load AssetBundle!");
            return; 
        }
        GameObject asset = localAssetBundle.LoadAsset<GameObject>(assetName);
        Instantiate(asset);
        localAssetBundle.Unload(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
