using UnityEngine;
using UnityEngine.UI;
using EasyUI.Dialogs;

public class Demo : MonoBehaviour {
	
	[SerializeField] Button showMessageButton;

	[Multiline]
	[SerializeField] string longText;

	void Start ( ) {

		showMessageButton.onClick.RemoveAllListeners ( );
		showMessageButton.onClick.AddListener ( ( ) => {

			//Dialog 1 --------------------------------------------------------------------
			ConfirmDialogUI.Instance
			.SetTitle ( "Message 1" )
			.SetMessage ( longText )
			.SetButtonsColor ( DialogButtonColor.Yellow )
			.SetFadeDuration ( .6f )
			.OnPositiveButtonClicked ( ( ) => Debug.Log ( "Message1 closed" ) )
			.Show ( );


			//Dialog 2 --------------------------------------------------------------------
			ConfirmDialogUI.Instance
			.SetTitle ( "Message 2" )
			.SetMessage ( "Hello world" )
			.SetButtonsVisibility ( false )
			.OnCloseButtonClicked ( delegate {
				Debug.Log ( "[NO BUTTONS]  Message closed" );
			} )
			.Show ( );


			//Dialog 3 --------------------------------------------------------------------
			ConfirmDialogUI.Instance
			.SetTitle ( "Message 3" )
			.SetMessage ( "End message" )
			.SetButtonsColor ( DialogButtonColor.Green )
			.SetPositiveButtonText ( "Cancel" )
			.SetNegativeButtonText ( "Yes" )
			.SetFadeDuration ( 0f )
			.OnPositiveButtonClicked ( ( ) => {
				Debug.Log ( "Message3 closed" );
			} )
			.Show ( );


			//Dialog 4 --------------------------------------------------------------------
			ConfirmDialogUI.Instance
			.SetTitle ( "Message 4" )
			.SetMessage ( longText )
			.SetButtonsColor ( DialogButtonColor.Blue )
			.SetFadeDuration ( 0f )
			.Show ( );


			//Dialog 5 --------------------------------------------------------------------
			ConfirmDialogUI.Instance
			.SetTitle ( "Message 5" )
			.SetMessage ( "Hello this is the last dialog" )
			.SetButtonsColor ( DialogButtonColor.Magenta )
			.SetFadeDuration ( .6f )
			.Show ( );

		} );

	}

}
