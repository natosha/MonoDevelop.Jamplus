//
// JamplusIntegrationConfig.cs
//  
// Author:
//       Na'Tosha Bard <natosha@unity3d.com;natosha@gmail.com>
// 
// Copyright (c) 2011 Na'Tosha Bard
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.Collections.Generic;
using MonoDevelop.Projects;

namespace MonoDevelop.Jamplus
{
	public class JamplusIntegrationConfig
	{
		public JamplusIntegrationConfig ()
		{
		}
		
		public static JamplusIntegrationConfig getInstance()
		{
			if(null == instance)
			{
				instance = new MonoDevelop.Jamplus.JamplusIntegrationConfig();
			}
			return instance;
		}
		
		public static void setOptions(JamplusOptions options)
		{
			options = null;
		}
		
		public static JamplusOptions getOptions()
		{
			return options;
		}
		
		// Data Members
		private static JamplusIntegrationConfig instance = null;
		private static JamplusOptions options = null;
	}
	
	public class JamplusOptions
	{
		public JamplusOptions()
		{
		}
		
		public void setIntegrationEnabled(bool integrationEnabled)
		{
			this.integrationEnabled = integrationEnabled;
		}
		
		public bool getIntegrationEnabled()
		{
			return this.integrationEnabled;
		}
		
		public void addCommand(string configurationName, string jamplusCommand)
		{
			configurationJamplusCommmands.Add(configurationName, jamplusCommand);
		}
		
		public string getCommand(string configurationName)
		{
			if(configurationJamplusCommmands.ContainsKey(configurationName))
			{
				return configurationJamplusCommmands[configurationName];
			} else {
				return "";
			}
		}
		
		public JamplusOptions Clone()
		{
			JamplusOptions retval = new JamplusOptions();
			retval.setIntegrationEnabled(this.getIntegrationEnabled());
			foreach(KeyValuePair<string, string> pair in configurationJamplusCommmands)
			{
				retval.addCommand(pair.Key, pair.Value);	
			}
			return retval;
		}
		
		// Data Members
		private bool integrationEnabled = false;
		Dictionary<string, string> configurationJamplusCommmands =
			new Dictionary<string, string>();
	}
}

