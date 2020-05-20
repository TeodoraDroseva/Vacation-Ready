using System;

namespace Vacation_Ready.Models
{
    public class RequestsModel
    {
        public int Id { get; set; }
        public DateTime DateSent { get; set; }
        public int UserId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime UntilDate { get; set; }
        public int LeaveTypeId { get; set; }
        public bool HalfDay { get; set; }
        public string AttachmentUrl { get; set; }
        public bool Approved { get; set; }
        public LeaveTypesModel LeaveType { get; set; }
    }
}