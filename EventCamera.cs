using BDSP.SmartPoint.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace BDSP
{
	public class EventCamera // TypeDefIndex: 3695
	{
		// Fields
		private FieldCamera camera; // 0x10
		private EventCameraData cameraData; // 0x18
		private Vector3<defaultPosition> k__BackingField; // 0x20
		private Vector3<defaultRotate> k__BackingField; // 0x2C
		private Vector3<beforePosition> k__BackingField; // 0x38
		private Vector3<beforeRotate> k__BackingField; // 0x44
		private Vector3 workPosition; // 0x50
		private Vector3 workRotate; // 0x5C
		private Vector3 retrunDefaultPosition; // 0x68
		private Vector3 returnDefaultRotate; // 0x74
		private bool <IsEnd>k__BackingField; // 0x80
		private DepthOfField _dof; // 0x88
		private float[] default_dof; // 0x90
		private float[] work_dof; // 0x98
		private Vector3 default_dof_offset; // 0xA0
		private Vector3 before_dof_offset; // 0xAC
		private Vector3 work_dof_offset; // 0xB8
		private EventCameraTable _cameraTbl; // 0xC8
		private float workFov; // 0xD0
		private float beforeFov; // 0xD4
		private float defaultFov; // 0xD8

		// Properties
		public Vector3 defaultPosition { get; set; }
		public Vector3 defaultRotate { get; set; }
		public Vector3 beforePosition { get; set; }
		public Vector3 beforeRotate { get; set; }
		public bool IsEnd { get; set; }

		// Methods

		// RVA: 0x1F7E730 Offset: 0x1F7E831 VA: 0x1F7E730
		public void SetCameraData(EventCameraTable tbl, int index)
		{
			EventCameraData data = tbl.get_Item(index);
			SetCameraData(tbl, data);
		}

		// RVA: 0x1F7E770 Offset: 0x1F7E871 VA: 0x1F7E770
		public void SetCameraData(EventCameraTable tbl, EventCameraData data)
		{
            _cameraTbl = tbl;

            if (_dof == null)
            {
                _dof = DepthOfField.instance;
            }

            if (_dof != null)
            {
                // These 6 use some fields, but idk which, these seem wrong
                if (default_dof.Length == 0)
                {
                    throw new IndexOutOfRangeException();
                }
                default_dof[0] = _dof.field_0x3c;

                if (work_dof.Length == 0)
                {
                    throw new IndexOutOfRangeException();
                }
                work_dof[0] = _dof.field_0x3c;

                if (default_dof.Length < 2)
                {
                    throw new IndexOutOfRangeException();
                }
                default_dof[1] = _dof.farDepth;

                if (work_dof.Length < 2)
                {
                    throw new IndexOutOfRangeException();
                }
                work_dof[1] = _dof.farDepth;

                if (default_dof.Length < 3)
                {
                    throw new IndexOutOfRangeException();
                }
                default_dof[2] = _dof.focalLength;

                if (work_dof.Length < 3)
                {
                    throw new IndexOutOfRangeException();
                }
                work_dof[2] = _dof.focalLength;

                if (cameraData == null)
                {
                    default_dof_offset = _dof.targetOffset;
                }

                before_dof_offset = work_dof_offset;

                // Unclear?
                work_dof_offset = Vector3.zero;
            }

            beforePosition = workPosition;
            beforeRotate = workRotate;
            workPosition = camera.transform.localPosition;

            workRotate = camera.transform.localEulerAngles;

            defaultFov = camera.Fov;
            beforeFov = workFov;

            workFov = camera.Fov;
            cameraData = data;

            cameraData.baseTime = 0.0f;

            if (cameraData.isEnd.Count > 0)
            {
                for (int i=0; i< cameraData.isEnd.Count; i++)
                {
                    cameraData.isEnd[i] = false;
                }
            }

            if (cameraData.pathData.Count > 0)
            {
                for (int i=0; i<cameraData.pathData.Count; i++)
                {
                    cameraData.pathData[i].workTime = 0.0;
                }
            }

            if (cameraData.dofData.Count > 0)
            {
                for (int i=0; i<cameraData.dofData.Count; i++)
                {
                    cameraData.dofData[i].workTime = 0.0;
                }
            }

            if (cameraData.pathData2.Count > 0)
            {
                for (int i=0; i<cameraData.pathData2.Count; i++)
                {
                    cameraData.pathData2[i].workTime = 0.0;
                }
            }

            if (cameraData.rotationData.Count > 0)
            {
                for (int i=0; i<cameraData.rotationData.Count; i++)
                {
                    cameraData.rotationData[i].workTime = 0.0;
                }
            }

            if (cameraData.returnDefault.Count > 0)
            {
                for (int i=0; i<cameraData.returnDefault.Count; i++)
                {
                    cameraData.returnDefault[i].workTime = 0.0;
                }
            }

            if (cameraData.returnDefaultRotate.Count > 0)
            {
                for (int i=0; i<cameraData.returnDefaultRotate.Count; i++)
                {
                    cameraData.returnDefaultRotate[i].workTime = 0.0;
                }
            }

            if (cameraData.fovData.Count > 0)
            {
                for (int i=0; i<cameraData.fovData.Count; i++)
                {
                    cameraData.fovData[i].workTime = 0.0;
                }
            }

            IsEnd = false;
            return;
        }

		// RVA: 0x1F7ECF0 Offset: 0x1F7EDF1 VA: 0x1F7ECF0
		public void Release() { }

		// RVA: 0x1F7ED00 Offset: 0x1F7EE01 VA: 0x1F7ED00
		public void lateUpdate(float deltatime) { }

		// RVA: 0x1F7FC40 Offset: 0x1F7FD41 VA: 0x1F7FC40
		private bool PathUpdate(EventCameraData.PathData path, float t) { }

		// RVA: 0x1F80000 Offset: 0x1F80101 VA: 0x1F80000
		private bool PathUpdate2(EventCameraData.PathData2 path, float t) { }

		// RVA: 0x1F80280 Offset: 0x1F80381 VA: 0x1F80280
		private bool RotationUpdate(EventCameraData.RotationData path, float t) { }

		// RVA: 0x1F80490 Offset: 0x1F80591 VA: 0x1F80490
		private bool ReturnDefault(EventCameraData.ReturnDefault path, float t) { }

		// RVA: 0x1F80600 Offset: 0x1F80701 VA: 0x1F80600
		private bool ReturnDefaultRotate(EventCameraData.ReturnDefault path, float t) { }

		// RVA: 0x1F80770 Offset: 0x1F80871 VA: 0x1F80770
		private bool FieldOfViewUpdate(EventCameraData.FovData path, float t) { }

		// RVA: 0x1F7FFB0 Offset: 0x1F800B1 VA: 0x1F7FFB0
		private void FadeUpdate(EventCameraData.FadeData fade) { }
	}
}
