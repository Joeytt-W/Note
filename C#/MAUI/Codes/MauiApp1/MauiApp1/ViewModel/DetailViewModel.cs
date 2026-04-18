using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiApp1.ViewModel
{
    [QueryProperty("Text","Text")]//[QueryProperty("属性名","跳转路由时的参数名Text")] await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}");
    public partial class DetailViewModel:ObservableObject
    {
        [ObservableProperty]
        string text;

        [RelayCommand]
        async Task GoBack()
        {
            //这里类似文件的目录返回上一级
            //../Another.xaml===>跳转到Another页
            await Shell.Current.GoToAsync("..");
        }
    }
}
