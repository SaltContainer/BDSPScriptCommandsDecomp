using BDSP.Dpr.EvScript;
using System;
using System.Collections.Generic;
using System.Text;

namespace BDSP
{
	public static class FlagWork
	{
		// RVA: 0x1A6C2C0 Offset: 0x1A6C3C1 VA: 0x1A6C2C0
		public static bool GetFlag(int flagNo) { }

		// RVA: 0x1A6C330 Offset: 0x1A6C431 VA: 0x1A6C330
		public static bool GetFlag(EvWork.FLAG_INDEX flagNo) { }

		// RVA: 0x1A6C3A0 Offset: 0x1A6C4A1 VA: 0x1A6C3A0
		public static void SetFlag(int flagNo, bool value) { }

		// RVA: 0x1A6C420 Offset: 0x1A6C521 VA: 0x1A6C420
		public static void SetFlag(EvWork.FLAG_INDEX flagNo, bool value) { }

		// RVA: 0x1A6C4A0 Offset: 0x1A6C5A1 VA: 0x1A6C4A0
		public static void ResetFlag(int flagNo) { }

		// RVA: 0x1A6C510 Offset: 0x1A6C611 VA: 0x1A6C510
		public static void ResetFlag(EvWork.FLAG_INDEX flagNo) { }

		// RVA: 0x1A6C580 Offset: 0x1A6C681 VA: 0x1A6C580
		public static bool GetVanishFlag(int flagNo) { }

		// RVA: 0x1A6C600 Offset: 0x1A6C701 VA: 0x1A6C600
		public static void SetVanishFlag(int flagNo, bool value) { }

		// RVA: 0x1A6C690 Offset: 0x1A6C791 VA: 0x1A6C690
		public static void ResetVanishFlag(int flagNo) { }

		// RVA: 0x1A6C710 Offset: 0x1A6C811 VA: 0x1A6C710
		public static bool GetSysFlag(EvWork.SYSFLAG_INDEX flagNo) { }

		// RVA: 0x1A6C780 Offset: 0x1A6C881 VA: 0x1A6C780
		public static void SetSysFlag(EvWork.SYSFLAG_INDEX flagNo, bool value) { }

		// RVA: 0x1A6C800 Offset: 0x1A6C901 VA: 0x1A6C800
		public static void ResetSysFlag(EvWork.SYSFLAG_INDEX flagNo) { }

		// RVA: 0x1A6C870 Offset: 0x1A6C971 VA: 0x1A6C870
		public static int GetWork(int workNo) { }

		// RVA: 0x1A6C8E0 Offset: 0x1A6C9E1 VA: 0x1A6C8E0
		public static int GetWork(EvWork.WORK_INDEX workNo) { }

		// RVA: 0x1A6C950 Offset: 0x1A6CA51 VA: 0x1A6C950
		public static void SetWork(int workNo, int value) { }

		// RVA: 0x1A6C9D0 Offset: 0x1A6CAD1 VA: 0x1A6C9D0
		public static void SetWork(EvWork.WORK_INDEX workNo, int value) { }

		// RVA: 0x1A6CA50 Offset: 0x1A6CB51 VA: 0x1A6CA50
		public static void ResetWork(int workNo) { }

		// RVA: 0x1A6CAC0 Offset: 0x1A6CBC1 VA: 0x1A6CAC0
		public static float GetFloatWork(int workNo) { }

		// RVA: 0x1A6CB30 Offset: 0x1A6CC31 VA: 0x1A6CB30
		public static float GetFloatWork(EvWork.WORK_INDEX workNo) { }

		// RVA: 0x1A6CBA0 Offset: 0x1A6CCA1 VA: 0x1A6CBA0
		public static void SetFloatWork(int workNo, float value) { }

		// RVA: 0x1A6CC20 Offset: 0x1A6CD21 VA: 0x1A6CC20
		public static void SetFloatWork(EvWork.WORK_INDEX workNo, float value) { }

		// RVA: 0x1A6CCA0 Offset: 0x1A6CDA1 VA: 0x1A6CCA0
		public static int BadgeCount() { }
	}
}
