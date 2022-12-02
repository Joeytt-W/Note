using System.Runtime.Intrinsics.Arm;
using System.Windows;
using System.Windows.Controls;

namespace LearnWpf
{
    public class MyOwnBtn:Button
    {
        //1.声明依赖项属性  约定依赖项属性的命名以Property结尾
        public static readonly DependencyProperty MydpProperty;

        //2.使用静态构造函数初始化依赖项属性
        static MyOwnBtn()
        {
            //指示依赖属性使用什么服务（如数据绑定、动画以及日志）
            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata(default(double),
                FrameworkPropertyMetadataOptions.AffectsMeasure);

            metadata.CoerceValueCallback = new CoerceValueCallback(IsCoerceValueCallback);
            //注册依赖属性
            /*
             * Register方法的参数
             * 1、属性名,例子中为Mydp
             * 2、属性的数据类型
             * 3、拥有该属性的类型
             * 4、附加属性设置的FrameworkPropertyMetadata对象(可选)
             * 5、验证属性的回调函数(可选)
             */
            MydpProperty = DependencyProperty.Register("Mydp", typeof(double), typeof(MyOwnBtn), metadata,
                new ValidateValueCallback(ShirtValidateCallback));

        }

        //3.添加属性包装器 DependencyObject.SetValue() or DependencyObject.GetValue()   
        //DependencyObject.Clear(DP.MydpProperty) 删除本地值设置
        public double Mydp
        {
            set { SetValue(MydpProperty, value); }
            get { return (double)GetValue(MydpProperty); }
        }


        private static bool ShirtValidateCallback(object value)
        {
            return true;
        }

        private static object IsCoerceValueCallback(DependencyObject obj, object value)
        {
            return 10.0;
        }

        //注册附加属性  
        public static readonly DependencyProperty AnotherContentProperty =
            DependencyProperty.RegisterAttached("AnotherContent", typeof(string), typeof(MyOwnBtn), new PropertyMetadata(string.Empty));

        public static string GetAnotherContent(DependencyObject obj)
        {
            return (string)obj.GetValue(AnotherContentProperty);
        }
        public static void SetAnotherContent(DependencyObject obj, string value)
        {
            obj.SetValue(AnotherContentProperty, value);
        }
    }
}
