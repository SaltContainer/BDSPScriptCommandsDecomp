using BDSP.Dpr.EvScript;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace BDSP
{
	public class FieldObjectEntity : BaseEntity
	{
		public Vector3 moveVector; // 0x70
		public bool isExtruded; // 0x7C
		public bool isLanding; // 0x7D
		private Vector3 oldMoveVector; // 0x80
		private FieldObjectRouteMove _routeMove; // 0x90
		public bool IsIgnorePlayerCollision; // 0x98
		private EvEntityCommand _evEntityCmd; // 0xA0
		private Vector2Int oldGridPosition; // 0xA8
		public Vector3[] logPosition; // 0xB0
		public byte logcount; // 0xB8
		private bool _scaleChangeFlag; // 0xB9
		private float _scaleStart; // 0xBC
		private float _scaleEnd; // 0xC0
		private float _scaleTime; // 0xC4
		private float _scaleProgressTime; // 0xC8
		public EvDataManager.EntityParam EventParams; // 0xD0

		// Properties
		public override string entityType { get; }
		public Vector3 oldMoveVector { get; set; }
		public Vector4 locatorDirect { get; set; }
		public FieldObjectRouteMove RouteMove { get; }
		public bool IsBusyRouteMove { get; }
		public Vector2Int gridPosition { get; set; }
		public Vector2Int gridPositionDirect { get; set; }
		public EvEntityCommand EvEntityCmd { get; }
		public Vector2Int oldGridPosition { get; set; }
		public float Height { get; set; }
	}
}
