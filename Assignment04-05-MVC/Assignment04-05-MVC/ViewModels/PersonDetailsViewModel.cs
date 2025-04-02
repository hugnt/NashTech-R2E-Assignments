using Assignment04_05_MVC.Common.Enums;
using Assignment04_05_MVC.Models;

namespace Assignment04_05_MVC.ViewModels;

public class PersonDetailsViewModel
{
    public string Title { get; set; }
    public FormMode FormMode { get; set; }
    public Person Person { get; set; }

	public string RouteAction { get; set; } = "";
	public string Method { get; set; } = "";

	public bool IsModeDetails => FormMode == FormMode.Detail;
	public bool IsModeAdd => FormMode == FormMode.Add;
	public bool IsModeUpdate => FormMode == FormMode.Update;


	public bool IsHideSaveButton => FormMode == FormMode.Detail;
	public bool IsHideResetButton => FormMode == FormMode.Detail;
	public bool IsHideDeleteButton => FormMode != FormMode.Detail;

	public bool IsHideAddnewButton => FormMode == FormMode.Add;
	public bool IsHideUpdateButton =>  FormMode == FormMode.Update|| FormMode == FormMode.Add;

}
