using BBCTests.Helpers;
using Models;
using System;
using System.Collections.Concurrent;

namespace BBCTests.Insfrastructure
{
    public static class UserAccountManager
    {
        //Use concurrent collection to make code thread safe
        private static ConcurrentDictionary<string, User> userDictionary =
                    new ConcurrentDictionary<string, User>();

        public static User User
        {
            get
            {
                if (userDictionary.ContainsKey(UserID))
                {
                    return userDictionary[UserID];
                }
                throw new Exception("User is not initialized");
            }
        }

        private static string UserID => NUnitHelper.CurrentTestName;

        public static void CleanupUser()
        {
            userDictionary.TryRemove(UserID, out User tempuser);
        }

        public static void InitUser(User user)
        {
            userDictionary.TryAdd(UserID, user);
        }

    }
}
