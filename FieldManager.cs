using System;
using System.Collections.Generic;
using System.Text;

namespace BDSP
{
    class FieldManager
    {
		[CompilerGeneratedAttribute] // RVA: 0x7E570 Offset: 0x7E671 VA: 0x7E570
		private static FieldManager<Instance> k__BackingField; // 0x0
		private const int MapSize = 64;
		[CompilerGeneratedAttribute] // RVA: 0x7E580 Offset: 0x7E681 VA: 0x7E580
		private Action OnZoneChangeEvent; // 0x10
		public Action OnZoneChangeOnce; // 0x18
		[CompilerGeneratedAttribute] // RVA: 0x7E590 Offset: 0x7E691 VA: 0x7E590
		private Action OnSceneInitEvent; // 0x20
		public static FieldWalkingManager fwMng; // 0x8
		public static Utils.AssetUnloader abUnloader; // 0x10
		[CompilerGeneratedAttribute] // RVA: 0x7E5A0 Offset: 0x7E6A1 VA: 0x7E5A0
		private static bool <IsResume>k__BackingField; // 0x18
	private FieldManager.UpdateType _updateType; // 0x28
		private FieldManager.EncountUpdateType _encountUpdateType; // 0x2C
		private float _encountWait; // 0x30
		private FieldManager.EncountFadeType _encountFadeType; // 0x34
		private Queue<FieldManager.AttributeEvent> _attributeEntitySE; // 0x38
		private Queue<FieldManager.AttributeEvent> _attributeEntityEffect; // 0x40
		public MapType NowMapType; // 0x48
		public MapType OldMapType; // 0x4C
		private ZoneID _now_zoneID; // 0x50
		[CompilerGeneratedAttribute] // RVA: 0x7E5B0 Offset: 0x7E6B1 VA: 0x7E5B0
		private ZoneID<Before_zoneID> k__BackingField; // 0x54
		private FieldManager.LoadEffectData[] _effectDataArray; // 0x58
		private EffectInstance _weatherEffectInstance; // 0x60
		private SYS_WEATHER _nowWeather; // 0x68
		private FieldWeather _weather; // 0x70
		public FieldMistWork MistWork; // 0x78
		public FieldFlashWork FlashWork; // 0x80
		private TrainerID _btl_trainerID1; // 0x88
		private TrainerID _btl_trainerID2; // 0x8C
		private GameObject _ug_hole; // 0x90
		private bool _is_ugHoleLock; // 0x98
		private Vector3 _ugHolePos; // 0x9C
		private UgMainProc _ugMainProc; // 0xA8
		private GameObject _fldCanvasObject; // 0xB0
		private AssetRequestOperation _fldCanvasAssetReqOpe; // 0xB8
		private int _oldEncountWalkCount; // 0xC0
		private EncountFadeTextures _encFadeTextures; // 0xC8
		private Material _encFadeMaterial; // 0xD0
		private AssetRequestOperation _encFadeTexturesReqOpe; // 0xD8
		private EncountResult _encResult; // 0xE0
		private EncEffectSequenceController _encEffctController; // 0xE8
		private int _encEffectCount; // 0xF0
		private GameObject[] _encEffectAsset; // 0xF8
		private bool _encountAttriLog; // 0x100
		private FieldFishing _fishing; // 0x108
		private FishingRod _useRod; // 0x110
		private FieldManager.FieldWazaAction _wazaAction; // 0x118
		[CompilerGeneratedAttribute] // RVA: 0x7E5C0 Offset: 0x7E6C1 VA: 0x7E5C0
		private bool <IsMenuOpen>k__BackingField; // 0x120
	private bool _isMenuOpenRequest; // 0x121
		private float _shortCutPushTime; // 0x124
		private int _shortCutPushHoldId; // 0x128
		[CompilerGeneratedAttribute] // RVA: 0x7E5D0 Offset: 0x7E6D1 VA: 0x7E5D0
		private bool <IsPoketchOpen>k__BackingField; // 0x12C
	public bool SND_W_ID_CTRL_BGM_FLAG; // 0x12D
		[CompilerGeneratedAttribute] // RVA: 0x7E5E0 Offset: 0x7E6E1 VA: 0x7E5E0
		private KinomiResources<KinomiResources> k__BackingField; // 0x130
		private FieldManager.UpdateType _demoReturnType; // 0x138
		private bool _demoReturnInput; // 0x13C
		private uint _WalkEventName_Attribute; // 0x140
		private bool _initFlag; // 0x144
		private FieldManager.AutoSaveState _autoSaveState; // 0x148
		public static bool SealPrevFalg; // 0x19
		public Vector3 eventTownMapPos; // 0x14C
		private List<int> unnnoonFormList; // 0x158
		private int _shorCutSeq; // 0x160
		private Transform _akLisnerTransform; // 0x168

