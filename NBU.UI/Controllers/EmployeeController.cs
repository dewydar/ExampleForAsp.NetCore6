using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using NBU.BLL._Department;
using NBU.BLL._Employee;
using NBU.BLL._Gender;
using NBU.BLL._Job;
using NBU.Common.AttachmentsConfigure;
using NBU.DAL.Entities;
using NBU.DAL.ViewModel;

namespace NBU.UI.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeBLL _Bll;
        private readonly DepartmentBLL _DeptBll;
        private readonly GenderBLL _GenderBll;
        private readonly JobBLL _JobBLL;
        
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<EmployeeController> _localizer;
        public EmployeeController(IEmployeeBLL Bll, IDepartmentBLL DeptBll, IGenderBLL GenderBll, IJobBLL JobBLL,
                                    IMapper mapper, IStringLocalizer<EmployeeController> localizer)
        {
            _Bll = Bll as EmployeeBLL;
            _DeptBll = DeptBll as DepartmentBLL;
            _GenderBll = GenderBll as GenderBLL;
            _JobBLL = JobBLL as JobBLL;
            _mapper = mapper;
            _localizer = localizer;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Details() => PartialView();
        public async Task<JsonResult> LoadDataGrid()
        {
            var employees = await _Bll.GetList(null, new List<string> { "Job", "Gender" , "DocumentInfo" });
            var data = employees.Select(z => new
            {
                Id = z.Id,
                FirstName = z.FirstName,
                LastName = z.LastName,
                DateOfBirth = z.DateOfBirth,
                Salary = z.Salary,
                GenderType = z.Gender?.NameEn,
                JobName = z.Job?.NameEn,
                idAndName = new { Id=z.Id,Name=z.FirstName+z.LastName},
                //FiePath=(z.DocumentInfo!=null)? z.DocumentInfo?.FilePath+"/"+z.DocumentInfo?.Id+"."+z.DocumentInfo?.FileType:"",
                //FiePath = (z.DocumentInfo != null) ? "../Attachments/Employees/"+ z.Id +"/" + z.DocumentInfo?.Id + "." + z.DocumentInfo?.FileType : ""
                FiePath = (z.DocumentInfo != null) ? AttachmentsController.CreateDocumentPath("Employees",z.Id.ToString(),z.DocumentInfoId.ToString(), z.DocumentInfo.FileType) : ""
            })
                      .OrderByDescending(z => z.Id)
                      .ToList();

            return Json(data);
        }
        public async Task<PartialViewResult> Form(int Id = 0, string FormType = null)
        {
            EmployeeVM ViewModel = new EmployeeVM();
            if (Id == 0 && FormType == "Add")
            {
            }
            else if (Id > 0 && FormType == "Edit")
            {
                var entity=await _Bll.GetOne(z=>z.Id== Id, new List<string>{ "Job" , "DocumentInfo" });
                if (entity != null)
                {
                    ViewModel = _mapper.Map<Employee, EmployeeVM>(entity);
                    ViewModel.DepartmentId= entity?.Job?.DepartmentId;
                    
                    ViewModel.FilePath = (ViewModel.DocumentInfo != null) ? "../Attachments/Employees/" + ViewModel.Id + "/" + ViewModel.DocumentInfo?.Id + "." + ViewModel.DocumentInfo?.FileType : string.Empty;
                }
            }
            ViewModel.FormName = FormType;
            var ListOfDep = await _DeptBll.GetList();
            ViewModel.Departments = ListOfDep.Select(z => new ListOptions { Name = z.NameEn, Value = z.Id }).ToList();
            var ListOfGender = await _GenderBll.GetList();
            List<GenderVM> ViewModelGender = _mapper.Map<List<Gender>, List<GenderVM>>(ListOfGender);
            ViewModel.Genders = ViewModelGender.Select(z => new ListOptions { Name = z.Name, Value = z.Id }).ToList();

            return PartialView(ViewModel);
        }
        public async Task<JsonResult> GetJobByDepID(int DepartmentId)
        {
            var ListOfJobs = await _JobBLL.JobsByDepartment(DepartmentId);
            var jobs = ListOfJobs.Select(z => new ListOptions { Name = z.NameEn, Value = z.Id }).ToList();
            return Json(jobs);
        }
        [HttpPost]
        public async Task<JsonResult> PostModel(EmployeeVM ViewModel)
        {
            string _message = string.Empty;
            if (ModelState.IsValid)
            {
                var entity = _mapper.Map<EmployeeVM, Employee>(ViewModel);
                if (ViewModel.Id == 0 && ViewModel.FormName == "Add")
                {
                    entity.CreateOn = DateTime.Now;
                    if (ViewModel.DocumentAttached != null)
                    {
                        entity.DocumentInfo = new DocumentInfo()
                        {
                            FileName = ViewModel.DocumentAttached.FileName,
                            FileType = HandleDocumentExtension.GetExtension(ViewModel.DocumentAttached.FileName.Split('.')),
                            FilePath = Path.Combine(Directory.GetCurrentDirectory(),
                          "wwwroot/Attachments",
                          "Employees",
                          path4: $"{entity.Id}")
                        };
                        
                    }
                    await _Bll.Add(entity);
                    if (entity.Id>0 && entity.DocumentInfoId > 0)
                    {
                        FileManager.CheckFilePath(entity.DocumentInfo.FilePath);
                        var path = Path.Combine(entity.DocumentInfo.FilePath, path2: $"{entity.DocumentInfo.Id}.{entity.DocumentInfo.FileType}");
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await ViewModel.DocumentAttached.CopyToAsync(stream);
                        }
                    }
                    _message = _localizer["AddedSuccessfully"];
                    return Json(new { add = true, done = true, message = _message });
                }
                else if (ViewModel.Id != 0 && ViewModel.FormName == "Edit")
                {
                    entity.UpdateOn=DateTime.Now;
                    if (ViewModel.DocumentAttached != null)
                    {
                        entity.DocumentInfo = new DocumentInfo()
                        {
                            Id=entity.DocumentInfoId!=null&& entity.DocumentInfoId >0?(int)entity.DocumentInfoId:0,
                            FileName = ViewModel.DocumentAttached.FileName,
                            FileType = HandleDocumentExtension.GetExtension(ViewModel.DocumentAttached.FileName.Split('.')),
                            FilePath = Path.Combine(Directory.GetCurrentDirectory(),
                              "wwwroot/Attachments",
                              "Employees",
                              path4: $"{entity.Id}")
                        };
                        
                    }
                    await _Bll.Update(entity);
                    if (ViewModel.DocumentAttached != null)
                    {
                        if (!string.IsNullOrEmpty(ViewModel.FilePath))
                            FileManager.DeleteFolder(ViewModel.FilePath);
                        FileManager.CheckFilePath(entity.DocumentInfo.FilePath);
                        var path = Path.Combine(entity.DocumentInfo.FilePath, path2: $"{entity.DocumentInfo.Id}.{entity.DocumentInfo.FileType}");
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await ViewModel.DocumentAttached.CopyToAsync(stream);
                        }
                    }
                    _message = _localizer["EditSuccessfully"];
                    return Json(new { edit = true, done = true, message = _message });
                }
            }
            _message = _localizer["AddedFaild"];
            return Json(new { add = true, done = false, message = _message });
        }
        [AcceptVerbs("POST")]
        public async Task<JsonResult> Delete(int Id)
        {
            string _message = string.Empty;
            try
            {
                var current = await _Bll.GetOne(z => z.Id == Id);
                int result = await _Bll.Delete(current);
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
