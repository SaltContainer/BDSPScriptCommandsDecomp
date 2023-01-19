using System;
using System.Collections.Generic;
using System.Text;

namespace BDSP
{
	class FieldPlayerEntity : FieldCharacterEntity // TypeDefIndex: 4050
	{
		// Fields
		private static readonly int _StencilRefID; // 0x0
		[SerializeField] // RVA: 0x7F2E0 Offset: 0x7F3E1 VA: 0x7F2E0
		protected Renderer[] _hatRenderers; // 0x1A8
		[SerializeField] // RVA: 0x7F2F0 Offset: 0x7F3F1 VA: 0x7F2F0
		protected Renderer[] _shoesRenderers; // 0x1B0
		[SerializeField] // RVA: 0x7F300 Offset: 0x7F401 VA: 0x7F300
		protected GameObject _meshGroup; // 0x1B8
		[SerializeField] // RVA: 0x7F310 Offset: 0x7F411 VA: 0x7F310
		protected GameObject _bicycleObject; // 0x1C0
		[SerializeField] // RVA: 0x7F320 Offset: 0x7F421 VA: 0x7F320
		protected Renderer[] _rodRenderers; // 0x1C8
		[SerializeField] // RVA: 0x7F330 Offset: 0x7F431 VA: 0x7F330
		protected Renderer _podRenderer; // 0x1D0
		[SerializeField] // RVA: 0x7F340 Offset: 0x7F441 VA: 0x7F340
		protected Renderer _beadaruRenderer; // 0x1D8
		[SerializeField] // RVA: 0x7F350 Offset: 0x7F451 VA: 0x7F350
		protected Renderer _mukuhawkRenderer; // 0x1E0
		[SerializeField] // RVA: 0x7F360 Offset: 0x7F461 VA: 0x7F360
		protected Color[] _bicycleColors; // 0x1E8
		[SerializeField] // RVA: 0x7F370 Offset: 0x7F471 VA: 0x7F370
		protected Renderer _bicycleRenderer; // 0x1F0
		[SerializeField] // RVA: 0x7F380 Offset: 0x7F481 VA: 0x7F380
		protected int _bicycleMaterialIndex; // 0x1F8
		[CompilerGeneratedAttribute] // RVA: 0x7F390 Offset: 0x7F491 VA: 0x7F390
		private int <bicycleColorIndex>k__BackingField; // 0x1FC
	public bool isExtrudable; // 0x200
		[CompilerGeneratedAttribute] // RVA: 0x7F3A0 Offset: 0x7F4A1 VA: 0x7F3A0
		private bool <DashFlag>k__BackingField; // 0x201
	private JumpCalculator _path; // 0x208
		private bool _setupMaterials; // 0x210
		private bool _hit_se_request; // 0x211
		private float _hit_se_wait; // 0x214
		public Vector3 InputMoveVector; // 0x218
		[CompilerGeneratedAttribute] // RVA: 0x7F3B0 Offset: 0x7F4B1 VA: 0x7F3B0
		private Func<FieldPlayerEntity, bool> <LateUpdateEvent>k__BackingField; // 0x228
	[CompilerGeneratedAttribute] // RVA: 0x7F3C0 Offset: 0x7F4C1 VA: 0x7F3C0
		private float <MoveSpeed>k__BackingField; // 0x230
	private float _beforeAngle; // 0x234
		public int FormType; // 0x238
		private MapAttributeTable.SheetData nowAttribute; // 0x240
		private bool isAttributeStop; // 0x248
		[CompilerGeneratedAttribute] // RVA: 0x7F3D0 Offset: 0x7F4D1 VA: 0x7F3D0
		private int <FashionTableID>k__BackingField; // 0x24C
	private bool FootSeWalkStartEvent; // 0x250
		private FieldPlayerEntity.CheckGridCollisionFunc CheckGridCollision; // 0x258
		private int _sandFallSeq; // 0x260
		private float _sandFallWait; // 0x264
		private float _sandFallPosZ; // 0x268
		private bool UpdateInputAngleDisable; // 0x26C
		private int KairikiPushObjectIndex; // 0x270
		private float KairikiPushTime; // 0x274
		private float debugInputTime; // 0x278
		private float debugInputVectolX; // 0x27C
		private bool _isCrossUpdate; // 0x280
		private Vector2 _crossInputVectol; // 0x284
		private Vector2 _crossStopPosition; // 0x28C
		private DIR _crossInputDir; // 0x294
		private float _crossKey_pushTime; // 0x298
		private Vector3 _eventMoveTargetPosition; // 0x29C
		private float _eventMoveTargetAngle; // 0x2A8
		private bool _eventMoveEnd; // 0x2AC
		private bool _eventRotateEnd; // 0x2AD
		private int currentForm; // 0x2B0
		private int nextForm; // 0x2B4
		private Action formFinish; // 0x2B8
		private bool changeFormRetInput; // 0x2C0
		private BicycleJump _bicJump; // 0x2C8
		private bool _isCycDownHillMode; // 0x2D0
		private float _bicOldAcceleration; // 0x2D4
		private float _bicAccelerationTime; // 0x2D8
		private float _bicDecelerateTime; // 0x2DC
		private bool _isBicMaxSpeed; // 0x2E0
		private FieldPlayerEntity.IceFloorStateType IceFloorState; // 0x2E4
		private Vector3 IceFloorDirection; // 0x2E8
		private int IceSlidingLevel; // 0x2F4
		private float IceSlidingSpeed; // 0x2F8
		private bool IsIceSlope; // 0x2FC
		private float IceFloorStopTime; // 0x300
		private Vector3 IceFloorStartGridCenterPos; // 0x304
		private FieldObjectMove IceSlopeDownMove; // 0x310
		private FieldObjectRotateYaw IceSlidingRotate; // 0x318
		private DIR IceFloorDirtyNextDir; // 0x320
		private FieldPlayerEntity.MoveFloorType CurrentMoveFloor; // 0x324
		private FieldPlayerEntity.MoveFloorType NextMoveFloor; // 0x328
		private float MoveFloorTime; // 0x32C
		private float PrevRotateOffset; // 0x330
		private FieldObjectRotateYaw MoveFloorRotate; // 0x338
		private const float RotateAnimeOneCycleTime = 0.5;
		private const float NaminoriCheckDistance = 0.7;
		public const float NaminoriWaterSurfaceOfs = 0.5;
		public bool ForcePlayNaminoriEffect; // 0x340
		private EffectInstance NaminoriEffect; // 0x348
		private AudioInstance NaminoriAudio; // 0x350
		private bool IsPlayNaminoriEffect; // 0x358
		private const float NaminoriSeWaitTime = 0.6;
		private float NaminoriSeWait; // 0x35C
		private FieldPlayerEntity.NaminoriEventRequestType NaminoriEventRequest; // 0x360
		private FieldPlayerEntity.CheckGridCollisionCheckSwimFunc CheckGridCollisionCheckSwim; // 0x368
		private FieldPlayerEntity.CheckGridCollisionCalcSwimFunc CheckGridCollisionCalcSwim; // 0x370
		private FieldPlayerEntity.CheckGridCollisionEndSwimFunc CheckGridCollisionEndSwim; // 0x378
		private FieldPlayerEntity.CheckGridCollisionCalcSwimEndFunc CheckGridCollisionCalcSwimEnd; // 0x380
		[CompilerGeneratedAttribute] // RVA: 0x7F3E0 Offset: 0x7F4E1 VA: 0x7F3E0
		private Transform<BiidaruTransform> k__BackingField; // 0x388
		private Vector3 BiidaruPosOriginal; // 0x390
		private Vector3 BiidaruMoveStartPos; // 0x39C
		private Vector3 BiidaruMoveEndPos; // 0x3A8
		private FieldFloatMove BiidaruMoveTime; // 0x3B8
		[CompilerGeneratedAttribute] // RVA: 0x7F3F0 Offset: 0x7F4F1 VA: 0x7F3F0
		private FieldFloatMove<VisiblePodMove> k__BackingField; // 0x3C0
		private EffectInstance RockClimbEffect; // 0x3C8
		private DIR SwampDeepInputDir; // 0x3D0
		private int SwampDeepInputCount; // 0x3D4
		private FieldPlayerEntity.SwampPhaseType SwampPhase; // 0x3D8
		private FieldObjectMove SwampMove; // 0x3E0
		private FieldFloatMove SwampWait; // 0x3E8
		private bool isPlayedSwampStartEffect; // 0x3F0
		private bool isSwampLoopEffect; // 0x3F1
		private const float WaterFallUpCheckDistance = 0.7;
		private const float WaterFallDownCheckDistance = 0.7;

