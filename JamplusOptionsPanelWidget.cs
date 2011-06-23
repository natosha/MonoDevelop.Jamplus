// 
// JamplusOptionsPanelWidget.cs
//  
// Author:
//       builduser <${AuthorEmail}>
// 
// Copyright (c) 2011 builduser
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
using System.Collections;
using MonoDevelop.Projects;

using Gtk;

namespace MonoDevelop.Jamplus
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class JamplusOptionsPanelWidget : Gtk.Bin
	{
		public JamplusOptionsPanelWidget (Project project, JamplusOptions tmpData) : this()
		{
			this.data = tmpData;
			this.project = project;
			if(null == data)
			{
				data = new JamplusOptions();
				this.IntegrationEnabledCheckbox.Active = false;
			}
			ConfigurationsComboBox.
			foreach(String configuration in project.GetConfigurations())
			{
			
			}
		}

		public JamplusOptionsPanelWidget()
		{
			this.Build();
		}
		
		public bool ValidateChanges (Project project)
		{
			data.setIntegrationEnabled(IntegrationEnabledCheckbox.Active);
			Console.Out.WriteLine("Called Validate Changes!\n");
			JamplusIntegrationConfig.setOptions(data);
			return true;
		}
		
		public void Store (Project project)
		{
			Console.Out.WriteLine("FIXME: Implement Store!\n");
		}
		
		protected virtual void enableJamplusIntegrationButtonClicked (object sender, System.EventArgs e)
		{
			bool sensitivity = IntegrationEnabledCheckbox.Active;
			ConfigurationsComboBox.Sensitive = sensitivity;
			JamplusCommandLabel.Sensitive = sensitivity;
			CommandLabel.Sensitive = sensitivity;
		}
		
		
		//Data Members
		JamplusOptions data = null;
		Project project = null;
	}
}

