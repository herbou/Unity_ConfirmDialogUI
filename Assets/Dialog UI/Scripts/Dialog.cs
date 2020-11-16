using UnityEngine;
using UnityEngine.Events;

namespace EasyUI.Dialogs {

	class Dialog {
		public string Title = null;
		public string Message = null;
		public bool HasButtons;
		public string NegativeButtonText = null;
		public string PositiveButtonText = null;
		public DialogButtonColor ButtonsColor;

		public float FadeDuration;

		//Events
		public UnityAction CloseButtonClickAction = null;
		public UnityAction NegativeButtonClickAction = null;
		public UnityAction PositiveButtonClickAction = null;
	}

}
