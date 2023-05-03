namespace RenewalTracker_API
{
    public class configuration
    {
        public static string mongoServer = @"mongodb://mongo.lsnj.org:27017";
        public static string mongoDatabase = "renewalmanager";
        public static string renewalsCollection = "renewals";
        public static string vendorsCollection = "vendors";
        public static string categoriesCollection = "categories";
        public static string contactsCollection = "categories";
    }
}
