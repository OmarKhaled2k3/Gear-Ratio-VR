﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BundleWebLoader : MonoBehaviour
{
    public string bundleUrl = "http://localhost/assetbundles/testbundle";
    public string assetName = "Robotic";
    // Start is called before the first frame update
    IEnumerator Start()
    {
        using (WWW web = new WWW(bundleUrl)) 
        {
            yield return web;
            AssetBundle remoteAssetBundle = web.assetBundle;
            if (remoteAssetBundle == null) 
            { 
                Debug.LogError("Failed to download AssetBundle!");
                yield break; 
            } 
            Instantiate(remoteAssetBundle.LoadAsset(assetName));
            remoteAssetBundle.Unload(false); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