		// Properties
		public override string entityType { get; }
		public Renderer[] rodRenderers { set; }
		public Renderer podRenderer { get; set; }
		public GameObject meshGroup { set; }
		public GameObject bicycleObject { get; set; }
		public Renderer beadaruRenderer { set; }
		public Renderer mukuhawkRenderer { set; }
		public Color[] bicycleColors { get; set; }
		public Renderer bicycleRenderer { get; set; }
		public int bicycleMaterialIndex { get; set; }
		public int bicycleColorIndex { get; set; }
		public int hatVariation { get; set; }
		public int shoesVariation { get; set; }
		public int rodVariation { get; set; }
		public bool podVisibility { get; set; }
		public bool beadaruVisibility { get; set; }
		public bool mukuhawkVisibility { get; set; }
		public bool DashFlag { get; set; }
		public Func<FieldPlayerEntity, bool> LateUpdateEvent { get; set; }
		public float MoveSpeed { get; set; }
		public int FashionTableID { get; set; }
		public Transform BiidaruTransform { get; set; }
		public FieldFloatMove VisiblePodMove { get; set; }

		// Methods

		// RVA: 0x1E15260 Offset: 0x1E15361 VA: 0x1E15260 Slot: 4
		public override string get_entityType() { }

		// RVA: 0x1E152B0 Offset: 0x1E153B1 VA: 0x1E152B0
		public void set_rodRenderers(Renderer[] value) { }

		// RVA: 0x1E152C0 Offset: 0x1E153C1 VA: 0x1E152C0
		public Renderer get_podRenderer() { }

		// RVA: 0x1E152D0 Offset: 0x1E153D1 VA: 0x1E152D0
		public void set_podRenderer(Renderer value) { }

		// RVA: 0x1E152E0 Offset: 0x1E153E1 VA: 0x1E152E0
		public void set_meshGroup(GameObject value) { }

		// RVA: 0x1E152F0 Offset: 0x1E153F1 VA: 0x1E152F0
		public GameObject get_bicycleObject() { }

		// RVA: 0x1E15300 Offset: 0x1E15401 VA: 0x1E15300
		public void set_bicycleObject(GameObject value) { }

		// RVA: 0x1E15310 Offset: 0x1E15411 VA: 0x1E15310
		public void set_beadaruRenderer(Renderer value) { }

		// RVA: 0x1E15320 Offset: 0x1E15421 VA: 0x1E15320
		public void set_mukuhawkRenderer(Renderer value) { }

		// RVA: 0x1E15330 Offset: 0x1E15431 VA: 0x1E15330
		public Color[] get_bicycleColors() { }

		// RVA: 0x1E15340 Offset: 0x1E15441 VA: 0x1E15340
		public void set_bicycleColors(Color[] value) { }

		// RVA: 0x1E15350 Offset: 0x1E15451 VA: 0x1E15350
		public Renderer get_bicycleRenderer() { }

		// RVA: 0x1E15360 Offset: 0x1E15461 VA: 0x1E15360
		public void set_bicycleRenderer(Renderer value) { }

		// RVA: 0x1E15370 Offset: 0x1E15471 VA: 0x1E15370
		public int get_bicycleMaterialIndex() { }

		// RVA: 0x1E15380 Offset: 0x1E15481 VA: 0x1E15380
		public void set_bicycleMaterialIndex(int value) { }

		[CompilerGeneratedAttribute] // RVA: 0x9F5B0 Offset: 0x9F6B1 VA: 0x9F5B0
									 // RVA: 0x1E15390 Offset: 0x1E15491 VA: 0x1E15390
		public int get_bicycleColorIndex() { }

