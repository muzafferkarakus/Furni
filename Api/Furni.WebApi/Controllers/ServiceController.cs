using AutoMapper;
using Furni.BusinessLayer.Abstract;
using Furni.DtoLayer.Dtos.ServiceDtos;
using Furni.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Furni.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        private readonly IMapper _mapper;

        public ServiceController(IServiceService ServiceService, IMapper mapper)
        {
            _serviceService = ServiceService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ServiceList()
        {
            var values = _serviceService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult ServiceListById(int id)
        {
            var values = _serviceService.TGetById(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateService(CreateServiceDto createServiceDto)
        {
            var values = _mapper.Map<Service>(createServiceDto);
            _serviceService.TInsert(values);
            return Ok("Hizmetler Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteService(int id)
        {
            var values = _serviceService.TGetById(id);
            _serviceService.TDelete(values);
            return Ok("Hizmetler Silindi");
        }

        [HttpPut]
        public IActionResult UpdateService(UpdateServiceDto updateServiceDto)
        {
            var values = _mapper.Map<Service>(updateServiceDto);
            _serviceService.TUpdate(values);
            return Ok("Hizmetler Güncellendi");
        }
    }
}
