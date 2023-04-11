using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelForm
{
    internal interface IRecordRepository
    {
        /*
        void AddRecord(Record record);
        void UpdateRecord(Record record);
        void DeleteRecord(Record record);
        */

        Record NextRecord();

        Record PreviousRecord();
        Record GetRecordById();

        IEnumerable<Record> GetAllRecords();
    }
}
