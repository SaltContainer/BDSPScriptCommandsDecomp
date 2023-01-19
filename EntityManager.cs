using System;
using System.Collections.Generic;
using System.Text;

namespace BDSP
{
	static class EntityManager // TypeDefIndex: 4005
	{
		// Fields
		private static List<BaseEntity> _baseEntities; // 0x0
		[CompilerGeneratedAttribute] // RVA: 0x7EE70 Offset: 0x7EF71 VA: 0x7EE70
		private static BattlePlayerEntity<activeBattlePlayer> k__BackingField; // 0x8
		[CompilerGeneratedAttribute] // RVA: 0x7EE80 Offset: 0x7EF81 VA: 0x7EE80
		private static FieldPlayerEntity<activeFieldPlayer> k__BackingField; // 0x10
		[CompilerGeneratedAttribute] // RVA: 0x7EE90 Offset: 0x7EF91 VA: 0x7EE90
		private static FieldPokemonEntity<activeFieldPartner> k__BackingField; // 0x18
		[CompilerGeneratedAttribute] // RVA: 0x7EEA0 Offset: 0x7EFA1 VA: 0x7EEA0
		private static FieldPlayerEntity[] <fieldPlayers>k__BackingField; // 0x20
	[CompilerGeneratedAttribute] // RVA: 0x7EEB0 Offset: 0x7EFB1 VA: 0x7EEB0
		private static FieldPokemonEntity[] <fieldPokemons>k__BackingField; // 0x28
	[CompilerGeneratedAttribute] // RVA: 0x7EEC0 Offset: 0x7EFC1 VA: 0x7EEC0
		private static FieldCharacterEntity[] <fieldCharacters>k__BackingField; // 0x30
	[CompilerGeneratedAttribute] // RVA: 0x7EED0 Offset: 0x7EFD1 VA: 0x7EED0
		private static FieldObjectEntity[] <fieldObjects>k__BackingField; // 0x38
	[CompilerGeneratedAttribute] // RVA: 0x7EEE0 Offset: 0x7EFE1 VA: 0x7EEE0
		private static FieldEventEntity[] <fieldEventObjects>k__BackingField; // 0x40
	[CompilerGeneratedAttribute] // RVA: 0x7EEF0 Offset: 0x7EFF1 VA: 0x7EEF0
		private static FieldEventDoorEntity[] <fieldDoorObjects>k__BackingField; // 0x48
	[CompilerGeneratedAttribute] // RVA: 0x7EF00 Offset: 0x7F001 VA: 0x7EF00
		private static FieldEventLiftEntity[] <fieldLiftObjects>k__BackingField; // 0x50
	[CompilerGeneratedAttribute] // RVA: 0x7EF10 Offset: 0x7F011 VA: 0x7EF10
		private static FieldTobariGymWallEntity[] <fieldTobariGymWalls>k__BackingField; // 0x58
	[CompilerGeneratedAttribute] // RVA: 0x7EF20 Offset: 0x7F021 VA: 0x7EF20
		private static FieldNagisaGymGearEntity[] <fieldNagisaGymGears>k__BackingField; // 0x60
	[CompilerGeneratedAttribute] // RVA: 0x7EF30 Offset: 0x7F031 VA: 0x7EF30
		private static FieldNomoseGymWaterEntity[] <fieldNomoseGymWater>k__BackingField; // 0x68
	[CompilerGeneratedAttribute] // RVA: 0x7EF40 Offset: 0x7F041 VA: 0x7EF40
		private static FieldNomoseGymSwitchEntity[] <fieldNomoseGymSwitches>k__BackingField; // 0x70
	[CompilerGeneratedAttribute] // RVA: 0x7EF50 Offset: 0x7F051 VA: 0x7EF50
		private static FieldElevatorBackgroundEntity[] <fieldElevatorBackground>k__BackingField; // 0x78
	[CompilerGeneratedAttribute] // RVA: 0x7EF60 Offset: 0x7F061 VA: 0x7EF60
		private static FieldPokemonCenterEntity[] <fieldPokemonCenter>k__BackingField; // 0x80
	[CompilerGeneratedAttribute] // RVA: 0x7EF70 Offset: 0x7F071 VA: 0x7EF70
		private static FieldPokemonCenterMonitorEntity[] <fieldPokemonCenterMonitor>k__BackingField; // 0x88
	[CompilerGeneratedAttribute] // RVA: 0x7EF80 Offset: 0x7F081 VA: 0x7EF80
		private static FieldEventTrainEntity[] <fieldEventTrain>k__BackingField; // 0x90
	[CompilerGeneratedAttribute] // RVA: 0x7EF90 Offset: 0x7F091 VA: 0x7EF90
		private static FieldEyePaintingEntity[] <fieldEyePainting>k__BackingField; // 0x98
	[CompilerGeneratedAttribute] // RVA: 0x7EFA0 Offset: 0x7F0A1 VA: 0x7EFA0
		private static FieldEmbankmentEntity[] <fieldEmbankment>k__BackingField; // 0xA0
	[CompilerGeneratedAttribute] // RVA: 0x7EFB0 Offset: 0x7F0B1 VA: 0x7EFB0
		private static FieldTvEntity[] <fieldTv>k__BackingField; // 0xA8

