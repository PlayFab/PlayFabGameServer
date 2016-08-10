using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;
using System.Collections.Generic;

public class MainContextView : ContextView
{
    public List<StrangePackage> Packages = new List<StrangePackage>();

    void Awake()
    {
        context = new MainContext(this, true);
        context.Start();
        DontDestroyOnLoad(gameObject);
    }
}