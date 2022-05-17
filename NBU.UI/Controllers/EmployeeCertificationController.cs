using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using NBU.BLL._EmployeeCertification;
using NBU.DAL.Entities;
using NBU.DAL.ViewModel;

namespace NBU.UI.Controllers
{
    public class EmployeeCertificationController : Controller
    {
        private readonly EmployeeCertificationBLL _BLL;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<EmployeeCertificationController> _localizer;
        public EmployeeCertificationController(IEmployeeCertificationBLL BLL,IMapper mapper, IStringLocalizer<EmployeeCertificationController> localizer)
        {
            _BLL = BLL as EmployeeCertificationBLL;
            _mapper = mapper;
            _localizer = localizer;
        }
        public IActionResult Index(int EmployeeId,string Name)
        {
            ViewBag.EmployeeId = EmployeeId.ToString();
            ViewBag.EmployeeName = Name.ToString();
            return View();
        }
        public async Task<IActionResult> Details(int? EmployeeId = 0) {
            ViewBag.EmployeeId = EmployeeId.ToString();
            return PartialView();
        }
        public async Task<JsonResult> LoadDataGrid(int EmployeeId = 0)
        {
            var employeesCertification = await _BLL.GetList(z => z.EmployeeId == EmployeeId);
            var data = employeesCertification.Select(z => new
            {
                Id = z.Id,
                CertificationName = z.CertificationName,
                CertificationDate = z.CertificationDate
            }).OrderByDescending(z => z.Id).ToList();
            return Json(data);
        }
        public async Task<PartialViewResult> Form(int EmployeeId=0, int Id = 0, string FormType = null)
        {
            EmployeeCertificationVM ViewModel= new EmployeeCertificationVM();
            if (Id == 0 && !string.IsNullOrEmpty(FormType) && FormType == "Add") { 
            ViewModel.CertificationDate=DateTime.Now;
            }
            ViewModel.FormType = FormType;
            ViewModel.EmployeeId = EmployeeId;
            return PartialView(ViewModel);
        }
        public async Task<JsonResult> PostModel(EmployeeCertificationVM ViewModel)
        {
            string _message = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = _mapper.Map<EmployeeCertificationVM, EmployeeCertification>(ViewModel);
                    if (ViewModel.Id == 0 && ViewModel.FormType == "Add")
                    {
                        entity.CreateOn = DateTime.Now;
                        await _BLL.Add(entity);
                        _message = _localizer["AddedSuccessfully"];
                        return Json(new { add = true, done = true, message = _message });
                    }
                }
                _message = _localizer["AddedFaild"];
                return Json(new { add = true, done = false, message = _message });
            }
            catch (Exception)
            {
                _message = _localizer["AddedFaild"];
                return Json(new { add = true, done = false, message = _message });
            }
        }
        [AcceptVerbs("POST")]
        public async Task<JsonResult> Delete(int Id)
        {
            string _message = string.Empty;
            try
            {
                var current = await _BLL.GetOne(z => z.Id == Id);
                int result = await _BLL.Delete(current);
                _message = _localizer["DeletedSuccessfully"];
                return Json(new { done = true, message = _message });

            }
            catch (Exception x)
            {
                _message = _localizer["ErrorDeleteRelatedData"];
                return Json(new { done = false, message = _message });
            }
        }
    }
}
