using System;

namespace Plcway.Abstract.Tests.Utils
{
    public static class CollectionHelper
    {
        public static bool ArrayDeepEqual<T>(T[] arr1, T[] arr2) where T : IComparable<T>
        {
            if (arr1.Length != arr2.Length)
            {
                return false;
            }

            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i].CompareTo(arr2[i]) != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
