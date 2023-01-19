using System;
using System.Collections.Generic;
using System.Text;

namespace BDSP
{
	class FieldCharacterEntity : FieldObjectEntity // TypeDefIndex: 4011
	{
		// Fields
		protected static readonly Vector2[] FaceUVs; // 0x0
		public static float ViewerHandScale; // 0x8
		public float HandScale; // 0xD8
		[SerializeField] // RVA: 0x7F030 Offset: 0x7F131 VA: 0x7F030
		protected AnimationPlayer _animationPlayer; // 0xE0
		[SerializeField] // RVA: 0x7F040 Offset: 0x7F141 VA: 0x7F040
		protected CurvePatterns _blinkPatterns; // 0xE8
		[SerializeField] // RVA: 0x7F050 Offset: 0x7F151 VA: 0x7F050
		protected FieldCharacterVariation[] _variations; // 0xF0
		[SerializeField] // RVA: 0x7F060 Offset: 0x7F161 VA: 0x7F060
		[RangeAttribute] // RVA: 0x7F060 Offset: 0x7F161 VA: 0x7F060
		protected int _eyePatternIndex; // 0xF8
		[SerializeField] // RVA: 0x7F0A0 Offset: 0x7F1A1 VA: 0x7F0A0
		[RangeAttribute] // RVA: 0x7F0A0 Offset: 0x7F1A1 VA: 0x7F0A0
		protected int _mouthPatternIndex; // 0xFC
		[SerializeField] // RVA: 0x7F0E0 Offset: 0x7F1E1 VA: 0x7F0E0
		[RangeAttribute] // RVA: 0x7F0E0 Offset: 0x7F1E1 VA: 0x7F0E0
		protected int _currentVariation; // 0x100
		[SerializeField] // RVA: 0x7F120 Offset: 0x7F221 VA: 0x7F120
		protected Renderer _watchRenderer; // 0x108
		private int _blinkCurveIndex; // 0x110
		private float _blinkTime; // 0x114
		private int _UVOffsetID; // 0x118
		protected MaterialPropertyBlock _propertyBlock; // 0x120
		protected const float _MaxCoolTime = 0.43333334;
		protected float[] _effectCoolTime; // 0x128
		public Vector3 NeckAngle; // 0x130
		public Vector3 _updateNeckAngle; // 0x13C
		public Vector3 _updateNeckAngle2; // 0x148
		private Transform _subductionNode; // 0x158
		private Transform _hipNode; // 0x160
		public float SubductionDepth; // 0x168
		private EffectInstance SwimEffect; // 0x170
		private bool isPlayingSwimEffect; // 0x178
		private EffectInstance _swimWalkEffect; // 0x180
		private bool _isPlayingSwimWalkEffect; // 0x188
		[CompilerGeneratedAttribute] // RVA: 0x7F130 Offset: 0x7F231 VA: 0x7F130
		private bool <IsForceBlink>k__BackingField; // 0x189
	private bool _reqestStopFootEffect; // 0x18A
		private bool _isStopFootEffect; // 0x18B
		private float _stopFootEffectRetrunTime; // 0x18C
		private int _oldAnimEventIndex; // 0x190
		private int _oldAnimClipIndex; // 0x194
		private CharcterAnimeEvent.SheetanimeEvent[][] _animEvents; // 0x198
		private Func<AnimationPlayer, bool> animeEndCallBack; // 0x1A0

		// Properties
		public override string entityType { get; }
		public Renderer watchRender { get; set; }
		public bool watchVisibility { get; set; }
		public FieldCharacterVariation[] variations { get; set; }
		public CurvePatterns blinkPattern { get; set; }
		public int eyePatternIndex { get; }
		public int mouthPatternIndex { get; }
		public int currentVariation { get; }
		public Transform hipNode { get; }
		public bool IsForceBlink { get; set; }
		public bool IsStopFootEffect { get; set; }

		// Methods