		// Properties
		public static FieldManager Instance { get; set; }
		public static bool IsResume { get; set; }
		public FieldManager.UpdateType updateType { get; }
		public MapInfo.SheetZoneData ZoneData { get; }
		public AreaID areaID { get; }
		public ZoneID zoneID { get; }
		public ZoneID Before_zoneID { get; set; }
		public GameObject UG_Hole { get; }
		public static bool IsWazaActionEnd { get; }
		public uint _nowEventId { get; set; }
		public bool IsMenuOpen { get; set; }
		public bool IsPoketchOpen { get; set; }
		public KinomiResources KinomiResources { get; set; }

		// Methods

		[CompilerGeneratedAttribute] // RVA: 0x9E750 Offset: 0x9E851 VA: 0x9E750
									 // RVA: 0x182B970 Offset: 0x182BA71 VA: 0x182B970
		private static void set_Instance(FieldManager value) { }

		[CompilerGeneratedAttribute] // RVA: 0x9E760 Offset: 0x9E861 VA: 0x9E760
									 // RVA: 0x182B9E0 Offset: 0x182BAE1 VA: 0x182B9E0
		public static FieldManager get_Instance() { }

		[CompilerGeneratedAttribute] // RVA: 0x9E770 Offset: 0x9E871 VA: 0x9E770
									 // RVA: 0x182BA50 Offset: 0x182BB51 VA: 0x182BA50
		public void add_OnZoneChangeEvent(Action value) { }

		[CompilerGeneratedAttribute] // RVA: 0x9E780 Offset: 0x9E881 VA: 0x9E780
									 // RVA: 0x182BB00 Offset: 0x182BC01 VA: 0x182BB00
		public void remove_OnZoneChangeEvent(Action value) { }

		[CompilerGeneratedAttribute] // RVA: 0x9E790 Offset: 0x9E891 VA: 0x9E790
									 // RVA: 0x182BBB0 Offset: 0x182BCB1 VA: 0x182BBB0
		public void add_OnSceneInitEvent(Action value) { }

		[CompilerGeneratedAttribute] // RVA: 0x9E7A0 Offset: 0x9E8A1 VA: 0x9E7A0
									 // RVA: 0x182BC60 Offset: 0x182BD61 VA: 0x182BC60
		public void remove_OnSceneInitEvent(Action value) { }

		[CompilerGeneratedAttribute] // RVA: 0x9E7B0 Offset: 0x9E8B1 VA: 0x9E7B0
									 // RVA: 0x182BD10 Offset: 0x182BE11 VA: 0x182BD10
		public static bool get_IsResume() { }

		[CompilerGeneratedAttribute] // RVA: 0x9E7C0 Offset: 0x9E8C1 VA: 0x9E7C0
									 // RVA: 0x182BD80 Offset: 0x182BE81 VA: 0x182BD80
		private static void set_IsResume(bool value) { }

		// RVA: 0x182BDF0 Offset: 0x182BEF1 VA: 0x182BDF0
		public FieldManager.UpdateType get_updateType() { }

		// RVA: 0x182BE00 Offset: 0x182BF01 VA: 0x182BE00
		public MapInfo.SheetZoneData get_ZoneData() { }

		// RVA: 0x182BEA0 Offset: 0x182BFA1 VA: 0x182BEA0
		public AreaID get_areaID() { }