		[CompilerGeneratedAttribute] // RVA: 0x9F5C0 Offset: 0x9F6C1 VA: 0x9F5C0
									 // RVA: 0x1E153A0 Offset: 0x1E154A1 VA: 0x1E153A0
		public void set_bicycleColorIndex(int value) { }

		// RVA: 0x1E153B0 Offset: 0x1E154B1 VA: 0x1E153B0
		public void ChangeVariation(int index) { }

		// RVA: 0x1E15590 Offset: 0x1E15691 VA: 0x1E15590
		public int get_hatVariation() { }

		// RVA: 0x1E156A0 Offset: 0x1E157A1 VA: 0x1E156A0
		public void set_hatVariation(int value) { }

		// RVA: 0x1E157A0 Offset: 0x1E158A1 VA: 0x1E157A0
		public int get_shoesVariation() { }

		// RVA: 0x1E158B0 Offset: 0x1E159B1 VA: 0x1E158B0
		public void set_shoesVariation(int value) { }

		// RVA: 0x1E159B0 Offset: 0x1E15AB1 VA: 0x1E159B0
		public int get_rodVariation() { }

		// RVA: 0x1E15AC0 Offset: 0x1E15BC1 VA: 0x1E15AC0
		public void set_rodVariation(int value) { }

		// RVA: 0x1E15C50 Offset: 0x1E15D51 VA: 0x1E15C50
		public bool get_podVisibility() { }

		// RVA: 0x1E15CE0 Offset: 0x1E15DE1 VA: 0x1E15CE0
		public void set_podVisibility(bool value) { }

		// RVA: 0x1E15D80 Offset: 0x1E15E81 VA: 0x1E15D80
		public bool get_beadaruVisibility() { }

		// RVA: 0x1E15E10 Offset: 0x1E15F11 VA: 0x1E15E10
		public void set_beadaruVisibility(bool value) { }

		// RVA: 0x1E15EB0 Offset: 0x1E15FB1 VA: 0x1E15EB0
		public bool get_mukuhawkVisibility() { }

		// RVA: 0x1E15F40 Offset: 0x1E16041 VA: 0x1E15F40
		public void set_mukuhawkVisibility(bool value) { }

		[CompilerGeneratedAttribute] // RVA: 0x9F5D0 Offset: 0x9F6D1 VA: 0x9F5D0
									 // RVA: 0x1E15FE0 Offset: 0x1E160E1 VA: 0x1E15FE0
		private void set_DashFlag(bool value) { }

		[CompilerGeneratedAttribute] // RVA: 0x9F5E0 Offset: 0x9F6E1 VA: 0x9F5E0
									 // RVA: 0x1E15FF0 Offset: 0x1E160F1 VA: 0x1E15FF0
		public bool get_DashFlag() { }

		[CompilerGeneratedAttribute] // RVA: 0x9F5F0 Offset: 0x9F6F1 VA: 0x9F5F0
									 // RVA: 0x1E16000 Offset: 0x1E16101 VA: 0x1E16000
		public Func<FieldPlayerEntity, bool> get_LateUpdateEvent() { }

		[CompilerGeneratedAttribute] // RVA: 0x9F600 Offset: 0x9F701 VA: 0x9F600
									 // RVA: 0x1E16010 Offset: 0x1E16111 VA: 0x1E16010
		public void set_LateUpdateEvent(Func<FieldPlayerEntity, bool> value) { }

		[CompilerGeneratedAttribute] // RVA: 0x9F610 Offset: 0x9F711 VA: 0x9F610
									 // RVA: 0x1E16020 Offset: 0x1E16121 VA: 0x1E16020
		private void set_MoveSpeed(float value) { }

		[CompilerGeneratedAttribute] // RVA: 0x9F620 Offset: 0x9F721 VA: 0x9F620
									 // RVA: 0x1E16030 Offset: 0x1E16131 VA: 0x1E16030
		public float get_MoveSpeed() { }

		[CompilerGeneratedAttribute] // RVA: 0x9F630 Offset: 0x9F731 VA: 0x9F630
									 // RVA: 0x1E16040 Offset: 0x1E16141 VA: 0x1E16040
		public void set_FashionTableID(int value) { }

		[CompilerGeneratedAttribute] // RVA: 0x9F640 Offset: 0x9F741 VA: 0x9F640
									 // RVA: 0x1E16050 Offset: 0x1E16151 VA: 0x1E16050
		public int get_FashionTableID() { }

		// RVA: 0x1E16060 Offset: 0x1E16161 VA: 0x1E16060 Slot: 6
		protected override void Awake() { }

		// RVA: 0x1E16070 Offset: 0x1E16171 VA: 0x1E16070 Slot: 7
		protected override void OnEnable() { }

		// RVA: 0x1E163D0 Offset: 0x1E164D1 VA: 0x1E163D0 Slot: 14
		protected override void OnFootSE() { }

		// RVA: 0x1E16580 Offset: 0x1E16681 VA: 0x1E16580 Slot: 15
		protected override void OnFootEffect(int index) { }

		// RVA: 0x1E16800 Offset: 0x1E16901 VA: 0x1E16800 Slot: 10
		protected override void OnUpdate(float deltaTime) { }

		// RVA: 0x1E16BE0 Offset: 0x1E16CE1 VA: 0x1E16BE0 Slot: 11
		protected override void OnLateUpdate(float deltaTime) { }

		// RVA: 0x1E176E0 Offset: 0x1E177E1 VA: 0x1E176E0
		private bool CheckMapCollision_AfterCharacterHit(Vector3 moveVelocity, out Vector3 afterMoveVector, out Vector3 hitNormal) { }

		// RVA: 0x1E19B90 Offset: 0x1E19C91 VA: 0x1E19B90 Slot: 12
		protected override bool SwitchToNext() { }

		// RVA: 0x1E1A5D0 Offset: 0x1E1A6D1 VA: 0x1E1A5D0 Slot: 13
		protected override void ProcessSequence(float deltaTime) { }

