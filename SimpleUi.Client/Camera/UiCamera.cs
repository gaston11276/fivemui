using System;
using CitizenFX.Core;
using CitizenFX.Core.Native;

namespace Gaston11276.Fivemui
{
	public enum CameraMode
	{
		Game = 0,
		Front,
		Upper,
		Face,
	}

	static public class UiCamera
	{
		public const float DegToRad = (float)Math.PI / 180.0f;
		public const float RadToDeg = 180.0f / (float)Math.PI;

		public static bool rotatingCamera = false;
		public static float lastCursorX = 0f;
		public static float lastCursorY = 0f;

		public static float AngleBetween(Vector3 a, Vector3 b)
		{
			double sinA = a.X * b.Y - b.X * a.Y;
			double cosA = a.X * b.X + a.Y * b.Y;
			return (float)Math.Atan2(sinA, cosA) / DegToRad;
		}

		static private Camera camera;
		static private CameraMode mode;

		static UiCamera()
		{
			WindowManager.RegisterOnMouseButtonCallback(OnMouseButton);
			WindowManager.RegisterOnMouseMoveCallback(OnMouseMove);
		}

		static public void OnMouseButton(int state, int button, float CursorX, float CursorY)
		{
			
			if (!rotatingCamera && state == 1 && button == 2)
			{
				rotatingCamera = true;
				lastCursorX = CursorX;
				lastCursorY = CursorY;
			}
			else if (rotatingCamera && state == 3 && button == 2)
			{
				rotatingCamera = false;
			}
			
		}

		static public void OnMouseMove(float CursorX, float CursorY)
		{
			
			if (rotatingCamera)
			{
				float AxisX = ((float)(lastCursorX - CursorX)) / 1280f;
				float AxisY = ((float)(lastCursorY - CursorY)) / 1280f;
				UpdateCamera(AxisX, AxisY);
				lastCursorX = CursorX;
				lastCursorY = CursorY;
			}
		}


		static public void SetMode(CameraMode cameraMode)
		{
			mode = cameraMode;
			UpdateMode();
		}

		static void UpdateMode()
		{
			float distance = 3f;
			float height = 0.0f;

			if (mode == CameraMode.Game)
			{
				API.RenderScriptCams(false, true, 200, true, true);
				return;
			}
			else if (mode == CameraMode.Front)
			{
				distance = 3.0f;
				height = 0.0f;
			}
			else if (mode == CameraMode.Upper)
			{
				distance = 1.0f;
				height = 0.4f;
			}
			else if (mode == CameraMode.Face)
			{
				distance = 0.7f;
				height = 0.65f;
			}

			API.FreezePedCameraRotation(Game.PlayerPed.Handle);

			Vector3 cam_pos = Game.PlayerPed.Position + Game.PlayerPed.ForwardVector * distance;
			cam_pos.Z += height;

			Vector3 ped_rot = Game.PlayerPed.Rotation;


			Vector3 cam_rot;
			cam_rot.X = ped_rot.X;
			cam_rot.Y = ped_rot.Y;
			if (ped_rot.Z > 0f)
				cam_rot.Z = -180f + ped_rot.Z;
			else
				cam_rot.Z = 180f + ped_rot.Z;

			World.DestroyAllCameras();
			camera = World.CreateCamera(cam_pos, cam_rot, GameplayCamera.FieldOfView);
			camera.Position = cam_pos;
			camera.Rotation = cam_rot;
			camera.IsActive = true;
			API.RenderScriptCams(true, true, 200, true, true);
		}

		static public void UpdateCamera(float axisX, float axisY)
		{
			float angleX = -2.0f;
			angleX *= axisX;

			Vector3 vec_ped_to_cam = camera.Position - Game.PlayerPed.Position;
			Vector3 pedpos = Game.PlayerPed.Position;
			Vector3 new_vec_ped_to_cam = Vector3.TransformCoordinate(vec_ped_to_cam, Matrix.RotationAxis(new Vector3(0f, 0f, 1f), -angleX));

			camera.Position = pedpos + new_vec_ped_to_cam;

			Vector3 cam_rot = camera.Rotation;
			float current_angle = camera.Rotation.Length();
			cam_rot.Normalize();

			float rot_angle = angleX * RadToDeg;
			if (cam_rot.Z > 0f)
			{
				rot_angle *= -1f;
			}

			float new_angle = current_angle + rot_angle;
			cam_rot *= new_angle;
			camera.Rotation = cam_rot;
		}

		static public void SetCamera(float distance, float height, float rotation)
		{
			Vector3 ped_rot = Game.PlayerPed.Rotation;
			float accumulated_rotation = ped_rot.Length() + rotation;
			if (accumulated_rotation > 180f)
			{
				accumulated_rotation = -180 + (accumulated_rotation - 180f);
			}
			else if (accumulated_rotation < -180f)
			{
				accumulated_rotation = 180f + (accumulated_rotation + 180f);
			}

			float angle = accumulated_rotation * DegToRad;

			Vector3 axis = new Vector3(0f, 0f, 1f);
			if (accumulated_rotation < 0)
			{
				axis *= -1f;
			}

			Vector3 vec_ped_to_cam = new Vector3(0f, -1f, 0f);

			Vector3 pedpos = Game.PlayerPed.Position;
			Vector3 new_vec_ped_to_cam = Vector3.TransformCoordinate(vec_ped_to_cam, Matrix.RotationAxis(axis, angle));
			new_vec_ped_to_cam.Normalize();

			pedpos.Z += height;
			camera.Position = pedpos + new_vec_ped_to_cam * distance;
			camera.Rotation = axis * accumulated_rotation;
		}
	}
}
