namespace chillhub.Entities
{
    public class Dashboard
    {
        public long Id { get; set; }

        public int UsersCount { get; set; }
        public int RolesCount { get; set; }
        public int PermissionsCount { get; set; }
        public int PermissionGroupsCount { get; set; }
        public int MediasCount { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
