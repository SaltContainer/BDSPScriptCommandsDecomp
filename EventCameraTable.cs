using System;
using System.Collections.Generic;
using System.Text;

namespace BDSP
{
	public class EventCameraTable : ScriptableObject // TypeDefIndex: 3709
	{
		// Fields
		public EventCameraCurveTable curve; // 0x18
		public EventCameraData[] table; // 0x20

		public EventCameraData Item { get; }

		public EventCameraData get_Item(int index) {
			return table[index];
		}
	}
}
