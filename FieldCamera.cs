using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace BDSP
{
	public class FieldCamera : MonoBehaviour
	{
		// Fields
		private Transform _target; // 0x18
		private Camera _camera; // 0x20
		private float _pitch; // 0x28
		private float _fov; // 0x2C
		private float _targetRange; // 0x30
		private float _defocusStart; // 0x34
		private float _defocusEnd; // 0x38
		private float _start_pitch; // 0x3C
		private float _start_fov; // 0x40
		private float _start_targetRange; // 0x44
		private float _start_defocusStart; // 0x48
		private float _start_defocusEnd; // 0x4C
		private float _end_pitch; // 0x50
		private float _end_fov; // 0x54
		private float _end_targetRange; // 0x58
		private float _end_defocusStart; // 0x5C
		private float _end_defocusEnd; // 0x60
		private float _pitch_time; // 0x64
		private float _pitch_work_wait; // 0x68
		private Vector3 oldPosition; // 0x6C
		private Vector3<offset> k__BackingField; // 0x78
		private Vector3<offsetAngle> k__BackingField; // 0x84
		private float _cameraLerpRate; // 0x90
		public Camera EncountEffectCamera; // 0x98
		public bool IsUpdateStop; // 0xA0
		private EventCamera<EventCamera> k__BackingField; // 0xA8
		private FieldCameraShake<FieldCameraShake> k__BackingField; // 0xB0
		private FieldFloatMove<TargetRangeOffset> k__BackingField; // 0xB8
		private bool isPanCamera; // 0xC0
		private FieldPanCamera _panCamera; // 0xC8
		private GameObject DarkWindow; // 0xD0
		private float _scriptFardepth; // 0xD8
		private float _scriptFardepthTime; // 0xDC
		private float _scriptFardepthTimeVectol; // 0xE0
		private AfterImage<AfterImage> k__BackingField; // 0xE8
		private float _fovOffset; // 0xF0
		private float _fovOffsetStart; // 0xF4
		private float _fovOffsetEnd; // 0xF8
		private float _fovOffsetTime; // 0xFC
		private float _fovOffsetTimeScale; // 0x100
		private Transform returnDofTransform; // 0x108
		private GameObject tempDofTransform; // 0x110
		private bool IsStopDofTarget; // 0x118

		// Properties
		public Vector3 offset { get; set; }
		public Vector3 offsetAngle { get; set; }
		public Transform Target { get; set; }
		public EventCamera EventCamera { get; set; }
		public FieldCameraShake FieldCameraShake { get; set; }
		public FieldFloatMove TargetRangeOffset { get; set; }
		public float Fov { get; set; }
		public AfterImage AfterImage { get; set; }
		public float TargetRange { get; }

		// Methods

		// RVA: 0x18178E0 Offset: 0x18179E1 VA: 0x18178E0
		public void SetPanCameraFlag(bool flag) { }

		// RVA: 0x1817900 Offset: 0x1817A01 VA: 0x1817900
		public bool GetPanCameraFlag() { }

		// RVA: 0x1817910 Offset: 0x1817A11 VA: 0x1817910
		private void Awake() { }

		// RVA: 0x1817930 Offset: 0x1817A31 VA: 0x1817930
		private void OnEnable() { }

		// RVA: 0x1817B50 Offset: 0x1817C51 VA: 0x1817B50
		private void Update() { }

		// RVA: 0x18183F0 Offset: 0x18184F1 VA: 0x18183F0
		private void LateUpdate() { }

		// RVA: 0x18186A0 Offset: 0x18187A1 VA: 0x18186A0
		public void ForceUpdateCamera() { }

		// RVA: 0x1817E70 Offset: 0x1817F71 VA: 0x1817E70
		private void CameraUpdate(float deltaTime) { }

		// RVA: 0x18186B0 Offset: 0x18187B1 VA: 0x18186B0
		public void FixedPosition() { }

		// RVA: 0x1818870 Offset: 0x1818971 VA: 0x1818870
		public void SetTempNormalCamera(float pitch, float fov, float far) { }

		// RVA: 0x18188B0 Offset: 0x18189B1 VA: 0x18188B0
		public void SetTempNormalCamera(float pitch, float fov, float targetRange, float defocusStart, float defocusEnd, bool isForse = True, float wait = 0) { }

		// RVA: 0x1818910 Offset: 0x1818A11 VA: 0x1818910
		public void SetTempNormalCamera(MapInfo.SheetCamera data, bool isForse, float wait) { }

		// RVA: 0x1817D40 Offset: 0x1817E41 VA: 0x1817D40
		public void UpdateMapInfoParam(float time) { }

		// RVA: 0x1818960 Offset: 0x1818A61 VA: 0x1818960
		public bool IsMoveStop() { }

		// RVA: 0x1818AF0 Offset: 0x1818BF1 VA: 0x1818AF0
		public void CameraComponentEnable(bool flag) { }

		// RVA: 0x1818B00 Offset: 0x1818C01 VA: 0x1818B00
		public void InstantiateDarkWindow(GameObject darkWindow) { }

		// RVA: 0x1818C80 Offset: 0x1818D81 VA: 0x1818C80
		public void DestroyDarkWindow() { }

		// RVA: 0x1818D50 Offset: 0x1818E51 VA: 0x1818D50
		public GameObject GetDarkWindow() { }

		// RVA: 0x1818D60 Offset: 0x1818E61 VA: 0x1818D60
		public void ScriptFarDepth(float depth, float frame) { }

		// RVA: 0x1818DB0 Offset: 0x1818EB1 VA: 0x1818DB0
		public void ChangeDofTarget(ref Vector3 postion) { }

		// RVA: 0x1818F30 Offset: 0x1819031 VA: 0x1818F30
		public void ResetChangeDofTarget() { }

		// RVA: 0x18190A0 Offset: 0x18191A1 VA: 0x18190A0
		public void SetCameraDirect(Vector3 position, Vector3 rotate) { }

		// RVA: 0x1819130 Offset: 0x1819231 VA: 0x1819130
		public Camera GetCamera() { }

		// RVA: 0x1819140 Offset: 0x1819241 VA: 0x1819140
		public void SetFovOffset(float offset, float time) { }

		// RVA: 0x1819170 Offset: 0x1819271 VA: 0x1819170
		public float GetFov() { }

		// RVA: 0x1819180 Offset: 0x1819281 VA: 0x1819180
		public void .ctor() { }
	}
}
