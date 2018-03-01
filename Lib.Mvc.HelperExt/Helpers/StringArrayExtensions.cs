using System.Linq;

namespace Lib.Mvc.HelperExt.Helpers
{
    public static class StringArrayExtensions
    {
        /// <summary>
        /// 嘗試取得陣列中的值
        /// </summary>
        /// <param name="ary"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string TryGetValue(this string[] ary, int index)
        {
            return ary?.ElementAtOrDefault(index) ?? "not found";
        }
    }
}