		// RVA: 0x182BEC0 Offset: 0x182BFC1 VA: 0x182BEC0
		public ZoneID get_zoneID() { }

		[CompilerGeneratedAttribute] // RVA: 0x9E7D0 Offset: 0x9E8D1 VA: 0x9E7D0
									 // RVA: 0x182BEE0 Offset: 0x182BFE1 VA: 0x182BEE0
		private void set_Before_zoneID(ZoneID value) { }

		[CompilerGeneratedAttribute] // RVA: 0x9E7E0 Offset: 0x9E8E1 VA: 0x9E7E0
									 // RVA: 0x182BEF0 Offset: 0x182BFF1 VA: 0x182BEF0
		public ZoneID get_Before_zoneID() { }

		// RVA: 0x182BF00 Offset: 0x182C001 VA: 0x182BF00
		public GameObject get_UG_Hole() { }

		// RVA: 0x182BF10 Offset: 0x182C011 VA: 0x182BF10
		public static bool get_IsWazaActionEnd() { }

		// RVA: 0x182BFF0 Offset: 0x182C0F1 VA: 0x182BFF0
		public uint get__nowEventId() { }

		// RVA: 0x182C070 Offset: 0x182C171 VA: 0x182C070
		public void set__nowEventId(uint value) { }

		[CompilerGeneratedAttribute] // RVA: 0x9E7F0 Offset: 0x9E8F1 VA: 0x9E7F0
									 // RVA: 0x182C160 Offset: 0x182C261 VA: 0x182C160
		private void set_IsMenuOpen(bool value) { }

		[CompilerGeneratedAttribute] // RVA: 0x9E800 Offset: 0x9E901 VA: 0x9E800
									 // RVA: 0x182C170 Offset: 0x182C271 VA: 0x182C170
		public bool get_IsMenuOpen() { }

		[CompilerGeneratedAttribute] // RVA: 0x9E810 Offset: 0x9E911 VA: 0x9E810
									 // RVA: 0x182C180 Offset: 0x182C281 VA: 0x182C180
		private void set_IsPoketchOpen(bool value) { }

		[CompilerGeneratedAttribute] // RVA: 0x9E820 Offset: 0x9E921 VA: 0x9E820
									 // RVA: 0x182C190 Offset: 0x182C291 VA: 0x182C190
		public bool get_IsPoketchOpen() { }

		[CompilerGeneratedAttribute] // RVA: 0x9E830 Offset: 0x9E931 VA: 0x9E830
									 // RVA: 0x182C1A0 Offset: 0x182C2A1 VA: 0x182C1A0
		private void set_KinomiResources(KinomiResources value) { }

		[CompilerGeneratedAttribute] // RVA: 0x9E840 Offset: 0x9E941 VA: 0x9E840
									 // RVA: 0x182C1B0 Offset: 0x182C2B1 VA: 0x182C1B0
		public KinomiResources get_KinomiResources() { }

		// RVA: 0x182C1C0 Offset: 0x182C2C1 VA: 0x182C1C0
		public void .ctor() { }

		// RVA: 0x182C8B0 Offset: 0x182C9B1 VA: 0x182C8B0
		private void SeqOnDestroy() { }

		// RVA: 0x182C9F0 Offset: 0x182CAF1 VA: 0x182C9F0
		public void SetDefaultParam() { }

		[IteratorStateMachineAttribute] // RVA: 0x9E850 Offset: 0x9E951 VA: 0x9E850
										// RVA: 0x1824BC0 Offset: 0x1824CC1 VA: 0x1824BC0
		public IEnumerator SceneInit() { }

		// RVA: 0x182CA50 Offset: 0x182CB51 VA: 0x182CA50
		private bool IsSavedMapType(MapType mapType) { }

		// RVA: 0x182CA70 Offset: 0x182CB71 VA: 0x182CA70
		private bool IsTownMapNoSavedZone(ZoneID zoneid) { }

