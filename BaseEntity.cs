using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

namespace BDSP
{
	class BaseEntity : MonoBehaviour // TypeDefIndex: 3983
	{
		// Fields
		[SerializeField] // RVA: 0x7EC60 Offset: 0x7ED61 VA: 0x7EC60
		private string _enityName; // 0x18
		private bool _alreadyRegistered; // 0x20
		public float yawAngle; // 0x24
		public Vector3 worldPosition; // 0x28
		private float savedYawAngle; // 0x34
		private Vector3 savedPosition; // 0x38
		[CompilerGeneratedAttribute] // RVA: 0x7EC70 Offset: 0x7ED71 VA: 0x7EC70
		private Vector3<beforePosition> k__BackingField; // 0x44
		private Transform _cacheTransform; // 0x50
		[CompilerGeneratedAttribute] // RVA: 0x7EC80 Offset: 0x7ED81 VA: 0x7EC80
		private int <currentSequence>k__BackingField; // 0x58
	[CompilerGeneratedAttribute] // RVA: 0x7EC90 Offset: 0x7ED91 VA: 0x7EC90
		private int <nextSequence>k__BackingField; // 0x5C
	[CompilerGeneratedAttribute] // RVA: 0x7ECA0 Offset: 0x7EDA1 VA: 0x7ECA0
		private float <sequenceTime>k__BackingField; // 0x60
	[CompilerGeneratedAttribute] // RVA: 0x7ECB0 Offset: 0x7EDB1 VA: 0x7ECB0
		private BaseEntity<target> k__BackingField; // 0x68

		// Properties
		public virtual string entityType { get; }
		public Vector3 beforePosition { get; set; }
		public int currentSequence { get; set; }
		public int nextSequence { get; set; }
		public float sequenceTime { get; set; }
		public string entityEname { get; set; }
		public BaseEntity target { get; set; }
		public Transform transform { get; }

		// Methods

		// RVA: 0x1C7DB00 Offset: 0x1C7DC01 VA: 0x1C7DB00 Slot: 4
		public virtual string get_entityType() { }

		// RVA: 0x1C7DB50 Offset: 0x1C7DC51 VA: 0x1C7DB50 Slot: 5
		public virtual AnimationPlayer GetAnimationPlayer() { }

		[CompilerGeneratedAttribute] // RVA: 0x9F000 Offset: 0x9F101 VA: 0x9F000
									 // RVA: 0x1C7DB60 Offset: 0x1C7DC61 VA: 0x1C7DB60
		private void set_beforePosition(Vector3 value) { }

		[CompilerGeneratedAttribute] // RVA: 0x9F010 Offset: 0x9F111 VA: 0x9F010
									 // RVA: 0x1C7DB70 Offset: 0x1C7DC71 VA: 0x1C7DB70
		public Vector3 get_beforePosition() { }

		// RVA: 0x1C7DB80 Offset: 0x1C7DC81 VA: 0x1C7DB80
		public void Register() { }

		// RVA: 0x1C7DC10 Offset: 0x1C7DD11 VA: 0x1C7DC10
		public void Unregister() { }

		[CompilerGeneratedAttribute] // RVA: 0x9F020 Offset: 0x9F121 VA: 0x9F020
									 // RVA: 0x1C7DC90 Offset: 0x1C7DD91 VA: 0x1C7DC90
		public int get_currentSequence() { }

		[CompilerGeneratedAttribute] // RVA: 0x9F030 Offset: 0x9F131 VA: 0x9F030
									 // RVA: 0x1C7DCA0 Offset: 0x1C7DDA1 VA: 0x1C7DCA0
		private void set_currentSequence(int value) { }

		[CompilerGeneratedAttribute] // RVA: 0x9F040 Offset: 0x9F141 VA: 0x9F040
									 // RVA: 0x1C7DCB0 Offset: 0x1C7DDB1 VA: 0x1C7DCB0
		public int get_nextSequence() { }

