# GenericDialogForm
Create dialog form with custom number of input fields and buttons for selection of folders paths. Additionally it can include textbox for customt text entry

If you need dialog form for catching folder paths and/or insert custom text this form can be useful. With this form you can easily insert one, two or as many textbox fields you want/need and to return all that for further use.
This project includes short example for use, but classes of interst are:
 - GenericDialogForm.cs - this is form and the main class, it generates fields and sets selected paths
 - DialogEnums
 - DialogComponentsFileName.cs - this inherits UserControl and forms control which contains label + textbox
 - DialogComponentsFolderBrowse.cs - inherits UserControl and forms control which contains label, textbox and button
 - IDialogComponents.cs