		// RVA: 0x1824C40 Offset: 0x1824D41 VA: 0x1824C40
		public bool IsSceneLoadEnd() { }

		// RVA: 0x1824D00 Offset: 0x1824E01 VA: 0x1824D00
		public bool UnUsed_UnloadAsset() { }

		[IteratorStateMachineAttribute] // RVA: 0x9E8C0 Offset: 0x9E9C1 VA: 0x9E8C0
										// RVA: 0x1824D70 Offset: 0x1824E71 VA: 0x1824D70
		public IEnumerator SceneInitAfter() { }

		[IteratorStateMachineAttribute] // RVA: 0x9E930 Offset: 0x9EA31 VA: 0x9E930
										// RVA: 0x182CAC0 Offset: 0x182CBC1 VA: 0x182CAC0
		private IEnumerator EffectLoad() { }

		// RVA: 0x18250E0 Offset: 0x18251E1 VA: 0x18250E0
		public void SceneStart() { }

		// RVA: 0x182D980 Offset: 0x182DA81 VA: 0x182D980
		public void OnDestroy() { }

		// RVA: 0x182DBE0 Offset: 0x182DCE1 VA: 0x182DBE0
		private bool IsDemoReqestStop() { }

		// RVA: 0x182DD20 Offset: 0x182DE21 VA: 0x182DD20
		public void ActiveUpdate() { }

		// RVA: 0x182DA20 Offset: 0x182DB21 VA: 0x182DA20
		public void DeleteUpdate() { }

		// RVA: 0x182DEE0 Offset: 0x182DFE1 VA: 0x182DEE0
		public void update(float deltatime) { }

		// RVA: 0x182F640 Offset: 0x182F741 VA: 0x182F640
		public void lateupdate(float deltatime) { }

		// RVA: 0x182FD40 Offset: 0x182FE41 VA: 0x182FD40
		public void postLateUpdate(float deltatime) { }

		// RVA: 0x182CB40 Offset: 0x182CC41 VA: 0x182CB40
		public void OnZoneChange(bool walk = True) { }

		// RVA: 0x1825030 Offset: 0x1825131 VA: 0x1825030
		public void SetAutoSaveState(FieldManager.AutoSaveState state) { }

		// RVA: 0x18302D0 Offset: 0x18303D1 VA: 0x18302D0
		public bool AutoSave(bool isForce = False, bool mainsave = True, bool backup = True, bool underground = False) { }

		[IteratorStateMachineAttribute] // RVA: 0x9E9A0 Offset: 0x9EAA1 VA: 0x9E9A0
										// RVA: 0x1825060 Offset: 0x1825161 VA: 0x1825060
		public IEnumerator ZoneChangeAutoSave() { }

		// RVA: 0x1824DF0 Offset: 0x1824EF1 VA: 0x1824DF0
		public void ZoneChangeSetZenmetu(ZoneID transition) { }

		[IteratorStateMachineAttribute] // RVA: 0x9EA10 Offset: 0x9EB11 VA: 0x9EA10
										// RVA: 0x1825870 Offset: 0x1825971 VA: 0x1825870
		public IEnumerator OnSceneChange() { }

		// RVA: 0x182E7D0 Offset: 0x182E8D1 VA: 0x182E7D0
		private void fdUpdate(float deltatime) { }

		// RVA: 0x182F7B0 Offset: 0x182F8B1 VA: 0x182F7B0
		private void fdLateUpdate(float deltatime) { }

		// RVA: 0x182E940 Offset: 0x182EA41 VA: 0x182E940
		private void ugUpdate(float deltatime) { }

		// RVA: 0x182F840 Offset: 0x182F941 VA: 0x182F840
		private void ugLateUpdate(float deltatime) { }

		// RVA: 0x182EA80 Offset: 0x182EB81 VA: 0x182EA80
		private void EncountUpdate(float deltatime) { }

		// RVA: 0x1832560 Offset: 0x1832661 VA: 0x1832560
		public void PreLoadEncEffect(string assetname) { }

		// RVA: 0x1830690 Offset: 0x1830791 VA: 0x1830690
		public uint GetNowBgmState() { }

