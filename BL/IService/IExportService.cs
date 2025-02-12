using BL.Models;

namespace BL.IService
{
	public interface IExportService
	{
		byte[] ExportPatientsToCsv(IEnumerable<PatientDto> patients);
		Task<byte[]> ExportDetailedPatientToCsvAsync(int patientId);
		string GenerateFileName(string prefix);
	}
}
