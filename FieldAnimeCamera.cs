using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace BDSP
{
	public class FieldAnimeCamera : MonoBehaviour // TypeDefIndex: 4145
	{
		// Fields
		public static FieldAnimeCamera instance; // 0x0
		private Camera _camera; // 0x18
		private Animator _animator; // 0x20
		private bool _isPlay; // 0x28
		private Transform transform; // 0x30
		private string assetbundleName; // 0x38

		// Methods

		// RVA: 0x18159B0 Offset: 0x1815AB1 VA: 0x18159B0
		private void Awake() { }

		// RVA: 0x1815A80 Offset: 0x1815B81 VA: 0x1815A80
		private void OnDestroy() { }

		// RVA: 0x1815B10 Offset: 0x1815C11 VA: 0x1815B10
		public float GetFov() { }

		// RVA: 0x1815B20 Offset: 0x1815C21 VA: 0x1815B20
		public float GetFocalLength() { }

		// RVA: 0x1815B30 Offset: 0x1815C31 VA: 0x1815B30
		public void Play(string statename)
		{
			_animator.Play(statename);
			_isPlay = true;
		}

		// RVA: 0x1815B60 Offset: 0x1815C61 VA: 0x1815B60
		public void Stop() { }

		// RVA: 0x1815BC0 Offset: 0x1815CC1 VA: 0x1815BC0
		public void OnStateMachineExit() { }

		// RVA: 0x1815BD0 Offset: 0x1815CD1 VA: 0x1815BD0
		public bool IsPlay() { }

		// RVA: 0x1815BE0 Offset: 0x1815CE1 VA: 0x1815BE0
		public bool IsPlay(string statename) { }

		// RVA: 0x1815CB0 Offset: 0x1815DB1 VA: 0x1815CB0
		public bool Ready() { }

		// RVA: 0x1815D30 Offset: 0x1815E31 VA: 0x1815D30
		public void LoadRuntimeAnimatorController(string assetname) { }

		// RVA: 0x1815EA0 Offset: 0x1815FA1 VA: 0x1815EA0
		public void ReleaseSetRuntimeAnimatorController() { }

		private IEnumerator Load(string assetname) { }

		// RVA: 0x1816050 Offset: 0x1816151 VA: 0x1816050
		public bool IsNull() { }

		// RVA: 0x1815F70 Offset: 0x1816071 VA: 0x1815F70
		private void UnloadAsset() { }
	}
}
