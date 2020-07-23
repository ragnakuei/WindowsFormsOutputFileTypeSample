using System.Collections.Generic;

namespace WindowsFormsApp
{
    public static class Helper
    {
        public static TValue GetValue<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key)
        {
            if(dict.TryGetValue(key, out TValue result))
            {
                return result;
            }
        
            return default(TValue);
        }
    }
}