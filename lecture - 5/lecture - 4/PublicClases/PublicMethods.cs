using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Text.Json;

namespace lecture___4
{
    public static class PublicMethods
    {
        public static string returnDate()
        {
           return DateTime.Now.ToString("dddd - H - mm");
        }

        public static void Put<T>(this ITempDataDictionary tempData, string key, T value) where T : class
        {
            tempData[key] = JsonSerializer.Serialize(value);
        }

        public static T Get<T>(this ITempDataDictionary tempData, string key) where T : class
        {
            tempData.TryGetValue(key, out object o);
            return o == null ? null : JsonSerializer.Deserialize<T>((string)o);
        }

        public static T Peek<T>(this ITempDataDictionary tempData, string key) where T : class
        {
            object o = tempData.Peek(key);
            return o == null ? null : JsonSerializer.Deserialize<T>((string)o);
        }

        public class SerializeModelStatePageFilter : IPageFilter
        {
            public class ModelStateTransferValue
            {
                public string Key { get; set; }
                public string AttemptedValue { get; set; }
                public object RawValue { get; set; }
                public ICollection<string> ErrorMessages { get; set; } = new List<string>();
            }


            public void OnPageHandlerSelected(PageHandlerSelectedContext context)
            {
                if (!(context.HandlerInstance is PageModel page))
                    return;

                var serializedModelState = page.TempData[nameof(SerializeModelStatePageFilter)] as string;
                if(string.IsNullOrEmpty(serializedModelState))
                    return;

                var modelState = DeserializeModelState(serializedModelState);
                page.ModelState.Merge(modelState);
            }

            public void OnPageHandlerExecuting(PageHandlerExecutingContext context) { }

            public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
            {
                if (!(context.HandlerInstance is PageModel page))
                    return;
                if (page.ModelState.IsValid)
                    return;
                if (context.Result is IKeepTempDataResult)
                {
                    var modelState = SerializeModelState(page.ModelState);
                    page.TempData[nameof(SerializeModelStatePageFilter)] = modelState;
                }
            }


            private static string SerializeModelState(ModelStateDictionary modelState)
            {
                var errorList = modelState
                    .Select(kvp => new ModelStateTransferValue
                    {
                        Key = kvp.Key,
                        AttemptedValue = kvp.Value.AttemptedValue,
                        RawValue = kvp.Value.RawValue,
                        ErrorMessages = kvp.Value.Errors.Select(err => err.ErrorMessage).ToList(),
                    });

                return System.Text.Json.JsonSerializer.Serialize(errorList);
            }

            private static ModelStateDictionary DeserializeModelState(string serialisedErrorList)
            {
                var errorList = System.Text.Json.JsonSerializer.Deserialize<List<ModelStateTransferValue>>(serialisedErrorList);
                var modelState = new ModelStateDictionary();

                foreach (var item in errorList)
                {
                    modelState.SetModelValue(item.Key, item.RawValue, item.AttemptedValue);
                    foreach (var error in item.ErrorMessages)
                        modelState.AddModelError(item.Key, error);
                }
                return modelState;
            }
        }

    }
}
