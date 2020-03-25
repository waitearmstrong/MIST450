using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using WVHSMVCAppArmstrong.Data;

namespace WVHSMVCAppArmstrong.Models
{
    public class SchoolRepo : ISchoolRepo
    {
        private ApplicationDbContext database;

        public SchoolRepo(ApplicationDbContext dbContext)
        {
            this.database = dbContext;
        }
        public List<School> ListAllSchools()
        {
            List<School> schoolList = database.Schools.ToList<School>();
            return schoolList;
        }

        public List<School> ListSchoolsForRegionalVoting(string classification, int region,int schoolIDofVotingCoach)
        {
            List<School> schoolList = database.Schools.ToList<School>();

            schoolList = schoolList.Where(s => s.SchoolClassification == classification && s.SchoolRegion == region)
                .ToList<School>();

            School schoolOfCoachVoting = database.Schools.Find(schoolIDofVotingCoach);

            schoolList.Remove(schoolOfCoachVoting);
            return schoolList;
        }
    }
}
