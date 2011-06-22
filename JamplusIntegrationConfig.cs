using System;

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
		
		// Data Members
		private static JamplusIntegrationConfig instance = null;
	}
}

