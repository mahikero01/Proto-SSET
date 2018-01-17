namespace SkillsetClient.Models
{
    public class SS_Associates
    {
        public int AssociateID { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public bool VPN { get; set; }
        public short DepartmentID { get; set; }
        public int LocationID { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