		[CompilerGeneratedAttribute] // RVA: 0x9F050 Offset: 0x9F151 VA: 0x9F050
									 // RVA: 0x1C7DCC0 Offset: 0x1C7DDC1 VA: 0x1C7DCC0
		public void set_nextSequence(int value) { }

		[CompilerGeneratedAttribute] // RVA: 0x9F060 Offset: 0x9F161 VA: 0x9F060
									 // RVA: 0x1C7DCD0 Offset: 0x1C7DDD1 VA: 0x1C7DCD0
		public float get_sequenceTime() { }

		[CompilerGeneratedAttribute] // RVA: 0x9F070 Offset: 0x9F171 VA: 0x9F070
									 // RVA: 0x1C7DCE0 Offset: 0x1C7DDE1 VA: 0x1C7DCE0
		private void set_sequenceTime(float value) { }

		// RVA: 0x1C7DCF0 Offset: 0x1C7DDF1 VA: 0x1C7DCF0
		public string get_entityEname() { }

		// RVA: 0x1C7DD70 Offset: 0x1C7DE71 VA: 0x1C7DD70
		public void set_entityEname(string value) { }

		[CompilerGeneratedAttribute] // RVA: 0x9F080 Offset: 0x9F181 VA: 0x9F080
									 // RVA: 0x1C7DD80 Offset: 0x1C7DE81 VA: 0x1C7DD80
		public BaseEntity get_target() { }

		[CompilerGeneratedAttribute] // RVA: 0x9F090 Offset: 0x9F191 VA: 0x9F090
									 // RVA: 0x1C7DD90 Offset: 0x1C7DE91 VA: 0x1C7DD90
		private void set_target(BaseEntity value) { }

		// RVA: 0x1C7DDA0 Offset: 0x1C7DEA1 VA: 0x1C7DDA0
		public Transform get_transform() { }

		// RVA: 0x1C7DE50 Offset: 0x1C7DF51 VA: 0x1C7DE50 Slot: 6
		protected virtual void Awake() { }

		// RVA: 0x1C7DF80 Offset: 0x1C7E081 VA: 0x1C7DF80 Slot: 7
		protected virtual void OnEnable() { }

		// RVA: 0x1C7E2D0 Offset: 0x1C7E3D1 VA: 0x1C7E2D0 Slot: 8
		protected virtual void OnDisable() { }

		// RVA: 0x1C7E500 Offset: 0x1C7E601 VA: 0x1C7E500 Slot: 9
		protected virtual void OnDestroy() { }

		// RVA: 0x1C7E580 Offset: 0x1C7E681 VA: 0x1C7E580
		private void OnEarlyUpdate(float deltaTime) { }

		// RVA: 0x1C7E5E0 Offset: 0x1C7E6E1 VA: 0x1C7E5E0 Slot: 10
		protected virtual void OnUpdate(float deltaTime) { }

		// RVA: 0x1C7E660 Offset: 0x1C7E761 VA: 0x1C7E660 Slot: 11
		protected virtual void OnLateUpdate(float deltaTime) { }

		// RVA: 0x1C7E1C0 Offset: 0x1C7E2C1 VA: 0x1C7E1C0
		private void OnPostLateUpdate(float deltaTime) { }

		// RVA: 0x1C7E670 Offset: 0x1C7E771 VA: 0x1C7E670 Slot: 12
		protected virtual bool SwitchToNext() { }

		// RVA: 0x1C7E680 Offset: 0x1C7E781 VA: 0x1C7E680 Slot: 13
		protected virtual void ProcessSequence(float deltaTime) { }

		// RVA: 0x1C7E690 Offset: 0x1C7E791 VA: 0x1C7E690
		public void SetPositionDirect(Vector3 pos) { }

		// RVA: 0x1C7E6E0 Offset: 0x1C7E7E1 VA: 0x1C7E6E0
		public void SetYawAngleDirect(float angle) { }

		// RVA: 0x1C7E740 Offset: 0x1C7E841 VA: 0x1C7E740
		public void .ctor() { }
	}
}