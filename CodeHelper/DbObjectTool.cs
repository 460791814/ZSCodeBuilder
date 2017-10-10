using System;

namespace CodeHelper
{
	public class DbObjectTool
	{
		public static string DefaultValToCS(string DefaultVal)
		{
			//DefaultVal.Substring(0, 2) == "N'";
			//DefaultVal == "N'";
			return DefaultVal;
		}
	}
}