		// RVA: 0x1830AB0 Offset: 0x1830BB1 VA: 0x1830AB0
		public string GetMapBgmState() { }

		// RVA: 0x1832620 Offset: 0x1832721 VA: 0x1832620
		public uint CheckMapBgmState(uint id) { }

		// RVA: 0x1830C30 Offset: 0x1830D31 VA: 0x1830C30
		public string GetEnvironmentalSound() { }

		// RVA: 0x1832780 Offset: 0x1832881 VA: 0x1832780
		public void ResetSaveZoneBgm() { }

		// RVA: 0x1832860 Offset: 0x1832961 VA: 0x1832860
		public void SetCutOutFade(int index) { }

		// RVA: 0x1831340 Offset: 0x1831441 VA: 0x1831340
		private bool CheckEncount() { }

		// RVA: 0x18328B0 Offset: 0x18329B1 VA: 0x18328B0
		private void ResultSetUpWildBattle(EncountResult result, int btlBgIndex, out PokeParty party, out int safariball) { }

		// RVA: 0x1833420 Offset: 0x1833521 VA: 0x1833420
		private ushort GetFormNo(MonsNo mons, int karana, int anno) { }

		// RVA: 0x18335E0 Offset: 0x18336E1 VA: 0x18335E0
		public void EventWildBattle(MonsNo mons, int level, bool isCaptureDemo = False, bool isSymbol = False, bool isMitu = False, byte talentVNum = 0, bool isCantUseBall = False, int formNo = 0, bool tokusei3rd = False) { }

		// RVA: 0x1833800 Offset: 0x1833901 VA: 0x1833800
		public void EventWildBattle(PokeParty pokeParty, bool isCaptureDemo = False, bool isSymbol = False, bool isMitu = False, bool isCantUseBall = False) { }

		// RVA: 0x18331F0 Offset: 0x18332F1 VA: 0x18331F0
		public void EncountStart(FieldManager.EncountFadeType type, TrainerID trainerid1 = 0, TrainerID trainerid2 = 0) { }

		// RVA: 0x1833C20 Offset: 0x1833D21 VA: 0x1833C20
		public bool IsEncountUpdate() { }

		// RVA: 0x182FB40 Offset: 0x182FC41 VA: 0x182FB40
		private void AttributeEventEffect() { }

		// RVA: 0x182F8D0 Offset: 0x182F9D1 VA: 0x182F8D0
		private void AttributeEventSE() { }

		// RVA: 0x1833CF0 Offset: 0x1833DF1 VA: 0x1833CF0
		private void FootSE_Walk(string name, FieldManager.AttributeEventCallType callType, int graphicIndex, Transform tra) { }

		// RVA: 0x1833C30 Offset: 0x1833D31 VA: 0x1833C30
		private void FootSE_Bic(string name) { }

		// RVA: 0x181CC60 Offset: 0x181CD61 VA: 0x181CC60
		public void FootEventEffect(FieldObjectEntity entity, bool running, bool bicycle, FieldManager.AttributeEventCallType calltype) { }

		// RVA: 0x181CA20 Offset: 0x181CB21 VA: 0x181CA20
		public void FootEventSE(FieldObjectEntity entity, bool running, bool bicycle, FieldManager.AttributeEventCallType calltype) { }

		// RVA: 0x1833F50 Offset: 0x1834051 VA: 0x1833F50
		public void RequestAttributeEffect(FieldObjectEntity entity, FieldManager.AttributeEventType attri) { }

		// RVA: 0x1833FF0 Offset: 0x18340F1 VA: 0x1833FF0
		public void RequestAttributeSE(FieldObjectEntity entity, FieldManager.AttributeEventType attri) { }

		// RVA: 0x1834090 Offset: 0x1834191 VA: 0x1834090
		public void CallEffect(EffectFieldID index, Transform parent, Vector3 ofs, Vector3 rot, Action<EffectInstance> loadcallback, UnityAction<EffectInstance> eff_onFinished) { }