		// RVA: 0x1E1DF90 Offset: 0x1E1E091 VA: 0x1E1DF90
		public void GetInputVectorIgnoreUpdateInputAngle(out Vector2 stickL, out float stickPowerSq, float deltatime, out bool analogstick) { }

		// RVA: 0x1E1DFC0 Offset: 0x1E1E0C1 VA: 0x1E1DFC0
		public void GetInputVector(out Vector2 stickL, out float stickPowerSq, float deltatime, out bool analogstick) { }

		// RVA: 0x1E1C7A0 Offset: 0x1E1C8A1 VA: 0x1E1C7A0
		private bool IsStickInput() { }

		// RVA: 0x1E1E210 Offset: 0x1E1E311 VA: 0x1E1E210
		private bool GetCrossKeyVector(ref Vector2 stickL, ref float stickPowerSq, float deltatime) { }

		// RVA: 0x1E17940 Offset: 0x1E17A41 VA: 0x1E17940
		private void StopCrossUpdate() { }

		// RVA: 0x1E1E6B0 Offset: 0x1E1E7B1 VA: 0x1E1E6B0
		private void UpdateCrossInputMove(ref Vector2 stickL, ref float stickPowerSq, float deltatime) { }

		// RVA: 0x1E18800 Offset: 0x1E18901 VA: 0x1E18800
		private void LateUpdateCrossInput() { }

		// RVA: 0x1E1E750 Offset: 0x1E1E851 VA: 0x1E1E750
		private void LimitedCrossInput(ref Vector2 stick) { }

		// RVA: 0x1E1EBF0 Offset: 0x1E1ECF1 VA: 0x1E1EBF0
		public float InputAtanAngle(ref Vector2 stickL) { }

		// RVA: 0x1E1EC80 Offset: 0x1E1ED81 VA: 0x1E1EC80
		public float InputYawAngle(float angle) { }

		// RVA: 0x1E1E810 Offset: 0x1E1E911 VA: 0x1E1E810
		private float UpdateInputAngle(ref Vector2 stickL) { }

		// RVA: 0x1E1E940 Offset: 0x1E1EA41 VA: 0x1E1E940
		private bool IsInputStop() { }

		// RVA: 0x1E1B3E0 Offset: 0x1E1B4E1 VA: 0x1E1B3E0
		private void UpdateInputOperation(float deltaTime) { }

		// RVA: 0x1E20790 Offset: 0x1E20891 VA: 0x1E20790
		private FieldGridCollision.GridCollisionType CheckGridCollisionCore(Vector2Int grid) { }

		// RVA: 0x1E1CA80 Offset: 0x1E1CB81 VA: 0x1E1CA80
		private float GetMoveSpeed(bool isDash, float deltatime, bool gear, bool colHit, bool isdebug) { }

		// RVA: 0x1E207E0 Offset: 0x1E208E1 VA: 0x1E207E0
		private bool CanEntryAttribute(Vector2Int grid, float height) { }

		// RVA: 0x1E20C00 Offset: 0x1E20D01 VA: 0x1E20C00
		private static bool CanEntryAttribute(Vector2Int grid, float height, bool isRideBicyclelse, bool isSwim) { }

		// RVA: 0x1E20E60 Offset: 0x1E20F61 VA: 0x1E20E60
		private static bool CanEntryAttributeCommon(int code, int stop) { }

		// RVA: 0x1E1F780 Offset: 0x1E1F881 VA: 0x1E1F780
		private static bool CanEntryAttributeBycJump(int code, int stop, Vector3 forward, out Vector3 jumpvector) { }

		// RVA: 0x1E1F900 Offset: 0x1E1FA01 VA: 0x1E1F900
		private bool IsBicJumpObjectEntity(ref Vector2Int grid, float vectolx) { }

		// RVA: 0x1E20900 Offset: 0x1E20A01 VA: 0x1E20900
		private bool CanEntryNomoseGymWaterGrid(Vector2Int grid, float height) { }

		// RVA: 0x1E20F00 Offset: 0x1E21001 VA: 0x1E20F00
		public void OnEventEnter(float deltaTime, FieldEventEntity eventEntity) { }

		// RVA: 0x1E20FA0 Offset: 0x1E210A1 VA: 0x1E20FA0
		public void OnEventStay(float deltaTime, FieldEventEntity eventEntity) { }

		// RVA: 0x1E21040 Offset: 0x1E21141 VA: 0x1E21040
		public void OnEventLeave(float deltaTime, FieldEventEntity eventEntity) { }

		// RVA: 0x1E210E0 Offset: 0x1E211E1 VA: 0x1E210E0
		private void OnGroundTrigger() { }

		// RVA: 0x1E210F0 Offset: 0x1E211F1 VA: 0x1E210F0
		public void SetNormalForm(Action onfinish) { }

		// RVA: 0x1E1AF80 Offset: 0x1E1B081 VA: 0x1E1AF80
		private void SettingAttributeFlags() { }

		// RVA: 0x1E1FDC0 Offset: 0x1E1FEC1 VA: 0x1E1FDC0
		private void HitSeRequest() { }

		// RVA: 0x1E1AF70 Offset: 0x1E1B071 VA: 0x1E1AF70
		private void HitSEReset() { }

		// RVA: 0x1E19A60 Offset: 0x1E19B61 VA: 0x1E19A60
		private void LaetPlayHitSE(float time) { }

		// RVA: 0x1E1F470 Offset: 0x1E1F571 VA: 0x1E1F470
		private bool DashJudgment(double inputforce) { }

		// RVA: 0x1E212E0 Offset: 0x1E213E1 VA: 0x1E212E0
		public void SetEventCorrectionMove(Vector3 position, float angle) { }

		// RVA: 0x1E21300 Offset: 0x1E21401 VA: 0x1E21300
		public void StartEventCorrectionMove() { }

		// RVA: 0x1E21310 Offset: 0x1E21411 VA: 0x1E21310
		public bool IsEventCorrectionMoveEnd() { }

		// RVA: 0x1E1CE40 Offset: 0x1E1CF41 VA: 0x1E1CE40
		private bool CorrectionMove(Vector3 position, float deltaTime) { }

