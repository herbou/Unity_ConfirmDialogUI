# Confirm Dialog UI
### Video tutorial : [https://youtu.be/xqx6BmaWOx0](https://youtu.be/xqx6BmaWOx0)
![Video thumbnail](https://img.youtube.com/vi/xqx6BmaWOx0/0.jpg)

- *STEP 1* : Add *Text Mesh Pro* to your project.
- *STEP 2* : Add ConfirmDialoUI package.
- *STEP 3* : Add the DialogUI prefab to your scene.

now you're ready to go 😉

To show the dialog you simply write:
```c#
using EasyUI.Dialogs;
...
...
void Start ( ) {
   ConfirmDialogUI.Instance.SetMessage("Hello").Show( );
}
...
```

# ■ Dialog properties :
### Title :
```c#
SetTitle ( string title )
```

### Body Text :
```c#
SetMessage ( string message )
```

### Fade duration :
```c#
SetFadeDuration ( float duration )
```

### Show or Hide bottom buttons:
```c#
SetButtonsVisibility ( bool visibility )
```

### Buttons color :
```c#
SetButtonsColor ( DialogButtonColor color )
```

### Right button text :
```c#
SetPositiveButtonText ( string text )
```

### Left button text :
```c#
SetNegativeButtonText ( string text )
```

# ■ Dialog Events :
### Right button click event :
```c#
OnPositiveButtonClicked ( UnityAction action )
```

### Left button click event :
```c#
OnNegativeButtonClicked ( UnityAction action )
```

### Close button event :
```c#
OnCloseButtonClicked ( UnityAction action )
```
