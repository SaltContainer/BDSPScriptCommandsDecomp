using System;
using System.Collections.Generic;
using System.Text;

namespace BDSP
{
	public class EventCameraData : ScriptableObject // TypeDefIndex: 3697
	{
		// Fields
		public float baseTime; // 0x18
		public float timeScale; // 0x1C
		public int length; // 0x20
		public List<EventCameraData.EventType> type; // 0x28
		public List<bool> isEnd; // 0x30
		public List<float> startTime; // 0x38
		public List<EventCameraData.FadeData> fadeData; // 0x40
		public List<EventCameraData.PathData> pathData; // 0x48
		public List<EventCameraData.DofData> dofData; // 0x50
		public List<EventCameraData.PathData2> pathData2; // 0x58
		public List<EventCameraData.RotationData> rotationData; // 0x60
		public List<EventCameraData.ReturnDefault> returnDefault; // 0x68
		public List<EventCameraData.ReturnDefault> returnDefaultRotate; // 0x70
		public List<EventCameraData.FovData> fovData; // 0x78
	}
}