	// Properties
	public static BattlePlayerEntity activeBattlePlayer { get; set; }
		public static FieldPlayerEntity activeFieldPlayer { get; set; }
		public static FieldPokemonEntity activeFieldPartner { get; set; }
		public static FieldPlayerEntity[] fieldPlayers { get; set; }
		public static FieldPokemonEntity[] fieldPokemons { get; set; }
		public static FieldCharacterEntity[] fieldCharacters { get; set; }
		public static FieldObjectEntity[] fieldObjects { get; set; }
		public static FieldEventEntity[] fieldEventObjects { get; set; }
		public static FieldEventDoorEntity[] fieldDoorObjects { get; set; }
		public static FieldEventLiftEntity[] fieldLiftObjects { get; set; }
		public static FieldTobariGymWallEntity[] fieldTobariGymWalls { get; set; }
		public static FieldNagisaGymGearEntity[] fieldNagisaGymGears { get; set; }
		public static FieldNomoseGymWaterEntity[] fieldNomoseGymWater { get; set; }
		public static FieldNomoseGymSwitchEntity[] fieldNomoseGymSwitches { get; set; }
		public static FieldElevatorBackgroundEntity[] fieldElevatorBackground { get; set; }
		public static FieldPokemonCenterEntity[] fieldPokemonCenter { get; set; }
		public static FieldPokemonCenterMonitorEntity[] fieldPokemonCenterMonitor { get; set; }
		public static FieldEventTrainEntity[] fieldEventTrain { get; set; }
		public static FieldEyePaintingEntity[] fieldEyePainting { get; set; }
		public static FieldEmbankmentEntity[] fieldEmbankment { get; set; }
		public static FieldTvEntity[] fieldTv { get; set; }

		// Methods

		[CompilerGeneratedAttribute] // RVA: 0x9F1C0 Offset: 0x9F2C1 VA: 0x9F1C0
									 // RVA: 0x1F74BD0 Offset: 0x1F74CD1 VA: 0x1F74BD0
		public static BattlePlayerEntity get_activeBattlePlayer() { }

		[CompilerGeneratedAttribute] // RVA: 0x9F1D0 Offset: 0x9F2D1 VA: 0x9F1D0
									 // RVA: 0x1F74C40 Offset: 0x1F74D41 VA: 0x1F74C40
		public static void set_activeBattlePlayer(BattlePlayerEntity value) { }