		// RVA: 0x1834310 Offset: 0x1834411 VA: 0x1834310
		public void CallEffect(EffectFieldID index, Transform parent, Vector3 ofs, Action<EffectInstance> loadcallback, UnityAction<EffectInstance> eff_onFinished) { }

		// RVA: 0x181EC10 Offset: 0x181ED11 VA: 0x181EC10
		public void CallEffect(EffectFieldID index, Transform parent, Action<EffectInstance> loadcallback, UnityAction<EffectInstance> eff_onFinished) { }

		// RVA: 0x1834450 Offset: 0x1834551 VA: 0x1834450
		public void CallEffect(EffectFieldID index, Vector3 pos, Action<EffectInstance> loadcallback, UnityAction<EffectInstance> eff_onFinished) { }

		[IteratorStateMachineAttribute] // RVA: 0x9EA80 Offset: 0x9EB81 VA: 0x9EA80
										// RVA: 0x18341F0 Offset: 0x18342F1 VA: 0x18341F0
		private IEnumerator PlayEffect(EffectFieldID index, Transform parent, Vector3 pos, Quaternion rot, Action<EffectInstance> loadcallback, UnityAction<EffectInstance> eff_onFinished) { }

		// RVA: 0x1832220 Offset: 0x1832321 VA: 0x1832220
		private bool ControlPoketch() { }

		// RVA: 0x1834580 Offset: 0x1834681 VA: 0x1834580
		public void ChangePoketchLarge() { }

		// RVA: 0x1834710 Offset: 0x1834811 VA: 0x1834710
		public void ChangePoketchSmall() { }

		// RVA: 0x1832450 Offset: 0x1832551 VA: 0x1832450
		public void MenuOpen(float deltatime, bool isIgnoreGround = False) { }

		// RVA: 0x182FEC0 Offset: 0x182FFC1 VA: 0x182FEC0
		private void LateMenuOpen() { }

		// RVA: 0x1832360 Offset: 0x1832461 VA: 0x1832360
		private bool MenuOpenInvalidZone() { }

		// RVA: 0x1834F10 Offset: 0x1835011 VA: 0x1834F10
		private bool OpenUnionRoomWarp(bool isUnderGround) { }

		// RVA: 0x1835240 Offset: 0x1835341 VA: 0x1835240
		public bool IsEnableUnionRoomWarp(bool isUnderGround) { }

		// RVA: 0x1834780 Offset: 0x1834881 VA: 0x1834780
		private bool UseShotCut(float deltatime) { }

		// RVA: 0x18350F0 Offset: 0x18351F1 VA: 0x18350F0
		private bool IsKariEyeHitCheck() { }

		// RVA: 0x1835CB0 Offset: 0x1835DB1 VA: 0x1835CB0
		private void OpenShortCut() { }

		// RVA: 0x1835590 Offset: 0x1835691 VA: 0x1835590
		public void StopShortCutData() { }

		// RVA: 0x1835E40 Offset: 0x1835F41 VA: 0x1835E40
		public void LockHolePos(Vector3 pos) { }

		// RVA: 0x1835E60 Offset: 0x1835F61 VA: 0x1835E60
		public void LockHoleEnd() { }

		// RVA: 0x1835E70 Offset: 0x1835F71 VA: 0x1835E70
		public static void DebugLot(int randmark) { }

		// RVA: 0x1830C50 Offset: 0x1830D51 VA: 0x1830C50
		private void SetMapInfoCameraData(bool isforce) { }

		// RVA: 0x182E700 Offset: 0x182E801 VA: 0x182E700
		private bool CheckWeather() { }

		// RVA: 0x1835F50 Offset: 0x1836051 VA: 0x1835F50
		private void WeatherEffectPlay() { }

		// RVA: 0x1836030 Offset: 0x1836131 VA: 0x1836030
		private void CheckWeatherBGM() { }

		// RVA: 0x1836130 Offset: 0x1836231 VA: 0x1836130
		public void SetCloudShadowBaseEnable() { }

		// RVA: 0x1836150 Offset: 0x1836251 VA: 0x1836150
		public void SetCloudShadowBaseDisable() { }

