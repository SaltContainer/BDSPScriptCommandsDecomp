using System;
using System.Collections.Generic;
using System.Text;

namespace BDSP
{
	public class EvData : ScriptableObject
	{
		public List<Script> Scripts;
		public List<string> StrList;

		public string GetString(int index)
		{
			if (index < StrList.Count)
            {
				if (StrList.Count <= (uint)index)
				{
					throw new ArgumentOutOfRangeException();
				}
				return StrList[index];
			}
			return null;
		}

		[Serializable]
		public class Script
		{
			public string Label;
			public List<Command> Commands;
		}

		[Serializable]
		public class Command
		{
			public List<Aregment> Arg;
		}

		[Serializable]
		public struct Aregment
		{
			public ArgType argType;
			public int data;
		}

		public enum ArgType
		{
			Command = 0,
			Float = 1,
			Work = 2,
			Flag = 3,
			SysFlag = 4,
			String = 5
		}
	}
}
