// 
// JamplusOptionsPanel.cs
//  
// Author:
//       natosha <${AuthorEmail}>
// 
// Copyright (c) 2011 natosha
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
using Gtk;
using MonoDevelop.Ide.Gui.Dialogs;
using MonoDevelop.Projects;

namespace MonoDevelop.Jamplus
{
	public partial class JamplusOptionsPanel : ItemOptionsPanel
	{
		JamplusOptionsPanelWidget widget;

		public JamplusOptionsPanel ()
		{
		}

		public override Widget CreatePanelWidget()
		{
			Project project = ConfiguredProject;
			JamplusOptions data = project.ExtendedProperties ["MonoDevelop.Jamplus.JamplusInfo"] as JamplusOptions;
			
			JamplusOptions tmpData = null;
			if (data != null) {
				tmpData = (JamplusOptions) data.Clone ();
			}
			return (widget = new JamplusOptionsPanelWidget (project, tmpData));
		}
		
		public override bool ValidateChanges ()
		{
			return widget.ValidateChanges (ConfiguredProject);
		}
		
		public override void ApplyChanges ()
		{
			widget.Store (ConfiguredProject);
		}
	}
}