		[CompilerGeneratedAttribute] // RVA: 0x9F1E0 Offset: 0x9F2E1 VA: 0x9F1E0
									 // RVA: 0x1F74CB0 Offset: 0x1F74DB1 VA: 0x1F74CB0
		public static FieldPlayerEntity get_activeFieldPlayer() { }

		[CompilerGeneratedAttribute] // RVA: 0x9F1F0 Offset: 0x9F2F1 VA: 0x9F1F0
									 // RVA: 0x1F74D20 Offset: 0x1F74E21 VA: 0x1F74D20
		public static void set_activeFieldPlayer(FieldPlayerEntity value) { }

		[CompilerGeneratedAttribute] // RVA: 0x9F200 Offset: 0x9F301 VA: 0x9F200
									 // RVA: 0x1F74D90 Offset: 0x1F74E91 VA: 0x1F74D90
		public static FieldPokemonEntity get_activeFieldPartner() { }

		[CompilerGeneratedAttribute] // RVA: 0x9F210 Offset: 0x9F311 VA: 0x9F210
									 // RVA: 0x1F74E00 Offset: 0x1F74F01 VA: 0x1F74E00
		public static void set_activeFieldPartner(FieldPokemonEntity value) { }

		[CompilerGeneratedAttribute] // RVA: 0x9F220 Offset: 0x9F321 VA: 0x9F220
									 // RVA: 0x1F74E70 Offset: 0x1F74F71 VA: 0x1F74E70
		public static FieldPlayerEntity[] get_fieldPlayers() { }

		[CompilerGeneratedAttribute] // RVA: 0x9F230 Offset: 0x9F331 VA: 0x9F230
									 // RVA: 0x1F74EE0 Offset: 0x1F74FE1 VA: 0x1F74EE0
		private static void set_fieldPlayers(FieldPlayerEntity[] value) { }

		[CompilerGeneratedAttribute] // RVA: 0x9F240 Offset: 0x9F341 VA: 0x9F240
									 // RVA: 0x1F74F50 Offset: 0x1F75051 VA: 0x1F74F50
		public static FieldPokemonEntity[] get_fieldPokemons() { }

		[CompilerGeneratedAttribute] // RVA: 0x9F250 Offset: 0x9F351 VA: 0x9F250
									 // RVA: 0x1F74FC0 Offset: 0x1F750C1 VA: 0x1F74FC0
		private static void set_fieldPokemons(FieldPokemonEntity[] value) { }

		[CompilerGeneratedAttribute] // RVA: 0x9F260 Offset: 0x9F361 VA: 0x9F260
									 // RVA: 0x1F75030 Offset: 0x1F75131 VA: 0x1F75030
		public static FieldCharacterEntity[] get_fieldCharacters() { }

		[CompilerGeneratedAttribute] // RVA: 0x9F270 Offset: 0x9F371 VA: 0x9F270
									 // RVA: 0x1F750A0 Offset: 0x1F751A1 VA: 0x1F750A0
		private static void set_fieldCharacters(FieldCharacterEntity[] value) { }

		[CompilerGeneratedAttribute] // RVA: 0x9F280 Offset: 0x9F381 VA: 0x9F280
									 // RVA: 0x1F75110 Offset: 0x1F75211 VA: 0x1F75110
		public static FieldObjectEntity[] get_fieldObjects() { }

		[CompilerGeneratedAttribute] // RVA: 0x9F290 Offset: 0x9F391 VA: 0x9F290
									 // RVA: 0x1F75180 Offset: 0x1F75281 VA: 0x1F75180
		private static void set_fieldObjects(FieldObjectEntity[] value) { }

		[CompilerGeneratedAttribute] // RVA: 0x9F2A0 Offset: 0x9F3A1 VA: 0x9F2A0
									 // RVA: 0x1F751F0 Offset: 0x1F752F1 VA: 0x1F751F0
		public static FieldEventEntity[] get_fieldEventObjects() { }

