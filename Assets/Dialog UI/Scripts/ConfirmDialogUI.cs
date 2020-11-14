using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using System.Collections;

namespace EasyUI.Dialogs {

	[System.Serializable]
	public enum DialogButtonColor {
		Black,
		Purple,
		Magenta,
		Blue,
		Green,
		Yellow,
		Orange,
		Red,
		Gray
	}


	public class ConfirmDialogUI : MonoBehaviour {
		// UI references ------------------------------------------------
		[SerializeField] GameObject uiCanvas;
		[SerializeField] Button uiCloseButton;
		[SerializeField] TextMeshProUGUI uiTitleText;
		[SerializeField] TextMeshProUGUI uiMessageText;
		[SerializeField] Button uiNegativeButton;
		[SerializeField] Button uiPositiveButton;

		TextMeshProUGUI uiNegativeButtonText;
		TextMeshProUGUI uiPositiveButtonText;
		Image uiNegativeButtonImage;
		Image uiPositiveButtonImage;
		CanvasGroup uiCanvasGroup;


		// Dialog properties ---------------------------------------------
		//Default values:
		[Space ( 20f )]
		[Header ( "Dialog's defaults:" )]
		[SerializeField] int maxMessageLetters = 300;
		[SerializeField] string _defaultNegativeButtonText = "no";
		[SerializeField] string _defaultPositiveButtonText = "yes";
		[SerializeField] DialogButtonColor _defaultButtonsColor = DialogButtonColor.Black;
		[SerializeField] float _defaultFadeDuration = .3f;

		string Title;
		string Message;
		string NegativeButtonText;
		string PositiveButtonText;
		DialogButtonColor ButtonsColor;
		float FadeDuration;
		UnityAction CloseButtonClickAction = null;
		UnityAction NegativeButtonClickAction = null;
		UnityAction PositiveButtonClickAction = null;


		[Space ( 20f )]
		[SerializeField] Color[] dialogButtonColors;


		[HideInInspector] public bool IsActive = false;



		// Singleton instance ----------------------------------------------
		public static ConfirmDialogUI Instance;


		void Awake ( ) {
			Instance = this;


			uiNegativeButtonText = uiNegativeButton.GetComponentInChildren <TextMeshProUGUI> ( );
			uiPositiveButtonText = uiPositiveButton.GetComponentInChildren <TextMeshProUGUI> ( );
			uiNegativeButtonImage = uiNegativeButton.GetComponent <Image> ( );
			uiPositiveButtonImage = uiPositiveButton.GetComponent <Image> ( );
			uiCanvasGroup = uiCanvas.GetComponent <CanvasGroup> ( );


			ResetDialog ( );
		}


		//---------------------------------------------------------------------------

		public ConfirmDialogUI SetTitle ( string title ) {
			this.Title = title;
			return Instance;
		}

		public ConfirmDialogUI SetMessage ( string message ) {
			this.Message = message;
			return Instance;
		}

		public ConfirmDialogUI SetButtonsColor ( DialogButtonColor color ) {
			this.ButtonsColor = color;
			return Instance;
		}

		public ConfirmDialogUI SetNegativeButtonText ( string text ) {
			this.NegativeButtonText = text;
			return Instance;
		}

		public ConfirmDialogUI SetPositiveButtonText ( string text ) {
			this.PositiveButtonText = text;
			return Instance;
		}

		public ConfirmDialogUI SetFadeDuration ( float duration ) {
			this.FadeDuration = duration;
			return Instance;
		}

		public ConfirmDialogUI OnCloseButtonClicked ( UnityAction action ) {
			this.CloseButtonClickAction = action;
			return Instance;
		}

		public ConfirmDialogUI OnNegativeButtonClicked ( UnityAction action ) {
			this.NegativeButtonClickAction = action;
			return Instance;
		}

		public ConfirmDialogUI OnPositiveButtonClicked ( UnityAction action ) {
			this.PositiveButtonClickAction = action;
			return Instance;
		}


