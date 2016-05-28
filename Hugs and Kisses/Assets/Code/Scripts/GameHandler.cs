using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameHandler : MonoBehaviour
{
	public Sprite HugSprite = null;
	public Sprite KissSprite = null;
	[SerializeField] private GameObject m_BoardCellsPrefab = null;

	private int m_PlayerTurn = 1;
	private Cell[] m_Cells = null;

	void Awake ()
	{
		AssignComponentReferences ();
		InitialiseGame ();
	}

	void AssignComponentReferences ()
	{
		m_Cells = new Cell[m_BoardCellsPrefab.transform.childCount];

		for (int i = 0; i < m_Cells.Length; i++)
		{
			m_Cells [i] = m_BoardCellsPrefab.transform.GetChild (i).GetComponent<Cell> ();
		}
	}

	void InitialiseGame ()
	{
		foreach (Cell cell in m_Cells)
		{
			cell.Initialise (this);
		}
	}

	public int GetCurrentPlayer ()
	{
		return m_PlayerTurn;
	}

	public void EndTurn ()
	{
		CheckForWinCondition ();
		SwitchTurn ();
	}

	void SwitchTurn ()
	{
		m_PlayerTurn = (m_PlayerTurn == 1) ? 0 : 1;
	}

	void CheckForWinCondition ()
	{
		VerticalConditions ();
		HorizontalConditions ();
		DiagonalConditions ();
	}

	void VerticalConditions ()
	{
		if(m_Cells[0].PlayerOwner == m_PlayerTurn && m_Cells[1].PlayerOwner == m_PlayerTurn && m_Cells[2].PlayerOwner == m_PlayerTurn)
		{
			GameOver ();
		}
		else if(m_Cells[3].PlayerOwner == m_PlayerTurn && m_Cells[4].PlayerOwner == m_PlayerTurn && m_Cells[5].PlayerOwner == m_PlayerTurn)
		{
			GameOver ();
		}
		else if(m_Cells[6].PlayerOwner == m_PlayerTurn && m_Cells[7].PlayerOwner == m_PlayerTurn && m_Cells[8].PlayerOwner == m_PlayerTurn)
		{
			GameOver ();
		}
	}

	void HorizontalConditions ()
	{
		if(m_Cells[0].PlayerOwner == m_PlayerTurn && m_Cells[3].PlayerOwner == m_PlayerTurn && m_Cells[6].PlayerOwner == m_PlayerTurn)
		{
			GameOver ();
		}
		else if(m_Cells[1].PlayerOwner == m_PlayerTurn && m_Cells[4].PlayerOwner == m_PlayerTurn && m_Cells[7].PlayerOwner == m_PlayerTurn)
		{
			GameOver ();
		}
		else if(m_Cells[2].PlayerOwner == m_PlayerTurn && m_Cells[5].PlayerOwner == m_PlayerTurn && m_Cells[8].PlayerOwner == m_PlayerTurn)
		{
			GameOver ();
		}
	}

	void DiagonalConditions ()
	{
		if(m_Cells[0].PlayerOwner == m_PlayerTurn && m_Cells[4].PlayerOwner == m_PlayerTurn && m_Cells[8].PlayerOwner == m_PlayerTurn)
		{
			GameOver ();
		}
		else if(m_Cells[6].PlayerOwner == m_PlayerTurn && m_Cells[4].PlayerOwner == m_PlayerTurn && m_Cells[2].PlayerOwner == m_PlayerTurn)
		{
			GameOver ();
		}
	}

	void GameOver ()
	{
		foreach (Cell cell in m_Cells)
		{
			cell.gameObject.GetComponent<Button> ().interactable = false;
		}
	}
}