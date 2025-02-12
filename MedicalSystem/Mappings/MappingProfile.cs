using AutoMapper;
using BL.Models;
using MedicalSystem.Models.Patient;
using MedicalSystem.ViewModels.Examination;
using MedicalSystem.ViewModels.MedicalHistory;
using MedicalSystem.ViewModels.Prescription;

namespace MedicalSystem.Mappings
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<PatientCreateViewModel, PatientCreateDto>();
			CreateMap<PatientEditViewModel, PatientUpdateDto>();
			CreateMap<PatientDto, PatientDetailsDto>();

			CreateMap<ExaminationCreateViewModel, ExaminationDto>();
			CreateMap<ExaminationEditViewModel, ExaminationDto>();

			CreateMap<MedicalHistoryCreateViewModel, MedicalHistoryDto>();
			CreateMap<MedicalHistoryEditViewModel, MedicalHistoryDto>();

			CreateMap<PrescriptionCreateViewModel, PrescriptionDto>();
			CreateMap<PrescriptionEditViewModel, PrescriptionDto>();

			CreateMap<PatientDto, PatientEditViewModel>();
			CreateMap<ExaminationDto, ExaminationEditViewModel>();
			CreateMap<MedicalHistoryDto, MedicalHistoryEditViewModel>();
			CreateMap<PrescriptionDto, PrescriptionEditViewModel>();
		}
	}
}
