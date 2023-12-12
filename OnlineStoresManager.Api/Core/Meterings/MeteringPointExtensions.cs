namespace OnlineStoresManager.API
{
    internal static class MeteringPointExtensions
    {
        public static IQueryable<MeteringPoint> FilterBy(this IQueryable<MeteringPoint> points, IMeteringPointFilter filter)
        {
            return points.Where(p =>
                (filter.ParkId == null || p.ParkId == filter.ParkId)
                    && (filter.SearchText == null
                        || (p.Code != null && p.Code.Contains(filter.SearchText))
                        || (p.ShortName != null && p.ShortName.Contains(filter.SearchText))
                        || (p.Description != null && p.Description.Contains(filter.SearchText))));
        }

        public static IQueryable<MeteringPoint> SortBy(this IQueryable<MeteringPoint> points, IMeteringPointFilter filter)
        {
            switch (filter.SortBy)
            {
                case MeteringPointFieldIdentifier.Code:
                    return points.OrderBy(p => p.Code, filter.SortOrder);

                case MeteringPointFieldIdentifier.Description:
                    return points.OrderBy(p => p.Description, filter.SortOrder);

                case MeteringPointFieldIdentifier.Id:
                    return points.OrderBy(p => p.Id, filter.SortOrder);

                case MeteringPointFieldIdentifier.ShortName:
                    return points.OrderBy(p => p.ShortName, filter.SortOrder);

                default:
                    throw new ArgumentException(string.Format("Not supported sort field '{0}'", filter.SortBy));
            }
        }
    }
}
