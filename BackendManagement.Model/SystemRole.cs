using FreeSql.DataAnnotations;

namespace BackendManagement.Model
{
    /// <summary>
    /// 系统角色
    /// </summary>
    public class SystemRole
    {
        [Column(IsIdentity = true, IsPrimary = true)]
        public int SystemRoleId { get; set; }
        public string RoleName { get; set; }=string.Empty;
    }
}