		// RVA: 0x1836170 Offset: 0x1836271 VA: 0x1836170
		private UIManager.FieldUseResult UI_onFieldWaza(UIManager.FieldWazaParam param) { }

		// RVA: 0x1836320 Offset: 0x1836421 VA: 0x1836320
		public void UI_SelectWaza(WazaNo waza) { }

		// RVA: 0x18364D0 Offset: 0x18365D1 VA: 0x18364D0
		private UIManager.FieldUseResult UI_onUseFieldItem(ItemInfo item) { }

		// RVA: 0x18355A0 Offset: 0x18356A1 VA: 0x18355A0
		private UIManager.FieldUseResult UI_onUseFieldItem(ItemNo id) { }

		// RVA: 0x1836560 Offset: 0x1836661 VA: 0x1836560
		private bool CheckAvailableFieldItem(ItemNo id) { }

		// RVA: 0x1836AD0 Offset: 0x1836BD1 VA: 0x1836AD0
		private bool CheckUseItem() { }

		// RVA: 0x1836D50 Offset: 0x1836E51 VA: 0x1836D50
		private void UseFieldItem() { }

		// RVA: 0x1835620 Offset: 0x1835721 VA: 0x1835620
		private void UseFieldItem(ItemNo itemno) { }

		// RVA: 0x1837260 Offset: 0x1837361 VA: 0x1837260
		private void UI_onWazaFly(ZoneID zoneid, int locatorIndex) { }

		// RVA: 0x18303F0 Offset: 0x18304F1 VA: 0x18303F0
		public bool StopSwayGrass_NextArea() { }

		// RVA: 0x1837330 Offset: 0x1837431 VA: 0x1837330
		private bool CheckIgnoreWeatherSweetEncount(SYS_WEATHER weather) { }

		// RVA: 0x1837370 Offset: 0x1837471 VA: 0x1837370
		public bool StartSweetEncount() { }

		// RVA: 0x1830BB0 Offset: 0x1830CB1 VA: 0x1830BB0
		public void SetBgmEvent(string eventName) { }

		// RVA: 0x18308D0 Offset: 0x18309D1 VA: 0x18308D0
		public void SetBgmEvent(uint eventid) { }

		// RVA: 0x1837C60 Offset: 0x1837D61 VA: 0x1837C60
		public void SetWwiseEvent(string eventName) { }

		// RVA: 0x1837880 Offset: 0x1837981 VA: 0x1837880
		private uint BGMFlagCheck(uint eventid) { }

		// RVA: 0x1837C30 Offset: 0x1837D31 VA: 0x1837C30
		private bool NotSaveBgmEvent(uint eventid) { }

		// RVA: 0x18218E0 Offset: 0x18219E1 VA: 0x18218E0
		public void SetWwiseEvent(uint eventid) { }

		// RVA: 0x1821970 Offset: 0x1821A71 VA: 0x1821970
		public void UniqueBGMEvent(ZoneID nextid, ZoneID oldid) { }

		// RVA: 0x1836EA0 Offset: 0x1836FA1 VA: 0x1836EA0
		public void RidBicycle(Action onfinish) { }

		// RVA: 0x1832120 Offset: 0x1832221 VA: 0x1832120
		private bool FishingUpdate(float time) { }

		// RVA: 0x1837D70 Offset: 0x1837E71 VA: 0x1837D70
		public void SetWazaAction(FieldManager.FieldWazaAction action) { }

		// RVA: 0x1820B80 Offset: 0x1820C81 VA: 0x1820B80
		public void SetTownMapPos(ZoneID zoneid, ref Vector3 pos) { }

		// RVA: 0x1837D80 Offset: 0x1837E81 VA: 0x1837D80
		public void GetTownMapPos(out ZoneID zoneid, out Vector3 pos, bool isForcePrevious = False) { }

		// RVA: 0x1837EE0 Offset: 0x1837FE1 VA: 0x1837EE0
		public void SetAkLisnerTransform(Transform tra) { }