		// RVA: 0x1E1D030 Offset: 0x1E1D131 VA: 0x1E1D030
		private bool CorrectionRotate(float angle) { }

		// RVA: 0x1E215B0 Offset: 0x1E216B1 VA: 0x1E215B0
		private bool IsIgnoreWalkCountZone(ZoneID zoneId) { }

		// RVA: 0x1E215D0 Offset: 0x1E216D1 VA: 0x1E215D0
		private bool IsIgnoreEggHatchCountZone(ZoneID zoneId) { }

		// RVA: 0x1E19440 Offset: 0x1E19541 VA: 0x1E19440
		private void UpdateWalkCount() { }

		// RVA: 0x1E21610 Offset: 0x1E21711 VA: 0x1E21610
		private bool NoWalkUpdateAttribute() { }

		// RVA: 0x1E21890 Offset: 0x1E21991 VA: 0x1E21890
		private bool IsEncount() { }

		// RVA: 0x1E21170 Offset: 0x1E21271 VA: 0x1E21170
		public void ChangeForm(int form, Action onFinish) { }

		// RVA: 0x1E219E0 Offset: 0x1E21AE1 VA: 0x1E219E0
		private void ChangeAnime(float time) { }

		// RVA: 0x1E21B50 Offset: 0x1E21C51 VA: 0x1E21B50
		public void JumpPlayerActionEvent(string label) { }

		// RVA: 0x1E18EC0 Offset: 0x1E18FC1 VA: 0x1E18EC0
		private void KairikiPushObject(float deltaTime) { }

		// RVA: 0x1E189D0 Offset: 0x1E18AD1 VA: 0x1E189D0
		private void LimitHeight() { }

		// RVA: 0x1E21BF0 Offset: 0x1E21CF1 VA: 0x1E21BF0
		public void WorkApplyVisibility() { }

		// RVA: 0x1E20530 Offset: 0x1E20631 VA: 0x1E20530
		private void UpdateIdle() { }

		// RVA: 0x1E21CC0 Offset: 0x1E21DC1 VA: 0x1E21CC0
		private int GetNextGesture() { }

		// RVA: 0x1E21D90 Offset: 0x1E21E91 VA: 0x1E21D90
		public void PlayIdle(float duration) { }

		// RVA: 0x1E21330 Offset: 0x1E21431 VA: 0x1E21330
		public void PlayIdle() { }

		// RVA: 0x1E21E80 Offset: 0x1E21F81 VA: 0x1E21E80 Slot: 16
		public override void GetIdleAnimationIndex(out int index, out float duration) { }

		// RVA: 0x1E21FB0 Offset: 0x1E220B1 VA: 0x1E21FB0
		public bool IsIdle() { }

		// RVA: 0x1E21FD0 Offset: 0x1E220D1 VA: 0x1E21FD0
		public void GetWalkAnimationIndex(out int index, out float duration) { }

		// RVA: 0x1E1FDD0 Offset: 0x1E1FED1 VA: 0x1E1FDD0
		public void PlayWalk() { }

		// RVA: 0x1E212B0 Offset: 0x1E213B1 VA: 0x1E212B0
		public bool IsWalk() { }

		// RVA: 0x1E1C8C0 Offset: 0x1E1C9C1 VA: 0x1E1C8C0
		public void PlayRun() { }

		// RVA: 0x1E1A5A0 Offset: 0x1E1A6A1 VA: 0x1E1A5A0
		public bool IsRun() { }

		// RVA: 0x1E1FC00 Offset: 0x1E1FD01 VA: 0x1E1FC00
		public void PlayWallWalk() { }

		// RVA: 0x1E22100 Offset: 0x1E22201 VA: 0x1E22100
		public void PlayNaminoriStart() { }

		// RVA: 0x1E221C0 Offset: 0x1E222C1 VA: 0x1E221C0
		public void PlayNaminoriEnd() { }

		// RVA: 0x1E22280 Offset: 0x1E22381 VA: 0x1E22280
		public void PlayNaminoriLoop() { }

		// RVA: 0x1E1A410 Offset: 0x1E1A511 VA: 0x1E1A410
		public void PlayJumpStart() { }

		// RVA: 0x1E1C5C0 Offset: 0x1E1C6C1 VA: 0x1E1C5C0
		public void PlayJumpLoop() { }

		// RVA: 0x1E1C6B0 Offset: 0x1E1C7B1 VA: 0x1E1C6B0
		public void PlayJumpEnd() { }

		// RVA: 0x1E222A0 Offset: 0x1E223A1 VA: 0x1E222A0
		public void PlayHandOver() { }

		// RVA: 0x1E222C0 Offset: 0x1E223C1 VA: 0x1E222C0
		public void PlaySit() { }

		// RVA: 0x1E222E0 Offset: 0x1E223E1 VA: 0x1E222E0
		public void PlaySquat() { }

		// RVA: 0x1E22300 Offset: 0x1E22401 VA: 0x1E22300
		public void PlayGetPause() { }

		// RVA: 0x1E22320 Offset: 0x1E22421 VA: 0x1E22320
		public void PlayPoketchStart() { }

		// RVA: 0x1E223B0 Offset: 0x1E224B1 VA: 0x1E223B0
		public void PlayPoketchLoop() { }

		// RVA: 0x1E22440 Offset: 0x1E22541 VA: 0x1E22440
		public void PlayPoketchEnd() { }

		// RVA: 0x1E224D0 Offset: 0x1E225D1 VA: 0x1E224D0
		public bool IsPlayPoketchLoop() { }

		// RVA: 0x1E22570 Offset: 0x1E22671 VA: 0x1E22570
		public void PlaySwampStart() { }

		// RVA: 0x1E22590 Offset: 0x1E22691 VA: 0x1E22590
		public void PlaySwampLoop() { }

		// RVA: 0x1E225B0 Offset: 0x1E226B1 VA: 0x1E225B0
		public void PlaySwampEnd() { }

		// RVA: 0x1E225D0 Offset: 0x1E226D1 VA: 0x1E225D0
		public void PlaySpin(bool restart = False) { }

