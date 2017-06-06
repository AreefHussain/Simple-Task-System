using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskSystem;

namespace Simple_Task_System.Controllers
{
    public class UserTasksController : Controller
    {
        // GET: UserTasks
        public ActionResult Index()
        {
            string sql = @"select ut.Id,ut.Name,ut.Description,ut.FromDate,ut.ToDate,ut.SubOf,
                            ut.CurrentStatus,ut.AssignedBy,ut.CompletedOn,ut.AssignedTo,apby.Name as AssignedByUsrName,
                            apto.Name as AssignedToUsrName ,utsb.Name as ParentTaskName from UserTasks ut
                            inner join ApplicationUsers apby on ut.AssignedBy = apby.Id
                            inner join ApplicationUsers apto on ut.AssignedTo = apto.Id
                            left join UserTasks utsb on ut.SubOf = utsb.Id ";

            var lstOfUserTasks = DAL.Db().Query<UserTaskViewModel>(sql);

            return View(lstOfUserTasks);
        }

        [HttpGet]
        public ActionResult TaskNew(int? id)
        {
            ViewBag.Users = DAL.Db().Query<ApplicationUsers>("select Id,Name from ApplicationUsers");
            ViewBag.Tasks = DAL.Db().Query<UserTasks>("select Id,Name from UserTasks");

            var taskObject = new UserTasks();

            if (id != null && id > 0)
            {
                taskObject =  DAL.Db().Fetch<UserTasks>("where id=@0", id).FirstOrDefault();
            }

            return View(taskObject);
        }
        [HttpPost]
        public ActionResult TaskNew(UserTasks userTaskdto)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (string.IsNullOrEmpty(userTaskdto.Name))
                        throw new Exception("Enter task name");

                    if (string.IsNullOrEmpty(userTaskdto.Description))
                        throw new Exception("Enter task description");

                    bool isUserExist = DAL.Db().Fetch<ApplicationUsers>(" where id=@0", userTaskdto.AssignedBy).Any();

                    if (!isUserExist)
                        throw new Exception("Invalid assigned by user found !!");

                    isUserExist = DAL.Db().Fetch<ApplicationUsers>(" where id=@0", userTaskdto.AssignedTo).Any();

                    if (!isUserExist)
                        throw new Exception("Invalid assigned to user found !!");

                    if (userTaskdto.ToDate < userTaskdto.FromDate)
                        throw new Exception("To date should be greater than from date");


                    DAL.Db().Save(userTaskdto);

                    TempData["ModelSuccess"] = "Task successfully saved";

                    userTaskdto = new UserTasks();
                    ModelState.Clear();
                }
                else
                    throw new Exception("some errors found.");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                
            }

            ViewBag.Users = DAL.Db().Query<ApplicationUsers>("select Id,Name from ApplicationUsers");
            ViewBag.Tasks = DAL.Db().Query<UserTasks>("select Id,Name from UserTasks");

            return View(userTaskdto);
        }

        public ActionResult TaskDelete(int id)
        {
            try
            {
                if (id <= 0)
                    throw new Exception("Select a task");

                var taskObject = DAL.Db().Fetch<UserTasks>("where id=@0", id).FirstOrDefault();

                if (taskObject == null)
                    throw new Exception("Task details not found");

                DAL.Db().Delete(taskObject);

                TempData["ModelSuccess"]= "Task successfully removed";

            }
            catch (Exception ex)
            {
                TempData["ModelError"] = ex.Message;
            }
            
            return RedirectToAction("Index");
        }

    }
}