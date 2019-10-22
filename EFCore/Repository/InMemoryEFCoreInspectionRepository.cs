using System;
using System.Collections.Generic;
using System.Text;
using EFCore.Configuration.EfCore;
using EFCore.Poco;

namespace EFCore.Repository
{

    public interface IInMemoryEFCoreInspectionRepository
    {
        int AddInspection(InspectionPoco inspectionPoco);
        int GetItemInMemory();
    }

    public class InMemoryEFCoreInspectionRepository : IInMemoryEFCoreInspectionRepository
    {
        private int _getInMemory;

        public int AddInspection(InspectionPoco inspectionPoco)
        {
            using (var db = new MemoryContext())
            {

                db.InspectionDbSet.Add(inspectionPoco);

                db.SaveChanges();

                _getInMemory++;
                return inspectionPoco.InspectionId;
            }
        }


        public int GetItemInMemory()
        {
            return _getInMemory;
        }

    }

}
