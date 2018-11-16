using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace TPCWC{

	public class CreateObjectsEditor : EditorWindow {

		[MenuItem("TPCWC/Create Objects/Door")]
		public static void CreateDoor(){

			GameObject door = Instantiate(Resources.Load("Interactions/Door")) as GameObject;
			door.name = "Door";

		}

		[MenuItem("TPCWC/Create Objects/Switch")]
		public static void CreateSwitch(){

			GameObject Switch = Instantiate(Resources.Load("Interactions/Switch")) as GameObject;
			Switch.name = "Switch";

		}

		[MenuItem("TPCWC/Create Objects/Push Button")]
		public static void CreatePushButton(){

			GameObject PushButton = Instantiate(Resources.Load("Interactions/Push Button")) as GameObject;
			PushButton.name = "Push Button";

		}

		[MenuItem("TPCWC/Create Objects/Plane Prototype")]
		public static void CreatePlanePrototype(){

			GameObject Plane = Instantiate(Resources.Load("Interactions/Plane")) as GameObject;
			Plane.name = "Plane";

		}

		[MenuItem("TPCWC/Create Objects/Wall Prototype")]
		public static void CreateWallPrototype(){

			GameObject Wall = Instantiate(Resources.Load("Interactions/Wall")) as GameObject;
			Wall.name = "Wall";

		}

	}
}