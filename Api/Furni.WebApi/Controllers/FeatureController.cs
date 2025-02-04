using AutoMapper;
using Furni.BusinessLayer.Abstract;
using Furni.DtoLayer.Dtos.FeatureDtos;
using Furni.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Furni.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetFeatureList()
        {
            var values = _featureService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetFeatureById(int id)
        {
            var values = _featureService.TGetById(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var values = _mapper.Map<Feature>(createFeatureDto);
            _featureService.TInsert(values);
            return Ok("Özellik Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var values = _featureService.TGetById(id);
            _featureService.TDelete(values);
            return Ok("Özellik Silindi");
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var values = _mapper.Map<Feature>(updateFeatureDto);
            _featureService.TUpdate(values);
            return Ok("Özellik Güncellendi");
        }
    }
}
