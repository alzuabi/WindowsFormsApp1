using MULTISYSDbContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PullAndClassification.Utils
{
    public static class Session
    {
        public static DatabaseContext context = new DatabaseContext();

        private static Project currentProject;
        public static Project CurrentProject { get => currentProject; set => currentProject = value; }
        public static int CurrentProjectId { get => currentProjectId; set => currentProjectId = value; }
        //public static int? DefaultProjectId { get => defaultProjectId; set => defaultProjectId = value; }

        private static int currentProjectId = UserSetting.getCurrentProjectId(context);


        //private static int? defaultProjectId = context.Projects.OrderByDescending(p => p.CreatedAt).FirstOrDefault()?.Id;
    }
}
