namespace TgimbaSeleniumTests.Tests
{
    public class Constants
    {        
        public const string TEST_USER = "testUser";
        public const string DB_CONN_LOCAL_HOST_BUCKETLIST = "Data Source=DESKTOP-T0D67EL\\SQLEXPRESS;Initial Catalog=SQL2016_974243_bucketlist;Integrated Security=true;";
        
        public const string DELETE_TEST_USER = "delete from [Bucket].[BucketListItem]   "
                                        + " where bucketlistitemid in (select bucketListItemId   "
                                        + "                            from [Bucket].[BucketListUser]   "
                                        + " 						   where userid in (select userid   "
                                        + " 						                    from [Bucket].[User]   "
                                        + " 										    where UserName = 'testUser')   "
                                        + " 						   )   "
                                        + "    "
                                        + " delete from [Bucket].[BucketListUser]   "
                                        + " where userid in (select userid   "
                                        + " 				from [Bucket].[User]   "
                                        + " 				where UserName = 'testUser')   "
                                        + "    "
                                        + " delete from [Bucket].[User]   "
                                        + " where UserName = 'testUser' ";
    }
}
