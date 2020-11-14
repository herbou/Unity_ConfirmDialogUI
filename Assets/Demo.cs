using UnityEngine;
using UnityEngine.UI;
using EasyUI.Dialogs;

public class Demo : MonoBehaviour {
	
	[SerializeField] Button showMessageButton;

	[Multiline]
	[SerializeField] string messageText;

	void Start ( ) {

		showMessageButton.onClick.RemoveAllListeners ( );
		showMessageButton.onClick.AddListener ( ( ) => 
			ConfirmDialogUI.Instance
			.SetTitle ( "Message" )
			.SetMessage ( messageText )

			.SetFadeDuration ( .5f )

			.SetNegativeButtonText ( "Non" )
			.OnNegativeButtonClicked ( ( ) => Debug.Log ( "[Non] is clicked" ))

			.SetPositiveButtonText ( "Oui" )
			.OnPositiveButtonClicked ( ( ) => Debug.Log ( "[Oui] is clicked" ))

			.OnCloseButtonClicked ( ( ) => Debug.Log ( "[x] is clicked" ) )

			.SetButtonsColor ( DialogButtonColor.Magenta )

			.Show ( )
		);


		/* Different ways to add events (Functions, Delegates , or the Lambda Expression => ) :

			1 : Functions ---------------------------------------------------------------
			.OnPositiveButtonClicked ( PositiveButtonClick )
			where PositiveButtonClick is a function defined in your script :

			void PositiveButtonClick(){
				//code here ;
				Debug.Log ( "Positive button is clicked" );
			}


			2 : Delegates ---------------------------------------------------------------
			.OnPositiveButtonClicked ( delegate {
				//code here ;
				Debug.Log ( "Positive button is clicked" );
			} )


			3.1 : Lambda Expression (Multiline) -------------------------------------------
			.OnPositiveButtonClicked ( () => {
				//code here ;
				Debug.Log ( "Positive button is clicked" );
			} )


			3.2 : Lambda Expression (One line) -------------------------------------------
			.OnPositiveButtonClicked ( () => Debug.Log ( "Positive button is clicked" ) )

			//no need for ';'



		*/

	}

}