		// RVA: 0x1E22620 Offset: 0x1E22721 VA: 0x1E22620
		public void PlayWatering() { }

		// RVA: 0x1E226F0 Offset: 0x1E227F1 VA: 0x1E226F0
		public void PlayWateringLoop() { }

		// RVA: 0x1E22710 Offset: 0x1E22811 VA: 0x1E22710
		public void PlayWateringEnd() { }

		// RVA: 0x1E22780 Offset: 0x1E22881 VA: 0x1E22780
		public void PlayFlyStart() { }

		// RVA: 0x1E227A0 Offset: 0x1E228A1 VA: 0x1E227A0
		public void PlayFlyEnd() { }

		// RVA: 0x1E227C0 Offset: 0x1E228C1 VA: 0x1E227C0
		public void PlayRockClimbUp() { }

		// RVA: 0x1E227E0 Offset: 0x1E228E1 VA: 0x1E227E0
		public void PlayRockClimbDown() { }

		// RVA: 0x1E22800 Offset: 0x1E22901 VA: 0x1E22800
		public bool IsFishingStart() { }

		// RVA: 0x1E22820 Offset: 0x1E22921 VA: 0x1E22820
		public void PlayFishingStart() { }

		// RVA: 0x1E228B0 Offset: 0x1E229B1 VA: 0x1E228B0
		public void PlayFishingLoop() { }

		// RVA: 0x1E22940 Offset: 0x1E22A41 VA: 0x1E22940
		public void PlayFishingHit() { }

		// RVA: 0x1E229D0 Offset: 0x1E22AD1 VA: 0x1E229D0
		public void PlayFishingHitLoop() { }

		// RVA: 0x1E22A60 Offset: 0x1E22B61 VA: 0x1E22A60
		public void PlayFishingEnd() { }

		// RVA: 0x1E22AF0 Offset: 0x1E22BF1 VA: 0x1E22AF0
		public void PlayFishingSuccess() { }

		// RVA: 0x1E22B80 Offset: 0x1E22C81 VA: 0x1E22B80
		public void PlayFishingSuccessLoop() { }

		// RVA: 0x1E1FEA0 Offset: 0x1E1FFA1 VA: 0x1E1FEA0
		private void BicycleDecelerate(float deltatime) { }

		// RVA: 0x1E22C10 Offset: 0x1E22D11 VA: 0x1E22C10
		public void SetRideBicycle(Action onfinish) { }

		// RVA: 0x1E1A530 Offset: 0x1E1A631 VA: 0x1E1A530
		public bool IsRideBicycle() { }

		// RVA: 0x1E1F290 Offset: 0x1E1F391 VA: 0x1E1F290
		private void ChangeBicycleGear(bool gear) { }

		// RVA: 0x1E1E6E0 Offset: 0x1E1E7E1 VA: 0x1E1E6E0
		private bool GetBicycleGear() { }

		// RVA: 0x1E1A400 Offset: 0x1E1A501 VA: 0x1E1A400
		public void StopBicycleDecelerate() { }

		// RVA: 0x1E1FB70 Offset: 0x1E1FC71 VA: 0x1E1FB70
		public void MaxBicycleDecelerate() { }

		// RVA: 0x1E22D10 Offset: 0x1E22E11 VA: 0x1E22D10
		public void SetIceFloorDirty() { }

		// RVA: 0x1E17960 Offset: 0x1E17A61 VA: 0x1E17960
		private bool CheckIceFloor(float deltaTime) { }

		// RVA: 0x1E22FB0 Offset: 0x1E230B1 VA: 0x1E22FB0
		private Vector3 CalcIceMoveDirection(Vector3 inputVector) { }

		// RVA: 0x1E17EC0 Offset: 0x1E17FC1 VA: 0x1E17EC0
		private void StartIceFloor() { }

		// RVA: 0x1E232F0 Offset: 0x1E233F1 VA: 0x1E232F0
		private void EndIceFloor() { }

		// RVA: 0x1E1D0E0 Offset: 0x1E1D1E1 VA: 0x1E1D0E0
		private void UpdateIceFloor(float deltaTime) { }

		// RVA: 0x1E23520 Offset: 0x1E23621 VA: 0x1E23520
		private Vector3 CalcAdjustIceFloorMoveDirection() { }

		// RVA: 0x1E23680 Offset: 0x1E23781 VA: 0x1E23680
		private void CheckColSnowBall(Vector3 direction, float speed) { }

		// RVA: 0x1E23A80 Offset: 0x1E23B81 VA: 0x1E23A80
		private void CrashSnowBall(FieldObjectEntity entity) { }

		// RVA: 0x1E230C0 Offset: 0x1E231C1 VA: 0x1E230C0
		private bool CheckColIceFloor(Vector3 direction, float speed, out Vector3 outVelocity) { }

		// RVA: 0x1E23C30 Offset: 0x1E23D31 VA: 0x1E23C30
		private bool CheckColNpcIceFloor(Vector3 direction, float speed) { }

		// RVA: 0x1E233F0 Offset: 0x1E234F1 VA: 0x1E233F0
		private float UpdateIceSpeed(float deltaTime) { }

		// RVA: 0x1E23930 Offset: 0x1E23A31 VA: 0x1E23930
		private void CheckIceSlope() { }

		// RVA: 0x1E24070 Offset: 0x1E24171 VA: 0x1E24070
		private Vector2Int CheckIceSlopeFloor() { }

		// RVA: 0x1E22F00 Offset: 0x1E23001 VA: 0x1E22F00
		private bool IsIceGrid(Vector2Int grid, float height) { }

		// RVA: 0x1E182B0 Offset: 0x1E183B1 VA: 0x1E182B0
		private bool CheckMoveFloor(float deltaTime) { }

		// RVA: 0x1E24550 Offset: 0x1E24651 VA: 0x1E24550
		private FieldPlayerEntity.MoveFloorType CheckMoveFloorGrid(Vector2Int grid, float height) { }

		// RVA: 0x1E18370 Offset: 0x1E18471 VA: 0x1E18370
		private void StartMoveFloor() { }

