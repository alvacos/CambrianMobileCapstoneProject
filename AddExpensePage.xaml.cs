using CambrianMobileCapstoneProject.ViewModel;
namespace CambrianMobileCapstoneProject;

public partial class AddExpensePage : ContentPage
{
    public AddExpensePage()
    {
        InitializeComponent();
        BindingContext = new AddExpensePageViewModel();
    }
}