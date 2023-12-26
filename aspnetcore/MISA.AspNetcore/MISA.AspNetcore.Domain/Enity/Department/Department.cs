namespace MISA.AspNetcore.Domain
{
    public class Department : BaseAuditEntity, IEntity<Guid>
    {
        /// <summary>
        /// Id phòng ban
        /// </summary>
        public Guid DepartmentId { get; set; }
        /// <summary>
        /// Tên phòng ban
        /// </summary>
        public string DepartmentName { get; set; }

        public Guid GetId()
        {
            return DepartmentId;
        }

        public void SetId(Guid id)
        {
            DepartmentId = id;
        }
    }
}