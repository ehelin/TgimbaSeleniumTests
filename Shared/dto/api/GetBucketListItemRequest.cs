﻿namespace Shared.dto.api
{
    public class GetBucketListItemRequest
    {
        public string EncodedUserName { get; set; }
        public string EncodedToken { get; set; }
        public string EncodedSortString { get; set; }
        public string EncodedSearchString { get; set; }
    }
}
