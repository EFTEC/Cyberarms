using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cyberarms.IntrusionDetection.Shared;
using System.Diagnostics;

namespace Cyberarms.IntrusionDetection.Shared.Test {
    [TestClass]
    public class IddsConfigTest {

        //[TestMethod]
        //public void IsActivatedTest() {
        //    try {
        //        bool activated = IddsConfig.Instance.IsActivated;
        //    } catch (ApplicationException ex) {
        //        Debug.Print("Hardware ID: {0}", IddsConfig.Instance.HardwareId);
        //        Debug.Print("Activation ID: {0}", IddsConfig.Instance.ActivationId);
        //        if(ex.InnerException is MissingFieldException) return;
        //    }
            
        //    Assert.Fail("Activation did not report error!");
        //}


        [TestMethod]
        public void ActivateTrialKeyTest() {
            Assert.Fail("Not implemented");
        }

        [TestMethod]
        public void VariousProductActivationTest() {
            Assert.Fail("Not implemented");
        }

        [TestMethod]
        public void CreateEditionKeyTest() {
            Assert.Fail("Not implemented");
        }

        [TestMethod]
        public void ActivateEditionKeyTest() {
            Assert.Fail("Not implemented");
        }

        [TestMethod]
        public void SaveConfigTest() {
            IddsConfig.Instance.ApplicationPath = @"c:\\temp\\";
            IddsConfig.Instance.ConfigVersionNumber = 1;
            IddsConfig.Instance.CyberSheriffContributor = true;
            IddsConfig.Instance.Edition = "PRO";
            IddsConfig.Instance.Expires = DateTime.MaxValue;
            IddsConfig.Instance.HardLockAttempts = 10;
            IddsConfig.Instance.HardLockTimeHours = 2;
            IddsConfig.Instance.LockForever = false;
            IddsConfig.Instance.NotificationEmailAddress = "maxemilian.hilbrand@readytomarket.net";
            IddsConfig.Instance.SenderEmailAddress = "idds@localhost";
            IddsConfig.Instance.SendInfoMail = true;
            IddsConfig.Instance.SmtpPassword = "smtpPasss";
            IddsConfig.Instance.SmtpPort = 25;
            IddsConfig.Instance.SmtpRequiresAuthentication = false;
            IddsConfig.Instance.SmtpServer = "localhost";
            IddsConfig.Instance.SmtpUsername = "smtpuser";
            IddsConfig.Instance.SoftLockAttempts = 3;
            IddsConfig.Instance.SoftLockTimeMinutes = 20;
            IddsConfig.Instance.UseSafeNetworkList = true;
            IddsConfig.Instance.WebBasedMonitoring = true;
            
            IddsConfig.Instance.Save();

        }

        //[TestMethod]
        //public void CreateAgentConfigTest() {
        //    IddsConfig.PluginDirectory = "test";
        //    IddsConfig.Instance.ApplicationPath = @"c:\\temp\\";
        //    Cyberarms.IntrusionDetection.Api.Plugin.AgentConfigurationBase agentConfig = new Cyberarms.IntrusionDetection.Api.Plugin.AgentConfigurationBase();
        //    agentConfig.AgentName = "TestAgent";
        //    agentConfig.AssemblyName = "TestDom.TestAgent";
        //    agentConfig.ConfigurationSettingsTypeName = "ConfigType";
        //    agentConfig.Enabled = false;
        //    agentConfig.FileName = "TestAgent.dll";
        //    agentConfig.HardLockAttempts = 100;
        //    agentConfig.HardLockDurationHrs = 10;
        //    agentConfig.NeverUnlock = true;
        //    agentConfig.OverwriteConfiguration = true;
        //    agentConfig.PluginConfigurationXml = "<xml>";
        //    agentConfig.SoftLockAttempts = 20;
        //    agentConfig.SoftLockDurationMins = 200;
        //    //IddsConfig.Instance.WriteAgentConfiguration(agentConfig);
            
        //}



        [TestMethod]
        public void ReadWriteAppConfigTest() {
            IddsConfig.Instance.ApplicationPath = @"c:\\temp\\";
            
            IddsConfig.Instance.GetConfigValue("TestConfigSetting1");
            IddsConfig.Instance.SetConfigValue("TestConfigSetting1", "Value1");
            IddsConfig.Instance.SetConfigValue("TestConfigSetting2", "Value2");
            IddsConfig.Instance.SaveAppConfig();
            IddsConfig.Instance.AppConfig.Clear();
            IddsConfig.Instance.LoadAppConfig();
            Assert.AreEqual("Value1", IddsConfig.Instance.GetConfigValue("TestConfigSetting1"));
            Assert.AreEqual("Value2", IddsConfig.Instance.GetConfigValue("TestConfigSetting2"));
            IddsConfig.Instance.AppConfig.Remove("TestConfigSetting1");
            IddsConfig.Instance.AppConfig.Remove("TestConfigSetting2");
            IddsConfig.Instance.SaveAppConfig();
        }

        [TestMethod]
        public void ConfigIsInSafeNetworkTest() {
            Database.Instance.Configure(@"c:\\temp");
            IddsConfig.Instance.ApplicationPath = @"c:\\temp";
            
            IddsConfig.Instance.SafeNetworks.Add(new IddsConfig.CSafeNetwork("192.168.1.1", "255.255.255.255"));
            Assert.IsTrue(IddsConfig.Instance.IsInSafeNetwork("192.168.1.1"));
            Assert.IsFalse(IddsConfig.Instance.IsInSafeNetwork("192.168.1.2"));
            IddsConfig.Instance.SafeNetworks.Add(new IddsConfig.CSafeNetwork("192.168.1.0", "255.255.255.0"));
            Assert.IsTrue(IddsConfig.Instance.IsInSafeNetwork("192.168.1.1"));
            Assert.IsTrue(IddsConfig.Instance.IsInSafeNetwork("192.168.1.2"));
        }
    }
}