		// RVA: 0x181C620 Offset: 0x181C721 VA: 0x181C620 Slot: 4
		public override string get_entityType() { }

		// RVA: 0x181C670 Offset: 0x181C771 VA: 0x181C670 Slot: 5
		public override AnimationPlayer GetAnimationPlayer() { }

		// RVA: 0x181C680 Offset: 0x181C781 VA: 0x181C680
		public Renderer get_watchRender() { }

		// RVA: 0x181C690 Offset: 0x181C791 VA: 0x181C690
		public void set_watchRender(Renderer value) { }

		// RVA: 0x181C6A0 Offset: 0x181C7A1 VA: 0x181C6A0
		public bool get_watchVisibility() { }

		// RVA: 0x181C730 Offset: 0x181C831 VA: 0x181C730
		public void set_watchVisibility(bool value) { }

		// RVA: 0x181C7D0 Offset: 0x181C8D1 VA: 0x181C7D0
		public FieldCharacterVariation[] get_variations() { }

		// RVA: 0x181C7E0 Offset: 0x181C8E1 VA: 0x181C7E0
		public void set_variations(FieldCharacterVariation[] value) { }

		// RVA: 0x181C7F0 Offset: 0x181C8F1 VA: 0x181C7F0
		public CurvePatterns get_blinkPattern() { }

		// RVA: 0x181C800 Offset: 0x181C901 VA: 0x181C800
		public void set_blinkPattern(CurvePatterns value) { }

		// RVA: 0x181C810 Offset: 0x181C911 VA: 0x181C810
		private void OnValidate() { }

		// RVA: 0x181C820 Offset: 0x181C921 VA: 0x181C820
		public int get_eyePatternIndex() { }

		// RVA: 0x181C830 Offset: 0x181C931 VA: 0x181C830
		public int get_mouthPatternIndex() { }

		// RVA: 0x181C840 Offset: 0x181C941 VA: 0x181C840
		public int get_currentVariation() { }

		// RVA: 0x181C850 Offset: 0x181C951 VA: 0x181C850
		public Transform get_hipNode() { }

		[CompilerGeneratedAttribute] // RVA: 0x9F460 Offset: 0x9F561 VA: 0x9F460
									 // RVA: 0x181C860 Offset: 0x181C961 VA: 0x181C860
		public void set_IsForceBlink(bool value) { }

		[CompilerGeneratedAttribute] // RVA: 0x9F470 Offset: 0x9F571 VA: 0x9F470
									 // RVA: 0x181C870 Offset: 0x181C971 VA: 0x181C870
		public bool get_IsForceBlink() { }

		// RVA: 0x181C880 Offset: 0x181C981 VA: 0x181C880
		public void set_IsStopFootEffect(bool value) { }

		// RVA: 0x181C8B0 Offset: 0x181C9B1 VA: 0x181C8B0
		public bool get_IsStopFootEffect() { }

		// RVA: 0x181C8C0 Offset: 0x181C9C1 VA: 0x181C8C0
		private void Start() { }

		// RVA: 0x181C8D0 Offset: 0x181C9D1 VA: 0x181C8D0 Slot: 14
		protected virtual void OnFootSE() { }

		// RVA: 0x181CAE0 Offset: 0x181CBE1 VA: 0x181CAE0 Slot: 15
		protected virtual void OnFootEffect(int index) { }

		// RVA: 0x181CD20 Offset: 0x181CE21 VA: 0x181CD20 Slot: 7
		protected override void OnEnable() { }

		// RVA: 0x181CF50 Offset: 0x181D051 VA: 0x181CF50 Slot: 8
		protected override void OnDisable() { }

		// RVA: 0x181CFF0 Offset: 0x181D0F1 VA: 0x181CFF0 Slot: 10
		protected override void OnUpdate(float deltaTime) { }

		// RVA: 0x181D5B0 Offset: 0x181D6B1 VA: 0x181D5B0 Slot: 11
		protected override void OnLateUpdate(float deltaTime) { }

