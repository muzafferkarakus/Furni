using AutoMapper;
using Furni.BusinessLayer.Abstract;
using Furni.DtoLayer.Dtos.StaffDtos;
using Furni.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Furni.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;
        private readonly IMapper _mapper;

        public StaffController(IStaffService StaffService, IMapper mapper)
        {
            _staffService = StaffService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult StaffList()
        {
            var values = _staffService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult StaffListById(int id)
        {
            var values = _staffService.TGetById(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateStaff(CreateStaffDto createStaffDto)
        {
            var values = _mapper.Map<Staff>(createStaffDto);
            _staffService.TInsert(values);
            return Ok("Ekip Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteStaff(int id)
        {
            var values = _staffService.TGetById(id);
            _staffService.TDelete(values);
            return Ok("Ekip Silindi");
        }

        [HttpPut]
        public IActionResult UpdateStaff(UpdateStaffDto updateStaffDto)
        {
            var values = _mapper.Map<Staff>(updateStaffDto);
            _staffService.TUpdate(values);
            return Ok("Ekip Güncellendi");
        }
    }
}
