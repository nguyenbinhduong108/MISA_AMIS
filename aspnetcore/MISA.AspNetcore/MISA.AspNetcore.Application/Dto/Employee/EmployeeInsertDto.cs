using MISA.AspNetcore.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AspNetcore.Application
{
    public class EmployeeInsertDto : BaseAuditDto
    {
        /// <summary>
        /// Id nhân viên
        /// </summary>
        public Guid EmployeeId { get; set; }
        /// <summary>
        /// Mã nhân viên
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string EmployeeCode { get; set; }
        /// <summary>
        /// Họ tên
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }
        /// <summary>
        /// Mã đơn vị
        /// </summary>
        public Guid DepartmentId { get; set; }
        /// <summary>
        /// Mã vị trí
        /// </summary>
        public Guid? PositionId { get; set; }
        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// Giới tính
        /// </summary>
        public Gender? Gender { get; set; }
        /// <summary>
        /// Số CCCD
        /// </summary>
        public string? IdentityNumber { get; set; }
        /// <summary>
        /// Ngày cấp
        /// </summary>
        public DateTime? IdentityDate { get; set; }
        /// <summary>
        /// Nơi cấp
        /// </summary>
        public string? IdentityPlace { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string? Address { get; set; }
        /// <summary>
        /// ĐT dị động
        /// </summary>
        public string? PhoneNumber { get; set; }
        /// <summary>
        /// ĐT cố định
        /// </summary>
        public string? LandingPhone { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// tài khoản ngân hàng
        /// </summary>
        public string? BankingAccount { get; set; }
        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        public string? BankingName { get; set; }
        /// <summary>
        /// Chi nhánh ngân hàng
        /// </summary>
        public string? BankingBranch { get; set; }
    }
}