		[CompilerGeneratedAttribute] // RVA: 0x9F2B0 Offset: 0x9F3B1 VA: 0x9F2B0
									 // RVA: 0x1F75260 Offset: 0x1F75361 VA: 0x1F75260
		private static void set_fieldEventObjects(FieldEventEntity[] value) { }

		[CompilerGeneratedAttribute] // RVA: 0x9F2C0 Offset: 0x9F3C1 VA: 0x9F2C0
									 // RVA: 0x1F752D0 Offset: 0x1F753D1 VA: 0x1F752D0
		public static FieldEventDoorEntity[] get_fieldDoorObjects() { }

		[CompilerGeneratedAttribute] // RVA: 0x9F2D0 Offset: 0x9F3D1 VA: 0x9F2D0
									 // RVA: 0x1F75340 Offset: 0x1F75441 VA: 0x1F75340
		private static void set_fieldDoorObjects(FieldEventDoorEntity[] value) { }

		[CompilerGeneratedAttribute] // RVA: 0x9F2E0 Offset: 0x9F3E1 VA: 0x9F2E0
									 // RVA: 0x1F753B0 Offset: 0x1F754B1 VA: 0x1F753B0
		public static FieldEventLiftEntity[] get_fieldLiftObjects() { }

		[CompilerGeneratedAttribute] // RVA: 0x9F2F0 Offset: 0x9F3F1 VA: 0x9F2F0
									 // RVA: 0x1F75420 Offset: 0x1F75521 VA: 0x1F75420
		private static void set_fieldLiftObjects(FieldEventLiftEntity[] value) { }

		[CompilerGeneratedAttribute] // RVA: 0x9F300 Offset: 0x9F401 VA: 0x9F300
									 // RVA: 0x1F75490 Offset: 0x1F75591 VA: 0x1F75490
		public static FieldTobariGymWallEntity[] get_fieldTobariGymWalls() { }

		[CompilerGeneratedAttribute] // RVA: 0x9F310 Offset: 0x9F411 VA: 0x9F310
									 // RVA: 0x1F75500 Offset: 0x1F75601 VA: 0x1F75500
		private static void set_fieldTobariGymWalls(FieldTobariGymWallEntity[] value) { }

		[CompilerGeneratedAttribute] // RVA: 0x9F320 Offset: 0x9F421 VA: 0x9F320
									 // RVA: 0x1F75570 Offset: 0x1F75671 VA: 0x1F75570
		public static FieldNagisaGymGearEntity[] get_fieldNagisaGymGears() { }

		[CompilerGeneratedAttribute] // RVA: 0x9F330 Offset: 0x9F431 VA: 0x9F330
									 // RVA: 0x1F755E0 Offset: 0x1F756E1 VA: 0x1F755E0
		private static void set_fieldNagisaGymGears(FieldNagisaGymGearEntity[] value) { }

		[CompilerGeneratedAttribute] // RVA: 0x9F340 Offset: 0x9F441 VA: 0x9F340
									 // RVA: 0x1F75650 Offset: 0x1F75751 VA: 0x1F75650
		public static FieldNomoseGymWaterEntity[] get_fieldNomoseGymWater() { }

		[CompilerGeneratedAttribute] // RVA: 0x9F350 Offset: 0x9F451 VA: 0x9F350
									 // RVA: 0x1F756C0 Offset: 0x1F757C1 VA: 0x1F756C0
		private static void set_fieldNomoseGymWater(FieldNomoseGymWaterEntity[] value) { }

		[CompilerGeneratedAttribute] // RVA: 0x9F360 Offset: 0x9F461 VA: 0x9F360
									 // RVA: 0x1F75730 Offset: 0x1F75831 VA: 0x1F75730
		public static FieldNomoseGymSwitchEntity[] get_fieldNomoseGymSwitches() { }

		[CompilerGeneratedAttribute] // RVA: 0x9F370 Offset: 0x9F471 VA: 0x9F370
									 // RVA: 0x1F757A0 Offset: 0x1F758A1 VA: 0x1F757A0
		private static void set_fieldNomoseGymSwitches(FieldNomoseGymSwitchEntity[] value) { }

