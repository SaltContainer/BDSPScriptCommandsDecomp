using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace BDSP
{
    public class GameManager //: SingletonMonoBehaviour<GameManager>
    {
		public const long ticksPerDay = 864000000000;
		public const long ticksPerSecond = 10000000;
		private Transform _fieldObjectHolder; // 0x18
		private Transform _battleObjectHolder; // 0x20
		private GameObject _licenseTextObject; // 0x28
		private GameObject _errorTextObject; // 0x30
		private TextMeshProUGUI _officeTextUGUI; // 0x38
		private TextMeshProUGUI _userTextUGUI; // 0x40
		private string _securityFileName; // 0x48
		private string _primarySecurityKey; // 0x50
		private string _secondarySecurityKey; // 0x58
		private PokemonData _debugPokemonData; // 0x60
		private GameSettings gameSettings; // 0x68
		public static SceneConnector connector; // 0x0
		private static bool <isReady>k__BackingField; // 0x8
		private static bool <afterStarting>k__BackingField; // 0x9
		private static bool <playEnding>k__BackingField; // 0xA
		private static DateTime _nowTime; // 0x10
		private static long <tickOffset>k__BackingField; // 0x18
		private static long <timeScale>k__BackingField; // 0x20
		private static bool <pause>k__BackingField; // 0x28
		private AreaID _cacheAreaID; // 0x70
		private SceneID _targetSceneID; // 0x74
		private Coroutine _loadingOperation; // 0x78
		private bool _switchingNow; // 0x80
		public static FieldCamera fieldCamera; // 0x30
		public static bool isControllable; // 0x38
		public static bool useSubAttribute; // 0x39

		// Properties
		public static Transform fieldObjectHolder { get; }
		public static Transform battleObjectHolder { get; }
		public static bool isReady { get; set; }
		public static MapInfo mapInfo { get; }
		public static ArenaInfo arenaInfo { get; }
		public static CalenderEncTable calenderEncTable { get; }
		public static FieldEncountTable fieldEncountTable { get; }
		public static WaterSettings waterSettings { get; }
		public static bool afterStarting { get; set; }
		public static bool playEnding { get; set; }
		public static DateTime nowTime { get; set; }
		public static long tickOffset { get; set; }
		public static long timeScale { get; set; }
		public static bool pause { get; set; }
		public static float elapsedTimeOfDay { get; }
		public static PeriodOfDay currentPeriodOfDay { get; }
		public static ValueTuple<PeriodOfDay, float, float> currentPeriodOfDayEx { get; }
		public static PokemonData debugPokemonData { get; }

		// Methods

		// RVA: 0x1A72BD0 Offset: 0x1A72CD1 VA: 0x1A72BD0
		public static FieldEncountTable.Sheettable GetFieldEncountData(ZoneID zoneid) { }

		// RVA: 0x1A72D40 Offset: 0x1A72E41 VA: 0x1A72D40
		public static FieldEncountTable.Sheethoneytree[] GetHoneyTreeEncountLotteryTable() { }

		// RVA: 0x1A72E20 Offset: 0x1A72F21 VA: 0x1A72E20
		public static FieldEncountTable.Sheetmistu[] GetHoneyTreeEncountTable() { }

		// RVA: 0x1A72F00 Offset: 0x1A73001 VA: 0x1A72F00
		public static MonsNo GetSafariMonsNo(int index) { }

		// RVA: 0x1A73010 Offset: 0x1A73111 VA: 0x1A73010
		public static MonsNo GetUrayamaMonsNo(int index) { }

		[AssetAssistantInitializeMethodAttribute] // RVA: 0xA0080 Offset: 0xA0181 VA: 0xA0080
												  // RVA: 0x1A73120 Offset: 0x1A73221 VA: 0x1A73120
		private static void Initialize() { }

		[IteratorStateMachineAttribute] // RVA: 0xA00A0 Offset: 0xA01A1 VA: 0xA00A0
										// RVA: 0x1A73410 Offset: 0x1A73511 VA: 0x1A73410
		private static IEnumerator OnetimeInitializeOperation() { }

		// RVA: 0x1A734A0 Offset: 0x1A735A1 VA: 0x1A734A0
		public static void ReloadLanguege(MessageEnumData.MsgLangId unloadLangId, UnityAction<bool> onLoaded) { }

		// RVA: 0x1A73670 Offset: 0x1A73771 VA: 0x1A73670
		public static void AfterInitialize(GameManager.AfterInitType type, MessageEnumData.MsgLangId unloadLangId, UnityAction<GameManager.AfterLoadState> onLoaded) { }

		// RVA: 0x1A73770 Offset: 0x1A73871 VA: 0x1A73770
		private static void CheckDebugPause(float deltaTime) { }

		// RVA: 0x1A73780 Offset: 0x1A73881 VA: 0x1A73780
		private void OnUpdate(float deltaTime) { }

		[IteratorStateMachineAttribute] // RVA: 0xA0110 Offset: 0xA0211 VA: 0xA0110
										// RVA: 0x1A73DC0 Offset: 0x1A73EC1 VA: 0x1A73DC0
		private IEnumerator SceneSwitchingOperation() { }

		// RVA: 0x1A73E70 Offset: 0x1A73F71 VA: 0x1A73E70
		private void UpdateTargetScene() { }

		// RVA: 0x1A74980 Offset: 0x1A74A81 VA: 0x1A74980
		private void OnEnable() { }

		// RVA: 0x1A74990 Offset: 0x1A74A91 VA: 0x1A74990
		private void OnDisable() { }

		// RVA: 0x1A749A0 Offset: 0x1A74AA1 VA: 0x1A749A0
		private void OnDestroy() { }

		// RVA: 0x1A74BF0 Offset: 0x1A74CF1 VA: 0x1A74BF0
		public static AttributeMatrix GetMapAttributeMattrix() { }

		// RVA: 0x1A74E10 Offset: 0x1A74F11 VA: 0x1A74E10
		public static AttributeMatrix GetMapAttributeExMattrix() { }

		// RVA: 0x1A75030 Offset: 0x1A75131 VA: 0x1A75030
		public static void GetAttribute(Vector2Int grid, out int code, out int stop, bool debugdraw = False) { }

		// RVA: 0x1A752E0 Offset: 0x1A753E1 VA: 0x1A752E0
		public static MapAttributeTable.SheetData GetAttributeTable(int code) { }

		// RVA: 0x1A75120 Offset: 0x1A75221 VA: 0x1A75120
		public static void GetAttribute(AttributeMatrix attributes, Vector2Int grid, out int code, out int stop, bool debugdraw = False) { }

		// RVA: 0x1A75380 Offset: 0x1A75481 VA: 0x1A75380
		public static MapAttributeExTable.SheetData GetAttributeEx(Vector2Int grid, float height, bool debugdraw = False) { }

		// RVA: 0x1A75710 Offset: 0x1A75811 VA: 0x1A75710
		public static int GetAttributeExCodeRaw(Vector2Int grid) { }

		// RVA: 0x1A759C0 Offset: 0x1A75AC1 VA: 0x1A759C0
		public static bool IsHighAttribute(int attriRaw, float height) { }

		// RVA: 0x1A758E0 Offset: 0x1A759E1 VA: 0x1A758E0
		public static int HeightAttribute(int attri, float height) { }

		// RVA: 0x1A75A00 Offset: 0x1A75B01 VA: 0x1A75A00
		public static ZoneID GetGridZoneID(Vector2Int pos) { }

		// RVA: 0x1A75BD0 Offset: 0x1A75CD1 VA: 0x1A75BD0
		private static void SetAssetBundleMemory() { }

		// RVA: 0x1A75CF0 Offset: 0x1A75DF1 VA: 0x1A75CF0
		public static bool CPU_BOOST_ON() { }

		// RVA: 0x1A75FA0 Offset: 0x1A760A1 VA: 0x1A75FA0
		public static bool CPU_BOOST_OFF() { }
	}
}
