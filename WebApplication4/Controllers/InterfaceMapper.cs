namespace WebApplication4.Controllers
{
    public static class InterfaceMapper
    {

        public static TDest Map<TDest, T>(this TDest dest, T source)
            where TDest: T
        {
            Map(dest, source);
            return dest;
        }

        public static void Map<T>(this T dest, T source)
        {
            var type = typeof (T);
            var props = type.GetProperties();
            foreach (var propertyInfo in props)
            {
                if (propertyInfo.CanRead && propertyInfo.CanWrite)
                {
                    propertyInfo.SetValue(dest, propertyInfo.GetValue(source));
                }
            }
        }
    }
}