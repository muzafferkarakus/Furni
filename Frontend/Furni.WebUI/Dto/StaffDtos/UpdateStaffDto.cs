namespace Furni.WebUI.Dto.StaffDtos
{
    public class UpdateStaffDto
    {
        public int StaffId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile file { get; set; }
    }
}
