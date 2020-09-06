using System.Linq;
using System.Threading.Tasks;
using DeviceManager.Business.Interfaces;
using DeviceManager.Business.Models;
using DeviceManager.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IElectricMeterBusiness _electricMeterBusiness;
        private readonly IWaterMeterBusiness _waterMeterBusiness;
        private readonly IGatewayBusiness _gatewayBusiness;

        public HomeController(
            IElectricMeterBusiness electricMeterBusiness,
            IWaterMeterBusiness waterMeterBusiness,
            IGatewayBusiness gatewayBusiness
        )
        {
            _electricMeterBusiness = electricMeterBusiness;
            _waterMeterBusiness = waterMeterBusiness;
            _gatewayBusiness = gatewayBusiness;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> RegisterElectricMeter()
        {
            ViewBag.ElectricMeters = await _electricMeterBusiness.All();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterElectricMeter(ElectricMeterViewModel model)
        {
            var response = new ApiResponseModel();
            if (!ModelState.IsValid)
            {
                response.SetMessage("INVALID_INPUT").SetData(ModelState.Values.SelectMany(v => v.Errors));
                return Json(response);
            }

            var insertResult = await  _electricMeterBusiness.Add(new ElectricMeterDto
            {
                SerialNumber = model.SerialNumber,
                FirmwareVersion = model.FirmwareVersion,
                State = model.State
            });

            response
                .SetStatus(insertResult.Success)
                .SetMessage(insertResult.Message)
                .SetData(insertResult.Data);

            return Json(response);
        }

        public async Task<IActionResult> RegisterWaterMeter()
        {
            ViewBag.WaterMeters = await _waterMeterBusiness.All();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterWaterMeter(WaterMeterViewModel model)
        {
            var response = new ApiResponseModel();
            if (!ModelState.IsValid)
            {
                response.SetMessage("INVALID_INPUT").SetData(ModelState.Values.SelectMany(v => v.Errors));
                return Json(response);
            }

            var insertResult = await _waterMeterBusiness.Add(new WaterMeterDto
            {
                SerialNumber = model.SerialNumber,
                FirmwareVersion = model.FirmwareVersion,
                State = model.State
            });

            response
                .SetStatus(insertResult.Success)
                .SetMessage(insertResult.Message)
                .SetData(insertResult.Data);

            return Json(response);
        }

        public async Task<IActionResult> RegisterGateway()
        {
            ViewBag.Gateways = await _gatewayBusiness.All();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterGateway(GatewayViewModel model)
        {
            var response = new ApiResponseModel();
            if (!ModelState.IsValid)
            {
                response.SetMessage("INVALID_INPUT").SetData(ModelState.Values.SelectMany(v => v.Errors));
                return Json(response);
            }

            var insertResult = await _gatewayBusiness.Add(new GatewayDto
            {
                SerialNumber = model.SerialNumber,
                FirmwareVersion = model.FirmwareVersion,
                State = model.State,
                IP = model.IP,
                Port = model.Port
            });

            response
                .SetStatus(insertResult.Success)
                .SetMessage(insertResult.Message)
                .SetData(insertResult.Data);

            return Json(response);
        }
    }
}
