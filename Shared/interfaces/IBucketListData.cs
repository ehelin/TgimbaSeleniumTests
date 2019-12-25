﻿using System.Collections.Generic;
using Shared.dto;
using Shared.misc;

namespace Shared.interfaces
{
    public interface IBucketListData
    {
        IList<Shared.dto.BucketListItem> GetBucketList(string userName, Enums.SortColumns? sortColumn, bool isAsc = true, string srchTerm = "");
        void UpsertBucketListItem(Shared.dto.BucketListItem bucketListItem, string userName);
        void DeleteBucketListItem(int bucketListItemDbId);
        void LogMsg(string msg);
        IList<SystemStatistic> GetSystemStatistics();
        IList<SystemBuildStatistic> GetSystemBuildStatistics();

        void AddToken(int userId, string token);
        User GetUser(int id);
        User GetUser(string userName);
        int AddUser(User user);
        void DeleteUser(int userId);
    }
}