		// RVA: 0x1E24670 Offset: 0x1E24771 VA: 0x1E24670
		private void EndMoveFloor() { }

		// RVA: 0x1E1D4D0 Offset: 0x1E1D5D1 VA: 0x1E1D4D0
		private void UpdateMoveFloor(float deltaTime) { }

		// RVA: 0x1E24760 Offset: 0x1E24861 VA: 0x1E24760
		private Vector3 GetMoveFloorDirection() { }

		// RVA: 0x1E24900 Offset: 0x1E24A01 VA: 0x1E24900
		private bool CheckColMoveFloor(Vector3 direction, float speed, out Vector3 outVelocity) { }

		// RVA: 0x1E24910 Offset: 0x1E24A11 VA: 0x1E24910
		public void ChangeSwim(bool swim) { }

		// RVA: 0x1E1ECA0 Offset: 0x1E1EDA1 VA: 0x1E1ECA0
		public bool IsSwim() { }

		// RVA: 0x1E24AA0 Offset: 0x1E24BA1 VA: 0x1E24AA0
		private Vector3 CalcCheckFrontGridDirection() { }

		// RVA: 0x1E1EEB0 Offset: 0x1E1EFB1 VA: 0x1E1EEB0
		public bool CheckSwim() { }

		// RVA: 0x1E24AE0 Offset: 0x1E24BE1 VA: 0x1E24AE0
		private FieldGridCollision.GridCollisionType CheckGridCollisionCheckSwimCore(Vector2Int grid) { }

		// RVA: 0x1E24C90 Offset: 0x1E24D91 VA: 0x1E24C90
		public Vector3 CalcSwimTargetPosition() { }

		// RVA: 0x1E25130 Offset: 0x1E25231 VA: 0x1E25130
		private FieldGridCollision.GridCollisionType CheckGridCollisionCalcSwimCore(Vector2Int grid, float waterPositionY) { }

		// RVA: 0x1E1ED10 Offset: 0x1E1EE11 VA: 0x1E1ED10
		private bool UpdateSwim(float deltaTime) { }

		// RVA: 0x1E25240 Offset: 0x1E25341 VA: 0x1E25240
		private bool CheckEndSwim(Vector2 inputDir) { }

		// RVA: 0x1E25BA0 Offset: 0x1E25CA1 VA: 0x1E25BA0
		private FieldGridCollision.GridCollisionType CheckGridCollisionEndSwimCore(Vector2Int grid) { }

		// RVA: 0x1E25D50 Offset: 0x1E25E51 VA: 0x1E25D50
		public Vector3 CalcSwimEndTargetPosition() { }

		// RVA: 0x1E261C0 Offset: 0x1E262C1 VA: 0x1E261C0
		private FieldGridCollision.GridCollisionType CheckGridCollisionCalcSwimEndCore(Vector2Int grid, float landPositionY) { }

		// RVA: 0x1E1F1F0 Offset: 0x1E1F2F1 VA: 0x1E1F1F0
		public void RequestStartSwimEvent() { }

		// RVA: 0x1E256B0 Offset: 0x1E257B1 VA: 0x1E256B0
		private void RequestEndSwimEvent() { }

		// RVA: 0x1E16AF0 Offset: 0x1E16BF1 VA: 0x1E16AF0
		public void StartSwimEvent() { }

		// RVA: 0x1E16B90 Offset: 0x1E16C91 VA: 0x1E16B90
		private void EndSwimEvent() { }

		// RVA: 0x1E262D0 Offset: 0x1E263D1 VA: 0x1E262D0
		public void AppearSwimBiidaru(float ofs, float time) { }

		// RVA: 0x1E266A0 Offset: 0x1E267A1 VA: 0x1E266A0
		public void DisappearSwimBiidaru(float ofs, float time) { }

		// RVA: 0x1E267A0 Offset: 0x1E268A1 VA: 0x1E267A0
		public void UpdateSwimEffect(float time) { }

		// RVA: 0x1E269A0 Offset: 0x1E26AA1 VA: 0x1E269A0
		public void PlaySwimEffect() { }

		// RVA: 0x1E26BC0 Offset: 0x1E26CC1 VA: 0x1E26BC0
		private void PlayNaminoriLoopSE(float time) { }

		// RVA: 0x1E26D10 Offset: 0x1E26E11 VA: 0x1E26D10
		public void PlayWaterFallUpEffect() { }

		// RVA: 0x1E26F10 Offset: 0x1E27011 VA: 0x1E26F10
		public void PlayWaterFallDownEffect() { }

		// RVA: 0x1E26D20 Offset: 0x1E26E21 VA: 0x1E26D20
		private void PlayWaterFallEffectCommon(float yawAngle) { }

		// RVA: 0x1E26C90 Offset: 0x1E26D91 VA: 0x1E26C90
		public void StopSwimEffect() { }

		// RVA: 0x1E26F20 Offset: 0x1E27021 VA: 0x1E26F20
		public bool IsBusySwimEffect() { }

		// RVA: 0x1E16AE0 Offset: 0x1E16BE1 VA: 0x1E16AE0
		private void UpdateParts(float deltaTime) { }

		// RVA: 0x1E176A0 Offset: 0x1E177A1 VA: 0x1E176A0
		private void LateUpdateParts(float deltaTime) { }

		[CompilerGeneratedAttribute] // RVA: 0x9F650 Offset: 0x9F751 VA: 0x9F650
									 // RVA: 0x1E27100 Offset: 0x1E27201 VA: 0x1E27100
		public Transform get_BiidaruTransform() { }

		[CompilerGeneratedAttribute] // RVA: 0x9F660 Offset: 0x9F761 VA: 0x9F660
									 // RVA: 0x1E27110 Offset: 0x1E27211 VA: 0x1E27110
		private void set_BiidaruTransform(Transform value) { }

		// RVA: 0x1E27120 Offset: 0x1E27221 VA: 0x1E27120
		public void ResetBiidaruOffset() { }

		// RVA: 0x1E26430 Offset: 0x1E26531 VA: 0x1E26430
		private void MoveBiidaruOffset(Vector3 start, Vector3 end, float time) { }

