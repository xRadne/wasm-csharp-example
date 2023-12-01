using Microsoft.JSInterop;
using Newtonsoft.Json;

namespace Demo1
{
    public class Program
    {
        private static async Task Main(string[] args)
        {
        }

        [JSInvokable]
        public static int Add(int i, int j)
        {
            return i + j;
        }

        [JSInvokable]
        public static string Box()
        {
            var box = new Box(0, 0, 0, 1, 1, 1);
            return box.ToJson();
        }

        [JSInvokable]
        public static string Move(string boxJson, string translationJson)
        {
            Box? box = JsonConvert.DeserializeObject<Box>(boxJson);
            Point? translation = JsonConvert.DeserializeObject<Point>(translationJson);

            if (box != null && translation != null)
            {
                box.Move(translation);
                return box.ToJson();
            }

            return "{}";
        }
    }
}