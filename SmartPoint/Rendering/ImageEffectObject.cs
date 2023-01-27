using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace BDSP.SmartPoint.Rendering
{
	public class ImageEffectObject : ScriptableObject
	{
		// Fields
		private Material[] materials; // 0x18
		protected Material[] materialInstances; // 0x20
		private RenderTexture<temporaryRT> k__BackingField; // 0x28
		private bool <enabled>k__BackingField; // 0x30
		private Camera<camera> k__BackingField; // 0x38
		private Transform<target> k__BackingField; // 0x40
		private int initializedCount; // 0x48

		// Properties
		public RenderTexture temporaryRT { get; set; }
		public bool enabled { get; set; }
		public Camera camera { get; set; }
		public Transform target { get; set; }

		// Methods

		// RVA: 0x18A0550 Offset: 0x18A0651 VA: 0x18A0550 Slot: 4
		public virtual CommandBuffer Build(RenderTargetIdentifier sourceRT, out RenderTargetIdentifier resultRT, bool feedbackCameraTarget = True) { }

		// RVA: 0x189EC70 Offset: 0x189ED71 VA: 0x189EC70
		protected void InstantiateMaterials() { }

		// RVA: 0x18A0570 Offset: 0x18A0671 VA: 0x18A0570 Slot: 5
		public virtual void Update() { }

		// RVA: 0x189F490 Offset: 0x189F591 VA: 0x189F490 Slot: 6
		public virtual void Destroy() { }
	}
}