		// RVA: 0x1E26F30 Offset: 0x1E27031 VA: 0x1E26F30
		private void UpdateBiidaru(float deltaTime) { }

		// RVA: 0x1E26490 Offset: 0x1E26591 VA: 0x1E26490
		private void UpdateBiidaruNode() { }

		[CompilerGeneratedAttribute] // RVA: 0x9F670 Offset: 0x9F771 VA: 0x9F670
									 // RVA: 0x1E271C0 Offset: 0x1E272C1 VA: 0x1E271C0
		public FieldFloatMove get_VisiblePodMove() { }

		[CompilerGeneratedAttribute] // RVA: 0x9F680 Offset: 0x9F781 VA: 0x9F680
									 // RVA: 0x1E271D0 Offset: 0x1E272D1 VA: 0x1E271D0
		private void set_VisiblePodMove(FieldFloatMove value) { }

		// RVA: 0x1E22690 Offset: 0x1E22791 VA: 0x1E22690
		public void VisiblePod(bool visible) { }

		// RVA: 0x1E26F40 Offset: 0x1E27041 VA: 0x1E26F40
		private void UpdateVisiblePod(float deltaTime) { }

		// RVA: 0x1E271E0 Offset: 0x1E272E1 VA: 0x1E271E0
		public Transform GetPodEffectAttachTransform() { }

		// RVA: 0x1E272D0 Offset: 0x1E273D1 VA: 0x1E272D0
		public bool CheckRockClimbing(FieldObjectEntity eventObject) { }

		// RVA: 0x1E276A0 Offset: 0x1E277A1 VA: 0x1E276A0
		public void CalcRockClimbingTargetPosition(FieldObjectEntity eventObject, out Vector3 climbStart, out Vector3 climbEnd, out Vector3 standPos) { }

		// RVA: 0x1E27A30 Offset: 0x1E27B31 VA: 0x1E27A30
		public Vector3 CalcRockClimbingAnotherTalkPosition(FieldObjectEntity eventObject) { }

		// RVA: 0x1E27530 Offset: 0x1E27631 VA: 0x1E27530
		private Vector3 CalcRockClimbingDirection(FieldObjectEntity eventObject) { }

		// RVA: 0x1E27AB0 Offset: 0x1E27BB1 VA: 0x1E27AB0
		public void PlayRockClimbEffect() { }

		// RVA: 0x1E27C20 Offset: 0x1E27D21 VA: 0x1E27C20
		public void StopRockClimbEffect() { }

		// RVA: 0x1E18530 Offset: 0x1E18631 VA: 0x1E18530
		private bool CheckSwampDeep(float deltaTime) { }

		// RVA: 0x1E18630 Offset: 0x1E18731 VA: 0x1E18630
		private void StartSwampDeep() { }

		// RVA: 0x1E27D20 Offset: 0x1E27E21 VA: 0x1E27D20
		private void EndSwampDeep() { }

		// RVA: 0x1E1D880 Offset: 0x1E1D981 VA: 0x1E1D880
		private void UpdateSwampDeep(float deltaTime) { }

		// RVA: 0x1E27C70 Offset: 0x1E27D71 VA: 0x1E27C70
		private bool IsSwampDeepGrid(Vector2Int grid, float height) { }

		// RVA: 0x1E256C0 Offset: 0x1E257C1 VA: 0x1E256C0
		private bool CheckWaterfallDown(Vector2 inputDir) { }

		// RVA: 0x1E27E30 Offset: 0x1E27F31 VA: 0x1E27E30
		public Vector3 CalcWaterfallDownTargetPosition() { }

		// RVA: 0x1E25980 Offset: 0x1E25A81 VA: 0x1E25980
		public bool CheckWaterfallUp() { }

		// RVA: 0x1E28000 Offset: 0x1E28101 VA: 0x1E28000
		public Vector3 CalcWaterfallUpTargetPosition() { }

		// RVA: 0x1E25B50 Offset: 0x1E25C51 VA: 0x1E25B50
		public void WaterfallUpEvent() { }

		// RVA: 0x1E25930 Offset: 0x1E25A31 VA: 0x1E25930
		private void WaterfallDownEvent() { }

		// RVA: 0x1E281D0 Offset: 0x1E282D1 VA: 0x1E281D0
		public void .ctor() { }

		// RVA: 0x1E28510 Offset: 0x1E28611 VA: 0x1E28510
		private static void .cctor() { }

		[CompilerGeneratedAttribute] // RVA: 0x9F690 Offset: 0x9F791 VA: 0x9F690
									 // RVA: 0x1E1F5B0 Offset: 0x1E1F6B1 VA: 0x1E1F5B0
		private float <UpdateInputOperation>g__CalcMoveSpeed|124_0(bool dashFlag, bool colHit, ref FieldPlayerEntity.<>c__DisplayClass124_0 ) { }

	[CompilerGeneratedAttribute] // RVA: 0x9F6A0 Offset: 0x9F7A1 VA: 0x9F6A0
								 // RVA: 0x1E28580 Offset: 0x1E28681 VA: 0x1E28580
		private void <PlaySwimEffect>b__302_0(EffectInstance instance) { }

		[CompilerGeneratedAttribute] // RVA: 0x9F6B0 Offset: 0x9F7B1 VA: 0x9F6B0
									 // RVA: 0x1E28590 Offset: 0x1E28691 VA: 0x1E28590
		private void <PlayWaterFallEffectCommon>b__306_0(EffectInstance instance) { }

		[CompilerGeneratedAttribute] // RVA: 0x9F6C0 Offset: 0x9F7C1 VA: 0x9F6C0
									 // RVA: 0x1E285A0 Offset: 0x1E286A1 VA: 0x1E285A0
		private void <PlayRockClimbEffect>b__335_0(EffectInstance instance) { }

		[CompilerGeneratedAttribute] // RVA: 0x9F6D0 Offset: 0x9F7D1 VA: 0x9F6D0
									 // RVA: 0x1E285B0 Offset: 0x1E286B1 VA: 0x1E285B0
		private void <UpdateSwampDeep>b__348_0(EffectInstance eff) { }
	}
}
