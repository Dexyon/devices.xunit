﻿using System.Reflection;
using Xunit.Runners.UI;

using test.xunit.pcltestlib;



namespace test.xunit.runner.wpa81
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public sealed partial class App : RunnerApplication
    {
        protected override void OnInitializeRunner()
        {
            // tests can be inside the main assembly
            AddTestAssembly(GetType().GetTypeInfo().Assembly);
            // otherwise you need to ensure that the test assemblies will 
            // become part of the app bundle
            AddTestAssembly(typeof(PortableTests).GetTypeInfo().Assembly);
        }
    }
}