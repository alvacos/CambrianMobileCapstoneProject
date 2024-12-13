using CambrianMobileCapstoneProject.ViewModel;

namespace CambrianMobileCapstoneProject;

public partial class DetailPage : ContentPage
{
    public DetailPage(DetailViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
