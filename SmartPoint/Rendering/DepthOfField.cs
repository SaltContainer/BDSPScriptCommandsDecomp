using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace BDSP.SmartPoint.Rendering
{
	public class DepthOfField : ImageEffectObject // TypeDefIndex: 5959
	{
		// Fields
		private static readonly int BLUROFFSET_X; // 0x0
		private static readonly int BLUROFFSET_Y; // 0x4
		private static readonly int TEMPORARY_RT; // 0x8
		private static readonly int DEPTH_RT; // 0xC
		private static readonly int BLUR_TEX; // 0x10
		private static readonly int STRONGER_BLUR_TEX; // 0x14
		private static readonly int FOCUS_TEX; // 0x18
		private static readonly int FOCAL_COEFF; // 0x1C
		public static DepthOfField.OnBuildCallback onBuild; // 0x20
		public static DepthOfField.OnRelaseCallback onRelease; // 0x28
		private float <farDepth>k__BackingField; // 0x4C
		private float <focalLength>k__BackingField; // 0x50
		private float <distance>k__BackingField; // 0x54
		private float <sensorScale>k__BackingField; // 0x58
		private Vector3<targetOffset> k__BackingField; // 0x5C
		private Camera<shootingCamera> k__BackingField; // 0x68
		private static float <blurry>k__BackingField; // 0x30
		public static DepthOfField instance; // 0x38
		private RenderTexture downscaledRT; // 0x70
		private RenderTexture blurredRT; // 0x78

		// Properties
		public float farDepth { get; set; }
		public float focalLength { get; set; }
		public float distance { get; set; }
		public float sensorScale { get; set; }
		public Vector3 targetOffset { get; set; }
		public Camera shootingCamera { get; set; }
		public static float blurry { get; set; }
		public RenderTexture renderTexture { get; }
		public RenderTexture strongerBlurTexture { get; }
		public Material downsampleMaterial { get; }
		public Material blurMaterial { get; }
		public Vector4 blurOffset { get; }

		// Methods

		// RVA: 0x189D940 Offset: 0x189DA41 VA: 0x189D940 Slot: 4
		public override CommandBuffer Build(RenderTargetIdentifier sourceRT, out RenderTargetIdentifier resultRT, bool feedbackCameraTarget = True) { }

		// RVA: 0x189EFF0 Offset: 0x189F0F1 VA: 0x189EFF0 Slot: 5
		public override void Update() { }

		// RVA: 0x189F2E0 Offset: 0x189F3E1 VA: 0x189F2E0 Slot: 6
		public override void Destroy() { }
	}
}
