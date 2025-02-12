using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.IService
{
	public interface IExportService
	{
		byte[] ExportPatientsToCsv(IEnumerable<PatientDto> patients);
		Task<byte[]> ExportDetailedPatientToCsvAsync(int patientId);
		string GenerateFileName(string prefix);
	}
}