		[CompilerGeneratedAttribute] // RVA: 0x9F380 Offset: 0x9F481 VA: 0x9F380
									 // RVA: 0x1F75810 Offset: 0x1F75911 VA: 0x1F75810
		public static FieldElevatorBackgroundEntity[] get_fieldElevatorBackground() { }

		[CompilerGeneratedAttribute] // RVA: 0x9F390 Offset: 0x9F491 VA: 0x9F390
									 // RVA: 0x1F75880 Offset: 0x1F75981 VA: 0x1F75880
		private static void set_fieldElevatorBackground(FieldElevatorBackgroundEntity[] value) { }

		[CompilerGeneratedAttribute] // RVA: 0x9F3A0 Offset: 0x9F4A1 VA: 0x9F3A0
									 // RVA: 0x1F758F0 Offset: 0x1F759F1 VA: 0x1F758F0
		public static FieldPokemonCenterEntity[] get_fieldPokemonCenter() { }

		[CompilerGeneratedAttribute] // RVA: 0x9F3B0 Offset: 0x9F4B1 VA: 0x9F3B0
									 // RVA: 0x1F75960 Offset: 0x1F75A61 VA: 0x1F75960
		private static void set_fieldPokemonCenter(FieldPokemonCenterEntity[] value) { }

		[CompilerGeneratedAttribute] // RVA: 0x9F3C0 Offset: 0x9F4C1 VA: 0x9F3C0
									 // RVA: 0x1F759D0 Offset: 0x1F75AD1 VA: 0x1F759D0
		public static FieldPokemonCenterMonitorEntity[] get_fieldPokemonCenterMonitor() { }

		[CompilerGeneratedAttribute] // RVA: 0x9F3D0 Offset: 0x9F4D1 VA: 0x9F3D0
									 // RVA: 0x1F75A40 Offset: 0x1F75B41 VA: 0x1F75A40
		private static void set_fieldPokemonCenterMonitor(FieldPokemonCenterMonitorEntity[] value) { }

		[CompilerGeneratedAttribute] // RVA: 0x9F3E0 Offset: 0x9F4E1 VA: 0x9F3E0
									 // RVA: 0x1F75AB0 Offset: 0x1F75BB1 VA: 0x1F75AB0
		public static FieldEventTrainEntity[] get_fieldEventTrain() { }

		[CompilerGeneratedAttribute] // RVA: 0x9F3F0 Offset: 0x9F4F1 VA: 0x9F3F0
									 // RVA: 0x1F75B20 Offset: 0x1F75C21 VA: 0x1F75B20
		private static void set_fieldEventTrain(FieldEventTrainEntity[] value) { }

		[CompilerGeneratedAttribute] // RVA: 0x9F400 Offset: 0x9F501 VA: 0x9F400
									 // RVA: 0x1F75B90 Offset: 0x1F75C91 VA: 0x1F75B90
		public static FieldEyePaintingEntity[] get_fieldEyePainting() { }

		[CompilerGeneratedAttribute] // RVA: 0x9F410 Offset: 0x9F511 VA: 0x9F410
									 // RVA: 0x1F75C00 Offset: 0x1F75D01 VA: 0x1F75C00
		private static void set_fieldEyePainting(FieldEyePaintingEntity[] value) { }

		[CompilerGeneratedAttribute] // RVA: 0x9F420 Offset: 0x9F521 VA: 0x9F420
									 // RVA: 0x1F75C70 Offset: 0x1F75D71 VA: 0x1F75C70
		public static FieldEmbankmentEntity[] get_fieldEmbankment() { }

		[CompilerGeneratedAttribute] // RVA: 0x9F430 Offset: 0x9F531 VA: 0x9F430
									 // RVA: 0x1F75CE0 Offset: 0x1F75DE1 VA: 0x1F75CE0
		private static void set_fieldEmbankment(FieldEmbankmentEntity[] value) { }

