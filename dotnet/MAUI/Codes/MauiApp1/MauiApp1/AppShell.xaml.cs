namespace MauiApp1;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		//注册导航路由
		Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
	}
}
