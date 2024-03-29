﻿using BDSP.SmartPoint.AssetAssistant;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace BDSP.Dpr.EvScript
{
    public class EvDataManager // TypeDefIndex: 11212
    {
        // Fields
        private static EvDataManager _instanse; // 0x0
        public static bool IsFirstInitializedAfterSaveDataLoad; // 0x8
        private const string Path_Parsons = "persons/field/";
        private const string Path_Poke_Model = "pokemons/field/";
        private const int Graphic_Gimmick = 500;
        private const int Graphic_Poke = 10000;
        private const float HitMinSize = 3;
        private const int Graphic_SekiZou = 1000;
        private const int Graphic_SekiZouMAX = 3000;
        private Action<EntityParam> OnTalkStartCallBack; // 0x10
        private bool _isScriptLoad; // 0x18
        private EvScriptData[] _eventList; // 0x20
        private int _eventListIndex; // 0x28
        private Stack<EvCallData> _callQueue; // 0x30
        private Dictionary<string, int[]> _findAllLabel; // 0x38
        private FieldObjectEntity _hit_object; // 0x40
        private FieldObjectEntity _hit_object_sub; // 0x48
        private Vector3 _hit_position; // 0x50
        private CmpResult _cmp_flag; // 0x5C
        private AssetRequestOperation _scriptOperation; // 0x60
        private AreaID _areaID; // 0x68
        private const int WarpListLength = 30;
        private List<FieldEventEntity> _warpList; // 0x70
        private MapWarp _warpData; // 0x78
        private GameObject _warpRoot; // 0x80
        private EvDataManager.PlaySeData[] _se_datas; // 0x88
        private EvDataManager.PlaySeData[] _voice_datas; // 0x90
        private Vector2Int _eventEndPosition; // 0x98
        private string _posEventLabelReserve; // 0xA0
        private const int EntityParamLength = 50;
        private EntityParam[] _entityParamList; // 0xA8
        private GameObject _stopRoot; // 0xB0
        private bool _isInitFirstMap; // 0xB8
        private FieldObjectEntity<_dummyPlayer> k__BackingField; // 0xC0
        private EvDataManager.UpdateDelegate _updateDelegate; // 0xC8
        private EvDataManager.EventEndDelegate _eventEndDelegate; // 0xD0
        private FieldEventDoorEntity _doorEntity; // 0xD8
        private EvDataManager.WorpEventData _worpEventData; // 0xE0
        private Vector2Int _eqZoneWorpGrid; // 0xF0
        private bool _isEqZoneWorp; // 0xF8
        private FieldEventLiftEntity _liftEntity; // 0x100
        private FieldTobariGymWallEntity _tobariGymWallEntity; // 0x108
        private FieldNagisaGymGearEntity _nagisaGymGearEntity; // 0x110
        private FieldNomoseGymSwitchEntity _nomoseGymSwitchEntity; // 0x118
        private FieldEyePaintingEntity _eyePaintingEntity; // 0x120
        private FieldEmbankmentEntity _embankmentEntity; // 0x128
        private FieldMistPlate _mistPlate; // 0x130
        private FieldPokemonCenter<PokemonCenter> k__BackingField; // 0x138
        private Telescope<Telescope> k__BackingField; // 0x140
        private TelescopeNagisa<TelescopeNagisa> k__BackingField; // 0x148
        private bool AzukariyaInitEventFlag; // 0x150
        private FieldWazaCutIn<FieldWazaCutIn> k__BackingField; // 0x158
        private InterviewWork<InterviewWork> k__BackingField; // 0x160
        private int[] TvCommercials; // 0x168
        private int TvCommercialsCurrentIndex; // 0x170
        private FieldShip<FieldShip> k__BackingField; // 0x178
        private string _callLabel_SceneChange; // 0x180
        private string _callLabel_UpdateSP; // 0x188
        private string _callLabel_AdjustHeroPos; // 0x190
        private const int FieldObjectMoveCodesLength = 200;
        public List<FieldObjectMoveCode> FieldObjectMoveCodes; // 0x198
        private bool _lateUpdateMoveCode; // 0x1A0
        private bool _isCall_TrainerBtl; // 0x1A1
        private EvDataManager.EvCallData _battleReturnData; // 0x1A4
        private FieldObjectEntity _battleReturnHitObject; // 0x1B0
        private const int TRAINER_EYE_HITMAX = 2;
        private const int SCR_EYE_TR_TYPE_SINGLE = 0;
        private const int SCR_EYE_TR_TYPE_DOUBLE = 1;
        private const int SCR_EYE_TR_TYPE_TAG = 2;
        private FieldObjectMoveCode[] _eyeEncountTarget; // 0x1B8
        private Balloon[] _eyeEncountBallon; // 0x1C0
        private float _eyeEncountWait; // 0x1C8
        private int _eyeEncountSeq; // 0x1CC
        private int[] _talkTrinerIndex; // 0x1D0
        public TrainerType Btl_TrainerType1; // 0x1D8
        public TrainerType Btl_TrainerType2; // 0x1DC
        private int _ugSeq; // 0x1E0
        private Vector3 _ugEndPos; // 0x1E4
        private Vector3 _ugHoleRot; // 0x1F0
        private const float _fallSpd = 0.25;
        private const float _fallOffset = 15;
        private const float _fallRotSpd = 35;
        private const float _fallDiveSpd = 15;
        private const float _fallDiveAcce = 0.1;
        private float _ugFallSpdCurrent; // 0x1FC
        private int _ugDiveSeq; // 0x200
        private float _ugDiveUpdateTime; // 0x204
        private float _ugDiveRotTime; // 0x208
        private float _ugDiveRotStart; // 0x20C
        private float _ugDiveRotEnd; // 0x210
        private float _ugDiveJumpingTime; // 0x214
        private const float _fromRotSpd = 50;
        private const float _fromRotAcce = 4;
        private const float _fromRotSpdMin = 10;
        private int _ugFromSeq; // 0x218
        private float _ugFromJumpTime; // 0x21C
        private float _ugFromRotSpdCurrent; // 0x220
        private UgJumpPos.SheetData _ugNextJumpPos; // 0x228
        private FieldToUgInvisibleObjects _toUgInvisibleObjects; // 0x230
        private ZoneID _cacheZoneID_SceneChange; // 0x238
        private bool _pendingInitScripts; // 0x23C
        public ZoneID SorawotobuZoneId; // 0x240
        public int SorawotobuLocatorIndex; // 0x244
        private EventCameraTable _evCameraTable; // 0x248
        private TairyouHasseiPokeManager _tairyouHasseiMane; // 0x250
        private bool _isFadeEventReturnInput; // 0x258
        private float _cloudSpeed; // 0x25C
        private float _cloudTime; // 0x260
        private const float _const_cloudTime = 5;
        private const float _app_frame = 0.033333335;
        private const int _WORK_TRUE = 1;
        private const int _WORK_FALSE = 0;
        private const string SEQ_SE_DP_SELECT = "UI_common_decide";
        private int _switch_work_index; // 0x264
        private float _timeWait; // 0x268
        private MsgWindowParam _msgWindowParam; // 0x270
        private MsgWindowParam _msgWindowParamOther; // 0x278
        private EvDataManager.MsgOpenParam _msgOpenParam; // 0x280
        private bool _isAutoMsg; // 0x2B0
        private MSGSPEED _eMsgSpeed; // 0x2B4
        private float _autoTime; // 0x2B8
        private EvDataManager.BOARD _boardState; // 0x2BC
        private MsgWindow _msgWindow; // 0x2C0
        private MsgWindow _msgWindowOther; // 0x2C8
        private Coroutine _msgWindowCoroutine; // 0x2D0
        private EvDataManager.TalkState _talkStart; // 0x2D8
        private EvCmdID.NAME _macroCmd; // 0x2DC
        private EvCmdID.NAME _procCmd; // 0x2E0
        private string _talkOpenMsbt; // 0x2E8
        private string _talkOpenLabel; // 0x2F0
        private float _turnEndFrame_Hero; // 0x2F8
        private float _turnEndFrame_Obj; // 0x2FC
        private float[] _turnTime; // 0x300
        private Quaternion[] _turnEndQuaternion; // 0x308
        private bool[] _turnDiffFlag; // 0x310
        private float _deltatime; // 0x318
        private string _mapChangeZoneID; // 0x320
        private int _mapChangeIndex; // 0x328
        private Quaternion _moveGridCenterStart; // 0x32C
        private Quaternion _moveGridCenterEnd; // 0x33C
        private bool _isOpenSubContentsMenu; // 0x34C
        private bool _isWaitCheckOnlineAccount; // 0x34D
        private string _custumWindow_msbt; // 0x350
        private List<string> _custumWindow_Labels; // 0x358
        private List<int> _custumWindow_RetIndex; // 0x360
        private FieldEventEntity _selectDoorObject; // 0x368
        private float _fadeSpeed; // 0x370
        private EvDataManager.HeroReqBit _heroReqBit; // 0x374
        private DIR _heroMoveGridCenterFrontDir; // 0x378
        private bool _heroMoveGridCenterFrontStat; // 0x37C
        private FieldObjectMove _fieldObjectMove; // 0x380
        private FieldObjectRotateYaw _fieldObjectRotateYaw; // 0x388
        private FieldFloatMove _fieldFloatMove; // 0x390
        private int _hidenSequence; // 0x398
        private Vector3 _takiTargetPosition; // 0x39C
        private Vector3 _rockClimbingEndPos; // 0x3A8
        private Vector3 _rockClimbingStandPos; // 0x3B4
        private bool _hidenEffectWait; // 0x3C0
        private bool _rideBicycleReserve; // 0x3C1
        private FieldEventLiftEntity _runEventLiftEntity; // 0x3C8
        private int _liftSequence; // 0x3D0
        private int _gearSequence; // 0x3D4
        private int _waterSequence; // 0x3D8
        private int _kinomiSequence; // 0x3DC
        private float _kinomiSequenceTime; // 0x3E0
        private EffectInstance _kinomiEffect; // 0x3E8
        private int _warpSequence; // 0x3F0
        private int _warpSpeedSequence; // 0x3F4
        private float _warpSpeedSequenceTime; // 0x3F8
        private int _scopeSequence; // 0x3FC
        private int _azukariyaSequence; // 0x400
        private int _pokelistSequence; // 0x404
        private int _pokelistBox; // 0x408
        private int _pokelistIndex; // 0x40C
        private int _trainSequence; // 0x410
        private int _itemSequence; // 0x414
        private int _btwrSequence; // 0x418
        private bool _isOpenSpecialWin; // 0x41C
        private int _openSpecialWinLabelSelected; // 0x420
        private TV_PROGRAM _currentTvProgram; // 0x424
        private EvDataManager.CutInState _cutinState; // 0x428
        private const int TRMSG_FIGHT_START = 0;
        private const int TRMSG_FIGHT_LOSE = 1;
        private const int TRMSG_FIGHT_AFTER = 2;
        private const int TRMSG_FIGHT_START_1 = 3;
        private const int TRMSG_FIGHT_LOSE_1 = 4;
        private const int TRMSG_FIGHT_AFTER_1 = 5;
        private const int TRMSG_POKE_ONE_1 = 6;
        private const int TRMSG_FIGHT_START_2 = 7;
        private const int TRMSG_FIGHT_LOSE_2 = 8;
        private const int TRMSG_FIGHT_AFTER_2 = 9;
        private const int TRMSG_POKE_ONE_2 = 10;
        private const int TRMSG_FIGHT_NONE_DN = 11;
        private const int TRMSG_FIGHT_NONE_D = 12;
        private const int TRMSG_FIGHT_FIRST_DAMAGE = 13;
        private const int TRMSG_FIGHT_POKE_HP_HALF = 14;
        private const int TRMSG_FIGHT_POKE_LAST = 15;
        private const int TRMSG_FIGHT_POKE_LAST_HP_HALF = 16;
        private const int TRMSG_REVENGE_FIGHT_START = 17;
        private const int TRMSG_REVENGE_FIGHT_START_1 = 18;
        private const int TRMSG_REVENGE_FIGHT_START_2 = 19;
        private const int MUGEN_LOOP = 5000;
        private bool _isShopOpen; // 0x42C
        private int _bagSelectItemNo; // 0x430
        private FloorWindow _floorWindow; // 0x438
        private MoneyWindow _moneyWindow; // 0x440
        private StringBuilder matchingPassword; // 0x448
        private static Dictionary<int, MonsNo> KasekiFukugenTable; // 0x10
        private int _openTownMapSeq; // 0x450
        private bool _isOpenBtlTowerRecode; // 0x454
        private int _softwareKeyboardSubState; // 0x458
        private int _effSeq; // 0x45C
        private bool _pc_window_close; // 0x460
        private int _dendou; // 0x464
        private FieldAnimatorController[] _umaAnimatorCtr; // 0x468
        private bool _isOpenCustomBallTrainer; // 0x470
        private int _nicknamePlacementSequence; // 0x474
        private EffectInstance[] _scriptEffects; // 0x478
        private Coroutine[] _scriptScaleCorutine; // 0x480
        private bool[] _scriptScaleVectol; // 0x488
        private PokemonParam _temp_PokePara; // 0x490
        private bool _isBattleTowerBtl; // 0x498
        private bool _isBattleTowerWin; // 0x499
        private Vector2 _playerMoveGridCenterAngle; // 0x49C
        private EvScriptData _evData; // 0x4A8
        private EvData.Script _evScript; // 0x4B0
        private EvData.Command _evCommand; // 0x4B8
        private EvData.Aregment[] _evArg; // 0x4C0
        private int btlsearchSeq; // 0x4C8
        private AudioInstance btlserchAudio; // 0x4D0
        private bool _isOpenHallOfFame; // 0x4D8
        private const int RockClimbSequence_None = 0;
        private const int RockClimbSequence_JumpUp = 1;
        private const int RockClimbSequence_JumpLoop = 2;
        private const int RockClimbSequence_Climb = 3;
        private const int RockClimbSequence_EndJumpUp = 4;
        private const int RockClimbSequence_EndJumpLoop = 5;
        private const int RockClimbSequence_EndJumpEnd = 6;
        private Coroutine _cmdReportSaveCoroutine; // 0x4E0
        private int _seqRankingView; // 0x4E8
        private static ValueTuple<int, int, int>[] PokemonSizeTable; // 0x18
        private bool _isOpenCertificate; // 0x4EC
        private int returnSequenceID; // 0x4F0
        public static bool EventCameraEnable; // 0x20
        private bool _boukennootoTipsOpen; // 0x4F4
        private const int FashionSeq_Reqest = 0;
        private const int FashionSeq_Wait = 1;
        private const int FashionSeq_End = 2;
        private const int FashionSeq_Error = 999;
        private int _fashionLoadSeq; // 0x4F8
        private string _oldfashionAssetReqUri; // 0x500
        private AssetRequestOperation _fashionAssetReqOp; // 0x508
        private float _fashionYawAngle; // 0x510
        private Vector3 _fashionWorldpos; // 0x514
        private bool _isTraining; // 0x520
        private bool _isOpenTraining; // 0x521
        private const int LIGHT_FILED = 0;
        private const int LIGHT_CHAR = 1;
        private const int LIGHT_POKE = 2;
        private const int LIGHT_MAX = 3;
        private float[] _setlight_timer; // 0x528
        private float[] _setlight_timer_limit; // 0x530
        private float[] _start_lightIntensity; // 0x538
        private float[] _end_lightIntensity; // 0x540
        private bool[] _isRunningLight; // 0x548
        public List<string> Debug_01_DebugLabel; // 0x550
        public List<string> DebugSceneEventLabel; // 0x558
        private const int FieldObjectEntityLength = 100;
        private const int FieldKinomiGrowEntityLength = 30;
        public List<FieldObjectEntity> _fieldObjectEntity; // 0x560
        public List<FieldKinomiGrowEntity> _FieldKinomiGrowEntity; // 0x568
        private List<EvDataManager.AssetReqOpeRef> _AssetReqOpeList; // 0x570
        private List<EvDataManager.LoadObjectData> _loadObjectList; // 0x578
        private int _loadObjectIndex; // 0x580
        private Transform _loadObjectParent; // 0x588
        private bool _nowInstantiate; // 0x590
        private const int _PoolLength = 100;
        private Dictionary<int, GameObject> _poolLoadObjects; // 0x598

        // Properties
        public static EvDataManager Instanse { get; }
        public bool IsPosEventReserved { get; }
        public FieldObjectEntity _dummyPlayer { get; set; }
        public FieldPokemonCenter PokemonCenter { get; set; }
        public Telescope Telescope { get; set; }
        public TelescopeNagisa TelescopeNagisa { get; set; }
        public FieldWazaCutIn FieldWazaCutIn { get; set; }
        public InterviewWork InterviewWork { get; set; }
        public FieldShip FieldShip { get; set; }

        // Methods

        // RVA: 0x173A050 Offset: 0x173A151 VA: 0x173A050
        public static EvDataManager get_Instanse()
        {
            //Stub
            return new EvDataManager();
        }

        // RVA: 0x173B830 Offset: 0x173B931 VA: 0x173B830
        public void add_OnTalkStartCallBack(Action<EvDataManager.EntityParam> value) { }

        // RVA: 0x173B8E0 Offset: 0x173B9E1 VA: 0x173B8E0
        public void remove_OnTalkStartCallBack(Action<EvDataManager.EntityParam> value) { }

        // RVA: 0x173B990 Offset: 0x173BA91 VA: 0x173B990
        public bool get_IsPosEventReserved()
        {
            //Stub
            return true;
        }

        // RVA: 0x173B9C0 Offset: 0x173BAC1 VA: 0x173B9C0
        public FieldObjectEntity get__dummyPlayer()
        {
            //Stub
            return null;
        }

        // RVA: 0x173B9D0 Offset: 0x173BAD1 VA: 0x173B9D0
        private void set__dummyPlayer(FieldObjectEntity value) { }

        // RVA: 0x173B9E0 Offset: 0x173BAE1 VA: 0x173B9E0
        public bool IsContactDoor()
        {
            //Stub
            return true;
        }

        // RVA: 0x173BAA0 Offset: 0x173BBA1 VA: 0x173BAA0
        public FieldPokemonCenter get_PokemonCenter()
        {
            //Stub
            return null;
        }

        // RVA: 0x173BAB0 Offset: 0x173BBB1 VA: 0x173BAB0
        private void set_PokemonCenter(FieldPokemonCenter value) { }

        // RVA: 0x173BAC0 Offset: 0x173BBC1 VA: 0x173BAC0
        public Telescope get_Telescope()
        {
            //Stub
            return null;
        }

        // RVA: 0x173BAD0 Offset: 0x173BBD1 VA: 0x173BAD0
        private void set_Telescope(Telescope value) { }

        // RVA: 0x173BAE0 Offset: 0x173BBE1 VA: 0x173BAE0
        public TelescopeNagisa get_TelescopeNagisa()
        {
            //Stub
            return null;
        }

        // RVA: 0x173BAF0 Offset: 0x173BBF1 VA: 0x173BAF0
        private void set_TelescopeNagisa(TelescopeNagisa value) { }

        // RVA: 0x173BB00 Offset: 0x173BC01 VA: 0x173BB00
        public FieldWazaCutIn get_FieldWazaCutIn()
        {
            //Stub
            return null;
        }

        // RVA: 0x173BB10 Offset: 0x173BC11 VA: 0x173BB10
        private void set_FieldWazaCutIn(FieldWazaCutIn value) { }

        // RVA: 0x173BB20 Offset: 0x173BC21 VA: 0x173BB20
        public InterviewWork get_InterviewWork()
        {
            //Stub
            return null;
        }

        // RVA: 0x173BB30 Offset: 0x173BC31 VA: 0x173BB30
        private void set_InterviewWork(InterviewWork value) { }

        // RVA: 0x173BB40 Offset: 0x173BC41 VA: 0x173BB40
        public FieldShip get_FieldShip()
        {
            //Stub
            return null;
        }

        // RVA: 0x173BB50 Offset: 0x173BC51 VA: 0x173BB50
        private void set_FieldShip(FieldShip value) { }

        // RVA: 0x173BBD0 Offset: 0x173BCD1 VA: 0x173BBD0
        public void Destroy() { }

        // RVA: 0x173BC40 Offset: 0x173BD41 VA: 0x173BC40
        public void SceneChangeRelease() { }

        // RVA: 0x173BDD0 Offset: 0x173BED1 VA: 0x173BDD0
        public void CacheSceneChangeRelease() { }

        // RVA: 0x173BEC0 Offset: 0x173BFC1 VA: 0x173BEC0
        public bool UpdateStart()
        {
            //Stub
            return true;
        }

        // RVA: 0x173E8B0 Offset: 0x173E9B1 VA: 0x173E8B0
        public void CallFieldWarpExitLabel() { }

        // RVA: 0x173D380 Offset: 0x173D481 VA: 0x173D380
        public void FieldZoneChange(bool walk = true) { }

        // RVA: 0x173FDB0 Offset: 0x173FEB1 VA: 0x173FDB0
        public void ResetVanishFlagObject() { }

        // RVA: 0x1740000 Offset: 0x1740101 VA: 0x1740000
        private void PendingInitScripts() { }

        // RVA: 0x173EFE0 Offset: 0x173F0E1 VA: 0x173EFE0
        private void WalkInit() { }

        // RVA: 0x173F080 Offset: 0x173F181 VA: 0x173F080
        private void MapJumpInit() { }

        // RVA: 0x17404F0 Offset: 0x17405F1 VA: 0x17404F0
        public bool m_Update(float time)
        {
            //Stub
            return true;
        }

        // RVA: 0x1742040 Offset: 0x1742141 VA: 0x1742040
        public bool m_LateUpdate(float time)
        {
            //Stub
            return true;
        }

        // RVA: 0x17423F0 Offset: 0x17424F1 VA: 0x17423F0
        private bool FindLabel(string label)
        {
            //Stub
            return true;
        }

        // RVA: 0x1741050 Offset: 0x1741151 VA: 0x1741050
        private bool CheckSceneChangeLabel()
        {
            //Stub
            return true;
        }

        // RVA: 0x1742450 Offset: 0x1742551 VA: 0x1742450
        private void SetBattleReturn() { }

        // RVA: 0x17410D0 Offset: 0x17411D1 VA: 0x17410D0
        private bool CheckBattleReturnLabel()
        {
            //Stub
            return true;
        }

        // RVA: 0x17415A0 Offset: 0x17416A1 VA: 0x17415A0
        private bool CheckUpdateSPLabel()
        {
            //Stub
            return true;
        }

        // RVA: 0x17428D0 Offset: 0x17429D1 VA: 0x17428D0
        private bool CheckSafariEvent()
        {
            //Stub
            return true;
        }

        // RVA: 0x173A130 Offset: 0x173A231 VA: 0x173A130
        public void SetSafariEndEventFromBattle(BtlResult btlResult) { }

        // RVA: 0x1742B50 Offset: 0x1742C51 VA: 0x1742B50
        public void RetireSafari() { }

        // RVA: 0x1742BB0 Offset: 0x1742CB1 VA: 0x1742BB0
        public void SetSafariScopeEvent() { }

        // RVA: 0x1742C10 Offset: 0x1742D11 VA: 0x1742C10
        public void SetSafariScopeEndEvent() { }

        // RVA: 0x1742C70 Offset: 0x1742D71 VA: 0x1742C70
        public void SetNagisaScopeEvent() { }

        // RVA: 0x1742CD0 Offset: 0x1742DD1 VA: 0x1742CD0
        public void SetNagisaScopeEndEvent() { }

        // RVA: 0x1742D30 Offset: 0x1742E31 VA: 0x1742D30
        public void UpdatePartyEggHatchingCount(int step) { }

        // RVA: 0x1742EC0 Offset: 0x1742FC1 VA: 0x1742EC0
        private int GetPartyEggHatchingValue(int step)
        {
            //Stub
            return 0;
        }

        // RVA: 0x1741620 Offset: 0x1741721 VA: 0x1741620
        private bool CheckPartyEggHatching()
        {
            //Stub
            return true;
        }

        // RVA: 0x1741700 Offset: 0x1741801 VA: 0x1741700
        private void EggHatchingEvent() { }

        // RVA: 0x1742FB0 Offset: 0x17430B1 VA: 0x1742FB0
        private void UpdateWait(float time) { }

        // RVA: 0x1742FC0 Offset: 0x17430C1 VA: 0x1742FC0
        public void OnOpenMenu() { }

        // RVA: 0x1743910 Offset: 0x1743A11 VA: 0x1743910
        public void OnCloseMenu() { }

        // RVA: 0x173EE20 Offset: 0x173EF21 VA: 0x173EE20
        public bool IsRunningEvent()
        {
            //Stub
            return true;
        }

        // RVA: 0x1743AF0 Offset: 0x1743BF1 VA: 0x1743AF0
        public bool CheckPosEvent(out Vector3 outWorldPos, FieldPlayerEntity player)
        {
            //Stub
            return true;
        }

        // RVA: 0x17441A0 Offset: 0x17442A1 VA: 0x17441A0
        public EvDataManager.EntityParam GetPosEventFromGrid(Vector2Int gridPos)
        {
            //Stub
            return null;
        }

        // RVA: 0x1744390 Offset: 0x1744491 VA: 0x1744390
        private bool IsPosEventOverWarp(ref Vector3 pos)
        {
            //Stub
            return true;
        }

        // RVA: 0x17425D0 Offset: 0x17426D1 VA: 0x17425D0
        private void PlayerInputActive(bool active, bool animation = True) { }

        // RVA: 0x173BB60 Offset: 0x173BC61 VA: 0x173BB60
        private void SetEventListIndex(int idx) { }

        // RVA: 0x173ECD0 Offset: 0x173EDD1 VA: 0x173ECD0
        private void CloudScaleReset() { }

        // RVA: 0x1744830 Offset: 0x1744931 VA: 0x1744830
        private void SetCloudScaleStart() { }

        // RVA: 0x1744560 Offset: 0x1744661 VA: 0x1744560
        private void SetCloudScaleEnd() { }

        // RVA: 0x1744B00 Offset: 0x1744C01 VA: 0x1744B00
        private void EnvironmentControllerCallBack(EnvironmentController controller, float deltaTime) { }

        // RVA: 0x173EE40 Offset: 0x173EF41 VA: 0x173EE40
        public bool JumpLabel(string label, EventEndDelegate callback)
        {
            // TODO: Is this just allocating memory for something?
            if ((DAT_7104c73abf & 1) == 0)
            {
                thunk_FUN_710026bc70(0x4580);
                DAT_7104c73abf = 1;
            }

            if (!string.IsNullOrEmpty(label) && _findAllLabel.ContainsKey(label))
            {
                int[] foundLabel = _findAllLabel[label]; //Probably some struct
                if (foundLabel[6] != 0)
                {
                    int uVar1 = foundLabel[8];
                    if ((uint)uVar1 == 0xffffffff)
                    {
                        SetCloudScaleEnd();
                    }
                    else
                    {
                        if (_eventListIndex == -1)
                        {
                            SetCloudScaleStart();
                        }
                    }

                    _eventListIndex = uVar1;
                    if (_eventListIndex < _eventList.Length)
                    {
                        if ((uint)foundLabel[6] > 1)
                        {
                            _eventList[_eventListIndex].LabelIndex = foundLabel[9];
                            if (_eventListIndex < _eventList.Length)
                            {
                                _eventList[_eventListIndex].CommandIndex = 0;
                                if (callback != null)
                                {
                                    Delegate combinedDelegate = Delegate.Combine(_eventEndDelegate, callback);
                                    if (combinedDelegate != null && !(combinedDelegate is EventEndDelegate))
                                    {
                                        FUNC_ThrowInvalidCast(combinedDelegate);
                                        return true;
                                    }
                                    _eventEndDelegate = (EventEndDelegate)combinedDelegate;

                                    // TODO: What is this?
                                    thunk_FUN_710029a080(_eventEndDelegate, combinedDelegate);
                                }
                                return true;
                            }
                        }
                    }
                }

                FUNC_ThrowIndexOutOfRange();
                return true;
            }
            return false;
        }

        // RVA: 0x1744CA0 Offset: 0x1744DA1 VA: 0x1744CA0
        public bool CallLabel(string label)
        {
            // TODO: Is this just allocating memory for something?
            if ((DAT_7104c73ac0 & 1) == 0)
            {
                thunk_FUN_710026bc70(0x430a);
                DAT_7104c73ac0 = 1;
            }

            if (!string.IsNullOrEmpty(label) && _findAllLabel.ContainsKey(label))
            {
                if (_eventListIndex < _eventList.Length)
                {
                    //A lot of this is presumed, the ghidra decomp is hard to understand here
                    EvCallData call;
                    call.EventListIndex = _eventListIndex;
                    call.LabelIndex = _eventList[_eventListIndex].LabelIndex;
                    call.CommandIndex = 0; //Required for defining struct, undefined normally (likely 0)
                    _callQueue.Push(call);

                    int[] foundLabel = _findAllLabel[label]; //Probably some struct
                    if (foundLabel[6] != 0)
                    {
                        int uVar1 = foundLabel[8];
                        if ((uint)uVar1 == 0xffffffff)
                        {
                            SetCloudScaleEnd();
                        }
                        else
                        {
                            if (_eventListIndex == -1)
                            {
                                SetCloudScaleStart();
                            }
                        }

                        _eventListIndex = uVar1;
                        if (_eventListIndex < _eventList.Length)
                        {
                            EvScriptData script = _eventList[_eventListIndex];
                            foundLabel = _findAllLabel[label];

                            if ((uint)foundLabel[6] > 1)
                            {
                                script.LabelIndex = foundLabel[9];
                                if (_eventListIndex < _eventList.Length)
                                {
                                    _eventList[_eventListIndex].CommandIndex = 0;
                                    return true;
                                }
                            }
                        }
                    }
                }

                FUNC_ThrowIndexOutOfRange();
                return true;
            }

            return false;
        }

        // RVA: 0x1744E30 Offset: 0x1744F31 VA: 0x1744E30
        public bool ReturnEvData()
        {
            //Stub
            return true;
        }

        // RVA: 0x1744F40 Offset: 0x1745041 VA: 0x1744F40
        private FieldCharacterEntity GetFieldCharacterEntity(string id)
        {
            //Stub
            return null;
        }

        // RVA: 0x17452C0 Offset: 0x17453C1 VA: 0x17452C0
        private FieldObjectEntity Find_fieldObjectEntity(string id)
        {
            //Stub
            return null;
        }

        // RVA: 0x1745500 Offset: 0x1745601 VA: 0x1745500
        public FieldObjectEntity GetFieldObject(string id)
        {
            //Stub
            return null;
        }

        // RVA: 0x1745880 Offset: 0x1745981 VA: 0x1745880
        private FieldObjectEntity GetFieldObject(int id)
        {
            //Stub
            return null;
        }

        // RVA: 0x1745910 Offset: 0x1745A11 VA: 0x1745910
        public FieldEventEntity GetFieldEventEntity(string id)
        {
            //Stub
            return null;
        }

        // RVA: 0x1745BF0 Offset: 0x1745CF1 VA: 0x1745BF0
        private bool IsMoveEnd(string id = "")
        {
            //Stub
            return true;
        }

        // RVA: 0x1741760 Offset: 0x1741861 VA: 0x1741760
        private bool ScriptStartCheck(float time)
        {
            //Stub
            return true;
        }

        // RVA: 0x1747C10 Offset: 0x1747D11 VA: 0x1747C10
        public Vector3 CalcContactCheckPos()
        {
            //Stub
            return null;
        }

        // RVA: 0x1747DB0 Offset: 0x1747EB1 VA: 0x1747DB0
        public bool CanContact(FieldObjectEntity obj, Vector3 playerpos)
        {
            //Stub
            return true;
        }

        // RVA: 0x1746320 Offset: 0x1746421 VA: 0x1746320
        public bool CanContact2(FieldObjectEntity obj, Vector3 playerpos)
        {
            //Stub
            return true;
        }

        // RVA: 0x17486D0 Offset: 0x17487D1 VA: 0x17486D0
        public void ClearPlayerMoveVector() { }

        // RVA: 0x1746AF0 Offset: 0x1746BF1 VA: 0x1746AF0
        public bool RunObjectEvent(int idx, FieldObjectEntity obj, string label)
        {
            //Stub
            return true;
        }

        // RVA: 0x1748230 Offset: 0x1748331 VA: 0x1748230
        private bool IsTalkBitMask(ref Vector2 target, ref Vector2 talkpont, byte mask)
        {
            //Stub
            return true;
        }

        // RVA: 0x1747DC0 Offset: 0x1747EC1 VA: 0x1747DC0
        private bool IsHit(Vector3 traA, Vector3 traB, Vector2 rangB, bool center)
        {
            //Stub
            return true;
        }

        // RVA: 0x1748520 Offset: 0x1748621 VA: 0x1748520
        private float PlayerDiffAngle(ref Vector2 diff)
        {
            //Stub
            return 0;
        }

        // RVA: 0x17487E0 Offset: 0x17488E1 VA: 0x17487E0
        private bool IsCircleHit(ref Vector2 v1, ref Vector2 v2, float range, out float outAngle)
        {
            //Stub
            return true;
        }

        // RVA: 0x1747F30 Offset: 0x1748031 VA: 0x1747F30
        private bool IsCircleHit(ref Vector2 v1, ref Vector2 v2, float range)
        {
            //Stub
            return true;
        }

        // RVA: 0x1746C40 Offset: 0x1746D41 VA: 0x1746C40
        private bool WarpListCheck()
        {
            //Stub
            return true;
        }

        // RVA: 0x17491F0 Offset: 0x17492F1 VA: 0x17491F0
        private void EvCmdCmpMain(EvWork.WORK_INDEX r1, EvWork.WORK_INDEX r2) { }

        // RVA: 0x1749260 Offset: 0x1749361 VA: 0x1749260
        public void OnEventEnter(float deltaTime, FieldEventEntity eventEntity) { }

        // RVA: 0x1749590 Offset: 0x1749691 VA: 0x1749590
        public void OnEventStay(float deltaTime, FieldEventEntity eventEntity) { }

        // RVA: 0x17498C0 Offset: 0x17499C1 VA: 0x17498C0
        public void OnEventLeave(float deltaTime, FieldEventEntity eventEntity) { }

        // RVA: 0x173FF50 Offset: 0x1740051 VA: 0x173FF50
        public void ResetGimmickEntityRef() { }

        // RVA: 0x1749940 Offset: 0x1749A41 VA: 0x1749940
        public bool IsDowsingEnable(FieldObjectEntity entity)
        {
            //Stub
            return true;
        }

        // RVA: 0x1747460 Offset: 0x1747561 VA: 0x1747460
        private bool WarpHit(FieldEventDoorEntity eventEntity)
        {
            //Stub
            return true;
        }

        // RVA: 0x1749AD0 Offset: 0x1749BD1 VA: 0x1749AD0
        private void CorrectionEventEntityWait(float deltatime) { }

        // RVA: 0x1749D10 Offset: 0x1749E11 VA: 0x1749D10
        private bool CorrectionDirCheck(FieldEventEntity eventEntity)
        {
            //Stub
            return true;
        }

        // RVA: 0x1749D20 Offset: 0x1749E21 VA: 0x1749D20
        private void CorrectionDirSegment(FieldEventEntity eventEntity, out Vector2 segStart, out Vector2 segEnd) { }

        // RVA: 0x1748F90 Offset: 0x1749091 VA: 0x1748F90
        private float CorrectionDirAngle(FieldEventEntity eventEntity)
        {
            //Stub
            return 0;
        }

        // RVA: 0x1747720 Offset: 0x1747821 VA: 0x1747720
        private bool IsLiftHit(FieldEventLiftEntity liftEntity)
        {
            //Stub
            return true;
        }

        // RVA: 0x17478A0 Offset: 0x17479A1 VA: 0x17478A0
        private bool IsNagisaGymGearHit(FieldNagisaGymGearEntity gymGearEntity)
        {
            //Stub
            return true;
        }

        // RVA: 0x1747A00 Offset: 0x1747B01 VA: 0x1747A00
        private bool IsNomoseGymSwitchHit(FieldNomoseGymSwitchEntity gymSwitchEntity)
        {
            //Stub
            return true;
        }

        // RVA: 0x1747B70 Offset: 0x1747C71 VA: 0x1747B70
        private bool IsEyePaintingHit(FieldEyePaintingEntity eyePaintingEntity)
        {
            //Stub
            return true;
        }

        // RVA: 0x1747BC0 Offset: 0x1747CC1 VA: 0x1747BC0
        private bool IsEmbankmentHit(FieldEmbankmentEntity embankmentEntity)
        {
            //Stub
            return true;
        }

        // RVA: 0x1749D90 Offset: 0x1749E91 VA: 0x1749D90
        private bool IsEventHit(FieldEventEntity eventEntity)
        {
            //Stub
            return true;
        }

        // RVA: 0x17499E0 Offset: 0x1749AE1 VA: 0x17499E0
        private bool IsWorpHit(FieldEventEntity eventEntity)
        {
            //Stub
            return true;
        }

        // RVA: 0x17490B0 Offset: 0x17491B1 VA: 0x17490B0
        private void WarpUpdate(float time) { }

        // RVA: 0x1749F80 Offset: 0x174A081 VA: 0x1749F80
        private void WarpUpdateEnd() { }

        // RVA: 0x174ACE0 Offset: 0x174ADE1 VA: 0x174ACE0
        private void EqualZoneWarp(float time) { }

        // RVA: 0x173F290 Offset: 0x173F391 VA: 0x173F290
        public void SetWork(int index, int val) { }

        // RVA: 0x17487D0 Offset: 0x17488D1 VA: 0x17487D0
        public void SetWork(EvWork.WORK_INDEX index, int val) { }

        // RVA: 0x174AE30 Offset: 0x174AF31 VA: 0x174AE30
        public int GetWork(int index)
        {
            //Stub
            return 0;
        }

        // RVA: 0x1744380 Offset: 0x1744481 VA: 0x1744380
        public int GetWork(EvWork.WORK_INDEX index)
        {
            //Stub
            return 0;
        }

        // RVA: 0x173F2A0 Offset: 0x173F3A1 VA: 0x173F2A0
        public EvWork.FLAG_INDEX SetFlag(int index, bool val)
        {
            //Stub
            return 0;
        }

        // RVA: 0x174AE40 Offset: 0x174AF41 VA: 0x174AE40
        public void SetFlag(EvWork.FLAG_INDEX index, bool val) { }

        // RVA: 0x1748900 Offset: 0x1748A01 VA: 0x1748900
        public int GetFlag(EvWork.FLAG_INDEX index)
        {
            //Stub
            return 0;
        }

        // RVA: 0x173FFD0 Offset: 0x17400D1 VA: 0x173FFD0
        public int GetFlag(int index)
        {
            //Stub
            return 0;
        }

        // RVA: 0x1740110 Offset: 0x1740211 VA: 0x1740110
        public void SetSysFlag(EvWork.SYSFLAG_INDEX index, bool val) { }

        // RVA: 0x174AE50 Offset: 0x174AF51 VA: 0x174AE50
        public void SetSysFlag(int index, bool val) { }

        // RVA: 0x174B050 Offset: 0x174B151 VA: 0x174B050
        public int GetSysFlag(EvWork.SYSFLAG_INDEX index)
        {
            //Stub
            return 0;
        }

        // RVA: 0x174B070 Offset: 0x174B171 VA: 0x174B070
        public int GetSysFlag(int index)
        {
            //Stub
            return 0;
        }

        // RVA: 0x174B090 Offset: 0x174B191 VA: 0x174B090
        public int GetArgInt(EvData.Aregment arg)
        {
            //Stub
            return 0;
        }

        // RVA: 0x174B0D0 Offset: 0x174B1D1 VA: 0x174B0D0
        public float GetArgFloat(EvData.Aregment arg)
        {
            //Stub
            return 0;
        }

        // RVA: 0x174B110 Offset: 0x174B211 VA: 0x174B110
        public string GetArgString(EvScriptData ev, EvData.Aregment arg)
        {
            //Stub
            return "";
        }

        // RVA: 0x174AF80 Offset: 0x174B081 VA: 0x174AF80
        public int GetBadgeCount()
        {
            //Stub
            return 0;
        }

        // RVA: 0x174B190 Offset: 0x174B291 VA: 0x174B190
        private string GetTrainerMsg(int tr_id, int kind)
        {
            //Stub
            return "";
        }

        // RVA: 0x174B340 Offset: 0x174B441 VA: 0x174B340
        private string GetTrainerRevengeMsg(int tr_id, int kind)
        {
            //Stub
            return "";
        }

        // RVA: 0x174B460 Offset: 0x174B561 VA: 0x174B460
        private bool PlaySe(string name)
        {
            //Stub
            return true;
        }

        // RVA: 0x174B730 Offset: 0x174B831 VA: 0x174B730
        private bool PlayVoice(string name)
        {
            //Stub
            return true;
        }

        // RVA: 0x174BB50 Offset: 0x174BC51 VA: 0x174BB50
        private bool StopSe(string name)
        {
            //Stub
            return true;
        }

        // RVA: 0x174BC80 Offset: 0x174BD81 VA: 0x174BC80
        private bool StopVoice(string name)
        {
            //Stub
            return true;
        }

        // RVA: 0x174BDB0 Offset: 0x174BEB1 VA: 0x174BDB0
        private bool IsPlayingSe(string name = "")
        {
            //Stub
            return true;
        }

        // RVA: 0x174BE90 Offset: 0x174BF91 VA: 0x174BE90
        private bool IsPlayingVoice(string name = "")
        {
            //Stub
            return true;
        }

        // RVA: 0x174BF70 Offset: 0x174C071 VA: 0x174BF70
        public void PlayVoice(int monsNo, int formNo, int voiceType) { }

        // RVA: 0x174C040 Offset: 0x174C141 VA: 0x174C040
        public void PlayVoiceUI(int monsNo, int formNo, int voiceType) { }

        // RVA: 0x173F5B0 Offset: 0x173F6B1 VA: 0x173F5B0
        private void SpLabel_Init(ZoneID id) { }

        // RVA: 0x173F680 Offset: 0x173F781 VA: 0x173F680
        private void SpLabel_Obj(ZoneID id) { }

        // RVA: 0x173F820 Offset: 0x173F921 VA: 0x173F820
        public void SpLabel_Scene(ZoneID id) { }

        // RVA: 0x173F750 Offset: 0x173F851 VA: 0x173F750
        private void SpLabel_Flag(ZoneID id) { }

        // RVA: 0x173CA00 Offset: 0x173CB01 VA: 0x173CA00
        public void Jump_InitScr() { }

        // RVA: 0x1746A90 Offset: 0x1746B91 VA: 0x1746A90
        private void FindTrainerIndex(int index, TrainerID id) { }

        // RVA: 0x174B2B0 Offset: 0x174B3B1 VA: 0x174B2B0
        private TrainerTable.SheetTrainerData GetTrainer(int index)
        {
            //Stub
            return null;
        }

        // RVA: 0x174C110 Offset: 0x174C211 VA: 0x174C110
        private TrainerTable.SheetTrainerType GetTrainerType(TrainerType id)
        {
            //Stub
            return null;
        }

        // RVA: 0x174C180 Offset: 0x174C281 VA: 0x174C180
        private void BattleTrainer(TrainerID enemy1, TrainerID enemy2 = 0, TrainerID partner = 0) { }

        // RVA: 0x174C7E0 Offset: 0x174C8E1 VA: 0x174C7E0
        public void ForceEyeEncount(TrainerID trainerID) { }

        // RVA: 0x174C8E0 Offset: 0x174C9E1 VA: 0x174C8E0
        public bool TrainerEyeCheck(ref Vector3 moveVector, ref Vector2 hitpos)
        {
            //Stub
            return true;
        }

        // RVA: 0x174D2C0 Offset: 0x174D3C1 VA: 0x174D2C0
        private void OnEyeCallBack(FieldObjectMoveCode mvobj) { }

        // RVA: 0x174CEB0 Offset: 0x174CFB1 VA: 0x174CEB0
        private void EyeTrainerSetUp(float time) { }

        // RVA: 0x174D480 Offset: 0x174D581 VA: 0x174D480
        private bool EyeEncount(FieldObjectMoveCode mvobj, float time)
        {
            //Stub
            return true;
        }

        // RVA: 0x174D6A0 Offset: 0x174D7A1 VA: 0x174D6A0
        private bool EyeEncountTagTrainer(FieldObjectMoveCode mvobj1, FieldObjectMoveCode mvobj2, float time)
        {
            //Stub
            return true;
        }

        // RVA: 0x174D970 Offset: 0x174DA71 VA: 0x174D970
        private void UG_GuruGuruHole(float time) { }

        // RVA: 0x174DF70 Offset: 0x174E071 VA: 0x174DF70
        public bool isUpdateDelegate()
        {
            //Stub
            return true;
        }

        // RVA: 0x17400E0 Offset: 0x17401E1 VA: 0x17400E0
        private void ARRIVEDATA_SetArriveFlag(ZoneID id) { }

        // RVA: 0x1743D60 Offset: 0x1743E61 VA: 0x1743D60
        private bool IsPlayingUgEnterOrExit()
        {
            //Stub
            return true;
        }

        // RVA: 0x174DF80 Offset: 0x174E081 VA: 0x174DF80
        public void UG_EnterOrExit() { }

        // RVA: 0x174EFD0 Offset: 0x174F0D1 VA: 0x174EFD0
        public bool IsCanGotoUG() { }

        // RVA: 0x174F270 Offset: 0x174F371 VA: 0x174F270
        public bool CheckPlaceData()
        {
            //Stub
            return true;
        }

        // RVA: 0x174E650 Offset: 0x174E751 VA: 0x174E650
        private UgJumpPos.SheetData GetUgJumpPosData(int MatrixID)
        {
            //Stub
            return null;
        }

        // RVA: 0x174ECE0 Offset: 0x174EDE1 VA: 0x174ECE0
        private void GotoOnTheGround() { }

        // RVA: 0x174F510 Offset: 0x174F611 VA: 0x174F510
        private void SetupUgHolePosRot(GameObject ugObject) { }

        // RVA: 0x174E710 Offset: 0x174E811 VA: 0x174E710
        private void GotoUnderGround() { }

        // RVA: 0x173E6B0 Offset: 0x173E7B1 VA: 0x173E6B0
        private void FromUnderGround() { }

        // RVA: 0x174F640 Offset: 0x174F741 VA: 0x174F640
        public void PlayerRising(float deltaTime) { }

        // RVA: 0x174F870 Offset: 0x174F971 VA: 0x174F870
        public void PlayerFall(float deltaTime) { }

        // RVA: 0x174FAA0 Offset: 0x174FBA1 VA: 0x174FAA0
        private void UG_HoleDive(float time) { }

        // RVA: 0x17503F0 Offset: 0x17504F1 VA: 0x17503F0
        private void UG_From(float time) { }

        // RVA: 0x1746250 Offset: 0x1746351 VA: 0x1746250
        private void StartAdjustHeroPos(float deltaTime, string label) { }

        // RVA: 0x1750B60 Offset: 0x1750C61 VA: 0x1750B60
        private bool CheckUpdateAdjustHeroPos(float deltaTime)
        {
            //Stub
            return true;
        }

        // RVA: 0x1751020 Offset: 0x1751121 VA: 0x1751020
        private void UpdateAdjustHeroPos(float deltaTime) { }

        // RVA: 0x1751060 Offset: 0x1751161 VA: 0x1751060
        public bool CheckEventObjectGrid(int x, int y, float height)
        {
            //Stub
            return true;
        }

        // RVA: 0x17512C0 Offset: 0x17513C1 VA: 0x17512C0
        private static bool CheckEventObjectGridCore(FieldObjectEntity entity, int x, int y, float height)
        {
            //Stub
            return true;
        }

        // RVA: 0x1740A30 Offset: 0x1740B31 VA: 0x1740A30
        private void EntityMoveCodeCheck() { }

        // RVA: 0x1751490 Offset: 0x1751591 VA: 0x1751490
        private bool SetNearIndex(ref EvDataManager.EntityParam param, int index)
        {
            //Stub
            return true;
        }

        // RVA: 0x1751500 Offset: 0x1751601 VA: 0x1751500
        public void SetBtlSearchEndEvent(EvDataManager.UpdateDelegate degate) { }

        // RVA: 0x1751510 Offset: 0x1751611 VA: 0x1751510
        public void EndSpray() { }

        // RVA: 0x1740FF0 Offset: 0x17410F1 VA: 0x1740FF0
        private void ChkFadeInput() { }

        // RVA: 0x1740240 Offset: 0x1740341 VA: 0x1740240
        private void SetCommandUseTime() { }

        // RVA: 0x17515E0 Offset: 0x17516E1 VA: 0x17515E0
        private int GetCommandUseTime(EvDataManager.COMMAND_USE_TIME use)
        {
            //Stub
            return 0;
        }

        // RVA: 0x1751760 Offset: 0x1751861 VA: 0x1751760
        private void VariableReset() { }

        // RVA: 0x17518E0 Offset: 0x17519E1 VA: 0x17518E0
        private void EventEnd() { }

        // RVA: 0x1751F50 Offset: 0x1752051 VA: 0x1751F50
        private bool OpenTalk(EvDataManager.MsgOpenParam msgparam)
        {
            //Stub
            return true;
        }

        // RVA: 0x1752150 Offset: 0x1752251 VA: 0x1752150
        private MessageMsgFile GetMSBTFile(string msbtfilename)
        {
            //Stub
            return null;
        }

        // RVA: 0x17520B0 Offset: 0x17521B1 VA: 0x17520B0
        private IEnumerator<int> OpenMsgFile(EvDataManager.MsgOpenParam msgparam)
        {
            //Stub
            return null;
        }

        // RVA: 0x1752250 Offset: 0x1752351 VA: 0x1752250
        private void CloseMsg() { }

        // RVA: 0x17522E0 Offset: 0x17523E1 VA: 0x17522E0
        private bool CommandEquals(string eq, int val1, int val2)
        {
            //Stub
            return true;
        }

        // RVA: 0x17525E0 Offset: 0x17526E1 VA: 0x17525E0
        private bool IfJump_Call(bool jump, string eq, string label)
        {
            // TODO: Is this just allocating memory for something?
            if ((DAT_7104c73b03 & 1) == 0)
            {
                thunk_FUN_710026bc70(0x456d);
                DAT_7104c73b03 = 1;
            }

            string comparison = ReEQType(eq);
            switch (comparison)
            {
                case "EQ":
                    //Exclude Less and Greater
                    if (_cmp_flag != CmpResult.EQUAL)
                    {
                        return false;
                    }
                    break;
                case "NE":
                    //Exclude Equal
                    if (_cmp_flag == CmpResult.EQUAL)
                    {
                        return false;
                    }
                    break;
                case "GT":
                    //Exclude Less and Equal
                    if (_cmp_flag != CmpResult.PLUS)
                    {
                        return false;
                    }
                    break;
                case "GE":
                    //Exclude Less
                    if (_cmp_flag == CmpResult.MINUS)
                    {
                        return false;
                    }
                    break;
                case "LT":
                    //Exclude Greater and Equal
                    if (_cmp_flag != CmpResult.MINUS)
                    {
                        return false;
                    }
                    break;
                case "LE":
                    //Exclude Greater
                    if (_cmp_flag == CmpResult.PLUS)
                    {
                        return false;
                    }
                    break;
                default:
                    return false;
            }

            if (jump)
            {
                return JumpLabel(label, null);
            }
            return CallLabel(label);
        }

        // RVA: 0x1752460 Offset: 0x1752561 VA: 0x1752460
        private string ReEQType(string eq)
        {
            // TODO: Is this just allocating memory for something?
            if ((DAT_7104c73b04 & 1) == 0)
            {
                thunk_FUN_710026bc70(0x45a0);
                DAT_7104c73b04 = 1;
            }

            switch (eq)
            {
                case "EQUAL":
                    return "EQ";
                case "LITTLER":
                    return "LT";
                case "GREATER":
                    return "GT";
                case "LT_EQ":
                    return "LE";
                case "GT_EQ":
                    return "GE";
                case "FLGON":
                    return "EQ";
                case "FLGOFF":
                    return "LT";
                default:
                    return eq;
            }
        }

        // RVA: 0x1752780 Offset: 0x1752881 VA: 0x1752780
        private bool Cmd_TalkMsg(EvScriptData ev, bool index = False)
        {
            //Stub
            return true;
        }

        // RVA: 0x1752BA0 Offset: 0x1752CA1 VA: 0x1752BA0
        private bool Cmd_ExplanationMsg(string msgfile, string label)
        {
            //Stub
            return true;
        }

        // RVA: 0x1752CF0 Offset: 0x1752DF1 VA: 0x1752CF0
        private bool Cmd_TalkMsg(string msbt, string label)
        {
            //Stub
            return true;
        }

        // RVA: 0x1752DC0 Offset: 0x1752EC1 VA: 0x1752DC0
        private void Cmd_TalkWindOpen() { }

        // RVA: 0x1752E20 Offset: 0x1752F21 VA: 0x1752E20
        private void Cmd_TalkWindClose() { }

        // RVA: 0x1752F30 Offset: 0x1753031 VA: 0x1752F30
        private void Cmd_TrainerTalkTypeGet(int wk1, int wk2, int wk3) { }

        // RVA: 0x17530F0 Offset: 0x17531F1 VA: 0x17530F0
        private void Cmd_RevengeTrainerTalkTypeGet(int wk1, int wk2, int wk3) { }

        // RVA: 0x1753050 Offset: 0x1753151 VA: 0x1753050
        private bool CheckTrainer2vs2Type(int tr_id)
        {
            //Stub
            return true;
        }

        // RVA: 0x1753210 Offset: 0x1753311 VA: 0x1753210
        private bool EvCmdTrainerMessageSet(int wk1, int wk2)
        {
            //Stub
            return true;
        }

        // RVA: 0x1753350 Offset: 0x1753451 VA: 0x1753350
        private void EvCmdBoardMake(EvScriptData ev) { }

        // RVA: 0x17538A0 Offset: 0x17539A1 VA: 0x17538A0
        private bool EvCmdBoardReqDpr(EvScriptData ev)
        {
            //Stub
            return true;
        }

        // RVA: 0x1753B70 Offset: 0x1753C71 VA: 0x1753B70
        private bool EvCmdBoardReqDpr()
        {
            //Stub
            return true;
        }

        // RVA: 0x1753D40 Offset: 0x1753E41 VA: 0x1753D40
        private bool EvCmdBoardReqWait()
        {
            //Stub
            return true;
        }

        // RVA: 0x1753DE0 Offset: 0x1753EE1 VA: 0x1753DE0
        private bool EvCmdBoardEndWait(EvWork.WORK_INDEX work)
        {
            //Stub
            return true;
        }

        // RVA: 0x1753F00 Offset: 0x1754001 VA: 0x1753F00
        private void EvCmdInfoBoardMake(EvScriptData ev) { }

        // RVA: 0x1754450 Offset: 0x1754551 VA: 0x1754450
        private void Cmd_If_Jump(string type, string label) { }

        // RVA: 0x1754460 Offset: 0x1754561 VA: 0x1754460
        private bool Cmd_TalkObjStart()
        {
            //Stub
            return true;
        }

        // RVA: 0x1754950 Offset: 0x1754A51 VA: 0x1754950
        private bool Cmd_TalkObjStartTurnNot()
        {
            //Stub
            return true;
        }

        // RVA: 0x1754A10 Offset: 0x1754B11 VA: 0x1754A10
        private bool Cmd_LastKeyWait()
        {
            //Stub
            return true;
        }

        // RVA: 0x1754A20 Offset: 0x1754B21 VA: 0x1754A20
        private bool Cmd_TalkStart()
        {
            //Stub
            return true;
        }

        // RVA: 0x1743090 Offset: 0x1743191 VA: 0x1743090
        public bool Cmd_ObjPauseAll()
        {
            //Stub
            return true;
        }

        // RVA: 0x17439F0 Offset: 0x1743AF1 VA: 0x17439F0
        public bool Cmd_ObjPauseClearAll()
        {
            //Stub
            return true;
        }

        // RVA: 0x1754AD0 Offset: 0x1754BD1 VA: 0x1754AD0
        private IEnumerator<int> TurnEnumerator(int index)
        {
            //Stub
            return null;
        }

        // RVA: 0x1754B60 Offset: 0x1754C61 VA: 0x1754B60
        private bool Turn_HitObjectToHero()
        {
            //Stub
            return true;
        }

        // RVA: 0x1754C30 Offset: 0x1754D31 VA: 0x1754C30
        private bool Turn_HeroToHitObject()
        {
            //Stub
            return true;
        }

        // RVA: 0x1754D00 Offset: 0x1754E01 VA: 0x1754D00
        private bool ObjectTurn(float time, float endtime, ref Vector3 target, FieldObjectEntity myEntity, int index)
        {
            //Stub
            return true;
        }

        // RVA: 0x1752B20 Offset: 0x1752C21 VA: 0x1752B20
        private string[] GetMsbtFileLabel(string cmdarg)
        {
            //Stub
            return null;
        }

        // RVA: 0x17553C0 Offset: 0x17554C1 VA: 0x17553C0
        private bool CmdMapChange(EvScriptData ev)
        {
            //Stub
            return true;
        }

        // RVA: 0x1755520 Offset: 0x1755621 VA: 0x1755520
        private bool CmdMapChangeNoneFade(EvScriptData ev)
        {
            //Stub
            return true;
        }

        // RVA: 0x1755540 Offset: 0x1755641 VA: 0x1755540
        private bool StackMapChange()
        {
            //Stub
            return true;
        }

        // RVA: 0x1755740 Offset: 0x1755841 VA: 0x1755740
        private bool YesNoWindow(EvScriptData ev)
        {
            //Stub
            return true;
        }

        // RVA: 0x17558F0 Offset: 0x17559F1 VA: 0x17558F0
        private bool CustumWindow(EvData.Command data, bool wordSet = false)
        {
            //Stub
            return true;
        }

        // RVA: 0x1755B10 Offset: 0x1755C11 VA: 0x1755B10
        private bool CmdPlayerMoveGridCenter(EvData.Command data)
        {
            //Stub
            return true;
        }

        // RVA: 0x17560C0 Offset: 0x17561C1 VA: 0x17560C0
        private bool CmdPokemonName(EvData.Command data)
        {
            //Stub
            return true;
        }

        // RVA: 0x17562C0 Offset: 0x17563C1 VA: 0x17562C0
        private bool CmdFirstPokemonName(EvData.Command data)
        {
            //Stub
            return true;
        }

        // RVA: 0x17563E0 Offset: 0x17564E1 VA: 0x17563E0
        private bool CmdRivalPokemonName(EvData.Command data)
        {
            //Stub
            return true;
        }

        // RVA: 0x1756500 Offset: 0x1756601 VA: 0x1756500
        private bool CmdSupportPokemonName(EvData.Command data)
        {
            //Stub
            return true;
        }

        // RVA: 0x1756200 Offset: 0x1756301 VA: 0x1756200
        private bool CmdPokemonNameIndex(int index, int pos)
        {
            //Stub
            return true;
        }

        // RVA: 0x1756620 Offset: 0x1756721 VA: 0x1756620
        private bool CmdPokemonNickNameIndex(int index, int pos)
        {
            //Stub
            return true;
        }

        // RVA: 0x17566E0 Offset: 0x17567E1 VA: 0x17566E0
        private bool CmdPokemonNickNameIndexBox(int index, int tray, int pos)
        {
            //Stub
            return true;
        }

        // RVA: 0x1756780 Offset: 0x1756881 VA: 0x1756780
        private bool CmdGetRelPosHero(EvScriptData ev)
        {
            //Stub
            return true;
        }

        // RVA: 0x1756B20 Offset: 0x1756C21 VA: 0x1756B20
        private bool CmdSxyExitPosChange(EvData.Command data)
        {
            //Stub
            return true;
        }

        // RVA: 0x1756E50 Offset: 0x1756F51 VA: 0x1756E50
        private TrainerID GetArgTrainerID(EvScriptData ev, EvData.Aregment arg)
        {
            //Stub
            return null;
        }

        // RVA: 0x1756F90 Offset: 0x1757091 VA: 0x1756F90
        private bool CmdTrainerBtlSet(EvScriptData ev)
        {
            //Stub
            return true;
        }

        // RVA: 0x1757090 Offset: 0x1757191 VA: 0x1757090
        private bool CmdTrainerBtlSetMulti(EvScriptData ev)
        {
            //Stub
            return true;
        }

        // RVA: 0x17571C0 Offset: 0x17572C1 VA: 0x17571C0
        private bool CmdTrainerBgmSet(EvData.Command data)
        {
            //Stub
            return true;
        }

        // RVA: 0x1757420 Offset: 0x1757521 VA: 0x1757420
        private bool CmdVisibleObjProp(EvScriptData ev, bool flag)
        {
            //Stub
            return true;
        }

        // RVA: 0x1757650 Offset: 0x1757751 VA: 0x1757650
        private bool CmdFirstPokeSelectProc(EvScriptData ev)
        {
            //Stub
            return true;
        }

        // RVA: 0x173F8E0 Offset: 0x173F9E1 VA: 0x173F8E0
        private bool UpdateEvdata(float time, bool sp_script = False)
        {
            //Stub
            return true;
        }

        // RVA: 0x175C4F0 Offset: 0x175C5F1 VA: 0x175C4F0
        private bool EvCmdNop()
        {
            //Stub
            return true;
        }

        // RVA: 0x175C520 Offset: 0x175C621 VA: 0x175C520
        private bool EvCmdDummy()
        {
            //Stub
            return true;
        }

        // RVA: 0x175C530 Offset: 0x175C631 VA: 0x175C530
        private bool EvCmdEnd()
        {
            //Stub
            return true;
        }

        // RVA: 0x175C560 Offset: 0x175C661 VA: 0x175C560
        private bool EvCmdTimeWait()
        {
            if (_evArg.Length > 1)
            {
                float frames;
                float workNo = _evArg[1].data;
                switch (_evArg[1].argType)
                {
                    case EvData.ArgType.Work:
                        frames = FlagWork.GetWork((int)workNo);
                        break;
                    case EvData.ArgType.Float:
                        frames = workNo;
                        break;
                    default:
                        frames = 0.0F;
                        break;
                }

                if (_evArg.Length > 2)
                {
                    if (frames * 0.03333334 < _timeWait)
                    {
                        FlagWork.SetWork(_evArg[2].data, 0);
                        return true;
                    }
                    FlagWork.SetWork(_evArg[2].data, 1);
                    _timeWait += _deltatime;
                    return false;
                }
            }

            FUNC_ThrowIndexOutOfRange();
            return true;
        }

        // RVA: 0x175C640 Offset: 0x175C741 VA: 0x175C640
        private bool EvCmdLoadRegValue()
        {
            //Stub
            return true;
        }

        // RVA: 0x175C650 Offset: 0x175C751 VA: 0x175C650
        private bool EvCmdLoadRegWData()
        {
            //Stub
            return true;
        }

        // RVA: 0x175C660 Offset: 0x175C761 VA: 0x175C660
        private bool EvCmdLoadRegAdrs()
        {
            //Stub
            return true;
        }

        // RVA: 0x175C670 Offset: 0x175C771 VA: 0x175C670
        private bool EvCmdLoadAdrsValue()
        {
            //Stub
            return true;
        }

        // RVA: 0x175C680 Offset: 0x175C781 VA: 0x175C680
        private bool EvCmdLoadAdrsReg()
        {
            //Stub
            return true;
        }

        // RVA: 0x175C690 Offset: 0x175C791 VA: 0x175C690
        private bool EvCmdLoadRegReg()
        {
            //Stub
            return true;
        }

        // RVA: 0x175C6A0 Offset: 0x175C7A1 VA: 0x175C6A0
        private bool EvCmdLoadAdrsAdrs()
        {
            //Stub
            return true;
        }

        // RVA: 0x175C6B0 Offset: 0x175C7B1 VA: 0x175C6B0
        private bool EvCmdCmpRegReg()
        {
            //Stub
            return true;
        }

        // RVA: 0x175C6C0 Offset: 0x175C7C1 VA: 0x175C6C0
        private bool EvCmdCmpRegValue()
        {
            //Stub
            return true;
        }

        // RVA: 0x175C6D0 Offset: 0x175C7D1 VA: 0x175C6D0
        private bool EvCmdCmpRegAdrs()
        {
            //Stub
            return true;
        }

        // RVA: 0x175C6E0 Offset: 0x175C7E1 VA: 0x175C6E0
        private bool EvCmdCmpAdrsReg()
        {
            //Stub
            return true;
        }

        // RVA: 0x175C6F0 Offset: 0x175C7F1 VA: 0x175C6F0
        private bool EvCmdCmpAdrsValue()
        {
            //Stub
            return true;
        }

        // RVA: 0x175C700 Offset: 0x175C801 VA: 0x175C700
        private bool EvCmdCmpAdrsAdrs()
        {
            //Stub
            return true;
        }

        // RVA: 0x175C710 Offset: 0x175C811 VA: 0x175C710
        private bool EvCmdCmpWkValue()
        {
            //Stub
            return true;
        }

        // RVA: 0x175C720 Offset: 0x175C821 VA: 0x175C720
        private bool EvCmdCmpWkWk()
        {
            if (_evArg.Length < 2)
            {
                FUNC_ThrowIndexOutOfRange();
                return true;
            }

            int workNo1;
            switch (_evArg[1].argType)
            {
                case EvData.ArgType.Work:
                    workNo1 = FlagWork.GetWork(_evArg[1].data);
                    break;
                case EvData.ArgType.Float:
                    workNo1 = _evArg[1].data;
                    break;
                default:
                    workNo1 = 0;
                    break;
            }

            if (_evArg.Length < 3)
            {
                FUNC_ThrowIndexOutOfRange();
                return true;
            }

            int workNo2;
            switch (_evArg[2].argType)
            {
                case EvData.ArgType.Work:
                    workNo2 = FlagWork.GetWork(_evArg[2].data);
                    break;
                case EvData.ArgType.Float:
                    workNo2 = _evArg[1].data;
                    break;
                default:
                    workNo2 = 0;
                    break;
            }

            int workValue1 = FlagWork.GetWork(workNo1);
            int workValue2 = FlagWork.GetWork(workNo2);

            if (workValue1 < workValue2)
            {
                _cmp_flag = CmpResult.MINUS;
            }
            else if (workValue1 == workValue2)
            {
                _cmp_flag = CmpResult.EQUAL;
            }
            else
            {
                _cmp_flag = CmpResult.PLUS;
                return true;
            }

            _cmp_flag = CmpResult.PLUS; // This is correct behavior and not a mistake in the decomp
            return true;
        }

        // RVA: 0x175C840 Offset: 0x175C941 VA: 0x175C840
        private bool EvCmdDebugWatch()
        {
            //Stub
            return true;
        }

        // RVA: 0x175C850 Offset: 0x175C951 VA: 0x175C850
        private bool EvCmdVMMachineAdd()
        {
            //Stub
            return true;
        }

        // RVA: 0x175C860 Offset: 0x175C961 VA: 0x175C860
        private bool EvCmdChangeCommonScr()
        {
            //Stub
            return true;
        }

        // RVA: 0x175C9C0 Offset: 0x175CAC1 VA: 0x175C9C0
        private bool EvCmdChangeLocalScr()
        {
            //Stub
            return true;
        }

        // RVA: 0x175CA40 Offset: 0x175CB41 VA: 0x175CA40
        private bool EvCmdGlobalJump()
        {
            //Stub
            return true;
        }

        // RVA: 0x175CAF0 Offset: 0x175CBF1 VA: 0x175CAF0
        private bool EvCmdObjIDJump()
        {
            //Stub
            return true;
        }

        // RVA: 0x175CB00 Offset: 0x175CC01 VA: 0x175CB00
        private bool EvCmdBgIDJump()
        {
            //Stub
            return true;
        }

        // RVA: 0x175CB10 Offset: 0x175CC11 VA: 0x175CB10
        private bool EvCmdPlayerDirJump()
        {
            //Stub
            return true;
        }

        // RVA: 0x175C910 Offset: 0x175CA11 VA: 0x175C910
        private bool EvCmdGlobalCall()
        {
            //Stub
            return true;
        }

        // RVA: 0x175CA00 Offset: 0x175CB01 VA: 0x175CA00
        private bool EvCmdRet()
        {
            //Stub
            return true;
        }

        // RVA: 0x175CB20 Offset: 0x175CC21 VA: 0x175CB20
        private bool EvCmdIfJump()
        {
            if (_evArg.Length < 2)
            {
                FUNC_ThrowIndexOutOfRange();
                return true;
            }

            // TODO: Is this just allocating memory for something?
            if ((DAT_7104c73d10 & 1) == 0)
            {
                thunk_FUN_710026bc70(0x4556);
                DAT_7104c73d10 = 1;
            }

            string eq;
            if (_evArg[1].argType == EvData.ArgType.String)
            {
                eq = _evData.EvData.GetString(_evArg[1].data);
            }
            else
            {
                eq = "";
            }

            if (_evArg.Length < 3)
            {
                FUNC_ThrowIndexOutOfRange();
                return true;
            }
                
            // TODO: Is this just allocating memory for something?
            if ((DAT_7104c73d10 & 1) == 0)
            {
                thunk_FUN_710026bc70(0x4556);
                DAT_7104c73d10 = 1;
            }

            string label = "";
            if (_evArg[2].argType == EvData.ArgType.String)
            {
                label = _evData.EvData.GetString(_evArg[2].data);
            }

            IfJump_Call(true, eq, label);
            return true;
        }

        // RVA: 0x175CC50 Offset: 0x175CD51 VA: 0x175CC50
        private bool EvCmdIfCall()
        {
            if (_evArg.Length < 2)
            {
                FUNC_ThrowIndexOutOfRange();
                return true;
            }

            // TODO: Is this just allocating memory for something?
            if ((DAT_7104c73d10 & 1) == 0)
            {
                thunk_FUN_710026bc70(0x4556);
                DAT_7104c73d10 = 1;
            }

            string eq;
            if (_evArg[1].argType == EvData.ArgType.String)
            {
                eq = _evData.EvData.GetString(_evArg[1].data);
            }
            else
            {
                eq = "";
            }

            if (_evArg.Length < 3)
            {
                FUNC_ThrowIndexOutOfRange();
                return true;
            }

            // TODO: Is this just allocating memory for something?
            if ((DAT_7104c73d10 & 1) == 0)
            {
                thunk_FUN_710026bc70(0x4556);
                DAT_7104c73d10 = 1;
            }

            string label = "";
            if (_evArg[2].argType == EvData.ArgType.String)
            {
                label = _evData.EvData.GetString(_evArg[2].data);
            }

            IfJump_Call(false, eq, label);
            return true;
        }

        // RVA: 0x175CD80 Offset: 0x175CE81 VA: 0x175CD80
        private bool EvMacro_IFVAL_JUMP()
        {
            if (_evArg.Length < 2)
            {
                FUNC_ThrowIndexOutOfRange();
                return true;
            }

            int val1;
            switch (_evArg[1].argType)
            {
                case EvData.ArgType.Work:
                    val1 = FlagWork.GetWork(_evArg[1].data);
                    break;
                case EvData.ArgType.Float:
                    val1 = _evArg[1].data;
                    break;
                default:
                    val1 = 0;
                    break;
            }

            if (_evArg.Length < 3)
            {
                FUNC_ThrowIndexOutOfRange();
                return true;
            }

            // TODO: Is this just allocating memory for something?
            if ((DAT_7104c73d10 & 1) == 0)
            {
                thunk_FUN_710026bc70(0x4556);
                DAT_7104c73d10 = 1;
            }

            string eq = _evArg[2].argType == EvData.ArgType.String ? _evData.EvData.GetString(_evArg[2].data) : "";

            if (_evArg.Length < 4)
            {
                FUNC_ThrowIndexOutOfRange();
                return true;
            }

            int val2;
            switch (_evArg[3].argType)
            {
                case EvData.ArgType.Work:
                    val2 = FlagWork.GetWork(_evArg[3].data);
                    break;
                case EvData.ArgType.Float:
                    val2 = _evArg[3].data;
                    break;
                default:
                    val2 = 0;
                    break;
            }
            
            if (_evArg.Length < 5)
            {
                FUNC_ThrowIndexOutOfRange();
                return true;
            }

            // TODO: Is this just allocating memory for something?
            if ((DAT_7104c73d10 & 1) == 0)
            {
                thunk_FUN_710026bc70(0x4556);
                DAT_7104c73d10 = 1;
            }

            string label = _evArg[4].argType == EvData.ArgType.String ? _evData.EvData.GetString(_evArg[4].data) : "";

            if (CommandEquals(eq, val1, val2))
            {
                JumpLabel(label, null);
            }
            return true;
        }

        // RVA: 0x175CF80 Offset: 0x175D081 VA: 0x175CF80
        private bool EvMacro_IFVAL_CALL()
        {
            if (_evArg.Length < 2)
            {
                FUNC_ThrowIndexOutOfRange();
                return true;
            }

            int val1;
            switch (_evArg[1].argType)
            {
                case EvData.ArgType.Work:
                    val1 = FlagWork.GetWork(_evArg[1].data);
                    break;
                case EvData.ArgType.Float:
                    val1 = _evArg[1].data;
                    break;
                default:
                    val1 = 0;
                    break;
            }

            if (_evArg.Length < 3)
            {
                FUNC_ThrowIndexOutOfRange();
                return true;
            }

            // TODO: Is this just allocating memory for something?
            if ((DAT_7104c73d10 & 1) == 0)
            {
                thunk_FUN_710026bc70(0x4556);
                DAT_7104c73d10 = 1;
            }

            string eq = _evArg[2].argType == EvData.ArgType.String ? _evData.EvData.GetString(_evArg[2].data) : "";

            if (_evArg.Length < 4)
            {
                FUNC_ThrowIndexOutOfRange();
                return true;
            }

            int val2;
            switch (_evArg[3].argType)
            {
                case EvData.ArgType.Work:
                    val2 = FlagWork.GetWork(_evArg[3].data);
                    break;
                case EvData.ArgType.Float:
                    val2 = _evArg[3].data;
                    break;
                default:
                    val2 = 0;
                    break;
            }

            if (_evArg.Length < 5)
            {
                FUNC_ThrowIndexOutOfRange();
                return true;
            }

            // TODO: Is this just allocating memory for something?
            if ((DAT_7104c73d10 & 1) == 0)
            {
                thunk_FUN_710026bc70(0x4556);
                DAT_7104c73d10 = 1;
            }

            string label = _evArg[4].argType == EvData.ArgType.String ? _evData.EvData.GetString(_evArg[4].data) : "";

            if (CommandEquals(eq, val1, val2))
            {
                CallLabel(label);
            }
            return true;
        }

        // RVA: 0x175D180 Offset: 0x175D281 VA: 0x175D180
        private bool EvMacro_IFWK_JUMP()
        {
            //Stub
            return true;
        }

        // RVA: 0x175D1A0 Offset: 0x175D2A1 VA: 0x175D1A0
        private bool EvMacro_IFWK_CALL()
        {
            //Stub
            return true;
        }

        // RVA: 0x175D1C0 Offset: 0x175D2C1 VA: 0x175D1C0
        private bool EvMacro_SWITCH()
        {
            //Stub
            return true;
        }

        // RVA: 0x175D200 Offset: 0x175D301 VA: 0x175D200
        private bool EvMacro_CASE_JUMP()
        {
            int actualVal = FlagWork.GetWork(_switch_work_index);

            if (_evArg.Length < 2)
            {
                FUNC_ThrowIndexOutOfRange();
                return true;
            }

            int checkedVal;
            switch (_evArg[1].argType)
            {
                case EvData.ArgType.Work:
                    checkedVal = FlagWork.GetWork(_evArg[1].data);
                    break;
                case EvData.ArgType.Float:
                    checkedVal = _evArg[1].data;
                    break;
                default:
                    checkedVal = 0;
                    break;
            }

            if (_evArg.Length < 3)
            {
                FUNC_ThrowIndexOutOfRange();
                return true;
            }

            // TODO: Is this just allocating memory for something?
            if ((DAT_7104c73d10 & 1) == 0)
            {
                thunk_FUN_710026bc70(0x4556);
                DAT_7104c73d10 = 1;
            }
                
            string label = _evArg[2].argType == EvData.ArgType.String ? _evData.EvData.GetString(_evArg[2].data) : "";

            if (actualVal == checkedVal)
            {
                JumpLabel(label, null);
            }
            return true;
        }

        // RVA: 0x175D330 Offset: 0x175D431 VA: 0x175D330
        private bool EvMacro_CASE_CANCEL()
        {
            // TODO: Is this just allocating memory for something?
            if ((DAT_7104c73d2d & 1) == 0)
            {
                thunk_FUN_710026bc70(0x4537);
                DAT_7104c73d2d = 1;
            }

            int val1 = FlagWork.GetWork(0xf2);
            int val2 = FlagWork.GetWork(0xf8);
            if (val1 < val2)
            {
                _cmp_flag = CmpResult.MINUS;
            }
            else if (val1 == val2)
            {
                _cmp_flag = CmpResult.EQUAL;
            }
            _cmp_flag = CmpResult.PLUS; // This is correct behavior and not a mistake in the decomp

            if (_evArg.Length < 2)
            {
                FUNC_ThrowIndexOutOfRange();
                return true;
            }

            // TODO: Is this just allocating memory for something?
            if ((DAT_7104c73d10 & 1) == 0)
            {
                thunk_FUN_710026bc70(0x4556);
                DAT_7104c73d10 = 1;
            }

            string label = _evArg[1].argType == EvData.ArgType.String ? _evData.EvData.GetString(_evArg[1].data) : "";

            IfJump_Call(true, "EQ", label);
            return true;
        }

        // RVA: 0x175D450 Offset: 0x175D551 VA: 0x175D450
        private bool EvCmdTimeWaitIconAdd()
        {
            //Stub
            return true;
        }

        // RVA: 0x175D460 Offset: 0x175D561 VA: 0x175D460
        private bool EvCmdTimeWaitIconDel()
        {
            //Stub
            return true;
        }

        // RVA: 0x175D470 Offset: 0x175D571 VA: 0x175D470
        private bool EvCmdFlagSet()
        {
            // TODO: Is this just allocating memory for something?
            if ((DAT_7104c73b1d & 1) == 0)
            {
                thunk_FUN_710026bc70(0x43c1);
                DAT_7104c73b1d = 1;
            }

            if (_evArg.Length < 2)
            {
                FUNC_ThrowIndexOutOfRange();
                return true;
            }

            int flagNo = _evArg[1].data;
            FlagWork.SetFlag(flagNo, true);
            if (flagNo > -1 && flagNo == 0x6b2) // Decomp was weird here with putting SetFlag in the if
            {
                // TODO: A lot of memory allocation stuff? Or some checks to allow static fields?
                if ((((FieldManager_TypeInfo->_2).bitflags2 >> 1 & 1) != 0) && ((FieldManager_TypeInfo->_2).cctor_finished == 0))
                {
                    thunk_FUN_71002640b8();
                }
                if (DAT_7104c73cd2 == '\0')
                {
                    thunk_FUN_710026bc70(0x48ee);
                    DAT_7104c73cd2 = '\x01';
                }
                if ((((FieldManager_TypeInfo->_2).bitflags2 >> 1 & 1) != 0) && ((FieldManager_TypeInfo->_2).cctor_finished == 0))
                {
                    thunk_FUN_71002640b8();
                }
                if ((((EntityManager_TypeInfo->_2).bitflags2 >> 1 & 1) != 0) && ((EntityManager_TypeInfo->_2).cctor_finished == 0))
                {
                    thunk_FUN_71002640b8();
                }
                if (DAT_7104c73cd7 == '\0')
                {
                    thunk_FUN_710026bc70(0x3f06);
                    DAT_7104c73cd7 = '\x01';
                }
                if ((((EntityManager_TypeInfo->_2).bitflags2 >> 1 & 1) != 0) && ((EntityManager_TypeInfo->_2).cctor_finished == 0))
                {
                    thunk_FUN_71002640b8();
                }

                float playerZ = EntityManager.activeFieldPlayer.worldPosition.z;
                FieldManager.Instance.eventTownMapPos = EntityManager.activeFieldPlayer.worldPosition;
                FieldManager.Instance.eventTownMapPos.fields.z = playerZ;
            }

            return true;
        }

        // RVA: 0x175D5F0 Offset: 0x175D6F1 VA: 0x175D5F0
        private bool EvMacro_ARRIVE_FLAG_SET()
        {
            //Stub
            return true;
        }

        // RVA: 0x175D630 Offset: 0x175D731 VA: 0x175D630
        private bool EvCmdFlagReset()
        {
            //Stub
            return true;
        }

        // RVA: 0x175D680 Offset: 0x175D781 VA: 0x175D680
        private bool EvCmdFlagCheck()
        {
            //Stub
            return true;
        }

        // RVA: 0x175D6F0 Offset: 0x175D7F1 VA: 0x175D6F0
        private bool EvMacro_IF_FLAGON_JUMP()
        {
            // TODO: Is this just allocating memory for something?
            if ((DAT_7104c73d2e & 1) == 0)
            {
                thunk_FUN_710026bc70(0x4540);
                DAT_7104c73d2e = 1;
            }

            if (_evArg.Length < 3)
            {
                FUNC_ThrowIndexOutOfRange();
                return true;
            }

            // TODO: Is this just allocating memory for something?
            if ((DAT_7104c73d10 & 1) == 0)
            {
                thunk_FUN_710026bc70(0x4556);
                DAT_7104c73d10 = 1;
            }

            string label;
            if (_evArg[2].argType == EvData.ArgType.String)
            {
                label = _evData.EvData.GetString(_evArg[2].data);
            }
            else
            {
                label = "";
            }

            if (_evArg.Length < 2)
            {
                FUNC_ThrowIndexOutOfRange();
                return true;
            }

            bool flagState;
            int flagNo = _evArg[1].data;
            if (_evArg[1].argType == EvData.ArgType.SysFlag)
            {
                flagState = FlagWork.GetSysFlag((EvWork.SYSFLAG_INDEX)flagNo);
            }
            else
            {
                if (_evArg[1].argType != EvData.ArgType.Flag || flagNo < 0 || flagNo == (int)EvWork.FLAG_INDEX.FLAG_END_SAVE_SIZE)
                {
                    return true;
                }
                flagState = FlagWork.GetFlag(flagNo);
            }

            if (flagState)
            {
                _cmp_flag = CmpResult.EQUAL;
                IfJump_Call(true, "FLGON", label);
            }

            return true;
        }

        // RVA: 0x175D890 Offset: 0x175D991 VA: 0x175D890
        private bool EvMacro_IF_FLAGOFF_JUMP()
        {
            // TODO: Is this just allocating memory for something?
            if ((DAT_7104c73d2f & 1) == 0)
            {
                thunk_FUN_710026bc70(0x453e);
                DAT_7104c73d2f = 1;
            }

            if (_evArg.Length < 3)
            {
                FUNC_ThrowIndexOutOfRange();
                return true;
            }

            // TODO: Is this just allocating memory for something?
            if ((DAT_7104c73d10 & 1) == 0)
            {
                thunk_FUN_710026bc70(0x4556);
                DAT_7104c73d10 = 1;
            }

            string label;
            if (_evArg[2].argType == EvData.ArgType.String)
            {
                label = _evData.EvData.GetString(_evArg[2].data);
            }
            else
            {
                label = "";
            }

            if (_evArg.Length < 2)
            {
                FUNC_ThrowIndexOutOfRange();
                return true;
            }

            bool flagState;
            int flagNo = _evArg[1].data;
            if (_evArg[1].argType == EvData.ArgType.SysFlag)
            {
                flagState = FlagWork.GetSysFlag((EvWork.SYSFLAG_INDEX)flagNo);
            }
            else
            {
                if (_evArg[1].argType != EvData.ArgType.Flag)
                {
                    return true;
                }
                if (flagNo < 0 || flagNo == (int)EvWork.FLAG_INDEX.FLAG_END_SAVE_SIZE)
                {
                    _cmp_flag = CmpResult.MINUS;
                    IfJump_Call(true, "FLGOFF", label);
                    return true;
                }
                flagState = FlagWork.GetFlag(flagNo);
            }

            if (!flagState)
            {
                _cmp_flag = CmpResult.MINUS;
                IfJump_Call(true, "FLGOFF", label);
            }
            
            return true;
        }

        // RVA: 0x175D9D0 Offset: 0x175DAD1 VA: 0x175D9D0
        private bool EvMacro_IF_FLAGON_CALL()
        {
            // TODO: Is this just allocating memory for something?
            if ((DAT_7104c73d30 & 1) == 0)
            {
                thunk_FUN_710026bc70(0x453f);
                DAT_7104c73d30 = 1;
            }

            if (_evArg.Length < 3)
            {
                FUNC_ThrowIndexOutOfRange();
                return true;
            }

            // TODO: Is this just allocating memory for something?
            if ((DAT_7104c73d10 & 1) == 0)
            {
                thunk_FUN_710026bc70(0x4556);
                DAT_7104c73d10 = 1;
            }

            string label;
            if (_evArg[2].argType == EvData.ArgType.String)
            {
                label = _evData.EvData.GetString(_evArg[2].data);
            }
            else
            {
                label = "";
            }

            if (_evArg.Length < 2)
            {
                FUNC_ThrowIndexOutOfRange();
                return true;
            }

            bool flagState;
            int flagNo = _evArg[1].data;
            if (_evArg[1].argType == EvData.ArgType.SysFlag)
            {
                flagState = FlagWork.GetSysFlag((EvWork.SYSFLAG_INDEX)flagNo);
            }
            else
            {
                if (_evArg[1].argType != EvData.ArgType.Flag || flagNo < 0 || flagNo == (int)EvWork.FLAG_INDEX.FLAG_END_SAVE_SIZE)
                {
                    return true;
                }
                flagState = FlagWork.GetFlag(flagNo);
            }

            if (flagState)
            {
                _cmp_flag = CmpResult.EQUAL;
                IfJump_Call(false, "FLGON", label);
            }

            return true;
        }

        // RVA: 0x175DB10 Offset: 0x175DC11 VA: 0x175DB10
        private bool EvMacro_IF_FLAGOFF_CALL()
        {
            // TODO: Is this just allocating memory for something?
            if ((DAT_7104c73d31 & 1) == 0)
            {
                thunk_FUN_710026bc70(0x453d);
                DAT_7104c73d31 = 1;
            }

            if (_evArg.Length < 3)
            {
                FUNC_ThrowIndexOutOfRange();
                return true;
            }

            // TODO: Is this just allocating memory for something?
            if ((DAT_7104c73d10 & 1) == 0)
            {
                thunk_FUN_710026bc70(0x4556);
                DAT_7104c73d10 = 1;
            }

            string label;
            if (_evArg[2].argType == EvData.ArgType.String)
            {
                label = _evData.EvData.GetString(_evArg[2].data);
            }
            else
            {
                label = "";
            }

            if (_evArg.Length < 2)
            {
                FUNC_ThrowIndexOutOfRange();
                return true;
            }

            bool flagState;
            int flagNo = _evArg[1].data;
            if (_evArg[1].argType == EvData.ArgType.SysFlag)
            {
                flagState = FlagWork.GetSysFlag((EvWork.SYSFLAG_INDEX)flagNo);
            }
            else
            {
                if (_evArg[1].argType != EvData.ArgType.Flag)
                {
                    return true;
                }
                if (flagNo < 0 || flagNo == (int)EvWork.FLAG_INDEX.FLAG_END_SAVE_SIZE)
                {
                    _cmp_flag = CmpResult.MINUS;
                    IfJump_Call(false, "FLGOFF", label);
                    return true;
                }
                flagState = FlagWork.GetFlag(flagNo);
            }

            if (!flagState)
            {
                _cmp_flag = CmpResult.MINUS;
                IfJump_Call(false, "FLGOFF", label);
            }

            return true;
        }

        // RVA: 0x175D830 Offset: 0x175D931 VA: 0x175D830
        private int GetIF_FLAG(EvData.Aregment arg)
        {
            //Stub
            return 0;
        }

        // RVA: 0x175DC50 Offset: 0x175DD51 VA: 0x175DC50
        private bool EvCmdFlagCheckWk()
        {
            if (_evArg.Length < 2)
            {
                FUNC_ThrowIndexOutOfRange();
                return true;
            }

            int workNo = _evArg[1].data;
            CmpResult result;
            switch (_evArg[1].argType)
            {
                case EvData.ArgType.Work:
                    int workValue = FlagWork.GetWork(workNo);
                    if (workValue < 0 || workValue == (int)EvWork.FLAG_INDEX.FLAG_END_SAVE_SIZE) result = CmpResult.EQUAL;
                    else result = FlagWork.GetFlag(workValue) ? CmpResult.MINUS : CmpResult.EQUAL;
                    break;

                case EvData.ArgType.Float:
                    if (workNo < 0 || workNo == (int)EvWork.FLAG_INDEX.FLAG_END_SAVE_SIZE) result = CmpResult.EQUAL;
                    else result = FlagWork.GetFlag(workNo) ? CmpResult.MINUS : CmpResult.EQUAL;
                    break;

                default:
                    result = FlagWork.GetFlag(0) ? CmpResult.MINUS : CmpResult.EQUAL;
                    break;
            }

            if (_evArg.Length < 3)
            {
                FUNC_ThrowIndexOutOfRange();
                return true;
            }

            FlagWork.SetWork(_evArg[2].data, (int)result);
            return true;
        }

        // RVA: 0x175DD20 Offset: 0x175DE21 VA: 0x175DD20
        private bool EvCmdFlagSetWk()
        {
            //Stub
            return true;
        }

        // RVA: 0x175DDB0 Offset: 0x175DEB1 VA: 0x175DDB0
        private bool EvCmdTrainerFlagSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x175DE10 Offset: 0x175DF11 VA: 0x175DE10
        private bool EvCmdTrainerFlagReset()
        {
            //Stub
            return true;
        }

        // RVA: 0x175DE70 Offset: 0x175DF71 VA: 0x175DE70
        private bool EvCmdTrainerFlagCheck()
        {
            //Stub
            return true;
        }

        // RVA: 0x175DF00 Offset: 0x175E001 VA: 0x175DF00
        private bool EvMacro_IF_TR_FLAGON_JUMP()
        {
            //Stub
            return true;
        }

        // RVA: 0x175E010 Offset: 0x175E111 VA: 0x175E010
        private bool EvMacro_IF_TR_FLAGOFF_JUMP()
        {
            //Stub
            return true;
        }

        // RVA: 0x175E120 Offset: 0x175E221 VA: 0x175E120
        private bool EvMacro_IF_TR_FLAGON_CALL()
        {
            //Stub
            return true;
        }

        // RVA: 0x175E250 Offset: 0x175E351 VA: 0x175E250
        private bool EvMacro_IF_TR_FLAGOFF_CALL()
        {
            //Stub
            return true;
        }

        // RVA: 0x175E380 Offset: 0x175E481 VA: 0x175E380
        private bool EvCmdWkAdd()
        {
            //Stub
            return true;
        }

        // RVA: 0x175E470 Offset: 0x175E571 VA: 0x175E470
        private bool EvCmdWkSub()
        {
            //Stub
            return true;
        }

        // RVA: 0x175E560 Offset: 0x175E661 VA: 0x175E560
        private bool EvCmdLoadWkValue()
        {
            //Stub
            return true;
        }

        // RVA: 0x175E5F0 Offset: 0x175E6F1 VA: 0x175E5F0
        private bool EvCmdLoadWkWk()
        {
            //Stub
            return true;
        }

        // RVA: 0x175E680 Offset: 0x175E781 VA: 0x175E680
        private bool EvCmdLoadWkWkValue()
        {
            //Stub
            return true;
        }

        // RVA: 0x175E710 Offset: 0x175E811 VA: 0x175E710
        private bool EvCmdTalkMsgAllPut()
        {
            //Stub
            return true;
        }

        // RVA: 0x175E720 Offset: 0x175E821 VA: 0x175E720
        private bool EvCmdTalkMsgAllPutOtherArc()
        {
            //Stub
            return true;
        }

        // RVA: 0x175E730 Offset: 0x175E831 VA: 0x175E730
        private bool EvCmdTalkMsgOtherArc()
        {
            //Stub
            return true;
        }

        // RVA: 0x175E740 Offset: 0x175E841 VA: 0x175E740
        private bool EvCmdTalkMsgAllPutPMS()
        {
            //Stub
            return true;
        }

        // RVA: 0x175E750 Offset: 0x175E851 VA: 0x175E750
        private bool EvCmdTalkMsgPMS()
        {
            //Stub
            return true;
        }

        // RVA: 0x175E760 Offset: 0x175E861 VA: 0x175E760
        private bool EvCmdTalkMsgTowerApper()
        {
            //Stub
            return true;
        }

        // RVA: 0x175E9C0 Offset: 0x175EAC1 VA: 0x175E9C0
        private bool EvCmdTalkMsgNgPokeName()
        {
            //Stub
            return true;
        }

        // RVA: 0x175E9D0 Offset: 0x175EAD1 VA: 0x175E9D0
        private bool EvCmdTalkMsg()
        {
            //Stub
            return true;
        }

        // RVA: 0x175E9E0 Offset: 0x175EAE1 VA: 0x175E9E0
        private bool EvCmdTalkMsgSp()
        {
            //Stub
            return true;
        }

        // RVA: 0x175E9F0 Offset: 0x175EAF1 VA: 0x175E9F0
        private bool EvCmdTalkMsgSpAuto()
        {
            //Stub
            return true;
        }

        // RVA: 0x175EA00 Offset: 0x175EB01 VA: 0x175EA00
        private bool EvCmdTalkMsgNoSkip()
        {
            //Stub
            return true;
        }

        // RVA: 0x175EA10 Offset: 0x175EB11 VA: 0x175EA10
        private bool EvCmdTalkConSioMsg()
        {
            //Stub
            return true;
        }

        // RVA: 0x175EA20 Offset: 0x175EB21 VA: 0x175EA20
        private bool EvCmdMsgAutoGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x175EA30 Offset: 0x175EB31 VA: 0x175EA30
        private bool EvCmdABKeyWait()
        {
            //Stub
            return true;
        }

        // RVA: 0x175EA40 Offset: 0x175EB41 VA: 0x175EA40
        private bool EvCmdABKeyTimeWait()
        {
            //Stub
            return true;
        }

        // RVA: 0x175EB10 Offset: 0x175EC11 VA: 0x175EB10
        private bool EvCmdLastKeyWait()
        {
            //Stub
            return true;
        }

        // RVA: 0x175EB20 Offset: 0x175EC21 VA: 0x175EB20
        private bool EvCmdNextAnmLastKeyWait()
        {
            //Stub
            return true;
        }

        // RVA: 0x175EB30 Offset: 0x175EC31 VA: 0x175EB30
        private bool EvCmdTalkWinOpen()
        {
            //Stub
            return true;
        }

        // RVA: 0x175EB90 Offset: 0x175EC91 VA: 0x175EB90
        private bool EvCmdTalkWinClose()
        {
            //Stub
            return true;
        }

        // RVA: 0x175EBD0 Offset: 0x175ECD1 VA: 0x175EBD0
        private bool EvCmdTalkWinCloseNoClear()
        {
            //Stub
            return true;
        }

        // RVA: 0x175EC10 Offset: 0x175ED11 VA: 0x175EC10
        private bool EvMacro_TALK_KEYWAIT()
        {
            //Stub
            return true;
        }

        // RVA: 0x175EC20 Offset: 0x175ED21 VA: 0x175EC20
        private bool EvMacro_EASY_OBJ_MSG()
        {
            //Stub
            return true;
        }

        // RVA: 0x175EDA0 Offset: 0x175EEA1 VA: 0x175EDA0
        private bool EvMacro_EASY_MSG()
        {
            //Stub
            return true;
        }

        // RVA: 0x175EF70 Offset: 0x175F071 VA: 0x175EF70
        private bool EvCmdBoardMake()
        {
            //Stub
            return true;
        }

        // RVA: 0x175F460 Offset: 0x175F561 VA: 0x175F460
        private bool EvCmdInfoBoardMake()
        {
            //Stub
            return true;
        }

        // RVA: 0x175F950 Offset: 0x175FA51 VA: 0x175F950
        private bool EvCmdBoardReq()
        {
            //Stub
            return true;
        }

        // RVA: 0x175FDA0 Offset: 0x175FEA1 VA: 0x175FDA0
        private bool EvCmdBoardWait()
        {
            //Stub
            return true;
        }

        // RVA: 0x175FE40 Offset: 0x175FF41 VA: 0x175FE40
        private bool EvCmdBoardMsg()
        {
            //Stub
            return true;
        }

        // RVA: 0x175FFB0 Offset: 0x17600B1 VA: 0x175FFB0
        private bool EvCmdBoardEndWait()
        {
            //Stub
            return true;
        }

        // RVA: 0x175FFC0 Offset: 0x17600C1 VA: 0x175FFC0
        private bool EvMacro_EASY_BOARD_MSG()
        {
            //Stub
            return true;
        }

        // RVA: 0x1760160 Offset: 0x1760261 VA: 0x1760160
        private bool EvMacro_EASY_INFOBOARD_MSG()
        {
            //Stub
            return true;
        }

        // RVA: 0x1760300 Offset: 0x1760401 VA: 0x1760300
        private bool EvCmdMenuReq()
        {
            //Stub
            return true;
        }

        // RVA: 0x1760310 Offset: 0x1760411 VA: 0x1760310
        private bool EvCmdBgScroll()
        {
            //Stub
            return true;
        }

        // RVA: 0x1760320 Offset: 0x1760421 VA: 0x1760320
        private bool EvCmdYesNoWin()
        {
            //Stub
            return true;
        }

        // RVA: 0x1760330 Offset: 0x1760431 VA: 0x1760330
        private bool EvCmdGuinnessWin()
        {
            //Stub
            return true;
        }

        // RVA: 0x1760340 Offset: 0x1760441 VA: 0x1760340
        private bool EvCmdBmpMenuInit()
        {
            //Stub
            return true;
        }

        // RVA: 0x1760350 Offset: 0x1760451 VA: 0x1760350
        private bool EvCmdBmpMenuInitEx()
        {
            //Stub
            return true;
        }

        // RVA: 0x1760360 Offset: 0x1760461 VA: 0x1760360
        private bool EvCmdBmpMenuMakeList()
        {
            //Stub
            return true;
        }

        // RVA: 0x1760370 Offset: 0x1760471 VA: 0x1760370
        private bool EvCmdBmpMenuMakeList16()
        {
            //Stub
            return true;
        }

        // RVA: 0x1760380 Offset: 0x1760481 VA: 0x1760380
        private bool EvCmdBmpMenuStart()
        {
            //Stub
            return true;
        }

        // RVA: 0x1760390 Offset: 0x1760491 VA: 0x1760390
        private bool EvCmdBmpListInit()
        {
            //Stub
            return true;
        }

        // RVA: 0x17603A0 Offset: 0x17604A1 VA: 0x17603A0
        private bool EvCmdBmpListInitEx()
        {
            //Stub
            return true;
        }

        // RVA: 0x17603B0 Offset: 0x17604B1 VA: 0x17603B0
        private bool EvCmdBmpListMakeList()
        {
            //Stub
            return true;
        }

        // RVA: 0x17603C0 Offset: 0x17604C1 VA: 0x17603C0
        private bool EvCmdBmpListStart()
        {
            //Stub
            return true;
        }

        // RVA: 0x17603D0 Offset: 0x17604D1 VA: 0x17603D0
        private bool EvCmdBmpMenuHVStart()
        {
            //Stub
            return true;
        }

        // RVA: 0x17603E0 Offset: 0x17604E1 VA: 0x17603E0
        private bool EvCmdSePlay()
        {
            //Stub
            return true;
        }

        // RVA: 0x1760490 Offset: 0x1760591 VA: 0x1760490
        private bool EvCmdSeStop()
        {
            //Stub
            return true;
        }

        // RVA: 0x1760540 Offset: 0x1760641 VA: 0x1760540
        private bool EvCmdSeWait()
        {
            //Stub
            return true;
        }

        // RVA: 0x17605F0 Offset: 0x17606F1 VA: 0x17605F0
        private bool EvCmdVoicePlay()
        {
            //Stub
            return true;
        }

        // RVA: 0x1760740 Offset: 0x1760841 VA: 0x1760740
        private bool EvCmdVoicePlayWait()
        {
            //Stub
            return true;
        }

        // RVA: 0x17607A0 Offset: 0x17608A1 VA: 0x17607A0
        private bool EvMacro_EASY_VOICE_MSG()
        {
            //Stub
            return true;
        }

        // RVA: 0x1760B50 Offset: 0x1760C51 VA: 0x1760B50
        private bool EvCmdMePlay()
        {
            //Stub
            return true;
        }

        // RVA: 0x1760C00 Offset: 0x1760D01 VA: 0x1760C00
        private bool EvCmdMeWait()
        {
            //Stub
            return true;
        }

        // RVA: 0x1760C60 Offset: 0x1760D61 VA: 0x1760C60
        private bool EvCmdSndInitialVolSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x1760C70 Offset: 0x1760D71 VA: 0x1760C70
        private bool EvCmdBgmPlay()
        {
            //Stub
            return true;
        }

        // RVA: 0x1760DE0 Offset: 0x1760EE1 VA: 0x1760DE0
        private bool EvCmdBgmPlayCheck()
        {
            //Stub
            return true;
        }

        // RVA: 0x1760DF0 Offset: 0x1760EF1 VA: 0x1760DF0
        private bool EvCmdBgmStop()
        {
            //Stub
            return true;
        }

        // RVA: 0x1760E70 Offset: 0x1760F71 VA: 0x1760E70
        private bool EvCmdBgmNowMapPlay()
        {
            //Stub
            return true;
        }

        // RVA: 0x1760FB0 Offset: 0x17610B1 VA: 0x1760FB0
        private bool EvCmdBgmSpecialSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x1761120 Offset: 0x1761221 VA: 0x1761120
        private bool EvMacro_BGM_SPECIAL_CLR()
        {
            //Stub
            return true;
        }

        // RVA: 0x1761130 Offset: 0x1761231 VA: 0x1761130
        private bool EvCmdBgmFadeOut()
        {
            //Stub
            return true;
        }

        // RVA: 0x1761140 Offset: 0x1761241 VA: 0x1761140
        private bool EvMacro_BGM_FADEOUT_PLAY()
        {
            //Stub
            return true;
        }

        // RVA: 0x1761150 Offset: 0x1761251 VA: 0x1761150
        private bool EvCmdBgmFadeIn()
        {
            //Stub
            return true;
        }

        // RVA: 0x1761160 Offset: 0x1761261 VA: 0x1761160
        private bool EvCmdBgmPlayerPause()
        {
            //Stub
            return true;
        }

        // RVA: 0x1761170 Offset: 0x1761271 VA: 0x1761170
        private bool EvCmdPlayerFieldDemoBgmPlay()
        {
            //Stub
            return true;
        }

        // RVA: 0x17612E0 Offset: 0x17613E1 VA: 0x17612E0
        private bool EvCmdCtrlBgmFlagSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x17613C0 Offset: 0x17614C1 VA: 0x17613C0
        private bool EvCmdCtrlBgmFlagReSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x1761490 Offset: 0x1761591 VA: 0x1761490
        private bool EvCmdPerapDataCheck()
        {
            //Stub
            return true;
        }

        // RVA: 0x17614A0 Offset: 0x17615A1 VA: 0x17614A0
        private bool EvCmdPerapRecStart()
        {
            //Stub
            return true;
        }

        // RVA: 0x17614B0 Offset: 0x17615B1 VA: 0x17614B0
        private bool EvCmdPerapRecStop()
        {
            //Stub
            return true;
        }

        // RVA: 0x17614C0 Offset: 0x17615C1 VA: 0x17614C0
        private bool EvCmdPerapSave()
        {
            //Stub
            return true;
        }

        // RVA: 0x17614D0 Offset: 0x17615D1 VA: 0x17614D0
        private bool EvCmdSndClimaxDataLoad()
        {
            //Stub
            return true;
        }

        // RVA: 0x17614E0 Offset: 0x17615E1 VA: 0x17614E0
        private bool EvCmdObjAnime()
        {
            //Stub
            return true;
        }

        // RVA: 0x17617A0 Offset: 0x17618A1 VA: 0x17617A0
        private bool EvCmdObjAnimePos()
        {
            //Stub
            return true;
        }

        // RVA: 0x17617B0 Offset: 0x17618B1 VA: 0x17617B0
        private bool EvMacro_ANIME_LABEL()
        {
            //Stub
            return true;
        }

        // RVA: 0x17617C0 Offset: 0x17618C1 VA: 0x17617C0
        private bool EvMacro_ANIME_DATA()
        {
            //Stub
            return true;
        }

        // RVA: 0x17617D0 Offset: 0x17618D1 VA: 0x17617D0
        private bool EvCmdObjAnimeWait()
        {
            //Stub
            return true;
        }

        // RVA: 0x1761820 Offset: 0x1761921 VA: 0x1761820
        private bool EvCmdTalkObjPauseAll()
        {
            //Stub
            return true;
        }

        // RVA: 0x1761830 Offset: 0x1761931 VA: 0x1761830
        private bool EvCmdObjPauseAll()
        {
            //Stub
            return true;
        }

        // RVA: 0x1761850 Offset: 0x1761951 VA: 0x1761850
        private bool EvCmdObjPauseClearAll()
        {
            //Stub
            return true;
        }

        // RVA: 0x1761860 Offset: 0x1761961 VA: 0x1761860
        private bool EvCmdObjPause()
        {
            //Stub
            return true;
        }

        // RVA: 0x1761980 Offset: 0x1761A81 VA: 0x1761980
        private bool EvCmdObjPauseClear()
        {
            //Stub
            return true;
        }

        // RVA: 0x1761A90 Offset: 0x1761B91 VA: 0x1761A90
        private bool EvCmdObjAdd()
        {
            //Stub
            return true;
        }

        // RVA: 0x1761BB0 Offset: 0x1761CB1 VA: 0x1761BB0
        private bool EvCmdObjDel()
        {
            //Stub
            return true;
        }

        // RVA: 0x1761DA0 Offset: 0x1761EA1 VA: 0x1761DA0
        private bool EvCmdVanishDummyObjAdd()
        {
            //Stub
            return true;
        }

        // RVA: 0x1761DB0 Offset: 0x1761EB1 VA: 0x1761DB0
        private bool EvCmdVanishDummyObjDel()
        {
            //Stub
            return true;
        }

        // RVA: 0x1761DC0 Offset: 0x1761EC1 VA: 0x1761DC0
        private bool EvCmdObjTurn()
        {
            //Stub
            return true;
        }

        // RVA: 0x175ED90 Offset: 0x175EE91 VA: 0x175ED90
        private bool EvMacro_TALK_OBJ_START()
        {
            //Stub
            return true;
        }

        // RVA: 0x1761DE0 Offset: 0x1761EE1 VA: 0x1761DE0
        private bool EvMacro_TALK_OBJ_START_TURN_NOT()
        {
            //Stub
            return true;
        }

        // RVA: 0x1761DF0 Offset: 0x1761EF1 VA: 0x1761DF0
        private bool EvMacro_TALK_OBJ_END()
        {
            //Stub
            return true;
        }

        // RVA: 0x1761E10 Offset: 0x1761F11 VA: 0x1761E10
        private bool EvMacro_TALK_START()
        {
            //Stub
            return true;
        }

        // RVA: 0x1761EC0 Offset: 0x1761FC1 VA: 0x1761EC0
        private bool EvMacro_EVENT_START()
        {
            //Stub
            return true;
        }

        // RVA: 0x1761F40 Offset: 0x1762041 VA: 0x1761F40
        private bool EvMacro_TALK_END()
        {
            //Stub
            return true;
        }

        // RVA: 0x1761F60 Offset: 0x1762061 VA: 0x1761F60
        private bool EvMacro_EVENT_END()
        {
            //Stub
            return true;
        }

        // RVA: 0x1761F80 Offset: 0x1762081 VA: 0x1761F80
        private bool EvCmdPlayerPosGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x17620E0 Offset: 0x17621E1 VA: 0x17620E0
        private bool EvCmdObjPosGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x1762260 Offset: 0x1762361 VA: 0x1762260
        private bool EvCmdPlayerPosOffsetSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x1762270 Offset: 0x1762371 VA: 0x1762270
        private bool EvCmdPlayerDirGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x1762390 Offset: 0x1762491 VA: 0x1762390
        private bool EvCmdNotZoneDelSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x17623A0 Offset: 0x17624A1 VA: 0x17623A0
        private bool EvCmdMoveCodeChange()
        {
            //Stub
            return true;
        }

        // RVA: 0x1762540 Offset: 0x1762641 VA: 0x1762540
        private bool EvCmdMoveCodeGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x1762550 Offset: 0x1762651 VA: 0x1762550
        private bool EvCmdPairObjIdSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x1762660 Offset: 0x1762761 VA: 0x1762660
        private bool EvMacro_EVENT_DATA()
        {
            //Stub
            return true;
        }

        // RVA: 0x1762670 Offset: 0x1762771 VA: 0x1762670
        private bool EvMacro_EVENT_DATA_END()
        {
            //Stub
            return true;
        }

        // RVA: 0x1762680 Offset: 0x1762781 VA: 0x1762680
        private bool EvMacro_SP_EVENT_DATA_END()
        {
            //Stub
            return true;
        }

        // RVA: 0x17626B0 Offset: 0x17627B1 VA: 0x17626B0
        private bool EvMacro_SCENE_CHANGE_LABEL()
        {
            //Stub
            return true;
        }

        // RVA: 0x1762760 Offset: 0x1762861 VA: 0x1762760
        private bool EvMacro_SCENE_CHANGE_DATA()
        {
            //Stub
            return true;
        }

        // RVA: 0x17628E0 Offset: 0x17629E1 VA: 0x17628E0
        private bool EvMacro_SCENE_CHANGE_END()
        {
            //Stub
            return true;
        }

        // RVA: 0x1762910 Offset: 0x1762A11 VA: 0x1762910
        private bool EvMacro_FLAG_CHANGE_LABEL()
        {
            //Stub
            return true;
        }

        // RVA: 0x17629C0 Offset: 0x1762AC1 VA: 0x17629C0
        private bool EvMacro_OBJ_CHANGE_LABEL()
        {
            //Stub
            return true;
        }

        // RVA: 0x1762A70 Offset: 0x1762B71 VA: 0x1762A70
        private bool EvMacro_INIT_CHANGE_LABEL()
        {
            //Stub
            return true;
        }

        // RVA: 0x1762B20 Offset: 0x1762C21 VA: 0x1762B20
        private bool EvCmdAddGold()
        {
            //Stub
            return true;
        }

        // RVA: 0x1762B90 Offset: 0x1762C91 VA: 0x1762B90
        private bool EvCmdSubGold()
        {
            //Stub
            return true;
        }

        // RVA: 0x1762C10 Offset: 0x1762D11 VA: 0x1762C10
        private bool EvCmdCompGold()
        {
            //Stub
            return true;
        }

        // RVA: 0x1762CF0 Offset: 0x1762DF1 VA: 0x1762CF0
        private bool EvCmd_GET_GOLD()
        {
            //Stub
            return true;
        }

        // RVA: 0x1762D90 Offset: 0x1762E91 VA: 0x1762D90
        private bool EvCmdGoldWinWrite()
        {
            //Stub
            return true;
        }

        // RVA: 0x1762DA0 Offset: 0x1762EA1 VA: 0x1762DA0
        private bool EvCmdGoldWinDel()
        {
            //Stub
            return true;
        }

        // RVA: 0x1762DB0 Offset: 0x1762EB1 VA: 0x1762DB0
        private bool EvCmdGoldWrite()
        {
            //Stub
            return true;
        }

        // RVA: 0x1762DC0 Offset: 0x1762EC1 VA: 0x1762DC0
        private bool EvCmdCoinWinWrite()
        {
            //Stub
            return true;
        }

        // RVA: 0x1762DD0 Offset: 0x1762ED1 VA: 0x1762DD0
        private bool EvCmdCoinWinDel()
        {
            //Stub
            return true;
        }

        // RVA: 0x1762DE0 Offset: 0x1762EE1 VA: 0x1762DE0
        private bool EvCmdCoinWrite()
        {
            //Stub
            return true;
        }

        // RVA: 0x1762DF0 Offset: 0x1762EF1 VA: 0x1762DF0
        private bool EvCmdCheckCoin()
        {
            //Stub
            return true;
        }

        // RVA: 0x1762E00 Offset: 0x1762F01 VA: 0x1762E00
        private bool EvCmdAddCoin()
        {
            //Stub
            return true;
        }

        // RVA: 0x1762E10 Offset: 0x1762F11 VA: 0x1762E10
        private bool EvCmdSubCoin()
        {
            //Stub
            return true;
        }

        // RVA: 0x1762E20 Offset: 0x1762F21 VA: 0x1762E20
        private bool EvMacro_FLD_ITEM_EVENT()
        {
            //Stub
            return true;
        }

        // RVA: 0x1762F60 Offset: 0x1763061 VA: 0x1762F60
        private bool EvMacro_HIDE_ITEM_EVENT()
        {
            //Stub
            return true;
        }

        // RVA: 0x1762F70 Offset: 0x1763071 VA: 0x1762F70
        private bool EvCmdAddItem()
        {
            //Stub
            return true;
        }

        // RVA: 0x17630C0 Offset: 0x17631C1 VA: 0x17630C0
        private bool EvCmdSubItem()
        {
            //Stub
            return true;
        }

        // RVA: 0x1763260 Offset: 0x1763361 VA: 0x1763260
        private bool EvCmdAddItemChk()
        {
            //Stub
            return true;
        }

        // RVA: 0x17633C0 Offset: 0x17634C1 VA: 0x17633C0
        private bool EvCmdCheckItem()
        {
            //Stub
            return true;
        }

        // RVA: 0x1763510 Offset: 0x1763611 VA: 0x1763510
        private bool EvCmd_GET_ITEM_COUNT()
        {
            //Stub
            return true;
        }

        // RVA: 0x1763610 Offset: 0x1763711 VA: 0x1763610
        private bool EvCmd_PLAY_EMO_SE()
        {
            //Stub
            return true;
        }

        // RVA: 0x17636E0 Offset: 0x17637E1 VA: 0x17636E0
        private bool EvCmdWazaMachineItemNoCheck()
        {
            //Stub
            return true;
        }

        // RVA: 0x17637A0 Offset: 0x17638A1 VA: 0x17637A0
        private bool EvCmdGetPocketNo()
        {
            //Stub
            return true;
        }

        // RVA: 0x1763910 Offset: 0x1763A11 VA: 0x1763910
        private bool EvCmdPocketCheck()
        {
            //Stub
            return true;
        }

        // RVA: 0x1763A30 Offset: 0x1763B31 VA: 0x1763A30
        private bool EvCmdPofinCheck()
        {
            //Stub
            return true;
        }

        // RVA: 0x1763AF0 Offset: 0x1763BF1 VA: 0x1763AF0
        private bool EvCmdAddPCBoxItem()
        {
            //Stub
            return true;
        }

        // RVA: 0x1763B00 Offset: 0x1763C01 VA: 0x1763B00
        private bool EvCmdCheckPCBoxItem()
        {
            //Stub
            return true;
        }

        // RVA: 0x1763B10 Offset: 0x1763C11 VA: 0x1763B10
        private bool EvCmdAddGoods()
        {
            //Stub
            return true;
        }

        // RVA: 0x1763B20 Offset: 0x1763C21 VA: 0x1763B20
        private bool EvCmdSubGoods()
        {
            //Stub
            return true;
        }

        // RVA: 0x1763B30 Offset: 0x1763C31 VA: 0x1763B30
        private bool EvCmdAddGoodsChk()
        {
            //Stub
            return true;
        }

        // RVA: 0x1763B40 Offset: 0x1763C41 VA: 0x1763B40
        private bool EvCmdCheckGoods()
        {
            //Stub
            return true;
        }

        // RVA: 0x1763B50 Offset: 0x1763C51 VA: 0x1763B50
        private bool EvCmdAddTrap()
        {
            //Stub
            return true;
        }

        // RVA: 0x1763B60 Offset: 0x1763C61 VA: 0x1763B60
        private bool EvCmdSubTrap()
        {
            //Stub
            return true;
        }

        // RVA: 0x1763B70 Offset: 0x1763C71 VA: 0x1763B70
        private bool EvCmdAddTrapChk()
        {
            //Stub
            return true;
        }

        // RVA: 0x1763B80 Offset: 0x1763C81 VA: 0x1763B80
        private bool EvCmdCheckTrap()
        {
            //Stub
            return true;
        }

        // RVA: 0x1763B90 Offset: 0x1763C91 VA: 0x1763B90
        private bool EvCmdAddTreasure()
        {
            //Stub
            return true;
        }

        // RVA: 0x1763BA0 Offset: 0x1763CA1 VA: 0x1763BA0
        private bool EvCmdSubTreasure()
        {
            //Stub
            return true;
        }

        // RVA: 0x1763BB0 Offset: 0x1763CB1 VA: 0x1763BB0
        private bool EvCmdAddTreasureChk()
        {
            //Stub
            return true;
        }

        // RVA: 0x1763BC0 Offset: 0x1763CC1 VA: 0x1763BC0
        private bool EvCmdCheckTreasure()
        {
            //Stub
            return true;
        }

        // RVA: 0x1763BD0 Offset: 0x1763CD1 VA: 0x1763BD0
        private bool EvCmdAddTama()
        {
            //Stub
            return true;
        }

        // RVA: 0x1763BE0 Offset: 0x1763CE1 VA: 0x1763BE0
        private bool EvCmdSubTama()
        {
            //Stub
            return true;
        }

        // RVA: 0x1763BF0 Offset: 0x1763CF1 VA: 0x1763BF0
        private bool EvCmdAddTamaChk()
        {
            //Stub
            return true;
        }

        // RVA: 0x1763C00 Offset: 0x1763D01 VA: 0x1763C00
        private bool EvCmdCheckTama()
        {
            //Stub
            return true;
        }

        // RVA: 0x1763C10 Offset: 0x1763D11 VA: 0x1763C10
        private bool EvCmdCBSealKindNumGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x1763C20 Offset: 0x1763D21 VA: 0x1763C20
        private bool EvCmdCBItemNumGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x1763D10 Offset: 0x1763E11 VA: 0x1763D10
        private bool EvCmdCBItemNumAdd()
        {
            //Stub
            return true;
        }

        // RVA: 0x1763E40 Offset: 0x1763F41 VA: 0x1763E40
        private bool EvCmdUnknownFormGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x17640E0 Offset: 0x17641E1 VA: 0x17640E0
        private bool EvCmdAddPokemon()
        {
            //Stub
            return true;
        }

        // RVA: 0x17643D0 Offset: 0x17644D1 VA: 0x17643D0
        private bool EvCmdAddPokemonUI()
        {
            //Stub
            return true;
        }

        // RVA: 0x1764720 Offset: 0x1764821 VA: 0x1764720
        private bool EvCmdAddUniquePokemonUI()
        {
            //Stub
            return true;
        }

        // RVA: 0x1764880 Offset: 0x1764981 VA: 0x1764880
        private bool EvCmdAddTamago()
        {
            //Stub
            return true;
        }

        // RVA: 0x1764AE0 Offset: 0x1764BE1 VA: 0x1764AE0
        private bool EvCmdChgPokeWaza()
        {
            //Stub
            return true;
        }

        // RVA: 0x1764AF0 Offset: 0x1764BF1 VA: 0x1764AF0
        private bool EvCmdChkPokeWaza()
        {
            //Stub
            return true;
        }

        // RVA: 0x1764D20 Offset: 0x1764E21 VA: 0x1764D20
        private bool EvCmdChkPokeWazaGroup()
        {
            //Stub
            return true;
        }

        // RVA: 0x1764E90 Offset: 0x1764F91 VA: 0x1764E90
        private bool EvCmdAddWaza()
        {
            //Stub
            return true;
        }

        // RVA: 0x1765000 Offset: 0x1765101 VA: 0x1765000
        private bool EvCmdApprovePoisonDead()
        {
            //Stub
            return true;
        }

        // RVA: 0x1765010 Offset: 0x1765111 VA: 0x1765010
        private bool EvCmdRevengeTrainerSearch()
        {
            //Stub
            return true;
        }

        // RVA: 0x17650A0 Offset: 0x17651A1 VA: 0x17650A0
        private bool EvCmdSetWeather()
        {
            //Stub
            return true;
        }

        // RVA: 0x17650B0 Offset: 0x17651B1 VA: 0x17650B0
        private bool EvCmdInitWeather()
        {
            //Stub
            return true;
        }

        // RVA: 0x17650C0 Offset: 0x17651C1 VA: 0x17650C0
        private bool EvCmdUpdateWeather()
        {
            //Stub
            return true;
        }

        // RVA: 0x17650D0 Offset: 0x17651D1 VA: 0x17650D0
        private bool EvCmdGetMapPosition()
        {
            //Stub
            return true;
        }

        // RVA: 0x17650E0 Offset: 0x17651E1 VA: 0x17650E0
        private bool EvCmdGetTemotiPokeNum()
        {
            //Stub
            return true;
        }

        // RVA: 0x17650F0 Offset: 0x17651F1 VA: 0x17650F0
        private bool EvCmdSetMapProc()
        {
            //Stub
            return true;
        }

        // RVA: 0x1765100 Offset: 0x1765201 VA: 0x1765100
        private bool EvCmdFinishMapProc()
        {
            //Stub
            return true;
        }

        // RVA: 0x1765110 Offset: 0x1765211 VA: 0x1765110
        private bool EvCmdWiFiAutoReg()
        {
            //Stub
            return true;
        }

        // RVA: 0x1765120 Offset: 0x1765221 VA: 0x1765120
        private bool EvCmdWiFiP2PMatchEventCall()
        {
            //Stub
            return true;
        }

        // RVA: 0x1765130 Offset: 0x1765231 VA: 0x1765130
        private bool EvCmdWiFiP2PMatchSetDel()
        {
            //Stub
            return true;
        }

        // RVA: 0x1765140 Offset: 0x1765241 VA: 0x1765140
        private bool EvCmdCommGetCurrentID()
        {
            //Stub
            return true;
        }

        // RVA: 0x1765150 Offset: 0x1765251 VA: 0x1765150
        private bool EvCmdDendouNumGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x17651B0 Offset: 0x17652B1 VA: 0x17651B0
        private bool EvCmdPokeWindowPut()
        {
            //Stub
            return true;
        }

        // RVA: 0x1765380 Offset: 0x1765481 VA: 0x1765380
        private bool EvCmdPokeWindowPutPP()
        {
            //Stub
            return true;
        }

        // RVA: 0x1765390 Offset: 0x1765491 VA: 0x1765390
        private bool EvCmdPokeWindowDel()
        {
            //Stub
            return true;
        }

        // RVA: 0x17653A0 Offset: 0x17654A1 VA: 0x17653A0
        private bool EvCmdPokeWindowAnm()
        {
            //Stub
            return true;
        }

        // RVA: 0x17653B0 Offset: 0x17654B1 VA: 0x17653B0
        private bool EvCmdPokeWindowAnmWait()
        {
            //Stub
            return true;
        }

        // RVA: 0x17653C0 Offset: 0x17654C1 VA: 0x17653C0
        private bool EvCmdBtlSearcherEventCall()
        {
            //Stub
            return true;
        }

        // RVA: 0x17655E0 Offset: 0x17656E1 VA: 0x17655E0
        private bool EvCmdBtlSearcherDirMvSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x17655F0 Offset: 0x17656F1 VA: 0x17655F0
        private bool EvCmdMsgBoyEvent()
        {
            //Stub
            return true;
        }

        // RVA: 0x1765600 Offset: 0x1765701 VA: 0x1765600
        private bool EvCmdImageClipSetProc()
        {
            //Stub
            return true;
        }

        // RVA: 0x1765610 Offset: 0x1765711 VA: 0x1765610
        private bool EvCmdImageClipPreviewTvProc()
        {
            //Stub
            return true;
        }

        // RVA: 0x1765620 Offset: 0x1765721 VA: 0x1765620
        private bool EvCmdImageClipPreviewConProc()
        {
            //Stub
            return true;
        }

        // RVA: 0x1765820 Offset: 0x1765921 VA: 0x1765820
        private bool EvCmdCustomBallEventCall()
        {
            //Stub
            return true;
        }

        // RVA: 0x1765910 Offset: 0x1765A11 VA: 0x1765910
        private bool EvCmdTMapBGSetProc()
        {
            //Stub
            return true;
        }

        // RVA: 0x1765A30 Offset: 0x1765B31 VA: 0x1765A30
        private bool EvCmdBoxSetProc()
        {
            //Stub
            return true;
        }

        // RVA: 0x1765B20 Offset: 0x1765C21 VA: 0x1765B20
        private bool EvCmd_BOX_SEAL_UI_WAIT()
        {
            //Stub
            return true;
        }

        // RVA: 0x1765B30 Offset: 0x1765C31 VA: 0x1765B30
        private bool EvCmdOekakiBoardSetProc()
        {
            //Stub
            return true;
        }

        // RVA: 0x1765B40 Offset: 0x1765C41 VA: 0x1765B40
        private bool EvCmdCallTrCard()
        {
            //Stub
            return true;
        }

        // RVA: 0x1765B50 Offset: 0x1765C51 VA: 0x1765B50
        private bool EvCmdTradeListSetProc()
        {
            //Stub
            return true;
        }

        // RVA: 0x1765B60 Offset: 0x1765C61 VA: 0x1765B60
        private bool EvCmdRecordCornerSetProc()
        {
            //Stub
            return true;
        }

        // RVA: 0x1765B70 Offset: 0x1765C71 VA: 0x1765B70
        private bool EvCmdDendouSetProc()
        {
            //Stub
            return true;
        }

        // RVA: 0x1765D20 Offset: 0x1765E21 VA: 0x1765D20
        private bool EvCmdPcDendouSetProc()
        {
            //Stub
            return true;
        }

        // RVA: 0x1765E30 Offset: 0x1765F31 VA: 0x1765E30
        private bool EvCmdPcDendouSetProcOpenWait()
        {
            //Stub
            return true;
        }

        // RVA: 0x1765E40 Offset: 0x1765F41 VA: 0x1765E40
        private bool EvCmdWorldTradeSetProc()
        {
            //Stub
            return true;
        }

        // RVA: 0x1765E50 Offset: 0x1765F51 VA: 0x1765E50
        private bool EvCmdDPWInitProc()
        {
            //Stub
            return true;
        }

        // RVA: 0x1765E60 Offset: 0x1765F61 VA: 0x1765E60
        private bool EvCmdFirstPokeSelectProc()
        {
            //Stub
            return true;
        }

        // RVA: 0x1765E70 Offset: 0x1765F71 VA: 0x1765E70
        private bool EvCmdFirstPokeSelectSetAndDel()
        {
            //Stub
            return true;
        }

        // RVA: 0x1765E80 Offset: 0x1765F81 VA: 0x1765E80
        private bool EvCmdBagSetProcNormal()
        {
            //Stub
            return true;
        }

        // RVA: 0x1765E90 Offset: 0x1765F91 VA: 0x1765E90
        private bool EvCmdBagSetProcKinomi()
        {
            //Stub
            return true;
        }

        // RVA: 0x1765FE0 Offset: 0x17660E1 VA: 0x1765FE0
        private bool EvCmdBagGetResult()
        {
            //Stub
            return true;
        }

        // RVA: 0x1766030 Offset: 0x1766131 VA: 0x1766030
        private bool EvCmdPokeListSetProc()
        {
            //Stub
            return true;
        }

        // RVA: 0x17661D0 Offset: 0x17662D1 VA: 0x17661D0
        private bool EvCmdNpcTradePokeListSetProc()
        {
            //Stub
            return true;
        }

        // RVA: 0x17661E0 Offset: 0x17662E1 VA: 0x17661E0
        private bool EvCmdUnionPokeListSetProc()
        {
            //Stub
            return true;
        }

        // RVA: 0x17661F0 Offset: 0x17662F1 VA: 0x17661F0
        private bool EvCmdPokeListGetResult()
        {
            //Stub
            return true;
        }

        // RVA: 0x1766260 Offset: 0x1766361 VA: 0x1766260
        private bool EvCmdConPokeListSetProc()
        {
            //Stub
            return true;
        }

        // RVA: 0x1766270 Offset: 0x1766371 VA: 0x1766270
        private bool EvCmdConPokeListGetResult()
        {
            //Stub
            return true;
        }

        // RVA: 0x1766280 Offset: 0x1766381 VA: 0x1766280
        private bool EvCmdConPokeStatusSetProc()
        {
            //Stub
            return true;
        }

        // RVA: 0x1766290 Offset: 0x1766391 VA: 0x1766290
        private bool EvCmdPokeStatusGetResult()
        {
            //Stub
            return true;
        }

        // RVA: 0x17662A0 Offset: 0x17663A1 VA: 0x17662A0
        private bool EvCmdWifiEarthSetProc()
        {
            //Stub
            return true;
        }

        // RVA: 0x1766470 Offset: 0x1766571 VA: 0x1766470
        private bool EvCmdEyeTrainerMoveSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x17665A0 Offset: 0x17666A1 VA: 0x17665A0
        private bool EvCmdEyeTrainerMoveCheck()
        {
            //Stub
            return true;
        }

        // RVA: 0x17665E0 Offset: 0x17666E1 VA: 0x17665E0
        private bool EvCmdEyeTrainerTypeGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x1766720 Offset: 0x1766821 VA: 0x1766720
        private bool EvCmdEyeTrainerIdGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x17667E0 Offset: 0x17668E1 VA: 0x17667E0
        private bool EvCmdNameIn()
        {
            //Stub
            return true;
        }

        // RVA: 0x17667F0 Offset: 0x17668F1 VA: 0x17667F0
        private bool EvCmdNameInPoke()
        {
            //Stub
            return true;
        }

        // RVA: 0x1766B80 Offset: 0x1766C81 VA: 0x1766B80
        private bool EvCmdWipeFadeStart()
        {
            //Stub
            return true;
        }

        // RVA: 0x1766B90 Offset: 0x1766C91 VA: 0x1766B90
        private bool EvCmdWipeFadeCheck()
        {
            //Stub
            return true;
        }

        // RVA: 0x1766BA0 Offset: 0x1766CA1 VA: 0x1766BA0
        private bool EvMacro_WHITE_OUT()
        {
            //Stub
            return true;
        }

        // RVA: 0x1766BE0 Offset: 0x1766CE1 VA: 0x1766BE0
        private bool EvMacro_WHITE_IN()
        {
            //Stub
            return true;
        }

        // RVA: 0x1766C20 Offset: 0x1766D21 VA: 0x1766C20
        private bool EvMacro_BLACK_OUT()
        {
            //Stub
            return true;
        }

        // RVA: 0x1766C60 Offset: 0x1766D61 VA: 0x1766C60
        private bool EvMacro_BLACK_IN()
        {
            //Stub
            return true;
        }

        // RVA: 0x1766CA0 Offset: 0x1766DA1 VA: 0x1766CA0
        private bool EvMacro_MAP_CHANGE()
        {
            //Stub
            return true;
        }

        // RVA: 0x1766CC0 Offset: 0x1766DC1 VA: 0x1766CC0
        private bool EvCmdMapChange()
        {
            //Stub
            return true;
        }

        // RVA: 0x1766CE0 Offset: 0x1766DE1 VA: 0x1766CE0
        private bool EvCmdColosseumMapChangeIn()
        {
            //Stub
            return true;
        }

        // RVA: 0x17670D0 Offset: 0x17671D1 VA: 0x17670D0
        private bool EvCmdColosseumMapChangeOut()
        {
            //Stub
            return true;
        }

        // RVA: 0x17670E0 Offset: 0x17671E1 VA: 0x17670E0
        private bool EvCmdGetBeforeZoneID()
        {
            //Stub
            return true;
        }

        // RVA: 0x17671F0 Offset: 0x17672F1 VA: 0x17671F0
        private bool EvCmdGetNowZoneID()
        {
            //Stub
            return true;
        }

        // RVA: 0x1767290 Offset: 0x1767391 VA: 0x1767290
        private bool EvCmdKabeNobori()
        {
            //Stub
            return true;
        }

        // RVA: 0x1767C10 Offset: 0x1767D11 VA: 0x1767C10
        private bool EvCmdNaminori()
        {
            //Stub
            return true;
        }

        // RVA: 0x1768050 Offset: 0x1768151 VA: 0x1768050
        private bool EvCmdBicycleCheck()
        {
            //Stub
            return true;
        }

        // RVA: 0x17680F0 Offset: 0x17681F1 VA: 0x17680F0
        private bool EvCmdBicycleReq()
        {
            //Stub
            return true;
        }

        // RVA: 0x1768740 Offset: 0x1768841 VA: 0x1768740
        private bool EvCmdBicycleReqNonBgm()
        {
            //Stub
            return true;
        }

        // RVA: 0x1768B20 Offset: 0x1768C21 VA: 0x1768B20
        private bool EvCmdCyclingRoadSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x1768B30 Offset: 0x1768C31 VA: 0x1768B30
        private bool EvCmdPlayerFormGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x1768B40 Offset: 0x1768C41 VA: 0x1768B40
        private bool EvCmdPlayerReqBitOn()
        {
            //Stub
            return true;
        }

        // RVA: 0x1768BC0 Offset: 0x1768CC1 VA: 0x1768BC0
        private bool EvCmdPlayerReqStart()
        {
            //Stub
            return true;
        }

        // RVA: 0x1768DE0 Offset: 0x1768EE1 VA: 0x1768DE0
        private bool EvCmdTakinobori()
        {
            //Stub
            return true;
        }

        // RVA: 0x17691C0 Offset: 0x17692C1 VA: 0x17691C0
        private bool EvCmdSorawotobu()
        {
            //Stub
            return true;
        }

        // RVA: 0x1769420 Offset: 0x1769521 VA: 0x1769420
        private bool EvCmdSorawotobuEnd()
        {
            //Stub
            return true;
        }

        // RVA: 0x17695F0 Offset: 0x17696F1 VA: 0x17695F0
        private bool EvCmdHidenFlash()
        {
            //Stub
            return true;
        }

        // RVA: 0x1769790 Offset: 0x1769891 VA: 0x1769790
        private bool EvCmd_DARKNESS_TEMPORARILY_OFF()
        {
            //Stub
            return true;
        }

        // RVA: 0x1769930 Offset: 0x1769A31 VA: 0x1769930
        private bool EvCmd_DARKNESS_TEMPORARILY_ON()
        {
            //Stub
            return true;
        }

        // RVA: 0x1769B40 Offset: 0x1769C41 VA: 0x1769B40
        private bool EvCmdHidenKiribarai()
        {
            //Stub
            return true;
        }

        // RVA: 0x1769CE0 Offset: 0x1769DE1 VA: 0x1769CE0
        private bool EvCmdCutIn()
        {
            //Stub
            return true;
        }

        // RVA: 0x176A6D0 Offset: 0x176A7D1 VA: 0x176A6D0
        private MonsNo GetHidenWazaMonsNo(WazaNo wazaNo)
        {
            //Stub
            return null;
        }

        // RVA: 0x176A5C0 Offset: 0x176A6C1 VA: 0x176A5C0
        private bool CheckHidenWazaForceResetForm(WazaNo wazaNo)
        {
            //Stub
            return true;
        }

        // RVA: 0x176A750 Offset: 0x176A851 VA: 0x176A750
        private bool EvCmdConHeroChange()
        {
            //Stub
            return true;
        }

        // RVA: 0x176A760 Offset: 0x176A861 VA: 0x176A760
        private bool EvCmdPlayerName()
        {
            //Stub
            return true;
        }

        // RVA: 0x176A830 Offset: 0x176A931 VA: 0x176A830
        private bool EvCmdRivalName()
        {
            //Stub
            return true;
        }

        // RVA: 0x176A900 Offset: 0x176AA01 VA: 0x176A900
        private bool EvCmdSupportName()
        {
            //Stub
            return true;
        }

        // RVA: 0x176A9D0 Offset: 0x176AAD1 VA: 0x176A9D0
        private bool EvCmdPokemonName()
        {
            //Stub
            return true;
        }

        // RVA: 0x176A9F0 Offset: 0x176AAF1 VA: 0x176A9F0
        private bool EvCmdItemName()
        {
            //Stub
            return true;
        }

        // RVA: 0x176AB80 Offset: 0x176AC81 VA: 0x176AB80
        private bool EvCmdPocketName()
        {
            //Stub
            return true;
        }

        // RVA: 0x176ACB0 Offset: 0x176ADB1 VA: 0x176ACB0
        private bool EvCmdItemWazaName()
        {
            //Stub
            return true;
        }

        // RVA: 0x176AE80 Offset: 0x176AF81 VA: 0x176AE80
        private bool EvCmdWazaName()
        {
            //Stub
            return true;
        }

        // RVA: 0x176AFB0 Offset: 0x176B0B1 VA: 0x176AFB0
        private bool EvCmdNumberName()
        {
            //Stub
            return true;
        }

        // RVA: 0x176B0E0 Offset: 0x176B1E1 VA: 0x176B0E0
        private bool EvCmdNumberNameEx()
        {
            //Stub
            return true;
        }

        // RVA: 0x176B370 Offset: 0x176B471 VA: 0x176B370
        private bool EvCmdSpeakersName()
        {
            //Stub
            return true;
        }

        // RVA: 0x176B500 Offset: 0x176B601 VA: 0x176B500
        private bool EvCmdContestCategoryName()
        {
            //Stub
            return true;
        }

        // RVA: 0x176B630 Offset: 0x176B731 VA: 0x176B630
        private bool EvCmdContestRankName()
        {
            //Stub
            return true;
        }

        // RVA: 0x176B760 Offset: 0x176B861 VA: 0x176B760
        private bool EvCmdPokeTypeName()
        {
            //Stub
            return true;
        }

        // RVA: 0x176B890 Offset: 0x176B991 VA: 0x176B890
        private bool EvCmdPofifinName()
        {
            //Stub
            return true;
        }

        // RVA: 0x176B9C0 Offset: 0x176BAC1 VA: 0x176B9C0
        private bool EvCmdDressName()
        {
            //Stub
            return true;
        }

        // RVA: 0x176BB90 Offset: 0x176BC91 VA: 0x176BB90
        private bool EvCmdBirthDayCheck()
        {
            //Stub
            return true;
        }

        // RVA: 0x176BD10 Offset: 0x176BE11 VA: 0x176BD10
        private bool EvCmdBirthMonthInput()
        {
            //Stub
            return true;
        }

        // RVA: 0x176BF40 Offset: 0x176C041 VA: 0x176BF40
        private bool EvCmdBirthDayInput()
        {
            //Stub
            return true;
        }

        // RVA: 0x176C180 Offset: 0x176C281 VA: 0x176C180
        private int DayNumInMonth(int month)
        {
            //Stub
            return 0;
        }

        // RVA: 0x176C3D0 Offset: 0x176C4D1 VA: 0x176C3D0
        private bool EvCmdAnoonSeeNum()
        {
            //Stub
            return true;
        }

        // RVA: 0x176C4D0 Offset: 0x176C5D1 VA: 0x176C4D0
        private bool EvCmdNickName()
        {
            //Stub
            return true;
        }

        // RVA: 0x176C5B0 Offset: 0x176C6B1 VA: 0x176C5B0
        private bool EvCmdPoketchName()
        {
            //Stub
            return true;
        }

        // RVA: 0x176C6E0 Offset: 0x176C7E1 VA: 0x176C6E0
        private bool EvCmdTrTypeName()
        {
            //Stub
            return true;
        }

        // RVA: 0x176C860 Offset: 0x176C961 VA: 0x176C860
        private bool EvCmdPartnerNameSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176C930 Offset: 0x176CA31 VA: 0x176C930
        private bool EvCmdMyTrTypeName()
        {
            //Stub
            return true;
        }

        // RVA: 0x176C940 Offset: 0x176CA41 VA: 0x176C940
        private bool EvCmdPokemonNameExtra()
        {
            //Stub
            return true;
        }

        // RVA: 0x176CA70 Offset: 0x176CB71 VA: 0x176CA70
        private bool EvCmdFirstPokemonName()
        {
            //Stub
            return true;
        }

        // RVA: 0x176CA90 Offset: 0x176CB91 VA: 0x176CA90
        private bool EvCmdRivalPokemonName()
        {
            //Stub
            return true;
        }

        // RVA: 0x176CAB0 Offset: 0x176CBB1 VA: 0x176CAB0
        private bool EvCmdSupportPokemonName()
        {
            //Stub
            return true;
        }

        // RVA: 0x176CAD0 Offset: 0x176CBD1 VA: 0x176CAD0
        private bool EvCmdFirstPokeNoGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176CB70 Offset: 0x176CC71 VA: 0x176CB70
        private bool EvCmdNutsName()
        {
            //Stub
            return true;
        }

        // RVA: 0x176CD00 Offset: 0x176CE01 VA: 0x176CD00
        private bool EvCmdSeikakuName()
        {
            //Stub
            return true;
        }

        // RVA: 0x176CE30 Offset: 0x176CF31 VA: 0x176CE30
        private bool EvCmdGoodsName()
        {
            //Stub
            return true;
        }

        // RVA: 0x176CE40 Offset: 0x176CF41 VA: 0x176CE40
        private bool EvCmdTrapName()
        {
            //Stub
            return true;
        }

        // RVA: 0x176CE50 Offset: 0x176CF51 VA: 0x176CE50
        private bool EvCmdTamaName()
        {
            //Stub
            return true;
        }

        // RVA: 0x176CE60 Offset: 0x176CF61 VA: 0x176CE60
        private bool EvCmdZoneName()
        {
            //Stub
            return true;
        }

        // RVA: 0x176CFC0 Offset: 0x176D0C1 VA: 0x176CFC0
        private bool EvCmdZoneName2()
        {
            //Stub
            return true;
        }

        // RVA: 0x176D120 Offset: 0x176D221 VA: 0x176D120
        private bool EvCmdZoneNameLabel()
        {
            //Stub
            return true;
        }

        // RVA: 0x176D2F0 Offset: 0x176D3F1 VA: 0x176D2F0
        private bool EvCmdGenerateInfoGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176D390 Offset: 0x176D491 VA: 0x176D390
        private bool EvCmdTrainerIdGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176D3E0 Offset: 0x176D4E1 VA: 0x176D3E0
        private bool EvCmdTrainerBattleSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176D400 Offset: 0x176D501 VA: 0x176D400
        private bool EvCmdTrainerMultiBattleSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176D420 Offset: 0x176D521 VA: 0x176D420
        private bool EvCmdTrainerMessageSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176D460 Offset: 0x176D561 VA: 0x176D460
        private bool EvCmdTrainerTalkTypeGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176D4B0 Offset: 0x176D5B1 VA: 0x176D4B0
        private bool EvCmdRevengeTrainerTalkTypeGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176D500 Offset: 0x176D601 VA: 0x176D500
        private bool EvCmdTrainerTypeGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176D510 Offset: 0x176D611 VA: 0x176D510
        private bool EvCmdTrainerBgmSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176D530 Offset: 0x176D631 VA: 0x176D530
        private bool EvCmdTrainerLose()
        {
            //Stub
            return true;
        }

        // RVA: 0x176D540 Offset: 0x176D641 VA: 0x176D540
        private bool EvCmdTrainerLoseCheck()
        {
            //Stub
            return true;
        }

        // RVA: 0x176D550 Offset: 0x176D651 VA: 0x176D550
        private bool EvCmdNormalLose()
        {
            //Stub
            return true;
        }

        // RVA: 0x176D560 Offset: 0x176D661 VA: 0x176D560
        private bool EvCmdNormalLoseCheck()
        {
            //Stub
            return true;
        }

        // RVA: 0x176D570 Offset: 0x176D671 VA: 0x176D570
        private bool EvCmdSeacretPokeRetryCheck()
        {
            //Stub
            return true;
        }

        // RVA: 0x176D770 Offset: 0x176D871 VA: 0x176D770
        private bool EvCmdHaifuPokeRetryCheck()
        {
            //Stub
            return true;
        }

        // RVA: 0x176D780 Offset: 0x176D881 VA: 0x176D780
        private bool EvCmd2vs2BattleCheck()
        {
            //Stub
            return true;
        }

        // RVA: 0x176D960 Offset: 0x176DA61 VA: 0x176D960
        private bool EvCmdDebugBattleSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176D970 Offset: 0x176DA71 VA: 0x176D970
        private bool EvCmdDebugTrainerFlagSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176D980 Offset: 0x176DA81 VA: 0x176D980
        private bool EvCmdDebugTrainerFlagOnJump()
        {
            //Stub
            return true;
        }

        // RVA: 0x176D990 Offset: 0x176DA91 VA: 0x176D990
        private bool EvMacro_DEBUG_TR_TALK_BTL()
        {
            //Stub
            return true;
        }

        // RVA: 0x176D9A0 Offset: 0x176DAA1 VA: 0x176D9A0
        private bool EvCmdConnectSelParentWin()
        {
            //Stub
            return true;
        }

        // RVA: 0x176D9B0 Offset: 0x176DAB1 VA: 0x176D9B0
        private bool EvCmdConnectSelChildWin()
        {
            //Stub
            return true;
        }

        // RVA: 0x176D9C0 Offset: 0x176DAC1 VA: 0x176D9C0
        private bool EvCmdConnectDebugParentWin()
        {
            //Stub
            return true;
        }

        // RVA: 0x176D9D0 Offset: 0x176DAD1 VA: 0x176D9D0
        private bool EvCmdConnectDebugChildWin()
        {
            //Stub
            return true;
        }

        // RVA: 0x176D9E0 Offset: 0x176DAE1 VA: 0x176D9E0
        private bool EvCmdDebugSioEncount()
        {
            //Stub
            return true;
        }

        // RVA: 0x176D9F0 Offset: 0x176DAF1 VA: 0x176D9F0
        private bool EvCmdDebugSioContest()
        {
            //Stub
            return true;
        }

        // RVA: 0x176DA00 Offset: 0x176DB01 VA: 0x176DA00
        private bool EvCmdConSioTimingSend()
        {
            //Stub
            return true;
        }

        // RVA: 0x176DA10 Offset: 0x176DB11 VA: 0x176DA10
        private bool EvCmdConSioTimingCheck()
        {
            //Stub
            return true;
        }

        // RVA: 0x176DA20 Offset: 0x176DB21 VA: 0x176DA20
        private bool EvCmdConSystemCreate()
        {
            //Stub
            return true;
        }

        // RVA: 0x176DA30 Offset: 0x176DB31 VA: 0x176DA30
        private bool EvCmdConSystemExit()
        {
            //Stub
            return true;
        }

        // RVA: 0x176DA40 Offset: 0x176DB41 VA: 0x176DA40
        private bool EvCmdConJudgeNameGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176DA50 Offset: 0x176DB51 VA: 0x176DA50
        private bool EvCmdConBreederNameGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176DA60 Offset: 0x176DB61 VA: 0x176DA60
        private bool EvCmdConNickNameGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176DA70 Offset: 0x176DB71 VA: 0x176DA70
        private bool EvCmdConNumTagSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176DA80 Offset: 0x176DB81 VA: 0x176DA80
        private bool EvCmdConSioParamInitSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176DA90 Offset: 0x176DB91 VA: 0x176DA90
        private bool EvCmdContestProc()
        {
            //Stub
            return true;
        }

        // RVA: 0x176DCC0 Offset: 0x176DDC1 VA: 0x176DCC0
        private bool EvCmdConRankNameGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176DCD0 Offset: 0x176DDD1 VA: 0x176DCD0
        private bool EvCmdConTypeNameGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176DCE0 Offset: 0x176DDE1 VA: 0x176DCE0
        private bool EvCmdConVictoryBreederNameGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176DCF0 Offset: 0x176DDF1 VA: 0x176DCF0
        private bool EvCmdConVictoryItemNoGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176DD00 Offset: 0x176DE01 VA: 0x176DD00
        private bool EvCmdConVictoryNickNameGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176DD10 Offset: 0x176DE11 VA: 0x176DD10
        private bool EvCmdConRankingCheck()
        {
            //Stub
            return true;
        }

        // RVA: 0x176DD20 Offset: 0x176DE21 VA: 0x176DD20
        private bool EvCmdConVictoryEntryNoGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176DD30 Offset: 0x176DE31 VA: 0x176DD30
        private bool EvCmdConMyEntryNoGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176DD40 Offset: 0x176DE41 VA: 0x176DD40
        private bool EvCmdConObjCodeGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176DD50 Offset: 0x176DE51 VA: 0x176DD50
        private bool EvCmdConPopularityGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176DD60 Offset: 0x176DE61 VA: 0x176DD60
        private bool EvCmdConDeskModeGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176DD70 Offset: 0x176DE71 VA: 0x176DD70
        private bool EvCmdConHaveRibbonCheck()
        {
            //Stub
            return true;
        }

        // RVA: 0x176DDD0 Offset: 0x176DED1 VA: 0x176DDD0
        private bool EvCmdConRibbonNameGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176DDE0 Offset: 0x176DEE1 VA: 0x176DDE0
        private bool EvCmdConAcceNoGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176DDF0 Offset: 0x176DEF1 VA: 0x176DDF0
        private bool EvCmdConEntryParamGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176DE00 Offset: 0x176DF01 VA: 0x176DE00
        private bool EvCmdConCameraFlashSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176DE10 Offset: 0x176DF11 VA: 0x176DE10
        private bool EvCmdConCameraFlashCheck()
        {
            //Stub
            return true;
        }

        // RVA: 0x176DE20 Offset: 0x176DF21 VA: 0x176DE20
        private bool EvCmdConHBlankStop()
        {
            //Stub
            return true;
        }

        // RVA: 0x176DE30 Offset: 0x176DF31 VA: 0x176DE30
        private bool EvCmdConHBlankStart()
        {
            //Stub
            return true;
        }

        // RVA: 0x176DE40 Offset: 0x176DF41 VA: 0x176DE40
        private bool EvCmdConEndingSkipCheck()
        {
            //Stub
            return true;
        }

        // RVA: 0x176DE50 Offset: 0x176DF51 VA: 0x176DE50
        private bool EvCmdConRecordDisp()
        {
            //Stub
            return true;
        }

        // RVA: 0x176DF90 Offset: 0x176E091 VA: 0x176DF90
        private bool EvCmdConMsgPrintFlagSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176DFA0 Offset: 0x176E0A1 VA: 0x176DFA0
        private bool EvCmdConMsgPrintFlagReset()
        {
            //Stub
            return true;
        }

        // RVA: 0x176DFB0 Offset: 0x176E0B1 VA: 0x176DFB0
        private bool EvCmdSpLocationSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176DFC0 Offset: 0x176E0C1 VA: 0x176DFC0
        private bool EvCmdElevatorNowFloorGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176DFD0 Offset: 0x176E0D1 VA: 0x176DFD0
        private bool EvCmdElevatorFloorWrite()
        {
            //Stub
            return true;
        }

        // RVA: 0x176DFE0 Offset: 0x176E0E1 VA: 0x176DFE0
        private bool EvCmdGetShinouZukanSeeNum()
        {
            //Stub
            return true;
        }

        // RVA: 0x176E080 Offset: 0x176E181 VA: 0x176E080
        private bool EvCmdGetShinouZukanGetNum()
        {
            //Stub
            return true;
        }

        // RVA: 0x176E120 Offset: 0x176E221 VA: 0x176E120
        private bool EvCmdGetZenkokuZukanSeeNum()
        {
            //Stub
            return true;
        }

        // RVA: 0x176E1C0 Offset: 0x176E2C1 VA: 0x176E1C0
        private bool EvCmdGetZenkokuZukanGetNum()
        {
            //Stub
            return true;
        }

        // RVA: 0x176E260 Offset: 0x176E361 VA: 0x176E260
        private bool EvCmdChkZenkokuZukan()
        {
            //Stub
            return true;
        }

        // RVA: 0x176E270 Offset: 0x176E371 VA: 0x176E270
        private bool EvCmdGetZukanHyoukaMsgID()
        {
            //Stub
            return true;
        }

        // RVA: 0x176E280 Offset: 0x176E381 VA: 0x176E280
        private bool EvCmdWildBattleSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176E450 Offset: 0x176E551 VA: 0x176E450
        private bool EvCmdSpWildBattleSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176E770 Offset: 0x176E871 VA: 0x176E770
        private bool EvCmdFirstBattleSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176E9B0 Offset: 0x176EAB1 VA: 0x176E9B0
        private bool EvCmdCaptureBattleSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176EAC0 Offset: 0x176EBC1 VA: 0x176EAC0
        private bool EvCmdHoneyTree()
        {
            //Stub
            return true;
        }

        // RVA: 0x176EB90 Offset: 0x176EC91 VA: 0x176EB90
        private bool EvCmdGetHoneyTreeState()
        {
            //Stub
            return true;
        }

        // RVA: 0x176ECE0 Offset: 0x176EDE1 VA: 0x176ECE0
        private bool EvCmdHoneyTreeBattleSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176EF50 Offset: 0x176F051 VA: 0x176EF50
        private bool EvCmdHoneyAfterTreeBattleSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176EF60 Offset: 0x176F061 VA: 0x176EF60
        private bool EvCmdTSignSetProc()
        {
            //Stub
            return true;
        }

        // RVA: 0x176EF70 Offset: 0x176F071 VA: 0x176EF70
        private bool EvCmdReportSaveCheck()
        {
            //Stub
            return true;
        }

        // RVA: 0x176EF80 Offset: 0x176F081 VA: 0x176EF80
        private bool EvCmdReportSave()
        {
            //Stub
            return true;
        }

        // RVA: 0x176F080 Offset: 0x176F181 VA: 0x176F080
        private IEnumerator<int> evReportSaveCoroutine()
        {
            //Stub
            return null;
        }

        // RVA: 0x176F100 Offset: 0x176F201 VA: 0x176F100
        private bool EvCmdReportInfoWinOpen()
        {
            //Stub
            return true;
        }

        // RVA: 0x176F110 Offset: 0x176F211 VA: 0x176F110
        private bool EvCmdReportInfoWinClose()
        {
            //Stub
            return true;
        }

        // RVA: 0x176F120 Offset: 0x176F221 VA: 0x176F120
        private bool EvCmdImageClipTvSaveDataCheck()
        {
            //Stub
            return true;
        }

        // RVA: 0x176F130 Offset: 0x176F231 VA: 0x176F130
        private bool EvCmdImageClipConSaveDataCheck()
        {
            //Stub
            return true;
        }

        // RVA: 0x176F140 Offset: 0x176F241 VA: 0x176F140
        private bool EvCmdImageClipTvSaveTitle()
        {
            //Stub
            return true;
        }

        // RVA: 0x176F150 Offset: 0x176F251 VA: 0x176F150
        private bool EvCmdGetPoketch()
        {
            //Stub
            return true;
        }

        // RVA: 0x176F180 Offset: 0x176F281 VA: 0x176F180
        private bool EvCmdGetPoketchFlag()
        {
            //Stub
            return true;
        }

        // RVA: 0x176F1E0 Offset: 0x176F2E1 VA: 0x176F1E0
        private bool EvCmdPoketchAppAdd()
        {
            //Stub
            return true;
        }

        // RVA: 0x176F2B0 Offset: 0x176F3B1 VA: 0x176F2B0
        private bool EvCmdPoketchAppCheck()
        {
            //Stub
            return true;
        }

        // RVA: 0x176F3A0 Offset: 0x176F4A1 VA: 0x176F3A0
        private bool EvCmdCommTimingSyncStart()
        {
            //Stub
            return true;
        }

        // RVA: 0x176F3B0 Offset: 0x176F4B1 VA: 0x176F3B0
        private bool EvCmdCommTempDataReset()
        {
            //Stub
            return true;
        }

        // RVA: 0x176F3C0 Offset: 0x176F4C1 VA: 0x176F3C0
        private bool EvCmdUnionProc()
        {
            //Stub
            return true;
        }

        // RVA: 0x176F780 Offset: 0x176F881 VA: 0x176F780
        private bool EvCmdUnionParentCardTalkNo()
        {
            //Stub
            return true;
        }

        // RVA: 0x176F790 Offset: 0x176F891 VA: 0x176F790
        private bool EvCmdUnionGetInfoTalkNo()
        {
            //Stub
            return true;
        }

        // RVA: 0x176F7A0 Offset: 0x176F8A1 VA: 0x176F7A0
        private bool EvCmdUnionBeaconChange()
        {
            //Stub
            return true;
        }

        // RVA: 0x176F7B0 Offset: 0x176F8B1 VA: 0x176F7B0
        private bool EvCmdUnionConnectTalkDenied()
        {
            //Stub
            return true;
        }

        // RVA: 0x176F7C0 Offset: 0x176F8C1 VA: 0x176F7C0
        private bool EvCmdUnionConnectTalkOk()
        {
            //Stub
            return true;
        }

        // RVA: 0x176F7D0 Offset: 0x176F8D1 VA: 0x176F7D0
        private bool EvCmdUnionTrainerNameRegist()
        {
            //Stub
            return true;
        }

        // RVA: 0x176F7E0 Offset: 0x176F8E1 VA: 0x176F7E0
        private bool EvCmdUnionReturnSetUp()
        {
            //Stub
            return true;
        }

        // RVA: 0x176F7F0 Offset: 0x176F8F1 VA: 0x176F7F0
        private bool EvCmdUnionConnectCutRestart()
        {
            //Stub
            return true;
        }

        // RVA: 0x176F800 Offset: 0x176F901 VA: 0x176F800
        private bool EvCmdUnionGetTalkNumber()
        {
            //Stub
            return true;
        }

        // RVA: 0x176F810 Offset: 0x176F911 VA: 0x176F810
        private bool EvCmdUnionIdSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176F820 Offset: 0x176F921 VA: 0x176F820
        private bool EvCmdUnionResultGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176F830 Offset: 0x176F931 VA: 0x176F830
        private bool EvCmdUnionObjAllVanish()
        {
            //Stub
            return true;
        }

        // RVA: 0x176F840 Offset: 0x176F941 VA: 0x176F840
        private bool EvCmdUnionScriptResultSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176F850 Offset: 0x176F951 VA: 0x176F850
        private bool EvCmdUnionParentStartCommandSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176F860 Offset: 0x176F961 VA: 0x176F860
        private bool EvCmdUnionChildSelectCommandSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176F870 Offset: 0x176F971 VA: 0x176F870
        private bool EvCmdUnionConnectStart()
        {
            //Stub
            return true;
        }

        // RVA: 0x176F880 Offset: 0x176F981 VA: 0x176F880
        private bool EvCmdUnionMapChange()
        {
            //Stub
            return true;
        }

        // RVA: 0x176F890 Offset: 0x176F991 VA: 0x176F890
        private bool EvCmdUnionViewSetUpTrainerTypeSelect()
        {
            //Stub
            return true;
        }

        // RVA: 0x176F8A0 Offset: 0x176F9A1 VA: 0x176F8A0
        private bool EvCmdUnionViewGetTrainerType()
        {
            //Stub
            return true;
        }

        // RVA: 0x176F8B0 Offset: 0x176F9B1 VA: 0x176F8B0
        private bool EvCmdUnionViewGetTrainerTypeNo()
        {
            //Stub
            return true;
        }

        // RVA: 0x176F8C0 Offset: 0x176F9C1 VA: 0x176F8C0
        private bool EvCmdUnionViewMyStatusSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176F8D0 Offset: 0x176F9D1 VA: 0x176F8D0
        private bool EvCmdSysFlagZukanGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176F930 Offset: 0x176FA31 VA: 0x176F930
        private bool EvCmdSysFlagZukanSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176F9B0 Offset: 0x176FAB1 VA: 0x176F9B0
        private bool EvCmdSysFlagShoesGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176FA10 Offset: 0x176FB11 VA: 0x176FA10
        private bool EvCmdSysFlagShoesSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176FB00 Offset: 0x176FC01 VA: 0x176FB00
        private bool EvCmdSysFlagBadgeGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176FB60 Offset: 0x176FC61 VA: 0x176FB60
        private bool EvCmdSysFlagBadgeSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176FBA0 Offset: 0x176FCA1 VA: 0x176FBA0
        private bool EvCmdSysFlagBadgeCount()
        {
            //Stub
            return true;
        }

        // RVA: 0x176FCA0 Offset: 0x176FDA1 VA: 0x176FCA0
        private bool EvCmdSysFlagBagGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176FD00 Offset: 0x176FE01 VA: 0x176FD00
        private bool EvCmdSysFlagBagSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176FD30 Offset: 0x176FE31 VA: 0x176FD30
        private bool EvCmdSysFlagPairGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176FD90 Offset: 0x176FE91 VA: 0x176FD90
        private bool EvCmdSysFlagPairSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176FDC0 Offset: 0x176FEC1 VA: 0x176FDC0
        private bool EvCmdSysFlagPairReset()
        {
            //Stub
            return true;
        }

        // RVA: 0x176FE70 Offset: 0x176FF71 VA: 0x176FE70
        private bool EvCmdSysFlagOneStepGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176FF00 Offset: 0x1770001 VA: 0x176FF00
        private bool EvCmdSysFlagOneStepSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176FF30 Offset: 0x1770031 VA: 0x176FF30
        private bool EvCmdSysFlagOneStepReset()
        {
            //Stub
            return true;
        }

        // RVA: 0x176FF60 Offset: 0x1770061 VA: 0x176FF60
        private bool EvCmdSysFlagGameClearGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176FFC0 Offset: 0x17700C1 VA: 0x176FFC0
        private bool EvCmdSysFlagGameClearSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x176FFF0 Offset: 0x17700F1 VA: 0x176FFF0
        private bool EvCmdSysFlagKairikiSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x1770020 Offset: 0x1770121 VA: 0x1770020
        private bool EvCmdSysFlagKairikiReset()
        {
            //Stub
            return true;
        }

        // RVA: 0x1770050 Offset: 0x1770151 VA: 0x1770050
        private bool EvCmdSysFlagKairikiGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x17700B0 Offset: 0x17701B1 VA: 0x17700B0
        private bool EvCmdSysFlagFlashSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x1770180 Offset: 0x1770281 VA: 0x1770180
        private bool EvCmdSysFlagFlashReset()
        {
            //Stub
            return true;
        }

        // RVA: 0x1770250 Offset: 0x1770351 VA: 0x1770250
        private bool EvCmdSysFlagFlashGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x1770360 Offset: 0x1770461 VA: 0x1770360
        private bool EvCmdSysFlagKiribaraiSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x17703D0 Offset: 0x17704D1 VA: 0x17703D0
        private bool EvCmdSysFlagKiribaraiReset()
        {
            //Stub
            return true;
        }

        // RVA: 0x1770440 Offset: 0x1770541 VA: 0x1770440
        private bool EvCmdSysFlagKiribaraiGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x17704E0 Offset: 0x17705E1 VA: 0x17704E0
        private bool EvCmdShopCall()
        {
            //Stub
            return true;
        }

        // RVA: 0x17704F0 Offset: 0x17705F1 VA: 0x17704F0
        private bool EvCmdFixShopCall()
        {
            //Stub
            return true;
        }

        // RVA: 0x1770500 Offset: 0x1770601 VA: 0x1770500
        private bool EvCmdFixGoodsCall()
        {
            //Stub
            return true;
        }

        // RVA: 0x1770510 Offset: 0x1770611 VA: 0x1770510
        private bool EvCmdFixSealCall()
        {
            //Stub
            return true;
        }

        // RVA: 0x1770520 Offset: 0x1770621 VA: 0x1770520
        private bool EvCmdAcceShopCall()
        {
            //Stub
            return true;
        }

        // RVA: 0x1770530 Offset: 0x1770631 VA: 0x1770530
        private bool EvCmdReportDrawProcSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x1770540 Offset: 0x1770641 VA: 0x1770540
        private bool EvCmdReportDrawProcDel()
        {
            //Stub
            return true;
        }

        // RVA: 0x1770550 Offset: 0x1770651 VA: 0x1770550
        private bool EvCmdGameOverCall()
        {
            //Stub
            return true;
        }

        // RVA: 0x1770560 Offset: 0x1770661 VA: 0x1770560
        private bool EvCmdSetWarpId()
        {
            //Stub
            return true;
        }

        // RVA: 0x17706A0 Offset: 0x17707A1 VA: 0x17706A0
        private bool EvCmd_SET_TELEPORT_ID()
        {
            //Stub
            return true;
        }

        // RVA: 0x1770840 Offset: 0x1770941 VA: 0x1770840
        private bool EvCmdGetMySex()
        {
            //Stub
            return true;
        }

        // RVA: 0x17708E0 Offset: 0x17709E1 VA: 0x17708E0
        private bool EvCmdPcKaifuku()
        {
            //Stub
            return true;
        }

        // RVA: 0x1770960 Offset: 0x1770A61 VA: 0x1770960
        private bool EvCmdUgManShopNpcRandomPlace()
        {
            //Stub
            return true;
        }

        // RVA: 0x1770970 Offset: 0x1770A71 VA: 0x1770970
        private bool EvCmdCommDirectEnd()
        {
            //Stub
            return true;
        }

        // RVA: 0x1770980 Offset: 0x1770A81 VA: 0x1770980
        private bool EvCmdCommDirectEndTiming()
        {
            //Stub
            return true;
        }

        // RVA: 0x1770990 Offset: 0x1770A91 VA: 0x1770990
        private bool EvCmdCommDirectEnterBtlRoom()
        {
            //Stub
            return true;
        }

        // RVA: 0x17709A0 Offset: 0x1770AA1 VA: 0x17709A0
        private bool EvCmdCommPlayerSetDir()
        {
            //Stub
            return true;
        }

        // RVA: 0x17709B0 Offset: 0x1770AB1 VA: 0x17709B0
        private bool EvCmdSetUpDoorAnime()
        {
            //Stub
            return true;
        }

        // RVA: 0x17709C0 Offset: 0x1770AC1 VA: 0x17709C0
        private bool EvCmdWait3DAnime()
        {
            //Stub
            return true;
        }

        // RVA: 0x1770A50 Offset: 0x1770B51 VA: 0x1770A50
        private bool EvCmdFree3DAnime()
        {
            //Stub
            return true;
        }

        // RVA: 0x1770A80 Offset: 0x1770B81 VA: 0x1770A80
        private bool EvCmdOpenDoor()
        {
            //Stub
            return true;
        }

        // RVA: 0x1770B10 Offset: 0x1770C11 VA: 0x1770B10
        private bool EvCmdCloseDoor()
        {
            //Stub
            return true;
        }

        // RVA: 0x1770BA0 Offset: 0x1770CA1 VA: 0x1770BA0
        private bool EvCmdPMSInputSingleProc()
        {
            //Stub
            return true;
        }

        // RVA: 0x1770BB0 Offset: 0x1770CB1 VA: 0x1770BB0
        private bool EvCmdPMSInputDoubleProc()
        {
            //Stub
            return true;
        }

        // RVA: 0x1770BC0 Offset: 0x1770CC1 VA: 0x1770BC0
        private bool EvCmdPMSBuf()
        {
            //Stub
            return true;
        }

        // RVA: 0x1770BD0 Offset: 0x1770CD1 VA: 0x1770BD0
        private FieldKinomiGrowEntity GetCurrentKinomiGrowEntity()
        {
            //Stub
            return null;
        }

        // RVA: 0x1770D20 Offset: 0x1770E21 VA: 0x1770D20
        private int GetCurrentKinomiGrowId()
        {
            //Stub
            return 0;
        }

        // RVA: 0x1770DC0 Offset: 0x1770EC1 VA: 0x1770DC0
        private bool EvCmdSeedGetStatus()
        {
            //Stub
            return true;
        }

        // RVA: 0x1770EA0 Offset: 0x1770FA1 VA: 0x1770EA0
        private bool EvCmdSeedGetType()
        {
            //Stub
            return true;
        }

        // RVA: 0x1770FC0 Offset: 0x17710C1 VA: 0x1770FC0
        private bool EvCmdSeedGetCompost()
        {
            //Stub
            return true;
        }

        // RVA: 0x1770FD0 Offset: 0x17710D1 VA: 0x1770FD0
        private bool EvCmdSeedGetGroundStatus()
        {
            //Stub
            return true;
        }

        // RVA: 0x1770FE0 Offset: 0x17710E1 VA: 0x1770FE0
        private bool EvCmdSeedGetNutsCount()
        {
            //Stub
            return true;
        }

        // RVA: 0x17710C0 Offset: 0x17711C1 VA: 0x17710C0
        private bool EvCmdSeedSetCompost()
        {
            //Stub
            return true;
        }

        // RVA: 0x17710D0 Offset: 0x17711D1 VA: 0x17710D0
        private bool EvCmdSeedSetNuts()
        {
            //Stub
            return true;
        }

        // RVA: 0x17711F0 Offset: 0x17712F1 VA: 0x17711F0
        private bool EvCmdSeedSetWater()
        {
            //Stub
            return true;
        }

        // RVA: 0x17718F0 Offset: 0x17719F1 VA: 0x17718F0
        private bool EvCmdSeedTakeNuts()
        {
            //Stub
            return true;
        }

        // RVA: 0x17719B0 Offset: 0x1771AB1 VA: 0x17719B0
        private bool EvCmdSxyPosChange()
        {
            //Stub
            return true;
        }

        // RVA: 0x1771BB0 Offset: 0x1771CB1 VA: 0x1771BB0
        private bool EvCmdObjPosChange()
        {
            //Stub
            return true;
        }

        // RVA: 0x1771EF0 Offset: 0x1771FF1 VA: 0x1771EF0
        private bool EvCmd_OBJ_POS_CHANGE_WORLD()
        {
            //Stub
            return true;
        }

        // RVA: 0x1772150 Offset: 0x1772251 VA: 0x1772150
        private bool EvCmd_OBJ_DIR_CHANGE_WORLD()
        {
            //Stub
            return true;
        }

        // RVA: 0x17723D0 Offset: 0x17724D1 VA: 0x17723D0
        private bool EvCmd_OBJ_POS_CHANGE_WORLD_FIND()
        {
            //Stub
            return true;
        }

        // RVA: 0x1772650 Offset: 0x1772751 VA: 0x1772650
        private bool EvCmdSxyMoveCodeChange()
        {
            //Stub
            return true;
        }

        // RVA: 0x17727F0 Offset: 0x17728F1 VA: 0x17727F0
        private bool EvCmdSxyDirChange()
        {
            //Stub
            return true;
        }

        // RVA: 0x1772950 Offset: 0x1772A51 VA: 0x1772950
        private bool EvCmdSxyExitPosChange()
        {
            //Stub
            return true;
        }

        // RVA: 0x1772970 Offset: 0x1772A71 VA: 0x1772970
        private bool EvCmdSxyBgPosChange()
        {
            //Stub
            return true;
        }

        // RVA: 0x1772980 Offset: 0x1772A81 VA: 0x1772980
        private bool EvCmdObjDirChange()
        {
            //Stub
            return true;
        }

        // RVA: 0x17729A0 Offset: 0x1772AA1 VA: 0x17729A0
        private bool EvCmdReturnScriptWkSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x1772A20 Offset: 0x1772B21 VA: 0x1772A20
        private bool EvCmdMsgExpandBuf()
        {
            //Stub
            return true;
        }

        // RVA: 0x1772A30 Offset: 0x1772B31 VA: 0x1772A30
        private bool EvCmdGetSodateyaName()
        {
            //Stub
            return true;
        }

        // RVA: 0x1772A40 Offset: 0x1772B41 VA: 0x1772A40
        private bool EvCmdGetSodateyaZiisan()
        {
            //Stub
            return true;
        }

        // RVA: 0x1772B40 Offset: 0x1772C41 VA: 0x1772B40
        private bool EvCmdInitWaterGym()
        {
            //Stub
            return true;
        }

        // RVA: 0x1772B50 Offset: 0x1772C51 VA: 0x1772B50
        private bool EvCmdPushWaterGymButton()
        {
            //Stub
            return true;
        }

        // RVA: 0x1773150 Offset: 0x1773251 VA: 0x1773150
        private bool EvCmdInitGhostGym()
        {
            //Stub
            return true;
        }

        // RVA: 0x17732E0 Offset: 0x17733E1 VA: 0x17732E0
        private bool EvCmdMoveGhostGymLift()
        {
            //Stub
            return true;
        }

        // RVA: 0x1773C30 Offset: 0x1773D31 VA: 0x1773C30
        private bool EvCmdInitSteelGym()
        {
            //Stub
            return true;
        }

        // RVA: 0x1773C40 Offset: 0x1773D41 VA: 0x1773C40
        private bool EvCmdInitCombatGym()
        {
            //Stub
            return true;
        }

        // RVA: 0x1773D60 Offset: 0x1773E61 VA: 0x1773D60
        private bool EvCmdInitElecGym()
        {
            //Stub
            return true;
        }

        // RVA: 0x1773D70 Offset: 0x1773E71 VA: 0x1773D70
        private bool EvCmdRotElecGymGear()
        {
            //Stub
            return true;
        }

        // RVA: 0x17742B0 Offset: 0x17743B1 VA: 0x17742B0
        private bool EvCmdGetPokeCount()
        {
            //Stub
            return true;
        }

        // RVA: 0x1774350 Offset: 0x1774451 VA: 0x1774350
        private bool EvCmdGetPokeCount2()
        {
            //Stub
            return true;
        }

        // RVA: 0x1774460 Offset: 0x1774561 VA: 0x1774460
        private bool EvCmdGetPokeCount3()
        {
            //Stub
            return true;
        }

        // RVA: 0x17745A0 Offset: 0x17746A1 VA: 0x17745A0
        private bool EvCmdGetPokeCount4()
        {
            //Stub
            return true;
        }

        // RVA: 0x1774800 Offset: 0x1774901 VA: 0x1774800
        private bool EvCmdGetPokeCount5()
        {
            //Stub
            return true;
        }

        // RVA: 0x17749A0 Offset: 0x1774AA1 VA: 0x17749A0
        private bool EvCmdGetTamagoCount()
        {
            //Stub
            return true;
        }

        // RVA: 0x17749B0 Offset: 0x1774AB1 VA: 0x17749B0
        private bool EvCmdUgShopMenuInit()
        {
            //Stub
            return true;
        }

        // RVA: 0x1774D30 Offset: 0x1774E31 VA: 0x1774D30
        private DayOfWeek GetShopUgWeek()
        {
            //Stub
            return DayOfWeek.Sunday;
        }

        // RVA: 0x1774DB0 Offset: 0x1774EB1 VA: 0x1774DB0
        private bool EvCmdUgLevaeHyouta()
        {
            //Stub
            return true;
        }

        // RVA: 0x1775100 Offset: 0x1775201 VA: 0x1775100
        private bool EvCmdAGAnimationHyouta()
        {
            //Stub
            return true;
        }

        // RVA: 0x1775450 Offset: 0x1775551 VA: 0x1775450
        private bool EvCmdUgShopTalkStart()
        {
            //Stub
            return true;
        }

        // RVA: 0x1775460 Offset: 0x1775561 VA: 0x1775460
        private bool EvCmdUgShopTalkEnd()
        {
            //Stub
            return true;
        }

        // RVA: 0x1775470 Offset: 0x1775571 VA: 0x1775470
        private bool EvCmdUgShopTalkRegisterItemName()
        {
            //Stub
            return true;
        }

        // RVA: 0x1775480 Offset: 0x1775581 VA: 0x1775480
        private bool EvCmdUgShopTalkRegisterTrapName()
        {
            //Stub
            return true;
        }

        // RVA: 0x1775490 Offset: 0x1775591 VA: 0x1775490
        private bool EvCmdDelSodateyaEgg()
        {
            //Stub
            return true;
        }

        // RVA: 0x17754A0 Offset: 0x17755A1 VA: 0x17754A0
        private bool EvCmdGetSodateyaEgg()
        {
            //Stub
            return true;
        }

        // RVA: 0x17754B0 Offset: 0x17755B1 VA: 0x17754B0
        private bool EvCmdMsgSodateyaAishou()
        {
            //Stub
            return true;
        }

        // RVA: 0x17754C0 Offset: 0x17755C1 VA: 0x17754C0
        private bool EvCmdMsgAzukeSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x17754D0 Offset: 0x17755D1 VA: 0x17754D0
        private bool EvCmdSetSodateyaPoke()
        {
            //Stub
            return true;
        }

        // RVA: 0x17754E0 Offset: 0x17755E1 VA: 0x17754E0
        private bool EvCmdSodateyaPokeList()
        {
            //Stub
            return true;
        }

        // RVA: 0x17754F0 Offset: 0x17755F1 VA: 0x17754F0
        private bool EvCmdHikitoriList()
        {
            //Stub
            return true;
        }

        // RVA: 0x1775500 Offset: 0x1775601 VA: 0x1775500
        private bool EvCmdSodatePokeLevelStr()
        {
            //Stub
            return true;
        }

        // RVA: 0x1775510 Offset: 0x1775611 VA: 0x1775510
        private bool EvCmdHikitoriRyoukin()
        {
            //Stub
            return true;
        }

        // RVA: 0x1775520 Offset: 0x1775621 VA: 0x1775520
        private bool EvCmdHikitoriPoke()
        {
            //Stub
            return true;
        }

        // RVA: 0x1775530 Offset: 0x1775631 VA: 0x1775530
        private bool EvCmdTamagoDemo()
        {
            //Stub
            return true;
        }

        // RVA: 0x17757D0 Offset: 0x17758D1 VA: 0x17757D0
        private bool EvCmdTemotiMonsNo()
        {
            //Stub
            return true;
        }

        // RVA: 0x1775910 Offset: 0x1775A11 VA: 0x1775910
        private bool EvCmdMonsOwnChk()
        {
            //Stub
            return true;
        }

        // RVA: 0x1775A50 Offset: 0x1775B51 VA: 0x1775A50
        private bool EvCmdChkTemotiPokerus()
        {
            //Stub
            return true;
        }

        // RVA: 0x1775B00 Offset: 0x1775C01 VA: 0x1775B00
        private bool EvCmdTemotiPokeSexGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x1775B10 Offset: 0x1775C11 VA: 0x1775B10
        private bool EvCmdSubMyGold()
        {
            //Stub
            return true;
        }

        // RVA: 0x1775B80 Offset: 0x1775C81 VA: 0x1775B80
        private bool EvCmdCompMyGold()
        {
            //Stub
            return true;
        }

        // RVA: 0x1775C30 Offset: 0x1775D31 VA: 0x1775C30
        private bool EvCmdObjVisible()
        {
            //Stub
            return true;
        }

        // RVA: 0x1775D50 Offset: 0x1775E51 VA: 0x1775D50
        private bool EvCmdObjInvisible()
        {
            //Stub
            return true;
        }

        // RVA: 0x1775E70 Offset: 0x1775F71 VA: 0x1775E70
        private bool EvCmdMailBox()
        {
            //Stub
            return true;
        }

        // RVA: 0x1775E80 Offset: 0x1775F81 VA: 0x1775E80
        private bool EvCmdGetMailBoxDataNum()
        {
            //Stub
            return true;
        }

        // RVA: 0x1775E90 Offset: 0x1775F91 VA: 0x1775E90
        private bool EvCmdRankingView()
        {
            //Stub
            return true;
        }

        // RVA: 0x1776090 Offset: 0x1776191 VA: 0x1776090
        private bool EvCmdGetTimeZone()
        {
            //Stub
            return true;
        }

        // RVA: 0x1776130 Offset: 0x1776231 VA: 0x1776130
        private bool EvCmdGetRand()
        {
            //Stub
            return true;
        }

        // RVA: 0x17761D0 Offset: 0x17762D1 VA: 0x17761D0
        private bool EvCmdGetRandNext()
        {
            //Stub
            return true;
        }

        // RVA: 0x17761F0 Offset: 0x17762F1 VA: 0x17761F0
        private bool EvCmdGetNatsuki()
        {
            //Stub
            return true;
        }

        // RVA: 0x1776350 Offset: 0x1776451 VA: 0x1776350
        private bool EvCmdAddNatsuki()
        {
            //Stub
            return true;
        }

        // RVA: 0x17765C0 Offset: 0x17766C1 VA: 0x17765C0
        private bool EvCmdSubNatsuki()
        {
            //Stub
            return true;
        }

        // RVA: 0x17765D0 Offset: 0x17766D1 VA: 0x17765D0
        private bool EvCmdHikitoriListNameSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x17765E0 Offset: 0x17766E1 VA: 0x17765E0
        private bool EvCmdGetSodateyaAishou()
        {
            //Stub
            return true;
        }

        // RVA: 0x17765F0 Offset: 0x17766F1 VA: 0x17765F0
        private bool EvCmdGetSodateyaTamagoCheck()
        {
            //Stub
            return true;
        }

        // RVA: 0x1776600 Offset: 0x1776701 VA: 0x1776600
        private bool EvCmdTemotiPokeChk()
        {
            //Stub
            return true;
        }

        // RVA: 0x17767A0 Offset: 0x17768A1 VA: 0x17767A0
        private bool EvCmdOokisaRecordChk()
        {
            //Stub
            return true;
        }

        // RVA: 0x1776930 Offset: 0x1776A31 VA: 0x1776930
        private int CalcPokemonSizeValue(PokemonParam param)
        {
            //Stub
            return 0;
        }

        // RVA: 0x1776A20 Offset: 0x1776B21 VA: 0x1776A20
        private float CalcPokemonSize(MonsNo monsNo, int sizeValue)
        {
            //Stub
            return 0;
        }

        // RVA: 0x1776BD0 Offset: 0x1776CD1 VA: 0x1776BD0
        private bool EvCmdOokisaRecordSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x1776D20 Offset: 0x1776E21 VA: 0x1776D20
        private bool EvCmdOokisaTemotiSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x1776FE0 Offset: 0x17770E1 VA: 0x1776FE0
        private bool EvCmdOokisaKirokuSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x17771A0 Offset: 0x17772A1 VA: 0x17771A0
        private bool EvCmdOokisaValueSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x1776F50 Offset: 0x1777051 VA: 0x1776F50
        private void SetOokisaDigit(int idx0, int idx1, float size) { }

        // RVA: 0x17773A0 Offset: 0x17774A1 VA: 0x17773A0
        private bool EvCmdOokisaKurabeInit()
        {
            //Stub
            return true;
        }

        // RVA: 0x17773D0 Offset: 0x17774D1 VA: 0x17773D0
        private bool EvCmdWazaListSetProc()
        {
            //Stub
            return true;
        }

        // RVA: 0x17773E0 Offset: 0x17774E1 VA: 0x17773E0
        private bool EvCmdWazaListGetResult()
        {
            //Stub
            return true;
        }

        // RVA: 0x17773F0 Offset: 0x17774F1 VA: 0x17773F0
        private bool EvCmdWazaCount()
        {
            //Stub
            return true;
        }

        // RVA: 0x1777550 Offset: 0x1777651 VA: 0x1777550
        private bool EvCmdWazaDel()
        {
            //Stub
            return true;
        }

        // RVA: 0x1777710 Offset: 0x1777811 VA: 0x1777710
        private bool EvCmdTemotiWazaNo()
        {
            //Stub
            return true;
        }

        // RVA: 0x1777720 Offset: 0x1777821 VA: 0x1777720
        private bool EvCmdTemotiWazaName()
        {
            //Stub
            return true;
        }

        // RVA: 0x1777970 Offset: 0x1777A71 VA: 0x1777970
        private bool EvCmdFNoteStartSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x1777980 Offset: 0x1777A81 VA: 0x1777980
        private bool EvCmdFNoteDataMake()
        {
            //Stub
            return true;
        }

        // RVA: 0x1777990 Offset: 0x1777A91 VA: 0x1777990
        private bool EvCmdFNoteDataSave()
        {
            //Stub
            return true;
        }

        // RVA: 0x17779A0 Offset: 0x1777AA1 VA: 0x17779A0
        private bool EvCmdImcAcceAddItem()
        {
            //Stub
            return true;
        }

        // RVA: 0x17779B0 Offset: 0x1777AB1 VA: 0x17779B0
        private bool EvCmdImcAcceAddItemChk()
        {
            //Stub
            return true;
        }

        // RVA: 0x17779C0 Offset: 0x1777AC1 VA: 0x17779C0
        private bool EvCmdImcAcceCheckItem()
        {
            //Stub
            return true;
        }

        // RVA: 0x17779D0 Offset: 0x1777AD1 VA: 0x17779D0
        private bool EvCmdImcBgAddItem()
        {
            //Stub
            return true;
        }

        // RVA: 0x17779E0 Offset: 0x1777AE1 VA: 0x17779E0
        private bool EvCmdImcBgCheckItem()
        {
            //Stub
            return true;
        }

        // RVA: 0x17779F0 Offset: 0x1777AF1 VA: 0x17779F0
        private bool EvCmdNutMixerProc()
        {
            //Stub
            return true;
        }

        // RVA: 0x1777AE0 Offset: 0x1777BE1 VA: 0x1777AE0
        private bool EvCmdNutMixerPlayStateCheck()
        {
            //Stub
            return true;
        }

        // RVA: 0x1777AF0 Offset: 0x1777BF1 VA: 0x1777AF0
        private bool EvCmdZukanChkShinou()
        {
            //Stub
            return true;
        }

        // RVA: 0x1777B90 Offset: 0x1777C91 VA: 0x1777B90
        private bool EvCmdZukanChkNational()
        {
            //Stub
            return true;
        }

        // RVA: 0x1777C30 Offset: 0x1777D31 VA: 0x1777C30
        private bool EvCmdZukanRecongnizeShinou()
        {
            //Stub
            return true;
        }

        // RVA: 0x1777D50 Offset: 0x1777E51 VA: 0x1777D50
        private bool EvCmdZukanRecongnizeNational()
        {
            //Stub
            return true;
        }

        // RVA: 0x1777E70 Offset: 0x1777F71 VA: 0x1777E70
        private bool EvCmdRecongnizeTokikake()
        {
            //Stub
            return true;
        }

        // RVA: 0x1777FD0 Offset: 0x17780D1 VA: 0x1777FD0
        private bool EvCmdRecongnizeOpenWait()
        {
            //Stub
            return true;
        }

        // RVA: 0x1777FE0 Offset: 0x17780E1 VA: 0x1777FE0
        private bool EvCmdUrayamaEncountSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x1778000 Offset: 0x1778101 VA: 0x1778000
        private bool EvCmdUrayamaEncountNoChk()
        {
            //Stub
            return true;
        }

        // RVA: 0x17780B0 Offset: 0x17781B1 VA: 0x17780B0
        private bool EvCmdPokeMailChk()
        {
            //Stub
            return true;
        }

        // RVA: 0x17780C0 Offset: 0x17781C1 VA: 0x17780C0
        private bool EvCmdPaperplaneSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x17780D0 Offset: 0x17781D1 VA: 0x17780D0
        private bool EvCmdPokeMailDel()
        {
            //Stub
            return true;
        }

        // RVA: 0x17780E0 Offset: 0x17781E1 VA: 0x17780E0
        private bool EvCmdKasekiCount()
        {
            //Stub
            return true;
        }

        // RVA: 0x17782A0 Offset: 0x17783A1 VA: 0x17782A0
        private bool EvCmdItemListSetProc()
        {
            //Stub
            return true;
        }

        // RVA: 0x17782B0 Offset: 0x17783B1 VA: 0x17782B0
        private bool EvCmdItemListGetResult()
        {
            //Stub
            return true;
        }

        // RVA: 0x17782C0 Offset: 0x17783C1 VA: 0x17782C0
        private bool EvCmdItemNoToMonsNo()
        {
            //Stub
            return true;
        }

        // RVA: 0x1778420 Offset: 0x1778521 VA: 0x1778420
        private bool EvCmdKasekiItemNo()
        {
            //Stub
            return true;
        }

        // RVA: 0x1778680 Offset: 0x1778781 VA: 0x1778680
        private bool EvCmdPokeLevelChk()
        {
            //Stub
            return true;
        }

        // RVA: 0x1778800 Offset: 0x1778901 VA: 0x1778800
        private bool EvCmdBTowerAppSetProc()
        {
            //Stub
            return true;
        }

        // RVA: 0x1778AC0 Offset: 0x1778BC1 VA: 0x1778AC0
        private bool EvCmdBattleTowerRecordMenuWait()
        {
            //Stub
            return true;
        }

        // RVA: 0x1778AD0 Offset: 0x1778BD1 VA: 0x1778AD0
        private bool EvCmdBattleTowerWorkClear()
        {
            //Stub
            return true;
        }

        // RVA: 0x1778AE0 Offset: 0x1778BE1 VA: 0x1778AE0
        private bool EvCmdBattleTowerWorkInit()
        {
            //Stub
            return true;
        }

        // RVA: 0x1778AF0 Offset: 0x1778BF1 VA: 0x1778AF0
        private bool EvCmdBattleTowerWorkRelease()
        {
            //Stub
            return true;
        }

        // RVA: 0x1778B00 Offset: 0x1778C01 VA: 0x1778B00
        private bool EvCmdBattleTowerTools()
        {
            //Stub
            return true;
        }

        // RVA: 0x1778B10 Offset: 0x1778C11 VA: 0x1778B10
        private bool EvCmdBattleTowerGetSevenPokeData()
        {
            //Stub
            return true;
        }

        // RVA: 0x1778B20 Offset: 0x1778C21 VA: 0x1778B20
        private bool EvCmdBattleTowerIsPrizeGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x1778B30 Offset: 0x1778C31 VA: 0x1778B30
        private bool EvCmdBattleTowerIsPrizemanSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x1778B40 Offset: 0x1778C41 VA: 0x1778B40
        private bool EvCmdBattleTowerSendBuf()
        {
            //Stub
            return true;
        }

        // RVA: 0x1778B50 Offset: 0x1778C51 VA: 0x1778B50
        private bool EvCmdBattleTowerRecvBuf()
        {
            //Stub
            return true;
        }

        // RVA: 0x1778B60 Offset: 0x1778C61 VA: 0x1778B60
        private bool EvCmdBattleTowerGetLeaderRoomID()
        {
            //Stub
            return true;
        }

        // RVA: 0x1778B70 Offset: 0x1778C71 VA: 0x1778B70
        private bool EvCmdBattleTowerIsLeaderDataExist()
        {
            //Stub
            return true;
        }

        // RVA: 0x1778B80 Offset: 0x1778C81 VA: 0x1778B80
        private bool EvCmdRecordInc()
        {
            //Stub
            return true;
        }

        // RVA: 0x1778C00 Offset: 0x1778D01 VA: 0x1778C00
        private bool EvCmdRecordGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x1778C10 Offset: 0x1778D11 VA: 0x1778C10
        private bool EvCmdRecordAdd()
        {
            //Stub
            return true;
        }

        // RVA: 0x1778C20 Offset: 0x1778D21 VA: 0x1778C20
        private bool EvCmdRecordSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x1778C30 Offset: 0x1778D31 VA: 0x1778C30
        private bool EvCmdRecordSetIflarge()
        {
            //Stub
            return true;
        }

        // RVA: 0x1778C40 Offset: 0x1778D41 VA: 0x1778C40
        private bool EvCmdSafariControlStart()
        {
            //Stub
            return true;
        }

        // RVA: 0x1778DF0 Offset: 0x1778EF1 VA: 0x1778DF0
        private bool EvCmdSafariControlEnd()
        {
            //Stub
            return true;
        }

        // RVA: 0x1779080 Offset: 0x1779181 VA: 0x1779080
        private bool EvCmdCallSafariScope()
        {
            //Stub
            return true;
        }

        // RVA: 0x17791B0 Offset: 0x17792B1 VA: 0x17791B0
        private bool EvCmdClimaxDemoCall()
        {
            //Stub
            return true;
        }

        // RVA: 0x17791C0 Offset: 0x17792C1 VA: 0x17791C0
        private bool EvCmdInitSafariTrain()
        {
            //Stub
            return true;
        }

        // RVA: 0x17791D0 Offset: 0x17792D1 VA: 0x17791D0
        private bool EvCmdMoveSafariTrain()
        {
            //Stub
            return true;
        }

        // RVA: 0x1779500 Offset: 0x1779601 VA: 0x1779500
        private bool EvCmdCheckSafariTrain()
        {
            //Stub
            return true;
        }

        // RVA: 0x1779370 Offset: 0x1779471 VA: 0x1779370
        private FieldEventTrainEntity GetTrain()
        {
            //Stub
            return null;
        }

        // RVA: 0x1779630 Offset: 0x1779731 VA: 0x1779630
        private bool EvCmdPlayerHeightValid()
        {
            //Stub
            return true;
        }

        // RVA: 0x1779770 Offset: 0x1779871 VA: 0x1779770
        private bool EvCmdGetPokeSeikaku()
        {
            //Stub
            return true;
        }

        // RVA: 0x17798B0 Offset: 0x17799B1 VA: 0x17798B0
        private bool EvCmdChkPokeSeikakuAll()
        {
            //Stub
            return true;
        }

        // RVA: 0x1779A20 Offset: 0x1779B21 VA: 0x1779A20
        private bool EvCmdUnderGroundTalkCount()
        {
            //Stub
            return true;
        }

        // RVA: 0x1779A30 Offset: 0x1779B31 VA: 0x1779A30
        private bool EvCmdNaturalParkWalkCountClear()
        {
            //Stub
            return true;
        }

        // RVA: 0x1779AE0 Offset: 0x1779BE1 VA: 0x1779AE0
        private bool EvCmdNaturalParkWalkCountGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x1779AF0 Offset: 0x1779BF1 VA: 0x1779AF0
        private bool EvCmdNaturalParkAccessoryNoGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x1779B00 Offset: 0x1779C01 VA: 0x1779B00
        private bool EvCmdGetNewsPokeNo()
        {
            //Stub
            return true;
        }

        // RVA: 0x1779CC0 Offset: 0x1779DC1 VA: 0x1779CC0
        private bool EvCmdNewsCountSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x1779CD0 Offset: 0x1779DD1 VA: 0x1779CD0
        private bool EvCmdNewsCountChk()
        {
            //Stub
            return true;
        }

        // RVA: 0x1779CE0 Offset: 0x1779DE1 VA: 0x1779CE0
        private bool EvCmdStartGenerate()
        {
            //Stub
            return true;
        }

        // RVA: 0x1779D60 Offset: 0x1779E61 VA: 0x1779D60
        private bool EvCmdAddMovePoke()
        {
            //Stub
            return true;
        }

        // RVA: 0x1779EE0 Offset: 0x1779FE1 VA: 0x1779EE0
        private bool EvCmdOshieWazaCount()
        {
            //Stub
            return true;
        }

        // RVA: 0x1779EF0 Offset: 0x1779FF1 VA: 0x1779EF0
        private bool EvCmdRemaindWazaCount()
        {
            //Stub
            return true;
        }

        // RVA: 0x177A070 Offset: 0x177A171 VA: 0x177A070
        private bool EvCmdOshieWazaListSetProc()
        {
            //Stub
            return true;
        }

        // RVA: 0x177A080 Offset: 0x177A181 VA: 0x177A080
        private bool EvCmdRemaindWazaListSetProc()
        {
            //Stub
            return true;
        }

        // RVA: 0x177A090 Offset: 0x177A191 VA: 0x177A090
        private bool EvCmdOshieWazaListGetResult()
        {
            //Stub
            return true;
        }

        // RVA: 0x177A0A0 Offset: 0x177A1A1 VA: 0x177A0A0
        private bool EvCmdRemaindWazaListGetResult()
        {
            //Stub
            return true;
        }

        // RVA: 0x177A0B0 Offset: 0x177A1B1 VA: 0x177A0B0
        private bool EvCmdNormalWazaListSetProc()
        {
            //Stub
            return true;
        }

        // RVA: 0x177A0C0 Offset: 0x177A1C1 VA: 0x177A0C0
        private bool EvCmdNormalWazaListGetResult()
        {
            //Stub
            return true;
        }

        // RVA: 0x177A0D0 Offset: 0x177A1D1 VA: 0x177A0D0
        private bool EvCmdFldTradeAlloc()
        {
            //Stub
            return true;
        }

        // RVA: 0x177A0E0 Offset: 0x177A1E1 VA: 0x177A0E0
        private bool EvCmdFldTradeMonsno()
        {
            //Stub
            return true;
        }

        // RVA: 0x177A0F0 Offset: 0x177A1F1 VA: 0x177A0F0
        private bool EvCmdFldTradeChgMonsno()
        {
            //Stub
            return true;
        }

        // RVA: 0x177A100 Offset: 0x177A201 VA: 0x177A100
        private bool EvCmdFldTradeEvent()
        {
            //Stub
            return true;
        }

        // RVA: 0x177A110 Offset: 0x177A211 VA: 0x177A110
        private bool EvCmdFldTradeDel()
        {
            //Stub
            return true;
        }

        // RVA: 0x177A120 Offset: 0x177A221 VA: 0x177A120
        private bool EvCmdZukanTextVerUp()
        {
            //Stub
            return true;
        }

        // RVA: 0x177A130 Offset: 0x177A231 VA: 0x177A130
        private bool EvCmdZukanSexVerUp()
        {
            //Stub
            return true;
        }

        // RVA: 0x177A140 Offset: 0x177A241 VA: 0x177A140
        private bool EvCmdZenkokuZukanFlag()
        {
            //Stub
            return true;
        }

        // RVA: 0x177A280 Offset: 0x177A381 VA: 0x177A280
        private bool EvCmdChkRibbonCount()
        {
            //Stub
            return true;
        }

        // RVA: 0x177A290 Offset: 0x177A391 VA: 0x177A290
        private bool EvCmdChkRibbonCountAll()
        {
            //Stub
            return true;
        }

        // RVA: 0x177A3E0 Offset: 0x177A4E1 VA: 0x177A3E0
        private bool EvCmdChkRibbon()
        {
            //Stub
            return true;
        }

        // RVA: 0x177A580 Offset: 0x177A681 VA: 0x177A580
        private bool EvCmdSetRibbon()
        {
            //Stub
            return true;
        }

        // RVA: 0x177A6F0 Offset: 0x177A7F1 VA: 0x177A6F0
        private bool EvCmdRibbonName()
        {
            //Stub
            return true;
        }

        // RVA: 0x177A820 Offset: 0x177A921 VA: 0x177A820
        private bool EvCmdChkPrmExp()
        {
            //Stub
            return true;
        }

        // RVA: 0x177A960 Offset: 0x177AA61 VA: 0x177A960
        private bool EvCmdChkWeek()
        {
            //Stub
            return true;
        }

        // RVA: 0x177A9D0 Offset: 0x177AAD1 VA: 0x177A9D0
        private bool EvCmdTVEntryWatchHideItem()
        {
            //Stub
            return true;
        }

        // RVA: 0x177AAA0 Offset: 0x177ABA1 VA: 0x177AAA0
        private bool EvCmdTVEntryWatchChangeName()
        {
            //Stub
            return true;
        }

        // RVA: 0x177ABD0 Offset: 0x177ACD1 VA: 0x177ABD0
        private bool EvCmdRegulationListCall()
        {
            //Stub
            return true;
        }

        // RVA: 0x177ABE0 Offset: 0x177ACE1 VA: 0x177ABE0
        private bool EvCmdAshiatoChk()
        {
            //Stub
            return true;
        }

        // RVA: 0x177AD80 Offset: 0x177AE81 VA: 0x177AD80
        private bool EvCmdPcRecoverAnm()
        {
            //Stub
            return true;
        }

        // RVA: 0x177B040 Offset: 0x177B141 VA: 0x177B040
        private bool EvCmdElevatorAnm()
        {
            //Stub
            return true;
        }

        // RVA: 0x177B250 Offset: 0x177B351 VA: 0x177B250
        private bool EvCmdCallShipDemo()
        {
            //Stub
            return true;
        }

        // RVA: 0x177B370 Offset: 0x177B471 VA: 0x177B370
        private bool EvCmdCallShipDemoSeaMap()
        {
            //Stub
            return true;
        }

        // RVA: 0x177B4A0 Offset: 0x177B5A1 VA: 0x177B4A0
        private bool EvCmdSetupShip()
        {
            //Stub
            return true;
        }

        // RVA: 0x177B560 Offset: 0x177B661 VA: 0x177B560
        private bool EvCmdGetUsedPoketchAppID()
        {
            //Stub
            return true;
        }

        // RVA: 0x177B760 Offset: 0x177B861 VA: 0x177B760
        private bool EvCmdDebugPrintWork()
        {
            //Stub
            return true;
        }

        // RVA: 0x177B770 Offset: 0x177B871 VA: 0x177B770
        private bool EvCmdDebugPrintFlag()
        {
            //Stub
            return true;
        }

        // RVA: 0x177B780 Offset: 0x177B881 VA: 0x177B780
        private bool EvCmdDebugPrintWorkStationed()
        {
            //Stub
            return true;
        }

        // RVA: 0x177B790 Offset: 0x177B891 VA: 0x177B790
        private bool EvCmdDebugPrintFlagStationed()
        {
            //Stub
            return true;
        }

        // RVA: 0x177B7A0 Offset: 0x177B8A1 VA: 0x177B7A0
        private bool EvCmdPMVersionGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x177B840 Offset: 0x177B941 VA: 0x177B840
        private bool EvCmdFrontPokemon()
        {
            //Stub
            return true;
        }

        // RVA: 0x177B950 Offset: 0x177BA51 VA: 0x177B950
        private bool EvCmdTemotiPokeType()
        {
            //Stub
            return true;
        }

        // RVA: 0x177BAD0 Offset: 0x177BBD1 VA: 0x177BAD0
        private bool EvCmdAikotobaKabegamiSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x177BAE0 Offset: 0x177BBE1 VA: 0x177BAE0
        private bool EvCmdGetUgHataNum()
        {
            //Stub
            return true;
        }

        // RVA: 0x177BAF0 Offset: 0x177BBF1 VA: 0x177BAF0
        private bool EvCmdSetUpPasoAnime()
        {
            //Stub
            return true;
        }

        // RVA: 0x177BB00 Offset: 0x177BC01 VA: 0x177BB00
        private bool EvCmdStartPasoOnAnime()
        {
            //Stub
            return true;
        }

        // RVA: 0x177BB10 Offset: 0x177BC11 VA: 0x177BB10
        private bool EvCmdStartPasoOffAnime()
        {
            //Stub
            return true;
        }

        // RVA: 0x177BB20 Offset: 0x177BC21 VA: 0x177BB20
        private bool EvCmdGetKujiAtariNum()
        {
            //Stub
            return true;
        }

        // RVA: 0x177BB80 Offset: 0x177BC81 VA: 0x177BB80
        private bool EvCmdKujiAtariChk()
        {
            //Stub
            return true;
        }

        // RVA: 0x177BE90 Offset: 0x177BF91 VA: 0x177BE90
        private bool EvCmdKujiAtariInit()
        {
            //Stub
            return true;
        }

        // RVA: 0x177BEB0 Offset: 0x177BFB1 VA: 0x177BEB0
        private bool EvCmdNickNamePC()
        {
            //Stub
            return true;
        }

        // RVA: 0x177BEC0 Offset: 0x177BFC1 VA: 0x177BEC0
        private bool EvCmdTVInterviewerCheck()
        {
            //Stub
            return true;
        }

        // RVA: 0x177BFB0 Offset: 0x177C0B1 VA: 0x177BFB0
        private bool EvCmdTVInterviewerMsg()
        {
            //Stub
            return true;
        }

        // RVA: 0x177BFC0 Offset: 0x177C0C1 VA: 0x177BFC0
        private bool EvCmdTVInterviewerEntry()
        {
            //Stub
            return true;
        }

        // RVA: 0x177C1B0 Offset: 0x177C2B1 VA: 0x177C1B0
        private bool EvCmdTVStart()
        {
            //Stub
            return true;
        }

        // RVA: 0x177C330 Offset: 0x177C431 VA: 0x177C330
        private void PlayTv(TvDataTable.Sheetdata data) { }

        // RVA: 0x177C420 Offset: 0x177C521 VA: 0x177C420
        private FieldTvEntity FindTvEntity()
        {
            //Stub
            return null;
        }

        // RVA: 0x177C640 Offset: 0x177C741 VA: 0x177C640
        private bool EvCmdTVEnd()
        {
            //Stub
            return true;
        }

        // RVA: 0x177C730 Offset: 0x177C831 VA: 0x177C730
        private bool EvCmdTVStartNumber()
        {
            //Stub
            return true;
        }

        // RVA: 0x177C810 Offset: 0x177C911 VA: 0x177C810
        private bool EvCmdTVTopicBranchGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x177C900 Offset: 0x177CA01 VA: 0x177C900
        private bool EvCmdTVTopicIntGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x177C9F0 Offset: 0x177CAF1 VA: 0x177C9F0
        private bool EvCmdTVTopicStrWordSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x177CB70 Offset: 0x177CC71 VA: 0x177CB70
        private bool EvCmdTVTopicStrGenderWordSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x177CD40 Offset: 0x177CE41 VA: 0x177CD40
        private bool EvCmdTvInterviewStrWordSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x177CEC0 Offset: 0x177CFC1 VA: 0x177CEC0
        private bool EvCmdTVMonitorSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x177CFA0 Offset: 0x177D0A1 VA: 0x177CFA0
        private bool EvCmdTVMonitorReset()
        {
            //Stub
            return true;
        }

        // RVA: 0x177D030 Offset: 0x177D131 VA: 0x177D030
        private bool EvCmdPokeBoxCountEmptySpace()
        {
            //Stub
            return true;
        }

        // RVA: 0x177D090 Offset: 0x177D191 VA: 0x177D090
        private bool EvCmdConOpenPokeSelectMenu()
        {
            //Stub
            return true;
        }

        // RVA: 0x177D1B0 Offset: 0x177D2B1 VA: 0x177D1B0
        private bool EvCmdConOpenCapsuleSelectMenu()
        {
            //Stub
            return true;
        }

        // RVA: 0x177D2D0 Offset: 0x177D3D1 VA: 0x177D2D0
        private bool EvCmdConOpenBoutiqueSelectMenu()
        {
            //Stub
            return true;
        }

        // RVA: 0x177D3C0 Offset: 0x177D4C1 VA: 0x177D3C0
        private bool EvCmdConOpenMatchingMenu()
        {
            //Stub
            return true;
        }

        // RVA: 0x177D620 Offset: 0x177D721 VA: 0x177D620
        private bool EvCmdConOpenResumeMatchingMenu()
        {
            //Stub
            return true;
        }

        // RVA: 0x177D740 Offset: 0x177D841 VA: 0x177D740
        private bool EvCmdConWaitContestMenu()
        {
            //Stub
            return true;
        }

        // RVA: 0x177D750 Offset: 0x177D851 VA: 0x177D750
        private bool EvCmdConMyEntryNumberWordSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x177D8E0 Offset: 0x177D9E1 VA: 0x177D8E0
        private bool EvCmdConBestPerformerCheck()
        {
            //Stub
            return true;
        }

        // RVA: 0x177D940 Offset: 0x177DA41 VA: 0x177D940
        private bool EvCmdConCategoryRibbonNameSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x177DA20 Offset: 0x177DB21 VA: 0x177DA20
        private bool EvCmdConHaveContestStarCheck()
        {
            //Stub
            return true;
        }

        // RVA: 0x177DA80 Offset: 0x177DB81 VA: 0x177DA80
        private bool EvCmdConContestStarNameSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x177DB60 Offset: 0x177DC61 VA: 0x177DB60
        private bool EvCmdConRewardNameSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x177DC40 Offset: 0x177DD41 VA: 0x177DC40
        private bool EvCmdConTwinkleStarNameSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x177DD20 Offset: 0x177DE21 VA: 0x177DD20
        private bool EvCmdRewardShowMasterNameSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x177DDF0 Offset: 0x177DEF1 VA: 0x177DDF0
        private bool EvCmdConCategoryAndRankSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x177DF10 Offset: 0x177E011 VA: 0x177DF10
        private bool EvCmdConRankSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x177DF20 Offset: 0x177E021 VA: 0x177DF20
        private bool EvCmdConCheckEntryPoke()
        {
            //Stub
            return true;
        }

        // RVA: 0x177E040 Offset: 0x177E141 VA: 0x177E040
        private bool EvCmdConResetParameter()
        {
            //Stub
            return true;
        }

        // RVA: 0x177E2B0 Offset: 0x177E3B1 VA: 0x177E2B0
        private bool EvCmdConSelectSingleMode()
        {
            //Stub
            return true;
        }

        // RVA: 0x177E3C0 Offset: 0x177E4C1 VA: 0x177E3C0
        private bool EvCmdConSelectMultiMode()
        {
            //Stub
            return true;
        }

        // RVA: 0x177E3D0 Offset: 0x177E4D1 VA: 0x177E3D0
        private bool ExCmdImageClipViewConCheckProc()
        {
            //Stub
            return true;
        }

        // RVA: 0x177E4D0 Offset: 0x177E5D1 VA: 0x177E4D0
        private bool EvCmdPokeParkControl()
        {
            //Stub
            return true;
        }

        // RVA: 0x177E4E0 Offset: 0x177E5E1 VA: 0x177E4E0
        private bool EvCmdPokeParkDepositCount()
        {
            //Stub
            return true;
        }

        // RVA: 0x177E4F0 Offset: 0x177E5F1 VA: 0x177E4F0
        private bool EvCmdPokeParkTransMons()
        {
            //Stub
            return true;
        }

        // RVA: 0x177E500 Offset: 0x177E601 VA: 0x177E500
        private bool EvCmdPokeParkGetScore()
        {
            //Stub
            return true;
        }

        // RVA: 0x177E510 Offset: 0x177E611 VA: 0x177E510
        private bool EvCmdDendouBallAnm()
        {
            //Stub
            return true;
        }

        // RVA: 0x1773170 Offset: 0x1773271 VA: 0x1773170
        private bool EvCmdInitFldLift()
        {
            //Stub
            return true;
        }

        // RVA: 0x17732F0 Offset: 0x17733F1 VA: 0x17732F0
        private bool EvCmdMoveFldLift()
        {
            //Stub
            return true;
        }

        // RVA: 0x177E520 Offset: 0x177E621 VA: 0x177E520
        private bool EvCmdCheckFldLift()
        {
            //Stub
            return true;
        }

        // RVA: 0x177E710 Offset: 0x177E811 VA: 0x177E710
        private bool EvCmdSetupRAHCyl()
        {
            //Stub
            return true;
        }

        // RVA: 0x177E720 Offset: 0x177E821 VA: 0x177E720
        private bool EvCmdStartRAHCyl()
        {
            //Stub
            return true;
        }

        // RVA: 0x177E730 Offset: 0x177E831 VA: 0x177E730
        private bool EvCmdAddScore()
        {
            //Stub
            return true;
        }

        // RVA: 0x177E740 Offset: 0x177E841 VA: 0x177E740
        private bool EvCmdAcceName()
        {
            //Stub
            return true;
        }

        // RVA: 0x177E750 Offset: 0x177E851 VA: 0x177E750
        private bool EvCmdPartyMonsNoCheck()
        {
            //Stub
            return true;
        }

        // RVA: 0x177E8D0 Offset: 0x177E9D1 VA: 0x177E8D0
        private bool EvCmdPartyDeokisisuFormChange()
        {
            //Stub
            return true;
        }

        // RVA: 0x177EAA0 Offset: 0x177EBA1 VA: 0x177EAA0
        private bool EvCmdCheckMinomuchiComp()
        {
            //Stub
            return true;
        }

        // RVA: 0x177EC10 Offset: 0x177ED11 VA: 0x177EC10
        private bool EvCmdPoketchHookSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x177EC20 Offset: 0x177ED21 VA: 0x177EC20
        private bool EvCmdPoketchHookReset()
        {
            //Stub
            return true;
        }

        // RVA: 0x177EC30 Offset: 0x177ED31 VA: 0x177EC30
        private bool EvCmdSlotMachine()
        {
            //Stub
            return true;
        }

        // RVA: 0x177EC40 Offset: 0x177ED41 VA: 0x177EC40
        private bool EvCmdGetNowHour()
        {
            //Stub
            return true;
        }

        // RVA: 0x177ECD0 Offset: 0x177EDD1 VA: 0x177ECD0
        private bool EvCmdObjShakeAnm()
        {
            //Stub
            return true;
        }

        // RVA: 0x177ECE0 Offset: 0x177EDE1 VA: 0x177ECE0
        private bool EvCmdObjBlinkAnm()
        {
            //Stub
            return true;
        }

        // RVA: 0x177ECF0 Offset: 0x177EDF1 VA: 0x177ECF0
        private bool EvCmd_D20R0106Legend_IsUnseal()
        {
            //Stub
            return true;
        }

        // RVA: 0x177EEB0 Offset: 0x177EFB1 VA: 0x177EEB0
        private bool EvCmdDressingImcAcceCheck()
        {
            //Stub
            return true;
        }

        // RVA: 0x177EEC0 Offset: 0x177EFC1 VA: 0x177EEC0
        private bool EvCmdTalkMsgUnknownFont()
        {
            //Stub
            return true;
        }

        // RVA: 0x177EED0 Offset: 0x177EFD1 VA: 0x177EED0
        private bool EvCmdAgbCartridgeVerGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x177EEE0 Offset: 0x177EFE1 VA: 0x177EEE0
        private bool EvCmdUnderGroundTalkCountClear()
        {
            //Stub
            return true;
        }

        // RVA: 0x177EEF0 Offset: 0x177EFF1 VA: 0x177EEF0
        private bool EvCmdHideMapStateChange()
        {
            //Stub
            return true;
        }

        // RVA: 0x177EF00 Offset: 0x177F001 VA: 0x177EF00
        private bool EvCmdNameInStone()
        {
            //Stub
            return true;
        }

        // RVA: 0x177F110 Offset: 0x177F211 VA: 0x177F110
        private bool EvCmdMonumantName()
        {
            //Stub
            return true;
        }

        // RVA: 0x177F260 Offset: 0x177F361 VA: 0x177F260
        private bool EvCmdImcBgNameSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x177F270 Offset: 0x177F371 VA: 0x177F270
        private bool EvCmdCompCoin()
        {
            //Stub
            return true;
        }

        // RVA: 0x177F280 Offset: 0x177F381 VA: 0x177F280
        private bool EvCmdSlotRentyanChk()
        {
            //Stub
            return true;
        }

        // RVA: 0x177F290 Offset: 0x177F391 VA: 0x177F290
        private bool EvCmdAddCoinChk()
        {
            //Stub
            return true;
        }

        // RVA: 0x177F2A0 Offset: 0x177F3A1 VA: 0x177F2A0
        private bool EvCmdLevelJijiiNo()
        {
            //Stub
            return true;
        }

        // RVA: 0x177F300 Offset: 0x177F401 VA: 0x177F300
        private bool EvCmdPokeLevelGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x177F440 Offset: 0x177F541 VA: 0x177F440
        private bool EvCmdImcAcceSubItem()
        {
            //Stub
            return true;
        }

        // RVA: 0x177F450 Offset: 0x177F551 VA: 0x177F450
        private bool EvCmdc08r0801ScopeCameraSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x177F580 Offset: 0x177F681 VA: 0x177F580
        private bool EvCmdc08r0801ScopeSequence()
        {
            //Stub
            return true;
        }

        // RVA: 0x177F5C0 Offset: 0x177F6C1 VA: 0x177F5C0
        private bool EvCmdLevelJijiiInit()
        {
            //Stub
            return true;
        }

        // RVA: 0x177F630 Offset: 0x177F731 VA: 0x177F630
        private bool EvCmdNewNankaiWordSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x177F640 Offset: 0x177F741 VA: 0x177F640
        private bool EvCmdRegularCheck()
        {
            //Stub
            return true;
        }

        // RVA: 0x177F6A0 Offset: 0x177F7A1 VA: 0x177F6A0
        private bool EvCmdNankaiWordCompleteCheck()
        {
            //Stub
            return true;
        }

        // RVA: 0x177F6B0 Offset: 0x177F7B1 VA: 0x177F6B0
        private bool EvCmdTemotiPokeContestStatusGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x177F850 Offset: 0x177F951 VA: 0x177F850
        private bool EvCmdD17SystemMapSelect()
        {
            //Stub
            return true;
        }

        // RVA: 0x177F860 Offset: 0x177F961 VA: 0x177F860
        private bool EvCmdUnderGroundToolGiveCount()
        {
            //Stub
            return true;
        }

        // RVA: 0x177F870 Offset: 0x177F971 VA: 0x177F870
        private bool EvCmdUnderGroundKasekiDigCount()
        {
            //Stub
            return true;
        }

        // RVA: 0x177F880 Offset: 0x177F981 VA: 0x177F880
        private bool EvCmdUnderGroundTrapHitCount()
        {
            //Stub
            return true;
        }

        // RVA: 0x177F890 Offset: 0x177F991 VA: 0x177F890
        private bool EvCmdPofinAdd()
        {
            //Stub
            return true;
        }

        // RVA: 0x177F8A0 Offset: 0x177F9A1 VA: 0x177F8A0
        private bool EvCmdPofinAddCheck()
        {
            //Stub
            return true;
        }

        // RVA: 0x177F8C0 Offset: 0x177F9C1 VA: 0x177F8C0
        private bool EvCmdIsHaihuEventEnable()
        {
            //Stub
            return true;
        }

        // RVA: 0x177F930 Offset: 0x177FA31 VA: 0x177F930
        private bool EvCmdSodateyaPokeListSetProc()
        {
            //Stub
            return true;
        }

        // RVA: 0x177F940 Offset: 0x177FA41 VA: 0x177F940
        private bool EvCmdSodateyaPokeListGetResult()
        {
            //Stub
            return true;
        }

        // RVA: 0x177F950 Offset: 0x177FA51 VA: 0x177F950
        private bool EvCmdGetRandomHit()
        {
            //Stub
            return true;
        }

        // RVA: 0x177FA00 Offset: 0x177FB01 VA: 0x177FA00
        private bool EvCmdUnderGroundTalkCount2()
        {
            //Stub
            return true;
        }

        // RVA: 0x177FA10 Offset: 0x177FB11 VA: 0x177FA10
        private bool EvCmdHidenEffStart()
        {
            //Stub
            return true;
        }

        // RVA: 0x177FC70 Offset: 0x177FD71 VA: 0x177FC70
        private bool EvCmdZishin()
        {
            //Stub
            return true;
        }

        // RVA: 0x177FC80 Offset: 0x177FD81 VA: 0x177FC80
        private bool EvCmdBtlPointWinWrite()
        {
            //Stub
            return true;
        }

        // RVA: 0x177FC90 Offset: 0x177FD91 VA: 0x177FC90
        private bool EvCmdBtlPointWinDel()
        {
            //Stub
            return true;
        }

        // RVA: 0x177FCA0 Offset: 0x177FDA1 VA: 0x177FCA0
        private bool EvCmdBtlPointWrite()
        {
            //Stub
            return true;
        }

        // RVA: 0x177FCB0 Offset: 0x177FDB1 VA: 0x177FCB0
        private bool EvCmdCheckBtlPoint()
        {
            //Stub
            return true;
        }

        // RVA: 0x177FCC0 Offset: 0x177FDC1 VA: 0x177FCC0
        private bool EvCmdAddBtlPoint()
        {
            //Stub
            return true;
        }

        // RVA: 0x177FCD0 Offset: 0x177FDD1 VA: 0x177FCD0
        private bool EvCmdSubBtlPoint()
        {
            //Stub
            return true;
        }

        // RVA: 0x177FCE0 Offset: 0x177FDE1 VA: 0x177FCE0
        private bool EvCmdCompBtlPoint()
        {
            //Stub
            return true;
        }

        // RVA: 0x177FCF0 Offset: 0x177FDF1 VA: 0x177FCF0
        private bool EvCmdGetBtlPointGift()
        {
            //Stub
            return true;
        }

        // RVA: 0x177FD00 Offset: 0x177FE01 VA: 0x177FD00
        private bool EvCmdUgBallCheck()
        {
            //Stub
            return true;
        }

        // RVA: 0x177FD10 Offset: 0x177FE11 VA: 0x177FD10
        private bool EvCmdAusuItemCheck()
        {
            //Stub
            return true;
        }

        // RVA: 0x177FDC0 Offset: 0x177FEC1 VA: 0x177FDC0
        private bool EvCmdCheckMyGSID()
        {
            //Stub
            return true;
        }

        // RVA: 0x177FDD0 Offset: 0x177FED1 VA: 0x177FDD0
        private bool EvCmdGetFriendDataNum()
        {
            //Stub
            return true;
        }

        // RVA: 0x177FDE0 Offset: 0x177FEE1 VA: 0x177FDE0
        private bool EvCmdGetCoinGift()
        {
            //Stub
            return true;
        }

        // RVA: 0x177FDF0 Offset: 0x177FEF1 VA: 0x177FDF0
        private bool EvCmdSubWkCoin()
        {
            //Stub
            return true;
        }

        // RVA: 0x177FE00 Offset: 0x177FF01 VA: 0x177FE00
        private bool EvCmdCompWkCoin()
        {
            //Stub
            return true;
        }

        // RVA: 0x177FE10 Offset: 0x177FF11 VA: 0x177FE10
        private bool EvCmdAikotobaOkurimonoChk()
        {
            //Stub
            return true;
        }

        // RVA: 0x177FE20 Offset: 0x177FF21 VA: 0x177FE20
        private bool EvCmdWifiHusiginaokurimonoOpenFlagSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x177FE30 Offset: 0x177FF31 VA: 0x177FE30
        private bool EvCmdUnionGetCardTalkNo()
        {
            //Stub
            return true;
        }

        // RVA: 0x177FE40 Offset: 0x177FF41 VA: 0x177FE40
        private bool EvCmdWirelessIconEasy()
        {
            //Stub
            return true;
        }

        // RVA: 0x177FE50 Offset: 0x177FF51 VA: 0x177FE50
        private bool EvCmdWirelessIconEasyEnd()
        {
            //Stub
            return true;
        }

        // RVA: 0x177FE60 Offset: 0x177FF61 VA: 0x177FE60
        private bool EvCmdSaveFieldObj()
        {
            //Stub
            return true;
        }

        // RVA: 0x177FE70 Offset: 0x177FF71 VA: 0x177FE70
        private bool EvCmdSealName()
        {
            //Stub
            return true;
        }

        // RVA: 0x1780000 Offset: 0x1780101 VA: 0x1780000
        private bool EvCmdSetEscapeLocation()
        {
            //Stub
            return true;
        }

        // RVA: 0x1780010 Offset: 0x1780111 VA: 0x1780010
        private bool EvCmdFieldObjBitSetFellowHit()
        {
            //Stub
            return true;
        }

        // RVA: 0x1780020 Offset: 0x1780121 VA: 0x1780020
        private bool EvCmdDameTamagoChkAll()
        {
            //Stub
            return true;
        }

        // RVA: 0x1780120 Offset: 0x1780221 VA: 0x1780120
        private bool EvCmdUnionBmpMenuStart()
        {
            //Stub
            return true;
        }

        // RVA: 0x1780130 Offset: 0x1780231 VA: 0x1780130
        private bool EvCmdUnionBattleStartCheck()
        {
            //Stub
            return true;
        }

        // RVA: 0x1780140 Offset: 0x1780241 VA: 0x1780140
        private bool EvCmdGetCardRank()
        {
            //Stub
            return true;
        }

        // RVA: 0x17801E0 Offset: 0x17802E1 VA: 0x17801E0
        private bool EvCmdFieldScopeModeSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x17801F0 Offset: 0x17802F1 VA: 0x17801F0
        private bool EvCmdFieldScopeModeReSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x1780200 Offset: 0x1780301 VA: 0x1780200
        private bool EvCmd_SET_TURN_HERO_FRAME()
        {
            //Stub
            return true;
        }

        // RVA: 0x1780290 Offset: 0x1780391 VA: 0x1780290
        private bool EvCmd_SET_TURN_OBJ_FRAME()
        {
            //Stub
            return true;
        }

        // RVA: 0x1780320 Offset: 0x1780421 VA: 0x1780320
        private bool EvCmd_DEBUG_PRINT()
        {
            //Stub
            return true;
        }

        // RVA: 0x1780350 Offset: 0x1780451 VA: 0x1780350
        private bool EvCmd_FADE_WAIT()
        {
            //Stub
            return true;
        }

        // RVA: 0x17803E0 Offset: 0x17804E1 VA: 0x17803E0
        private bool EvCmd_HERO_MOVE_GRID_CENTER()
        {
            //Stub
            return true;
        }

        // RVA: 0x17803F0 Offset: 0x17804F1 VA: 0x17803F0
        private bool EvCmd_SET_POS_HERO_MATCH_X()
        {
            //Stub
            return true;
        }

        // RVA: 0x17805A0 Offset: 0x17806A1 VA: 0x17805A0
        private bool EvCmd_SET_POS_HERO_MATCH_Z()
        {
            //Stub
            return true;
        }

        // RVA: 0x1780750 Offset: 0x1780851 VA: 0x1780750
        private bool EvCmd_GET_LANGUAGE()
        {
            //Stub
            return true;
        }

        // RVA: 0x1780800 Offset: 0x1780901 VA: 0x1780800
        private bool EvCmd__GET_REL_POS_HERO()
        {
            //Stub
            return true;
        }

        // RVA: 0x1740120 Offset: 0x1740221 VA: 0x1740120
        private bool EvCmd__CAMERA_TARGET_HERO()
        {
            //Stub
            return true;
        }

        // RVA: 0x1780820 Offset: 0x1780921 VA: 0x1780820
        private bool EvCmd__CAMERA_TARGET_DUMMY()
        {
            //Stub
            return true;
        }

        // RVA: 0x17808B0 Offset: 0x17809B1 VA: 0x17808B0
        private bool EvCmd_DUMMY_ANIME()
        {
            //Stub
            return true;
        }

        // RVA: 0x1780990 Offset: 0x1780A91 VA: 0x1780990
        private bool EvCmd__DUMMY_ANIME_WAIT()
        {
            //Stub
            return true;
        }

        // RVA: 0x17809B0 Offset: 0x1780AB1 VA: 0x17809B0
        private bool EvCmd_DUMMY_SET_POS()
        {
            //Stub
            return true;
        }

        // RVA: 0x1780AC0 Offset: 0x1780BC1 VA: 0x1780AC0
        private bool EvCmd_DUMMY_SET_POS_HERO()
        {
            //Stub
            return true;
        }

        // RVA: 0x1780CD0 Offset: 0x1780DD1 VA: 0x1780CD0
        private bool EvCmd_SET_CUSTUM_WIN_MSBT()
        {
            //Stub
            return true;
        }

        // RVA: 0x1780D80 Offset: 0x1780E81 VA: 0x1780D80
        private bool EvCmd_ADD_CUSTUM_WIN_LABEL()
        {
            //Stub
            return true;
        }

        // RVA: 0x1780F70 Offset: 0x1781071 VA: 0x1780F70
        private bool EvCmd_ADD_CUSTUM_WIN_LABEL_TWO_WINDOW()
        {
            //Stub
            return true;
        }

        // RVA: 0x1781240 Offset: 0x1781341 VA: 0x1781240
        private bool EvCmd_OPEN_CUSTUM_WIN()
        {
            //Stub
            return true;
        }

        // RVA: 0x1781250 Offset: 0x1781351 VA: 0x1781250
        private bool EvCmd_OPEN_CUSTUM_WIN_FIXED()
        {
            //Stub
            return true;
        }

        // RVA: 0x1781360 Offset: 0x1781461 VA: 0x1781360
        private bool EvCmd_VISIBLE_OBJ_PROP()
        {
            //Stub
            return true;
        }

        // RVA: 0x1781380 Offset: 0x1781481 VA: 0x1781380
        private bool EvCmd_INVISIBLE_OBJ_PROP()
        {
            //Stub
            return true;
        }

        // RVA: 0x17813A0 Offset: 0x17814A1 VA: 0x17813A0
        private bool EvCmd_EVENT_CAMERA_MODE()
        {
            //Stub
            return true;
        }

        // RVA: 0x17813B0 Offset: 0x17814B1 VA: 0x17813B0
        private bool EvCmd_SET_EVENT_CAMERA_PARAM()
        {
            //Stub
            return true;
        }

        // RVA: 0x17813C0 Offset: 0x17814C1 VA: 0x17813C0
        private bool EvCmd_EVENT_CAMERA_WAIT()
        {
            //Stub
            return true;
        }

        // RVA: 0x17813D0 Offset: 0x17814D1 VA: 0x17813D0
        private bool EvCmd_EVENT_CAMERA_FRAME()
        {
            //Stub
            return true;
        }

        // RVA: 0x17813E0 Offset: 0x17814E1 VA: 0x17813E0
        private bool EvCmd_HIT_DOOR_ANIME()
        {
            //Stub
            return true;
        }

        // RVA: 0x1781530 Offset: 0x1781631 VA: 0x1781530
        private bool EvCmd_HIT_DOOR_ANIME_WAIT()
        {
            //Stub
            return true;
        }

        // RVA: 0x1781610 Offset: 0x1781711 VA: 0x1781610
        private bool EvCmd_SET_DOOR_OBJ()
        {
            //Stub
            return true;
        }

        // RVA: 0x1781850 Offset: 0x1781951 VA: 0x1781850
        private bool EvCmdRotomuFormCheck()
        {
            //Stub
            return true;
        }

        // RVA: 0x1781AC0 Offset: 0x1781BC1 VA: 0x1781AC0
        private bool EvCmdRotomuFormWazaChange()
        {
            //Stub
            return true;
        }

        // RVA: 0x1781D90 Offset: 0x1781E91 VA: 0x1781D90
        private bool EvCmdTemotiRotomuFormChangeGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x1781F10 Offset: 0x1782011 VA: 0x1781F10
        private bool EvCmdTemotiPokeChkNum()
        {
            //Stub
            return true;
        }

        // RVA: 0x1782200 Offset: 0x1782301 VA: 0x1782200
        private bool EvCmdTemotiRotomuFormNoGet()
        {
            //Stub
            return true;
        }

        // RVA: 0x1782360 Offset: 0x1782461 VA: 0x1782360
        private bool EvCmdEventGetTemotiPokeChkGetPos()
        {
            //Stub
            return true;
        }

        // RVA: 0x17824A0 Offset: 0x17825A1 VA: 0x17824A0
        private bool EvCmd_TURN_HERO_TALK_OBJ()
        {
            //Stub
            return true;
        }

        // RVA: 0x17824C0 Offset: 0x17825C1 VA: 0x17824C0
        private bool EvCmd_FADE_SPEED()
        {
            //Stub
            return true;
        }

        // RVA: 0x1782550 Offset: 0x1782651 VA: 0x1782550
        private bool EvCmd_FADE_BALL()
        {
            //Stub
            return true;
        }

        // RVA: 0x1782560 Offset: 0x1782661 VA: 0x1782560
        private bool EvCmd_FADE_DEFAULT()
        {
            //Stub
            return true;
        }

        // RVA: 0x1782570 Offset: 0x1782671 VA: 0x1782570
        private bool EvCmd_DOOR_FORCE_ANIME_END()
        {
            //Stub
            return true;
        }

        // RVA: 0x17826A0 Offset: 0x17827A1 VA: 0x17826A0
        private bool EvMacro_LDVAL_VERSION()
        {
            //Stub
            return true;
        }

        // RVA: 0x1782810 Offset: 0x1782911 VA: 0x1782810
        private bool EvMacro_LDVAL_SEX()
        {
            //Stub
            return true;
        }

        // RVA: 0x1782910 Offset: 0x1782A11 VA: 0x1782910
        private bool EvCmd_DEBUG_RESET_WORK()
        {
            //Stub
            return true;
        }

        // RVA: 0x1782980 Offset: 0x1782A81 VA: 0x1782980
        private bool EvCmd_SET_SYS_FLAG()
        {
            //Stub
            return true;
        }

        // RVA: 0x17829C0 Offset: 0x1782AC1 VA: 0x17829C0
        private bool EvCmd_RESET_SYS_FLAG()
        {
            //Stub
            return true;
        }

        // RVA: 0x1782A00 Offset: 0x1782B01 VA: 0x1782A00
        private bool EvCmd_CAMERA_SET_COS_ANGLE()
        {
            //Stub
            return true;
        }

        // RVA: 0x1782AB0 Offset: 0x1782BB1 VA: 0x1782AB0
        private bool EvCmd_CAMERA_COS_ANGLE_WAIT()
        {
            //Stub
            return true;
        }

        // RVA: 0x1782AC0 Offset: 0x1782BC1 VA: 0x1782AC0
        private bool EvCmd_HERO_MOVE_GRID_CENTER_FRONT()
        {
            //Stub
            return true;
        }

        // RVA: 0x1782AD0 Offset: 0x1782BD1 VA: 0x1782AD0
        private bool EvCmd_WARP_ENABLE_SET()
        {
            //Stub
            return true;
        }

        // RVA: 0x1782D20 Offset: 0x1782E21 VA: 0x1782D20
        private bool EvCmd_DOOR_ENABLE_SET()
        {
            //Stub
            return true;
        }

        // RVA: 0x1782EE0 Offset: 0x1782FE1 VA: 0x1782EE0
        private bool EvCmd_AC_ANIM_LOCK()
        {
            //Stub
            return true;
        }

        // RVA: 0x1782FF0 Offset: 0x17830F1 VA: 0x1782FF0
        private bool EvCmd_AC_ANIM_RELEASE()
        {
            //Stub
            return true;
        }

        // RVA: 0x1783110 Offset: 0x1783211 VA: 0x1783110
        private bool EvCmd_CAMERA_SET_OFFSET()
        {
            //Stub
            return true;
        }

        // RVA: 0x17831E0 Offset: 0x17832E1 VA: 0x17831E0
        private bool EvCmd_CAMERA_OFFSET_WAIT()
        {
            //Stub
            return true;
        }

        // RVA: 0x17831F0 Offset: 0x17832F1 VA: 0x17831F0
        private bool EvCmdNaminoriEnd()
        {
            //Stub
            return true;
        }

        // RVA: 0x1783780 Offset: 0x1783881 VA: 0x1783780
        private bool EvCmdTakikudari()
        {
            //Stub
            return true;
        }

        // RVA: 0x1783AB0 Offset: 0x1783BB1 VA: 0x1783AB0
        private bool EvCmdKabeNoboriCheck()
        {
            //Stub
            return true;
        }

        // RVA: 0x1783C70 Offset: 0x1783D71 VA: 0x1783C70
        private bool EvCmdTalkPokeGetTemotiIndex()
        {
            //Stub
            return true;
        }

        // RVA: 0x1783D20 Offset: 0x1783E21 VA: 0x1783D20
        private bool EvCmdNaturalParkGetMonohiroiItemNo()
        {
            //Stub
            return true;
        }

        // RVA: 0x1783E00 Offset: 0x1783F01 VA: 0x1783E00
        private bool EvCmdNaturalParkPokeCreate()
        {
            //Stub
            return true;
        }

        // RVA: 0x1783EE0 Offset: 0x1783FE1 VA: 0x1783EE0
        private bool EvCmdNaturalParkPokeKaisan()
        {
            //Stub
            return true;
        }

        // RVA: 0x1783F80 Offset: 0x1784081 VA: 0x1783F80
        private bool EvCmdNaturalParkPokeSyuugou()
        {
            //Stub
            return true;
        }

        // RVA: 0x1784020 Offset: 0x1784121 VA: 0x1784020
        private bool EvCmdNaturalParkPokeSelectMenu()
        {
            //Stub
            return true;
        }

        // RVA: 0x17841B0 Offset: 0x17842B1 VA: 0x17841B0
        private bool EvCmdObjAnimeFureai()
        {
            //Stub
            return true;
        }

        // RVA: 0x17816C0 Offset: 0x17817C1 VA: 0x17816C0
        private FieldEventEntity FindEventEntity(string name)
        {
            //Stub
            return null;
        }

        // RVA: 0x1784340 Offset: 0x1784441 VA: 0x1784340
        private FieldEventEntity FindEventDoorEntity(string name)
        {
            //Stub
            return null;
        }

        // RVA: 0x1750D70 Offset: 0x1750E71 VA: 0x1750D70
        private bool HeroMoveGridCenterFront(float deltaTime)
        {
            //Stub
            return true;
        }

        // RVA: 0x175FBF0 Offset: 0x175FCF1 VA: 0x175FBF0
        private bool BoardReq()
        {
            //Stub
            return true;
        }

        // RVA: 0x175FE50 Offset: 0x175FF51 VA: 0x175FE50
        private bool BoardEndWait(EvWork.WORK_INDEX work)
        {
            //Stub
            return true;
        }

        // RVA: 0x1771EA0 Offset: 0x1771FA1 VA: 0x1771EA0
        private Vector3 ArgPosToPosition(int gx, int gy, int gz)
        {
            //Stub
            return null;
        }

        // RVA: 0x1764CC0 Offset: 0x1764DC1 VA: 0x1764CC0
        private bool CheckValidPokemonParam(PokemonParam param)
        {
            //Stub
            return true;
        }

        // RVA: 0x176D8F0 Offset: 0x176D9F1 VA: 0x176D8F0
        private bool CheckCanBattlePokemonParam(PokemonParam param)
        {
            //Stub
            return true;
        }

        // RVA: 0x1764070 Offset: 0x1764171 VA: 0x1764070
        private int GetPokemonFormNo(PokemonParam param)
        {
            //Stub
            return 0;
        }

        // RVA: 0x17844D0 Offset: 0x17845D1 VA: 0x17844D0
        private void TemotiBoxScan(Action<PokemonParam> action) { }

        // RVA: 0x1784580 Offset: 0x1784681 VA: 0x1784580
        private void TemotiBoxScan(Func<PokemonParam, int, int, bool> action) { }

        // RVA: 0x1774750 Offset: 0x1774851 VA: 0x1774750
        private void BoxScan(Action<PokemonParam> action) { }

        // RVA: 0x177BD90 Offset: 0x177BE91 VA: 0x177BD90
        private void BoxScan(Func<PokemonParam, int, int, bool> action) { }

        // RVA: 0x1782750 Offset: 0x1782851 VA: 0x1782750
        private int GetOriginalCassetVersion()
        {
            //Stub
            return 0;
        }

        // RVA: 0x1743E20 Offset: 0x1743F21 VA: 0x1743E20
        private DIR SetupHeroMoveGridCenterFrontDir(in RectInt stopGridArea, in Vector2Int nowGrid, in Vector2Int oldGrid)
        {
            //Stub
            return null;
        }

        // RVA: 0x1784720 Offset: 0x1784821 VA: 0x1784720
        private static bool InGridArea(in RectInt area, int x, int y)
        {
            //Stub
            return true;
        }

        // RVA: 0x17847D0 Offset: 0x17848D1 VA: 0x17847D0
        private bool EvCmdShopOpen()
        {
            //Stub
            return true;
        }

        // RVA: 0x1784B70 Offset: 0x1784C71 VA: 0x1784B70
        private bool EvCmdShopOpenWait()
        {
            //Stub
            return true;
        }

        // RVA: 0x1784B80 Offset: 0x1784C81 VA: 0x1784B80
        private bool EvCmdDoorTransitionZoneSet()
        {
            //Stub
            return true;
        }

        // RVA: 0x1784DA0 Offset: 0x1784EA1 VA: 0x1784DA0
        private bool EvCmdMoveCombatGymWall()
        {
            //Stub
            return true;
        }

        // RVA: 0x1785050 Offset: 0x1785151 VA: 0x1785050
        private bool EvCmdEventEntityPlayerMoveStart()
        {
            //Stub
            return true;
        }

        // RVA: 0x1785220 Offset: 0x1785321 VA: 0x1785220
        private bool EvCmdEventEntityPlayerMoveEnd()
        {
            //Stub
            return true;
        }

        // RVA: 0x17852F0 Offset: 0x17853F1 VA: 0x17852F0
        private bool EvCmdEventEntityPlayerMoveReset()
        {
            //Stub
            return true;
        }

        // RVA: 0x17853D0 Offset: 0x17854D1 VA: 0x17853D0
        public bool CheckCanSeedWater(int groupId)
        {
            //Stub
            return true;
        }

        // RVA: 0x1785590 Offset: 0x1785691 VA: 0x1785590
        private bool EvCmdCheckCanSeedWater()
        {
            //Stub
            return true;
        }

        // RVA: 0x1785660 Offset: 0x1785761 VA: 0x1785660
        private bool EvCmdOpenFixedShop()
        {
            //Stub
            return true;
        }

        // RVA: 0x1785800 Offset: 0x1785901 VA: 0x1785800
        private bool EvCmdOpenSealShop()
        {
            //Stub
            return true;
        }

        // RVA: 0x1785920 Offset: 0x1785A21 VA: 0x1785920
        private bool EvCmdOpenBattleParkShop()
        {
            //Stub
            return true;
        }

        // RVA: 0x1785AC0 Offset: 0x1785BC1 VA: 0x1785AC0
        private bool EvCmdOpenTobari4fShop()
        {
            //Stub
            return true;
        }

        // RVA: 0x1785C60 Offset: 0x1785D61 VA: 0x1785C60
        private bool EvCmdOpenFlowerShop()
        {
            //Stub
            return true;
        }

        // RVA: 0x1785D80 Offset: 0x1785E81 VA: 0x1785D80
        private bool EvCmdOpenOtenkiShop()
        {
            //Stub
            return true;
        }

        // RVA: 0x1785EA0 Offset: 0x1785FA1 VA: 0x1785EA0
        private bool EvCmdOpenPalParkShop()
        {
            //Stub
            return true;
        }

        // RVA: 0x1786040 Offset: 0x1786141 VA: 0x1786040
        private bool EvCmdOpenSellShop()
        {
            //Stub
            return true;
        }

        // RVA: 0x1786130 Offset: 0x1786231 VA: 0x1786130
        private bool EvCmdOpenBoutiqueShopBuy()
        {
            //Stub
            return true;
        }

        // RVA: 0x1786220 Offset: 0x1786321 VA: 0x1786220
        private bool EvCmdOpenBoutiqueShopChange()
        {
            //Stub
            return true;
        }

        // RVA: 0x1786310 Offset: 0x1786411 VA: 0x1786310
        private bool EvCmdOpenFloor()
        {
            //Stub
            return true;
        }

        // RVA: 0x17864A0 Offset: 0x17865A1 VA: 0x17864A0
        private bool EvCmdCloseFloor()
        {
            //Stub
            return true;
        }

        // RVA: 0x1786530 Offset: 0x1786631 VA: 0x1786530
        private bool EvCmdOpenMoney()
        {
            //Stub
            return true;
        }

        // RVA: 0x1786670 Offset: 0x1786771 VA: 0x1786670
        private bool EvCmdCloseMoney()
        {
            //Stub
            return true;
        }

        // RVA: 0x1786700 Offset: 0x1786801 VA: 0x1786700
        private bool EvCmdGetCostume()
        {
            //Stub
            return true;
        }

        // RVA: 0x17867A0 Offset: 0x17868A1 VA: 0x17867A0
        private bool EvCmdAnawohoru()
        {
            //Stub
            return true;
        }

        // RVA: 0x1786810 Offset: 0x1786911 VA: 0x1786810
        private bool EvCmdAnanukenohimo()
        {
            //Stub
            return true;
        }

        // RVA: 0x1786880 Offset: 0x1786981 VA: 0x1786880
        private bool EvCmdTeleport()
        {
            //Stub
            return true;
        }

        // RVA: 0x17868F0 Offset: 0x17869F1 VA: 0x17868F0
        private bool EvCmdAmaikaori()
        {
            //Stub
            return true;
        }

        // RVA: 0x17869E0 Offset: 0x1786AE1 VA: 0x17869E0
        private bool EvCmdAmaimitu()
        {
            //Stub
            return true;
        }

        // RVA: 0x1754540 Offset: 0x1754641 VA: 0x1754540
        private bool NeckRotateHero()
        {
            //Stub
            return true;
        }

        // RVA: 0x1786C60 Offset: 0x1786D61 VA: 0x1786C60
        private bool NeckOnlyRotateHero()
        {
            //Stub
            return true;
        }

        // RVA: 0x1754700 Offset: 0x1754801 VA: 0x1754700
        private bool NeckRotateTarget(bool isTurnNotFlag)
        {
            //Stub
            return true;
        }

        // RVA: 0x1786AD0 Offset: 0x1786BD1 VA: 0x1786AD0
        private bool CalcNeckRotateAngle(FieldCharacterEntity player, ref Vector3 tPos, out float angle)
        {
            //Stub
            return true;
        }

        // RVA: 0x1786E20 Offset: 0x1786F21 VA: 0x1786E20
        private bool EvCmdWarpStartAnimation()
        {
            //Stub
            return true;
        }

        // RVA: 0x1787300 Offset: 0x1787401 VA: 0x1787300
        private bool EvCmdWarpEndAnimation()
        {
            //Stub
            return true;
        }

        // RVA: 0x1787800 Offset: 0x1787901 VA: 0x1787800
        private bool EvCmdSafariScopeSequence()
        {
            //Stub
            return true;
        }

        // RVA: 0x1787AA0 Offset: 0x1787BA1 VA: 0x1787AA0
        private bool EvCmdEventCameraIndex()
        {
            if (_evArg.Length < 2)
            {
                FUNC_ThrowIndexOutOfRange();
            }

            int workNo = _evArg[1].data;
            int index;

            if (_evArg[1].argType == EvData.ArgType.Work)
            {
                index = FlagWork.GetWork(workNo);
            }
            else
            {
                index = 0;
                if (_evArg[1].argType == EvData.ArgType.Float)
                {
                    index = workNo;
                }
            }

            GameManager.fieldCamera.EventCamera.SetCameraData(_evCameraTable, index);

            return true;
        }

        // RVA: 0x1787B80 Offset: 0x1787C81 VA: 0x1787B80
        private bool EvCmdEventCameraEndWait()
        {
            //Stub
            return true;
        }

        // RVA: 0x1787BF0 Offset: 0x1787CF1 VA: 0x1787BF0
        private bool EvCmdAzukariyaExistEgg()
        {
            //Stub
            return true;
        }

        // RVA: 0x1787C90 Offset: 0x1787D91 VA: 0x1787C90
        private bool EvCmdAzukariyaStoredCount()
        {
            //Stub
            return true;
        }

        // RVA: 0x1787D30 Offset: 0x1787E31 VA: 0x1787D30
        private bool EvCmdAzukariyaSetStoredName()
        {
            //Stub
            return true;
        }

        // RVA: 0x1787EA0 Offset: 0x1787FA1 VA: 0x1787EA0
        private bool EvCmdAzukariyaStoreUI()
        {
            //Stub
            return true;
        }

        // RVA: 0x1788270 Offset: 0x1788371 VA: 0x1788270
        private bool EvCmdAzukariyaStore()
        {
            //Stub
            return true;
        }

        // RVA: 0x1788520 Offset: 0x1788621 VA: 0x1788520
        private bool EvCmdAzukariyaRestore()
        {
            //Stub
            return true;
        }

        // RVA: 0x1788690 Offset: 0x1788791 VA: 0x1788690
        private bool EvCmdAzukariyaLoveLevel()
        {
            //Stub
            return true;
        }

        // RVA: 0x1788730 Offset: 0x1788831 VA: 0x1788730
        private bool EvCmdAzukariyaGetStoredMonsNo()
        {
            //Stub
            return true;
        }

        // RVA: 0x1788850 Offset: 0x1788951 VA: 0x1788850
        private bool EvCmdAzukariyaGetEgg()
        {
            //Stub
            return true;
        }

        // RVA: 0x1788980 Offset: 0x1788A81 VA: 0x1788980
        private bool EvCmdAzukariyaDiscardEgg()
        {
            //Stub
            return true;
        }

        // RVA: 0x17889F0 Offset: 0x1788AF1 VA: 0x17889F0
        private bool EvCmdAzukariyaSetStoredInfoStr()
        {
            //Stub
            return true;
        }

        // RVA: 0x1788B30 Offset: 0x1788C31 VA: 0x1788B30
        private bool EvCmdAzukariyaGetStoredSex()
        {
            //Stub
            return true;
        }

        // RVA: 0x1788C90 Offset: 0x1788D91 VA: 0x1788C90
        private bool EvCmdAzukariyOldmanInit()
        {
            //Stub
            return true;
        }

        // RVA: 0x1788D90 Offset: 0x1788E91 VA: 0x1788D90
        private bool EvCmd_ADD_CUSTUM_WIN_LABEL_WORD_SET()
        {
            //Stub
            return true;
        }

        // RVA: 0x1788FD0 Offset: 0x17890D1 VA: 0x1788FD0
        private bool EvCmd_OPEN_CUSTUM_WIN_WORD_SET()
        {
            //Stub
            return true;
        }

        // RVA: 0x1788FE0 Offset: 0x17890E1 VA: 0x1788FE0
        private bool EvCmd_BTL_ENCSEQ_LOAD()
        {
            //Stub
            return true;
        }

        // RVA: 0x1789140 Offset: 0x1789241 VA: 0x1789140
        private bool EvCmd_UseSpray()
        {
            //Stub
            return true;
        }

        // RVA: 0x1789230 Offset: 0x1789331 VA: 0x1789230
        private bool EvCmd_GET_PLAYER_CAP()
        {
            //Stub
            return true;
        }

        // RVA: 0x1789320 Offset: 0x1789421 VA: 0x1789320
        private bool EvCmdCameraShake()
        {
            //Stub
            return true;
        }

        // RVA: 0x1789610 Offset: 0x1789711 VA: 0x1789610
        private bool EvCmdEventEntityClipPlay()
        {
            //Stub
            return true;
        }

        // RVA: 0x1789780 Offset: 0x1789881 VA: 0x1789780
        private bool EvCmdEventEntityClipWait()
        {
            //Stub
            return true;
        }

        // RVA: 0x17898A0 Offset: 0x17899A1 VA: 0x17898A0
        private bool EvCmdEventEntityAttachPlayer()
        {
            //Stub
            return true;
        }

        // RVA: 0x1789BA0 Offset: 0x1789CA1 VA: 0x1789BA0
        private bool EvCmdEventEntityVisible()
        {
            //Stub
            return true;
        }

        // RVA: 0x1789D10 Offset: 0x1789E11 VA: 0x1789D10
        private bool EvCmd_FACE_INDEX()
        {
            //Stub
            return true;
        }

        // RVA: 0x1789E80 Offset: 0x1789F81 VA: 0x1789E80
        private bool EvCmd_GROUP_EXIST_CHECK()
        {
            //Stub
            return true;
        }

        // RVA: 0x1789F30 Offset: 0x178A031 VA: 0x1789F30
        private bool EvCmd_GROUP_ENTRY_CHECK()
        {
            //Stub
            return true;
        }

        // RVA: 0x1789FD0 Offset: 0x178A0D1 VA: 0x1789FD0
        private bool EvCmd_GROUP_NAME()
        {
            //Stub
            return true;
        }

        // RVA: 0x178A1A0 Offset: 0x178A2A1 VA: 0x178A1A0
        private bool EvCmd_GROUP_LEADER_NAME()
        {
            //Stub
            return true;
        }

        // RVA: 0x178A370 Offset: 0x178A471 VA: 0x178A370
        private bool EvCmd_GROUP_NAME_IN()
        {
            //Stub
            return true;
        }

        // RVA: 0x178A590 Offset: 0x178A691 VA: 0x178A590
        private bool EvCmd_GROUP_ENTRY()
        {
            //Stub
            return true;
        }

        // RVA: 0x178A6D0 Offset: 0x178A7D1 VA: 0x178A6D0
        private bool EvCmd_GROUP_MAKE()
        {
            //Stub
            return true;
        }

        // RVA: 0x178A8B0 Offset: 0x178A9B1 VA: 0x178A8B0
        private bool EvCmdTemotiBallLoad()
        {
            //Stub
            return true;
        }

        // RVA: 0x178A8D0 Offset: 0x178A9D1 VA: 0x178A8D0
        private bool EvCmdTemotiBallLoadWait()
        {
            //Stub
            return true;
        }

        // RVA: 0x178A8E0 Offset: 0x178A9E1 VA: 0x178A8E0
        private bool EvCmdPokecenPutBall()
        {
            //Stub
            return true;
        }

        // RVA: 0x178AC90 Offset: 0x178AD91 VA: 0x178AC90
        private bool EvCmdPokecenClearBall()
        {
            //Stub
            return true;
        }

        // RVA: 0x178AF50 Offset: 0x178B051 VA: 0x178AF50
        private bool EvCmd_CHARA_LOOK_LOCK()
        {
            //Stub
            return true;
        }

        // RVA: 0x178B130 Offset: 0x178B231 VA: 0x178B130
        private bool EvCmd_CHARA_LOOK_RELEASE()
        {
            //Stub
            return true;
        }

        // RVA: 0x178B240 Offset: 0x178B341 VA: 0x178B240
        private bool EvCmd_TALK_OBJ_START_LOOK_NONE()
        {
            //Stub
            return true;
        }

        // RVA: 0x178B2F0 Offset: 0x178B3F1 VA: 0x178B2F0
        private bool EvCmdBoukennootoTipsOpen()
        {
            //Stub
            return true;
        }

        // RVA: 0x178B440 Offset: 0x178B541 VA: 0x178B440
        private bool EvCmdBoukennootoTipsOpenWait()
        {
            //Stub
            return true;
        }

        // RVA: 0x178B450 Offset: 0x178B551 VA: 0x178B450
        private bool EvCmdOpenSpecialWinLabel()
        {
            //Stub
            return true;
        }

        // RVA: 0x178C390 Offset: 0x178C491 VA: 0x178C390
        private bool EvCmdWaitSpecialWinLabel()
        {
            //Stub
            return true;
        }

        // RVA: 0x178C3F0 Offset: 0x178C4F1 VA: 0x178C3F0
        private bool EvCmdHidenEffWait()
        {
            //Stub
            return true;
        }

        // RVA: 0x178C400 Offset: 0x178C501 VA: 0x178C400
        private bool EvCmd_GET_URAYAMA_ENCOUNT_INDEX()
        {
            //Stub
            return true;
        }

        // RVA: 0x178C460 Offset: 0x178C561 VA: 0x178C460
        private bool EvCmd_CUSTOM_BALL_NUM_ADD()
        {
            //Stub
            return true;
        }

        // RVA: 0x178C530 Offset: 0x178C631 VA: 0x178C530
        private bool EvCmd_CHANGE_FASHION_REQ()
        {
            //Stub
            return true;
        }

        // RVA: 0x178CC80 Offset: 0x178CD81 VA: 0x178CC80
        private bool EvCmdWarpPanelStart()
        {
            //Stub
            return true;
        }

        // RVA: 0x178D110 Offset: 0x178D211 VA: 0x178D110
        private bool EvCmdWarpPanelEnd()
        {
            //Stub
            return true;
        }

        // RVA: 0x178D4B0 Offset: 0x178D5B1 VA: 0x178D4B0
        private bool EvCmdOpenPasswordSWKeyboard()
        {
            //Stub
            return true;
        }

        // RVA: 0x178D5B0 Offset: 0x178D6B1 VA: 0x178D5B0
        private bool EvCmdSetMatchingGroup()
        {
            //Stub
            return true;
        }

        // RVA: 0x178D660 Offset: 0x178D761 VA: 0x178D660
        public bool EvCmdCheckOnlineAccount()
        {
            //Stub
            return true;
        }

        // RVA: 0x178D7C0 Offset: 0x178D8C1 VA: 0x178D7C0
        private bool EvCmdWaitCheckOnlineAccount()
        {
            //Stub
            return true;
        }

        // RVA: 0x178D7D0 Offset: 0x178D8D1 VA: 0x178D7D0
        private bool EvCmd_DENDOU_NUM_SET()
        {
            //Stub
            return true;
        }

        // RVA: 0x178D860 Offset: 0x178D961 VA: 0x178D860
        private bool EvCmdTemotiBoxPokeChk()
        {
            //Stub
            return true;
        }

        // RVA: 0x178DA30 Offset: 0x178DB31 VA: 0x178DA30
        private bool EvCmdTemotiBoxMonsNo()
        {
            //Stub
            return true;
        }

        // RVA: 0x1763FA0 Offset: 0x17640A1 VA: 0x1763FA0
        private PokemonParam GetPokemonParam(int trayIndex, int index)
        {
            //Stub
            return null;
        }

        // RVA: 0x178DB90 Offset: 0x178DC91 VA: 0x178DB90
        private bool EvCmdCallWazaOmoidashiUi()
        {
            //Stub
            return true;
        }

        // RVA: 0x178DEB0 Offset: 0x178DFB1 VA: 0x178DEB0
        private bool EvCmdCallWazaWasureUi()
        {
            //Stub
            return true;
        }

        // RVA: 0x178E050 Offset: 0x178E151 VA: 0x178E050
        private bool EvCmdCallWazaOshieUi()
        {
            //Stub
            return true;
        }

        // RVA: 0x178DCF0 Offset: 0x178DDF1 VA: 0x178DCF0
        private bool CallWazaUiCommon(UIWazaManage.BootType bootType, PokemonParam pokemonParam, Action<WazaNo, WazaNo> resultCallback, WazaNo oshieWazaNo = 0)
        {
            //Stub
            return true;
        }

        // RVA: 0x178E230 Offset: 0x178E331 VA: 0x178E230
        private void LearnWaza(PokemonParam param, WazaNo learnWazaNo, WazaNo unlearnWazaNo) { }

        // RVA: 0x178E290 Offset: 0x178E391 VA: 0x178E290
        private bool EvCmdCheckWazaOshie()
        {
            //Stub
            return true;
        }

        // RVA: 0x178E520 Offset: 0x178E621 VA: 0x178E520
        private bool EvCmdCheckWazaOshieAll()
        {
            //Stub
            return true;
        }

        // RVA: 0x178E470 Offset: 0x178E571 VA: 0x178E470
        private EvDataManager.WazaOshieResult CheckWazaOshie(PokemonParam param, WazaNo oshieWazaNo)
        {
            //Stub
            return null;
        }

        // RVA: 0x178E650 Offset: 0x178E751 VA: 0x178E650
        private bool EvCmdTemotiBoxPokemonName()
        {
            //Stub
            return true;
        }

        // RVA: 0x178E7F0 Offset: 0x178E8F1 VA: 0x178E7F0
        private bool EvCmd_BTWR_TOOL_CHK_ENTRY_POKE_NUM()
        {
            //Stub
            return true;
        }

        // RVA: 0x178E800 Offset: 0x178E901 VA: 0x178E800
        private bool EvCmd_BTWR_TOOL_CLEAR_PLAY_DATA()
        {
            //Stub
            return true;
        }

        // RVA: 0x178E820 Offset: 0x178E921 VA: 0x178E820
        private bool EvCmd_BTWR_TOOL_PUSH_NOW_LOCATION()
        {
            //Stub
            return true;
        }

        // RVA: 0x178EA80 Offset: 0x178EB81 VA: 0x178EA80
        private bool EvCmd_BTWR_TOOL_POP_NOW_LOCATION()
        {
            //Stub
            return true;
        }

        // RVA: 0x178EC80 Offset: 0x178ED81 VA: 0x178EC80
        private bool EvCmd_BTWR_TOOL_GET_WIFI_RANK()
        {
            //Stub
            return true;
        }

        // RVA: 0x178EC90 Offset: 0x178ED91 VA: 0x178EC90
        private bool EvCmd_BTWR_TOOL_SET_PLAY_MODE()
        {
            //Stub
            return true;
        }

        // RVA: 0x178ED00 Offset: 0x178EE01 VA: 0x178ED00
        private bool EvCmd_BTWR_TOOL_SET_NOW_WIN()
        {
            //Stub
            return true;
        }

        // RVA: 0x178ED90 Offset: 0x178EE91 VA: 0x178ED90
        private bool EvCmd_BTWR_TOOL_SET_RANK()
        {
            //Stub
            return true;
        }

        // RVA: 0x178EE70 Offset: 0x178EF71 VA: 0x178EE70
        private bool EvCmd_BTWR_SUB_GET_RANK()
        {
            //Stub
            return true;
        }

        // RVA: 0x178EF00 Offset: 0x178F001 VA: 0x178EF00
        private bool EvCmd_BTWR_SUB_RANK_DOWN_LOSE()
        {
            //Stub
            return true;
        }

        // RVA: 0x178EF90 Offset: 0x178F091 VA: 0x178EF90
        private bool EvCmd_BTWR_SUB_RANK_DOWN_LOSE_RESET()
        {
            //Stub
            return true;
        }

        // RVA: 0x178F000 Offset: 0x178F101 VA: 0x178F000
        private bool EvCmd_BTWR_SUB_ADD_LOSE()
        {
            //Stub
            return true;
        }

        // RVA: 0x178F100 Offset: 0x178F201 VA: 0x178F100
        private bool EvCmd_BTWR_SUB_CHK_ENTRY_POKE()
        {
            //Stub
            return true;
        }

        // RVA: 0x178F110 Offset: 0x178F211 VA: 0x178F110
        private bool EvCmd_BTWR_SUB_GET_NOW_ROUND()
        {
            //Stub
            return true;
        }

        // RVA: 0x178F170 Offset: 0x178F271 VA: 0x178F170
        private bool EvCmd_BTWR_SUB_INC_ROUND()
        {
            //Stub
            return true;
        }

        // RVA: 0x178F220 Offset: 0x178F321 VA: 0x178F220
        private bool EvCmd_BTWR_SUB_IS_CLEAR()
        {
            //Stub
            return true;
        }

        // RVA: 0x178F280 Offset: 0x178F381 VA: 0x178F280
        private bool EvCmd_BTWR_SUB_GET_RENSHOU_CNT()
        {
            //Stub
            return true;
        }

        // RVA: 0x178F2E0 Offset: 0x178F3E1 VA: 0x178F2E0
        private bool EvCmd_BTWR_SUB_SET_SCORE()
        {
            //Stub
            return true;
        }

        // RVA: 0x178F300 Offset: 0x178F401 VA: 0x178F300
        private bool EvCmd_BTWR_SUB_CHOICE_BTL_PARTNER()
        {
            //Stub
            return true;
        }

        // RVA: 0x178F310 Offset: 0x178F411 VA: 0x178F310
        private bool EvCmd_BTWR_SUB_LOCAL_BTL_CALL()
        {
            //Stub
            return true;
        }

        // RVA: 0x178F830 Offset: 0x178F931 VA: 0x178F830
        private bool EvCmd_BTWR_SUB_GET_PLAY_MODE()
        {
            //Stub
            return true;
        }

        // RVA: 0x178F890 Offset: 0x178F991 VA: 0x178F890
        private bool EvCmd_BTWR_SUB_SET_LEADER_CLEAR_FLAG()
        {
            //Stub
            return true;
        }

        // RVA: 0x178F8A0 Offset: 0x178F9A1 VA: 0x178F8A0
        private bool EvCmd_BTWR_SUB_GET_LEADER_CLEAR_FLAG()
        {
            //Stub
            return true;
        }

        // RVA: 0x178F8B0 Offset: 0x178F9B1 VA: 0x178F8B0
        private bool EvCmd_BTWR_SUB_ADD_BATTLE_POINT()
        {
            //Stub
            return true;
        }

        // RVA: 0x178F9F0 Offset: 0x178FAF1 VA: 0x178F9F0
        private bool EvCmd_BTWR_SUB_RENSHOU_RIBBON_SET()
        {
            //Stub
            return true;
        }

        // RVA: 0x178FBB0 Offset: 0x178FCB1 VA: 0x178FBB0
        private bool EvCmd_BTWR_SUB_GET_MINE_OBJ()
        {
            //Stub
            return true;
        }

        // RVA: 0x178FBC0 Offset: 0x178FCC1 VA: 0x178FBC0
        private bool EvCmd_BTWR_SUB_UPDATE_RANDOM()
        {
            //Stub
            return true;
        }

        // RVA: 0x178FBE0 Offset: 0x178FCE1 VA: 0x178FBE0
        private bool EvCmd_BTWR_DEB_IS_WORK_NULL()
        {
            //Stub
            return true;
        }

        // RVA: 0x178FBF0 Offset: 0x178FCF1 VA: 0x178FBF0
        private bool EvCmd_BTWR_SUB_BTL_TRAINER_SET()
        {
            //Stub
            return true;
        }

        // RVA: 0x178FC00 Offset: 0x178FD01 VA: 0x178FC00
        private bool EvCmd_BTWR_PLAYER_WIN_CHECK()
        {
            //Stub
            return true;
        }

        // RVA: 0x178FC50 Offset: 0x178FD51 VA: 0x178FC50
        private bool EvCmd_BTWR_SUB_ADD_BATTLE_POINT_MANUAL()
        {
            //Stub
            return true;
        }

        // RVA: 0x178FD40 Offset: 0x178FE41 VA: 0x178FD40
        private bool EvCmdSaveRendouEnable()
        {
            //Stub
            return true;
        }

        // RVA: 0x178FDE0 Offset: 0x178FEE1 VA: 0x178FDE0
        private bool EvCmd_RETURN_LOOP()
        {
            //Stub
            return true;
        }

        // RVA: 0x178FE80 Offset: 0x178FF81 VA: 0x178FE80
        private bool EvCmd_INPUT_JUMP()
        {
            //Stub
            return true;
        }

        // RVA: 0x178FFA0 Offset: 0x17900A1 VA: 0x178FFA0
        private bool EvCmd_SET_VISIBILITY()
        {
            //Stub
            return true;
        }

        // RVA: 0x1790270 Offset: 0x1790371 VA: 0x1790270
        private void ChangeVisibility(FieldCharacterEntity entity, int type, bool flag) { }

        // RVA: 0x1790290 Offset: 0x1790391 VA: 0x1790290
        private bool EvCmd_LOAD_CAMERA_CONTROLLER()
        {
            //Stub
            return true;
        }

        // RVA: 0x1790370 Offset: 0x1790471 VA: 0x1790370
        private bool EvCmd_RELEASE_CAMERA_CONTROLLER()
        {
            //Stub
            return true;
        }

        // RVA: 0x17903D0 Offset: 0x17904D1 VA: 0x17903D0
        private bool EvCmd_LOAD_WAIT_CAMERA_CONTROLLER()
        {
            //Stub
            return true;
        }

        // RVA: 0x1790430 Offset: 0x1790531 VA: 0x1790430
        private bool EvCmd_CAMERA_CONTROLLER_PLAY()
        {
            if (_evArg.Length < 2)
            {
                FUNC_ThrowIndexOutOfRange();
                return true;
            }

            string statename = "";
            if (_evArg[1].argType == EvData.ArgType.String)
            {
                statename = _evData.EvData.GetString(_evArg[1].data);
            }

            FieldAnimeCamera.instance.Play(statename);
            return true;
        }

        // RVA: 0x1790510 Offset: 0x1790611 VA: 0x1790510
        private bool EvCmd_CAMERA_CONTROLLER_WAIT()
        {
            //Stub
            return true;
        }

        // RVA: 0x1790610 Offset: 0x1790711 VA: 0x1790610
        private bool EvCmd_CAMERA_CONTROLLER_END()
        {
            //Stub
            return true;
        }

        // RVA: 0x1790670 Offset: 0x1790771 VA: 0x1790670
        private bool EvCmd_TUREARUKI_POKEMON_TALK()
        {
            //Stub
            return true;
        }

        // RVA: 0x1790850 Offset: 0x1790951 VA: 0x1790850
        private bool EvCmd_TUREARUKI_POKEMON_INDEX()
        {
            //Stub
            return true;
        }

        // RVA: 0x1790940 Offset: 0x1790A41 VA: 0x1790940
        private bool EvCmd_TUREARUKI_TAKE_ITEM()
        {
            //Stub
            return true;
        }

        // RVA: 0x1790A00 Offset: 0x1790B01 VA: 0x1790A00
        private bool EvCmd_TUREARUKI_ITEM_TIMER_SET()
        {
            //Stub
            return true;
        }

        // RVA: 0x1790A10 Offset: 0x1790B11 VA: 0x1790A10
        private bool EvCmd_TUREARUKI_POKE_CREATE()
        {
            //Stub
            return true;
        }

        // RVA: 0x1790AD0 Offset: 0x1790BD1 VA: 0x1790AD0
        private bool EvCmd_TUREARUKI_POKE_DELETE()
        {
            //Stub
            return true;
        }

        // RVA: 0x1790C10 Offset: 0x1790D11 VA: 0x1790C10
        private bool EvCmd_FIND_BG_ENABLE()
        {
            //Stub
            return true;
        }

        // RVA: 0x1790DD0 Offset: 0x1790ED1 VA: 0x1790DD0
        private bool EvCmd_FIND_BG_DISABLE()
        {
            //Stub
            return true;
        }

        // RVA: 0x1790F90 Offset: 0x1791091 VA: 0x1790F90
        private bool EvCmd_CALL_EFFECT()
        {
            // Stub
            return true;
        }

        // RVA: 0x17913A0 Offset: 0x17914A1 VA: 0x17913A0
        private bool EvCmd_STOP_EFFECT()
        {
            // Stub
            return true;
        }

        // RVA: 0x1791540 Offset: 0x1791641 VA: 0x1791540
        public bool EvCmd_RELEASE_EFFECT()
        {
            // Stub
            return true;
        }

        // RVA: 0x1791690 Offset: 0x1791791 VA: 0x1791690
        private bool EvCmd_CALL_EFFECT_OBJ()
        {
            // Stub
            return true;
        }

        // RVA: 0x1791A30 Offset: 0x1791B31 VA: 0x1791A30
        private bool EvCmd_EFF_SCALE()
        {
            // Stub
            return true;
        }

        // RVA: 0x1791D70 Offset: 0x1791E71 VA: 0x1791D70
        private IEnumerator<int> EffScaleAnime(int index, float min, float max, float spd)
        {
            // Stub
            return null;
        }

        // RVA: 0x1791E20 Offset: 0x1791F21 VA: 0x1791E20
        private bool EvCmd_POKELIST_FORM_CHANGE_SET_PROC()
        {
            // Stub
            return true;
        }

        // RVA: 0x1792170 Offset: 0x1792271 VA: 0x1792170
        private bool EvCmd_POKELIST_FORM_CHANGE_GET_RESULT()
        {
            // Stub
            return true;
        }

        // RVA: 0x17921C0 Offset: 0x17922C1 VA: 0x17921C0
        private bool EvCmd_CASSET_VERSION_GET()
        {
            // Stub
            return true;
        }

        // RVA: 0x17922E0 Offset: 0x17923E1 VA: 0x17922E0
        private bool EvCmd_BOX_OPEN_NORMAL()
        {
            // Stub
            return true;
        }

        // RVA: 0x1792380 Offset: 0x1792481 VA: 0x1792380
        private bool EvCmd_BOX_OPEN_SELECT()
        {
            // Stub
            return true;
        }

        // RVA: 0x1792500 Offset: 0x1792601 VA: 0x1792500
        private bool EvCmd_AK_LISNER_TRA()
        {
            // Stub
            return true;
        }

        // RVA: 0x1792670 Offset: 0x1792771 VA: 0x1792670
        private bool EvCmd_AK_LISNER_POS()
        {
            // Stub
            return true;
        }

        // RVA: 0x17928B0 Offset: 0x17929B1 VA: 0x17928B0
        private bool EvCmd_AK_LISNER_ROT()
        {
            // Stub
            return true;
        }

        // RVA: 0x1792B00 Offset: 0x1792C01 VA: 0x1792B00
        private bool EvCmd_SET_TV_INT()
        {
            // Stub
            return true;
        }

        // RVA: 0x1792C30 Offset: 0x1792D31 VA: 0x1792C30
        private bool EvCmd_SET_TV_PLAYER_NAME()
        {
            // Stub
            return true;
        }

        // RVA: 0x1792D30 Offset: 0x1792E31 VA: 0x1792D30
        private bool EvCmd_SET_TV_POKE_NICK_NAME()
        {
            // Stub
            return true;
        }

        // RVA: 0x1792E40 Offset: 0x1792F41 VA: 0x1792E40
        private bool EvCmd_TV_TPIC_ENABLE()
        {
            // Stub
            return true;
        }

        // RVA: 0x1792F10 Offset: 0x1793011 VA: 0x1792F10
        private bool EvCmd_TV_TPIC_BRANCH()
        {
            // Stub
            return true;
        }

        // RVA: 0x1793040 Offset: 0x1793141 VA: 0x1793040
        private bool EvCmd_AUTO_TANKEN_SET()
        {
            // Stub
            return true;
        }

        // RVA: 0x17931B0 Offset: 0x17932B1 VA: 0x17931B0
        private bool EvCmd_AUTO_TANKEN_SET_WAIT()
        {
            // Stub
            return true;
        }

        // RVA: 0x1793200 Offset: 0x1793301 VA: 0x1793200
        private bool EvCmd_USE_TANKENSET()
        {
            // Stub
            return true;
        }

        // RVA: 0x1793440 Offset: 0x1793541 VA: 0x1793440
        private bool EvCmd_LOCALKOUKAN_APPLY()
        {
            // Stub
            return true;
        }

        // RVA: 0x17938E0 Offset: 0x17939E1 VA: 0x17938E0
        private bool EvCmd_ZUKAN_TOUROKU()
        {
            // Stub
            return true;
        }

        // RVA: 0x1793B90 Offset: 0x1793C91 VA: 0x1793B90
        private bool EvCmd_ZUKAN_TOUROKU_WAIT()
        {
            // Stub
            return true;
        }

        // RVA: 0x1793BE0 Offset: 0x1793CE1 VA: 0x1793BE0
        private bool EvCmd_CHK_ZUKAN_TOUROKU()
        {
            // Stub
            return true;
        }

        // RVA: 0x1793DA0 Offset: 0x1793EA1 VA: 0x1793DA0
        private bool EvCmd_AUTO_SAVE()
        {
            // Stub
            return true;
        }

        // RVA: 0x1793F90 Offset: 0x1794091 VA: 0x1793F90
        private bool EvCmd_AUTO_SAVE_BACK_UP_ON()
        {
            // Stub
            return true;
        }

        // RVA: 0x1794180 Offset: 0x1794281 VA: 0x1794180
        private bool EvCmd_ENDING_DEMO()
        {
            // Stub
            return true;
        }

        // RVA: 0x1794270 Offset: 0x1794371 VA: 0x1794270
        private bool EvCmdAzukariyaTakeOverPoke()
        {
            // Stub
            return true;
        }

        // RVA: 0x1794460 Offset: 0x1794561 VA: 0x1794460
        private bool EvCmd_TALK_UNION_NPC()
        {
            // Stub
            return true;
        }

        // RVA: 0x1794650 Offset: 0x1794751 VA: 0x1794650
        private bool EvCmd_TALK_COLISEUM_NPC()
        {
            // Stub
            return true;
        }

        // RVA: 0x1794840 Offset: 0x1794941 VA: 0x1794840
        private bool EvCmd_POKETORE_GET_CHARGE()
        {
            // Stub
            return true;
        }

        // RVA: 0x1794910 Offset: 0x1794A11 VA: 0x1794910
        private bool EvCmd_POKETORE_START()
        {
            // Stub
            return true;
        }

        // RVA: 0x1794DC0 Offset: 0x1794EC1 VA: 0x1794DC0
        private bool EvCmd_BICYCLE_COLOR_SET()
        {
            // Stub
            return true;
        }

        // RVA: 0x1794FC0 Offset: 0x17950C1 VA: 0x1794FC0
        private bool EvCmd_BICYCLE_COLOR_GET()
        {
            // Stub
            return true;
        }

        // RVA: 0x1795060 Offset: 0x1795161 VA: 0x1795060
        private bool EvCmd_PARK_ITEM_NAME()
        {
            // Stub
            return true;
        }

        // RVA: 0x17951F0 Offset: 0x17952F1 VA: 0x17951F0
        private bool EvCmd_LOAD_UMA_ANIME()
        {
            // Stub
            return true;
        }

        // RVA: 0x1795300 Offset: 0x1795401 VA: 0x1795300
        private IEnumerator<int> LoadUMAAsset()
        {
            // Stub
            return null;
        }

        // RVA: 0x1795380 Offset: 0x1795481 VA: 0x1795380
        private bool EvCmd_RELEASE_UMA_ANIME()
        {
            // Stub
            return true;
        }

        // RVA: 0x1795500 Offset: 0x1795601 VA: 0x1795500
        private bool EvCmd_LOAD_UMA_ANIME_WAIT()
        {
            // Stub
            return true;
        }

        // RVA: 0x1795600 Offset: 0x1795701 VA: 0x1795600
        private bool EvCmd_UMA_ANIME_PLAY()
        {
            // Stub
            return true;
        }

        // RVA: 0x1795730 Offset: 0x1795831 VA: 0x1795730
        private bool EvCmd_UMA_ANIME_ATTACH()
        {
            // Stub
            return true;
        }

        // RVA: 0x17958D0 Offset: 0x17959D1 VA: 0x17958D0
        private bool EvCmd_UMA_PLAY_WAIT()
        {
            // Stub
            return true;
        }

        // RVA: 0x1795A30 Offset: 0x1795B31 VA: 0x1795A30
        private bool EvCmd_OBJ_ANIME_SPEED()
        {
            // Stub
            return true;
        }

        // RVA: 0x1795C70 Offset: 0x1795D71 VA: 0x1795C70
        private bool EvCmd_OBJ_SCALE()
        {
            // Stub
            return true;
        }

        // RVA: 0x1795F50 Offset: 0x1796051 VA: 0x1795F50
        private bool EvCmd_BADGE_GET()
        {
            // Stub
            return true;
        }

        // RVA: 0x1796090 Offset: 0x1796191 VA: 0x1796090
        private bool EvCmdAddUgItem()
        {
            // Stub
            return true;
        }

        // RVA: 0x17961E0 Offset: 0x17962E1 VA: 0x17961E0
        private bool EvCmd_DOF_FAR_DEPTH()
        {
            // Stub
            return true;
        }

        // RVA: 0x1796300 Offset: 0x1796401 VA: 0x1796300
        private bool EvCmd_DISPLAY_MESSAGE()
        {
            // Stub
            return true;
        }

        // RVA: 0x17964C0 Offset: 0x17965C1 VA: 0x17964C0
        private bool EvCmd_DISPLAY_MESSAGE_CLOSE()
        {
            // Stub
            return true;
        }

        // RVA: 0x1796530 Offset: 0x1796631 VA: 0x1796530
        private bool EvCmdCustomBallTrainerPage()
        {
            // Stub
            return true;
        }

        // RVA: 0x1796710 Offset: 0x1796811 VA: 0x1796710
        private bool EvCmdCustomBallTrainerCopyOpen()
        {
            // Stub
            return true;
        }

        // RVA: 0x1796930 Offset: 0x1796A31 VA: 0x1796930
        private bool EvCmdUgItemName()
        {
            // Stub
            return true;
        }

        // RVA: 0x1796AC0 Offset: 0x1796BC1 VA: 0x1796AC0
        private bool EvCmdFureaiTalkStart()
        {
            // Stub
            return true;
        }

        // RVA: 0x1796BA0 Offset: 0x1796CA1 VA: 0x1796BA0
        private bool EvCmdFureaiTalkEnd()
        {
            // Stub
            return true;
        }

        // RVA: 0x1796BB0 Offset: 0x1796CB1 VA: 0x1796BB0
        private bool EvCmdPlayFureaiVoiceNakayoshiRank()
        {
            // Stub
            return true;
        }

        // RVA: 0x1796C90 Offset: 0x1796D91 VA: 0x1796C90
        private bool EvCmdCreateHyouta()
        {
            // Stub
            return true;
        }

        // RVA: 0x1796F00 Offset: 0x1797001 VA: 0x1796F00
        private bool EvCmd_FADE_DUNGEON_OUT()
        {
            // Stub
            return true;
        }

        // RVA: 0x1796F80 Offset: 0x1797081 VA: 0x1796F80
        private bool EvCmd_FADE_DUNGEON_IN()
        {
            // Stub
            return true;
        }

        // RVA: 0x1797000 Offset: 0x1797101 VA: 0x1797000
        private bool EvCmd_FADE_BUILDING_OUT()
        {
            // Stub
            return true;
        }

        // RVA: 0x1797080 Offset: 0x1797181 VA: 0x1797080
        private bool EvCmd_FADE_BUILDING_IN()
        {
            // Stub
            return true;
        }

        // RVA: 0x1797100 Offset: 0x1797201 VA: 0x1797100
        private bool EvCmd_FADE_AREA_OUT()
        {
            // Stub
            return true;
        }

        // RVA: 0x17971E0 Offset: 0x17972E1 VA: 0x17971E0
        private bool EvCmd_FADE_AREA_IN()
        {
            // Stub
            return true;
        }

        // RVA: 0x17972C0 Offset: 0x17973C1 VA: 0x17972C0
        private bool EvCmdCustomBallTrainerOpenWait()
        {
            // Stub
            return true;
        }

        // RVA: 0x17972D0 Offset: 0x17973D1 VA: 0x17972D0
        private bool EvCmd_EMBANKMENT()
        {
            // Stub
            return true;
        }

        // RVA: 0x17973B0 Offset: 0x17974B1 VA: 0x17973B0
        private bool EvCmdEntryUwasaZukan()
        {
            // Stub
            return true;
        }

        // RVA: 0x17974C0 Offset: 0x17975C1 VA: 0x17974C0
        private bool EvCmdTrainingOpen()
        {
            // Stub
            return true;
        }

        // RVA: 0x1797800 Offset: 0x1797901 VA: 0x1797800
        private bool EvCmdTrainingOpenWait()
        {
            // Stub
            return true;
        }

        // RVA: 0x1797860 Offset: 0x1797961 VA: 0x1797860
        private bool EvCmdTalkUgNpc()
        {
            // Stub
            return true;
        }

        // RVA: 0x17979A0 Offset: 0x1797AA1 VA: 0x17979A0
        private bool EvCmd_CAMERA_CONTROLLER_IS_NULL()
        {
            // Stub
            return true;
        }

        // RVA: 0x1797A30 Offset: 0x1797B31 VA: 0x1797A30
        private bool EvCmd_UMA_IS_NULL()
        {
            // Stub
            return true;
        }

        // RVA: 0x1797B70 Offset: 0x1797C71 VA: 0x1797B70
        private bool EvCmdGetIsHaveSecretBase()
        {
            // Stub
            return true;
        }

        // RVA: 0x1797C20 Offset: 0x1797D21 VA: 0x1797C20
        private bool EvCmdGetUgNpcTalkCount()
        {
            // Stub
            return true;
        }

        // RVA: 0x1797CC0 Offset: 0x1797DC1 VA: 0x1797CC0
        private bool EvCmdResetUgNpcTalkCount()
        {
            // Stub
            return true;
        }

        // RVA: 0x1797D30 Offset: 0x1797E31 VA: 0x1797D30
        private bool EvCmd_TEMOTI_POKE_CHK_GET_POS()
        {
            // Stub
            return true;
        }

        // RVA: 0x1797EB0 Offset: 0x1797FB1 VA: 0x1797EB0
        private bool EvCmd_SET_FORCE_BLINK()
        {
            // Stub
            return true;
        }

        // RVA: 0x1798020 Offset: 0x1798121 VA: 0x1798020
        private bool EvCmd_CheckSecretBaseExpantion()
        {
            // Stub
            return true;
        }

        // RVA: 0x1798140 Offset: 0x1798241 VA: 0x1798140
        private bool EvCmd_END_LIGHTINTENSITY()
        {
            // Stub
            return true;
        }

        // RVA: 0x1798180 Offset: 0x1798281 VA: 0x1798180
        private bool EvCmd_END_LIGHTINTENSITY_CHARCTER()
        {
            // Stub
            return true;
        }

        // RVA: 0x17981C0 Offset: 0x17982C1 VA: 0x17981C0
        private bool EvCmd_END_LIGHTINTENSITY_POKE()
        {
            // Stub
            return true;
        }

        // RVA: 0x1798200 Offset: 0x1798301 VA: 0x1798200
        private bool EvCmd_SET_LIGHTINTENSITY()
        {
            // Stub
            return true;
        }

        // RVA: 0x1798740 Offset: 0x1798841 VA: 0x1798740
        private bool EvCmd_SET_LIGHTINTENSITY_CHARCTER()
        {
            // Stub
            return true;
        }

        // RVA: 0x1798CB0 Offset: 0x1798DB1 VA: 0x1798CB0
        private bool EvCmd_SET_LIGHTINTENSITY_POKE()
        {
            // Stub
            return true;
        }

        // RVA: 0x1799220 Offset: 0x1799321 VA: 0x1799220
        private void EnvironmentControllerSetLight(EnvironmentController controller, float deltaTime) { }

        // RVA: 0x1799560 Offset: 0x1799661 VA: 0x1799560
        private void EnvironmentControllerSetLightCharacter(EnvironmentController controller, float deltaTime) { }

        // RVA: 0x1799710 Offset: 0x1799811 VA: 0x1799710
        private void EnvironmentControllerSetLightPoke(EnvironmentController controller, float deltaTime) { }

        // RVA: 0x17993D0 Offset: 0x17994D1 VA: 0x17993D0
        private bool EnviromentLightUpdate(int index, float deltaTime, out float ret)
        {
            // Stub
            ret = 0;
            return true;
        }

        // RVA: 0x17998C0 Offset: 0x17999C1 VA: 0x17998C0
        private bool EvCmd_TV_RED_GYARADOS_ON()
        {
            // Stub
            return true;
        }

        // RVA: 0x1799970 Offset: 0x1799A71 VA: 0x1799970
        private bool EvCmd_TV_RED_GYARADOS_OFF()
        {
            // Stub
            return true;
        }

        // RVA: 0x1799A20 Offset: 0x1799B21 VA: 0x1799A20
        private bool EvCmd_AUTO_MSG()
        {
            // Stub
            return true;
        }

        // RVA: 0x1799B10 Offset: 0x1799C11 VA: 0x1799B10
        private bool EvCmd_AUTO_MSG_STOP()
        {
            // Stub
            return true;
        }

        // RVA: 0x1799B20 Offset: 0x1799C21 VA: 0x1799B20
        private bool EvCmd_GET_TAG_PATNER_ID()
        {
            // Stub
            return true;
        }

        // RVA: 0x1799BD0 Offset: 0x1799CD1 VA: 0x1799BD0
        private bool EvCmd_UNIQUE_POKE_TEMP()
        {
            // Stub
            return true;
        }

        // RVA: 0x1799C60 Offset: 0x1799D61 VA: 0x1799C60
        private bool EvCmd_UNIQUE_POKE_FIX()
        {
            // Stub
            return true;
        }

        // RVA: 0x1799D80 Offset: 0x1799E81 VA: 0x1799D80
        private bool EvCmd_NICKNAME_PLACEMENT()
        {
            // Stub
            return true;
        }

        // RVA: 0x1799EF0 Offset: 0x1799FF1 VA: 0x1799EF0
        private bool EvCmd_GET_FORM()
        {
            // Stub
            return true;
        }

        // RVA: 0x1767BA0 Offset: 0x1767CA1 VA: 0x1767BA0
        private void CreateTurearuki() { }

        // RVA: 0x174E5E0 Offset: 0x174E6E1 VA: 0x174E5E0
        private void DeleteTurearuki() { }

        // RVA: 0x1799FF0 Offset: 0x179A0F1 VA: 0x1799FF0
        private bool EvCmd_NICK_NAME_ALL()
        {
            // Stub
            return true;
        }

        // RVA: 0x179A1C0 Offset: 0x179A2C1 VA: 0x179A1C0
        private bool EvCmd_DOF_CHANGE_TARGET_POS()
        {
            // Stub
            return true;
        }

        // RVA: 0x179A350 Offset: 0x179A451 VA: 0x179A350
        private bool EvCmd_DOF_RESET_TARGET_POS()
        {
            // Stub
            return true;
        }

        // RVA: 0x179A3D0 Offset: 0x179A4D1 VA: 0x179A3D0
        private bool EvCmd_ADD_MAROYAKA_POFFIN()
        {
            // Stub
            return true;
        }

        // RVA: 0x179A4B0 Offset: 0x179A5B1 VA: 0x179A4B0
        private bool EvCmd_ALL_MONSNO()
        {
            // Stub
            return true;
        }

        // RVA: 0x179A660 Offset: 0x179A761 VA: 0x179A660
        private bool EvCmd_ALL_MONS_OWN_CHK()
        {
            // Stub
            return true;
        }

        // RVA: 0x179A810 Offset: 0x179A911 VA: 0x179A810
        private bool EvCmd_POKE_LVUP_HOW_MANY()
        {
            // Stub
            return true;
        }

        // RVA: 0x179A940 Offset: 0x179AA41 VA: 0x179A940
        private bool EvCmd_USE_SPECIAL_ITEM()
        {
            // Stub
            return true;
        }

        // RVA: 0x179AC00 Offset: 0x179AD01 VA: 0x179AC00
        private bool EvCmd_GET_BP()
        {
            // Stub
            return true;
        }

        // RVA: 0x179AC60 Offset: 0x179AD61 VA: 0x179AC60
        private bool EvCmd_FOV_OFFSET_RATE()
        {
            // Stub
            return true;
        }

        // RVA: 0x179ADA0 Offset: 0x179AEA1 VA: 0x179ADA0
        private bool EvCmd_USE_SUB_ATTRIBUTE()
        {
            // Stub
            return true;
        }

        // RVA: 0x179AE10 Offset: 0x179AF11 VA: 0x179AE10
        private bool EvCmd_POKE_LEVEL_GET_ALL()
        {
            // Stub
            return true;
        }

        // RVA: 0x179AFC0 Offset: 0x179B0C1 VA: 0x179AFC0
        private bool EvCmd_RESET_SAVEBGM()
        {
            // Stub
            return true;
        }

        // RVA: 0x179B0A0 Offset: 0x179B1A1 VA: 0x179B0A0
        private bool EvCmd_BTWR_SUB_SELECT_POKE()
        {
            // Stub
            return true;
        }

        // RVA: 0x179B3B0 Offset: 0x179B4B1 VA: 0x179B3B0
        private bool EvCmd_BTWR_SUB_GET_ENTRY_POKE()
        {
            // Stub
            return true;
        }

        // RVA: 0x179B450 Offset: 0x179B551 VA: 0x179B450
        private bool EvCmd_SET_GLOBALWATERFIELD()
        {
            // Stub
            return true;
        }

        // RVA: 0x179B520 Offset: 0x179B621 VA: 0x179B520
        private bool EvCmd_GET_STATUENUM()
        {
            // Stub
            return true;
        }

        // RVA: 0x179B5C0 Offset: 0x179B6C1 VA: 0x179B5C0
        private bool EvCmdGetFureaiSelectPokeTemotiNo()
        {
            // Stub
            return true;
        }

        // RVA: 0x179B670 Offset: 0x179B771 VA: 0x179B670
        private bool EvCmd_POKE_TARENT_POW_MAX()
        {
            // Stub
            return true;
        }

        // RVA: 0x179B810 Offset: 0x179B911 VA: 0x179B810
        private bool EvCmd_OPEN_BATTLE_WIN()
        {
            // Stub
            return true;
        }

        // RVA: 0x179BA00 Offset: 0x179BB01 VA: 0x179BA00
        private IEnumerator<int> LoadBattleWindow(Action onLoad)
        {
            // Stub
            return null;
        }

        // RVA: 0x179BA80 Offset: 0x179BB81 VA: 0x179BA80
        private void OpenBattleWindow() { }

        // RVA: 0x179BBF0 Offset: 0x179BCF1 VA: 0x179BBF0
        private bool EvCmd_OJIGI()
        {
            // Stub
            return true;
        }

        // RVA: 0x179BE80 Offset: 0x179BF81 VA: 0x179BE80
        private bool OjibiCallback(AnimationPlayer anime)
        {
            // Stub
            return true;
        }

        // RVA: 0x179BEC0 Offset: 0x179BFC1 VA: 0x179BEC0
        private bool EvCmdSavePlayReport()
        {
            // Stub
            return true;
        }

        // RVA: 0x179BF90 Offset: 0x179C091 VA: 0x179BF90
        private bool EvCmd_SET_STOP_EYE_ENCOUNT()
        {
            // Stub
            return true;
        }

        // RVA: 0x179BFC0 Offset: 0x179C0C1 VA: 0x179BFC0
        private bool EvCmd_RESET_STOP_EYE_ENCOUNT()
        {
            // Stub
            return true;
        }

        // RVA: 0x179BFF0 Offset: 0x179C0F1 VA: 0x179BFF0
        private bool EvCmd_PLAY_REPORT_TRAINING()
        {
            // Stub
            return true;
        }

        // RVA: 0x1742790 Offset: 0x1742891 VA: 0x1742790
        private bool EvCmd_PLAY_REPORT_BTLTOWER_WIN()
        {
            // Stub
            return true;
        }

        // RVA: 0x1757790 Offset: 0x1757891 VA: 0x1757790
        private bool RunEvCmd(EvCmdID.NAME index)
        {

            bool result;
            if (index < EvCmdID.NAME.CMD_NAME_END)
            {
                switch (index)
                {
                    case EvCmdID.NAME._NOP:
                    case EvCmdID.NAME._END:
                        {
                            FUNC_EndScript();
                            return true;
                        }

                    case EvCmdID.NAME._TIME_WAIT:
                        {
                            return EvCmdTimeWait();
                        }

                    case EvCmdID.NAME._CMPWK:
                        {
                            EvCmdCmpWkWk();
                            return true;
                        }

                    case EvCmdID.NAME._CHG_COMMON_SCR:
                    case EvCmdID.NAME._CALL:
                        {
                            if (_evArg.Length < 2)
                            {
                                FUNC_ThrowIndexOutOfRange();
                                return true;
                            }
                            string label = "";
                            if (_evArg[1].argType == EvData.ArgType.String)
                            {
                                label = _evData.EvData.GetString(_evArg[1].data);
                            }
                            CallLabel(label);
                            return true;
                        }

                    case EvCmdID.NAME._CHG_LOCAL_SCR:
                    case EvCmdID.NAME._RET:
                        {
                            bool retResult = ReturnEvData();
                            if (!retResult)
                            {
                                FUNC_EndScript();
                            }
                            return true;
                        }

                    case EvCmdID.NAME._JUMP:
                        {
                            if (_evArg.Length < 2)
                            {
                                FUNC_ThrowIndexOutOfRange();
                                return true;
                            }
                            string label = "";
                            if (_evArg[1].argType == EvData.ArgType.String)
                            {
                                label = _evData.EvData.GetString(_evArg[1].data);
                            }
                            JumpLabel(label, null);
                            return true;
                        }

                    case EvCmdID.NAME._IF_JUMP:
                        {
                            EvCmdIfJump();
                            return true;
                        }

                    case EvCmdID.NAME._IF_CALL:
                        {
                            EvCmdIfCall();
                            return true;
                        }

                    case EvCmdID.NAME._IFVAL_JUMP:
                    case EvCmdID.NAME._IFWK_JUMP:
                        {
                            EvMacro_IFVAL_JUMP();
                            return true;
                        }

                    case EvCmdID.NAME._IFVAL_CALL:
                    case EvCmdID.NAME._IFWK_CALL:
                        {
                            EvMacro_IFVAL_CALL();
                            return true;
                        }

                    case EvCmdID.NAME._SWITCH:
                        {
                            // This is presumed. The ghidra decomp is so hard to understand here
                            if (_evArg.Length < 2)
                            {
                                FUNC_ThrowIndexOutOfRange();
                                return true;
                            }
                            _switch_work_index = _evArg[1].data;
                            return true;
                        }

                    case EvCmdID.NAME._CASE_JUMP:
                        {
                            EvMacro_CASE_JUMP();
                            return true;
                        }

                    case EvCmdID.NAME._CASE_CANCEL:
                        {
                            EvMacro_CASE_CANCEL();
                            return true;
                        }

                    case EvCmdID.NAME._FLAG_SET:
                        {
                            EvCmdFlagSet();
                            return true;
                        }

                    case EvCmdID.NAME._ARRIVE_FLAG_SET:
                        {
                            if (_evArg.Length < 2)
                            {
                                FUNC_ThrowIndexOutOfRange();
                                return true;
                            }
                            SetSysFlag(_evArg[1].data, true);
                            return true;
                        }

                    case EvCmdID.NAME._FLAG_RESET:
                        {
                            if (_evArg.Length < 2)
                            {
                                FUNC_ThrowIndexOutOfRange();
                                return true;
                            }
                            int flagNo = _evArg[1].data;
                            if (flagNo > -1)
                            {
                                FlagWork.SetFlag(flagNo, false);
                            }
                            return true;
                        }

                    case EvCmdID.NAME._FLAG_CHECK:
                        {
                            if (_evArg.Length < 2)
                            {
                                FUNC_ThrowIndexOutOfRange();
                                return true;
                            }
                            int flagNo = _evArg[1].data;
                            if ((flagNo < 0) || (flagNo == (int)EvWork.FLAG_INDEX.FLAG_END_SAVE_SIZE) || !FlagWork.GetFlag(flagNo))
                            {
                                _cmp_flag = CmpResult.EQUAL;
                            }
                            else
                            {
                                _cmp_flag = CmpResult.MINUS;
                            }
                            return true;
                        }

                    case EvCmdID.NAME._IF_FLAGON_JUMP:
                        {
                            EvMacro_IF_FLAGON_JUMP();
                            return true;
                        }

                    case EvCmdID.NAME._IF_FLAGOFF_JUMP:
                        {
                            EvMacro_IF_FLAGOFF_JUMP();
                            return true;
                        }

                    case EvCmdID.NAME._IF_FLAGON_CALL:
                        {
                            EvMacro_IF_FLAGON_CALL();
                            return true;
                        }

                    case EvCmdID.NAME._IF_FLAGOFF_CALL:
                        {
                            EvMacro_IF_FLAGOFF_CALL();
                            return true;
                        }

                    case EvCmdID.NAME._FLAG_CHECK_WK:
                        {
                            EvCmdFlagCheckWk();
                            return true;
                        }

                    case EvCmdID.NAME._EVENT_CAMERA_INDEX:
                        {
                            EvCmdEventCameraIndex();
                            return true;
                        }

                    case EvCmdID.NAME._CAMERA_CONTROLLER_PLAY:
                        {
                            EvCmd_CAMERA_CONTROLLER_PLAY();
                            return true;
                        }

                    default:
                        {
                            return true;
                        }
                }
            }
            return true;
        }

        private void FUNC_ThrowIndexOutOfRange()
        {
            throw new IndexOutOfRangeException("System");
        }

        private void FUNC_ThrowInvalidCast(object obj)
        {
            throw new InvalidCastException("System");
        }

        private void FUNC_EndScript()
        {
            SetCloudScaleEnd();
            _eventListIndex = -1;
        }

        // RVA: 0x1748930 Offset: 0x1748A31 VA: 0x1748930
        private bool WarpSegmentHitCheck(FieldEventDoorEntity entity, out Vector3 reusltPosition, out float subtendedAngle, out float lineDistance, float hitrange)
        {
            // Stub
            reusltPosition = null;
            subtendedAngle = 0;
            lineDistance = 0;
            return true;
        }

        // RVA: 0x1747F90 Offset: 0x1748091 VA: 0x1747F90
        private void SegmentHit(ref Vector2 segA, ref Vector2 segB, ref Vector2 targetPos, float radius, out float angleAT, out float angleBT, out float distance, out int hitstatus)
        {
            // Stub
            angleAT = 0;
            angleBT = 0;
            distance = 0;
            hitstatus = 0;
        }

        // RVA: 0x179C070 Offset: 0x179C171 VA: 0x179C070
        public void InitScriptLoad() { }

        // RVA: 0x179C150 Offset: 0x179C251 VA: 0x179C150
        public bool InitScriptLoadWait()
        {
            // Stub
            return true;
        }

        // RVA: 0x179C400 Offset: 0x179C501 VA: 0x179C400
        public void InitScriptEnd() { }

        // RVA: 0x179C590 Offset: 0x179C691 VA: 0x179C590
        private bool IsRockclimbLabel(string label)
        {
            // Stub
            return true;
        }

        // RVA: 0x179C5F0 Offset: 0x179C6F1 VA: 0x179C5F0
        public void SaveDataReflection() { }

        // RVA: 0x1743190 Offset: 0x1743291 VA: 0x1743190
        public void SetSaveObj() { }

        // RVA: 0x179CD00 Offset: 0x179CE01 VA: 0x179CD00
        public void SetupGimmickEntity() { }

        // RVA: 0x173E400 Offset: 0x173E501 VA: 0x173E400
        public void SceneStartGimmickEntity() { }

        // RVA: 0x173F2F0 Offset: 0x173F3F1 VA: 0x173F2F0
        public static void PlayHoneyTreeAnimation(ZoneID zoneId) { }

        // RVA: 0x173CA90 Offset: 0x173CB91 VA: 0x173CA90
        private void CreateWorpPoint() { }

        // RVA: 0x179D710 Offset: 0x179D811 VA: 0x179D710
        private FieldEventDoorEntity CreateWarpEntity(MapWarp.SheetData data, int[] index, Vector2 size, int[] locator)
        {
            // Stub
            return null;
        }

        // RVA: 0x179D9E0 Offset: 0x179DAE1 VA: 0x179D9E0
        public IEnumerator<int> RequestAssetSetUp(AreaID areaid)
        {
            // Stub
            return null;
        }

        // RVA: 0x179DA70 Offset: 0x179DB71 VA: 0x179DA70
        public IEnumerator<int> PreRequestAssetSetUp(AreaID areaid)
        {
            // Stub
            return null;
        }

        // RVA: 0x179DAE0 Offset: 0x179DBE1 VA: 0x179DAE0
        private void SetSaveDataParam(ref EvDataManager.LoadObjectData lodata) { }

        // RVA: 0x179DBE0 Offset: 0x179DCE1 VA: 0x179DBE0
        public void SetCreateParent(Transform parent) { }

        // RVA: 0x179DBF0 Offset: 0x179DCF1 VA: 0x179DBF0
        public void SortLoadObjectData(Vector2Int grid) { }

        // RVA: 0x179DED0 Offset: 0x179DFD1 VA: 0x179DED0
        public IEnumerator<int> StartUpCreate()
        {
            // Stub
            return null;
        }

        // RVA: 0x179DF50 Offset: 0x179E051 VA: 0x179DF50
        public void UpdateCreate() { }

        // RVA: 0x179E090 Offset: 0x179E191 VA: 0x179E090
        public void Init_PokemonCenter() { }

        // RVA: 0x179E0A0 Offset: 0x179E1A1 VA: 0x179E0A0
        public void Init_FieldShip() { }

        // RVA: 0x179E0B0 Offset: 0x179E1B1 VA: 0x179E0B0
        public bool RefCountZeroUnload()
        {
            // Stub
            return true;
        }

        // RVA: 0x179E4C0 Offset: 0x179E5C1 VA: 0x179E4C0
        public bool ForceUnload()
        {
            // Stub
            return true;
        }

        // RVA: 0x179E6C0 Offset: 0x179E7C1 VA: 0x179E6C0
        public bool IsLoadAssetBundle()
        {
            // Stub
            return true;
        }

        // RVA: 0x179E070 Offset: 0x179E171 VA: 0x179E070
        private void LoadObjectCreate(EvDataManager.LoadObjectData lodata) { }

        // RVA: 0x179E810 Offset: 0x179E911 VA: 0x179E810
        private void LoadObjectCreate_BOX(EvDataManager.LoadObjectData lodata) { }

        // RVA: 0x179EBA0 Offset: 0x179ECA1 VA: 0x179EBA0
        private void LoadObjectCreate_Asset(EvDataManager.LoadObjectData lodata) { }

        // RVA: 0x179FD40 Offset: 0x179FE41 VA: 0x179FD40
        private void LoadObjectCreate_KinomiGrow(KinomiPlaceData.SheetSheet1 kinomiPlaceData) { }

        // RVA: 0x179FC80 Offset: 0x179FD81 VA: 0x179FC80
        public int FieldObjectEntityAdd(FieldObjectEntity entity)
        {
            // Stub
            return 0;
        }

        // RVA: 0x17A0060 Offset: 0x17A0161 VA: 0x17A0060
        public void FieldObjectEntityRemove(FieldObjectEntity entity) { }

        private enum CmpResult
        {
            MINUS = 0,
            EQUAL = 1,
            PLUS = 2
        }

        public class EntityParam
        {
	        public string TalkLabel; // 0x10
            public string ContactLabel; // 0x18
            public int VanishFlagIndex; // 0x20
            public bool IsContact; // 0x24
            public EvWork.WORK_INDEX WorkIndex; // 0x28
            public int WorkValue; // 0x2C
            public EvDataManager.EntityType Type; // 0x30
            public RectInt StopGridArea; // 0x34
            public bool IsEventRunning; // 0x44
            public int MoveCodeIndex; // 0x48
            public bool Kairiki; // 0x4C
            public bool Iwakudaki; // 0x4D
            public bool Iaigiri; // 0x4E
            public bool Rockclimb; // 0x4F
            public int Dowsing; // 0x50
            public bool SnowBall; // 0x54
            public bool AzukariyaOldMan; // 0x55
            public bool HoneyTree; // 0x56
            public bool HeightIgnore; // 0x57
            public Vector2 ContactSize; // 0x58
            public bool IsContactCenter; // 0x60
            public bool Sit; // 0x61
            public int IdleAnimOverride; // 0x64
            public int WalkAnimOverride; // 0x68
            public TrainerID TrainerID; // 0x6C
            public int FieldObjectIndex; // 0x70
            public int[] NearObject; // 0x78
            public const int NearNone = -10;
            public float TalkRange; // 0x80
            public bool isTalkHit; // 0x84
            public float TalkAngle; // 0x88
            public bool SaveObject; // 0x8C
            public ZoneID LocaitionZoneID; // 0x90
            public bool IsObject; // 0x94
            public Vector2 TalkSegment; // 0x98
            public byte TalkBit; // 0xA0
            public int CharacterGraphicsIndex; // 0xA4
            public bool BattleReturnNotRotate; // 0xA8
        }

        private struct EvCallData
        {
	        public int EventListIndex; // 0x0
            public int LabelIndex; // 0x4
            public int CommandIndex; // 0x8
        }

        public delegate void EventEndDelegate();
    }
}