		//---------------------------------------------------------------------------


		public void Show ( ) {
			if ( IsActive ) {
				Debug.LogWarning ( "[DialogUI] You can't show more than one Dialog at the same time!" );
				return;
			}

			if ( string.IsNullOrEmpty ( this.Message ) ) {
				Debug.LogError ( "[DialogUI] Dialog's message text is not set. use <b>SetMessage(...)</b>" );
				return;
			}

			FillDialogUI ( );

			IsActive = true;
			uiCanvas.SetActive ( IsActive );
			StartCoroutine ( FadeIn ( this.FadeDuration ) );
		}

		void FillDialogUI ( ) {
			uiTitleText.text = this.Title;
			uiMessageText.text = (this.Message.Length > maxMessageLetters) ? this.Message.Substring ( 0, maxMessageLetters - 3 ) + "..." : this.Message;
			uiNegativeButtonText.text = this.NegativeButtonText;
			uiPositiveButtonText.text = this.PositiveButtonText;
			Color transparentColor = dialogButtonColors [ ( int )this.ButtonsColor ];
			transparentColor.a = .12f;
			uiNegativeButtonImage.color = transparentColor;
			uiPositiveButtonImage.color = dialogButtonColors [ ( int )this.ButtonsColor ];
		}

		public void Hide ( ) {
			IsActive = false;

			StopAllCoroutines ( );
			StartCoroutine ( FadeOut ( this.FadeDuration ) );

			uiCloseButton.onClick.RemoveListener ( OnCloseButtonClicked );
			uiNegativeButton.onClick.RemoveListener ( OnNegativeButtonClicked );
			uiPositiveButton.onClick.RemoveListener ( OnPositiveButtonClicked );

			ResetDialog ( );
		}

		void ResetDialog ( ) {
			this.Title = null;
			this.Message = null;
			this.FadeDuration = _defaultFadeDuration;
			this.ButtonsColor = _defaultButtonsColor;
			this.PositiveButtonText = _defaultPositiveButtonText;
			this.NegativeButtonText = _defaultNegativeButtonText;

			CloseButtonClickAction = null;
			NegativeButtonClickAction = null;
			PositiveButtonClickAction = null;
		}


		//---------------------------------------------------------------------------


		void OnCloseButtonClicked ( ) {
			if ( this.CloseButtonClickAction != null )
				this.CloseButtonClickAction.Invoke ( );

			Hide ( );
		}

		void OnNegativeButtonClicked ( ) {
			if ( this.NegativeButtonClickAction != null )
				this.NegativeButtonClickAction.Invoke ( );

			Hide ( );
		}

		void OnPositiveButtonClicked ( ) {
			if ( this.PositiveButtonClickAction != null )
				this.PositiveButtonClickAction.Invoke ( );

			Hide ( );
		}


		//---------------------------------------------------------------------------

		IEnumerator FadeIn ( float duration ) {
			float startTime = Time.time;
			float alpha = 0f;

			//Anim start
			while ( alpha < 1f ) {
				alpha = Mathf.Lerp ( 0f, 1f, (Time.time - startTime) / duration );
				uiCanvasGroup.alpha = alpha;

				yield return null;
			}
			//Anim end
			uiCloseButton.onClick.AddListener ( OnCloseButtonClicked );
			uiNegativeButton.onClick.AddListener ( OnNegativeButtonClicked );
			uiPositiveButton.onClick.AddListener ( OnPositiveButtonClicked );
		}

		IEnumerator FadeOut ( float duration ) {
			float startTime = Time.time;
			float alpha = 1f;

			//Anim start
			while ( alpha > 0f ) {
				alpha = Mathf.Lerp ( 1f, 0f, (Time.time - startTime) / duration );
				uiCanvasGroup.alpha = alpha;

				yield return null;
			}
			//Anim end
			uiCanvas.SetActive ( IsActive );
		}

	}

}
