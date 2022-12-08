using System;
using System.Collections.Generic;
using System.Text;

namespace BDSP.Dpr.EvScript
{
	public class EvScriptData
	{
		public EvData EvData;
		public int LabelIndex;
		public int CommandIndex;
		public int RetIndex;

		public EvData.Script GetScript;

		public EvData.Script get_GetScript()
		{
			if (LabelIndex > EvData.Scripts.Count)
			{
				throw new ArgumentOutOfRangeException();
			}
			return EvData.Scripts[LabelIndex];
		}

		public EvScriptData(EvData ev)
		{
			EvData = ev;
		}

		public int FindLabelIndex(string label)
		{
			// This is presumed. The ghidra decomp is so hard to understand here
			return EvData.Scripts.FindIndex(s => s.Label == label);
		}

		public EvData.Script FindLabelScript(string label)
		{
			// This is presumed. The ghidra decomp is so hard to understand here
			return EvData.Scripts.Find(s => s.Label == label);
		}

		public void Destroy()
		{
			EvData = null;
		}
	}
}
