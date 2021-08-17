using AutoMapper;
using JobPortal.Domains;
using JobPortal.Models;
using JobPortal.Services.JobSeekerService;
using JobPortal.Services.RegisterService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Controllers
{
    public class JobSeekerController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IJobSeekerService _jobSeekerService;
        private readonly IRegisterService _registerService;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public JobSeekerController(IMapper mapper, IJobSeekerService jobSeekerService,
            IRegisterService registerService, IWebHostEnvironment hostingEnvironment)
        {
            _mapper = mapper;
            _jobSeekerService = jobSeekerService;
            _registerService = registerService;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IActionResult> IndexAsync(int id)
        {
            var item = await _jobSeekerService.GetJobSeekerByFilterAsync(q => q.Register_id == id);
            var model = _mapper.Map<JobSeekerModel>(item);
            return View(model);
        }

        public async Task<IActionResult> EditAsync(int id)
        {
            var item = await _jobSeekerService.GetJobSeekerByIdAsync(id);
            var model = _mapper.Map<JobSeekerModel>(item);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(JobSeekerModel model)
        {
            string imageFileName = null;
            string cvFileName = null;

            if (model == null)
                return null;
            var item = await _jobSeekerService.GetJobSeekerByIdAsync(model.Id);

            if (model.Image == null)
            {
                imageFileName = item.Image;
            }
            else
            {
                imageFileName = CreateFileUploadPath(model.Image.FileName, "Images");
                model.Image.CopyTo(new FileStream(imageFileName, FileMode.Create));
            }
            if (model.Cv == null)
            {
                cvFileName = item.Cv;
            }
            else
            {
                cvFileName = CreateFileUploadPath(model.Cv.FileName, "CV");
                model.Cv.CopyTo(new FileStream(cvFileName, FileMode.Create));
            }
            var entity = _mapper.Map<JobSeeker>(model);
           // entity.FullName = model.Name;
            entity.CreatedAt = item.CreatedAt;
            entity.Register_id = item.Register_id;
            entity.Image = imageFileName;
            entity.Cv = cvFileName;
            await _jobSeekerService.UpdateJobSeekerAsync(entity);
                //new JobSeeker { 
            //    Id = item.Id,
            //    CreatedAt = item.CreatedAt,
            //    FullName = "sakib",
            //    Institute="abc",
            //    Register_id = item.Register_id
            //});
            return RedirectToAction("Index", new { id = item.Register_id });
        }

        protected string CreateFileUploadPath(string fileName, string folderName)
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, folderName);
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            return filePath;
            //model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
        }
    }
}
