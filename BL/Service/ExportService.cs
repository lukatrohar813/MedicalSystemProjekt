using BL.IService;
using BL.Models;
using System.Text;

namespace BL.Service
{
	public class ExportService : IExportService
	{
		private readonly IPatientService _patientService;
		private readonly IMedicalHistoryService _medicalHistoryService;
		private readonly IExaminationService _examinationService;
		private readonly IPrescriptionService _prescriptionService;

		public ExportService(
			IPatientService patientService,
			IMedicalHistoryService medicalHistoryService,
			IExaminationService examinationService,
			IPrescriptionService prescriptionService)
		{
			_patientService = patientService;
			_medicalHistoryService = medicalHistoryService;
			_examinationService = examinationService;
			_prescriptionService = prescriptionService;
		}

		public byte[] ExportPatientsToCsv(IEnumerable<PatientDto> patients)
		{
			var builder = new StringBuilder();

			builder.AppendLine("Patient Number,First Name,Last Name,OIB,Date of Birth,Gender");

			foreach (var patient in patients)
			{
				builder.AppendLine($"{patient.PatientNumber}," +
								 $"{patient.FirstName}," +
								 $"{patient.LastName}," +
								 $"{patient.OIB}," +
								 $"{patient.DateOfBirth:dd.MM.yyyy}," +
								 $"{patient.Gender}");
			}

			return Encoding.UTF8.GetBytes(builder.ToString());
		}

		public async Task<byte[]> ExportDetailedPatientToCsvAsync(int patientId)
		{
			var patient = await _patientService.GetByIdAsync(patientId);
			if (patient == null)
			{
				throw new ArgumentException("Patient not found.", nameof(patientId));
			}

			var medicalHistories = await _medicalHistoryService.GetByPatientIdAsync(patientId);
			var examinations = await _examinationService.GetByPatientIdAsync(patientId);
			var prescriptions = await _prescriptionService.GetByPatientIdAsync(patientId);

			var builder = new StringBuilder();

			builder.AppendLine("PATIENT INFORMATION");
			builder.AppendLine($"Patient Number,{patient.PatientNumber}");
			builder.AppendLine($"Name,{patient.FirstName} {patient.LastName}");
			builder.AppendLine($"OIB,{patient.OIB}");
			builder.AppendLine($"Date of Birth,{patient.DateOfBirth:dd.MM.yyyy}");
			builder.AppendLine($"Gender,{patient.Gender}");
			builder.AppendLine();

			builder.AppendLine("MEDICAL HISTORY");
			builder.AppendLine("Disease,Start Date,End Date,Status");
			foreach (var history in medicalHistories)
			{
				builder.AppendLine($"{history.DiseaseName},{history.StartDate:dd.MM.yyyy},{(history.EndDate?.ToString("dd.MM.yyyy") ?? "Ongoing")},{(history.EndDate.HasValue ? "Recovered" : "Ongoing")}");
			}
			builder.AppendLine();

			builder.AppendLine("EXAMINATIONS");
			builder.AppendLine("Date,Type,Notes");
			foreach (var exam in examinations)
			{
				builder.AppendLine($"{exam.ExaminationDateTime:dd.MM.yyyy HH:mm},{exam.ExaminationType},{exam.Notes?.Replace(",", ";")}");
			}
			builder.AppendLine();

			builder.AppendLine("PRESCRIPTIONS");
			builder.AppendLine("Date,Medicine,Dosage,Instructions");
			foreach (var prescription in prescriptions)
			{
				builder.AppendLine($"{prescription.PrescriptionDate:dd.MM.yyyy},{prescription.MedicineName},{prescription.Dosage},{prescription.Instructions?.Replace(",", ";")}");
			}

			return Encoding.UTF8.GetBytes(builder.ToString());
		}

		public string GenerateFileName(string prefix) =>
			$"{prefix}_export_{DateTime.Now:yyyyMMdd}.csv";
	}
}