using MULTISYSDbContext.Models;
using MULTISYSUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PullAndClassification.Utils
{
    public static class Session
    {
        public static DatabaseContext context = new();

        private static Project? currentProject;
        public static Project? CurrentProject { get => currentProject; set => currentProject = value; }
        public static int CurrentProjectId { get => currentProjectId; set => currentProjectId = value; }
        public static UserSetting UserSetting { get => userSetting; set => userSetting = value; }

        //public static int? DefaultProjectId { get => defaultProjectId; set => defaultProjectId = value; }

        private static int currentProjectId = UserSetting.getCurrentProjectId(context);

        private static string getRootDestination() {
            return UserSetting.getRootDistinationPath(GetDatabaseContext());
        }
        //private static int? defaultProjectId = context.Projects.OrderByDescending(p => p.CreatedAt).FirstOrDefault()?.Id;
        private static UserSetting userSetting;

        public static DatabaseContext GetDatabaseContext() {
            return new DatabaseContext();
        }

        public static string getTextMacth()=> GetDatabaseContext().ProjectFileNameStructures
                                               .Where(s => s.Id == CurrentProjectId)
                                               .Where(s => s.NameType == FNSTypes.fns_text_match.Id)
                                               .Select(s => s.Description).FirstOrDefault();
    }
}