		[CompilerGeneratedAttribute] // RVA: 0x9F440 Offset: 0x9F541 VA: 0x9F440
									 // RVA: 0x1F75D50 Offset: 0x1F75E51 VA: 0x1F75D50
		public static FieldTvEntity[] get_fieldTv() { }

		[CompilerGeneratedAttribute] // RVA: 0x9F450 Offset: 0x9F551 VA: 0x9F450
									 // RVA: 0x1F75DC0 Offset: 0x1F75EC1 VA: 0x1F75DC0
		private static void set_fieldTv(FieldTvEntity[] value) { }

		// RVA: 0x1F75E30 Offset: 0x1F75F31 VA: 0x1F75E30
		public static void Add(BaseEntity entity) { }

		// RVA: 0x1F76180 Offset: 0x1F76281 VA: 0x1F76180
		public static void Remove(BaseEntity entity) { }

		// RVA: -1 Offset: -1
		public static T GetEntity<T>() { }
		/* GenericInstMethod :
		|
		|-RVA: 0x1D6B970 Offset: 0x1D6BA71 VA: 0x1D6B970
		|-EntityManager.GetEntity<FieldNomoseGymWaterEntity>
		|-EntityManager.GetEntity<object>
		*/

		// RVA: -1 Offset: -1
		public static T[] GetEntities<T>() { }
		/* GenericInstMethod :
		|
		|-RVA: 0x2C8AC60 Offset: 0x2C8AD61 VA: 0x2C8AC60
		|-EntityManager.GetEntities<FieldCharacterEntity>
		|-EntityManager.GetEntities<FieldPlayerEntity>
		|-EntityManager.GetEntities<FieldPokemonEntity>
		|-EntityManager.GetEntities<object>
		*/

		// RVA: -1 Offset: -1
		public static T[] GetInheritedEntities<T>() { }
		/* GenericInstMethod :
		|
		|-RVA: 0x2C8AE80 Offset: 0x2C8AF81 VA: 0x2C8AE80
		|-EntityManager.GetInheritedEntities<BaseEntity>
		|-EntityManager.GetInheritedEntities<FieldCharacterEntity>
		|-EntityManager.GetInheritedEntities<FieldElevatorBackgroundEntity>
		|-EntityManager.GetInheritedEntities<FieldEmbankmentEntity>
		|-EntityManager.GetInheritedEntities<FieldEventDoorEntity>
		|-EntityManager.GetInheritedEntities<FieldEventEntity>
		|-EntityManager.GetInheritedEntities<FieldEventLiftEntity>
		|-EntityManager.GetInheritedEntities<FieldEventTrainEntity>
		|-EntityManager.GetInheritedEntities<FieldEyePaintingEntity>
		|-EntityManager.GetInheritedEntities<FieldNagisaGymGearEntity>
		|-EntityManager.GetInheritedEntities<FieldNomoseGymSwitchEntity>
		|-EntityManager.GetInheritedEntities<FieldNomoseGymWaterEntity>
		|-EntityManager.GetInheritedEntities<FieldObjectEntity>
		|-EntityManager.GetInheritedEntities<FieldPokemonCenterEntity>
		|-EntityManager.GetInheritedEntities<FieldPokemonCenterMonitorEntity>
		|-EntityManager.GetInheritedEntities<FieldTobariGymWallEntity>
		|-EntityManager.GetInheritedEntities<FieldTvEntity>
		|-EntityManager.GetInheritedEntities<object>
		*/

		// RVA: 0x1F76240 Offset: 0x1F76341 VA: 0x1F76240
		public static void BuildFieldEntities() { }

		// RVA: 0x1F76D00 Offset: 0x1F76E01 VA: 0x1F76D00
		private static void .cctor() { }
	}
}
