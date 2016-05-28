using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Cell : MonoBehaviour
{
	[HideInInspector] public int PlayerOwner = -1;

	private Sprite m_HugSprite = null;
	private Sprite m_KissSprite = null;
	private Button m_Button = null;
	private Image m_Image = null;
	private GameHandler m_GameHandler = null;

	public void Initialise (GameHandler handler)
	{
		AssignComponentReferences (handler);
		SetCellDefaults ();
	}

	void AssignComponentReferences (GameHandler handler)
	{
		m_Button = GetComponent<Button> ();
		m_Image = GetComponent<Image> ();
		m_GameHandler = handler;
		m_HugSprite = m_GameHandler.HugSprite;
		m_KissSprite = m_GameHandler.KissSprite;
	}

	void SetCellDefaults ()
	{
		PlayerOwner = -1;
		m_Button.interactable = true;
	}

	public void CellClick ()
	{
		PlayerOwner = m_GameHandler.GetCurrentPlayer ();
		m_GameHandler.EndTurn ();
		UpdateCell ();
	}

	void UpdateCell ()
	{
		m_Image.sprite = CurrentPlayerSprite ();
		m_Button.interactable = false;
	}

	Sprite CurrentPlayerSprite ()
	{
		if(PlayerOwner == 0)
		{
			return m_HugSprite;
		}
		else
		{
			return m_KissSprite;
		}
	}
}