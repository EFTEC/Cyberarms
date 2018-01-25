using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Cyberarms.IntrusionDetection.Api.Plugin;

namespace Cyberarms.IntrusionDetection {
    internal class Agents : List<Agent> {
        internal void Load(string assemblyName) {
            Type pInterfaceType = typeof(IAgentPlugin);
            Assembly assembly;
            try {
                assembly = Assembly.LoadFile(assemblyName);
                foreach (Type type in assembly.GetTypes()) {
                    if (type.IsPublic)              // Just the public ones
	                {
                        if (!type.IsAbstract) {    // ignore abstract classes
                            Type typeInterface = type.GetInterface(pInterfaceType.ToString(), false);

                            //Make sure the interface we want to use actually exists
                            if (typeInterface != null) {
                                try {
                                    IAgentPlugin objectInstance = (IAgentPlugin)Activator.CreateInstance(type);
                                    if (objectInstance != null) {
                                        Agent orange = new Agent(assembly.FullName);
                                        orange.Assembly = objectInstance;
                                        orange.Name = type.Name;
                                        this.Add(orange);
                                    }
                                } catch (Exception exception) {
                                    System.Diagnostics.Debug.WriteLine(exception);
                                    throw exception;
                                }
                            }

                            typeInterface = null;
                        }
                    }
                }
            } catch (Exception ex) {
                throw ex;
            }
            assembly = null;
        }

        internal void LoadAll(string configFilename) {
        }
    }
}
