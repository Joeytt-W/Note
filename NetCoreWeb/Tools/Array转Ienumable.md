```c#
/// <summary>
    /// 自定义 Model 绑定器，将 Uri Query 中的 Company ids 字符串处理为 IEnumerable<Guid>（视频P24)
    /// </summary>
    public class ArrayModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (!bindingContext.ModelMetadata.IsEnumerableType)
            {
                bindingContext.Result = ModelBindingResult.Failed();
                return Task.CompletedTask;
            }

            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName).ToString();

            if (string.IsNullOrWhiteSpace(value))
            {
                bindingContext.Result = ModelBindingResult.Success(null);
                return Task.CompletedTask;
            }

            var elementType = bindingContext.ModelType.GetTypeInfo().GenericTypeArguments[0];
            //创建一个转换器
            var converter = TypeDescriptor.GetConverter(elementType);
            var values = value.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(x => converter.ConvertFromString(x.Trim())).ToArray();
            var typedValues = Array.CreateInstance(elementType, values.Length);
            values.CopyTo(typedValues, 0);
            bindingContext.Model = typedValues;
            bindingContext.Result = ModelBindingResult.Success(bindingContext.Model);
            return Task.CompletedTask;
        }
    }
```