		// RVA: 0x182E600 Offset: 0x182E701 VA: 0x182E600
		public void UpdateAkLisner() { }

		// RVA: 0x1830D50 Offset: 0x1830E51 VA: 0x1830D50
		public void OnZoneChange_Subcontents() { }

		// RVA: 0x1837F10 Offset: 0x1838011 VA: 0x1837F10
		public void CreateFreaiManager() { }

		// RVA: 0x1837FF0 Offset: 0x18380F1 VA: 0x1837FF0
		public void DeleteFreaiManager() { }

		// RVA: 0x1832EA0 Offset: 0x1832FA1 VA: 0x1832EA0
		private void GetLegendPokeEncountInfo(PokemonParam param, out string encSec, ref ArenaID arenaID, out string bgm, out BattleSetupEffectId setupEffect) { }

		// RVA: 0x18380A0 Offset: 0x18381A1 VA: 0x18380A0
		private static FieldEncountTable.Sheetlegendpoke GetFieldEncountTableLegendPoke(MonsNo monsNo, ushort formNo) { }

		// RVA: 0x1831190 Offset: 0x1831291 VA: 0x1831190
		public bool IsEnableSave(bool isIgnoreGround = False) { }

		// RVA: 0x18381C0 Offset: 0x18382C1 VA: 0x18381C0
		public bool IsNoEntry(Vector2Int gridPos, Vector3 worldPos) { }

		// RVA: 0x18382B0 Offset: 0x18383B1 VA: 0x18382B0
		public bool IsNoEntrySea(Vector2Int gridPos, Vector3 worldPos) { }

		// RVA: 0x1833060 Offset: 0x1833161 VA: 0x1833060
		public SYS_WEATHER GetBatleWeather() { }

		// RVA: 0x1838960 Offset: 0x1838A61 VA: 0x1838960
		public UgMainProc GetUgMainProc() { }

		// RVA: 0x1830550 Offset: 0x1830651 VA: 0x1830550
		private void SaveCheckCyclingRoad() { }

		// RVA: 0x18321E0 Offset: 0x18322E1 VA: 0x18321E0
		private bool CheckEnterNazonobasyo() { }

		// RVA: 0x1838970 Offset: 0x1838A71 VA: 0x1838970
		private bool IsNazonobasyoEntrance() { }

		// RVA: 0x1838B60 Offset: 0x1838C61 VA: 0x1838B60
		private bool IsNazonobasyoEntry() { }

		// RVA: 0x1839120 Offset: 0x1839221 VA: 0x1839120
		private static void .cctor() { }

		[CompilerGeneratedAttribute] // RVA: 0x9EAF0 Offset: 0x9EBF1 VA: 0x9EAF0
									 // RVA: 0x18391D0 Offset: 0x18392D1 VA: 0x18391D0
		private void <LateMenuOpen>b__165_0(UIWindow _) { }

		[CompilerGeneratedAttribute] // RVA: 0x9EB00 Offset: 0x9EC01 VA: 0x9EB00
									 // RVA: 0x18393D0 Offset: 0x18394D1 VA: 0x18393D0
		private void <OpenUnionRoomWarp>b__167_0(UIWindow _) { }

		[CompilerGeneratedAttribute] // RVA: 0x9EB10 Offset: 0x9EC11 VA: 0x9EB10
									 // RVA: 0x1839440 Offset: 0x1839541 VA: 0x1839440
		private void <OpenShortCut>b__172_0(ushort itemNo) { }

		[CompilerGeneratedAttribute] // RVA: 0x9EB20 Offset: 0x9EC21 VA: 0x9EB20
									 // RVA: 0x1839740 Offset: 0x1839841 VA: 0x1839740
		private void <OpenShortCut>b__172_1(UIWindow _) { }

		[CompilerGeneratedAttribute] // RVA: 0x9EB30 Offset: 0x9EC31 VA: 0x9EB30
									 // RVA: 0x18397D0 Offset: 0x18398D1 VA: 0x18397D0
		private void <WeatherEffectPlay>b__179_0(EffectInstance eff) { }
	}
}
