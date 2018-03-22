using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using UnityEngine.XR.WSA.Input;

public class Inventory : MonoBehaviour
{

	public List<GameObject> inventoryItems;
	public GameObject currentItem;

	public GrabAttach grabAttach;

	int selectedItem = -1;
	float angle;

	public InputHandler leftInputHandler;

	// Use this for initialization
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		if (leftInputHandler == null)
		{
			foreach (InputHandler iHandler in FindObjectsOfType<InputHandler>())
			{
				if (iHandler.hand == InteractionSourceHandedness.Left)
				{
					leftInputHandler = iHandler;
				}
			}
		}
		else
		{
			if (leftInputHandler.touchpadTouched)
			{
				//Make objects appear depending of the amount of items we may want to use
				//Make the touchpad position offset so top item is in middle
				Vector2 from = new Vector2(0.0f, 1.0f);
				angle = Vector2.SignedAngle(from, leftInputHandler.touchpadPostion);
				if (angle < 0.0f)
					angle = -angle;
				else
					angle = 180.0f + (180.0f - angle);
				ObjectSelect();
				//Debug.Log("Angle: " + angle);
			}
		}
	}


	private void ObjectSelect()
	{
		int selectedDivision = 0;

		if (inventoryItems.Count > 1)
		{
			float divisions = 360.0f / inventoryItems.Count;

			// Offset angle
			angle -= divisions / 2.0f;
			if (angle < 0.0f)
			{
				angle = 360.0f + angle;
			}

			float selectedDivisionF = angle / divisions;
			selectedDivision = Mathf.FloorToInt(selectedDivisionF);
		}

		Debug.Log("Division: " + selectedDivision);

		if (selectedDivision != selectedItem)
		{
			// Switch to new item
			Destroy(currentItem);
			selectedItem = selectedDivision;
			currentItem = Instantiate(inventoryItems[selectedDivision]);
		}
	}

	private void AddToInventory(GameObject item)
	{
		GrabAttach grabAttach = item.GetComponent<GrabAttach>();
		if (grabAttach != null)
		{
			Debug.Log("Has grab attach");
			if (grabAttach.attachedToHand)
			{
				if (grabAttach.swapInventoryItem != null)
				{
					inventoryItems.Add(grabAttach.swapInventoryItem);
					Destroy(item);
				}
				else
				{
					inventoryItems.Add(item);
					Destroy(item);
				}
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "GrabbableItem")
		{
			AddToInventory(other.gameObject);
			Debug.Log("Touching");
		}
		
	}
}