		// RVA: 0x181E050 Offset: 0x181E151 VA: 0x181E050 Slot: 12
		protected override bool SwitchToNext() { }

		// RVA: 0x181E060 Offset: 0x181E161 VA: 0x181E060 Slot: 13
		protected override void ProcessSequence(float deltaTime) { }

		// RVA: 0x181DE20 Offset: 0x181DF21 VA: 0x181DE20
		private void LateUpdateNeckAngle(float deltaTime) { }

		// RVA: 0x181E0F0 Offset: 0x181E1F1 VA: 0x181E0F0 Slot: 16
		public virtual void GetIdleAnimationIndex(out int index, out float duration) { }

		// RVA: 0x181E140 Offset: 0x181E241 VA: 0x181E140
		public int GetWalkAnimationIndex() { }

		// RVA: 0x181E160 Offset: 0x181E261 VA: 0x181E160
		public void SetEyePattern(int index) { }

		// RVA: 0x181E210 Offset: 0x181E311 VA: 0x181E210
		public void SetMouthPattern(int index) { }

		// RVA: 0x181E2A0 Offset: 0x181E3A1 VA: 0x181E2A0
		public void SetAnimationEvents(CharcterAnimeTable tbl) { }

		// RVA: 0x181DA20 Offset: 0x181DB21 VA: 0x181DA20
		private void UpdateSubductionDepth() { }

		// RVA: 0x181E560 Offset: 0x181E661 VA: 0x181E560
		private static float CalcSubductionDepth(Vector3 worldPotision) { }

		// RVA: 0x181E6C0 Offset: 0x181E7C1 VA: 0x181E6C0
		private static float CalcSubductionDepthX(Vector3 gridPos, float worldPosX) { }

		// RVA: 0x181E850 Offset: 0x181E951 VA: 0x181E850
		private static float GetSubductionDepth(Vector3 worldPosition) { }

		// RVA: 0x181E8F0 Offset: 0x181E9F1 VA: 0x181E8F0
		private static float GetSubductionDepth(Vector2Int gridPosition, float height) { }

		// RVA: 0x181E4B0 Offset: 0x181E5B1 VA: 0x181E4B0
		private static bool CheckSubductionEnableAttribute(Vector2Int gridPosition, float height) { }

		// RVA: 0x181EAA0 Offset: 0x181EBA1 VA: 0x181EAA0
		public bool IsSwimCharacter() { }

		// RVA: 0x181DBD0 Offset: 0x181DCD1 VA: 0x181DBD0
		private void UpdateSwim() { }

		// RVA: 0x181EB60 Offset: 0x181EC61 VA: 0x181EB60
		private static bool CheckSwimEnableAttribute(Vector2Int gridPosition, float height) { }

		// RVA: 0x181D780 Offset: 0x181D881 VA: 0x181D780
		private void UpdateAnimEvent() { }

		// RVA: 0x181ED70 Offset: 0x181EE71 VA: 0x181ED70
		public void SetAnimeEndCallBack(Func<AnimationPlayer, bool> callback) { }

		// RVA: 0x181ED80 Offset: 0x181EE81 VA: 0x181ED80
		public void .ctor() { }

		// RVA: 0x181EE30 Offset: 0x181EF31 VA: 0x181EE30
		private static void .cctor() { }

		[CompilerGeneratedAttribute] // RVA: 0x9F480 Offset: 0x9F581 VA: 0x9F480
									 // RVA: 0x181EFA0 Offset: 0x181F0A1 VA: 0x181EFA0
		private void <UpdateSwim>b__87_0(EffectInstance eff) { }

		[CompilerGeneratedAttribute] // RVA: 0x9F490 Offset: 0x9F591 VA: 0x9F490
									 // RVA: 0x181EFB0 Offset: 0x181F0B1 VA: 0x181EFB0
		private void <UpdateSwim>b__87_1(EffectInstance eff) { }
	}
}