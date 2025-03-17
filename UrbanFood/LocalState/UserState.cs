namespace UrbanFood.LocalState
{
    public enum UserType
    {
        Supplier,
        Customer
    }

    public static class UserTypeExtensions
    {
        public static string ToString(this UserType userType)
        {
            return userType switch
            {
                UserType.Supplier => "Supplier",
                UserType.Customer => "Customer",
                _ => throw new ArgumentOutOfRangeException(nameof(userType), "Invalid UserType")
            };
        }
    }

    public class UserState
    {
        private static readonly Lazy<UserState> _instance = new(() => new UserState());

        public static UserState Instance => _instance.Value;

        public UserType? UserType { get; private set; } // Nullable to indicate unset state
        public string? UserId { get; private set; } // Nullable to indicate unset state

        private UserState() { }

        public void SetUserType(UserType userType)
        {
            if (UserType != null)
                throw new InvalidOperationException("UserType is already set. Reset before changing.");

            UserType = userType;
        }

        public void SetUserId(string userId)
        {
            if (UserType == null)
                throw new InvalidOperationException("UserType must be set before setting UserId.");

            if (UserId != null)
                throw new InvalidOperationException("UserId is already set. Reset before changing.");

            UserId = userId;
        }

        public UserType GetUserType()
        {
            if (UserType == null)
                throw new InvalidOperationException("UserType is not set.");

            return UserType.Value;
        }

        public string GetUserId()
        {
            if (UserId == null)
                throw new InvalidOperationException("UserId is not set.");

            return UserId;
        }

        public void Clear()
        {
            UserType = null;
            UserId = null;
        }
    }
}
