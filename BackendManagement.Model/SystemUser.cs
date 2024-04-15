using FreeSql.DataAnnotations;

namespace BackendManagement.Model
{
    /// <summary>
    /// 系统用户
    /// </summary>
    public class SystemUser
    {
        [Column(IsIdentity = true, IsPrimary = true)]
        public int SystemUserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public int UserAge { get; set; }
    }
}
