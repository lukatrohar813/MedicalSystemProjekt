using AutoMapper;
using BL.Models;
using MedicalSystem.Models.Patient;
using MedicalSystem.ViewModels.Examination;
using MedicalSystem.ViewModels.Illness;
using MedicalSystem.ViewModels.Medicine;
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
			CreateMap<ExaminationDto, ExaminationEditViewModel>();

			CreateMap<MedicalHistoryCreateViewModel, MedicalHistoryDto>();
			CreateMap<MedicalHistoryEditViewModel, MedicalHistoryDto>();
			CreateMap<MedicalHistoryDto, MedicalHistoryEditViewModel>();

			CreateMap<PrescriptionCreateViewModel, PrescriptionDto>();
			CreateMap<PrescriptionEditViewModel, PrescriptionDto>();
			CreateMap<PrescriptionDto, PrescriptionEditViewModel>();

			CreateMap<IllnessCreateViewModel, IllnessDto>();
			CreateMap<IllnessEditViewModel, IllnessDto>();
			CreateMap<IllnessDto, IllnessEditViewModel>();

			CreateMap<MedicineCreateViewModel, MedicineDto>();
			CreateMap<MedicineEditViewModel, MedicineDto>();
			CreateMap<MedicineDto, MedicineEditViewModel>();
		}
	}
}